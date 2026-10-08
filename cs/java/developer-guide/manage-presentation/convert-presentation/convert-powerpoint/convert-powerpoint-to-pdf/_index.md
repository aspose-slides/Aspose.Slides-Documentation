---
title: "Převod PPT a PPTX do PDF v Javě [Zahrnuty Pokročilé Funkce]"
linktitle: "PowerPoint do PDF"
type: docs
weight: 40
url: /cs/java/convert-powerpoint-to-pdf/
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
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Převádějte PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides, s rychlými ukázkami kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP apod.) do formátu PDF v Javě nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, chránit PDF soubory heslem, detekovat substituce písem, vybrat konkrétní snímky k převodu a použít normy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převést prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Chcete-li převést prezentaci do PDF, předávejte název souboru jako argument třídě [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a poté uložte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Třída [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application hodnotou "*Aspose.Slides*" a pole PDF Producer hodnotou ve tvaru "*Aspose.Slides v XX.XX*". **Note** že nemůžete Aspose.Slides instruovat, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Vybrané snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají původním prezentacím. Prvky a atributy jsou při převodu renderovány přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a patičky
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí volby. V tomto případě se Aspose.Slides snaží převést zadanou prezentaci do PDF pomocí optimálního nastavení na maximálních úrovních kvality.

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
Aspose nabízí zdarma online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Můžete provést test s tímto převodníkem pro živou implementaci zde popsaného postupu.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), které vám umožní přizpůsobit výsledný PDF, zamknout PDF heslem nebo určit, jak má proces převodu pokračovat.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být metafily zpracovány, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s JPEG kvalitou nastavenou na 90, rozlišením obrázku 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

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

### **Zachovat vložené OLE soubory jako PDF přílohy**

Pokud prezentace obsahuje vložený Excel sešit, můžete chtít, aby příjemci PDF mohli přistupovat k datům sešitu i prohlížet snímky. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s `true`, aby se vložené OLE soubory zachovaly jako přílohy ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu se vykreslí na stránce PDF, ale jeho vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožní příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nestane interaktivním Excel listem na stránce PDF.

Následující příklad načte prezentaci, která již obsahuje vložený Excel sešit, a exportuje ji do PDF s přiloženým sešitem.

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

Pro ověření výsledku:

1. Otevřete exportované PDF v prohlížeči, který podporuje souborové přílohy, například Adobe Acrobat Reader.
2. Otevřete panel **Attachments** prohlížeče a najděte vložený sešit.
3. Uložte přílohu a otevřete ji v Excelu k prozkoumání dat, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na stránce PDF je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje pouze PDF/A přílohy a PDF/A-3 povoluje jiné typy souborů, včetně Excel sešitů. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export do PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF včetně všech skrytých snímků.

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

Následující příklad exportuje prezentaci do PDF, které vyžaduje heslo `password` k otevření. Oprávnění přístupu umožňují tisk, včetně tisku vysoké kvality.

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

### **Detekce substitucí písem**

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), která vám umožní detekovat substituce písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypisuje varování o substituci písem do konzole. Varování je vytištěno pouze v případě, že během exportu je nahrazen nedostupný font.

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
Více informací o substituci písem najdete v článku [Font Substitution](/slides/cs/java/font-substitution/).
{{% /alert %}}

### **Zpracování písem bez dedikovaného tučného řezu**

Prezentace může použít tučné formátování textu i když její font nemá dedikovaný tučný řez. Text může stále vypadat tučně díky syntetickému tučnému formátování, které uměle ztlustí běžné glyfy. Pokud tento text vypadá příliš těžce nebo jinak neodpovídá zamýšlenému vzhledu v PDF, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) s `true`. Tato volba během exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled u některých fontů. Výchozí hodnota je `false`.

Ukázková prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním aplikovaným na stejný font, který nemá dedikovaný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou volbou. V tomto příkladu má tučný text těžší tahy při vypnuté možnosti. Při zapnuté možnosti jsou tahy lehčí; běžný text zůstává beze změny. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnutá (`false`, výchozí) | Volba zapnutá (`true`) |
|---|---|
| ![PDF s rasterizací nepodporovaného stylu písma vypnutou](unsupported-bold-disabled.png) | ![PDF s rasterizací nepodporovaného stylu písma zapnutou](unsupported-bold-enabled.png) |

V tomto příkladu zapnutí volby převede pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR a jeho hrany vypadají měkče při 800 % zoomu. Běžný text zůstává vyhledávatelný. Při vypnuté volbě zůstávají oba řetězce jako text.

Tato možnost rasterizuje text formátovaný jako tučný, pokud jeho font nemá dedikovaný tučný řez. [Font substitution](/slides/cs/java/font-substitution/) místo toho vybere jiný font, když originál není dostupný.

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

    // Odstraňte prázdný snímek, který byl vytvořen v nové prezentaci.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky přednášejícího každého snímku pod snímek. Použijte prezentaci obsahující poznámky přednášejícího, abyste viděli výsledek.

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

Aspose.Slides vám umožňuje použít postup převodu, který je v souladu s [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některých z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF na základě různých standardů souladu:

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
Aspose.Slides podporuje operace převodu PDF, což vám umožňuje konvertovat PDF soubory do populárních formátů. Můžete provést konverze [PDF do HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Note:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jednou figurou. Jednotlivé elementy cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytnut pouze pro celou figuru.

## **FAQ**

**Mohu převést více souborů PowerPoint do PDF najednou?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a programově aplikovat proces převodu.

**Je možné chránit převzatý PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) k nastavení hesla a definování oprávnění přístupu během procesu převodu.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) s `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby byly skryté snímky zahrnuty do výsledného PDF.

**Může Aspose.Slides udržet vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) a [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ve třídě [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), abyste zajistili vysoce kvalitní obrázky ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, čímž zajistíte, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Java](/slides/cs/java/)
- [API reference Aspose.Slides pro Java](https://reference.aspose.com/slides/java/)
- [Bezplatné online konvertory Aspose](https://products.aspose.app/slides/conversion)