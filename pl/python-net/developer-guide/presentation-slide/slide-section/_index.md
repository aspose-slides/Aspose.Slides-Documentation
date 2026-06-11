---
title: "Zarządzanie sekcjami slajdów w prezentacjach przy użyciu Pythona"
linktitle: "Sekcja slajdu"
type: docs
weight: 100
url: /pl/python-net/slide-section/
keywords:
- "tworzenie sekcji"
- "dodawanie sekcji"
- "edycja sekcji"
- "zmiana sekcji"
- "nazwa sekcji"
- "PowerPoint"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Usprawnij sekcje slajdów w PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona — podziel, zmień nazwę i przestaw, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wprowadzenie**

Za pomocą Aspose.Slides dla języka Python możesz organizować prezentację PowerPoint w sekcje, które grupują określone slajdy.

Możesz chcieć tworzyć sekcje, aby organizować lub dzielić prezentację na logiczne części w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją w zespole i musisz przydzielić określone slajdy konkretnym współpracownikom.
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów i trudno jest zarządzać lub edytować wszystko naraz.

Idealnie jest tworzyć sekcje, które grupują powiązane slajdy — te, które mają wspólny motyw, temat lub cel — i nadawać każdej sekcji nazwę jasno odzwierciedlającą jej zawartość. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać [Section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/), który grupuje slajdy w prezentacji, Aspose.Slides udostępnia metodę [add_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/add_section/). Pozwala ona określić nazwę sekcji i slajd, od którego sekcja się zaczyna.

Poniższy przykład w języku Python pokazuje, jak utworzyć sekcję w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Sekcja 1 kończy się na slajdzie 2; Sekcja 2 zaczyna się od slajdu 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Zmiana nazw sekcji**

Po utworzeniu [Section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/) w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy.

Poniższy przykład w języku Python pokazuje, jak zmienić nazwę sekcji w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Czy sekcje są zachowywane podczas zapisywania w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być "ukryta"?**

Nie. Ukryte mogą być tylko poszczególne slajdy. Sekcja jako jednostka nie ma stanu „ukryta”.

**Czy mogę szybko znaleźć sekcję po slajdzie oraz, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określona przez swój początkowy slajd; mając slajd, możesz określić, do której sekcji należy, a dla sekcji możesz uzyskać dostęp do jej pierwszego slajdu.