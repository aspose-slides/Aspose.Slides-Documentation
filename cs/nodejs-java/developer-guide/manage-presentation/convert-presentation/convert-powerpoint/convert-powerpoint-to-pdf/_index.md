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
description: "Převést PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF pomocí Aspose.Slides pro Node.js, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Konverze prezentací PowerPoint a OpenDocument (PPT, PPTX, ODP atd.) do formátu PDF pomocí JavaScriptu nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, zabezpečit PDF soubory heslem, detekovat náhradní písma, vybrat konkrétní snímky pro konverzi a aplikovat standardy souladu na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete‑li převést prezentaci do PDF, předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Třída [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), která se běžně používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java vkládá informace o své API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka**: nemůžete Aspose.Slides instruovat, aby tyto informace změnilo nebo odebralo z výstupních dokumentů.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF tak, aby výsledné PDF co nejvíce odpovídalo původním prezentacím. V konverzi jsou přesně vykresleny následující prvky a atributy, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint → PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF s optimálním nastavením a maximální úrovní kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozích nastavení exportu.

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
Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Tento konvertor můžete použít k otestování postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, zabezpečit PDF heslem nebo určit, jak má probíhat proces převodu.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete nastavit preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

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

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) s hodnotou `true`, aby byly vložené OLE soubory zachovány jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona objektu OLE je vykreslena na stránce PDF, ale vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se souborová data také zahrnou. Náhled zůstává vizuální reprezentací; příloha umožňuje příjemcům otevřít nebo uložit vložený soubor samostatně. Objekt OLE se na stránce PDF nepřemění na interaktivní list Excelu.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excelu, a exportuje ji do PDF se sešitem jako přílohou.

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

1. Otevřete exportovaný PDF v prohlížeči, který podporuje souborové přílohy, např. Adobe Acrobat Reader.
2. Otevřete panel **Attachments** a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu, abyste mohli zkontrolovat data, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A‑1 zakazuje vložené soubory, PDF/A‑2 povoluje jen přílohy PDF/A a PDF/A‑3 povoluje i jiné typy souborů, včetně sešitů Excelu. Jedná se o požadavky samotných standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

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

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

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

### **Detekce náhradních písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradě písem do konzole. Varování je vytištěno jen v případě, že je během exportu nahrazeno nedostupné písmo.

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
Další informace o náhradě písem naleznete v článku [Náhrada písem](/slides/cs/nodejs-java/font-substitution/).
{{% /alert %}} 

### **Zpracování písem bez vyhrazeného tučného řezu**

Prezentace může použít tučné formátování textu i když má písmo bez vyhrazeného tučného řezu. Text může být stále zobrazen tučně pomocí syntetického tučení, které uměle zesiluje běžné glyfy. Když tento text v PDF vypadá příliš těžce nebo jinak neodpovídá zamýšlenému vzhledu, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) s hodnotou `true`. Tato možnost vykreslí postižený text jako bitmapu během exportu PDF a může zlepšit jeho vzhled u některých písem. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním na stejném písmu, které nemá vyhrazený tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písem a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou možností. V tomto příkladu má tučný text těžší tahy při vypnuté volbě. S volbou zapnutou jsou tahy lehčí; běžný text zůstává beze změny. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnuta (`false`, výchozí) | Volba zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutá](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutá](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí možnosti převádí jen tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany při 800 % zvětšení vypadají měkčeji. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato možnost rasterizuje text formátovaný jako tučný, pokud jeho písmo nemá vyhrazený tučný řez. [Náhrada písem](/slides/cs/nodejs-java/font-substitution/) místo toho vybere jiné písmo, pokud je původní nedostupné.

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou číslována od jedné a vstupní prezentace musí obsahovat alespoň tři snímky.

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

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Obsah snímku přepočítá tak, aby se vešel, a exportuje jediný snímek do PDF.

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

    // Odstraňte prázdný snímek, který byl vytvořen v nové prezentaci.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení snímků s poznámkami**

Následující příklad exportuje prezentaci do PDF a pod každým snímkem umístí poznámky přednášejícího. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

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

## **Zpřístupnění a standardy souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Dokument PowerPoint můžete exportovat do PDF podle jakéhokoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

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
Aspose.Slides podporuje operace převodu PDF, které vám umožní převádět PDF soubory do populárních formátů. Můžete provést převody [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) a [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — také jsou podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrázkem. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý obrázek.

## **Často kladené otázky**

**Mohu převádět více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné zabezpečit převedený PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) a [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) ve třídě [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistí, že vaše dokumenty vyhovují požadavkům na zpřístupnění a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Node.js via Java](/slides/cs/nodejs-java/)
- [API reference Aspose.Slides pro Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/conversion)