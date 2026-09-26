---
title: Установка
type: docs
weight: 70
url: /ru/net/installation/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Установите Aspose.Slides для .NET из NuGet на Windows, Linux и macOS: выберите один из двух пакетов, добавьте его с помощью .NET CLI или Visual Studio и установите предварительные требования для Linux."
---
## **Обзор**

В этой статье объясняется, как добавить Aspose.Slides для .NET в проект на Windows, Linux и macOS. Aspose.Slides распространяется через NuGet. Его можно добавить с помощью .NET CLI на любой операционной системе, либо с помощью NuGet Package Manager или Package Manager Console в Visual Studio на Windows. В статье также объясняется, какой из двух пакетов NuGet выбрать и что дополнительно требуется для Linux.

Перед установкой ознакомьтесь с поддерживаемыми операционными системами, реализациями .NET и дополнительными зависимостями в [Системных требованиях](/slides/ru/net/system-requirements/).

## **Выбор пакета**

Aspose.Slides для .NET публикуется в виде двух пакетов NuGet. Оба предоставляют одни и те же пространства имён и классы Aspose.Slides, поэтому ваш код не меняется при переключении между ними; меняются только ссылка на пакет и требования к платформе.

| Пакет | Для использования | Дополнительные требования |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Приложения Windows и .NET Framework | В Linux и macOS: библиотека `libgdiplus` и включённый переключатель `System.Drawing.EnableUnixSupport` при запуске приложения |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 или новее на Windows, Linux и macOS | В Linux: библиотека `fontconfig`, если она ещё не установлена |

Если вы не уверены, используйте Aspose.Slides.NET на Windows и Aspose.Slides.NET6.CrossPlatform на Linux и macOS. На Alpine Linux и на системах Linux, у которых glibc старее 2.23 (x64) или 2.39 (ARM64), используйте вместо этого Aspose.Slides.NET. [Системные требования](/slides/ru/net/system-requirements/) перечисляет поддерживаемые платформы каждого пакета.

## **Установка с помощью .NET CLI**

Эти шаги работают на Windows, Linux и macOS с .NET SDK 6 или новее. Создайте консольное приложение:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Затем добавьте пакет для вашей платформы. В проект добавьте только один из двух пакетов.

- На Windows: `dotnet add package Aspose.Slides.NET`
- На Linux и macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (в Linux сначала установите предварительные требования; см. [Linux](#linux))

Чтобы проверить, что пакет работает, замените содержимое *Program.cs* первым примером в [Создании презентаций](/slides/ru/net/create-presentation/) и запустите `dotnet run`. Он сохраняет *hello.pptx* в папке проекта.

## **Windows**

### **Метод 1: Установка или обновление Aspose.Slides через NuGet Package Manager**

1. Откройте Microsoft Visual Studio.  
2. Создайте консольное приложение или откройте существующий проект.  
3. В **Solution Explorer** щёлкните правой кнопкой мыши проект и выберите **Manage NuGet Packages** (или перейдите в **Project** > **Manage NuGet Packages**).  
4. Во вкладке **Browse** выполните поиск *Aspose.Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Щёлкните **Aspose.Slides.NET**, а затем нажмите **Install**.  
   * Если вы уже установили Aspose.Slides и хотите обновить его, вместо этого нажмите **Update**.

Пакет загружается и добавляется в ваш проект.

### **Метод 2: Установка или обновление Aspose.Slides через консоль Package Manager Console**

Так вы подключаете пакет [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) через консоль Package Manager Console:

1. Откройте Microsoft Visual Studio.  
2. Создайте консольное приложение или откройте существующий проект.  
3. Перейдите в **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Opening the Package Manager Console](installation_2.png)
4. Выполните эту команду: `Install-Package Aspose.Slides.NET`  
![Running the Install-Package command](installation_3.png)

Последняя версия устанавливается в ваш проект.

Сообщение **Installing Aspose.Slides.NET** появляется внизу окна.  
![Installation progress in the Package Manager Console](installation_4.png)

Когда загрузка завершится, появляются сообщения подтверждения. Пакет распространяется в соответствии с [Aspose EULA](https://about.aspose.com/legal/eula).  
![Installation confirmation messages](installation_5.png)

Aspose.Slides теперь добавлен в ваш проект и подключён.  
![Aspose.Slides referenced in the project](installation_6.png)

Чтобы обновить пакет, выполните `Update-Package Aspose.Slides.NET` в консоли Package Manager Console.

## **Linux**

Используйте шаги .NET CLI, описанные выше. Выберите пакет и установите его предварительные требования с помощью менеджера пакетов вашего дистрибутива. На Debian и Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: установить `fontconfig`.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: установить `libgdiplus` и включить поддержку Unix для System.Drawing до того, как приложение начнёт использовать Aspose.Slides.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Добавьте эту инструкцию в начале вашего приложения, перед любым вызовом Aspose.Slides. В *Program.cs* с верхнеуровневыми инструкциями разместите её после директив `using`:  

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

  Используйте этот пакет на Alpine Linux и на системах, у которых glibc слишком старая для Aspose.Slides.NET6.CrossPlatform.

Шрифты, используемые в ваших презентациях, или подходящие их замены, должны быть установлены в системе, чтобы текст отображался корректно. [Системные требования](/slides/ru/net/system-requirements/) описывают пакеты, необходимые Aspose.Slides.NET на Alpine Linux, включая шрифты.

## **macOS**

Используйте шаги .NET CLI, описанные выше, с пакетом **Aspose.Slides.NET6.CrossPlatform**, который поддерживает как Intel (x86_64), так и Apple silicon (ARM64) Mac:  

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Есть ли бесплатная версия или ограничения пробной версии?**

Да. Без лицензии Aspose.Slides работает в режиме оценки: он добавляет водяной знак «evaluation» к каждому сохраняемому слайду и обрезает текст, считанный из презентаций. Чтобы снять эти ограничения, примените действующую [лицензию](/slides/ru/net/licensing/).