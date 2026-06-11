---
title: Zarządzaj sekcjami slajdów w prezentacjach przy użyciu PHP
linktitle: Sekcja slajdu
type: docs
weight: 90
url: /pl/php-java/slide-section/
keywords:
- tworzenie sekcji
- dodawanie sekcji
- edycja sekcji
- zmiana sekcji
- nazwa sekcji
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Usprawnij sekcje slajdów w PowerPoint i OpenDocument za pomocą Aspose.Slides for PHP via Java — podziel, zmień nazwę i zmień kolejność, aby zoptymalizować przepływy pracy PPTX i ODP."
---
## **Wprowadzenie**

Za pomocą Aspose.Slides for PHP via Java możesz organizować prezentację PowerPoint w sekcje. Możesz tworzyć sekcje, które zawierają określone slajdy.

Możesz chcieć tworzyć sekcje i używać ich do organizowania lub dzielenia slajdów w prezentacji na logiczne części w następujących sytuacjach:

- Kiedy pracujesz nad dużą prezentacją z innymi osobami lub zespołem — i musisz przydzielić określone slajdy koledze lub członkom zespołu. 
- Kiedy masz do czynienia z prezentacją zawierającą wiele slajdów — i masz trudności z zarządzaniem lub jednoczesną edycją jej zawartości.

Idealnie, powinieneś utworzyć sekcję, która zawiera podobne slajdy — slajdy mają coś wspólnego lub mogą istnieć w grupie na podstawie reguły — i nadać sekcji nazwę opisującą slajdy w niej zawarte. 

## **Tworzenie sekcji w prezentacjach**

Aby dodać sekcję, która będzie zawierała slajdy w prezentacji, Aspose.Slides for PHP via Java udostępnia metodę [addSection()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sectioncollection/#addSection), która pozwala określić nazwę sekcji, którą chcesz utworzyć, oraz slajd, od którego sekcja się zaczyna.

Poniższy kod przykładowy pokazuje, jak utworzyć sekcję w prezentacji :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 zostanie zakończona w newSlide2, a po niej section2 rozpocznie się

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmiana nazw sekcji**

Po utworzeniu sekcji w prezentacji PowerPoint możesz zdecydować się na zmianę jej nazwy. 

Poniższy kod przykładowy pokazuje, jak zmienić nazwę sekcji w prezentacji przy użyciu Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być "ukryta"?**

Nie. Tylko pojedyncze slajdy mogą być ukryte. Sekcja jako jednostka nie ma stanu „ukryta”.

**Czy mogę szybko znaleźć sekcję po slajdzie i, odwrotnie, pierwszy slajd sekcji?**

Tak. Sekcja jest jednoznacznie określona przez swój slajd początkowy; mając slajd, możesz określić, do której sekcji należy, a dla sekcji możesz uzyskać dostęp do jej pierwszego slajdu.