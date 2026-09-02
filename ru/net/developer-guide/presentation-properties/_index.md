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
description: "Освойте управление свойствами презентаций в Aspose.Slides for .NET и упростите поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for .NET поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба типа свойств легко доступны и управляются с помощью API Aspose.Slides for .NET.

Aspose.Slides позволяет работать со свойствами документов презентаций через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/). Экземпляр этого интерфейса возвращается свойством [Presentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/documentproperties/). Ниже приведены примеры, показывающие, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что поля **Application** и **Producer** нельзя изменять, так как они всегда будут отображать "Aspose Ltd." и "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с файлами. Существует два типа свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

Свойства **Built-in** содержат общую информацию о документе, такую как заголовок документа, имя автора, статистика документа и многое другое.

Свойства **Custom** определяются пользователями как пары **Name/Value**, где и имя, и значение задаются пользователем.

С помощью Aspose.Slides for .NET разработчики могут получать доступ и изменять как встроенные, так и пользовательские свойства.

Microsoft PowerPoint позволяет пользователям управлять свойствами документа, нажав значок Office, затем выбрав **File → Info → Properties**. После выбора **Advanced Properties** появляется диалоговое окно, где можно управлять всеми свойствами документа файла презентации.

В диалоговом окне **Properties** есть несколько вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Каждая вкладка предоставляет параметры для настройки конкретных типов информации, связанной с файлом PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами.

## **Доступ к встроенным свойствам**

Эти свойства, представленные интерфейсом [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (указывающий, является ли документ общим для разных производителей), **PresentationFormat**, **Subject**, **Title** и другие.

```cs
using Aspose.Slides;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

Изменение встроенных свойств файлов презентаций так же просто, как и их чтение. Вы можете просто присвоить строковое значение любой нужной собственности, и её значение будет обновлено. В примере ниже показано, как изменить встроенные свойства документа презентации.

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

Пользовательские свойства презентации позволяют разработчикам сохранять дополнительны​е метаданные или специфическую информацию внутри файла презентации. Aspose.Slides упрощает создание и управление этими пользовательскими свойствами программно. Ниже приведены примеры, демонстрирующие, как добавить пользовательские свойства к вашим презентациям.

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

## **Доступ к пользовательским свойствам и их изменение**

Aspose.Slides также позволяет разработчикам получать доступ к существующим пользовательским свойствам и легко изменять их значения. Эта функция помогает поддерживать точные метаданные и поддерживает динамические обновления на основе ввода пользователя или бизнес‑логики. Приведенные ниже примеры показывают, как получить и обновить значения пользовательских свойств в презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Получите доступ к пользовательским свойствам и измените их.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Отобразите имя и значение пользовательского свойства.
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

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и не могут быть полностью удалены. Однако их можно изменить или установить пустыми, если это допускает конкретное свойство.

**Что происходит, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавите пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется, так как Aspose.Slides автоматически обновляет значение свойства.

**Могу ли я получить доступ к свойствам презентации, не загружая её полностью?**

Да. Используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) и затем [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/) чтобы прочитать сохранённые метаданные документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/net/examine-presentation/) для полного примера отчёта и ограничений, специфичных для формата.