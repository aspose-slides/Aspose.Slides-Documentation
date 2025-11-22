---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /ru/net/managing-tags-and-custom-data
keywords: "Теги, Пользовательские данные, Значение для тегов, Добавление тегов, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавление тегов и пользовательских данных в презентации PowerPoint на C# или .NET"
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд (*slide*) является одним из элементов презентации, часть слайда (*slide part*) содержит содержимое одного слайда. Части слайда могут иметь явные связи со многими частями — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 

Теги по сути представляют собой пары строка‑ключ. 

{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for .NET для [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе определённого правила или свойства, то добавление тегов к этим презентациям может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и назначить в качестве значений соответствующие страны (США, Мексика и Канада). 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) с помощью Aspose.Slides for .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


Теги также могут быть заданы для [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
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

**Можно ли удалить все теги из презентации, слайда или фигуры одним действием?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) на [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/), чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.