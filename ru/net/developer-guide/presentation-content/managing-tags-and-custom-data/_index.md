---
title: Управление тегами и пользовательскими данными в презентациях в .NET
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/net/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- добавить тег
- парные значения
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для .NET, с примерами для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

С учётом того, что *слайд* является одним из элементов презентаций, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими частями — например, с пользовательскими тегами, определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Теги представляют собой пары строковых ключей и значений. 
{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для .NET для [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если вам нужно классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и задать в качестве значений соответствующие страны (США, Мексика и Канада). 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) с помощью Aspose.Slides для .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


Теги также можно задавать для [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


Или для любой отдельной [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **FAQ**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение одновременно.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имен тегов для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); она возвращает массив всех имён тегов.