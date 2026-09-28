---
title: Támogatott fájlformátumok
type: docs
weight: 96
url: /hu/net/supported-file-formats/
keywords:
- támogatott fájlformátumok
- bemutató betöltése
- PDF importálása
- HTML importálása
- bemutató mentése
- diák renderelése
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
description: "Lásd, hogy mely fájlformátumokat tud betölteni, importálni, menteni és renderelni az Aspose.Slides for .NET, és hogy melyik API olvassa vagy írja őket."
---
## **Áttekintés**

Az Aspose.Slides for .NET megnyitja és elmenti a PowerPoint és OpenDocument bemutatókat. PDF‑et és HTML‑t is importál diákba, a bemutatókat dokumentum-, web‑ és képfájlokba menti, valamint egyedi diákot és alakzatokat képként renderel. Ez a cikk felsorolja az egyes támogatott formátumokat és megnevezi a megfelelő API‑t, amely olvas vagy ír.

Mindkét NuGet csomag, az Aspose.Slides.NET és az Aspose.Slides.NET6.CrossPlatform ugyanazokat a formátumokat támogatja; a választáshoz lásd a [Telepítés](/slides/hu/net/installation/) oldalt. A szerkesztési funkciók áttekintéséért lásd a [Funkciók áttekintése](/slides/hu/net/features-overview/).

## **Támogatott Microsoft PowerPoint verziók**

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
- PowerPoint for Microsoft 365 (korábban Office 365)

{{% alert color="info" title="Megjegyzés" %}}

A PowerPoint 95 és korábbi verziókkal mentett prezentációk nem nyithatók meg. A [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) felismeri a PowerPoint 95 fájlt és `LoadFormat.Ppt95`‑t jelent, de a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/presentation/) konstruktor [PptUnsupportedFormatException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptunsupportedformatexception/)-t dob.

{{% /alert %}}

## **Támogatott fájlformátumok**

A táblázat négy műveletet használ:

- **Betöltés**: a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/presentation/) konstruktor szerkeszthető bemutatóként nyitja meg a fájlt.
- **Importálás**: a [SlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/) metódus a fájl tartalmából diákot hoz létre, és egy meglévő bemutatóhoz adja őket. A Presentation konstruktor nem tölti be ezeket a fájlokat bemutatóként.
- **Mentés**: a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) a bemutatót egy fájlba vagy streambe írja. Minden formátum, az XAML‑től eltérően, egy [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értékkel választható.
- **Renderelés**: egy renderelési metódus diát vagy alakzatot képként rajzol. Azok a formátumok, amelyek csak renderelhetők, nem rendelkeznek SaveFormat értékkel.

|**Formátum**|**Leírás**|**Betöltés / Importálás**|**Mentés / Renderelés**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97‑2003 bemutató|Betöltés|Mentés|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97‑2003 sablon|Betöltés|Mentés|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97‑2003 diavetítés|Betöltés|Mentés|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint bemutató|Betöltés|Mentés|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint sablon|Betöltés|Mentés|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint diavetítés|Betöltés|Mentés|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint makrókkal ellátott bemutató|Betöltés|Mentés|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint makrókkal ellátott sablon|Betöltés|Mentés|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint makrókkal ellátott diavetítés|Betöltés|Mentés|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument bemutató|Betöltés|Mentés|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument bemutató|Betöltés|Mentés|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument bemutató sablon|Betöltés|Mentés|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML bemutató|Betöltés|Mentés|`SaveFormat.Xml`; az ilyen fájlok `SourceFormat.Xml`‑t jelentenek (nincs `LoadFormat` érték)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Importálás|Mentés|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Importálás|Mentés|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Mentés|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Mentés, Renderelés|`SaveFormat.Tiff`; `ImageFormat.Tiff` (egy dia)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Mentés, Renderelés|`SaveFormat.Gif` (animált, összes dia); `ImageFormat.Gif` (egy dia)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Formátum (Flash)|—|Mentés|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Mentés|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Kiterjeszthető Alkalmazás Jelölőnyelv|—|Mentés|`Presentation.Save(IXamlOptions)`, egy XAML fájl diáronként; nincs `SaveFormat` érték|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Renderelés|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG kép|—|Renderelés|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap kép|—|Renderelés|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Renderelés|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Renderelés|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Betöltés és importálás**

- **Betöltés:** Adj egy fájlútvonalat vagy streamet a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/presentation/) konstruktorának. A formátum a tartalom alapján kerül felismerésre; a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) jelszó stb. beállításait adhatod meg. Egy fájl megnyitása előtt a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) hívás jelent egy [LoadFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/loadformat/) értéket. PowerPoint XML esetén `LoadFormat.Unknown`‑t ad vissza, de a konstruktor mégis megnyitja a fájlt, és ekkor a [Presentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/) `SourceFormat.Xml`‑t ad. Lásd a [Open Presentations](/slides/hu/net/open-presentation/) és a [Determine the Original Presentation Format](/slides/hu/net/detect-presentation-source-format/) oldalakat.
- **Importálás:** A [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addfrompdf/) minden PDF‑oldalhoz egy diát ad a bemutató végéhez. A [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addfromhtml/) HTML‑ből hoz létre diát, a [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/insertfromhtml/) pedig a megadott pozícióba illeszti őket. A Presentation konstruktor nem importál: PDF‑fájl esetén [PptUnsupportedFormatException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptunsupportedformatexception/)‑t dob, HTML esetén pedig nem konvertálja a jelölőnyelvet diatartalomra. Lásd az [Import Presentations from PDF or HTML](/slides/hu/net/import-presentation/) oldalát.

## **Mentés és renderelés**

- **Mentés:** A [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) a bemutatót egy [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értéknek megfelelő formátumban írja. A különböző opciós objektumokat használó túlterhelések szabályozzák a kimenetet, például a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/), a [Html5Options](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/), a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) és a [GifOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/gifoptions/). Azok a túlterhelések, amelyek diapozíciók tömbjét (1‑től kezdődően) fogadnak, csak a megadott diákot írják; ezek támogatják a PDF‑et, XPS‑t, TIFF‑et, HTML‑t, HTML5‑t, SWF‑t, GIF‑et és a Markdown‑ot, de nem a bemutatóformátumokat vagy a PowerPoint XML‑t. Az XAML‑nek saját túlterhelése van, amely [IXamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloptions/)‑t vár. Lásd a [Save Presentations](/slides/hu/net/save-presentation/), a [Convert Presentations](/slides/hu/net/convert-presentation/) és az [Export Presentations to XAML](/slides/hu/net/export-to-xaml/) oldalakat.
- **Renderelés:** A [Slide.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) és a [Shape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot ad vissza, amelyet az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/save/) PNG, JPEG, BMP, GIF vagy TIFF formátumban menthetünk, egy [ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) érték kiválasztásával. A [Presentation.GetImages](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages/) egyszerre rendereli az összes vagy a kiválasztott diákot. A [Slide.WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/writeassvg/) és a [Shape.WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) SVG‑t ír, a [Slide.WriteAsEmf](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/writeasemf/) EMF‑et. Lásd a [Convert Presentation Slides to Images](/slides/hu/net/convert-slide/) és a [Render a Slide as an SVG Image](/slides/hu/net/render-a-slide-as-an-svg-image/) oldalakat.

{{% alert color="warning" title="Figyelmeztetés" %}}

Az ImageFormat rendelkezik `Emf`, `Wmf`, `Icon`, `Exif` és `MemoryBmp` értékekkel is, de az IImage.Save nem állítja elő ezeket a formátumokat: a létrehozott fájl PNG adatot tartalmaz. EMF kép egy diáról a Slide.WriteAsEmf használatával kapható.

{{% /alert %}}

## **GYIK**

**Átalakíthatok PPT bemutatót PPTX‑re vagy ODP‑re?**

Igen. Nyisd meg a PPT fájlt a Presentation konstruktorral, majd mentsd `SaveFormat.Pptx` vagy `SaveFormat.Odp` használatával. Lásd a [Convert PPT to PPTX](/slides/hu/net/convert-ppt-to-pptx/) oldalt.

**Megnyithatok PDF‑et vagy HTML‑t bemutatóként?**

Nem. Hozz létre vagy nyiss meg egy bemutatót, importáld a PDF‑oldalakat vagy a HTML‑tartalmat a fent leírt slide‑gyűjtemény metódusokkal, majd mentés után bármely támogatott formátumba exportálhatod.

**Betölthetek egy exportált PNG‑ vagy SVG‑képet szerkeszthető bemutatóként?**

Nem. A kép csak a dia megjelenését rögzíti, nem a szöveget, alakzatokat vagy diagramokat. Ha később szerkeszteni akarod, tartsd meg az eredeti bemutatót.

**Menthetek PDF/A vagy PDF/UA dokumentumot?**

Igen. Állítsd be a [PdfOptions.Compliance](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/compliance/)‑t egy [PdfCompliance](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfcompliance/) értékre: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b vagy PDF/UA.

**Ellenőrizhetem, hogy egy fájl jelszóval védett‑e, mielőtt megnyitnám?**

Igen. A [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) fájlt vizsgál meg anélkül, hogy Presentation objektumot hozna létre, és az [IsPasswordProtected](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/ispasswordprotected/) tulajdonsága jelzi, szükséges‑e a jelszó. Lásd a [Password‑Protect Presentations](/slides/hu/net/password-protected-presentation/) oldalát.

**A két NuGet csomag különböző formátumokat támogat?**

Nem. Az Aspose.Slides.NET és az Aspose.Slides.NET6.CrossPlatform ugyanazokat a LoadFormat és SaveFormat értékeket, valamint ugyanazt az import‑ és renderelési módszertárat használja. Különbség csupán a futtatási platformokban és azok követelményeiben van; lásd a [Telepítés](/slides/hu/net/installation/) oldalt.