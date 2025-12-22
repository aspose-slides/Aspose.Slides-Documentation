---
title: Управление разделами слайдов в презентациях на Android
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/androidjava/slide-section/
keywords:
- создание раздела
- добавление раздела
- редактирование раздела
- изменение раздела
- имя раздела
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Оптимизируйте разделы слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides for Android via Java — разделяйте, переименовывайте и переупорядочивайте для повышения эффективности рабочих процессов PPTX и ODP."
---

С помощью Aspose.Slides for Android via Java вы можете организовать презентацию PowerPoint в разделы. Вы можете создавать разделы, содержащие определённые слайды.

Возможные ситуации, в которых вам может потребоваться создать разделы и использовать их для организации или разделения слайдов в презентации на логические части:

- Когда вы работаете над большой презентацией вместе с другими людьми или командой — и вам нужно назначить определённые слайды коллеге или членам команды. 
- Когда вы имеете дело с презентацией, содержащей множество слайдов — и вам трудно управлять её содержимым или редактировать его сразу.

Оптимально создавать раздел, в котором находятся схожие слайды — у слайдов есть общие черты или они могут быть сгруппированы по определённому правилу — и присваивать разделу название, описывающее содержащиеся в нём слайды. 

## **Создание разделов в презентациях**

Чтобы добавить раздел, содержащий слайды в презентации, Aspose.Slides for Android via Java предоставляет метод [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), который позволяет указать имя создаваемого раздела и слайд, с которого начинается раздел.

В этом примере кода показано, как создать раздел в презентации на Java:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 будет завершен на newSlide2, а после него начнётся section2   

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


## **Изменение имен разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его имя. 

В этом примере кода показано, как изменить имя раздела в презентации на Java с использованием Aspose.Slides:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. Можно скрыть только отдельные слайды. У раздела как объекта нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется стартовым слайдом; зная слайд, можно определить, к какому разделу он относится, а для раздела можно получить его первый слайд.