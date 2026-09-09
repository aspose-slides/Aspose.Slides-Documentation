---
title: Prezentáció helykitöltők kezelése Pythonban
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/python-java/manage-placeholder/
keywords:
- helykitöltő
- szöveghelykitöltő
- képhelykitöltő
- diagramhelykitöltő
- tartalomhelykitöltő
- prompt szöveg
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helykitöltőket, valamint hogyan értheti meg a helykitöltő öröklődést az Aspose.Slides Python (Java) verziójával."
---
## **Áttekintés**

A helykitöltő egy alakzat, amely egy adott típusú tartalom számára foglal helyet egy prezentációs sablonban. Gyakori példák a cím, a szövegtörzs, a kép, a diagram és az általános célú tartalomhelykitöltők. A szokásos alakzattól eltérően a helykitöltő örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezés‑dia vagy alap‑dia alapján.

Aspose.Slides a helykitöltő információkat a [Shape.getPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getPlaceholder) metóduson keresztül teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/) objektumot ad vissza, vagy `None`‑t egy normál alakzat esetén. Használja a [Placeholder.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/#getType) metódust az adott helykitöltő szándékolt tartalmának meghatározásához.

Az alakzat típusa továbbra is fontos, miután ismeri a helykitöltő típusát:

- Egy üres szöveg-, kép-, diagram- vagy tartalomhelykitöltő általában egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) formában jelenik meg.
- Egy kitöltött képhelykitöltő egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) segítségével jeleníthető meg.
- Egy kitöltött diagramhelykitöltő egy [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) segítségével képviselhető.
- Egy tartalomhelykitöltő többféle tartalmat is tartalmazhat. Ellenőrizze mind a [Placeholder.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/#getType), mind a futásidőbeni alakzat típust, ahelyett, hogy azt feltételezné, hogy minden helykitöltő egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/#getType) leírja a helykitöltő szerepét; nem garantálja az alakzat futásidőbeni típusát. Mindig végezzen típusellenőrzést, mielőtt szöveg, kép, diagram, táblázat vagy média‑specifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A helykitöltő öröklődés megértése**

A helykitöltők hierarchiát alkotnak:

1. Az alap‑dia (master slide) újrahasználható stílusokat definiál, és bizonyos esetekben alap‑szintű helykitöltőket is.
2. Az elrendezés‑dia (layout slide) meghatározza az egy vagy több normál dia által használt elrendezést, és örökölhet az alaptól.
3. Egy normál dia tartalmazza a saját helykitöltőit, és örökölhet az elrendezésétől.

A hierarchiában egy szinttel feljebb léphet a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) meghívásával. Egy diahelykitöltő normál esetben visszaadja az elrendezés‑helykitöltőjét; egy elrendezés‑helykitöltő visszaadhatja az alap‑helykitöltőjét. A metódus `None`‑t ad vissza, ha az alakzatnak nincs alap‑helykitöltője.

A következő példa felsorolja az első dia helykitöltőit, és jelentést készít azok alap‑helykitöltőiről:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Egy helykitöltő szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít azon a dián. A kapcsolódó elrendezés vagy alap szerkesztése minden olyan diára hatással lehet, amely még mindig örökli ezt a beállítást. Egy helyi, szokásos alakzatnak nincs alap‑helykitöltője, és nem kezd örökölni csak azért, mert ugyanazt a koordinátát foglalja.

## **Szöveg módosítása egy helykitöltőben**

A cím, középre igazított cím, alcím, szövegtörzs és szöveghelykitöltők általában támogatják a szöveget. Ellenőrizze, hogy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)‑e, mielőtt a [getTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/#getTextFrame) metódusát használná.

Ez a példa frissíti az első dia első címhelykitöltőjét, majd elmenti az eredményt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a minta elkerüli, hogy a kép, diagram, táblázat vagy média helykitöltőket [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)‑ként kezelje. Emellett a helykitöltőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat‑indexre támaszkodna.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő utasítás egy üres helykitöltőben, például *Kattintson a cím hozzáadásához*. Állítson be egyedi prompt szöveget az elrendezéshelykitöltőn, ahelyett, hogy a normál dia alakzategyűjteményén keresztül próbálna elérni. Az elrendezéshez a [Slide.getLayoutSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getLayoutSlide) metódussal férhet hozzá, és iteráljon a [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményen.

A következő példa módosítja a cím és alcím prompt szövegét az első dia által használt elrendezésen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A prompt szöveg nem normál dia tartalom. Üres helykitöltőkhöz készült szerkesztőalkalmazásokban, például a PowerPointban. Amint a felhasználó vagy egy program valós tartalmat biztosít, a prompt többé nem jelenik meg. A prompt módosítása nem cseréli le a meglévő szöveget azokat a diákat használó elrendezéseken.

## **Képhelykitöltő frissítése**

Két esetet kell kezelni:

- Ha a képhelykitöltő már ki van töltve és egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) reprezentálja, cserélje ki a képet a [PictureFillFormat.getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [Picture.setImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#setImage) metódusokkal.
- Ha még üres helykitöltő, adjon hozzá egy képkeretet a helykitöltő koordinátáihoz a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) segítségével, és távolítsa el az üres helykitöltőt.

A következő példa mindkét esetet támogatja, és elmenti a bemutatót:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az üres helykitöltőre létrehozott csere egy helyi képkeret, nem új helykitöltő, mivel a [Shape.getPlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getPlaceholder) nem biztosít beállítót. Megtartja a lefoglalt pozíciót, de már nem örököl a helykitöltőre jellemző viselkedést. Ha a helykitöltő kapcsolat megtartása létfontosságú, először készítse elő és töltse fel a helykitöltőt a PowerPointban, majd frissítse a keletkezett [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) objektumot az Aspose.Slides-szel.

A kép átlátszóságához, vágásához és egyéb képre specifikus hatásokhoz lásd a [Képkeretek kezelése](/slides/hu/python-java/picture-frame/) oldalt. Ezek a műveletek a képkerethez vagy a képkitöltéshez tartoznak, nem a helykitöltő metaadatokhoz.

## **Diagram és tartalom helykitöltőkkel való munka**

Egy kitöltött diagramhelykitöltő egy [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) segítségével jeleníthető meg. Ez a példa mind a helykitöltő típusa, mind a futásidőbeni típus alapján megtalálja az ilyen diagramot, módosítja a címét, és elmenti a fájlt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy általános tartalomhelykitöltő általában a [PlaceholderType.Object](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Object) típussal rendelkezik. A PowerPointban ez többféle tartalom típus indítójaként funkcionál, beleértve a diagramokat, táblázatokat, diagramokat, képeket és médiát. Miután kitöltötték, ellenőrizze a tényleges alakzat típust, hogy megtudja, mit tartalmaz. A specializált elrendezések szintén ki tudják mutatni a [PlaceholderType.Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Media) vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholdertype/#Diagram) típusokat.

Az Aspose.Slides nem alakítja át egy üres [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) helykitöltőt [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) objektummá a [Placeholder.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/#getType) módosításával; a típust az API-val nem lehet megváltoztatni. Egy üres diagram vagy tartalomterület programozott feltöltéséhez adja hozzá a szükséges objektumot a helykitöltő koordinátáihoz, majd távolítsa el az üres helykitöltőt. A következő példa ezt egy diagramra alkalmazza:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helykitöltő területét, de nem örököl az elrendezés‑helykitöltőtől. Használja a dedikált [diagramkezelési cikkeket](/slides/hu/python-java/powerpoint-charts/) amikor a kategóriák, sorozatok vagy munkafüzet adatainak cseréjére van szükség.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő végponttól‑végpontig tartó példa megnyit egy sablont, az első dián keres egy cím- vagy képhelykitöltőt, ellenőrzi a helykitöltő és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerül el egy alakzat index feltételezését vagy azt, hogy minden helykitöltőt ugyanannak a típusnak tekint.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **GYIK**

**Mi az a alap‑helykitöltő?**

Az alap‑helykitöltő az elrendezésen vagy alapon (master) lévő megfelelő alakzat, amelyből egy másik helykitöltő örököl. Használja a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getBasePlaceholder) metódust a lekérdezéséhez. Egy szokásos helyi alakzat `None`‑t ad vissza, mert nem része a helykitöltő hierarchiának.

**Meg tudom változtatni az összes diárcímét egy elrendezéshelykitöltő szerkesztésével?**

Az örökölt formázást vagy a prompt szöveget egy elrendezésen keresztül megváltoztathatja, de a meglévő cím tartalom a normál diákon van tárolva. A tényleges cím szövegének egy prezentációban való cseréjéhez iterálja a diákat, és frissítse minden címhelykitöltőt.

**Hogyan kezeljem a dátum, dia‑szám, fejléc és lábléc helykitöltőket?**

Használja a fej- és lábléc kezelőket a megfelelő dia, elrendezés, alap (master), jegyzet vagy szórólap tartományban. Lásd a [Prezentáció fej- és láblécének kezelése](/slides/hu/python-java/presentation-header-and-footer/) oldalt a teljes példákért.