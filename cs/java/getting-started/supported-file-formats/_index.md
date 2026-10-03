---
title: Podporované formáty souborů
type: docs
weight: 106
url: /cs/java/supported-file-formats/
keywords:
- podporované formáty souborů
- načíst prezentaci
- importovat PDF
- importovat HTML
- uložit prezentaci
- vykreslit snímky
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Zobrazíte, které souborové formáty Aspose.Slides pro Javu lze načíst, importovat, uložit a vykreslit, a které API každý z nich čte nebo zapisuje."
---
## **Přehled**

Aspose.Slides for Java otevírá a ukládá prezentace PowerPoint a OpenDocument. Také importuje obsah PDF a HTML do snímků, ukládá prezentace do dokumentových, webových a obrazových formátů a vykresluje jednotlivé snímky a tvary jako obrázky. Tento článek uvádí každý podporovaný formát a uvádí API, které jej čte nebo zapisuje.

Pro přehled funkcí úprav viz [Přehled funkcí](/slides/cs/java/features-overview/).

## **Podporované verze Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

Prezentace uložené v PowerPoint 95 a starších verzích nelze otevřít. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) rozpozná soubor PowerPoint 95 a hlásí `LoadFormat.Ppt95`, ale konstruktor [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) vyhodí [PptUnsupportedFormatException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptunsupportedformatexception/) pro něj.

{{% /alert %}}

## **Podporované souborové formáty**

Tabulka používá čtyři operace:

- **Load**: konstruktor [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) otevírá soubor jako editovatelnou prezentaci.
- **Import**: metoda [SlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/) vytváří snímky z obsahu souboru a přidává je do existující prezentace. Konstruktor Presentation tyto soubory na snímky nepřevádí.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) zapisuje prezentaci do souboru nebo proudu. Každý formát kromě XAML se volí pomocí hodnoty [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/).
- **Render**: metoda vykreslení nakreslí snímek nebo tvar jako obrázek. Formáty, které jsou jen vykreslovány, nemají hodnotu SaveFormat.

|**Formát**|**Popis**|**Načtení / Import**|**Uložení / Vykreslení**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentace PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Šablona PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Ukázka snímků PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentace PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Šablona PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Ukázka snímků PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Prezentace PowerPoint s podporou maker|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Šablona PowerPoint s podporou maker|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Ukázka snímků PowerPoint s podporou maker|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Prezentace OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Plochá XML OpenDocument prezentace|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Šablona OpenDocument prezentace|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Prezentace PowerPoint XML|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Formát přenosného dokumentu|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertextový značkovací jazyk|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specifikace XML papíru|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formát obrázků TIFF|—|Save, Render|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formát výměny grafiky GIF|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Malý webový formát (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Rozšiřitelný jazyk značkování aplikací|—|Save|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Přenosná síťová grafika|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Obrázek JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmapový obrázek|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Rozšířený metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Škálovatelná vektorová grafika|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Načtení a import**

- **Load:** Předávejte cestu k souboru nebo stream konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Formát se zjistí z obsahu; [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) poskytuje nastavení jako heslo. Pro kontrolu souboru před otevřením zavolejte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), který vrátí hodnotu [LoadFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadformat/). Pro PowerPoint XML vrací `LoadFormat.Unknown`, ale konstruktor takový soubor otevře a [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--) pak vrátí `SourceFormat.Xml`. Viz [Open Presentations](/slides/cs/java/open-presentation/) a [Determine the Original Presentation Format](/slides/cs/java/detect-presentation-source-format/).
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) přidá jeden snímek na každou stránku PDF na konec prezentace. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) přidá snímky vytvořené z HTML a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) je vloží na zvolenou pozici. Konstruktor Presentation neimportuje: pro PDF vyhodí [PptUnsupportedFormatException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptunsupportedformatexception/) a neprovádí konverzi HTML do obsahu snímků. Viz [Import Presentations from PDF or HTML](/slides/cs/java/import-presentation/).

## **Uložení a vykreslení**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) zapisuje prezentaci ve formátu odpovídajícím hodnotě [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/). Přetížení, která přijímají také objekt možností, řídí výstup, např. [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/), a [GifOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/gifoptions/). Přetížení, která přijímají pole pozic snímků (číslovaných od 1), zapisují jen uvedené snímky; podporují PDF, XPS, TIFF, HTML, HTML5, SWF, GIF a Markdown, ale ne formáty prezentací ani PowerPoint XML. XAML má vlastní přetížení, [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), které přijímá [IXamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ixamloptions/). Viz [Save Presentations](/slides/cs/java/save-presentation/), [Convert Presentations](/slides/cs/java/convert-presentation/) a [Export Presentations to XAML](/slides/cs/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-float-float-) a [Shape.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage--) vrací [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/), a [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ji zapisuje jako PNG, JPEG, BMP, GIF nebo TIFF, vybraný hodnotou [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) vykreslí všechny nebo vybrané snímky najednou. [Slide.writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) a [Shape.writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) zapisují SVG a [Slide.writeAsEmf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) zapisuje EMF. Viz [Convert Presentation Slides to Images](/slides/cs/java/convert-slide/) a [Render Presentation Slides as SVG Images](/slides/cs/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat také obsahuje hodnoty `Emf`, `Wmf`, `Icon`, `Exif` a `MemoryBmp`, ale IImage.save je nevytvoří: zápisovaný soubor obsahuje data PNG. Pro získání EMF obrázku snímku použijte Slide.writeAsEmf.

{{% /alert %}}

## **Často kladené otázky**

**Mohu převést prezentaci PPT na PPTX nebo ODP?**

Ano. Otevřete soubor PPT pomocí konstruktoru Presentation a uložte jej s `SaveFormat.Pptx` nebo `SaveFormat.Odp`. Viz [Převést PPT na PPTX](/slides/cs/java/convert-ppt-to-pptx/).

**Mohu otevřít soubor PDF nebo HTML jako prezentaci?**

Ne. Konstruktor Presentation vyhodí PptUnsupportedFormatException pro PDF a neprovádí konverzi HTML do snímků. Vytvořte nebo otevřete prezentaci, importujte PDF stránky nebo HTML obsah pomocí metod kolekce snímků uvedených výše a poté ji uložte v libovolném podporovaném formátu.

**Mohu načíst exportovaný PNG nebo SVG obrázek jako editovatelnou prezentaci?**

Ne. Výstupní obrázek zachycuje pouze vzhled snímku, ne jeho text, tvary ani grafy. Pokud potřebujete později upravovat, uchovejte původní prezentaci.

**Mohu ukládat dokumenty PDF/A nebo PDF/UA?**

Ano. Předávejte hodnotu [PdfCompliance](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfcompliance/) metodě [PdfOptions.setCompliance](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b nebo PDF/UA.

**Mohu zkontrolovat, zda je soubor chráněn heslem, před jeho otevřením?**

Ano. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) prověří soubor bez vytvoření objektu Presentation a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) uvádí, zda je potřeba heslo. Viz [Password-Protect Presentations](/slides/cs/java/password-protected-presentation/).