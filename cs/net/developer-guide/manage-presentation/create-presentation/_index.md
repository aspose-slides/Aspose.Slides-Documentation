---
title: Vytváření prezentací v .NET
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

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat textové pole na její první snímek a výsledek uložit jako soubor. Také ukazuje, jak vytvořit a uložit prázdnou prezentaci a jak otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu. Na konci je krátké FAQ, které pokrývá časté otázky ohledně formátů, šablon, velikosti snímků, jednotek, využití paměti, vícenásobných vláken, licencování, digitálních podpisů a podpory VBA.

Než začnete, přidejte Aspose.Slides do svého projektu z NuGet. Viz [Instalace](/slides/cs/net/installation/) pro balíček určený pro Windows, Linux a macOS.

## **Vytvoření PowerPoint prezentace**

Chcete‑li vytvořit prezentaci a umístit textové pole na její první snímek, postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.  
2. Získáte tento snímek ze sbírky [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) podle jeho indexu 0.  
3. Přidejte obdélník metodou [AddAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addautoshape/) a nastavte jeho [text](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/text/).  
4. Uložte prezentaci jako soubor PPTX metodou [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Horní levý roh obdélníku je vzdálen 50 bodů od levého okraje a 50 bodů od horního okraje snímku; šířka obdélníku je 400 bodů a výška 100 bodů. Uložený soubor obsahuje jeden snímek s tímto obdélníkem a jeho textem. Bez licence Aspose.Slides také přidává evaluační vodoznak na každý uložený snímek; viz [Licencování](/slides/cs/net/licensing/).

## **Vytvoření a uložení prezentace**

<a name="csharp-create-save-presentation"></a>

Pro vytvoření prázdné prezentace a její uložení vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a uložte ji v libovolném formátu z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/). Výsledkem je prezentace s jedním prázdným snímkem.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Otevření a uložení prezentace**

<a name="csharp-open-save-presentation"></a>

Pro převod prezentace z jednoho formátu do druhého otevřete soubor předáním jeho cesty konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/presentation/) a poté jej uložte v cílovém formátu. Aspose.Slides rozpozná vstupní formát (např. PPT, PPTX nebo ODP) přímo ze souboru.

Níže uvedený příklad předpokládá, že v pracovním adresáři je prezentace OpenDocument *Sample.odp* a uloží ji jako PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Jaké formáty mohu použít k uložení nové prezentace?

Můžete ukládat do [PPTX, PPT a ODP](/slides/cs/net/save-presentation/) a exportovat do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/net/convert-powerpoint-to-xps/), [HTML](/slides/cs/net/convert-powerpoint-to-html/), [SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) a [obrázků](/slides/cs/net/convert-powerpoint-to-png/), a dalších.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/net/supported-file-formats/).

### Jak mohu ovládat velikost/snímkový poměr při vytváření prezentace?

Nastavte [velikost snímku](/slides/cs/net/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak se má obsah škálovat.

### V jakých jednotkách jsou měřeny velikosti a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?

Použijte [strategii správy BLOB](/slides/cs/net/manage-blob/), omezte úložiště v paměti využitím dočasných souborů a upřednostněte workflow založené na souborech před čistě paměťovými streamy.

### Mohu vytvářet/ukládat prezentace paralelně?

Nelze pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) z [více vláken](/slides/cs/net/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

### Jak odstranit zkušební vodoznak a omezení?

[Použijte licenci](/slides/cs/net/licensing/) jednou na proces. XML licence nesmí být modifikováno a nastavení licence by mělo být synchronizováno, pokud používáte více vláken.

### Mohu digitálně podepsat vytvořený PPTX?

Ano. [Digitální podpisy](/slides/cs/net/digital-signature-in-powerpoint/) (přidávání i ověřování) jsou pro prezentace podporovány.

### Jsou makra (VBA) podporována v vytvořených prezentacích?

Ano. Můžete [vytvářet/editovat VBA projekty](/slides/cs/net/presentation-via-vba/) a ukládat soubory s povolenými makry, jako jsou PPTM/PPSM.