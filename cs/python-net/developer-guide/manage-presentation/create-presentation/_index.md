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
description: "Vytvářejte prezentace PowerPoint v Pythonu pomocí Aspose.Slides — vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Aspose.Slides pro Python vám umožňuje vytvořit zcela nový soubor prezentace výhradně pomocí kódu. Tento článek ukazuje základní postup – vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) , získání první snímku, vložení jednoduchého tvaru a uložení výsledku – takže můžete vidět, jak málo nastavení je potřeba k vytvoření prezentace bez Microsoft Office. Protože stejné API zapisuje soubory PPT, PPTX i ODP, můžete cílit jak na tradiční PowerPoint, tak na formáty OpenDocument z jedné kódové základny. Aspose.Slides je vhodný pro desktopové, webové i serverové prostředí, což vaší Python aplikaci poskytuje efektivní výchozí bod pro přidání bohatšího obsahu, jako je text, obrázky nebo grafy, jakmile je vytvořena počáteční sada snímků.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od nuly v Aspose.Slides pro Python je tak jednoduché, jako vytvoření instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Konstruktor automaticky poskytne prázdnou prezentaci s jedním snímkem, což vám dává okamžitou plochu pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Po úpravě tohoto snímku – nebo přidání nových – můžete výsledek uložit jako PPTX, starší PPT nebo dokonce formáty OpenDocument. Níže uvedený krátký ukázkový kód ilustruje tento postup přidáním jednoduchého tvaru na první snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) typu `CLOUD` pomocí metody `add_auto_shape` zveřejněné kolekcí `shapes`.
4. Přidejte text do auto‑shape.
5. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu je na první snímek prezentace přidán tvar oblaku.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte auto‑tvar typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/python-net/save-presentation/) a exportovat do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-net/convert-powerpoint-to-xps/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/), [SVG](/slides/cs/python-net/convert-powerpoint-to-png/) a [obrázků](/slides/cs/python-net/convert-powerpoint-to-png/), a další.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/python-net/supported-file-formats/).

**Jak mohu nastavit velikost a poměr stran snímku při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/python-net/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak se má obsah škálovat.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak zvládnout velmi velké prezentace (s mnoha mediálními soubory) a snížit využití paměti?**

Použijte [strategie správy BLOB](/slides/cs/python-net/manage-blob/), omezte úložiště v paměti pomocí dočasných souborů a upřednostňujte pracovní postupy založené na souborech před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nelze operovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) z [více vláken](/slides/cs/python-net/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak odstranit vodotisk a omezení z trial verze?**

[Aplikujte licenci](/slides/cs/python-net/licensing/) jednou na proces. Licenční XML soubor musí zůstat nezměněn a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

**Mohu digitálně podepsat PPTX, který vytvořím?**

Ano. [Digitální podpisy](/slides/cs/python-net/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou v vytvořených prezentacích podporována makra (VBA)?**

Ano. Můžete [vytvářet/editovat VBA projekty](/slides/cs/python-net/presentation-via-vba/) a ukládat soubory s povolenými makry, například PPTM/PPSM.