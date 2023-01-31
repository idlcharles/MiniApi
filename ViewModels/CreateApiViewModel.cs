using Flunt.Notifications;
using Flunt.Validations;
using MiniApi.Models;

namespace MiniApi.ViewModels
{
    public class CreateApiViewModel : Notifiable<Notification>
    {
        public string Title { get; set; }

        public Api MapApi()
        {
          var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título da tarefa")
                .IsGreaterThan(Title, 5, "O titulo deve conter mais de 5 caracteres");

            AddNotifications(contract);

                return new Api(Guid.NewGuid(), Title, false);
        }

    }
}
