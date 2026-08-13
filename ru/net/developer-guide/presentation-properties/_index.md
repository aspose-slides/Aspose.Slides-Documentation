---
title: Управление свойствами презентации в .NET
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/net/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Пользовательские свойства
- Расширенные свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте свойствами презентации в Aspose.Slides for .NET, упрощая поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for .NET поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба типа свойств легко доступны и управляются с помощью API Aspose.Slides for .NET.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/). Экземпляр этого интерфейса возвращается свойством [Presentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/documentproperties/). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" %}} 
Please note that the **Application** and **Producer** fields cannot be modified, as these fields will always display "Aspose Ltd." and "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства позволяют сохранять полезную информацию вместе с файлами. Существует два типа свойств документа:

- System-defined (built-in) properties
- User-defined (custom) properties

**Built-in** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и прочее.

**Custom** свойства задаются пользователями в виде пар **Name/Value**, где как имя, так и значение задаются пользователем.

С помощью Aspose.Slides for .NET разработчики могут получать доступ и изменять как встроенные, так и пользовательские свойства.

Microsoft PowerPoint позволяет пользователям управлять свойствами документа, щёлкнув значок Office, затем выбрав **File → Info → Properties**. После выбора **Advanced Properties** появляется диалог, где можно управлять всеми свойствами презентации.

В диалоговом окне **Properties** есть несколько вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Каждая вкладка предоставляет параметры для настройки определённых типов информации, связанной с файлом PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые интерфейсом [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/), включают: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indicates whether the document is shared between different producers), **PresentationFormat**, **Subject**, **Title** и др.

```cs
using Aspose.Slides;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Отобразите встроенные свойства.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Изменение встроенных свойств**

Изменять встроенные свойства файлов презентаций так же просто, как получать к ним доступ. Достаточно присвоить строковое значение нужному свойству, и значение будет обновлено. В примере ниже показано, как изменить встроенные свойства документа презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Установите встроенные свойства.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Сохраните презентацию в файл.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Добавление пользовательских свойств презентации**

Пользовательские свойства презентации позволяют разработчикам сохранять дополнительные метаданные или специфическую информацию внутри файла презентации. Aspose.Slides упрощает создание и управление этими свойствами программно. В следующих примерах демонстрируется, как добавить пользовательские свойства к вашим презентациям.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation.
using Presentation presentation = new Presentation();

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Добавьте пользовательские свойства.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Сохраните презентацию в файл.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Доступ и изменение пользовательских свойств**

Aspose.Slides также позволяет получать доступ к существующим пользовательским свойствам и легко изменять их значения. Эта возможность помогает поддерживать точные метаданные и поддерживает динамические обновления на основе ввода пользователя или **business logic**. Примеры ниже показывают, как извлекать и обновлять значения пользовательских свойств в презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Доступ к пользовательским свойствам и их изменение.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Выведите имя и значение пользовательского свойства.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Измените значение пользовательского свойства.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Сохраните презентацию в файл.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа с помощью API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## ***FAQ**

### Как удалить встроенное свойство из презентации?

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если это позволяет конкретное свойство.

### Что произойдёт, если добавить пользовательское свойство, которое уже существует?

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит значение свойства.

### Можно ли получить доступ к свойствам презентации без полной загрузки презентации?

Да, можно получить доступ к свойствам презентации без полной загрузки, используя метод `GetPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/). Затем используйте метод `ReadDocumentProperties`, предоставленный интерфейсом [IPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/), чтобы эффективно прочитать свойства, экономя память и улучшая производительность.