---
title: Prezentáció helykitöltőinek kezelése Pythonban
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
description: "Ismerje meg, hogyan lehet vizsgálni és szerkeszteni a szöveg-, kép-, diagram- és tartalomhelykitöltőket, valamint megérteni a helykitöltő öröklődést az Aspose.Slides Python (Java-on keresztül) segítségével."
---
## **Áttekintés**

A helykitöltő egy alakzat, amely helyet foglal egy adott típusú tartalom számára egy prezentációs sablonban. Gyakori példák a cím, a törzs, a kép, a diagram és az általános tartalom helykitöltői. A hétköznapi alakzattól eltérően a helykitöltő örökölheti pozícióját, méretét, formázását és egyéb beállításait az elrendezési vagy a mesterdiapozitról.

Az Aspose.Slides a helykitöltő információkat a [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) metóduson keresztül teszi elérhetővé. A metódus egy [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) objektumot ad vissza, vagy `None`‑t egy normál alakzat esetén. Használja a [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) metódust annak meghatározásához, hogy milyen tartalmat szándékozik a helykitöltő tartalmazni.

Az alakzat típusa továbbra is fontos, miután ismeri a helykitöltő típusát:

- Egy üres szöveg-, kép-, diagram- vagy tartalomhelykitöltő általában egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) segítségével jelenik meg.
- Egy kitöltött képhelykitöltő egy [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) segítségével jeleníthető meg.
- Egy kitöltött diagramhelykitöltő egy [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) segítségével jeleníthető meg.
- Egy tartalomhelykitöltő többféle tartalmat is tartalmazhat. Ellenőrizze mind a [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType), mind a futásidejű alakzat típust, ahelyett, hogy feltételezné, hogy minden helykitöltő egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
A [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) leírja a helykitöltő szerepét; nem garantálja az alakzat futásidejű típusát. Mindig végezzen típusellenőrzést, mielőtt szöveghez, képhez, diagramhoz, táblához vagy média-specifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A helykitöltő öröklődésének megértése**

A helykitöltők hierarchiát alkotnak:

1. A mesterdia meghatározza az újrahasználható stílusokat, és egyes esetekben a mester‑szintű helykitöltőket.
2. Az elrendezésdia meghatározza az elrendezést, amelyet egy vagy több normál dia használ, és örökölhet a mestertől.
3. Egy normál dia tartalmazza az adott dia helykitöltőit, és örökölhet az elrendezéséből.

Hívja meg a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) metódust a hierarchia egy szinttel feljebb lépéshez. Egy diahelykitöltő általában visszaadja az elrendezéshelykitöltőt; egy elrendezéshelykitöltő visszaadhatja a mesterhelykitöltőt. A metódus `None`‑t ad vissza, ha az alakzatnak nincs alaphelykitöltője.

A következő példa felsorolja az első dián található helykitöltőket, és jelentést készít azok alaphelykitöltőiről:

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

Egy helykitöltő szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít azon a dián. A kapcsolódó elrendezés vagy mester szerkesztése befolyásolhatja az összes olyan diát, amely még mindig örökli ezt a beállítást. Egy helyi szokásos alakzatnak nincs alaphelykitöltője, és nem kezd örökölni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Helykitöltő állapot eltávolítása**

Sablon módosításakor használja a [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) metódust, hogy egy meglévő objektumot szokásos alakzatként tartson meg. Ennek a [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) metódusa `None`‑t ad vissza, de az alakzat a dia gyűjteményében marad. Ezzel szemben a [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) eltávolítja az alakzatot a gyűjteményből.

A következő példa `template.pptx`‑et igényel, amely legalább egy diával és egy nem üres szöveges helykitöltővel rendelkezik az első dián. Használjon egy helykitöltőt, amely formázását az elrendezéséből vagy a mestertől örökli, hogy lássa a kapcsolat eltávolításának hatását. A példa ellenőrzi, hogy az ugyanaz az alakzat megmarad, újból meghívja a metódust a most már szokásos alakzaton, és elmenti az eredményt.

{{% alert color="warning" title="Warning" %}}
A helykitöltő állapotának eltávolítása nem őrzi meg automatikusan az örökölt megjelenési beállításokat. Az alábbi példa szándékosan változatlanul hagyja ezeket a beállításokat, így a kimenet eltérőnek tűnhet. Egy olyan alakzat, amelynek pozíciója és mérete teljesen örökölt, a hívás után null koordinátákkal és méretekkel rendelkezhet, és láthatatlanná válhat, pedig a gyűjteményben marad.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpacte.isJVMStarted():
    jpacte.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # A metódus hívása egy szokásos alakzaton nincs hatása.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Egy megfelelő helykitöltő esetén mindhárom ellenőrzés `True`‑t ír ki. A szöveg megmarad, de az örökölt pozíció, méret, forgatás, betűtípus, bekezdés igazítása, szövegkeret margók, vertikális rögzítés, kitöltés és vonal beállítások változhatnak, amikor a helykitöltő kapcsolatot eltávolítják. Például az örökölt címformázás visszaeshet a szokásos szövegformázásra. További információért lásd a [Slide Layout](/slides/hu/python-java/slide-layout/) oldalt.

A kívánt megjelenés megőrzéséhez a hívás előtt rögzítse a kiszámolt pozíciót, méretet és forgatást, majd másolja a szükséges hatékony formázási értékeket külön változókba. Szerezze be ezeket az értékeket a [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) és [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) metódusokon keresztül. Ne csak a hatékony formátumobjektumokra támaszkodjon, mivel a szövegformázási értékeik megváltozhatnak a kapcsolat eltávolítása után. Alkalmazza kifejezetten a rögzített értékeket a szokásos alakzatra később, beleértve a betűcsaládot, méretet, stílust, színt, bekezdés beállításokat, szövegkeret beállításokat, kitöltést és a sablon által használt vonalat.

Az örökölt alakzatgeometriát is explicit módon kell hozzárendelni a [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) segítségével. Egy téglalap alakú szöveghelykitöltő esetén ez azt jelenti, hogy a [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) értéket kell beállítani; csak a kitöltés és vonal helyreállítása nem feltétlenül állítja vissza a látható téglalapot. További hatásokkal vagy összetettebb formázással rendelkező sablonok esetén ezeket a beállításokat is kezelni kell.

## **Szöveg módosítása egy helykitöltőben**

A cím, középre igazított cím, alcím, törzs és szöveghelykitöltők általában támogatják a szöveget. A [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ellenőrzése után használja a [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) metódust.

Ez a példa frissíti az első címsor helykitöltőt az első dián, és elmenti az eredményt:

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

Ez a minta elkerüli, hogy a kép-, diagram-, tábla- vagy médiahelykitöltőket [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)‑ként kezelje. Emellett a helykitöltőt célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat indexre támaszkodna.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő utasítás egy üres helykitöltőben, például *Kattintson a cím hozzáadásához*. Egyedi prompt szöveget a elrendezéshelykitöltőn állítson be, ahelyett, hogy a normál dia alakzategyűjteményén keresztül próbálná elérni. Az elrendezést a [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) segítségével érheti el, és iteráljon a [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) által visszaadott gyűjteményen.

A következő példa megváltoztatja a cím és alcím promptjait az első dia által használt elrendezésen:

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

A prompt szöveg nem a normál dia tartalom. Üres helykitöltőkhöz van tervezve szerkesztőalkalmazásokban, például a PowerPointban. Amint egy felhasználó vagy program valós tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem is cseréli le a már létező szöveget az elrendezést használó diáknál.

## **Kép helykitöltő frissítése**

Két esetet kell kezelni:

- Ha a képhelykitöltő már ki van töltve és egy [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) képviseli, cserélje le a képet a [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) és a [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) segítségével.
- Ha még üres helykitöltő, adjon hozzá egy képkeretet a helykitöltő koordinátáiban a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) segítségével, és távolítsa el az üres helykitöltőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

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

Az üres helykitöltőhöz létrehozott helyettesítés egy helyi képkeret, nem egy új helykitöltő, mivel a [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) nem biztosít beállítót. Megőrzi a lefoglalt pozíciót, de már nem örököl helykitöltő‑specifikus viselkedést. Ha a helykitöltő kapcsolat megtartása lényeges, először készítse és töltse fel a helykitöltőt a PowerPointban, majd frissítse az eredményül kapott [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) objektumot az Aspose.Slides‑szel.

A kép átlátszóságához, vágásához és egyéb kép‑specifikus hatásokhoz lásd a [Manage Picture Frames](/slides/hu/python-java/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy képkitöltéshez tartoznak, nem a helykitöltő metaadataihoz.

## **Diagram és tartalomhelykitöltők kezelése**

Egy kitöltött diagramhelykitöltő egy [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) segítségével jeleníthető meg. Ez a példa a helykitöltő típusa és a futásidejű típus alapján keresi meg az ilyen diagramot, megváltoztatja a címét, és elmenti a fájlt:

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

Általános tartalomhelykitöltő általában a [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) típussal rendelkezik. PowerPointban ez többféle tartalomtípus indítójaként működik, beleértve a diagramokat, táblákat, diagrammákat, képeket és médiát. Miután kitöltötték, vizsgálja meg a tényleges alakzat típusát, hogy megtudja, mit tartalmaz. Speciális elrendezések szintén ki tudják mutatni a [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) vagy [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) típusokat.

Az Aspose.Slides nem konvertál egy üres [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) helykitöltőt [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) -é csak a [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) módosításával; a típust az API-val nem lehet megváltoztatni. Egy üres diagram vagy tartalmi terület programozott kitöltéséhez adja hozzá a szükséges objektumot a helykitöltő koordinátáihoz, majd távolítsa el az üres helykitöltőt. A következő példa ezt egy diagramra alkalmazza:

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

A hozzáadott diagram egy szokásos helyi diagram. Elfoglalja a helykitöltő területét, de nem örököl az elrendezés helykitöltőjétől. Használja a dedikált [chart management articles](/slides/hu/python-java/powerpoint-charts/) cikkeket, amikor a kategóriákat, sorozatokat vagy munkafüzet adatokat kell cserélni.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő vég‑végi példa megnyit egy sablont, az első dián keres egy címet vagy képhelykitöltőt, ellenőrzi a helykitöltő és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan elkerüli a alakzat index feltételezését vagy minden helykitöltő egyforma típusúként való kezelést.

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

## **FAQ**

**Mi a bázishelykitöltő?**

A bázishelykitöltő az elrendezésen vagy a mesteren lévő megfelelő alakzat, amelyből egy másik helykitöltő örököl. Használja a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) metódust a lekéréséhez. Egy szokásos helyi alakzat `None`‑t ad vissza, mivel nem része a helykitöltő hierarchiának.

**Meg tudom változtatni az összes dia címét egy elrendezéshelykitöltő szerkesztésével?**

Az elrendezésben módosíthatja az örökölt formázást vagy a prompt szöveget, de a meglévő címtartalom a normál diákban van tárolva. A prezentációban a tényleges cím szövegének cseréjéhez iteráljon a diákon, és frissítse minden címhelykitöltőt.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc helykitöltőket?**

Használja a fejléc- és lábléc kezelőket a megfelelő dián, elrendezésen, mesteren, jegyzeten vagy kiadványon. Lásd a [Manage Presentation Header and Footer](/slides/hu/python-java/presentation-header-and-footer/) oldalt a teljes példákért.