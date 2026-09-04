---
title: Támogatott fájlformátumok
type: docs
weight: 30
url: /hu/python-java/supported-file-formats/
keywords:
- támogatott fájlformátumok
- prezentációs formátumok
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- dia képek
- Python
- Aspose.Slides for Python via Java
description: "Fedezze fel azokat a prezentációs, dokumentum, web és kép formátumokat, amelyeket az Aspose.Slides for Python via Java betölthet, importálhat, menthet és exportálhat."
---
## **Áttekintés**

Aspose.Slides for Python via Java képes PowerPoint és OpenDocument prezentációk olvasására és írására. PDF és HTML tartalmat is importál diákba, illetve prezentációkat vagy egyedi diákat exportál dokumentum, web és kép formátumokba.

Az alábbi táblázat megkülönbözteti a bemutató betöltését a tartalom importálásától és a dia renderelésétől. A szerkesztési és renderelési képességek áttekintéséért tekintse meg a [Features Overview](/slides/hu/python-java/features-overview/) oldalt.

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
- PowerPoint a Microsoft 365-höz (korábban Office 365)

## **Támogatott fájlformátumok**

A következő táblázat felsorolja a támogatott be- és kimeneti formátumokat. **Betöltés / Importálás** magában foglalja a bemutatófájlok megnyitását és a PDF vagy HTML tartalom importálását. **Mentés / Exportálás** magában foglalja a bemutatók mentését és a diák képként történő renderelését. A kötőjel azt jelzi, hogy a megfelelő művelet nem támogatott prezentációkonverzióként.

|**Formátum**|**Leírás**|**Betöltés / Importálás**|**Mentés / Exportálás**|**Megjegyzés**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 sablon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint sablon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint makróval ellátott bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint makróval ellátott bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint makróval ellátott sablon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Csomagolt OpenDocument formátum.|
|FODP|Lapos XML OpenDocument bemutató|{{< emoticons/tick >}}|{{< emoticons/tick >}}|A bemutatót egyetlen XML dokumentumként tárolja.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument bemutató sablon|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Címkézett kép formátum|—|{{< emoticons/tick >}}|Többoldalas kimenetet támogat.|
|[EMF](https://docs.fileformat.com/image/emf/)|Továbbfejlesztett metafájl|—|{{< emoticons/tick >}}|Az egyes diákat vektoros képként exportálja.|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|{{< emoticons/tick >}}|PDF oldalakat importál diáként; a bemutatókat PDF-be exportálja.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|{{< emoticons/tick >}}|Rögzített elrendezésű dokumentumkimenet.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG kép|—|{{< emoticons/tick >}}|Az egyes diákat raszteres képként rendereli.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Az egyes diákat raszteres képként rendereli.|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|{{< emoticons/tick >}}|Képkimenet.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap kép|—|{{< emoticons/tick >}}|Az egyes diákat raszteres képként rendereli.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|{{< emoticons/tick >}}|Az egyes diákat vektoros képként exportálja.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format|—|{{< emoticons/tick >}}|Flash kimenet.|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|{{< emoticons/tick >}}|HTML tartalmat importál diáként; támogatja a HTML és HTML5 exportálást.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|{{< emoticons/tick >}}|A bemutató tartalmát XAML-ként exportálja.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|A bemutató tartalmát Markdown formátumba exportálja.|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML bemutató|—|{{< emoticons/tick >}}|PowerPoint-specifikus XML kimenet, nem általános XML.|

## **Importálási és exportálási megjegyzések**

- **PDF és HTML importálás:** Használja a [SlideCollection.addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addfrompdf) vagy a [SlideCollection.addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addfromhtml) metódust a forrás tartalomból diák létrehozásához és a prezentációhoz való hozzáadásához.
- **Prezentáció kimenet:** A [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) felsorolja a rendelkezésre álló prezentáció mentési formátumokat, beleértve a külön HTML és HTML5 exportálási lehetőségeket is.
- **Kép kimenet:** Egy dia képként történő exportálása annak vizuális ábrázolását eredményezi. A bemeneti oszlop nem írja le, hogy egy kép beilleszthető‑e egy prezentációba.

## **GYIK**

**Átalakíthatok egy PPT bemutatót PPTX vagy ODP formátumba?**

Igen. A PPT támogatott bemeneti formátum, a PPTX és az ODP pedig támogatott kimeneti formátumok. A konverzió eredménye a célformátum által támogatott funkcióktól függ.

**A PDF vagy HTML importálás a forrást PowerPoint fájlként nyitja meg?**

Nem. Az importálás PDF‑oldalakat vagy HTML‑tartalmat konvertál diákká. Ezután a kapott prezentációt bármely támogatott bemutatóformátumban mentheti.

**Betölthetek egy exportált PNG vagy SVG fájlt szerkeszthetőként?**

Nem. Ezek az exportok csak a dia megjelenését tartalmazzák. A szerkesztéshez a forrásbemutatót kell megtartania.