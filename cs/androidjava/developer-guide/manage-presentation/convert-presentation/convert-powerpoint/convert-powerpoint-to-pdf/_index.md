---
title: Převod PPT a PPTX do PDF na Androidu [Obsahuje pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/androidjava/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Převádějte PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides pro Android, se rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Overview**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v Androidu nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozložení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **PowerPoint to PDF Conversions**

Používáním Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) poskytuje metodu `save`, která se běžně používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro Android via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka**, že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides vám umožňuje převádět:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, čímž zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou během převodu vykreslovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Convert PowerPoint to PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálních nastavení při maximální úrovni kvality.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Uložte prezentaci jako PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose nabízí bezplatný online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Tento převodník můžete použít pro testování živé implementace postupu popsaného zde.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Convert PowerPoint to PDF with Custom Options**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

```java
// Vytvořte instanci třídy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Nastavte kvalitu pro JPG obrázky.
pdfOptions.setJpegQuality((byte)90);

// Nastavte DPI pro obrázky.
pdfOptions.setSufficientResolution(300);

/// Nastavte chování pro metafily.
pdfOptions.setSaveMetafilesAsPng(true);

// Nastavte úroveň komprese textu pro textový obsah.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definujte režim souladu PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Uložte prezentaci jako PDF dokument.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Vytvořte instanci třídy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Přidejte skryté snímky.
    pdfOptions.setShowHiddenSlides(true);

    // Uložte prezentaci jako PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to PDF with Password Protected PDF**

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/):

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Vytvořte instanci třídy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Nastavte heslo PDF a oprávnění přístupu.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Uložte prezentaci jako PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detect Font Substitutions**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) pod třídou [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

```java
public static void main(String[] args) {
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Nastavte callback varování v PDF možnostech.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Uložte prezentaci jako PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementace callbacku varování.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Pro více informací o náhradě písem viz článek [Náhrada písem](/slides/cs/androidjava/font-substitution/).

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

Tento kód ukazuje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Nastavte pole čísel snímků.
    int[] slides = { 1, 3 };

    // Uložte prezentaci jako PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF s určenou velikostí snímku:

```java
float slideWidth = 612;
float slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Vytvořte novou prezentaci s upravenou velikostí snímku.
Presentation resizedPresentation = new Presentation();

try {
    // Nastavte vlastní velikost snímku.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Klonujte první snímek z původní prezentace.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Uložte upravenou prezentaci do PDF s poznámkami.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF, který obsahuje poznámky:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Nakonfigurujte PDF možnosti s rozložením poznámek.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci do PDF s poznámkami.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF podle libovolného z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provádět převody [PDF to HTML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cs/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-jpg/), a [PDF to PNG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cs/java/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Note:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním obrazcem. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut jen pro celý obrazec.

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Is it possible to password-protect the converted PDF?**

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**How do I include hidden slides in the PDF?**

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Can Aspose.Slides maintain high image quality in the PDF?**

Ano, můžete řídit kvalitu obrazu pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), aby vaše PDF obsahovalo vysoce kvalitní obrázky.

**Does Aspose.Slides support PDF/A compliance standards?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajišťuje, že vaše dokumenty odpovídají požadavkům na přístupnost a archivaci.

## **Additional Resources**

- [Aspose.Slides for Android via Java Documentation](/slides/cs/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/cs/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/cs/conversion)