---
title: Раздел слайдов
type: docs
weight: 90
url: /ru/nodejs-java/slide-section/
---

С помощью Aspose.Slides for Node.js via Java вы можете организовать презентацию PowerPoint в разделы. Вы можете создавать разделы, содержащие определённые слайды.

Вы можете захотеть создавать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией совместно с другими людьми или командой — и нужно назначить определённые слайды коллеге или нескольким участникам команды.  
- Когда вы имеете дело с презентацией, содержащей множество слайдов — и вам трудно управлять или редактировать её содержимое целиком.

Оптимально создавать раздел, в котором находятся схожие слайды — слайды имеют что‑то общее или могут быть сгруппированы по определённому правилу — и давать разделу название, описывающее содержащиеся в нём слайды.

## **Создание разделов в презентациях**

Чтобы добавить раздел, в котором будут находиться слайды презентации, Aspose.Slides for Node.js via Java предоставляет метод [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-), позволяющий указать имя создаваемого раздела и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации на JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 завершится на newSlide2, а после него начнётся section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменение названий разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его название.

Этот пример кода показывает, как изменить название раздела в презентации на JavaScript с использованием Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. Скрывать можно только отдельные слайды. У раздела как сущности нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим начальным слайдом; по данному слайду можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.