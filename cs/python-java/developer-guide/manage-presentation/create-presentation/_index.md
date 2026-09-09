---
title: Vytváření prezentací v Pythonu přes Java
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/python-java/create-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Vytvářejte prezentace v Pythonu přes Java pomocí Aspose.Slides—vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci pomocí Aspose.Slides pro Python přes Java, přidat tvar s textem na první snímek a uložit výsledek jako soubor PPTX. Často kladené otázky pokrývají výstupní formáty, šablony, velikost snímků, využití paměti, vlákna, licencování, digitální podpisy a podporu VBA.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od nuly v Aspose.Slides pro Python přes Java je tak jednoduché, jako vytvořit instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Konstruktor automaticky poskytne prázdnou prezentaci s jediným snímkem, což vám okamžitě nabízí plátno pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Po úpravě tohoto snímku – nebo po přidání nových – můžete výsledek uložit jako PPTX, starší PPT nebo i do formátů OpenDocument. Níže uvedený stručný ukázkový kód ilustruje tento postup přidáním jednoduchého tvaru na první snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Cloud) pomocí [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Nastavte text tvaru pomocí [TextFrame.setText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#setText).
1. Uložte prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx).

Následující příklad vyžaduje Aspose.Slides pro Python přes Java a kompatibilní runtime Java. Spustí JVM, pokud ještě neběží, přidá tvar oblaku na první snímek a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořit prezentaci s jedním prázdným snímkem.
presentation = Presentation()
try:
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidat tvar oblaku a nastavit jeho text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Uložit prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete ukládat do [PPTX, PPT a ODP](/slides/cs/python-java/save-presentation/), a exportovat do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), [SVG](/slides/cs/python-java/render-slide-as-svg/), a [obrázků](/slides/cs/python-java/convert-powerpoint-to-png/), mezi jinými.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [are supported](/slides/cs/python-java/supported-file-formats/).

**Jak mohu řídit velikost/poměr stran snímku při vytváření prezentace?**

Nastavte [slide size](/slides/cs/python-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak má být obsah škálován.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec = 72 jednotek.

**Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení používání paměti?**

Použijte [BLOB management strategies](/slides/cs/python-java/manage-blob/), omezte ukládání do paměti využitím dočasných souborů a upřednostňujte workflow založené na souborech před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) z [multiple threads](/slides/cs/python-java/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak mohu odstranit vodotisk z trial verze a omezení?**

[Apply a license](/slides/cs/python-java/licensing/) jednou na proces. XML licence musí zůstat nezměněné a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

**Mohu digitálně podepsat vytvořený PPTX?**

Ano. [Digital signatures](/slides/cs/python-java/digital-signature-in-powerpoint/) (přidávání i ověřování) jsou pro prezentace podporovány.

**Jsou makra (VBA) podporována v vytvářených prezentacích?**

Ano. Můžete [create/edit VBA projects](/slides/cs/python-java/presentation-via-vba/) a uložit soubory s makry, jako jsou PPTM/PPSM.