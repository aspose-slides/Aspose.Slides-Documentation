---
title: Převod PPT a PPTX do PDF v Javě [Obsahuje pokročilé funkce]
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
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v jazyce Java nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat nahrazení fontů, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete‑li převést prezentaci do PDF, předávejte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a poté uložte prezentaci jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) poskytuje metodu `save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pro Java vkládá do výstupních dokumentů informace o svém API a číslo verze. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tyto informace ve výstupních dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textové rámečky a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint na PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést poskytnutou prezentaci do PDF pomocí optimálních nastavení na nejvyšší úrovni kvality.

Tento kód ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Uložte prezentaci jako PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Aspose nabízí bezplatný online [**PowerPoint na PDF převodník**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto převodníkem pro živou implementaci zde popsaného postupu.
{{% /alert %}}

## **Převod PowerPoint na PDF s volbami**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/) — které vám umožní přizpůsobit výsledné PDF, zamknout PDF heslem nebo určit, jak má proces převodu probíhat.

### **Převod PowerPoint na PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, nakonfigurovat DPI pro obrázky a další.

Níže uvedený příklad kódu ukazuje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Nastavte kvalitu pro JPG obrázky.
pdfOptions.setJpegQuality((byte)90);

// Nastavte DPI pro obrázky.
pdfOptions.setSufficientResolution(300);

// Nastavte chování pro metafily.
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

### **Převod PowerPoint na PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

Tento kód ukazuje, jak převést prezentaci PowerPoint do PDF se zahrnutými skrytými snímky:

```java
import com.aspose.slides.*;

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

### **Převod PowerPoint na PDF chráněné heslem**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

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

### **Detekce náhrad fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), která vám umožní detekovat náhrady fontů během procesu převodu prezentace na PDF.

Tento kód ukazuje, jak detekovat náhrady fontů:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Nastavte varovný zpětný volání v PDF možnostech.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Uložte prezentaci jako PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementace varovného zpětného volání.
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

{{%  alert color="info"  %}} 
Pro více informací o získávání zpětných volání pro náhrady fontů během procesu renderování viz [Getting Warning Callbacks for Fonts Substitution](/slides/cs/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pro více informací o náhradě fontů si přečtěte článek [Font Substitution](/slides/cs/java/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků v PowerPointu do PDF**

Tento kód demonstruje, jak převést pouze konkrétní snímky z prezentace PowerPoint do PDF:

```java
import com.aspose.slides.*;

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

## **Převod PowerPoint na PDF s vlastní velikostí snímku**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF se zadanou velikostí snímku:

```java
import com.aspose.slides.*;

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

    // Odstraňte prázdný snímek, který byl vytvořen v nové prezentaci.
    resizedPresentation.getSlides().removeAt(1);

    // Uložte upravenou prezentaci jako PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek snímku**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF, který obsahuje poznámky:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Nastavte PDF možnosti s rozvržením poznámek.
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

Aspose.Slides vám umožňuje použít postup převodu, který vyhovuje [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF s použitím libovolného z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF souborů na základě různých standardů souladu:

```java
import com.aspose.slides.*;

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje převádět soubory PDF do populárních formátů. Můžete provést převody [PDF na HTML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/cs/java/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-jpg/), a [PDF na PNG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/cs/java/conversion/pdf-to-tiff/), a [PDF na XML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako je SmartArt, grafy a vzorce, jako s jedním objektem. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celý objekt.

## **FAQ**

### Mohu hromadně převést více souborů PowerPoint do PDF?

Ano, Aspose.Slides podporuje dávkový převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

### Je možné chránit převodovaný PDF heslem?

Určitě. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

### Jak zahrnout skryté snímky do PDF?

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

### Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?

Ano, můžete řídit kvalitu obrázků pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

### Podporuje Aspose.Slides standardy souhlasu PDF/A?

Ano, Aspose.Slides vám umožňuje exportovat PDF, které splňují [různé standardy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty vyhovují požadavkům na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Java](/slides/cs/java/)
- [API reference Aspose.Slides pro Java](https://reference.aspose.com/slides/cs/java/)
- [Aspose bezplatné online převodníky](https://products.aspose.app/slides/cs/conversion)