---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /ru/java/add-slide-to-presentation/
---

## **Добавить слайд в презентацию**
{{% alert color="primary" %}} 

Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим несколько фактов о слайдах. Каждый файл презентации PowerPoint содержит **Мастер / Макет** слайд и другие **Обычные** слайды. Это означает, что файл презентации содержит как минимум один или несколько слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для Java. Каждый слайд имеет уникальный идентификатор, и все Обычные слайды организованы в порядке, заданном индексом, начиная с нуля.

{{% /alert %}} 

Aspose.Slides для Java позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (коллекция объектов слайдов) объекта [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции слайдов, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection).
- Выполните некоторые действия с вновь добавленным пустым слайдом.
- Наконец, сохраните файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).

```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    // Создайте экземпляр класса SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Добавьте пустой слайд в коллекцию слайдов
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Выполните некоторые действия с вновь добавленным слайдом

    // Сохраните файл PPTX на диск
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```