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
description: "Vytvářejte prezentace pomocí Aspose.Slides — vytvořte soubory PPT, PPTX a ODP, využijte podporu OpenDocument a uložte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat textové pole na její první snímek a výsledek uložit jako soubor.

Před začátkem nainstalujte balíček `aspose.slides.via.java` z npm spolu s JDK, Pythonem a nástroji pro sestavení C++, které jsou potřeba. Viz [Instalace](/slides/cs/nodejs-java/installation/).

## **Vytvořit prezentaci PowerPoint**

Chcete-li vytvořit prezentaci a umístit textové pole na její první snímek, postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.
2. Získejte tento snímek ze [kolekce snímků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) podle jeho indexu 0.
3. Přidejte obdélník pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/addautoshape/) a nastavte jeho text pomocí [setText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/settext/).
4. Uložte prezentaci jako soubor PPTX pomocí metody [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/save/).
5. Uvolněte prezentaci pomocí metody [dispose](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/dispose/), a ukončete proces.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides běží v Java virtuálním stroji, který udržuje Node.js v běhu, takže proces ukončete explicitně.
process.exit(0);
```

Levé horní rohy obdélníku jsou 50 bodů od levého okraje a 50 bodů od horního okraje snímku a obdélník má šířku 400 bodů a výšku 100 bodů. Uložte kód jako *hello.js* ve vaší složce projektu a spusťte `node hello.js`: uloží *hello.pptx* s jedním snímkem obsahujícím tento obdélník a jeho text, v aktuální složce.

Aspose.Slides běží v Java virtuálním stroji, který balíček `java` spouští uvnitř procesu Node.js. Tento virtuální stroj zabraňuje Node.js automaticky ukončit se po dokončení skriptu, takže příklad končí `process.exit(0)`.

Bez licence Aspose.Slides také přidává evaluační vodoznak na každý uložený snímek; viz [Licencování](/slides/cs/nodejs-java/licensing/).

## **Často kladené otázky**

### Do jakých formátů mohu uložit novou prezentaci?

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/nodejs-java/save-presentation/), a exportovat do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/), a [obrázků](/slides/cs/nodejs-java/convert-powerpoint-to-png/), mezi jinými.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/nodejs-java/supported-file-formats/).

### Jak mohu řídit velikost snímku/poměr stran při vytváření prezentace?

Nastavte [slide size](/slides/cs/nodejs-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak by měl být obsah škálován.

### V jakých jednotkách jsou měřeny velikosti a souřadnice?

V bodech: 1 palec se rovná 72 jednotkám.

### Jak mohu zvládnout velmi velké prezentace (s mnoha mediálními soubory) a snížit spotřebu paměti?

Použijte [BLOB management strategies](/slides/cs/nodejs-java/manage-blob/), omezte úložiště v paměti využíváním dočasných souborů a upřednostněte souborově založené pracovní postupy před čistě paměťovými proudy.

### Mohu vytvářet/ukládat prezentace paralelně?

Nelze operovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) z [více vláken](/slides/cs/nodejs-java/multithreading/). Spusťte oddělené, izolované instance pro každý vlákno nebo proces.

### Jak mohu odstranit zkušební vodoznak a omezení?

[Použít licenci](/slides/cs/nodejs-java/licensing/) jednou na proces. XML licence musí zůstat nezměněný a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

### Mohu digitálně podepsat vytvořený PPTX?

Ano. [Digitální podpisy](/slides/cs/nodejs-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou podporovány pro prezentace.

### Jsou makra (VBA) podporována v vytvořených prezentacích?

Ano. Můžete [vytvářet/úpravy VBA projektů](/slides/cs/nodejs-java/presentation-via-vba/) a uložit soubory s povolenými makry jako PPTM/PPSM.