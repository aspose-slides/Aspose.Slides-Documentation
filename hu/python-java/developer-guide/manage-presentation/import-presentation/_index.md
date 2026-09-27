---
title: Prezentációk importálása PDF-ből vagy HTML-ből Python via Java
linktitle: Prezentáció importálása
type: docs
weight: 60
url: /hu/python-java/import-presentation/
keywords:
- prezentáció importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF prezentációvá alakítása
- PDF PPT-re
- PDF PPTX-re
- PDF ODP-re
- HTML prezentációvá alakítása
- HTML PPT-re
- HTML PPTX-re
- HTML ODP-re
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet PDF és HTML tartalmat PowerPoint prezentációkba importálni Python via Java környezetben az Aspose.Slides segítségével, és az eredményeket PPTX fájlokként menteni."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java a PDF oldalakat vagy HTML tartalmat Microsoft PowerPoint nélkül PowerPoint diákra konvertálhatja. A [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) osztály a [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) és a [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) metódusokat biztosítja az importált tartalom bemutatóhoz való hozzáfűzéshez.

További vezérléshez az HTML elhelyezése felett a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) beszúrhatja a generált diákat egy gyűjtemény indexén vagy elkezdheti kitölteni a rendelkezésre álló helyet egy meglévő dián. A hosszú HTML automatikusan oldalakra van bontva további diákra, a forrás megadható karakterláncként vagy folyamként, és a külső eszközök betölthetők az [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) segítségével egy alap URI-val. A visszaadott [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) tömb az érintett és újonnan létrehozott diákat azonosítja.

## **Importálás PDF-ből**

Egy PDF dokumentum PowerPoint bemutatóvá konvertálásához importálja annak tartalmát a diagyűjteménybe, és mentse az eredményt PPTX fájlként.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Hozzon létre egy új [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot.  
2. Hívja meg a [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) metódust a PDF fájl útvonalával.  
3. Hívja meg a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) használatával a bemutató PPTX fájlba írásához.

A következő Python példa importál egy PDF dokumentumot, és elmenti a generált diákat PowerPoint bemutatóként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alapértelmezett üres dia a bemutatóban marad, mivel az importálás diák hozzáfűzésével történik. Ha csak az importált oldalakat szeretné megtartani, törölje a diagyűjteményt a [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) metódussal az importálás előtt.

A [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) metódus visszaadja a hozzáadott diákat, ami hasznos, ha csak az importált diákat kell feldolgozni.

{{% alert title="Tip" color="success" %}}
Próbálja ki az ingyenes [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) webalkalmazást, hogy lássa a konverziós munkafolyamatot működés közben.
{{% /alert %}}

## **Importálás HTML-ből**

Az Aspose.Slides also képes diák létrehozására HTML dokumentumból. A forrást meg lehet adni HTML szövegként vagy folyamként. A következő lépések egy fájlfolyamot használnak:

1. Hozzon létre egy új [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) objektumot.  
2. Nyissa meg a HTML fájlt olvasásra, és adja át a folyamot a [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) metódusnak.  
3. Hívja meg a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) használatával az eredmény PPTX fájlba írásához.

A következő Python példa importál egy HTML dokumentumot, és elmenti a generált diákat PowerPoint bemutatóként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML tartalom beszúrása**

Használja a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) metódust, ha a HTML által generált diákat egy adott pozícióba kell helyezni, ahelyett, hogy hozzáfűznék őket. Az index nullától kezdődik, és az importálás kiinduló helyét jelöli.

Az `useSlideWithIndexAsStart` argumentum szabályozza, hogyan használja az importáló ezt a pozíciót:

- Ha `False`, az importáló új diákat hoz létre a megadott indexnél, és eltolja a mögötte lévő diákat.  
- Ha `True`, az importáló a már létező dián ezen az indexen elérhető helyen kezdi meg a tartalom elhelyezését. Ha a HTML nem fér el, az Aspose.Slides automatikusan oldalakra bontja, és közvetlenül a kezdő dia után szúr be további diákat.

A [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) visszaad egy [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objektumok tömbjét. Ha a beszúrás új diákon kezdődik, minden visszaadott elem újnak jön létre. Ha egy meglévő dia van használva kiindulási pontként, a tömb tartalmazza az érintett diát, majd az esetleges új túlcsorduló diákat. Ennek a tömbnek a vizsgálata helyettesítheti a befolyó tartomány kiszámítását a bemutató diák számából.

### **HTML beszúrása új diákba**

A következő példa HTML-t ad meg karakterláncként, és a generált diákat a gyűjtemény `1` indexén szúrja be. A `False` átadása változatlanul hagyja a meglévő diákat, csak eltolja őket a hely biztosításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kezdés meglévő dián**

A következő példa a HTML-t folyamként adja meg. Megtartja a fejléct alakzatot a meglévő sablon dián, a lefoglalt terület alá kezdi az importálást, és a hosszú tartalmat további diákkal folytatja.

A HTML tartalmaz egy relatív kép URL-t is. Az [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) lekéri az erőforrást, míg az alap URI megmondja az importálónak, hogyan oldja fel a `images/logo.png` hivatkozást. Ebben a példában a fájl a `html-assets/images/logo.png` helyen várható.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Az egyenlő módon korlátlan külső erőforrás feloldó képes a HTML-ben hivatkozott helyi vagy hálózati erőforrások olvasására. Bizalmatlan bemenet esetén az importálás előtt ellenőrizze és tisztítsa meg az erőforrás URL-eket egy engedélyezett sémák, könyvtárak és gazdagépek fehérlistájával.
{{% /alert %}}

## **GYIK**

**Az Aspose.Slides képes táblázatokat felismerni PDF importálásakor?**

Igen. Hozzon létre egy [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/) objektumot, hívja meg a [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) metódust `True` értékkel, és adja át a beállításokat a [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) metódusnak. A táblázatfelismerés minősége a forrás PDF szerkezetétől és összetettségétől függ.

{{% alert title="Note" color="info" %}}
HTML importálása után a diák exportálhatók [images](/slides/hu/python-java/convert-powerpoint-to-png/), [TIFF](/slides/hu/python-java/convert-powerpoint-to-tiff/), vagy [SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) formátumokba.
{{% /alert %}}