---
title: Pythonban a prezentáció helykitöltők kezelése
linktitle: Helykitöltők kezelése
type: docs
weight: 10
url: /hu/python-net/manage-placeholder/
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
- Aspose.Slides
description: "Ismerje meg, hogyan vizsgálhatja és szerkesztheti a szöveg-, kép-, diagram- és tartalomhelykitöltőket, valamint hogyan értheti meg a helykitöltők öröklődését az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Egy helykitöltő olyan alakzat, amely egy adott típusú tartalom számára fenntart egy pozíciót egy prezentációs sablonban. Gyakori példák a cím, a törzsszöveg, a kép, a diagram és az általános célú tartalomhelykitöltők. Egy szokásos alakzattól eltérően a helykitöltő örökölheti a pozícióját, méretét, formázását és egyéb beállításait egy elrendezési vagy mesterdia diáról.

Aspose.Slides a helykitöltő információt a [Shape.placeholder] tulajdonságon keresztül teszi elérhetővé. A tulajdonság egy [Placeholder] objektumot ad vissza, vagy `None` értéket egy normál alakzat esetén. Használja a [Placeholder.type] értéket annak meghatározásához, hogy milyen tartalomra szolgál a helykitöltő.

A shape class még mindig fontos, miután ismeri a helykitöltő típusát:

- Egy üres szöveges, képes, diagram vagy tartalomhelykitöltő általában egy [AutoShape] segítségével van ábrázolva.
- Egy feltöltött képhelykitöltő egy [PictureFrame] segítségével ábrázolható.
- Egy feltöltött diagramhelykitöltő egy [Chart] segítségével ábrázolható.
- Egy tartalomhelykitöltő többféle tartalmat is tartalmazhat. Ellenőrizze mind a [Placeholder.type] értékét, mind a futásidőbeli alakzat osztályát, ahelyett, hogy azt feltételezné, hogy minden helykitöltő egy [AutoShape].

{{% alert color="warning" title="Warning" %}}
[Placeholder.type] leírja a helykitöltő szerepét; nem garantálja az alakzat futásidőbeli osztályát. Mindig végezzen típusellenőrzést, mielőtt szöveg, kép, diagram, táblázat vagy média-specifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A helykitöltő öröklődésének megértése**

A helykitöltők hierarchiát alkotnak:

1. Az alapdia (master slide) meghatározza az újrahasznosítható stílusokat, és bizonyos esetekben a mester‑szintű helykitöltőket.
2. Az elrendezési dia (layout slide) meghatározza azt a kialakítást, amelyet egy vagy több normál dia használ, és örökölhet az alaptól.
3. A normál dia tartalmazza a saját helykitöltőit, és örökölhet az elrendezési diáról.

Hívja meg a [Shape.get_base_placeholder] metódust, hogy egy szinttel feljebb lépjen a hierarchiában. Egy diahelykitöltő általában visszaadja az elrendezési helykitöltőjét; egy elrendezési helykitöltő visszaadhatja a mester helykitöltőjét. A metódus `None` értéket ad, ha az alakzatnak nincs alap‑helykitöltője.

A következő példa felsorolja az első dián található helykitöltőket, és jelentést készít azok alap‑helykitöltőiről:
```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Egy helykitöltő szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít ahhoz a diához. A kapcsolódó elrendezés vagy mester szerkesztése befolyásolhatja az összes diát, amely még örökli azt a beállítást. Egy helyi, szokásos alakzatnak nincs alap‑helykitöltője, és nem kezd el örökölni csak azért, mert ugyanazokban a koordinátákban helyezkedik el.

## **Szöveg módosítása egy helykitöltőben**

A cím, középre igazított cím, alcím, törzsszöveg és szöveghelykitöltők általában támogatják a szöveget. Ellenőrizze, hogy [AutoShape] típusú‑e, mielőtt a [text_frame] tulajdonságát használja.

Ez a példa frissíti az első dián lévő első címhelykitöltőt, majd elmenti az eredményt:
```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ez a minta elkerüli, hogy a képes, diagram, táblázat vagy médiahelykitöltőket [AutoShape] objektumként kezelje. Emellett a helykitöltőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat indexre támaszkodna.

## **Prompt szöveg beállítása egy elrendezésen**

A prompt szöveg a tervezési időben megjelenő utasítás egy üres helykitöltőben, például *Kattintson a cím hozzáadásához*. Állítson be egyedi prompt szöveget az elrendezés helykitöltőjén, ahelyett, hogy a normál dia alakzategyüttesén keresztül próbálná elérni. Az elrendezéshez a [Slide.layout_slide] útján férhet hozzá, és iteráljon a [LayoutSlide.shapes] gyűjteményen.

A következő példa módosítja a cím és az alcím prompt szövegét az első dia által használt elrendezésen:
```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

A prompt szöveg nem normál dia tartalom. Üres helykitöltők számára készült szerkesztőalkalmazásokban, például a PowerPointban. Amint a felhasználó vagy egy program valódi tartalmat ad meg, a prompt már nem jelenik meg. A prompt módosítása nem írja felül a már létező szöveget az elrendezést használó diákon.

## **Képhelykitöltő frissítése**

Két esetet kell kezelni:

- Ha a képhelykitöltő már fel van töltve, és egy [PictureFrame] képviseli, cserélje ki a képet a [PictureFillFormat.picture] és a [Picture.image] segítségével.
- Ha még üres helykitöltő, adjon hozzá egy képkeretet a helykitöltő koordinátáiban a [ShapeCollection.add_picture_frame] segítségével, és távolítsa el az üres helykitöltőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:
```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

A egy üres helykitöltőhöz létrehozott csere egy helyi képkeret, nem egy új helykitöltő, mivel a [Shape.placeholder] csak olvasható. Megtartja a lefoglalt pozíciót, de már nem örököl a helykitöltő‑specifikus viselkedést. Ha a helykitöltő kapcsolat megtartása lényeges, először készítse és töltse fel a helykitöltőt a PowerPointban, majd frissítse a kapott [PictureFrame] objektumot az Aspose.Slides segítségével.

Kép átlátszóság, vágás és egyéb képspecifikus hatások tekintetében lásd a [Manage Picture Frames](/slides/hu/python-net/picture-frame/) cikket. Ezek a műveletek a képkerethez vagy a kép kitöltéséhez tartoznak, nem a helykitöltő metaadataihoz.

## **Diagram- és tartalomhelykitöltőkkel való munka**

Egy feltöltött diagramhelykitöltő egy [Chart] segítségével ábrázolható. Ez a példa mind a helykitöltő típusa, mind a futásidőbeli osztály alapján megtalál egy ilyen diagramot, megváltoztatja a címét, és elmenti a fájlt:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Egy általános tartalomhelykitöltő általában a [PlaceholderType.OBJECT] típust használja. A PowerPointban ez többféle tartalomtípus indítója, köztük diagramok, táblázatok, diagramok, képek és média. Miután feltöltötték, ellenőrizze a tényleges alakzat osztályát, hogy megtudja, mit tartalmaz. Speciális elrendezések a [PlaceholderType.CHART], [PlaceholderType.TABLE], [PlaceholderType.PICTURE], [PlaceholderType.MEDIA] vagy [PlaceholderType.DIAGRAM] típusokat is kiterjeszthetik.

Az Aspose.Slides nem konvertál egy üres [AutoShape] helykitöltőt [Chart] objektummá pusztán a [Placeholder.type] megváltoztatásával; a típus csak olvasható. Egy üres diagram vagy tartalomi terület programozott feltöltéséhez adja hozzá a szükséges objektumot a helykitöltő koordinátáihoz, majd távolítsa el az üres helykitöltőt. A következő példa ezt egy diagram esetén mutatja be:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

A hozzáadott diagram egy egyszerű helyi diagram. Elfoglalja a helykitöltő területét, de nem örököl az elrendezés helykitöltőjétől. Használja a dedikált [chart management articles](/slides/hu/python-net/powerpoint-charts/) cikkeket, ha a kategóriákat, sorozatokat vagy munkafüzet adatokat kell cserélnie.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

A következő végponttól végpontig tartó példa megnyit egy sablont, megkeresi az első dián a cím vagy kép helykitöltőt, ellenőrzi a helykitöltő és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerül a alakzat index feltételezésétől, illetve attól, hogy minden helykitöltőt ugyanaznak az alakzat osztálynak tekint.
```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mi az az alap‑helykitöltő?**

Az alap‑helykitöltő a megfelelő alakzat az elrendezésen vagy a mester dián, amelyből egy másik helykitöltő örököl. Használja a [Shape.get_base_placeholder] metódust a lekéréséhez. Egy szokásos helyi alakzat `None` értéket ad, mivel nem része a helykitöltő hierarchiának.

**Módosíthatom‑e az összes dia címét egy elrendezési helykitöltő szerkesztésével?**

Az öröklött formázást vagy a prompt szöveget egy elrendezésen keresztül módosíthatja, de a meglévő cím tartalma a normál diákon van tárolva. A tényleges cím szövegének egy prezentációban való cseréjéhez iteráljon a diákon, és frissítse minden címhelykitöltőt.

**Hogyan kezeljem a dátum, dia‑szám, fejléc és lábléc helykitöltőket?**

Használja a fejléc‑ és lábléc‑kezelőket a megfelelő dia, elrendezés, mester, jegyzet vagy kézjegy (handout) szinten. Lásd a [Manage Presentation Header and Footer](/slides/hu/python-net/presentation-header-and-footer/) cikket a teljes példákért.