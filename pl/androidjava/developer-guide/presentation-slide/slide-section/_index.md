---
title: Zarządzanie sekcjami slajdów w prezentacjach na Androidzie
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/androidjava/slide-section/
keywords:
- utwórz sekcję
- dodaj sekcję
- edytuj sekcję
- zmień sekcję
- nazwa sekcji
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Usprawnij sekcje slajdów w PowerPoint i OpenDocument przy użyciu Aspose.Slides for Android via Java - podziel, zmień nazwę i zmień kolejność, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wprowadzenie**

Z Aspose.Slides for Android via Java możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje, które zawierają określone slajdy.

Możesz chcieć tworzyć sekcje i używać ich do organizowania lub podziału slajdów w prezentacji na części logiczne w następujących sytuacjach:

- Gdy pracujesz nad dużą prezentacją z innymi osobami lub zespołem — i musisz przydzielić niektóre slajdy koledze lub członkom zespołu.  
- Gdy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz problem z zarządzaniem lub edytowaniem jej zawartości jednocześnie.

Idealnie, powinieneś utworzyć sekcję, która skupia podobne slajdy — slajdy mają coś wspólnego lub mogą istnieć w grupie na podstawie reguły — i nadać sekcji nazwę opisującą znajdujące się w niej slajdy. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, w której będą znajdować się slajdy w prezentacji, Aspose.Slides for Android via Java udostępnia metodę [addSection()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) umożliwiającą określenie nazwy sekcji, którą chcesz utworzyć, oraz slajdu, od którego sekcja się rozpoczyna.

Poniższy przykładowy kod pokazuje, jak stworzyć sekcję w prezentacji w Javie:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 zostanie zakończona na newSlide2, a po niej rozpocznie się section2   

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

Poniższy przykładowy kod pokazuje, jak zmienić nazwę sekcji w prezentacji w Javie przy użyciu Aspose.Slides:

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

**Czy sekcje są zachowywane przy zapisie w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone przy zapisie do *.ppt*.

**Czy cała sekcja może być „ukryta”?**

Nie. Tylko pojedyncze slajdy mogą być ukryte. Sekcja jako jednostka nie posiada stanu „ukryta”.

**Czy mogę szybko znaleźć sekcję po slajdzie oraz, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określana przez swój slajd początkowy; znając slajd, możesz określić, do której sekcji należy, a znając sekcję, możesz uzyskać jej pierwszy slajd.