---
title: Раздел слайдов
type: docs
weight: 90
url: /java/slide-section/
---

С помощью Aspose.Slides для Java вы можете организовать презентацию PowerPoint на разделы. Вы можете создать разделы, которые содержат определенные слайды.

Вам может понадобиться создать разделы и использовать их для организации или деления слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией с другими людьми или командой — и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы имеете дело с презентацией, содержащей много слайдов — и вам трудно управлять или редактировать ее содержимое сразу.

В идеале, вы должны создать раздел, который объединяет похожие слайды — слайды имеют что-то общее или могут существовать в группе на основе правила — и дать разделу имя, которое описывает слайды внутри него.

## Создание разделов в презентациях

Чтобы добавить раздел, который будет содержать слайды в презентации, Aspose.Slides для Java предоставляет метод [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), который позволяет вам указать имя раздела, который вы собираетесь создать, и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации на Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Раздел 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Раздел 2", newSlide3); // section1 будет завершен на newSlide2, после него начнется section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Последний пустой раздел");

    pres.save("pres-section-with-empty.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Изменение названий разделов

После того, как вы создали раздел в презентации PowerPoint, вы можете решить изменить его название.

Этот пример кода показывает, как изменить название раздела в презентации на Java с помощью Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("Мой раздел");
} finally {
    if (pres != null) pres.dispose();
}
```