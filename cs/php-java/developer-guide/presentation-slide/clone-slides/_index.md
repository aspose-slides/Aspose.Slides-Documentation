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
description: "Rychle duplikujte snímky PowerPointu pomocí Aspose.Slides pro PHP. Postupujte podle našich přehledných ukázek kódu a automatizujte tvorbu PPT během několika sekund a eliminujte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides for PHP via Java také umožňuje vytvořit kopii nebo klon libovolného snímku a následně tento klonovaný snímek vložit do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který mohou vývojáři upravovat, aniž by měnili původní snímek. Existuje několik možností, jak snímek klonovat:

- Klon na konci v rámci prezentace.
- Klon na jiné pozici v rámci prezentace.
- Klon na konci v jiné prezentaci.
- Klon na jiné pozici v jiné prezentaci.
- Klon na konkrétní pozici v jiné prezentaci.

V Aspose.Slides for PHP via Java (kolekce objektů [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Slide)) poskytované objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) nabízí metody [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) a [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) pro provedení výše uvedených typů klonování snímků.

## **Klonovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejné souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) odkazováním na kolekci snímků poskytovanou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) poskytovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek, který má být klonován, jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Uložte upravený soubor prezentace.

V příkladu níže jsme klonovali snímek (nacházející se na první pozici – index nula – prezentace) na konec prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Uložte upravenou prezentaci na disk
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klonovat snímek na jiné pozici v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejné souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection) odkazováním na kolekci **Slides** poskytovanou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) poskytovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek, který má být klonován, spolu s indexem pro novou pozici jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone).
1. Uložte upravenou prezentaci jako soubor PPTX.

V příkladu níže jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – prezentace) na index 1 – Pozice 2 – prezentace.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    $slds = $pres->getSlides();
    # Klonujte požadovaný snímek na zadaný index ve stejné prezentaci
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Uložte upravenou prezentaci na disk
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klonovat snímek na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection) odkazováním na kolekci **Slides** poskytovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) poskytovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Uložte upravený soubor cílové prezentace.

V příkladu níže jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

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
      # Uložte cílovou prezentaci na disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klonovat snímek na jiné pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Získejte třídu [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) odkazováním na kolekci Slides poskytovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone) poskytovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#insertClone).
1. Uložte upravený soubor cílové prezentace.

V příkladu níže jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

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
      # Uložte cílovou prezentaci na disk
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klonovat snímek na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, nejprve klonujte požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijte tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte přístup ke snímku, který má být klonován, spolu s hlavním snímkem.
1. Vytvořte instanci [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/MasterSlideCollection) odkazováním na kolekci Masters poskytovanou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) poskytovanou objektem [MasterSlideCollection] a předávejte hlavní snímek ze zdrojového PPTX jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Vytvořte instanci [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) nastavením odkazu na kolekci Slides poskytovanou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) poskytovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSlides) a předávejte snímek ze zdrojové prezentace k klonování a hlavní snímek jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone).
1. Uložte upravený soubor cílové prezentace.

V příkladu níže jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

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
      # Klonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
      # cílové prezentaci
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
      # cílové prezentaci
      $iSlide = $masters->addClone($SourceMaster);
      # Klonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
      # kolekce snímků v cílové prezentaci
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

## **Klonovat snímek na konci určené sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejné souboru prezentace, ale v jiné sekci, použijte metodu [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection/#addClone) poskytovanou třídou [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java umožňuje klonovat snímek z první sekce a následně vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit jej do určené sekce.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Uložte cílovou prezentaci na disk
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Zajistit odpovídající velikost snímku**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti liší, Aspose.Slides automaticky nepřepočítá měřítko klonovaných objektů – jejich původní souřadnice a rozměry zůstávají zachovány, což může vést k posunutí obsahu nebo jeho přesahu mimo okraje snímku.

Před klonováním hlavního snímku a snímku můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Klone se poznámky řečníka a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/php-java/presentation-notes/) po vložení.

**Jak jsou zacházeno s grafy a jejich zdroji dat?**

Objekt grafu, jeho formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE objekt](/slides/cs/php-java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/php-java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté snímek do ní přesuňte.