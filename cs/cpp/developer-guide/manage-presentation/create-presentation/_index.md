---
title: Vytváření prezentací v C++
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Vytvářejte prezentace v C++ s Aspose.Slides - vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah do snímku a výsledek uložit jako soubor.

## **Vytvoření prezentace PowerPoint**
Chcete‑li přidat jednoduchou rovnou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
2. Získejte odkaz na snímek pomocí jeho Indexu.
3. Přidejte AutoShape typu Čára pomocí metody AddAutoShape, která je součástí objektu Shapes.
4. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **Často kladené otázky**

**Do jakých formátů mohu novou prezentaci uložit?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/cpp/save-presentation/), a exportovat do [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cs/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cs/cpp/convert-powerpoint-to-html/), [SVG](/slides/cs/cpp/convert-powerpoint-to-png/) a [obrázků](/slides/cs/cpp/convert-powerpoint-to-png/), a další.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/cpp/supported-file-formats/).

**Jak mohu při vytváření prezentace ovládat velikost snímku/poměr stran?**

Nastavte [velikost snímku](/slides/cs/cpp/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak má být obsah škálován.

**V jakých jednotkách se měří velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) a snížit využití paměti?**

Použijte [strategii správy BLOB](/slides/cs/cpp/manage-blob/), omezte úložiště v paměti využitím dočasných souborů a upřednostněte pracovní toky založené na souborech před čistě paměťovými proudy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete operovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) z [více vláken](/slides/cs/cpp/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak odstranit zkušební vodoznak a omezení?**

[Aplikujte licenci](/slides/cs/cpp/licensing/) jednou na proces. XML licence musí zůstat nepozměněno a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

**Mohu digitálně podepsat vytvořený PPTX?**

Ano. [Digitální podpisy](/slides/cs/cpp/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou vytvořené prezentace podporovány s makry (VBA)?**

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/cpp/presentation-via-vba/) a ukládat soubory s makry, jako jsou PPTM/PPSM.