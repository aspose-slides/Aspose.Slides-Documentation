---
title: Удалить слайд из презентации
type: docs
weight: 30
url: /ru/net/remove-slide-from-presentation/
keywords: "Удалить слайд, Удалить слайд, PowerPoint, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Удалить слайд из PowerPoint по ссылке или индексу в C# или .NET"
---

Если слайд (или его содержимое) становится лишним, вы можете удалить его. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , который инкапсулирует [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) , являющийся репозиторием всех слайдов в презентации. Используя указатели (ссылка или индекс) для известного объекта [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) , вы можете указать слайд, который хотите удалить. 

## **Удалить слайд по ссылке**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Получите ссылку на слайд, который нужно удалить, по его ID или индексу.
1. Удалите указанный слайд из презентации.
1. Сохраните изменённую презентацию. 

Этот код C# показывает, как удалить слайд по ссылке:
```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Получает слайд по его индексу в коллекции слайдов
    ISlide slide = pres.Slides[0];

    // Удаляет слайд по ссылке
    pres.Slides.Remove(slide);

    // Сохраняет изменённую презентацию
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Удалить слайд по индексу**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Удалите слайд из презентации по его позиции в индексе.
1. Сохраните изменённую презентацию. 

Этот код C# показывает, как удалить слайд по индексу:
```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Удаляет слайд по его индексу
    pres.Slides.RemoveAt(0);

    // Сохраняет изменённую презентацию
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Удалить неиспользуемый слайд макета**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ), позволяющий удалить нежелательные и неиспользуемые слайды макета. Этот код C# показывает, как удалить слайд макета из презентации PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Удалить неиспользуемый главный слайд**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ), позволяющий удалить нежелательные и неиспользуемые главные слайды. Этот код C# показывает, как удалить главный слайд из презентации PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Что происходит с индексами слайдов после их удаления?**

После удаления коллекция [slideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) переиндексируется: каждый последующий слайд сдвигается влево на одну позицию, поэтому прежние номера индексов становятся устаревшими. Если требуется стабильная ссылка, используйте постоянный ID слайда вместо его индекса.

**Отличается ли ID слайда от его индекса, и меняется ли он при удалении соседних слайдов?**

Да. Индекс — это позиция слайда, которая меняется при добавлении или удалении слайдов. ID слайда — это постоянный идентификатор и не меняется при удалении других слайдов.

**Как удаление слайда влияет на секции слайдов?**

Если слайд принадлежал секции, в этой секции просто будет на один слайд меньше. Структура секции остаётся; если секция становится пустой, вы можете [remove or reorganize sections](/slides/ru/net/slide-section/) по необходимости.

**Что происходит с заметками и комментариями, привязанными к слайду, после его удаления?**

[Notes](/slides/ru/net/presentation-notes/) и [comments](/slides/ru/net/presentation-comments/) привязаны к конкретному слайду и удаляются вместе с ним. Содержание остальных слайдов не затронуто.

**Чем отличается удаление слайдов от очистки неиспользуемых макетов/мастеров?**

Удаление удаляет конкретные обычные слайды из набора. Очистка неиспользуемых макетов/мастеров удаляет слайд‑макеты или мастер‑слайды, на которые ничего не ссылается, уменьшая размер файла без изменения оставшегося содержимого слайдов. Эти действия комплементарны: обычно сначала удаляют, затем проводят очистку.