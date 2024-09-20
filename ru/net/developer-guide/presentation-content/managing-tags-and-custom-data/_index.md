---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /net/managing-tags-and-custom-data
keywords: "Теги, Пользовательские данные, Значение тегов, Добавить теги, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте теги и пользовательские данные в презентации PowerPoint на C# или .NET"
---

## Хранение данных в файлах презентации

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

Слайд является одним из элементов презентаций, часть слайда содержит содержимое одного слайда. Части слайда могут иметь явные отношения ко многим частям, таким как Пользовательские Определенные Теги, определенные ISO/IEC 29500.

Пользовательские данные (специфические для презентации) или пользователя могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 

Теги по сути являются парами значений с ключом-строкой.

{{% /alert %}} 

## Получение значений тегов

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для .NET для [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## Добавление тегов в презентации

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- название пользовательского свойства - `MyTag`
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе конкретного правила или свойства, то вы можете извлечь выгоду от добавления тегов в эти презентации. Например, если вы хотите категоризировать или собрать все презентации из Североамериканских стран вместе, вы можете создать тег Северной Америки и затем назначить соответствующие страны (США, Мексика и Канада) в качестве значений.

Этот пример кода показывает, как добавить тег в [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) с использованием Aspose.Slides для .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Теги также могут быть установлены для [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Или для любого отдельного [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```