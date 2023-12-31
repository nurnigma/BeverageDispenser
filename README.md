# Веб-приложение "Автомат по продаже напитков"
## Описание

Данное веб-приложение представляет собой имитацию работы автомата по продаже напитков. Автомат принимает монеты номиналом 1, 2, 5 и 10 рублей. В автомате загружены напитки, которые можно купить, внеся сумму, равную или превышающую их стоимость.

### Приложение разработано с использованием .NET и языка C#, с применением следующих технологий:

- ASP.NET CORE
- EntityFramework
- Ajax

## Структура проекта
- /Controllers: Директория, содержащая контроллеры, отвечающие за обработку запросов.
- /Models: Директория, содержащая модели данных, используемые в приложении.
- /Views: Директория, содержащая представления, отображаемые пользователю.
- appsettings.json: Файл конфигурации приложения.
- Program.cs: Класс, отвечающий за конфигурацию и запуск приложения.
- App_Data: Содержит базу данных в виде файла

## Инструкции по установке и запуску
1. Установите Visual Studio 2012 или более позднюю версию.
2. Установите MS SQL Express (2012 или выше). MS SQL Express является бесплатной версией MS SQL и может быть загружена с официального сайта Microsoft.
3. Клонируйте репозиторий проекта из GitHub: [https://github.com/nurnigma/BeverageDispenser.git].
4. Откройте проект в Visual Studio.
5. Измените файл appsettings.json, чтобы настроить подключение к вашей базе данных MS SQL Express либо ничего не меняйте, подключение осуществляется с помощью директивы AttachDbFilename.
6. Запустите проект в Visual Studio и приложение будет развернуто на локальном сервере.

## Использование
**Пользовательский интерфейс**
Откройте веб-браузер и перейдите по адресу, где развернуто приложение.

На пользовательском интерфейсе вы сможете выполнить следующие действия:
  -Внести сумму, щелкнув на кнопки с номиналом монет (1, 2, 5, 10). 
  - Если монета заблокирована, соответствующая кнопка будет подсвечена и недоступна для нажатия.
  - Выбрать напиток, щелкнув на соответствующую картинку. При этом количество оставшихся напитков уменьшится на единицу, а из внесенной суммы будет вычтена стоимость напитка. 
  - Недоступно выбирать закончившиеся напитки или напитки, стоимость которых превышает внесенную сумму.
  - Получить оставшуюся сумму в виде сдачи.
##
**Административный интерфейс**
Для доступа к административному интерфейсу добавьте секретный ключ в адресную строку браузера.
Пример: http://localhost:5000/admin?secretKey=your-secret-key.
***Настроеивать можно через appsetting.***
На административном интерфейсе вы сможете выполнить следующие действия:
  - Администрировать ассортимент напитков: добавлять, удалять напитки, изменять их количество и стоимость.
