---
title: Převod PPT a PPTX do PDF v Javě [Obsahuje pokročilé funkce]
linktitle: PowerPoint na PDF
type: docs
weight: 40
url: /cs/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP apod.) do formátu PDF v jazyce Java nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace na PDF dokumenty, používat různé možnosti pro kontrolu kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint na PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete‑li převést prezentaci do PDF, předávejte název souboru jako argument třídě [Prezentace](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a poté prezentaci uložte jako PDF pomocí metody [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Třída [Prezentace](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), která se obvykle používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides pro Java vloží informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou „*Aspose.Slides*“ a pole PDF Producer hodnotou ve formátu „*Aspose.Slides v XX.XX*“. **Poznámka** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.

{{% /alert %}}

Aspose.Slides umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF, čímž zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint na PDF**

Standardní proces převodu PowerPoint na PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést poskytnutou prezentaci do PDF s optimálními nastaveními při maximální úrovni kvality.

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

Aspose nabízí bezplatný online [**PowerPoint na PDF převodník**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který demonstruje proces převodu prezentace na PDF. Můžete vyzkoušet tento převodník pro živou implementaci postupu popsaného zde.

{{% /alert %}}

## **Převod PowerPoint na PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), které vám umožní upravit výsledné PDF, zamknout PDF heslem nebo určit, jak má převodní proces pokračovat.

### **Převod PowerPoint na PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

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

### **Automatický výběr komprese obrázků**

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, zmenšení velikosti exportovaného PDF může usnadnit odeslání e‑mailem nebo stažení. Zavolejte [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) s hodnotou `true`, aby se během exportu PDF automaticky vybral nejvhodnější kompresní algoritmus pro každý obrázek.

Následující příklad načte existující prezentaci, zapne automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechna ostatní nastavení exportu PDF zachovají své výchozí hodnoty.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Tato možnost vybírá kompresní algoritmus pro každý obrázek. Snížením hodnoty předávané metodě [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) se sníží kvalita JPEG obrázku, zatímco snížením hodnoty předávané metodě [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) se umožní downsampling obrázků na nižší rozlišení, což může zmenšit detail. Zapnutí automatického výběru komprese samo o sobě nesnižuje žádnou z těchto nastavení.

Výběr kompresních algoritmů pro obrázky vyžaduje další výpočetní čas a paměť. Redukce velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevná úspora není u každé prezentace zaručena.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excelu, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s hodnotou `true`, aby se vložené OLE soubory zachovaly jako přílohy v výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nestane interaktivním listem Excelu na stránce PDF.

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

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Přílohy** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu pro kontrolu dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}

Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje jen PDF/A přílohy a PDF/A-3 povoluje jiné typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli o omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.

{{% /alert %}}

### **Převod PowerPoint na PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

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

### **Převod PowerPoint na PDF chráněné heslem**

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

### **Detekce náhrad písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace na PDF.

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

Pro více informací o náhradách písem viz článek [Náhrada písma](/slides/cs/java/font-substitution/).

{{% /alert %}} 

### **Zacházení s písmy bez samostatného tučného řezu**

Prezentace může použít tučné formátování textu i když její písmo nemá samostatný tučný řez. Text se pak může jevit jako tučný pomocí syntetického tučného stylu, který uměle zesílí běžné glyfy. Pokud takový text v PDF vypadá příliš těžce nebo jinak neodpovídá zamýšlenému vzhledu, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) s hodnotou `true`. Tato možnost během exportu PDF vykreslí dotýkaný text jako bitmapu a může zlepšit jeho vzhled pro některá písma. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním aplikovaným na stejné písmo, které nemá samostatný tučný řez. Následující příklad načte prezentaci, zapne rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Následující náhledy ukazují výstup s vypnutou a se zapnutou možností. V tomto příkladu má tučný text při vypnuté možnosti těžší tahy. Po zapnutí možnosti jsou tahy lehčí; běžný text zůstává beze změny. Porovnejte výsledky před tím, než si vyberete nastavení pro svou prezentaci.

| Možnost vypnuta (`false`, výchozí) | Možnost zapnuta (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutou](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutou](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí možnosti převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho okraje při 800 % zvětšení vypadají měkče. Běžný text zůstává vyhledatelný. Při vypnuté možnosti zůstávají oba řetězce jako text.

Tato možnost rasterizuje text formátovaný jako tučný, pokud jeho písmo nemá samostatný tučný řez. [Náhrada písma](/slides/cs/java/font-substitution/) místo toho vybere jiné písmo, když původní není dostupné.

## **Převod vybraných snímků z PowerPointu do PDF**

Následující příklad exportuje snímky 1 a 3 z prezentace do PDF. Čísla snímků v tomto poli jsou jednorozměrná a vstupní prezentace musí obsahovat alespoň tři snímky.

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

## **Převod PowerPoint na PDF s vlastním rozměrem snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s rozměrem snímku 612 × 792 bodů (8,5 × 11 palců). Škáluje obsah snímku, aby se vešel, a exportuje jediný snímek do PDF.

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

    // Odstraňte prázdný snímek, se kterým byla nová prezentace vytvořena.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint na PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF, přičemž pod každým snímkem umístí poznámky přednášejícího. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

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

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí kterékoli z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

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

Aspose.Slides podporuje operace převodu PDF, které umožňují převádět PDF soubory do oblíbených formátů. Můžete provádět převody [PDF na HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF na obrázek](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF na JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) a [PDF na PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF na SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF na TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) a [PDF na XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — jsou také podporovány.

{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním objektem. Jednotlivé cestové prvky nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý objekt.

## **Často kladené otázky**

**Mohu převést více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) k nastavení hesla a definování přístupových oprávnění během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) s hodnotou `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Může Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) a [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Java](/slides/cs/java/)
- [API reference Aspose.Slides pro Java](https://reference.aspose.com/slides/java/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/conversion)