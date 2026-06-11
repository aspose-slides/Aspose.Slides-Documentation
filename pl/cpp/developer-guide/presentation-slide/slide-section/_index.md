---
title: Zarządzaj sekcjami slajdów w prezentacjach przy użyciu C++
linktitle: Sekcja slajdu
type: docs
weight: 100
url: /pl/cpp/slide-section/
keywords:
- tworzenie sekcji
- dodawanie sekcji
- edycja sekcji
- zmiana sekcji
- nazwa sekcji
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Usprawnij zarządzanie sekcjami slajdów w PowerPoint i OpenDocument za pomocą Aspose.Slides for C++ — podziel, zmień nazwę i przestaw, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wprowadzenie**

Za pomocą Aspose.Slides for C++ możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje, które zawierają określone slajdy. 

Możesz chcieć tworzyć sekcje i używać ich do organizowania lub podziału slajdów w prezentacji na logiczne części w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją z innymi osobami lub zespołem — i musisz przydzielić określone slajdy koledze lub niektórym członkom zespołu. 
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz trudności z zarządzaniem lub edytowaniem jej zawartości jednocześnie.

Idealnie, powinieneś utworzyć sekcję, w której znajdą się podobne slajdy — slajdy mają coś wspólnego lub mogą istnieć w grupie na podstawie reguły — i nadać sekcji nazwę opisującą znajdujące się w niej slajdy. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, w której będą przechowywane slajdy w prezentacji, Aspose.Slides for C++ udostępnia metodę AddSection, która pozwala określić nazwę sekcji, którą zamierzasz utworzyć, oraz slajd, od którego sekcja się zaczyna. 

Ten przykładowy kod pokazuje, jak utworzyć sekcję w prezentacji w C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 zostanie zakończona na newSlide2, a po niej rozpocznie się section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Zmiana nazw sekcji**

Po utworzeniu sekcji w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy. 

Ten przykładowy kod pokazuje, jak zmienić nazwę sekcji w prezentacji w C++ przy użyciu Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Czy sekcje są zachowywane przy zapisie w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Tylko pojedyncze slajdy mogą być ukryte. Sekcja jako jednostka nie posiada stanu „ukryty”.

**Czy mogę szybko znaleźć sekcję na podstawie slajdu i, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określona przez swój slajd początkowy; mając slajd, możesz określić, do której sekcji należy, a dla sekcji możesz uzyskać dostęp do jej pierwszego slajdu.