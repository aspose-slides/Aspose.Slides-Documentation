---
title: Zarządzanie sekcjami slajdów w prezentacjach przy użyciu JavaScript
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/nodejs-java/slide-section/
keywords:
- utwórz sekcję
- dodaj sekcję
- edytuj sekcję
- zmień sekcję
- nazwa sekcji
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Usprawnij sekcje slajdów w PowerPoint i OpenDocument za pomocą Aspose.Slides dla Node.js — dziel, zmieniaj nazwy i przestawiaj, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wstęp**

Za pomocą Aspose.Slides for Node.js via Java możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje, które zawierają określone slajdy.

Możesz chcieć tworzyć sekcje i używać ich do organizowania lub podziału slajdów w prezentacji na logiczne części w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją z innymi osobami lub zespołem — i musisz przydzielić określone slajdy koledze lub niektórym członkom zespołu. 
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz problem z zarządzaniem lub edytowaniem jej zawartości jednocześnie.

Idealnie, powinieneś utworzyć sekcję, która grupuje podobne slajdy — slajdy mają coś wspólnego lub mogą tworzyć grupę na podstawie reguły — i nadać sekcji nazwę opisującą zawarte w niej slajdy. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, która będzie zawierała slajdy w prezentacji, Aspose.Slides for Node.js via Java udostępnia metodę [addSection()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) , która pozwala określić nazwę sekcji, którą chcesz utworzyć, oraz slajd, od którego sekcja się rozpoczyna.

Ten przykładowy kod pokazuje, jak utworzyć sekcję w prezentacji w języku JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 zakończy się na newSlide2, a po nim rozpocznie się section2
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

## **Zmiana nazw sekcji**

Po utworzeniu sekcji w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy. 

Ten przykładowy kod pokazuje, jak zmienić nazwę sekcji w prezentacji w języku JavaScript przy użyciu Aspose.Slides:

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

**Czy sekcje są zachowywane podczas zapisywania w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone podczas zapisywania do .ppt.

**Czy cała sekcja może być "ukryta"?**

Nie. Ukryte mogą być jedynie poszczególne slajdy. Sekcja jako jednostka nie posiada stanu „ukryte”.

**Czy mogę szybko znaleźć sekcję po slajdzie oraz, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określona przez swój slajd początkowy; mając slajd, możesz określić, do której sekcji należy, a dla sekcji możesz uzyskać dostęp do jej pierwszego slajdu.