---
title: Управление свойствами презентаций PowerPoint в C#
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
- Доступ к свойствам
- Изменение свойств
- Управление свойствами
- Метаданные документа
- Редактирование метаданных
- Язык проверки
- PowerPoint
- Презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Узнайте, как легко управлять, читать и редактировать свойства документов PowerPoint с помощью Aspose.Slides for .NET на C#. Повышайте продуктивность и автоматизируйте свой рабочий процесс!"
---

## **Обзор**

Aspose.Slides for .NET поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба типа свойств легко доступны и управляются с помощью API Aspose.Slides for .NET.

Для работы со свойствами документа Aspose.Slides предоставляет интерфейс [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/), доступный через свойство [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/). Разработчики могут использовать интерфейс [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) объекта `Presentation` для безболезненного чтения, изменения и управления свойствами презентации, как показано в примерах ниже.

{{% alert color="primary" %}} 
Обратите внимание, что поля **Application** и **Producer** невозможно изменить, так как они всегда отображают «Aspose Ltd.» и «Aspose.Slides for .NET x.x.x».
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с файлами. Существует два типа свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д.

**Пользовательские** свойства определяются пользователями как пары **Имя/Значение**, где и имя, и значение задаются пользователем.

С помощью Aspose.Slides for .NET разработчики могут получать доступ и изменять как встроенные, так и пользовательские свойства.

Microsoft PowerPoint позволяет пользователям управлять свойствами документа, щёлкнув по значку Office, затем выбрав **File → Info → Properties**. После выбора **Advanced Properties** открывается диалог, где можно управлять всеми свойствами презентации.

В диалоговом окне **Properties** есть несколько вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Каждая вкладка предоставляет параметры для настройки определённых видов информации, относящейся к файлу PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами.

## **Доступ к встроенным свойствам**

Эти свойства, объявленные интерфейсом [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (указание, общедоступен ли документ между разными производителями), **PresentationFormat**, **Subject**, **Title** и многое другое.
```cs
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Изменять встроенные свойства файлов презентаций так же просто, как их получать. Достаточно присвоить строковое значение нужному свойству, и значение свойства будет обновлено. В примере ниже показано, как изменить встроенные свойства документа презентации.
```cs
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

Пользовательские свойства презентации позволяют разработчикам хранить дополнительную метаинформацию или специфические данные внутри файла презентации. Aspose.Slides упрощает создание и управление этими пользовательскими свойствами программно. Ниже приведены примеры, демонстрирующие, как добавить пользовательские свойства к вашим презентациям.
```cs
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

Aspose.Slides также позволяет разработчикам получать доступ к существующим пользовательским свойствам и легко изменять их значения. Эта возможность помогает поддерживать точные метаданные и поддерживает динамические обновления на основе ввода пользователя или бизнес‑логики. Примеры ниже показывают, как получить и обновить значения пользовательских свойств в презентации.
```cs
// Создайте экземпляр класса Presentation, представляющего файл PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Получите доступ к пользовательским свойствам и измените их.
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


## **Пример в реальном времени**

Попробуйте онлайн‑приложение [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа с помощью API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или, если это допускается для конкретного свойства, установить их в пустую строку.

**Что произойдет, если я добавлю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Нет необходимости предварительно удалять или проверять свойство — Aspose.Slides автоматически обновит его значение.

**Могу ли я получить доступ к свойствам презентации, не загружая её полностью?**

Да, вы можете получить доступ к свойствам презентации без полной загрузки, используя метод `GetPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/). Затем используйте метод `ReadDocumentProperties`, предоставляемый интерфейсом [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/), чтобы эффективно считать свойства, экономя память и повышая производительность.