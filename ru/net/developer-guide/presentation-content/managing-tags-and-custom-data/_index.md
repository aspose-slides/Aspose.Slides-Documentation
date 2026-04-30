---
title: Управление тегами и пользовательскими данными в презентациях на .NET
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
## **Обзор**

Эта статья объясняет, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные хранятся в файлах PPTX, отмечается, что специфичные для презентации данные могут существовать в виде тегов и пользовательских XML‑частей, а также определяется, что теги представляют собой пары «ключ‑значение» строк.

Также показано, как читать значения тегов и как добавлять теги к презентации, отдельному слайду или фигуре. Кроме того, в статье рассматриваются типичные задачи управления тегами, такие как очистка всех тегов, удаление тега по имени и получение списка имен тегов.

## **Хранение данных в файлах презентаций**

Файлы PPTX — объекты с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

При том, что *слайд* является одним из элементов презентации, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные отношения со многими другими частями — например, с пользовательскими тегами — определенными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/itagcollection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Теги по сути являются парами строк‑ключ. 
{{% /alert %}} 

## **Получение значений тегов**

В Slides тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для .NET для [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation):

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

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, можете создать тег «North American» и присвоить в качестве значений соответствующие страны (США, Мексика, Канада). 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) с помощью Aspose.Slides для .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Или любой отдельной [Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Ограничения**

Теги, добавленные через коллекцию `CustomData.Tags`, сохраняются только внутри файла PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, присвоенный как тег, нельзя получить из PDF‑файла с тегами.

**Workaround**: Вы можете сохранить пользовательский идентификатор в свойстве объекта **Alt Text** (например, `shape.AlternativeText = "MyId"`). После экспорта в PDF Alt Text может появиться в структуре тегов PDF.

## **Часто задаваемые вопросы**

**Могу ли я удалить все теги из презентации, слайда или фигуры за одну операцию?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/clear/), которая удаляет все пары «ключ‑значение» сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имен тегов для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/ru/net/aspose.slides/tagcollection/); она вернёт массив со всеми именами тегов.