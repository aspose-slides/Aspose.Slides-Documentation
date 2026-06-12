---
title: Vytváření prezentací na Androidu
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Vytvářejte prezentace v jazyce Java pomocí Aspose.Slides pro Android — vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah do snímku a výsledek uložit jako soubor. Také demonstruje, jak vytvořit a uložit novou prezentaci, otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu.

## **Vytvoření prezentace PowerPoint**
Chcete-li přidat jednoduchou rovnou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy Presentation.
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte AutoShape typu Line pomocí metody addAutoShape, která je součástí objektu Shapes.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```java
// Vytvořte instanci objektu Presentation, který představuje soubor prezentace
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidejte autoshape typu čára
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/androidjava/save-presentation/), a exportovat do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), [SVG](/slides/cs/androidjava/convert-powerpoint-to-png/) a [obrázků](/slides/cs/androidjava/convert-powerpoint-to-png/), mezi ostatními.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/androidjava/supported-file-formats/).

**Jak mohu ovládat velikost/snámkový poměr při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/androidjava/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastní rozměry) a zvolte, jak se má obsah měřítkovat.

**V jakých jednotkách se měří velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory), aby se snížila spotřeba paměti?**

Použijte [strategií správy BLOB](/slides/cs/androidjava/manage-blob/), omezte úložiště v paměti pomocí dočasných souborů a upřednostňujte workflow založené na souborech před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nelze operovat na stejné [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) instanci z [více vláken](/slides/cs/androidjava/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak odstranit vodotisk a omezení z trial verze?**

[Aplikujte licenci](/slides/cs/androidjava/licensing/) jednou na proces. Licenční XML nesmí být změněno a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

**Mohu digitálně podepsat vytvořený PPTX?**

Ano. [Digitální podpisy](/slides/cs/androidjava/digital-signature-in-powerpoint/) (přidání a ověření) jsou pro prezentace podporovány.

**Jsou v vytvořených prezentacích podporovány makra (VBA)?**

Ano. Můžete [vytvářet/upravovat projekty VBA](/slides/cs/androidjava/presentation-via-vba/) a ukládat soubory s makry, jako jsou PPTM/PPSM.