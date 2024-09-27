---
title: Свойства презентации - доступ к свойствам PowerPoint презентации или их модификация на C#
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/net/presentation-properties/
keywords: "как удалить последние изменения в powerpoint, свойства PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Свойства презентации PowerPoint на C# или .NET"
---


## **Живой пример**
Попробуйте [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) онлайн-приложение, чтобы увидеть, как работать с свойствами документа через API Aspose.Slides:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **О свойствах презентации**
Как мы описали ранее, Aspose.Slides для .NET поддерживает два вида свойств документа: **Встроенные** и **Пользовательские** свойства. Таким образом, разработчики могут получить доступ к обоим видам свойств с использованием API Aspose.Slides для .NET. Aspose.Slides для .NET предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties), который представляет свойства документа, связанные с файлом презентации через свойство [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index). Разработчики могут использовать свойство [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties), представляющее **Объект Презентации**, для доступа к свойствам документа файлов презентации, как описано ниже:



{{% alert color="primary" %}} 

Обратите внимание, что вы не можете устанавливать значения для полей **Application** и **Producer**, потому что Aspose Ltd. и Aspose.Slides для .NET x.x.x будут отображаться в этих полях.

{{% /alert %}} 


## **Управление свойствами презентации**
Microsoft PowerPoint предоставляет возможность добавлять некоторые свойства к файлам презентации. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентации). Существует два вида свойств документа, как указано ниже

- Свойства, определенные системой (встроенные)
- Свойства, определенные пользователем (пользовательские)

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика документа и так далее. **Пользовательские** свойства - это свойства, которые определяются пользователями в формате **Имя/Значение**, где имя и значение задаются пользователем. Используя Aspose.Slides для .NET, разработчики могут получать доступ и модифицировать значения встроенных свойств, а также пользовательских свойств. Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентации. Все, что вам нужно сделать, это нажать на значок Office и перейти к меню **Подготовить | Свойства | Расширенные свойства** в Microsoft PowerPoint 2007. После выбора пункта меню **Расширенные свойства** появится диалог, позволяющий вам управлять свойствами документа файла PowerPoint. В **Диалоге свойств** вы увидите много вкладок, таких как **Общие, Резюме, Статистика, Содержимое и Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, относящиеся к файлам PowerPoint. Вкладка **Пользовательские** используется для управления пользовательскими свойствами файлов PowerPoint.
## **Доступ к встроенным свойствам**
Эти свойства, представленные объектом **IDocumentProperties**, включают: **Создатель (Автор)**, **Описание**, **Ключевые слова**, **Создано** (Дата создания), **Изменено**, **Дата последнего печатания**, **Последний изменивший**, **Ключевые слова**, **SharedDoc** (Общая ли между разными производителями?), **Формат презентации**, **Тема** и **Название**

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **Изменение встроенных свойств**
Изменение встроенных свойств файлов презентации так же легко, как и доступ к ним. Вы можете просто назначить строковое значение любому желаемому свойству, и значение свойства будет изменено. В приведенном ниже примере мы продемонстрировали, как можно изменить встроенные свойства документа файла презентации.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **Добавить пользовательские свойства презентации**
Aspose.Slides для .NET также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример приведен ниже, который показывает, как установить пользовательские свойства для презентации.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **Доступ и изменение пользовательских свойств**
Aspose.Slides для .NET также позволяет разработчикам получать доступ к значениям пользовательских свойств. Пример приведен ниже, который показывает, как вы можете получить доступ и изменить все эти пользовательские свойства для презентации.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **Проверьте, изменялась ли презентация или создана**
Aspose.Slides для .NET предоставляет возможность проверить, была ли презентация изменена или создана. Пример приведен ниже, который показывает, как проверить, была ли презентация создана или изменена.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

Установить язык по умолчанию

## **Установить язык проверки**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (представляемое классом [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)), чтобы вы могли установить язык проверки для документа PowerPoint. Язык проверки - это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот код C# показывает, как установить язык проверки для PowerPoint:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // установите идентификатор языка проверки
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Установить язык по умолчанию**

Этот код C# показывает, как установить язык по умолчанию для всей презентации PowerPoint: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Добавляет новую прямоугольную фигуру с текстом
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Новый текст";
    
    // Проверяет язык первой части
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```