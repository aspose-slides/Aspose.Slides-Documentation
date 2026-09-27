---
title: Vytváření prezentací v Pythonu
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Vytvořte prezentace PowerPoint v Pythonu pomocí Aspose.Slides—vytvářejte soubory PPT, PPTX a ODP, využijte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci s Aspose.Slides pro Python přes .NET, přidat tvar s textem na její první snímek a uložit výsledek jako soubor PPTX. Stejné API také ukládá prezentace jako PPT a ODP, takže můžete cílit na formáty PowerPoint i OpenDocument z jednoho kódu, bez Microsoft Office. Krátké FAQ na konci pokrývá běžné otázky o formátech, šablonách, velikosti snímků, jednotkách, využití paměti, vláknech, licencování, digitálních podpisech a podpoře VBA.

Než začnete, nainstalujte balíček z PyPI pomocí `pip install aspose.slides`. Viz [Instalace](/slides/cs/python-net/installation/) pro knihovny, které také potřebují Linux a macOS, a pro virtuální prostředí, které vyžaduje systémový Python v Debianu a Ubuntu.

## **Vytvořit prezentaci**

Chcete-li vytvořit prezentaci a umístit tvar s textem na její první snímek, postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.
2. Získejte tento snímek ze sbírky [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) pomocí jeho indexu 0.
3. Přidejte oblačný [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) pomocí metody [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) ze sbírky [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) snímku a nastavte jeho [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/).
4. Uložte prezentaci jako soubor PPTX pomocí metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Získat první snímek.
    slide = presentation.slides[0]

    # Přidat automatický tvar typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Uložit prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Lehý roh obláčku je 20 bodů od levého okraje a 20 bodů od horního okraje snímku a obláček je široký 200 bodů a vysoký 80 bodů. Výraz `with` uvolní prostředky prezentace po ukončení bloku. Skript uloží *new_presentation.pptx* do aktuální složky, s jedním snímkem, který obsahuje obláček a jeho text. Bez licence Aspose.Slides také přidává evaluační vodoznak na každý uložený snímek; viz [Licencování](/slides/cs/python-net/licensing/).

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

### Do jakých formátů mohu uložit novou prezentaci?

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/python-net/save-presentation/), a exportovat do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-net/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/), [SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) a [obrázky](/slides/cs/python-net/convert-powerpoint-to-png/), mezi jinými.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/python-net/supported-file-formats/).

### Jak mohu kontrolovat velikost snímku/poměr stran při vytváření prezentace?

Nastavte [velikost snímku](/slides/cs/python-net/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak by měl být obsah měněn.

### V jakých jednotkách se měří velikosti a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení spotřeby paměti?

Použijte [strategie správy BLOB](/slides/cs/python-net/manage-blob/), omezte úložiště v paměti využitím dočasných souborů a upřednostněte workflow založené na souborech před čistě paměťovými proudy.

### Mohu vytvářet/ukládat prezentace paralelně?

Nelze operovat na stejné instanci [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) z [více vláken](/slides/cs/python-net/multithreading/). Spusťte samostatné, izolované instance na každé vlákno nebo proces.

### Jak odstranit zkušební vodoznak a omezení?

[Aplikujte licenci](/slides/cs/python-net/licensing/) jednou na proces. XML licence musí zůstat nezměněný a nastavení licence by mělo být synchronizováno, pokud se zapojují více vláken.

### Mohu digitálně podepsat PPTX, který vytvořím?

Ano. [Digitální podpisy](/slides/cs/python-net/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou podporovány pro prezentace.

### Jsou makra (VBA) podporována ve vytvořených prezentacích?

Ano. Můžete [vytvářet/editovat VBA projekty](/slides/cs/python-net/presentation-via-vba/) a uložit soubory s makry jako PPTM/PPSM.