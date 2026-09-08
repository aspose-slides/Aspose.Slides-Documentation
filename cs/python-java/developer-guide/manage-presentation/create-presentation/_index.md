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
description: "Vytvářejte prezentace v Pythonu přes Java pomocí Aspose.Slides - vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci pomocí Aspose.Slides pro Python přes Java, přidat tvar s textem na první snímek a uložit výsledek jako soubor PPTX. Často kladené otázky pokrývají výstupní formáty, šablony, velikost snímků, využití paměti, vlákna, licencování, digitální podpisy a podporu VBA.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od nuly v Aspose.Slides pro Python přes Java je tak přímé, jako vytvořit instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Konstruktor automaticky poskytne prázdnou prezentaci s jedním snímkem, čímž vám poskytne okamžité plátno pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Jakmile tento snímek upravíte – nebo přidáte nové – můžete výsledek uložit jako PPTX, starší PPT nebo dokonce formáty OpenDocument. Krátký ukázkový kód níže ilustruje tento postup přidáním jednoduchého tvaru na první snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapetype/#Cloud) pomocí [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Nastavte text tvaru pomocí [TextFrame.setText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/#setText).
1. Uložte prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx).

Následující příklad vyžaduje Aspose.Slides pro Python přes Java a kompatibilní Java runtime. Spustí JVM, pokud již neběží, přidá tvar mraku na první snímek a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte prezentaci s jedním prázdným snímkem.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tvar mraku a nastavte jeho text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/python-java/save-presentation/), a exportovat do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), [SVG](/slides/cs/python-java/render-slide-as-svg/), a [obrázků](/slides/cs/python-java/convert-powerpoint-to-png/), mezi jinými.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/python-java/supported-file-formats/).

**Jak mohu řídit velikost snímku/poměr stran při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/python-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak má být obsah škálován.

**V jakých jednotkách se měří velikosti a souřadnice?**

V bodech: 1 palec se rovná 72 jednotkám.

**Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?**

Použijte [strategii správy BLOB](/slides/cs/python-java/manage-blob/), omezte úložiště v paměti využitím dočasných souborů a upřednostněte souborově založené pracovní postupy před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete pracovat se stejnou [Presentation] instancí z [více vláken](/slides/cs/python-java/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak mohu odstranit vodotisk z trial verze a omezení?**

[Aplikujte licenci](/slides/cs/python-java/licensing/) jednou za proces. XML licence musí zůstat nepozměněno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

**Mohu digitálně podepsat PPTX, který vytvořím?**

Ano. [Digitální podpisy](/slides/cs/python-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou makra (VBA) v vytvořených prezentacích podporována?**

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/python-java/presentation-via-vba/) a ukládat soubory s makry, jako jsou PPTM/PPSM.