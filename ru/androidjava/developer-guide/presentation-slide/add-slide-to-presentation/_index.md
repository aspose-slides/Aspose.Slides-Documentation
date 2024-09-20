---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /androidjava/add-slide-to-presentation/
---

## **Добавить слайд в презентацию**
{{% alert color="primary" %}} 

Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит **Мастер / Макет** слайд и другие **Обычные** слайды. Это означает, что файл презентации содержит как минимум один или несколько слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для Android через Java. Каждый слайд имеет уникальный идентификатор, и все Обычные слайды расположены в порядке, заданном индексом, начинающимся с нуля.

{{% /alert %}} 

Aspose.Slides для Android через Java позволяет разработчикам добавлять пустые слайды в их презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (коллекция объектов слайдов контента), предоставляемое объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции слайдов контента, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- Выполните некоторую работу с новым пустым слайдом.
- Наконец, сохраните файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).

```java
// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Создать экземпляр класса SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Добавить пустой слайд в коллекцию Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Выполнить некоторую работу с новым слайдом

    // Сохранить файл PPTX на диск
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```