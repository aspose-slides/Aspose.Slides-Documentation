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
description: "Управляйте свойствами презентаций в Aspose.Slides для .NET и оптимизируйте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides for .NET поддерживает **встроенные** и **пользовательские** свойства документа. Используйте эти свойства для чтения и обновления метаданных презентации, таких как автор, заголовок и пользовательские значения.

Aspose.Slides позволяет работать со свойствами документа презентации через интерфейс [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . Экземпляр этого интерфейса возвращается методом [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Ниже приведены примеры того, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Aspose.Slides управляет метаданными приложения и производителя при сохранении презентаций; эти поля идентифицируют программное обеспечение, создавшее вывод.
{{% /alert %}}

## **Управление свойствами презентации**

Свойства документа хранят описательную информацию вместе с содержимым презентации. Они делятся на две категории:

- **Встроенные свойства** содержат стандартные метаданные, такие как заголовок, автор и статистика документа.
- **Пользовательские свойства** хранят пары имя/значение, определённые пользователем.

Aspose.Slides for .NET предоставляет доступ к обеим категориям. В PowerPoint выберите **File → Info → Properties → Advanced Properties**, чтобы просмотреть метаданные документа. Диалоговое окно группирует информацию по вкладкам, таким как **Summary**, **Statistics**, **Contents** и **Custom**. Используйте вкладку **Custom** для управления пользовательскими свойствами.

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержимое презентации, так и свойства документа. Когда презентация зашифрована с помощью [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) установленного в `false`, её свойства документа остаются публичными. Приложение может затем установить [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) в `true` и прочитать публичные метаданные без предоставления пароля открытия.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) контролирует, что загружает Aspose.Slides; он ничего не дешифрует. Если свойства включены в шифрование, загрузка их без пароля завершается ошибкой. Если презентация не зашифрована, параметр игнорируется и загружается полная презентация.

Пример требует зашифрованную презентацию, у которой свойства документа оставлены публичными. Он проверяет режим загрузки с помощью [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) и затем читает встроенные свойства через [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, мультимедиа и другие объекты презентации недоступны. Приложения всегда должны проверять [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) перед выполнением операции, требующей полной модели объектов презентации.

{{% alert color="warning" title="Security" %}}
Публичные метаданные могут раскрыть имена авторов, заголовки, темы, ключевые слова, информацию о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только тогда, когда индексация, классификация, поиск или системы управления документами имеют конкретную потребность доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная с [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/), предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта, содержащего только метаданные, поскольку публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому их обновление требует правильного пароля открытия и полной загрузки.

Пример требует зашифрованную PPTX‑презентацию с публичными свойствами документа и известным паролем открытия. Он открывает полную презентацию с помощью [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) , чтобы проверить, что шифрование сохранено, и повторно открывает публичные метаданные без пароля для проверки новых значений:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Если приложению не разрешено расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Интерфейс [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) предоставляет встроенные метаданные через типизированные свойства, включая [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), и [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Этот пример открывает существующую презентацию и выводит её сохранённые метаданные в консоль. Значения зависят от входной презентации; некоторые поля могут быть пустыми.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **Изменение встроенных свойств**

Чтобы обновить встроенные метаданные, присвойте значения записываемым свойствам, раскрытым через [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Этот пример открывает существующую презентацию, задаёт [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), и [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), затем сохраняет обновлённую презентацию с помощью [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Сохранённый PPTX содержит новые метаданные.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Управление базой гиперссылок**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) хранит базовый адрес документа для относительных гиперссылок. Это полезно при перемещении презентации и связанных с ней файлов в другое место. Это отдельный параметр от [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) отдельной гиперссылки: изменение базы не переписывает сохранённые адреса ссылок и не меняет абсолютные назначения.

Пример требует презентацию, содержащую как относительную ссылку, например `target.html`, так и абсолютную ссылку, например `https://example.org/absolute.html`. Он читает существующую базу, задаёт новый базовый адрес и сохраняет, а затем открывает презентацию заново, чтобы проверить значение. Затем он очищает базу с помощью `string.Empty` и проверяет пустое значение в отдельном сохранённом файле. Замените пример базового адреса на расположение ваших связанных файлов.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Два сообщения проверки должны вывести `True`. Очистка базы оставляет отдельные адреса гиперссылок без изменений.

Относительная ссылка на `target.pptx` открывала `old/target.pptx`, когда база указывала на папку `old`. После изменения базы на папку `new`, сохранения и повторного открытия презентации та же ссылка открывала `new/target.pptx`. Абсолютная ссылка продолжала открывать тот же файл. Проверьте свои относительные ссылки в PowerPoint до и после перемещения презентации или изменения её базы.

## **Добавление пользовательских свойств презентации**

Пользовательские свойства хранят метаданные, которые не имеют соответствующего встроенного поля. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) позволяет присвоить значение по имени свойства. Этот пример создаёт презентацию, добавляет два текстовых значения и целочисленную версию, и сохраняет презентацию с помощью [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Присвоение значения существующему имени заменяет значение этого свойства.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Доступ и изменение пользовательских свойств**

Этот пример открывает презентацию, содержащую пользовательские свойства, и использует [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) , чтобы перебрать их. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) принимает нулевой индекс и возвращает имя, используемое [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Пример выводит каждое исходное имя и значение, заменяет каждое значение пронумерованной строкой независимо от его исходного типа и сохраняет изменения. Если пользовательских свойств нет, цикл не вносит изменений.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Рабочий пример**

Попробуйте онлайн‑приложение [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа с помощью API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и не могут быть полностью удалены. Однако их можно изменить или установить пустыми, если это разрешено для конкретного свойства.

**Что произойдёт, если я добавлю пользовательское свойство, которое уже существует?**

Если вы добавите пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется удалять или проверять свойство заранее, так как Aspose.Slides автоматически обновляет значение свойства.

**Могу ли я получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) , а затем [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) , чтобы прочитать сохранённые метаданные документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) . См. [Build a Lightweight Presentation Inventory](/slides/ru/net/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.

**Могу ли я читать публичные свойства зашифрованной презентации без её пароля открытия?**

Да. Презентация должна быть зашифрована с параметром [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) установленным в `false`, и её необходимо загрузить с помощью [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) установленного в `true`.

**Могу ли я обновить зашифрованный файл PPTX в режиме только свойств документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.