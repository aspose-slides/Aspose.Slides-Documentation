---
title: Převod PPT a PPTX do PDF v JavaScriptu [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- převod PowerPoint
- převod prezentace
- PowerPoint do PDF
- prezentace do PDF
- PPT do PDF
- převod PPT do PDF
- PPTX do PDF
- převod PPTX do PDF
- uložit PowerPoint jako PDF
- uložit PPT jako PDF
- uložit PPTX jako PDF
- exportovat PPT do PDF
- exportovat PPTX do PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF pomocí Aspose.Slides pro Node.js, s rychlými ukázkami kódu a pokročilými možnostmi konverze."
---
## **Přehled**

Konverze prezentací PowerPoint a OpenDocument (PPT, PPTX, ODP atd.) do formátu PDF v JavaScriptu nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro konverzi a aplikovat normy shody na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) a pak prezentaci uložíte jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) poskytuje metodu `save`, která se obvykle používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro Node.js přes Java vkládá informace o své API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tyto informace v výstupních dokumentech změnilo nebo odstranilo.

{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Specifické snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že vzniklé PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázků
* Textových polí a tvarů
* Formátování textu
* Formátování odstavců
* Hyperlinků
* Záhlaví a zápatí
* Odrážek
* Tabulek

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálního nastavení při maximální úrovni kvality.

Následující kód ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```js
// Vytvořte instanci třídy Presentation, která reprezentuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Uložte prezentaci jako PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertorem pro živou implementaci postupů popsaných zde.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány met soubory, nastavit úroveň komprese pro text, nakonfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu demonstruje, jak převést PowerPoint prezentaci do PDF s několika vlastními možnostmi.

```js
// Vytvořte instanci třídy PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Nastavte kvalitu JPG obrázků.
pdfOptions.setJpegQuality(java.newByte(90));

// Nastavte DPI pro obrázky.
pdfOptions.setSufficientResolution(300);

// Nastavte chování pro metafily.
pdfOptions.setSaveMetafilesAsPng(true);

// Nastavte úroveň komprese textu pro textový obsah.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definujte režim shody PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Uložte prezentaci jako PDF dokument.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions), abyste zahrnuli skryté snímky jako stránky ve výsledném PDF.

Tento JavaScriptový kód ukazuje, jak převést PowerPoint prezentaci do PDF se zahrnutými skrytými snímky:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Vytvořte instanci třídy PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Přidejte skryté snímky.
    pdfOptions.setShowHiddenSlides(true);

    // Uložte prezentaci jako PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento JavaScriptový kód demonstruje, jak převést PowerPoint prezentaci do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions):

```js
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Vytvořte instanci třídy PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Nastavte heslo PDF a přístupová oprávnění.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Uložte prezentaci jako PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

Tento JavaScriptový kód ukazuje, jak detekovat náhrady písem:

```js
// Nastavte výstražný callback v PDF možnostech.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Uložte prezentaci jako PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Pro více informací o náhradách písem si přečtěte článek [Font Substitution](/slides/cs/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků v PowerPointu do PDF**

Tento JavaScriptový kód demonstruje, jak převést pouze konkrétní snímky z PowerPoint prezentace do PDF:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Nastavte pole čísel snímků.
    let slides = java.newArray("int", [1, 3]);

    // Uložte prezentaci jako PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Tento JavaScriptový kód demonstruje, jak převést PowerPoint prezentaci do PDF s určenou velikostí snímku:

```js
const slideWidth = 612;
const slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Vytvořte novou prezentaci s upravenou velikostí snímku.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Nastavte vlastní velikost snímku.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Zkopírujte první snímek z původní prezentace.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Uložte změněnou velikost prezentaci do PDF s poznámkami.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento JavaScriptový kód demonstruje, jak převést PowerPoint prezentaci do PDF, který obsahuje poznámky:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Nastavte možnosti PDF s rozvržením poznámek.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci do PDF s poznámkami.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Dostupnost a standardy shody pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat PowerPoint dokument do PDF pomocí jakéhokoli z těchto standardů shody: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento JavaScriptový kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF na základě různých standardů shody:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides podporuje operace převodu PDF, které vám umožní převést PDF soubory do populárních formátů. Můžete provádět konverze [PDF do HTML](https://products.aspose.com/slides/cs/nodejs-java/conversion/pdf-to-html/), [PDF do JPG](https://products.aspose.com/slides/cs/nodejs-java/conversion/pdf-to-jpg/) a [PDF do PNG](https://products.aspose.com/slides/cs/nodejs-java/conversion/pdf-to-png/). Další konverze PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cs/nodejs-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cs/nodejs-java/conversion/pdf-to-tiff/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete programově projít své soubory a aplikovat proces převodu.

**Je možné převzatý PDF soubor chránit heslem?**

Určitě. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions) k zahrnutí skrytých snímků do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PdfOptions), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy shody PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, a tím zajišťují, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides for Node.js via Java Documentation](/slides/cs/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/cs/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/cs/conversion)