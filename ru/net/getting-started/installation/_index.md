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
description: "Узнайте, как быстро установить Aspose.Slides для .NET. Пошаговое руководство, системные требования и примеры кода — начните работать с презентациями PowerPoint уже сегодня!"
---

## **Windows**
NuGet предоставляет самый простой способ загрузки и установки API Aspose для .NET на ПК. 

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. Откройте Microsoft Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект. 
3. Перейдите через **Tools** > **NuGet package manager**. 
4. На вкладке **Browse** введите *Aspose Slides* в поле поиска. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Выберите **Aspose.Slides.NET** и нажмите **Install**. 
   * Если нужно обновить Aspose.Slides — предположив, что он уже установлен — нажмите **Update** вместо этого. 

Выбранный API будет загружен и добавлен в ваш проект.

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

Это способ добавить [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) через консоль менеджера пакетов:

1. Откройте Microsoft Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект. 
3. Перейдите через **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Выполните команду: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Будет установлен последний полный релиз в ваше приложение. 

* При желании можно добавить суффикс `-prerelease` к команде, чтобы установить также последние предрелизные версии (включая хотфиксы).

 Подсказка **Installing Aspose.Slides.NET** появляется в нижней части окна. 
![todo:image_alt_text](installation_4.png)

После завершения загрузки вы увидите подтверждающие сообщения. 

Если вы не знакомы с [Aspose EULA](https://about.aspose.com/legal/eula), вам стоит ознакомиться с лицензией по указанному URL. 
![todo:image_alt_text](installation_5.png)

В вашем приложении должно появиться сообщение о том, что Aspose.Slides успешно добавлен и подключён. 
![todo:image_alt_text](installation_6.png)

В консоли Package Manager Console можно выполнить команду `Update-Package Aspose.Slides.NET` для проверки обновлений пакета Aspose.Slides. При наличии обновлений они устанавливаются автоматически. Суффикс `-prerelease` также можно использовать для обновления до последнего предрелиза.
#### **Considerations When Running on a Shared Server Environment**
Мы настоятельно рекомендуем запускать все компоненты Aspose .NET с набором разрешений **Full Trust**, поскольку компоненты Aspose иногда требуют доступа к реестру и файлам, расположенным вне виртуального каталога — например, при чтении шрифтов. 

Кроме того, компоненты Aspose.NET основаны на базовых классах .NET, и некоторые из этих классов также требуют разрешения Full Trust для определённых операций.

Поставщики интернет‑услуг, которые размещают несколько приложений разных компаний, обычно используют уровень безопасности Medium Trust. В .NET 2.0 такой уровень может привести к ограничениям, влияющим на работу Aspose.Slides:

- **RegistryPermission** недоступен. Это означает, что нельзя обращаться к реестру, что необходимо для перечисления установленных шрифтов при рендеринге документов. 
- **FileIOPermission** ограничен. Это означает, что доступ к файлам возможен только внутри иерархии виртуального каталога вашего приложения. Это также может помешать чтению шрифтов во время экспорта. 

По указанным причинам настоятельно советуем запускать Aspose.Slides с разрешениями **Full Trust**. При использовании **Medium trust** возможны несоответствия — некоторые функции библиотеки (например, рендеринг) могут не работать при выполнении определённых задач. 

## **macOS**

NuGet предоставляет самый простой способ загрузки и установки Aspose.Slides для .NET на Mac. 

**Install Prerequisite**

Пространство имён `System.Drawing` работает по‑другому в macOS, поэтому необходимо установить mono-libgdiplus. 

> В .NET 5 и предыдущих версиях пакет NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) работает на Windows, Linux и macOS. Однако существуют различия между платформами. На Linux и macOS функциональность GDI+ реализуется библиотекой [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Эта библиотека не устанавливается по умолчанию в большинстве дистрибутивов Linux и не поддерживает всю функциональность GDI+ на Windows и macOS. Есть платформы, где libgdiplus вообще недоступна. Чтобы использовать типы из пакета System.Drawing.Common на Linux и macOS, необходимо установить libgdiplus отдельно. Подробнее см. [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) или [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus). 

Для отдельной установки mono-libgdiplus на вашем Mac см. [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) в документации .NET. 

### **Install Aspose.Slides**

1. Откройте Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект. 
3. Перейдите через **Project** > **Manage NuGet Packages...** 
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Введите *Aspose.Slides* в поле поиска. 
5. Выберите **Aspose.Slides for .NET** и нажмите **Add Package**. 
6. Добавьте простой фрагмент кода. 
   * Вы можете скопировать код со [this page](/slides/ru/net/create-presentation/). 
7. Запустите приложение. 
8. Откройте *folder/bin/Debug/presentation_file_name* вашего проекта. 

## **FAQ**

**Is there a free version or trial limitation?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, который добавляет водяные знаки и может иметь другие ограничения. Чтобы снять ограничения, необходимо применить действующую [license](/slides/ru/net/licensing/).