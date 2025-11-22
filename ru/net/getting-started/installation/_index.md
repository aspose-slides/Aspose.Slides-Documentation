---
title: Установка
type: docs
weight: 70
url: /ru/net/installation/
keywords: "Скачать Aspose.Slides, Установить Aspose.Slides, Установка Aspose.Slides, Windows, macOS, .NET"
description: "Установить Aspose.Slides для .NET в Windows или macOS"
---

## **Windows**
NuGet предоставляет самый простой путь для загрузки и установки API Aspose для .NET на ПК. 

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. Откройте Microsoft Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект. 
3. Перейдите в **Tools** > **NuGet package manager**.
4. На вкладке **Browse** введите *Aspose Slides* в поле поиска. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Выберите **Aspose.Slides.NET** и нажмите **Install**. 
   * Если нужно обновить Aspose.Slides — предполагая, что он уже установлен — нажмите **Update**. 

Выбранный API загружается и добавляется в ваш проект в качестве ссылки.

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

Так вы подключаете [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) через консоль диспетчера пакетов:

1. Откройте Microsoft Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект. 
3. Перейдите в **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Выполните команду: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Последний полный релиз будет установлен в ваше приложение. 

* При желании добавьте суффикс `-prerelease` к команде, чтобы установить также предрелизные версии (включая хотфиксы).

 Совет **Installing Aspose.Slides.NET** появляется в нижней части окна. 
![todo:image_alt_text](installation_4.png)

После завершения загрузки вы увидите сообщения подтверждения. 

Если вам незнаком [Aspose EULA](https://about.aspose.com/legal/eula), возможно, стоит ознакомиться с лицензией по указанному URL. 
![todo:image_alt_text](installation_5.png)

В вашем приложении вы должны увидеть, что Aspose.Slides успешно добавлен и подключён. 
![todo:image_alt_text](installation_6.png)

В консоли диспетчера пакетов можно выполнить команду `Update-Package Aspose.Slides.NET`, чтобы проверить наличие обновлений пакета Aspose.Slides. При наличии обновления они устанавливаются автоматически. Также можно использовать суффикс `-prerelease` для обновления до последней предрелизной версии.
#### **Considerations When Running on a Shared Server Environment**
Мы настоятельно рекомендуем запускать все компоненты Aspose .NET с набором разрешений **Full Trust**, поскольку иногда компоненты Aspose нуждаются в доступе к реестру и файлам, расположенным за пределами виртуального каталога — например, когда требуется чтение шрифтов. 

Кроме того, компоненты Aspose.NET основаны на базовых классах системы .NET, и некоторые из этих классов также требуют разрешения Full Trust для выполнения определённых операций.

Интернет‑провайдеры, хостящие несколько приложений от разных компаний, обычно используют уровень безопасности Medium Trust. В .NET 2.0 такой уровень может привести к ограничениям, влияющим на работу Aspose.Slides:

- **RegistryPermission** недоступен. Это означает, что вы не можете обращаться к реестру, что необходимо для перечисления установленных шрифтов при рендеринге документов.
- **FileIOPermission** ограничен. Вы сможете работать только с файлами в иерархии виртуального каталога вашего приложения. Это также может помешать чтению шрифтов во время экспорта. 

По вышеизложенным причинам мы настоятельно советуем использовать Aspose.Slides с разрешениями **Full Trust**. При работе в **Medium trust** могут возникнуть несоответствия — некоторые функции библиотеки (например, рендеринг) могут не работать при выполнении определённых задач. 

## **macOS**

NuGet предоставляет самый простой путь для загрузки и установки Aspose.Slides для .NET на Mac. 

**Install Prerequisite**

Пространство имён `System.Drawing` работает в macOS иначе, поэтому необходимо установить mono-libgdiplus. 

> В .NET 5 и более ранних версиях пакет NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) работает в Windows, Linux и macOS. Однако существуют различия между платформами. В Linux и macOS функциональность GDI+ реализуется библиотекой [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). Эта библиотека не устанавливается по умолчанию в большинстве дистрибутивов Linux и не поддерживает всю функциональность GDI+ из Windows и macOS. Существуют также платформы, где libgdiplus вовсе недоступна. Чтобы использовать типы из пакета System.Drawing.Common в Linux и macOS, необходимо установить libgdiplus отдельно. Подробнее см. [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) или [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus). 

Чтобы установить mono-libgdiplus отдельно на вашем Mac, обратитесь к [этой статье](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) в документации .NET. 

### **Install Aspose.Slides**

1. Откройте Visual Studio. 
2. Создайте простое консольное приложение или откройте существующий проект.
3. Перейдите в **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Введите *Aspose.Slides* в поле поиска. 
5. Выберите **Aspose.Slides for .NET** и нажмите **Add Package**. 
6. Добавьте простой фрагмент кода.
   * Вы можете скопировать код со [страницы](/slides/ru/net/create-presentation/).
7. Запустите приложение.
8. Откройте папку вашего проекта *folder/bin/Debug/presentation_file_name*.

## **FAQ**

**Is there a free version or trial limitation?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, при котором отображаются водяные знаки и могут быть другие ограничения. Чтобы снять ограничения, необходимо применить действующую [license](/slides/ru/net/licensing/).