---
title: Удаление слайдов из презентаций в .NET
linktitle: Удалить слайд
type: docs
weight: 30
url: /ru/net/remove-slide-from-presentation/
keywords:
- удалить слайд
- удалить слайд
- удалить неиспользуемый слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Без труда удаляйте слайды из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Получайте понятные примеры кода на C# и ускоряйте свой рабочий процесс."
---

Если слайд (или его содержимое) становится избыточным, его можно удалить. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) — обёртку над [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), которая служит хранилищем всех слайдов в презентации. Зная указатель (ссылка или индекс) на объект [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/), можно указать слайд, который нужно удалить. 

## **Удалить слайд по ссылке**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Получите ссылку на слайд, который нужно удалить, по его ID или индексу.
1. Удалите указанный слайд из презентации.
1. Сохраните изменённую презентацию. 

Этот C#‑код демонстрирует, как удалить слайд по ссылке:
```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{
    // Получает слайд по его индексу в коллекции слайдов
    ISlide slide = pres.Slides[0];

    // Удаляет слайд по его ссылке
    pres.Slides.Remove(slide);

    // Сохраняет изменённую презентацию
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Удалить слайд по индексу**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Удалите слайд из презентации по его порядковому номеру.
1. Сохраните изменённую презентацию. 

Этот C#‑код демонстрирует, как удалить слайд по индексу:
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


## **Удалить неиспользуемые слайды макета**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ), позволяющий удалять нежелательные и неиспользуемые слайды макета. Этот C#‑код показывает, как удалить слайд макета из презентации PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Удалить неиспользуемые слайды мастера**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ), позволяющий удалять нежелательные и неиспользуемые слайды мастера. Этот C#‑код показывает, как удалить слайд мастера из презентации PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Что происходит с индексами слайдов после их удаления?**

После удаления [коллекция](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) переиндексируется: каждый последующий слайд смещается на одну позицию влево, поэтому прежние номера индексов устаревают. Если нужен стабильный указатель, используйте постоянный ID слайда, а не его индекс.

**Отличается ли ID слайда от его индекса и меняется ли он при удалении соседних слайдов?**

Да. Индекс — это позиция слайда, и он меняется при добавлении или удалении слайдов. ID слайда — постоянный идентификатор и не изменяется при удалении других слайдов.

**Как удаление слайда влияет на секции слайдов?**

Если слайд принадлежал секции, в этой секции просто окажется на один слайд меньше. Структура секции сохраняется; если секция становится пустой, её можно [удалить или реорганизовать](/slides/ru/net/slide-section/) по необходимости.

**Что происходит с заметками и комментариями, привязанными к удаляемому слайду?**

[Заметки](/slides/ru/net/presentation-notes/) и [комментарии](/slides/ru/net/presentation-comments/) привязаны к конкретному слайду и удаляются вместе с ним. Содержимое остальных слайдов остаётся нетронутым.

**В чём разница между удалением слайдов и очисткой неиспользуемых макетов/мастеров?**

Удаление устраняет конкретные обычные слайды из набора. Очистка неиспользуемых макетов/мастеров удаляет слайды макетов или мастеров, которые больше никем не используются, уменьшая размер файла без изменения содержимого оставшихся слайдов. Эти действия дополняют друг друга: обычно сначала удаляют слайды, затем проводят очистку.