---
title: Převod PPT a PPTX do PDF na Androidu [Zahrnuty pokročilé funkce]
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
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides pro Android, s rychlými ukázkami kódu a pokročilými možnostmi konverze."
---
## **Přehled**

Konverze prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF na Androidu nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce fontů, vybrat konkrétní snímky pro konverzi a aplikovat standardy souladu na výstupní dokumenty.

## **Konverze PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Třída [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Android via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnilo nebo odstranilo.
{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, přičemž výsledná PDF soubory úzce odpovídají původním prezentacím. Prvky a atributy jsou v konverzi vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides snaží převést poskytnutou prezentaci do PDF pomocí optimálních nastavení na maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozího nastavení exportu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose nabízí zdarma online [**PowerPoint do PDF konvertor**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace do PDF. Můžete spustit test s tímto konvertorem pro živou implementaci postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — které vám umožňují přizpůsobit výsledný PDF, uzamknout PDF heslem nebo určit, jak má probíhat proces konverze.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností konverze můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese pro text, konfigurovat DPI pro obrázky a další.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s hodnotou `true`, abyste zachovali vložené OLE soubory jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožňuje příjemcům soubor otevřít nebo uložit samostatně. OLE objekt se nestane interaktivním listem Excelu na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s připojeným sešitem.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Pro kontrolu výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje přílohy souborů, například Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělen od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze přílohy PDF/A a PDF/A-3 povoluje další typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF s skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků jako stránek ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF, včetně všech skrytých snímků.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Převod PowerPoint do PDF chráněného heslem**

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` pro otevření. Přístupová oprávnění umožňují tisk, včetně tisku ve vysoké kvalitě.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detekce substitucí fontů**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), která vám umožňuje detekovat substituce fontů během procesu konverze prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o substitucích fontů do konzole. Varování je vytištěno pouze při substituci nedostupného fontu během exportu.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pro více informací o substituci fontů si přečtěte článek [Font Substitution](/slides/cs/androidjava/font-substitution/).
{{% /alert %}} 

## **Převod vybraných snímků z PowerPoint do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou číslována od jedné a vstupní prezentace musí obsahovat alespoň tři snímky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku tak, aby se vešel, a exportuje jediný snímek do PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Odstranit prázdný snímek, se kterým byla nová prezentace vytvořena.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka každého snímku pod samotný snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standardy přístupnosti a souladu pro PDF**

Aspose.Slides vám umožňuje použít konverzní postup, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides podporuje operace konverze PDF, což vám umožňuje převádět PDF soubory do populárních formátů. Můžete provést [PDF do HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) a [PDF do PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konverze. Další konverze PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako je SmartArt, grafy a vzorce, jako s jednou figurou. Individuální prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celou figuru.

## **Často kladené otázky**

**Mohu hromadně převádět více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadnou konverzi více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces konverze programově.

**Je možné chránit převod PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu konverze.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) s hodnotou `true` v třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) k zahrnutí skrytých snímků do výsledného PDF.

**Dokáže Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete kontrolovat kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) a [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistíte, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Aspose.Slides pro Android via Java Dokumentace](/slides/cs/androidjava/)
- [Aspose.Slides pro Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online konvertory](https://products.aspose.app/slides/conversion)