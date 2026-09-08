---
title: Prezentációk importálása PDF vagy HTML-ből Pythonon keresztül Java-val
linktitle: Prezentáció importálása
type: docs
weight: 60
url: /hu/python-java/import-presentation/
keywords:
  - prezentáció importálása
  - dia importálása
  - PDF importálása
  - HTML importálása
  - PDF prezentációvá
  - PDF PPT-vé
  - PDF PPTX-vé
  - PDF ODP-vé
  - HTML prezentációvá
  - HTML PPT-vé
  - HTML PPTX-vé
  - HTML ODP-vé
  - PowerPoint
  - OpenDocument
  - Python
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan lehet PDF és HTML tartalmat importálni PowerPoint prezentációkba Pythonon keresztül Java-val az Aspose.Slides segítségével, és menteni az eredményeket PPTX fájlokként."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java képes PDF oldalak vagy HTML tartalmat PowerPoint diákra alakítani a Microsoft PowerPoint nélkül. A [SlideCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/) osztály biztosítja a [addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromPdf) és a [addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromHtml) metódusokat az importált tartalom bemutatóhoz való hozzáadásához.

Ha nagyobb ellenőrzésre van szükség a HTML elhelyezése felett, a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertFromHtml) be tudja illeszteni a generált diákat egy gyűjtemény indexén, vagy elkezdheti kitölteni a rendelkezésre álló helyet egy meglévő dián. A hosszú HTML automatikusan több diára kerül felosztásra, a forrás lehet karakterlánc vagy folyam, és külső erőforrások betölthetők az [ExternalResourceResolver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/externalresourceresolver/) segítségével egy alap‑URI-val. A visszaadott [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) tömb az érintett és az újonnan létrehozott diákat azonosítja.

## **Importálás PDF-ből**

A PDF dokumentumot PowerPoint bemutatóvá konvertáláshoz importálja a tartalmát a diagyűjteménybe és mentse az eredményt PPTX fájlba.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Hozzon létre egy új [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot.  
2. Hívja meg a [addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromPdf) metódust a PDF fájl elérési útjával.  
3. Hívja meg a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) használatával a bemutató PPTX fájlba írásához.

A következő Python példa importál egy PDF dokumentumot és elmenti a generált diát PowerPoint bemutatóként:

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

Az alapértelmezett üres dia a bemutatóban marad, mert az importálás hozzáfűzi a diákat. Ha csak az importált oldalakat szeretné megtartani, törölje a diagyűjteményt a [SlideCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#clear) hívásával importálás előtt.

Az [addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromPdf) metódus visszaadja az általa hozzáadott diákat, ami hasznos, ha csak az importált diákon szeretne feldolgozni.

{{% alert title="Tip" color="success" %}}
Próbálja ki az ingyenes [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, hogy lássa a konverziós munkafolyamatot működés közben.
{{% /alert %}}

## **Importálás HTML-ből**

Az Aspose.Slides képes diák létrehozására HTML dokumentumból is. A forrás lehet HTML szöveg vagy folyam. Az alábbi lépések fájlfolyam használatával mutatják be a folyamatot:

1. Hozzon létre egy új [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot.  
2. Nyissa meg a HTML fájlt olvasásra, és adja át a folyamot a [addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromHtml) metódusnak.  
3. Hívja meg a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) használatával az eredmény PPTX fájlba írásához.

A következő Python példa importál egy HTML dokumentumot és elmenti a generált diát PowerPoint bemutatóként:

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

## **HTML tartalom beillesztése**

Használja a [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertFromHtml) metódust, amikor a HTML‑ből generált diákat egy meghatározott pozícióba kell helyezni a hozzáfűzés helyett. Az index nulla‑alapú és meghatározza azt a pozíciót, ahol az importálás kezdődik.

A `useSlideWithIndexAsStart` argumentum szabályozza, hogyan használja az importáló ezt a pozíciót:

- Ha `False`, az importáló új diákot hoz létre a megadott indexnél és eltolja a következő diákat.  
- Ha `True`, az importáló a megadott indexű meglévő dián lévő szabad helyet használja a tartalom elhelyezéséhez. Ha a HTML nem fér el, az Aspose.Slides automatikusan felosztja és további diákat szúr be közvetlenül a kezdő dia után.

A [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#insertFromHtml) egy [Slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/) objektumok tömbjét adja vissza. Ha a beszúrás új diákon kezdődik, minden visszaadott elem újonnan létrehozott. Ha egy meglévő diát használunk kiindulásként, a tömb tartalmazza az érintett diát, majd az esetleges új túlfutó diákokat. Ennek a tömbnek az ellenőrzésével elkerülhető a prezentáció diálszámából való számítás a ható tartomány meghatározásához.

### **HTML beillesztése új diákként**

Az alábbi példa HTML‑t ad meg karakterláncként, és a generált diákat a gyűjtemény `1`‑es indexére illeszti. A `False` átadása az existing diákat változatlanul hagyja, csak eltolja őket a hely biztosításához.

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

### **Kezdés egy meglévő diárról**

A következő példa HTML‑t egy folyamként ad meg. Megtartja a fejlécalakzatot a meglévő sablon diáron, az importálást az elfoglalt terület alá kezdi, és a hosszú szöveg továbbfolytatódik új diákra.

A HTML tartalmaz egy relatív képelérési utat is. Egy [ExternalResourceResolver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/externalresourceresolver/) szerzi be az erőforrást, míg az alap‑URI megmondja az importálónak, hogyan kell feloldani a `images/logo.png` hivatkozást. Ebben a példában a fájl a `html-assets/images/logo.png` helyen várható.

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
Egy korlátlan külső erőforrás-resolver képes helyi vagy hálózati erőforrásokat olvasni, amelyeket a HTML hivatkozik. Nem megbízható bemenet esetén ellenőrizze és tisztítsa meg az erőforrás‑URL‑eket egy engedélyezett sémák, könyvtárak és hostok listájával, mielőtt importálná a HTML‑t.
{{% /alert %}}

## **GYIK**

**Képes‑e az Aspose.Slides táblázatokat felismerni PDF importáláskor?**

Igen. Hozzon létre egy [PdfImportOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfimportoptions/) objektumot, hívja meg a [setDetectTables](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfimportoptions/#setDetectTables) metódust `True` értékkel, és adja át az opciókat a [addFromPdf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidecollection/#addFromPdf) metódusnak. A táblázat‑felismerés minősége a forrás PDF szerkezetétől és összetettségétől függ.

{{% alert title="Note" color="info" %}}
HTML importálása után a diákat exportálhatja [images](/slides/hu/python-java/convert-powerpoint-to-png/), [TIFF](/slides/hu/python-java/convert-powerpoint-to-tiff/), vagy [SVG](/slides/hu/python-java/render-slide-as-svg/) formátumokba is.
{{% /alert %}}