---
title: Добавить слайд в презентацию
type: docs
weight: 10
url: /ru/nodejs-java/add-slide-to-presentation/
---

## **Добавить слайд в презентацию**
{{% alert color="primary" %}} 

Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит слайд **Master / Layout** и другие **Normal** слайды. Это означает, что файл презентации содержит как минимум один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for Node.js via Java. Каждый слайд имеет уникальный Id, и все Normal Slides упорядочены в порядке, заданном нулевым индексом.

{{% /alert %}} 

Aspose.Slides for Node.js via Java позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (коллекцию объектов Slide содержимого), которое предоставляется объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции содержимых слайдов, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-), предоставляемые объектом [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection).
- Выполните необходимые действия с только что добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
```javascript
// Создать экземпляр класса Presentation, представляющего файл презентации
var pres = new aspose.slides.Presentation();
try {
    // Создать экземпляр класса SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Добавить пустой слайд в коллекцию Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Выполнить некоторые действия с только что добавленным слайдом
    // Сохранить файл PPTX на диск
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **FAQ**

**Могу ли я вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает коллекции слайдов и операции [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/), поэтому вы можете добавить слайд на необходимый индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Новая созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), который соответствует требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [добавить его в мастер](/slides/ru/nodejs-java/slide-layout/) и затем использовать его.