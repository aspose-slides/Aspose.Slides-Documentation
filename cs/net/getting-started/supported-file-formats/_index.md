---
title: Podporované formáty souborů
type: docs
weight: 96
url: /cs/net/supported-file-formats/
keywords:
- podporované formáty souborů
- načíst prezentaci
- importovat PDF
- importovat HTML
- uložit prezentaci
- renderovat snímky
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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, které souborové formáty Aspose.Slides pro .NET lze načíst, importovat, uložit a renderovat, a které API je čte nebo zapisuje."
---
## **Přehled**

Aspose.Slides for .NET otevírá a ukládá prezentace PowerPoint a OpenDocument. Také importuje obsah PDF a HTML do snímků, ukládá prezentace do dokumentových, webových a obrazových formátů a vykresluje jednotlivé snímky a tvary jako obrázky. Tento článek uvádí všechny podporované formáty a uvádí API, které je čte nebo zapisuje.

Oba balíčky NuGet, Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform, podporují stejné formáty; viz [Instalace](/slides/cs/net/installation/) pro výběr mezi nimi. Pro přehled editačních funkcí viz [Přehled funkcí](/slides/cs/net/features-overview/).

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
- Microsoft PowerPoint pro Mac
- PowerPoint pro Microsoft 365 (dříve Office 365)

{{% alert color="info" title="Note" %}}

Prezentace uložené pomocí PowerPointu 95 a starších verzí nelze otevřít. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) rozpozná soubor PowerPoint 95 a vrátí `LoadFormat.Ppt95`, ale konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) pro něj vyhodí [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/).

{{% /alert %}}

## **Podporované formáty souborů**

Tabulka používá čtyři operace:

- **Načíst**: konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) otevře soubor jako editovatelnou prezentaci.
- **Importovat**: metoda [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) vytvoří snímky z obsahu souboru a přidá je do existující prezentace. Konstruktor Presentation tyto soubory jako prezentace nenačítá.
- **Uložit**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) zapíše prezentaci do souboru nebo proudu. Každý formát kromě XAML se vybírá pomocí hodnoty [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).
- **Renderovat**: metoda pro vykreslení vykreslí snímek nebo tvar jako obrázek. Formáty, které jsou jen renderovány, nejsou hodnotami SaveFormat.

|**Formát**|**Popis**|**Načíst / Importovat**|**Uložit / Renderovat**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentace PowerPoint 97‑2003|Načíst|Uložit|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Šablona PowerPoint 97‑2003|Načíst|Uložit|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Prezentace PowerPoint 97‑2003 ve formě slideshow|Načíst|Uložit|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentace PowerPoint|Načíst|Uložit|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Šablona PowerPoint|Načíst|Uložit|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Slideshow PowerPoint|Načíst|Uložit|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Makro‑povolena prezentace PowerPoint|Načíst|Uložit|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Makro‑povolena šablona PowerPoint|Načíst|Uložit|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Makro‑povolena slideshow PowerPoint|Načíst|Uložit|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument prezentace|Načíst|Uložit|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument prezentace|Načíst|Uložit|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument šablona prezentace|Načíst|Uložit|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML prezentace|Načíst|Uložit|`SaveFormat.Xml`; načtené soubory vracejí `SourceFormat.Xml` (neexistuje hodnota `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Formát přenosného dokumentu|Importovat|Uložit|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertextový značkovací jazyk|Importovat|Uložit|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specifikace XML papíru|—|Uložit|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formát souboru s obrázkem (TIFF)|—|Uložit, Renderovat|`SaveFormat.Tiff`; `ImageFormat.Tiff` (jeden snímek)|
|[GIF](https://docs.fileformat.com/image/gif/)|Formát pro výměnu grafiky (GIF)|—|Uložit, Renderovat|`SaveFormat.Gif` (animovaný, všechny snímky); `ImageFormat.Gif` (jeden snímek)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Uložit|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Uložit|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Rozšiřitelný značkovací jazyk aplikací (XAML)|—|Uložit|`Presentation.Save(IXamlOptions)`, jeden XAML soubor na snímek; nehodnota `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Přenosná síťová grafika (PNG)|—|Renderovat|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG obrázek|—|Renderovat|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap obrázek|—|Renderovat|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Renderovat|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Renderovat|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Načtení a import**

- **Načíst:** Předávejte cestu k souboru nebo proud konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Formát se detekuje z obsahu; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) umožňuje nastavit například heslo. Pro kontrolu souboru před jeho otevřením zavolejte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/), který vrátí hodnotu [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). Pro PowerPoint XML vrací `LoadFormat.Unknown`, ale konstruktor takový soubor otevře a [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) pak vrátí `SourceFormat.Xml`. Viz [Otevření prezentací](/slides/cs/net/open-presentation/) a [Zjištění původního formátu prezentace](/slides/cs/net/detect-presentation-source-format/).
- **Importovat:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) přidá jeden snímek na každou stránku PDF na konec prezentace. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) přidá snímky vytvořené z HTML a [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) je vloží na zadanou pozici. Konstruktor Presentation neimportuje: pro PDF soubor vyhodí [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) a neprovádí konverzi HTML značek na obsah snímků. Viz [Import prezentací z PDF nebo HTML](/slides/cs/net/import-presentation/).

## **Uložení a renderování**

- **Uložit:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) zapíše prezentaci ve formátu určeném hodnotou [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Přetížení, která také přijímají objekt možností, řídí výstup, například [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), a [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Přetížení, která přijímají pole pozic snímků (číslovaných od 1), zapíšou pouze vybrané snímky; podporují PDF, XPS, TIFF, HTML, HTML5, SWF, GIF a Markdown, ale ne formáty prezentací ani PowerPoint XML. XAML má vlastní přetížení, které přijímá [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). Viz [Uložení prezentací](/slides/cs/net/save-presentation/), [Konverze prezentací](/slides/cs/net/convert-presentation/), a [Export prezentací do XAML](/slides/cs/net/export-to-xaml/).
- **Renderovat:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) a [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) vrací [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) zapisuje jako PNG, JPEG, BMP, GIF nebo TIFF podle hodnoty [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) renderuje všechny snímky nebo vybrané snímky najednou. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) a [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) zapisují SVG a [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) zapisuje EMF. Viz [Konverze snímků prezentace na obrázky](/slides/cs/net/convert-slide/) a [Renderování snímku jako SVG obrázku](/slides/cs/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat také obsahuje hodnoty `Emf`, `Wmf`, `Icon`, `Exif` a `MemoryBmp`, ale IImage.Save tyto formáty nevytváří: soubor, který zapíše, obsahuje PNG data. Pro získání EMF obrázku snímku použijte Slide.WriteAsEmf.

{{% /alert %}}

## **Často kladené otázky**

**Mohu převést prezentaci PPT na PPTX nebo ODP?**

Ano. Otevřete soubor PPT pomocí konstruktoru Presentation a uložte jej s `SaveFormat.Pptx` nebo `SaveFormat.Odp`. Viz [Převod PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/).

**Mohu otevřít PDF nebo HTML soubor jako prezentaci?**

Ne. Vytvořte nebo otevřete prezentaci, importujte stránky PDF nebo obsah HTML pomocí metod kolekce snímků popsaných výše a poté ji uložte v libovolném podporovaném formátu.

**Mohu načíst exportovaný PNG nebo SVG obrázek jako editovatelnou prezentaci?**

Ne. Výstupní obrázek zachycuje pouze vzhled snímku, ne jeho text, tvary ani grafy. Uchovejte původní prezentaci, pokud ji budete potřebovat později upravit.

**Mohu uložit dokumenty PDF/A nebo PDF/UA?**

Ano. Nastavte [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) na hodnotu [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b nebo PDF/UA.

**Mohu před otevřením souboru zjistit, zda je chráněn heslem?**

Ano. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) prozkoumá soubor bez vytváření objektu Presentation a jeho vlastnost [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) uvádí, zda je potřeba heslo. Viz [Prezentace chráněné heslem](/slides/cs/net/password-protected-presentation/).

**Podporují oba balíčky NuGet různé formáty?**

Ne. Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform mají stejné hodnoty LoadFormat a SaveFormat a stejné metody pro import a renderování. Liší se pouze platformami, na kterých běží, a požadavky těchto platforem; viz [Instalace](/slides/cs/net/installation/).