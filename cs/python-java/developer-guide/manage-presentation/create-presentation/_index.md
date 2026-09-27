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
description: "Vytvářejte prezentace v Pythonu přes Java s Aspose.Slides - vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci pomocí Aspose.Slides for Python via Java, přidat tvar s textem na první snímek a výsledek uložit jako soubor PPTX. Často kladené otázky pokrývají výstupní formáty, šablony, velikost snímků, využití paměti, vícevláknové zpracování, licencování, digitální podpisy a podporu VBA.

Než začnete, nainstalujte Python, JDK, JPype a Aspose.Slides for Python via Java. Viz [Installation](/slides/cs/python-java/installation/) pro kroky ve Windows, Linuxu a macOS.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od začátku v Aspose.Slides for Python via Java je tak jednoduché, jako vytvořit instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . Konstruktor automaticky poskytne prázdnou prezentaci s jediným snímkem, což vám dává okamžitou plátno pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Jakmile tento snímek upravíte – nebo přidáte nové – můžete výsledek uložit jako PPTX, starší PPT nebo dokonce formáty OpenDocument. Níže uvedený krátký ukázkový kód ilustruje tento postup přidáním jednoduchého tvaru na první snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. Získejte první snímek podle jeho indexu 0.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) typu [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) pomocí [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) .
1. Nastavte text tvaru pomocí [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) .
1. Uložte prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) .

Následující příklad spustí Java Virtual Machine (JVM), pokud již neběží, přidá tvar mraku s textem na první snímek a uloží prezentaci. Uložte jej jako *create_presentation.py*:

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

Spusťte skript v prostředí, kde jste nainstalovali balíčky:

```sh
python create_presentation.py
```

Levá horní část mraku je 20 bodů od levého a horního okraje snímku a mrak má šířku 200 bodů a výšku 80 bodů. Skript uloží *new_presentation.pptx* do aktuálního pracovního adresáře, s jedním snímkem, který obsahuje mrak a jeho text. JVM běží dál, dokud proces Python neukončí; viz [Limitations and API Differences](/slides/cs/python-java/limitations-and-api-differences/#import-the-library). Bez licence Aspose.Slides také přidává evaluační vodoznakový textový rámček na každý uložený snímek; viz [Licensing](/slides/cs/python-java/licensing/).

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT, and ODP](/slides/cs/python-java/save-presentation/), a exportovat do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-java/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/), [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/), a [images](/slides/cs/python-java/convert-powerpoint-to-png/), mezi ostatními.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; POTX/POTM/PPTM a podobné formáty [are supported](/slides/cs/python-java/supported-file-formats/).

**Jak mohu ovládat velikost snímku/poměr stran při vytváření prezentace?**

Nastavte [slide size](/slides/cs/python-java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastní rozměry) a vyberte, jak má být obsah škálován.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak mohu zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?**

Použijte [BLOB management strategies](/slides/cs/python-java/manage-blob/), omezte úložiště v paměti využitím dočasných souborů a upřednostněte workflow založené na souborech místo čistě paměťových streamů.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete operovat se stejnou [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instancí z [multiple threads](/slides/cs/python-java/multithreading/). Spusťte samostatné, izolované instance pro každý vlákno nebo proces.

**Jak mohu odstranit zkušební vodoznak a omezení?**

[Apply a license](/slides/cs/python-java/licensing/) jednou na proces. XML licence musí zůstat beze změny a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

**Mohu digitálně podepsat PPTX, který vytvořím?**

Ano. [Digital signatures](/slides/cs/python-java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou podporovány pro prezentace.

**Jsou makra (VBA) podporována v vytvořených prezentacích?**

Ano. Můžete [create/edit VBA projects](/slides/cs/python-java/presentation-via-vba/) a uložit soubory povolené pro makra, jako PPTM/PPSM.