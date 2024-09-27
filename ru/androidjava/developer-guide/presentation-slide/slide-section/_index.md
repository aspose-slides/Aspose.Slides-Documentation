---
title: Секция слайдов
type: docs
weight: 90
url: /ru/androidjava/slide-section/
---

С Aspose.Slides для Android через Java вы можете организовать презентацию PowerPoint на секции. Вы можете создать секции, которые содержат определенные слайды.

Вам может понадобиться создать секции и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией с другими людьми или командой — и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы имеете дело с презентацией, содержащей много слайдов — и вам трудно управлять ее содержимым или редактировать его сразу.

В идеале вы должны создать секцию, в которой размещены похожие слайды — слайды имеют что-то общее или могут существовать в группе на основе правила — и дать секции название, которое описывает находящиеся внутри нее слайды.

## Создание секций в презентациях

Чтобы добавить секцию, которая будет содержать слайды в презентации, Aspose.Slides для Android через Java предоставляет метод [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), который позволяет вам указать название секции, которую вы собираетесь создать, и слайд, с которого начинается секция.

Этот пример кода показывает, как создать секцию в презентации на Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Секция 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Секция 2", newSlide3); // section1 закончится на newSlide2, после чего начнется section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Последняя пустая секция");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Изменение названий секций

После того как вы создадите секцию в презентации PowerPoint, вы можете решить изменить ее название.

Этот пример кода показывает, как изменить название секции в презентации на Java с использованием Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("Моя секция");
} finally {
    if (pres != null) pres.dispose();
}
```