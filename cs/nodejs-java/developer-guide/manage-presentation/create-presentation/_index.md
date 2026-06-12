---
title: Vytváření prezentací v JavaScriptu
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte prezentace s Aspose.Slides—vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah na snímek a uložit výsledek jako soubor.

## **Vytvoření prezentace PowerPoint**

Chcete-li do vybraného snímku prezentace přidat jednoduchou přímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy Presentation.
2. Získejte odkaz na snímek pomocí jeho Indexu.
3. Přidejte AutoShape typu Line pomocí metody addAutoShape, kterou poskytuje objekt Shapes.
4. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali přímku na první snímek prezentace.

```javascript
// Vytvořte objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation();
try {
    // Získat první snímek
    var slide = pres.getSlides().get_Item(0);
    // Přidat autoshape typu čára
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/nodejs-java/save-presentation/), a exportovat do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/cs/nodejs-java/convert-powerpoint-to-png/), a [obrázky](/slides/cs/nodejs-java/convert-powerpoint-to-png/), mezi jinými.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/nodejs-java/supported-file-formats/).

**Jak mohu řídit velikost snímku a poměr stran při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/nodejs-java/slide-size/) (včetně předvoleb, jako 4:3 a 16:9, nebo vlastních rozměrů) a zvolte, jak má být obsah škálován.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak zvládnout velmi velké prezentace (s mnoha mediálními soubory) a snížit využití paměti?**

Použijte [strategii správy BLOB](/slides/cs/nodejs-java/manage-blob/), omezte úložiště v paměti pomocí dočasných souborů a upřednostněte pracovní postupy založené na souborech před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete operovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) z [více vláken](/slides/cs/nodejs-java/multithreading/). Spusťte samostatné, izolované instance na každém vlákně nebo procesu.

**Jak odebrat zkušební vodoznak a omezení?**

[Aplicujte licenci](/slides/cs/nodejs-java/licensing/) jednou na proces. XML licence nesmí být upravováno a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

**Mohu digitálně podepsat vytvořený PPTX?**

Ano. [Digitální podpisy](/slides/cs/nodejs-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou v vytvořených prezentacích podporovány makra (VBA)?**

Ano. Můžete [vytvářet/editovat VBA projekty](/slides/cs/nodejs-java/presentation-via-vba/) a ukládat soubory s podporou maker, jako PPTM/PPSM.