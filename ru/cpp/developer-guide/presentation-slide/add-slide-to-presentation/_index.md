---
title: Добавить слайды в презентации на C++
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/cpp/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко добавляйте слайды в свои презентации PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — бесшовное, эффективное вставление слайдов за секунды."
---

## **Добавить слайд в презентацию**
Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит слайд Master / Layout и другие обычные слайды. Это значит, что файл презентации содержит как минимум один слайд. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for C++. Каждый слайд имеет уникальный Id, а все обычные слайды упорядочены в порядке, заданном нулевым индексом. Aspose.Slides for C++ позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) , установив ссылку на свойство Slides (коллекция объектов Slide) , доступное через объект Presentation .
- Добавьте пустой слайд в презентацию в конец коллекции содержимых слайдов, вызвав методы AddEmptySlide , доступные через объект ISlideCollection .
- Выполните нужные операции с только что добавленным пустым слайдом .
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Могу ли я вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает коллекции слайдов и операции [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) , поэтому вы можете добавить слайд в требуемый индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего master, а новый слайд наследует от выбранного макета и связанного с ним master.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Ново созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у master‑а много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) , соответствующий требуемой структуре ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [add it to the master](/slides/ru/cpp/slide-layout/) и затем использовать его.