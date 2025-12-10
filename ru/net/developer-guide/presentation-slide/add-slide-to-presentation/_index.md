---
title: Добавить слайды в презентации на .NET
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/net/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — бесшовное, эффективное вставление слайдов за секунды."
---

## **Добавить слайд в презентацию**
Прежде чем говорить о добавлении слайдов в файлы презентаций, обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит слайд Master / Layout и другие обычные слайды. Это означает, что файл презентации содержит минимум один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for .NET. Каждый слайд имеет уникальный Id, и все обычные слайды упорядочены в порядке, определённом нулевым индексом. Aspose.Slides for .NET позволяет разработчикам добавлять пустые слайды в их презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), задав ссылку на свойство Slides (коллекция объектов Slide), которое доступно у объекта Presentation.
- Добавьте пустой слайд в презентацию в конец коллекции содержимых слайдов, вызвав метод AddEmptySlide, доступный у объекта ISlideCollection.
- Выполните необходимые действия с только что добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Можно ли вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает операции над коллекциями слайдов и методы [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/), поэтому вы можете добавить слайд по требуемому индексу, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Новосозданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при вычислении индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), соответствующий требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [add it to the master](/slides/ru/net/slide-layout/) и затем использовать его.