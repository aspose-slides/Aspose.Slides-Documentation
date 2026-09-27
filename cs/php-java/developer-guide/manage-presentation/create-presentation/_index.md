---
title: Vytváření prezentací v PHP
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/php-java/create-presentation/
keywords:
- vytvořit prezentaci
- nová prezentace
- vytvořit PPT
- nový PPT
- vytvořit PPTX
- nový PPTX
- vytvořit ODP
- nový ODP
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte prezentace pomocí Aspose.Slides pro PHP přes Java — vytvářejte soubory PPT, PPTX a ODP a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat textové pole na její první snímek a uložit výsledek jako soubor. Také ukazuje, jak vytvořit a uložit prázdnou prezentaci a jak otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu. Krátké FAQ na konci pokrývá běžné otázky o formátech, šablonách, velikosti snímků, jednotkách, využití paměti, vláknování, licencování, digitálních podpisech a podpoře VBA.

Než začnete, nainstalujte Aspose.Slides pro PHP přes Java s Composerem a spusťte PHP/Java Bridge v Apache Tomcat. Kompletní nastavení najdete v [Installation](/slides/cs/php-java/installation/). Příklady níže předpokládají, že Tomcat běží na `localhost:8080` a složka `vendor` Composeru je umístěna vedle skriptu.

## **Vytvoření PowerPoint prezentace**

Pro vytvoření prezentace a přidání textového pole na její první snímek postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.
2. Získejte tento snímek z kolekce vrácené metodou [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), podle jeho indexu 0.
3. Přidejte obdélník pomocí metody [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) a nastavte jeho text pomocí [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).
4. Uložte prezentaci jako soubor PPTX pomocí metody [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tyto dvě řádky `require_once` načítají klienta PHP/Java Bridge z Tomcatu a třídy Aspose.Slides z balíčku Composer. Levý horní roh obdélníku je 50 bodů od levého okraje a 50 bodů od horního okraje snímku, šířka obdélníku je 400 bodů a výška 100 bodů. Uložený soubor obsahuje jeden snímek s tímto obdélníkem a jeho textem. Bez licence Aspose.Slides také přidává vodotisk hodnocení ke každému uloženému snímku; viz [Licensing](/slides/cs/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides čte a zapisuje soubory uvnitř Tomcatu, ne ve vašem PHP procesu, takže relativní cesta jako `"hello.pptx"` je vyhodnocena vůči pracovní složce Tomcatu. Příklady na této stránce vytvářejí absolutní cesty pomocí `__DIR__`, takže soubory jsou načítány a ukládány vedle skriptu.
{{% /alert %}}

## **Vytvoření a uložení prezentace**

Pro vytvoření prázdné prezentace a její uložení vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a uložte ji v libovolném formátu z výčtu [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/). Výsledkem je prezentace s jedním prázdným snímkem.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Otevření a uložení prezentace**

Chcete-li převést prezentaci z jednoho formátu na druhý, otevřete ji předáním její cesty do konstruktoru [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), poté ji uložte v cílovém formátu. Aspose.Slides detekuje vstupní formát, například PPT, PPTX nebo ODP, podle samotného souboru.

Příklad níže očekává, že OpenDocument prezentace pojmenovaná *Sample.odp* bude vedle skriptu a uloží ji jako PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/cs/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### Do jakých formátů mohu uložit novou prezentaci?

Můžete uložit jako [PPTX, PPT a ODP](/slides/cs/php-java/save-presentation/), a exportovat do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/php-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), [SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/) a [obrázků](/slides/cs/php-java/convert-powerpoint-to-png/), mezi jinými.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/php-java/supported-file-formats/).

### Jak mohu řídit velikost snímku/poměr stran při vytváření prezentace?

Nastavte [velikost snímku](/slides/cs/php-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak má být obsah škálován.

### V jakých jednotkách jsou měřeny velikosti a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) za účelem snížení využití paměti?

Použijte [strategie správy BLOB](/slides/cs/php-java/manage-blob/), omezte ukládání v paměti pomocí dočasných souborů a upřednostněte pracovní postupy založené na souborech před čistě paměťovými proudy.

### Mohu vytvářet/ukládat prezentace paralelně?

Nelze pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) z [více vláken](/slides/cs/php-java/multithreading/). Používejte samostatné, izolované instance pro každé vlákno nebo proces.

### Jak odstranit zkušební vodotisk a omezení?

[Aplikujte licenci](/slides/cs/php-java/licensing/) jednou na proces. Soubor XML licence musí zůstat beze změny a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

### Mohu digitálně podepsat vytvořený PPTX?

Ano. [Digitální podpisy](/slides/cs/php-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

### Jsou v vytvořených prezentacích podporovány makra (VBA)?

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/php-java/presentation-via-vba/) a ukládat soubory s makry jako PPTM/PPSM.