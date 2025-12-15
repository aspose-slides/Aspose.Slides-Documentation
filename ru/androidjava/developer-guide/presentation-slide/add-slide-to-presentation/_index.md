---
title: Добавление слайдов в презентации на Android
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/androidjava/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Легко добавляйте слайды в свои презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java — бесшовное, эффективное вставление слайдов за секунды."
---

## **Добавить слайд в презентацию**
{{% alert color="primary" %}} 

Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит слайд **Master / Layout** и другие **Normal** слайды. Это означает, что файл презентации содержит как минимум один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for Android via Java. Каждый слайд имеет уникальный Id, и все Normal Slides упорядочены согласно индексу, начинающемуся с нуля.

{{% /alert %}} 

Aspose.Slides for Android via Java позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Инстанцируйте класс [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (коллекцию объектов Slide) объекта [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции контент‑слайдов, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Выполните необходимую работу с только что добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
```java
// Создайте объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Создайте объект класса SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Добавьте пустой слайд в коллекцию Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Выполните необходимые действия с только что добавленным слайдом

    // Сохраните файл PPTX на диск
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Можно ли вставить новый слайд в определённое положение, а не только в конец?**

Да. Библиотека поддерживает операции вставки и клонирования в коллекциях слайдов — [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), поэтому вы можете добавить слайд в нужный индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует его от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Новая презентация сразу содержит один пустой слайд с индексом 0. Это важно учитывать при вычислении индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера есть множество вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/), соответствующий требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). Если такой макет отсутствует, его можно [add it to the master](/slides/ru/androidjava/slide-layout/) и затем использовать.