---
title: Zarządzanie sekcjami slajdów w prezentacjach w .NET
linktitle: Sekcja slajdu
type: docs
weight: 100
url: /pl/net/slide-section/
keywords:
- utwórz sekcję
- dodaj sekcję
- edytuj sekcję
- zmień sekcję
- nazwa sekcji
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Usprawnij sekcje slajdów w PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET — podziel, zmień nazwę i przestaw, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wprowadzenie**

Za pomocą Aspose.Slides for .NET możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje, które zawierają określone slajdy. 

Możesz chcieć tworzyć sekcje i wykorzystywać je do organizowania lub dzielenia slajdów w prezentacji na części logiczne w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją z innymi osobami lub zespołem — i musisz przydzielić niektóre slajdy koledze lub członkom zespołu. 
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz trudności z zarządzaniem lub edytowaniem jej zawartości jednocześnie.

Idealnie, powinieneś utworzyć sekcję, która grupuje podobne slajdy — slajdy mają coś wspólnego lub mogą istnieć w grupie na podstawie reguły — i nadać sekcji nazwę opisującą znajdujące się w niej slajdy. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, która będzie zawierała slajdy w prezentacji, Aspose.Slides for .NET udostępnia metodę AddSection, która pozwala określić nazwę sekcji, którą chcesz utworzyć oraz slajd, od którego sekcja się zaczyna. 

Ten przykładowy kod pokazuje, jak utworzyć sekcję w prezentacji w języku C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // sekcja1 zakończy się na newSlide2, a po niej rozpocznie się sekcja2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Zmiana nazw sekcji**

Po utworzeniu sekcji w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy. 

Ten przykładowy kod pokazuje, jak zmienić nazwę sekcji w prezentacji w języku C# przy użyciu Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisie do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Ukrywać można tylko pojedyncze slajdy. Sekcja jako jednostka nie posiada stanu „ukrytego”.

**Czy mogę szybko znaleźć sekcję na podstawie slajdu oraz, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określona przez swój slajd początkowy; mając slajd, możesz określić, do której sekcji należy, a dla sekcji możesz uzyskać dostęp do jej pierwszego slajdu.