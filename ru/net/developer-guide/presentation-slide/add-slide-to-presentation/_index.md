---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /ru/net/add-slide-to-presentation/
keywords: "Добавить слайд в презентацию, C#, Csharp, .NET, Aspose.Slides"
description: "Добавить слайд в презентацию на C# или .NET"
---

## **Добавить слайд в презентацию**
Перед тем как говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит основной/макетный слайд и другие обычные слайды. Это означает, что файл презентации содержит по крайней мере один или несколько слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для .NET. Каждый слайд имеет уникальный идентификатор, и все обычные слайды упорядочены по индексу, начинающемуся с нуля. Aspose.Slides для .NET позволяет разработчикам добавлять пустые слайды в их презентации. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), установив ссылку на свойство Slides (коллекция объектов слайдов) объекта Presentation.
- Добавьте пустой слайд в презентацию в конце коллекции слайдов, вызвав методы AddEmptySlide, предоставленные объектом ISlideCollection.
- Выполните некоторые действия с вновь добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}