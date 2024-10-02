---
title: Слияние презентаций PowerPoint PPT, PPTX с помощью C#
linktitle: Слить Презентацию
type: docs
weight: 40
url: /ru/net/merge-presentation/
keywords: "Слияние PowerPoint, PPTX, PPT, объединение PowerPoint, слияние презентации, объединение презентации, C#, Csharp, .NET"
description: "Слияние или объединение презентаций PowerPoint на C# или .NET"
---

{{% alert title="Совет" color="primary" %}} 

Вам стоит обратить внимание на **бесплатное онлайн приложение** [Merger](https://products.aspose.app/slides/merger) от Aspose. Оно позволяет пользователям объединять презентации PowerPoint в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и сливать презентации в разных форматах (PPT в PPTX, PPTX в ODP и т.д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Слияние Презентации**

Когда вы [сливаете одну презентацию с другой](https://products.aspose.com/slides/net/merger/ppt/), вы фактически объединяете их слайды в одной презентации, чтобы получить один файл. 

{{% alert title="Информация" color="info" %}}

Большинство программ для работы с презентациями (PowerPoint или OpenOffice) не имеют функций, которые позволяют пользователям комбинировать презентации таким образом. 

Тем не менее, [**Aspose.Slides для .NET**](https://products.aspose.com/slides/net/) позволяет вам сливать презентации несколькими способами. Вы можете объединять презентации со всеми их формами, стилями, текстами, форматированием, комментариями, анимациями и т.д. без необходимости беспокоиться о потере качества или данных. 

**Смотрите также**

[Клонирование слайдов](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Что можно объединить**

С помощью Aspose.Slides вы можете объединить 

* целые презентации. Все слайды из презентаций оказываются в одной презентации
* конкретные слайды. Выбранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

{{% alert title="Заметка" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет вам объединять другие файлы:

* [Изображения](https://products.aspose.com/slides/net/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* И два разных файла, такие как [изображение в PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Варианты Слияния**

Вы можете применить опции, которые определяют, будет ли

* каждый слайд в выходной презентации сохранять уникальный стиль
* используемый специальный стиль для всех слайдов в выходной презентации. 

Для слияния презентаций Aspose.Slides предлагает методы [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Существуют несколько реализаций методов `AddClone`, которые определяют параметры процесса слияния презентаций. У каждого объекта Presentation есть коллекция [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), поэтому вы можете вызывать метод `AddClone` из презентации, в которую хотите объединить слайды. 

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в выходной презентации - это просто копия слайдов из источника. Поэтому вы можете вносить изменения в результирующие слайды (например, применять стили или параметры форматирования или макеты) без беспокойства о том, что исходные презентации потерпят влияние. 

## **Слияние Презентаций** 

Aspose.Slides предоставляет метод [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone), который позволяет вам объединять слайды, сохраняя при этом их макеты и стили (параметры по умолчанию). 

Этот код на C# показывает, как объединять презентации:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Слияние Презентаций с Мастером Слайда**

Aspose.Slides предоставляет метод [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2), который позволяет вам объединять слайды, применяя шаблон презентации мастера слайда. Таким образом, если необходимо, вы сможете изменить стиль для слайдов в выходной презентации. 

Этот код на C# демонстрирует описанную операцию:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Заметка" color="warning" %}} 

Макет слайда для мастера слайда определяется автоматически. Когда подходящий макет не может быть определен, если булевский параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет для исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Если вы хотите, чтобы слайды в выходной презентации имели другой макет слайда, используйте метод [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) вместо при слиянии. 

## **Слияние Конкретных Слайдов из Презентаций**

Этот код на C# показывает, как выбрать и объединить конкретные слайды из разных презентаций, чтобы получить одну выходную презентацию:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Слияние Презентаций с Макетом Слайда**

Этот код на C# показывает, как объединить слайды из презентаций, применяя ваш предпочтительный макет слайда к ним, чтобы получить одну выходную презентацию:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Слияние Презентаций с Разными Размероми Слайдов**

{{% alert title="Заметка" color="warning" %}} 

Вы не можете объединить презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, вам нужно изменить размер одной из презентаций, чтобы его размер соответствовал размеру другой презентации. 

Этот пример кода демонстрирует описанную операцию:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Слияние Слайдов в Раздел Презентации**

Этот код на C# показывает, как слить конкретный слайд в раздел презентации:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

Слайд добавляется в конец раздела. 

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). Используя этот онлайн-сервис, вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или изображения PNG в PNG, создавать [фото решетки](https://products.aspose.app/slides/collage/photo-grid) и многое другое. 

{{% /alert %}}