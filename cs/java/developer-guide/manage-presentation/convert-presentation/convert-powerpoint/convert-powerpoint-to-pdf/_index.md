---
title: Převod PPT a PPTX do PDF v Javě [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/java/convert-powerpoint-to-pdf/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do PDF
- prezentaci do PDF
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
- Java
- Aspose.Slides
description: "Konvertujte PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v Javě nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) nabízí metodu `save`, která se obvykle používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pro Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formě "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci v dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:
* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, což zajišťuje, že výsledná PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou během převodu přesně vykresleny, včetně:
* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint na PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést zadanou prezentaci do PDF pomocí optimálních nastavení s maximální úrovní kvality.

Tento kód vám ukáže, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

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
Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete provést test s tímto konvertorem pro živou ukázku postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak by měl proces převodu probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak se mají zacházet s metaznačkami, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu ukazuje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```java
// Vytvořte instanci třídy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Nastavte kvalitu pro JPG obrázky.
pdfOptions.setJpegQuality((byte)90);

// Nastavte DPI pro obrázky.
pdfOptions.setSufficientResolution(300);

// Nastavte chování pro meta soubory.
pdfOptions.setSaveMetafilesAsPng(true);

// Nastavte úroveň komprese textu pro textový obsah.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definujte režim souladu PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Uložte prezentaci jako PDF dokument.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty jako stránky ve výsledném PDF.

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF se skrytými snímky zahrnutými:

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

### **Převod PowerPoint do PDF chráněného heslem**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/):

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Vytvořte instanci třídy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Nastavte heslo PDF a přístupová oprávnění.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Uložte prezentaci jako PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detekce substituce písem**

Aspose.Slides nabízí metodu [setWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), která vám umožní detekovat substituce písem během procesu převodu prezentace na PDF.

Tento kód ukazuje, jak detekovat substituce písem:

```java
public static void main(String[] args) {
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Nastavte zpětné volání varování v možnostech PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Uložte prezentaci jako PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementace zpětného volání varování.
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
Pro více informací o přijímání zpětných volání pro substituce písem během procesu vykreslování viz [Getting Warning Callbacks for Fonts Substitution](/slides/cs/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Další informace o substituci písem najdete v článku [Font Substitution](/slides/cs/java/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků v PowerPoint do PDF**

Tento kód demonstruje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

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

## **Převod PowerPoint do PDF se vlastní velikostí snímku**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF se specifikovanou velikostí snímku:

```java
float slideWidth = 612;
float slideHeight = 792;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
Presentation resizedPresentation = new Presentation();

try {
    // Nastavte vlastní velikost snímku.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Zkopírujte první snímek z původní prezentace.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Uložte upravenou prezentaci do PDF s poznámkami.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek k snímkům**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Nakonfigurujte možnosti PDF s rozvržením poznámek.
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

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Pokyny pro přístupnost webového obsahu (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF na základě různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět soubory PDF do populárních formátů. Můžete provést konverze [PDF do HTML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/cs/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cs/java/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Individuální prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu převést více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné chránit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/) k nastavení hesla a definování oprávnění k přístupu během procesu převodu.

**Jak zahrnu skryté snímky do PDF?**

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), abyste zahrnuli skryté snímky do výsledného PDF.

**Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete kontrolovat kvalitu obrázků pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Java](/slides/cs/java/)
- [API reference Aspose.Slides pro Java](https://reference.aspose.com/slides/cs/java/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/cs/conversion)