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
description: "Освойте свойства презентаций в Aspose.Slides для .NET и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for .NET поддерживает два типа свойств документа: **Built-in** и **Custom**. Оба этих типа свойств легко доступны и управляются с помощью API Aspose.Slides for .NET.

Aspose.Slides позволяет работать со свойствами презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/). Экземпляр этого интерфейса возвращается методом [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/documentproperties/). Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Note" %}}
Обратите внимание, что поля **Application** и **Producer** нельзя изменять, так как они всегда отображают «Aspose Ltd.» и «Aspose.Slides for .NET x.x.x».
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с файлами. Существует два типа свойств документа:

- Свойства, определённые системой (встроенные)
- Свойства, определённые пользователем (настраиваемые)

**Built-in** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д.

**Custom** свойства определяются пользователями в виде пар **Имя/Значение**, где и имя, и значение задаются пользователем.

С помощью Aspose.Slides for .NET разработчики могут получать доступ и изменять как встроенные, так и пользовательские свойства.

Microsoft PowerPoint позволяет пользователям управлять свойствами документа, щёлкнув значок Office, затем выбрав **File → Info → Properties**. После выбора **Advanced Properties** появляется диалог, где можно управлять всеми свойствами презентации.

В диалоговом окне **Properties** есть несколько вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Каждая вкладка предоставляет параметры для настройки определённых типов информации, связанной с файлом PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована с помощью [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) со значением `false`, её свойства документа остаются публичными. Приложение может затем установить [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) в `true` и прочитать публичные метаданные без указания пароля открытия.

`OnlyLoadDocumentProperties` управляет тем, что Aspose.Slides загружает; он ничего не дешифрует. Если свойства включены в шифрование, их загрузка без пароля завершится неудачей. Если презентация не зашифрована, параметр игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) и затем читает встроенные свойства через [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения всегда должны проверять `IsOnlyDocumentPropertiesLoaded` перед выполнением операций, требующих полной модели объектов презентации.

{{% alert color="warning" title="Security" %}}
Публичные метаданные могут раскрывать имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только когда системы индексирования, классификации, поиска или управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная с `OnlyLoadDocumentProperties`, предназначена только для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из такого объекта, поскольку публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions.Password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/isencrypted/) для проверки сохранения шифрования и повторно открывает публичные метаданные без пароля, чтобы проверить новые значения:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Если приложение не имеет права дешифровать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые интерфейсом [IDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/idocumentproperties/), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (указывает, совместно используется ли документ разными производителями), **PresentationFormat**, **Subject**, **Title** и др.

```cs
using Aspose.Slides;

// Создайте экземпляр класса Presentation, который представляет файл презентации.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
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

Изменять встроенные свойства файлов презентаций так же просто, как к ним обращаться. Достаточно присвоить строковое значение нужному свойству, и значение свойства будет обновлено. В примере ниже показано, как изменить встроенные свойства документа презентации.

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

Пользовательские свойства презентации позволяют разработчикам сохранять дополнительные метаданные или специфическую информацию внутри файла презентации. Aspose.Slides упрощает создание и управление этими пользовательскими свойствами программно. Ниже приведены примеры, демонстрирующие, как добавить пользовательские свойства к вашим презентациям.

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

Aspose.Slides также позволяет разработчикам получать доступ к существующим пользовательским свойствам и легко изменять их значения. Эта возможность помогает поддерживать точные метаданные и поддерживает динамические обновления на основе ввода пользователя или бизнес‑логики. Примеры ниже показывают, как получить и обновить значения пользовательских свойств в презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, который представляет файл PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Получите ссылку на объект типа IDocumentProperties, связанный с презентацией.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Доступ и изменение пользовательских свойств.
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

## **Живой пример**

Попробуйте онлайн‑приложение [**Просмотр и редактирование метаданных PowerPoint**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа с помощью API Aspose.Slides:

[![Просмотр и редактирование метаданных PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Часто задаваемые вопросы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить пустую строку, если конкретное свойство позволяет это.

**Что происходит, если я добавляю пользовательское свойство, которое уже существует?**

Если вы добавляете пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется предварительно удалять или проверять свойство, поскольку Aspose.Slides автоматически обновит его значение.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) и затем [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/readdocumentproperties/) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). См. [Build a Lightweight Presentation Inventory](/slides/ru/net/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.

**Можно ли прочитать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна быть зашифрована с параметром `EncryptDocumentProperties`, установленным в `false`, и должна быть загружена с `OnlyLoadDocumentProperties`, установленным в `true`.

**Можно ли обновить зашифрованный файл PPTX в режиме только‑свойств‑документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.