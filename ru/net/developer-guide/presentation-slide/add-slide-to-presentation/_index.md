---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /ru/net/add-slide-to-presentation/
keywords: "Добавить слайд в презентацию, C#, Csharp, .NET, Aspose.Slides"
description: "Добавить слайд в презентацию на C# или .NET"
---

## **Добавить слайд в презентацию**
Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит слайд Master / Layout и другие обычные слайды. Это означает, что файл презентации содержит хотя бы один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для .NET. Каждый слайд имеет уникальный Id, и все обычные слайды упорядочены согласно нулевому индексу. Aspose.Slides для .NET позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), указав ссылку на свойство Slides (коллекция объектов Slide), предоставляемое объектом Presentation.
- Добавьте пустой слайд в презентацию в конец коллекции содержимых слайдов, вызвав методы AddEmptySlide, предоставляемые объектом ISlideCollection.
- Выполните необходимые действия с вновь добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Вопросы и ответы**

**Могу ли я вставить новый слайд в конкретное положение, а не только в конец?**

Да. Библиотека поддерживает коллекции слайдов и операции [вставить](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[клонировать](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/), поэтому вы можете добавить слайд в нужный индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего master, а новый слайд наследует от выбранного макета и связанного с ним master.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Новая созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при вычислении индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у master много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), который соответствует требуемой структуре ([Title and Content, Two Content и др.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [добавить его в master](/slides/ru/net/slide-layout/) и затем использовать его.