---
title: Támogatott fájlformátumok
type: docs
weight: 106
url: /hu/java/supported-file-formats/
keywords:
- támogatott fájlformátumok
- prezentáció betöltése
- PDF importálása
- HTML importálása
- prezentáció mentése
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
- Java
- Aspose.Slides
description: "Lásd, mely fájlformátumokat tud betölteni, importálni, menteni és renderelni az Aspose.Slides for Java, és mely API olvas vagy ír ezekhez."
---
## **Áttekintés**

Az Aspose.Slides for Java megnyitja és menti a PowerPoint és OpenDocument prezentációkat. Emellett PDF és HTML tartalmat importál diákba, ment prezentációkat dokumentum-, web- és képformátumokba, valamint egyedi diák és alakzatok képként történő megjelenítését is támogatja. Ez a cikk felsorolja a támogatott formátumokat, és megnevezi az olvasást vagy írást végző API‑kat.

A szerkesztési funkciók áttekintéséhez lásd a [Funkciók áttekintése](/slides/hu/java/features-overview/).

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
- PowerPoint a Microsoft 365-hez (korábban Office 365)

{{% alert color="info" title="Note" %}}
PowerPoint 95 és korábbi verziókkal mentett prezentációk nem nyithatók meg. A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) felismeri a PowerPoint 95 fájlt és `LoadFormat.Ppt95`‑t jelent, de a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) konstruktor [PptUnsupportedFormatException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptunsupportedformatexception/)‑t dob.
{{% /alert %}}

## **Támogatott fájlformátumok**

A táblázat négy műveletet használ:

- **Load**: a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) konstruktor megnyitja a fájlt szerkeszthető prezentációként.
- **Import**: egy [SlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/) metódus a fájl tartalmából diákot hoz létre, és hozzáadja egy meglévő prezentációhoz. A Presentation konstruktor nem konvertálja ezeket a fájlokat diákra.
- **Save**: a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) a prezentációt egy [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értékkel jelölt formátumba írja. A formátumválasztás minden XAML‑t kivéve egy [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értékkel történik.
- **Render**: egy renderelő metódus diát vagy alakzatot képként rajzol meg. Csak renderelhető formátumok nem rendelkeznek SaveFormat értékekkel.

|**Formátum**|**Leírás**|**Betöltés / Importálás**|**Mentés / Renderelés**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 prezentáció|Betöltés|Mentés|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 sablon|Betöltés|Mentés|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 diavetítés|Betöltés|Mentés|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint prezentáció|Betöltés|Mentés|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint sablon|Betöltés|Mentés|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint diavetítés|Betöltés|Mentés|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Makróval bővített PowerPoint prezentáció|Betöltés|Mentés|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Makróval bővített PowerPoint sablon|Betöltés|Mentés|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Makróval bővített PowerPoint diavetítés|Betöltés|Mentés|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument prezentáció|Betöltés|Mentés|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument prezentáció|Betöltés|Mentés|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument prezentációs sablon|Betöltés|Mentés|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML prezentáció|Betöltés|Mentés|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Importálás|Mentés|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Importálás|Mentés|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Mentés|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Mentés, Renderelés|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Mentés, Renderelés|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Mentés|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Mentés|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Mentés|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Renderelés|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Renderelés|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Renderelés|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Renderelés|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Renderelés|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Betöltés és importálás**

- **Load:** Adj egy fájl elérési útvonalat vagy egy adatfolyamot a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) konstruktorhoz. A formátum a tartalom alapján kerül felderítésre; a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) lehetővé teszi jelszó stb. beállítását. A fájl megnyitása előtti ellenőrzéshez hívd a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), ami egy [LoadFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadformat/) értéket ad vissza. PowerPoint XML esetén `LoadFormat.Unknown`‑t jelent, de a konstruktor megnyitja a fájlt, és a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) ezután `SourceFormat.Xml`‑t ad. Lásd a [Open Presentations](/slides/hu/java/open-presentation/) és a [Determine the Original Presentation Format](/slides/hu/java/detect-presentation-source-format/).
- **Import:** A [SlideCollection.addFromPdf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) egy diát ad minden PDF oldalhoz a prezentáció végéhez. A [SlideCollection.addFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) HTML‑ből létrehozott diákot ad hozzá, a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) pedig megadott pozícióba illeszti be őket. A Presentation konstruktor nem importál: PDF fájl esetén [PptUnsupportedFormatException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptunsupportedformatexception/)‑t dob, HTML esetén pedig nem alakítja a jelölőnyelvet diákká. Lásd az [Import Presentations from PDF or HTML](/slides/hu/java/import-presentation/).

## **Mentés és renderelés**

- **Save:** A [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) a prezentációt egy [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) értékkel jelölt formátumba írja. Az opciós objektumot fogadó túlterhelések irányítják a kimenetet, például a [PdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/), és [GifOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/gifoptions/). A diápozíciókat (1‑től) tartalmazó tömböt fogadó változatok csak a megadott diákot írják ki; ez a PDF, XPS, TIFF, HTML, HTML5, SWF, GIF és Markdown formátumokra érvényes, de nem a prezentációs formátumokra vagy a PowerPoint XML‑re. Az XAML‑nek saját túlterhelése van, a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) amely [IXamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloptions/)‑t vár. Lásd a [Save Presentations](/slides/hu/java/save-presentation/), a [Convert Presentations](/slides/hu/java/convert-presentation/) és az [Export Presentations to XAML](/slides/hu/java/export-to-xaml/).
- **Render:** A [Slide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getImage-float-float-) és a [Shape.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage--) egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/)‑t ad vissza, amelyet az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) PNG, JPEG, BMP, GIF vagy TIFF formátumban menthetünk, az [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) értékével kiválasztva. A [Presentation.getImages](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) egyszerre az összes vagy a kiválasztott diákot rendereli. A [Slide.writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) és a [Shape.writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) SVG‑t ír, a [Slide.writeAsEmf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) pedig EMF‑et. Lásd a [Convert Presentation Slides to Images](/slides/hu/java/convert-slide/) és a [Render Presentation Slides as SVG Images](/slides/hu/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}
Az ImageFormat tartalmazza még a `Emf`, `Wmf`, `Icon`, `Exif` és `MemoryBmp` értékeket, de az IImage.save nem állítja elő ezeket a formátumokat: a mentett fájl PNG adatot tartalmaz. EMF kép egy diáról a Slide.writeAsEmf használatával szerezhető.
{{% /alert %}}

## **GYIK**

**Átkonvertálhatok PPT prezentációt PPTX vagy ODP formátumba?**

Igen. Nyisd meg a PPT fájlt a Presentation konstruktorral, majd mentsd `SaveFormat.Pptx` vagy `SaveFormat.Odp` formátumban. Lásd a [Convert PPT to PPTX](/slides/hu/java/convert-ppt-to-pptx/).

**Megnyithatok PDF vagy HTML fájlt prezentációként?**

Nem. A Presentation konstruktor PDF esetén [PptUnsupportedFormatException]‑t dob, HTML esetén pedig nem konvertálja a jelölőnyelvet diákra. Hozz létre vagy nyiss meg egy prezentációt, importáld a PDF oldalakat vagy a HTML tartalmat a fent leírt slide collection metódusokkal, majd mentsd bármely támogatott formátumba.

**Betölthetek egy exportált PNG vagy SVG képet szerkeszthető prezentációként?**

Nem. A kép kimenet csak azt rögzíti, hogy egy dia hogyan néz ki, nem a szöveget, alakzatokat vagy diagramokat. Ha később szerkeszteni szeretnéd, tartsd meg a forrás prezentációt.

**Menthetek PDF/A vagy PDF/UA dokumentumokat?**

Igen. Adj egy [PdfCompliance](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfcompliance/) értéket a [PdfOptions.setCompliance](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/#setCompliance-int-) metódusnak: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b vagy PDF/UA.

**Ellenőrizhetem, hogy egy fájl jelszóval védett‑e, mielőtt megnyitnám?**

Igen. A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) egy fájlt vizsgál meg anélkül, hogy Presentation objektumot hozna létre, a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) pedig jelzi, szükséges‑e jelszó. Lásd a [Password‑Protect Presentations](/slides/hu/java/password-protected-presentation/).