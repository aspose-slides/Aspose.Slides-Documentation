---
title: Klonování snímků prezentace v PHP
linktitle: Klonovat snímky
type: docs
weight: 35
url: /cs/php-java/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPoint pomocí Aspose.Slides pro PHP. Postupujte podle našich přehledných ukázek kódu a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides for PHP via Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak snímek klonovat:

- Klónovat na konci v rámci prezentace.
- Klónovat na jiném místě v rámci prezentace.
- Klónovat na konci v jiné prezentaci.
- Klónovat na jiném místě v jiné prezentaci.
- Klónovat na konkrétním místě v jiné prezentaci.

V Aspose.Slides for PHP via Java (kolekce objektů [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Slide)) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) a [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) pro provedení výše uvedených typů klonování snímků.

## **Klónovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejné souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) odkazem na kolekci snímků, kterou poskytuje objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek, který má být klonován, jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – prezentace) na konec prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Zapište upravenou prezentaci na disk
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klónovat snímek na jiné místo v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejné souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection) odkazem na kolekci **[Slides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides)** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek, který má být klonován, spolu s indexem nové pozice jako parametry metodě [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone).
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – prezentace) na index 1 – Pozice 2 – prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    $slds = $pres->getSlides();
    # Klonujte požadovaný snímek na určený index ve stejné prezentaci
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Zapište upravenou prezentaci na disk
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klónovat snímek na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection) odkazem na kolekci **[Slides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides)** vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

```php
  # Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    $destPres = new Presentation();
    try {
      # Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Zapište cílovou prezentaci na disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klónovat snímek na jiné místo v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Získejte třídu [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) odkazem na kolekci Slides vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametry metodě [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```php
  # Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    $destPres = new Presentation();
    try {
      # Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Zapište cílovou prezentaci na disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klónovat snímek na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijete tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Přistupte k snímku, který má být klonován, spolu s hlavním snímkem.
1. Iniciujte třídu [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterSlideCollection) odkazem na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) vystavenou objektem [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterSlideCollection) a předávejte hlavní snímek ze zdrojového PPTX jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Iniciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) nastavením reference na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace k klonování a hlavní snímek jako parametry metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```php
  # Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    $destPres = new Presentation();
    try {
      # Vytvořte ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
      # hlavním snímkem
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
      # cílové prezentaci
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
      # cílové prezentaci
      $iSlide = $masters->addClone($SourceMaster);
      # Klonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
      # sbírky snímků v cílové prezentaci
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Uložte cílovou prezentaci na disk
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klónovat snímek na konci určené sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) vystavenou třídou [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu vám ukáže, jak klonovat snímek a vložit klonovaný snímek do určené sekce.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Uložte cílovou prezentaci na disk
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Často kladené otázky**

**Klony zahrnují poznámky k přednášejícímu a komentáře recenzentů?**

Ano. Stránka s poznámkami a komentáře recenzentů jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/php-java/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení zůstane zachováno jako [OLE objekt](/slides/cs/php-java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/php-java/slide-section/). Pokud cílová sekce neexistuje, vytvořte ji nejprve a poté do ní snímek přesunujte.