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
- příloha
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitních, prohledávatelných PDF v Javě pomocí Aspose.Slides pro Android, s rychlými příklady kódu a pokročilými možnostmi převodu."
---
## **Přehled**

Převod prezentací PowerPoint (PPT, PPTX, ODP atd.) do formátu PDF na Androidu nabízí několik výhod, včetně kompatibility napříč různými zařízeními a zachování rozvržení a formátování vaší prezentace. Tento průvodce ukazuje, jak převést prezentace do PDF dokumentů, použít různé možnosti pro řízení kvality obrázků, zahrnout skryté snímky, zabezpečit PDF soubory heslem, detekovat náhrady písem, vybrat konkrétní snímky pro převod a aplikovat standardy souladu na výstupní dokumenty.

## **Převody PowerPoint do PDF**

Pomocí Aspose.Slides můžete převádět prezentace v následujících formátech do PDF:

* **PPT**
* **PPTX**
* **ODP**

Pro převod prezentace do PDF předáte název souboru jako argument do třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a poté uložíte prezentaci jako PDF pomocí metody [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Třída [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) poskytuje metodu [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), která se typicky používá k převodu prezentace do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Android via Java vkládá informace o svém API a číslo verze do výstupních dokumentů. Například při převodu prezentace do PDF Aspose.Slides vyplní pole Application řetězcem "*Aspose.Slides*" a pole PDF Producer hodnotou ve formátu "*Aspose.Slides v XX.XX*". **Poznámka** že nemůžete instruovat Aspose.Slides, aby tuto informaci ve výstupních dokumentech změnil nebo odstranil.
{{% /alert %}}

Aspose.Slides vám umožňuje převést:

* Celé prezentace do PDF
* Konkrétní snímky z prezentace do PDF

Aspose.Slides exportuje prezentace do PDF a zajišťuje, že výsledné PDF úzce odpovídají originálním prezentacím. Prvky a atributy jsou při převodu vykresleny přesně, včetně:

* Obrázky
* Textová pole a tvary
* Formátování textu
* Formátování odstavců
* Hyperlinky
* Záhlaví a zápatí
* Odrážky
* Tabulky

## **Převod PowerPoint do PDF**

Standardní proces převodu PowerPoint do PDF používá výchozí možnosti. V tomto případě se Aspose.Slides pokusí převést zadanou prezentaci do PDF s optimálními nastaveními při maximální úrovni kvality.

Následující příklad načte prezentaci a uloží všechny viditelné snímky do PDF pomocí výchozích nastavení exportu.

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
Aspose nabízí bezplatný online [**PowerPoint do PDF převodník**](https://products.aspose.app/slides/conversion/ppt-to-pdf), který ukazuje proces převodu prezentace do PDF. Můžete spustit test s tímto převodníkem pro živou implementaci postupu popsaného zde.
{{% /alert %}}

## **Převod PowerPoint do PDF s možnostmi**

Aspose.Slides poskytuje vlastní možnosti — vlastnosti ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), které vám umožní přizpůsobit výsledné PDF, uzamknout PDF heslem nebo specifikovat, jak má probíhat proces převodu.

### **Převod PowerPoint do PDF s vlastními možnostmi**

Pomocí vlastních možností převodu můžete definovat preferované nastavení kvality rastrových obrázků, určit, jak mají být zpracovávány metafily, nastavit úroveň komprese textu, konfigurovat DPI pro obrázky a další.

Následující příklad exportuje prezentaci do PDF 1.5 s JPEG kvalitou nastavenou na 90, rozlišením obrázků 300 DPI, metafily uloženými jako PNG a kompresí textu Flate.

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

Když prezentace obsahuje mnoho fotografií nebo snímků obrazovky, zmenšení velikosti exportovaného PDF může usnadnit odesílání e-mailem nebo stahování. Zavolejte [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) s `true` pro automatický výběr nejvhodnějšího kompresního algoritmu pro každý obrázek během exportu PDF.

Následující příklad načte existující prezentaci, povolí automatický výběr komprese obrázků a uloží ji jako PDF dokument. Všechna ostatní nastavení exportu PDF si ponechají své výchozí hodnoty.

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

Tato možnost vybírá kompresní algoritmus pro každý obrázek. Snížením hodnoty předané metodě [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) se sníží kvalita JPEG obrázku, zatímco snížením hodnoty předané metodě [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) se povolí downsampling obrázků na nižší rozlišení, což může snížit detaily. Povolování automatického výběru komprese samo o sobě nesnižuje žádné z těchto nastavení.

Výběr kompresních algoritmů pro obrázky vyžaduje dodatečný čas zpracování a paměť. Snížení velikosti závisí na obrázcích v prezentaci a nastaveních exportu; pevné snížení není u každé prezentace zaručeno.

### **Zachovat vložené OLE soubory jako přílohy PDF**

Pokud prezentace obsahuje vložený sešit Excel, můžete chtít, aby příjemci PDF měli přístup k datům sešitu i k zobrazení snímků. Zavolejte [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) s `true` pro zachování vložených OLE souborů jako příloh ve výsledném PDF.

Výchozí hodnota je `false`: náhledový obrázek nebo ikona OLE objektu je vykreslena na PDF stránce, ale vložený soubor není zahrnut jako příloha. Nastavením možnosti na `true` se navíc zahrnou data souboru. Náhled zůstává vizuální reprezentací; příloha umožňuje příjemcům otevřít nebo uložit vložený soubor samostatně. OLE objekt se nestane interaktivním listem Excelu na PDF stránce.

Následující příklad načte prezentaci, která již obsahuje vložený sešit Excel, a exportuje ji do PDF s přiloženým sešitem:

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
3. Uložte přílohu a otevřete ji v Excelu, abyste zkontrolovali data, nebo ji otevřete přímo, pokud to prohlížeč umožňuje. Náhled na PDF stránce je oddělený od přílohy.

{{% alert color="info" title="Note" %}}
Standardy PDF/A ukládají omezení na přílohy: PDF/A-1 zakazuje vložené soubory, PDF/A-2 povoluje jen přílohy PDF/A a PDF/A-3 povoluje další typy souborů, včetně sešitů Excel. Jedná se o požadavky standardů, nikoli omezení specifická pro Aspose.Slides. Tento příklad používá výchozí nastavení souladu PDF a neukazuje export PDF/A.
{{% /alert %}}

### **Převod PowerPoint do PDF se skrytými snímky**

Pokud prezentace obsahuje skryté snímky, můžete použít metodu [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) ze třídy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly jako stránky ve výsledném PDF.

Následující příklad exportuje prezentaci do PDF a zahrne všechny skryté snímky.

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

Následující příklad exportuje prezentaci do PDF, který vyžaduje heslo `password` k otevření. Přístupová oprávnění umožňují tisk, včetně tisku vysoké kvality.

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

Aspose.Slides poskytuje metodu [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), která vám umožní detekovat náhrady písem během procesu převodu prezentace do PDF.

Následující příklad exportuje prezentaci do PDF a vypíše varování o náhradě písem do konzole. Varování je vytištěno pouze tehdy, když je během exportu nahrazen nedostupný font.

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
Pro více informací o náhradě písem navštivte článek [Náhrada písem](/slides/cs/androidjava/font-substitution/).
{{% /alert %}}

### **Zpracování písem bez samostatného tučného řezu**

Prezentace může použít tučné formátování textu i když dané písmo nemá samostatný tučný řez. Text se může stále jevit jako tučný pomocí syntetického zesílení, které uměle zahušťuje běžné glyfy. Když takový text vypadá příliš těžce nebo se liší od zamýšleného vzhledu v PDF, zkuste zavolat [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) s `true`. Tato možnost během exportu PDF vykreslí dotčený text jako bitmapu a může zlepšit jeho vzhled pro určitá písma. Výchozí hodnota je `false`.

Vzorová prezentace obsahuje dvě textová pole: jedno s běžným textem a druhé s tučným formátováním aplikovaným na stejné písmo, které nemá samostatný tučný řez. Následující příklad načte prezentaci, povolí rasterizaci nepodporovaných stylů písma a exportuje ji do PDF:

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

Následující náhledy ukazují výstup s vypnutou a zapnutou možností. V tomto příkladu má tučný text těžší tahy při vypnuté možnosti. Při zapnuté možnosti jsou tahy lehčí; běžný text zůstává nezměněn. Porovnejte výsledky před výběrem nastavení pro vaši prezentaci.

| Volba vypnuta (`false`, výchozí) | Volba zapnuta (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

V tomto příkladu povolení možnosti převádí pouze tučný text na bitmapu: nelze jej vybrat, kopírovat ani vyhledávat jako text bez OCR, a jeho hrany jsou při 800 % zvětšení měkčí. Běžný text zůstává vyhledávatelný. Při vypnuté možnosti zůstávají oba řetězce textem.

Tato možnost rasterizuje text formátovaný jako tučný, když jeho písmo nemá samostatný tučný řez. [Náhrada písem](/slides/cs/androidjava/font-substitution/) místo toho vybere jiné písmo, pokud není originál dostupný.

## **Převod vybraných snímků z PowerPoint do PDF**

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

## **Převod PowerPoint do PDF s vlastní velikostí snímku**

Následující příklad zkopíruje první snímek z prezentace do nové prezentace s velikostí snímku 612 × 792 bodů (8,5 × 11 palců). Obsah snímku se přizpůsobí a exportuje jediný snímek do PDF.

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

## **Převod PowerPoint do PDF v zobrazení poznámek ke snímkům**

Následující příklad exportuje prezentaci do PDF a umístí poznámky řečníka každého snímku pod snímek. Použijte prezentaci obsahující poznámky řečníka, abyste viděli výsledek.

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

## **Přístupnost a standardy souladu pro PDF**

Aspose.Slides vám umožňuje použít postup převodu, který splňuje [Směrnice o přístupnosti webového obsahu (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Můžete exportovat dokument PowerPoint do PDF pomocí některého z těchto standardů souladu: **PDF/A1a**, **PDF/A1b** a **PDF/UA**.

Tento kód demonstruje proces převodu PowerPoint do PDF, který vytváří několik PDF založených na různých standardech souladu:

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
Aspose.Slides podporuje operace převodu PDF, které vám umožňují převést soubory PDF do populárních formátů. Můžete provést převody [PDF do HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF do obrázku](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), a [PDF do PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Další převody PDF do specializovaných formátů — [PDF do SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), a [PDF do XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — jsou také podporovány.
{{% /alert %}}

> **Poznámka:** Při exportu do PDF/UA Aspose.Slides zachází s komplexní grafikou, jako jsou SmartArt, grafy a vzorce, jako s jedním objektem. Jednotlivé prvky cesty nejsou zachovány jako samostatný obsah a mohou být označeny jako artefakty; alternativní text je poskytován pouze pro celý objekt.

## **Často kladené otázky**

**Mohu hromadně převést více souborů PowerPoint do PDF?**

Ano, Aspose.Slides podporuje hromadný převod více souborů PPT nebo PPTX do PDF. Můžete iterovat přes své soubory a aplikovat proces převodu programově.

**Je možné zabezpečit převodní PDF heslem?**

Ano. Použijte třídu [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), abyste během procesu převodu nastavili heslo a definovali přístupová oprávnění.

**Jak zahrnout skryté snímky do PDF?**

Zavolejte [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) s `true` ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby se skryté snímky zahrnuly do výsledného PDF.

**Může Aspose.Slides zachovat vysokou kvalitu obrázků v PDF?**

Ano, můžete řídit kvalitu obrázků pomocí metod jako [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) a [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) ve třídě [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), abyste zajistili vysokou kvalitu obrázků ve vašem PDF.

**Podporuje Aspose.Slides standardy souladu PDF/A?**

Ano, Aspose.Slides vám umožňuje exportovat PDF, která splňují [různé standardy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), včetně PDF/A1a, PDF/A1b a PDF/UA, což zajišťuje, že vaše dokumenty splňují požadavky na přístupnost a archivaci.

## **Další zdroje**

- [Dokumentace Aspose.Slides pro Android via Java](/slides/cs/androidjava/)
- [API reference Aspose.Slides pro Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Bezplatné online převodníky Aspose](https://products.aspose.app/slides/conversion)