---
title: Převod PPT a PPTX do PDF na Androidu [Zahrnuty pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides pro Android, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF v systému Android nabízí několik výhod, včetně kompatibility mezi různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, používat různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a použít standardy souladu pro výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a poté prezentaci uložíte jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) poskytuje metodu `save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pro Android via Java vkládá informace o své API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application řetězcem "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že není možné Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides umožňuje převádět:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, čímž zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést zadanou prezentaci do PDF s optimálním nastavením při maximální úrovni kvality.

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

Aspose nabízí bezplatný online [**konvertor PowerPoint do PDF**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertorem pro živou implementaci zde popsaného postupu.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo určit, jak má převod probíhat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak se mají zacházet s metaznačkami, nastavit úroveň komprese textu, konfigurovat DPI obrázků a další.

Níže uvedený příklad kódu ukazuje, jak převést prezentaci PowerPoint do PDF s několika vlastními možnostmi.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Nastavte kvalitu obrázků JPG.
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

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků jako stránek do výsledného PDF.

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

### **Převod PowerPoint do PDF chráněného heslem**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/):

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

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), která vám umožní během převodu prezentace do PDF detekovat náhrady písem.

Tento kód ukazuje, jak detekovat náhrady písem:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Nastavte callback pro varování v PDF možnostech.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Uložte prezentaci jako PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementace callbacku pro varování.
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

Pro více informací o náhradách písem si přečtěte článek [Font Substitution](/slides/cs/androidjava/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

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

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF se zadaným rozměrem snímku:

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

    // Odstraňte prázdný snímek, se kterým byla nová prezentace vytvořena.
    resizedPresentation.getSlides().removeAt(1);

    // Uložte změněnou velikost prezentace jako PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento kód demonstruje, jak převést prezentaci PowerPoint do PDF, který zahrnuje poznámky:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurujte PDF možnosti s rozvržením poznámek.
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

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Dokument PowerPoint můžete exportovat do PDF podle některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří více PDF podle různých standardů souladu:

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

Aspose.Slides podporuje operace převodu PDF, umožňující převádět PDF soubory do populárních formátů. Můžete provádět převody [PDF to HTML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cs/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-jpg/) a [PDF to PNG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-png/). Další operace převodu PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/cs/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cs/java/conversion/pdf-to-tiff/) a [PDF to XML](https://products.aspose.com/slides/cs/java/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, diagramy a vzorce, jako s jednou figurou. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut jen pro celou figuru.

## **Často kladené otázky**

### Mohu hromadně převést více souborů PowerPoint do PDF?

Ano, Aspose.Slides podporuje dávkový převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

### Je možné chránit převzatý PDF heslem?

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

### Jak zahrnout skryté snímky do PDF?

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

### Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?

Ano, můžete kontrolovat kvalitu obrázků pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/), aby PDF obsahovalo vysoce kvalitní obrázky.

### Podporuje Aspose.Slides standardy souladu PDF/A?

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistí, že vaše dokumenty splňují požadavky na přístupnost i archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Android via Java](/slides/cs/androidjava/)
- [API reference Aspose.Slides pro Android via Java](https://reference.aspose.com/slides/cs/androidjava/)
- [Bezplatné online konvertory Aspose]https://products.aspose.app/slides/cs/conversion

