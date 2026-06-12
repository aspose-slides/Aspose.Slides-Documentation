---
title: Vytvořte prezentace v .NET
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte prezentace v .NET pomocí Aspose.Slides — vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah na snímek a výsledek uložit jako soubor. Také demonstruje, jak vytvořit a uložit novou prezentaci, otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu. Navíc článek obsahuje krátké FAQ, které pokrývá běžné otázky týkající se formátů, šablon, velikosti snímků, jednotek, využití paměti, vláknování, licencování, digitálních podpisů a podpory VBA.

## **Vytvoření PowerPoint prezentace**

Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle následujících kroků:

1. Vytvořte instanci třídy Presentation.
2. Získejte referenci na snímek pomocí jeho Indexu.
3. Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes.
4. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```c#
 // Vytvořte objekt Presentation, který představuje soubor prezentace
 using (Presentation presentation = new Presentation())
 {
     // Získá první snímek
     ISlide slide = presentation.Slides[0];

     // Přidá autoshape typu čára
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```

## **Vytvoření a uložení prezentace**

<a name="csharp-create-save-presentation"><strong>Kroky: Vytvoření a uložení prezentace v C#</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Uložte _Presentation_ do libovolného formátu podporovaného [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/).

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Otevření a uložení prezentace**

<a name="csharp-open-save-presentation"><strong>Kroky: Otevření a uložení prezentace v C#</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) s libovolným formátem, např. PPT, PPTX, ODP atd.
2. Uložte _Presentation_ do libovolného formátu podporovaného [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/).

```c#
// Načtěte libovolný podporovaný soubor v Presentation např. ppt, pptx, odp atd.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Do jakých formátů mohu uložit novou prezentaci?**

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/net/save-presentation/), a exportovat do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/net/convert-powerpoint-to-xps/), [HTML](/slides/cs/net/convert-powerpoint-to-html/), [SVG](/slides/cs/net/convert-powerpoint-to-png/) a [obrázků](/slides/cs/net/convert-powerpoint-to-png/), mezi jinými.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/net/supported-file-formats/).

**Jak mohu řídit velikost snímku/poměr stran při vytváření prezentace?**

Nastavte [velikost snímku](/slides/cs/net/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a vyberte, jak se má obsah škálovat.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec je roven 72 jednotkám.

**Jak mohu pracovat s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?**

Použijte [strategii správy BLOB](/slides/cs/net/manage-blob/), omezte úložiště v paměti pomocí dočasných souborů a upřednostněte pracovní postupy založené na souborech před čistě paměťovými streamy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) z [více vláken](/slides/cs/net/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak mohu odstranit zkušební vodoznak a omezení?**

[Aplikujte licenci](/slides/cs/net/licensing/) jednou na proces. XML licence musí zůstat nezměněno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

**Mohu digitálně podepsat vytvořený PPTX?**

Ano. [Digitální podpisy](/slides/cs/net/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou makra (VBA) podporována v vytvořených prezentacích?**

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/net/presentation-via-vba/) a ukládat soubory s povolenými makry, jako jsou PPTM/PPSM.