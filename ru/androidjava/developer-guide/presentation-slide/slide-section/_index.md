---
title: Управление разделами слайдов в презентациях на Android
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/androidjava/slide-section/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides для Android через Java: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы упорядочивают последовательные слайды в именованные группы без изменения содержимого слайдов. С помощью Aspose.Slides for Android via Java вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через метод [Presentation.getSections](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSections--) .

Разделы особенно полезны, когда:

- большая презентация должна быть разбита на логические темы или главы;
- разные группы слайдов назначаются разным сотрудникам;
- слайды необходимо обрабатывать, перемещать или объединять группами.

Выбирайте лаконичные имена разделов, которые описывают назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения их состава, а не выводите его из позиций слайдов.

## **Создание и управление разделами**

Используйте [ISectionCollection.addSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) для создания раздела, указывая его имя и начальный слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

Тот же [ISectionCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/) позволяет вам:

- переместить раздел вместе с его слайдами, используя [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- удалить только определение раздела с помощью [ISectionCollection.removeSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), при этом слайды сохраняются;
- удалить раздел и его слайды с помощью [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- добавить пустой раздел в конец с помощью [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) .

Следующий пример создаёт два раздела, перемещает один из них, удаляет его вместе с слайдами и добавляет пустой раздел:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

После этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, вызовите его метод [ISection.setName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) . Слайды и позиция раздела остаются без изменений.

Следующий пример создаёт раздел и меняет его имя:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Получение слайдов из разделов**

Метод [Presentation.getSections](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSections--) возвращает [ISectionCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectioncollection/), по которой можно выполнять итерацию. Для каждого [ISection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/) вызовите [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) , чтобы получить слайды, которые в данный момент принадлежат ему. Метод возвращает [ISectionSlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectionslidecollection/), предоставляющую количество, индексированный доступ и возможность итерации.

Следующий пример создаёт два заполненных раздела и один пустой раздел, затем выводит для каждого раздела его [name](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), количество слайдов и номера слайдов. Он использует [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) для чтения первого слайда и расширенный оператор `for` для обработки каждого слайда. Для пустого раздела возвращаемая коллекция имеет размер ноль, метод не вызывается, и итерация не выполняет никаких операций.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Членство в разделе определяется структурой разделов презентации. Не вычисляйте диапазон раздела вручную на основе [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), индексов слайдов и начального слайда следующего раздела.

Структурные изменения могут изменить как список слайдов, возвращаемый для раздела, так и их номера. Это включает переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. Следующий пример вызывает [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) после каждого такого изменения вместо сохранения предположений о прежних границах раздела.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Вызывайте [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это сохраняет согласованность последующей обработки с текущей структурой презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующей итерации.

## **FAQ**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, вызовите [ISlide.setHidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#setHidden-boolean-) для каждого слайда в разделе.

**Как найти раздел, содержащий определённый слайд?**

Итеративно пройдите по коллекции, возвращаемой [Presentation.getSections](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSections--), вызовите [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) для каждого раздела и сравните полученные слайды с целевым слайдом. Для непустого раздела [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) возвращает его первый слайд; для пустого раздела он возвращает `null`.