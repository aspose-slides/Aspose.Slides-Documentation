---
title: Управление разделами слайдов в презентациях с помощью JavaScript
linktitle: Раздел слайдов
type: docs
weight: 90
url: /ru/nodejs-java/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- получить слайды раздела
- обрабатывать слайды раздела
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides для Node.js via Java: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы организуют последовательные слайды в именованные группы, не изменяя содержимое слайдов. С Aspose.Slides for Node.js via Java вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы с помощью метода [Presentation.getSections](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSections).

Разделы особенно полезны, когда:
- большая презентация должна быть разделена на логические темы или главы;
- разные группы слайдов назначаются разным сотрудникам;
- слайды необходимо обрабатывать, перемещать или объединять группами.

Выбирайте короткие имена разделов, которые описывают назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения принадлежности, а не выводите её из позиций слайдов.

## **Создание и управление разделами**

Используйте [SectionCollection.addSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/#addSection) для создания раздела, указав его имя и начальный слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

То же самое [SectionCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/) также позволяет вам:
- переместить раздел вместе с его слайдами, используя [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- удалить только определение раздела с помощью [SectionCollection.removeSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/#removeSection), при этом сохраняются его слайды;
- удалить раздел и его слайды с помощью [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- добавить пустой раздел в конец с помощью [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Следующий пример создает два раздела, перемещает один из них, удаляет его вместе со слайдами и добавляет пустой раздел:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

После этих операций в презентации будет раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, вызовите его метод [Section.setName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#setName). Слайды раздела и его позиция остаются без изменений.

Следующий пример создает раздел и меняет его имя:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Получение слайдов из разделов**

Метод [Presentation.getSections](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSections) возвращает объект [SectionCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectioncollection/), к которому можно обращаться по индексу. Для каждого [Section](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/) вызовите [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getSlidesListOfSection), чтобы получить слайды, которые в данный момент принадлежат этому разделу. Метод возвращает объект [SectionSlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectionslidecollection/), который предоставляет количество и доступ по индексу.

Следующий пример создает два заполненных раздела и один пустой раздел, затем выводит для каждого раздела его [name](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getStartedFromSlide), количество слайдов и номера слайдов. Он использует [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) для чтения как первого слайда, так и каждого слайда в коллекции. Для пустого раздела возвращённая коллекция имеет размер 0, доступ по индексу пропускается, и цикл не выполняет операций.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Принадлежность к разделу определяется структурой разделов презентации. Не рассчитывайте диапазон раздела вручную, используя [Section.getStartedFromSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getStartedFromSlide), индексы слайдов и начальный слайд следующего раздела.

Структурные правки могут изменить как набор слайдов, возвращаемый для раздела, так и их номера. Это включает переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. В следующем примере после каждой такой правки вызывается [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getSlidesListOfSection) вместо того, чтобы сохранять предположения о прежних границах раздела.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Вызывайте [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getSlidesListOfSection) снова каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это сохраняет соответствие последующей обработки текущей структуре презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; при конвертации в PPT структура разделов удаляется, что делает невозможным последующее их перечисление.

## **Вопросы и ответы**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, вызовите [Slide.setHidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#setHidden) для каждого слайда в разделе.

**Как найти раздел, содержащий данный слайд?**

Получите каждый раздел из коллекции, возвращаемой [Presentation.getSections](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSections), вызовите [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getSlidesListOfSection) для каждого раздела и сравните полученные слайды с целевым слайдом. Для непустого раздела [Section.getStartedFromSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/section/#getStartedFromSlide) возвращает его первый слайд; для пустого раздела он возвращает `null`.