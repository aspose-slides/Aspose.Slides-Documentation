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

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah do snímku a uložit výsledek jako soubor. Také demonstruje, jak vytvořit a uložit novou prezentaci, otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu. Kromě toho článek obsahuje krátkou sekci FAQ, která pokrývá časté otázky související s formáty, šablonami, velikostí snímků, jednotkami, využitím paměti, vlákny, licencováním, digitálními podpisy a podporou VBA.

## **Vytvoření prezentace**

1. Vytvořte instanci třídy Presentation.  
1. Získejte odkaz na snímek pomocí jeho indexu.  
1. Přidejte AutoShape typu Line pomocí metody addAutoShape, kterou poskytuje objekt Shapes.  
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation();
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Přidat autoshape typu čára
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/php-java/save-presentation/), a exportovat do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/php-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), [SVG](/slides/cs/php-java/convert-powerpoint-to-png/) a [obrázků](/slides/cs/php-java/convert-powerpoint-to-png/), mezi dalšími.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/php-java/supported-file-formats/).

**Jak mohu řídit velikost/snímek a poměr stran při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/php-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak má být obsah škálován.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec se rovná 72 jednotkám.

**Jak mohu zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?**

Použijte [strategii správy BLOB](/slides/cs/php-java/manage-blob/), omezte ukládání v paměti využitím dočasných souborů a upřednostněte pracovní postupy založené na souborech před čistě paměťovými proudy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) z [více vláken](/slides/cs/php-java/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak mohu odstranit vodotisk z trial verze a omezení?**

[Aplikujte licenci](/slides/cs/php-java/licensing/) jednou na proces. XML licence musí zůstat nepozměněno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

**Mohu digitálně podepsat PPTX, který vytvořím?**

Ano. [Digitální podpisy](/slides/cs/php-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou makra (VBA) podporována v vytvořených prezentacích?**

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/php-java/presentation-via-vba/) a ukládat soubory s makry, jako jsou PPTM/PPSM.