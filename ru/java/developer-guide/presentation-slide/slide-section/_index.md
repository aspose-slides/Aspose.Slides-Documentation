---
title: Управление разделами слайдов в презентациях с помощью Java
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/java/slide-section/
keywords:
- создание раздела
- добавление раздела
- редактирование раздела
- изменение раздела
- имя раздела
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Оптимизируйте работу с разделами слайдов в PowerPoint и OpenDocument с Aspose.Slides for Java — разделяйте, переименовывайте и переставляйте их для повышения эффективности процессов PPTX и ODP."
---

С помощью Aspose.Slides for Java вы можете организовывать презентацию PowerPoint в разделы. Вы можете создавать разделы, содержащие определённые слайды. 

Возможно, вы захотите создавать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией вместе с другими людьми или командой - и вам нужно назначить определённые слайды коллеге или некоторым членам команды. 
- Когда вы имеете дело с презентацией, содержащей множество слайдов - и вам сложно управлять или редактировать её содержимое одновременно.

Оптимально создавать раздел, в котором находятся схожие слайды - слайды имеют что-то общее или могут быть сгруппированы по правилу - и давать разделу название, описывающее содержащиеся в нём слайды. 

## **Создание разделов в презентациях**

Чтобы добавить раздел, содержащий слайды в презентации, Aspose.Slides for Java предоставляет метод [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) , который позволяет указать название создаваемого раздела и слайд, с которого начинается раздел. 

Этот пример кода показывает, как создать раздел в презентации на Java:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 будет завершён на newSlide2 и после него начнётся section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменение названий разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его название. 

Этот пример кода показывает, как изменить название раздела в презентации на Java с помощью Aspose.Slides:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. Можно скрывать только отдельные слайды. У раздела как объекта нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим начальным слайдом; зная слайд, можно определить, к какому разделу он относится, а для раздела можно получить его первый слайд.