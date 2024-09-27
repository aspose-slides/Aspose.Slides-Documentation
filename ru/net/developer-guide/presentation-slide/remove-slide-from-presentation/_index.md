---
title: Удалить слайд из презентации
type: docs
weight: 30
url: /ru/net/remove-slide-from-presentation/
keywords: "Удалить слайд, Удалить слайд, PowerPoint, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Удалить слайд из PowerPoint по ссылке или индексу на C# или .NET"

---

Если слайд (или его содержимое) становится избыточным, вы можете удалить его. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), который инкапсулирует [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), представляющий собой репозиторий для всех слайдов в презентации. Используя указатели (ссылку или индекс) известного объекта [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/), вы можете указать слайд, который хотите удалить.

## **Удалить слайд по ссылке**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, который вы хотите удалить, через его ID или индекс.
1. Удалите указанный слайд из презентации.
1. Сохраните измененную презентацию.

Этот код на C# показывает, как удалить слайд по его ссылке:

```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Получает доступ к слайду через его индекс в коллекции слайдов
    ISlide slide = pres.Slides[0];

    // Удаляет слайд по его ссылке
    pres.Slides.Remove(slide);

    // Сохраняет измененную презентацию
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Удалить слайд по индексу**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Удалите слайд из презентации по его индексному положению.
1. Сохраните измененную презентацию.

Этот код на C# показывает, как удалить слайд по его индексу:

```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Удаляет слайд по его индексу
    pres.Slides.RemoveAt(0);

    // Сохраняет измененную презентацию
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)), который позволяет вам удалить ненужные и неиспользуемые макетные слайды. Этот код на C# показывает, как удалить макетный слайд из PowerPoint-презентации:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)), который позволяет вам удалить ненужные и неиспользуемые мастер-слайды. Этот код на C# показывает, как удалить мастер-слайд из PowerPoint-презентации:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```