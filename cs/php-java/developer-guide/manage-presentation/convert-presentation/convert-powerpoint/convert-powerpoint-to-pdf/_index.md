---
title: Převod PPT a PPTX do PDF v PHP [Obsahuje pokročilé funkce]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /cs/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: Převeďte PowerPoint PPT/PPTX na vysoce kvalitní, prohledávatelné PDF v PHP pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu.
---
## **Přehled**

Převod PowerPoint prezentací (PPT, PPTX, ODP a dalších) do formátu PDF v PHP nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převádět prezentace do PDF dokumentů, používat různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady fontů, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a pak prezentaci uložíte jako PDF pomocí metody `save`. Třída [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) exponuje metodu `save`, která se typicky používá k převodu prezentace do PDF.

{{%  alert title="POZNÁMKA"  color="warning"   %}} 

Aspose.Slides pro PHP via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Upozornění**, že nemůžete Aspose.Slides přimět tuto informaci ve výstupních dokumentech změnit nebo odstranit.

{{% /alert %}}

Aspose.Slides vám umožňuje převádět:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF tak, aby výsledné PDF co nejvíce odpovídalo původním prezentacím. Prvky a atributy jsou při převodu přesně vykresleny, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hypertextové odkazy
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint → PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést poskytnutou prezentaci do PDF s optimálním nastavením a maximální kvalitou.

Tento kód ukazuje, jak převést prezentaci (PPT, PPTX, ODP atd.) do PDF:

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Uložte prezentaci jako PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose nabízí bezplatný online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete si tento převod vyzkoušet přímo na webu.

{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PdfOptions) — které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo specifikovat, jak má probíhat proces převodu.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovány metafily, nastavit úroveň komprese textu, konfigurovat DPI obrázků a další.

Ukázkový kód níže demonstruje, jak převést PowerPoint prezentaci do PDF s několika vlastními možnostmi.

```php
# Vytvořte instanci třídy PdfOptions.
$pdfOptions = new PdfOptions();

# Nastavte kvalitu JPG obrázků.
$pdfOptions->setJpegQuality(90);

# Nastavte DPI obrázků.
$pdfOptions->setSufficientResolution(300);

# Nastavte chování metafilek.
$pdfOptions->setSaveMetafilesAsPng(true);

# Nastavte úroveň komprese textu pro textový obsah.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definujte režim souladu PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Uložte prezentaci jako PDF dokument.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete pomocí metody [setShowHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PdfOptions) zahrnout skryté snímky jako stránky ve výsledném PDF.

Tento kód ukazuje, jak převést PowerPoint prezentaci do PDF se skrytými snímky:

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Vytvořte instanci třídy PdfOptions.
    $pdfOptions = new PdfOptions();

    # Přidejte skryté snímky.
    $pdfOptions->setShowHiddenSlides(true);

    # Uložte prezentaci jako PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Převod PowerPoint do PDF chráněného heslem**

Tento kód demonstruje, jak převést PowerPoint prezentaci do PDF chráněného heslem pomocí parametrů ochrany ze třídy [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/) :

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Vytvořte instanci třídy PdfOptions.
    $pdfOptions = new PdfOptions();

    # Nastavte heslo PDF a přístupová oprávnění.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Uložte prezentaci jako PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Detekce substitucí fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setWarningCallback) ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), která umožňuje detekovat substituce fontů během převodu prezentace do PDF.

Tento kód ukazuje, jak detekovat substituce fontů:

```php
// Nastavte výzvu varování v možnostech PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Uložte prezentaci jako PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Pro více informací o substituci fontů si přečtěte článek [Font Substitution](/slides/cs/php-java/font-substitution/).

{{% /alert %}} 

## **Převod vybraných snímků v PowerPoint do PDF**

Tento kód demonstruje, jak převést pouze konkrétní snímky z PowerPoint prezentace do PDF:

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Nastavte pole čísel snímků.
    $slides = array(1, 3);

    # Uložte prezentaci jako PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Tento kód demonstruje, jak převést PowerPoint prezentaci do PDF se zadanou velikostí snímku:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Vytvořte novou prezentaci s upravenou velikostí snímku.
$resizedPresentation = new Presentation();

try {
    # Nastavte vlastní velikost snímku.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Klonujte první snímek z původní prezentace.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Uložte upravenou prezentaci do PDF s poznámkami.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Tento kód demonstruje, jak převést PowerPoint prezentaci do PDF, který zahrnuje poznámky ke snímkům:

```php
# Vytvořte instanci třídy Presentation, která představuje soubor PowerPoint nebo OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Nakonfigurujte možnosti PDF s rozvržením poznámek.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Uložte prezentaci do PDF s poznámkami.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat PowerPoint dokument do PDF s kterýmkoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint → PDF, který vytváří více PDF souborů podle různých standardů souladu:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Poznámka" color="warning" %}} 

Aspose.Slides podporuje operace převodu PDF, které vám umožňují převádět PDF soubory do populárních formátů. Můžete provádět [PDF to HTML](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-jpg/), a [PDF to PNG](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-png/) převody. Další převody PDF do specializovaných formátů — [PDF to SVG](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-tiff/), a [PDF to XML](https://products.aspose.com/slides/cs/php-java/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedinou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován jen pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje dávkový převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné chránit převzatý PDF heslem?**

Rozhodně. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Použijte metodu `setShowHiddenSlides` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Dokáže Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako `setJpegQuality` a `setSufficientResolution` ve třídě [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF soubory, které splňují různé standardy, včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty vyhovují požadavkům na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides for PHP via Java Documentation](/slides/cs/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/cs/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/cs/conversion)