---
title: "Zarządzanie sekcjami slajdów w prezentacjach przy użyciu Java"
linktitle: "Sekcja slajdu"
type: docs
weight: 90
url: /pl/java/slide-section/
keywords:
- "utwórz sekcję"
- "dodaj sekcję"
- "edytuj sekcję"
- "zmień sekcję"
- "nazwa sekcji"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Java"
- "Aspose.Slides"
description: "Usprawnij zarządzanie sekcjami slajdów w PowerPoint i OpenDocument za pomocą Aspose.Slides for Java — podziel, zmień nazwę i zmień kolejność, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wstęp**

Za pomocą Aspose.Slides for Java możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje zawierające określone slajdy. 

Możesz chcieć tworzyć sekcje i używać ich do organizowania lub podziału slajdów w prezentacji na logiczne części w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją razem z innymi osobami lub zespołem — i musisz przydzielić określone slajdy koledze lub kilku członkom zespołu. 
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz trudności z zarządzaniem lub edytowaniem jej zawartości jednocześnie.

Idealnie, powinieneś utworzyć sekcję, w której znajdą się podobne slajdy — slajdy mają coś wspólnego lub mogą istnieć w grupie na podstawie reguły — i nadać sekcji nazwę opisującą znajdujące się w niej slajdy. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, w której będą przechowywane slajdy w prezentacji, Aspose.Slides for Java udostępnia metodę [addSection()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), która pozwala określić nazwę sekcji, którą chcesz utworzyć, oraz slajd, od którego sekcja się rozpoczyna. 

Ten przykładowy kod pokazuje, jak utworzyć sekcję w prezentacji w języku Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 zostanie zakończona w newSlide2, a po niej rozpocznie się section2   

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

## **Zmiana nazw sekcji**

Po utworzeniu sekcji w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy. 

Ten przykładowy kod pokazuje, jak zmienić nazwę sekcji w prezentacji w języku Java przy użyciu Aspose.Slides:

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

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, dlatego grupowanie sekcji zostaje utracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Można ukrywać tylko pojedyncze slajdy. Sekcja jako jednostka nie ma stanu „ukryta”.

**Czy mogę szybko znaleźć sekcję po slajdzie oraz, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określana przez swój początkowy slajd; znając slajd, możesz ustalić, do której sekcji należy, a mając sekcję, możesz uzyskać dostęp do jej pierwszego slajdu.