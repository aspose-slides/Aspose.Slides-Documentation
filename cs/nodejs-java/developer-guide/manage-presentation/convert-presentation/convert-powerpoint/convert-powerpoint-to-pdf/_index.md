---
title: Převod PPT a PPTX do PDF v JavaScriptu [Obsahuje pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převést PPT do PDF
- PPTX do PDF
- převést PPTX do PDF
- uložit PowerPoint jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF pomocí Aspose.Slides pro Node.js, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint a OpenDocument (PPT, PPTX, ODP atd.) do formátu PDF v JavaScriptu nabízí řadu výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, zabezpečit PDF heslem, detekovat náhrady fontů, vybrat konkrétní snímky k převodu a aplikovat normy souladu na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) exponuje metodu [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídá původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textových polí a tvarů
* Formátování textu
* Formátování odstavců
* Hyperlinků
* Záhlaví a zápatí
* Odrážek
* Tabulek

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokouší převést zadanou prezentaci do PDF pomocí optimálního nastavení při maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose nabízí bezplatný online [**PowerPoint do PDF konvertor**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete tento konvertor použít k otestování postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), které umožňují přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, nakonfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s JPEG kvalitou nastavenou na 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a Flate kompresí textu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Automatický výběr komprese obrazu**

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, snížení velikosti exportovaného PDF může usnadnit jeho odeslání e‑mailem nebo stažení. Zavolejte [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) s hodnotou `true`, aby byl během exportu PDF automaticky vybrán nejvhodnější kompresní algoritmus pro každý obrázek.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechny ostatní nastavení exportu PDF si ponechají výchozí hodnoty.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Tato možnost vybírá kompresní algoritmus pro každý obrázek. Snížením hodnoty předané metodě [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) se místo toho snižuje kvalita JPEG obrázku, zatímco snížením hodnoty předané metodě [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) se obrázky mohou downsamplovat na nižší rozlišení, což může snížit detail. Povolení automatického výběru komprese samo o sobě neovlivňuje žádné z těchto nastavení.

Výběr kompresních algoritmů vyžaduje dodatečný čas zpracování a paměť. Úspora velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevná úspora není pro každou prezentaci zaručena.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k prohlížení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) s hodnotou `true`, aby byly vložené OLE soubory zachovány jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale vložený soubor není zahrnut jako příloha. Nastavením této možnosti na `true` se k datům souboru také přidá příloha. Náhled zůstává vizuální reprezentací; příloha umožňuje příjemcům soubor otevřít nebo uložit odděleně. OLE objekt se na stránce PDF nestane interaktivním listem Excelu.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s připojeným sešitem.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Pro kontrolu výsledku:

1. Otevřete exportovaný PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu, abyste si prohlédli data, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 umožňuje jiné typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, ne omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF s skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) ze třídy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF včetně všech skrytých snímků.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` k otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detekce náhrad fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), která umožňuje detekovat náhrady fontů během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradách fontů do konzole. Varování se zobrazí pouze v případě, že během exportu dojde k nahrazení nedostupného fontu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pro více informací o náhradě fontů viz článek [Náhrada fontů](/slides/cs/nodejs-java/font-substitution/).
{{% /alert %}}

### **Zpracování fontů bez dedikovaného tučného řezu**

Prezentace může aplikovat tučné formátování na text i v případě, že její font nemá dedikovaný tučný řez. Text může být stále tučný díky syntetickému zesílení, které uměle zahušťuje běžné glyfy. Když takový text vypadá příliš těžce nebo se liší od zamýšleného vzhledu v PDF, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) s hodnotou `true`. Tato možnost při exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled pro některé fonty. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s normálním textem a druhé s tučným formátováním aplikovaným na stejný font, který nemá dedikovaný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů fontu a exportuje ji do PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Následující náhledy ukazují výstup s vypnutou a zapnutou možností. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. Při zapnuté volbě jsou tahy lehčí; normální text zůstává beze změny. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba zakázaná (`false`, výchozí) | Volba povolená (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

V tomto příkladu povolení možnosti převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho okraje při 800 % přiblížení vypadají měkčeji. Normální text zůstává vyhledávatelný. S možností vypnutou zůstávají oba řetězce jako text.

Tato možnost rasterizuje text formátovaný jako tučný, pokud jeho font nemá dedikovaný tučný řez. [Náhrada fontů](/slides/cs/nodejs-java/font-substitution/) místo toho vybere jiný font, když původní není dostupný.

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jednorozměrná a vstupní prezentace musí obsahovat alespoň tři snímky.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Odebrat prázdný snímek, který byl vytvořen v nové prezentaci.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámkových snímků**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka pod každý snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít převodní postup, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některé z těchto norem souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF podle různých norem souladu:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do oblíbených formátů. Můžete provádět [PDF do HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF do JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) a [PDF do PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) převody. Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako je SmartArt, grafy a vzorce, jako s jedním obrázkem. Jednotlivé cestové elementy nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý obrázek.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné zabezpečit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty do výsledného PDF.

**Může Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete kontrolovat kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) a [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides normy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé normy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides for Node.js via Java Documentation](/slides/cs/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)