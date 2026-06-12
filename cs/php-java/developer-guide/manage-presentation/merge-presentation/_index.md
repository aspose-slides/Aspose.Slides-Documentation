---
title: Efektivně sloučit prezentace v PHP
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/php-java/merge-presentation/
keywords:
- sloučit PowerPoint
- sloučit prezentace
- sloučit snímky
- sloučit PPT
- sloučit PPTX
- sloučit ODP
- kombinovat PowerPoint
- kombinovat prezentace
- kombinovat snímky
- kombinovat PPT
- kombinovat PPTX
- kombinovat ODP
- PHP
- Aspose.Slides
description: "Jednoduše sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) pomocí Aspose.Slides pro PHP via Java, což zjednoduší váš pracovní postup."
---
## **Přehled**

Aspose.Slides umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní snímek nebo konkrétní rozvržení během sloučení, pracovat s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. Také se zabývá praktickými poznámkami souvisejícími se sloučeným obsahem, včetně poznámek k řečníkovi, komentářů, souborů chráněných heslem a používání vláken.

## **Sloučení prezentací**

Když sloučíte jednu prezentaci s druhou, v podstatě kombinujete jejich snímky do jedné prezentace a získáte jeden soubor. 

{{% alert title="Info" color="info" %}}

Většina programů pro prezentace (PowerPoint nebo OpenOffice) postrádá funkce, které uživatelům umožňují kombinovat prezentace tímto způsobem. 

[**Aspose.Slides pro PHP via Java**](https://products.aspose.com/slides/cs/php-java/), však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat.

**Viz také**

[**Klonovat snímky**](/slides/cs/php-java/clone-slides/).

{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci
* specifické snímky. Vybrané snímky skončí v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX atd.) a v různých formátech (PPT na PPTX, PPTX na ODP atd.) mezi sebou. 

{{% alert title="Note" color="warning" %}} 

Kromě prezentací umožňuje Aspose.Slides sloučit i jiné soubory:

* [Obrázky](https://products.aspose.com/slides/cs/php-java/merger/image-to-image/), například [JPG na JPG](https://products.aspose.com/slides/cs/php-java/merger/jpg-to-jpg/) nebo [PNG na PNG](https://products.aspose.com/slides/cs/php-java/merger/png-to-png/)
* Dokumenty, například [PDF na PDF](https://products.aspose.com/slides/cs/php-java/merger/pdf-to-pdf/) nebo [HTML na HTML](https://products.aspose.com/slides/cs/php-java/merger/html-to-html/)
* A dva různé soubory, například [obrázek na PDF](https://products.aspose.com/slides/cs/php-java/merger/image-to-pdf/) nebo [JPG na PDF](https://products.aspose.com/slides/cs/php-java/merger/jpg-to-pdf/) nebo [TIFF na PDF](https://products.aspose.com/slides/cs/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci zachová jedinečný styl
* konkrétní styl je použit pro všechny snímky ve výstupní prezentaci. 

Pro sloučení prezentací poskytuje Aspose.Slides metody [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) (z třídy [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/)). Existuje několik implementací metod `addClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getslides/), takže můžete zavolat metodu `addClone` z prezentace, do které chcete sloučit snímky.

Metoda `addClone` vrací objekt `Slide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (například aplikovat styly, formátování nebo rozvržení) aniž byste se museli obávat, že by to ovlivnilo zdrojové prezentace.

## **Sloučení prezentací** 

Aspose.Slides poskytuje metodu [addClone(Slide)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), která umožňuje kombinovat snímky, přičemž snímky zachovávají své rozvržení a styly (výchozí parametry).

Tento PHP kód ukazuje, jak sloučit prezentace:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Sloučení prezentací s hlavním snímkem** 

Aspose.Slides poskytuje metodu [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) , která umožňuje kombinovat snímky při použití šablony hlavního snímku prezentace. Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci.

Tento kód demonstruje popsanou operaci:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Rozvržení snímku pro hlavní snímek je určeno automaticky. Když nelze určit vhodné rozvržení, pokud je boolean parametr `allowCloneMissingLayout` metody `addClone` nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení snímku, použijte při sloučení místo toho metodu [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) .

## **Sloučení konkrétních snímků z prezentací** 

Sloučení konkrétních snímků z více prezentací je užitečné pro tvorbu vlastních sad snímků. Aspose.Slides pro PHP via Java vám umožňuje vybrat a importovat pouze snímky, které potřebujete. API zachovává formátování, rozvržení a design originálních snímků.

Následující PHP kód vytvoří novou prezentaci, přidá titulní snímky ze dvou ostatních prezentací a uloží výsledek do souboru:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Sloučení prezentací s rozvržením snímku** 

Tento PHP kód ukazuje, jak kombinovat snímky z prezentací při aplikaci požadovaného rozvržení snímku, aby vznikla jedna výstupní prezentace:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Sloučení prezentací s různými velikostmi snímků** 

{{% alert title="Note" color="warning" %}} 

Nemůžete sloučit prezentace s různými velikostmi snímků. 

{{% /alert %}}

Pro sloučení 2 prezentací s různými velikostmi snímků musíte upravit velikost jedné z prezentací, aby odpovídala velikosti druhé.

Tento ukázkový kód demonstruje popsanou operaci:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Sloučení snímků do sekce prezentace** 

Tento PHP kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Snímek je přidán na konec sekce. 

## **Viz také**


Aspose poskytuje [ZDARMA Online Collage Maker](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit obrázky [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a další.

Vyzkoušejte [Aspose FREE Online Merger](https://products.aspose.app/slides/cs/merger). Umožňuje sloučit PowerPoint prezentace ve stejném formátu (např. PPT na PPT, PPTX na PPTX) nebo napříč různými formáty (např. PPT na PPTX, PPTX na ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/cs/merger)

## **Často kladené otázky**

**Existují nějaká omezení počtu snímků při sloučení prezentací?**

Žádná striktní omezení. Aspose.Slides zvládne velké soubory, ale výkon závisí na velikosti a systémových zdrojích. Pro velmi velké prezentace se doporučuje používat 64‑bitový JVM a přidělit dostatečnou haldu paměti.

**Mohu sloučit prezentace s vloženým videem nebo zvukem?**

Ano, Aspose.Slides zachovává multimediální obsah vložený do snímků, ale výsledná prezentace může být výrazně větší.

**Budou písma při sloučení prezentací zachována?**

Ano. Písma použité ve zdrojových prezentacích jsou zachována ve výstupním souboru, pokud jsou nainstalována v systému nebo [vložená](/slides/cs/php-java/embedded-font/).