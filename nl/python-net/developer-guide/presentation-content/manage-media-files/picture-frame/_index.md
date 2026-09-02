---
title: Beheer afbeeldingsframes in presentaties met Python
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/python-net/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingsframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingsframes in presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een picture frame is een slide‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) bezit ingesloten afbeeldingsbronnen via zijn [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, picture‑effects en andere frame‑niveau instellingen van de afbeelding beheert.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/), en gebruik die afbeeldingsbron bij het maken van picture frames.

Picture frames kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is nuttig om te bepalen hoe de afbeelding moet worden opgeslagen voordat opmaak of optimalisatie wordt toegepast.

## **Een ingesloten afbeelding toevoegen en opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsgegevens toe aan de presentatie en maak je een picture frame met [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/). De afbeelding wordt onderdeel van het presentatiespakket, zodat de presentatie zelf‑containend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame met de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Het picture frame bepaalt de weergegeven geometrie; het wijzigen van de framegrootte verandert de originele pixelafmetingen die in de ingesloten afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt belangrijk wanneer je later een afbeelding bijsnijdt of comprimeert.

## **Relatieve schaal gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) biedt [relative_scale_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/relative_scale_width/) en [relative_scale_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/relative_scale_height/) voor het frame. Een waarde van `1.0` komt overeen met 100 % van de originele afmeting van de afbeelding. Relatieve schaal is nuttig wanneer een workflow de verhouding met de oorspronkelijke afbeeldingsgrootte moet behouden in plaats van handmatig de uiteindelijke afmetingen te berekenen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herschaalt of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en gekoppelde afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsgegevens op binnen de presentatie en is daarom de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een extern pad op via de [Picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picture/)‑link in plaats van de afbeeldingsgegevens in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst, of de bron niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet weergegeven zoals verwacht. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een picture frame en wijst het naar een lokaal afbeeldingsbestand. Het gaat uitsluitend over afbeeldingskoppelingen; video‑koppelingen zijn een aparte mediaprocess en worden bewust niet gemengd in dit voorbeeld.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet alleen als vervanging voor compressie: een kleine PPTX met gebroken afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere zelf‑containende presentatie.

## **Afbeeldingen extraheren uit afbeeldingframes**

Voordat je een afbeelding uit een bestaande presentatie extraheert, controleer je of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde picture frames bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden uitgehaald.

### **Rasterafbeelding extraheren**

De moderne image‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) direct. Het volgende voorbeeld zoekt de eerste ingesloten rasterafbeelding op een dia en slaat deze op als PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Opslaan via [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) zet de geëxtraheerde afbeelding om naar het gewenste uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen wilt hebben in plaats van een geconverteerd rasterbestand, gebruik dan de [PPImage.binary_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/binary_data/)‑eigenschap.

### **SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding biedt de [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) object. Hiermee kun je de SVG‑data rechtstreeks ophalen in plaats van de afbeelding eerst te rasteren.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG‑inhoud als SVG behouden houdt de vectorbron binnen de presentatie. Raster‑exports zoals PNG of JPEG renderen die vectorinhoud noodzakelijkerwijs naar pixels. PDF‑ of SVG‑dia‑export is ook een render‑bewerking, dus de geëxporteerde grafieken moeten niet worden beschouwd als een byte‑voor‑byte kopie van de originele ingesloten SVG; gebruik de ingebedde [SvgImage.svg_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/svg_data/) wanneer de originele vectorresource zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden bepaalt welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) zijn percentages van de bronafmetingen van de afbeelding. Bijsnijden verwijdert de verborgen pixels niet meteen uit de ingesloten afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een picture frame en past bijsnijdwaarden toe:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Omdat de verborgen afbeeldingsdata nog steeds aanwezig is, kan de bijsnijding later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) verwijdert afbeeldingsdata buiten het huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verminderen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet langer beschikbaar voor een latere uncrop‑bewerking.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de originele afbeelding ook wordt gebruikt door andere picture frames, moeten die frames hun bestaande resource behouden, zodat het verwijderen van bijgesneden gebieden niet per se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/compress_image/) vermindert de resolutie van rasterafbeeldingen relatief ten opzichte van de grootte waarop de afbeelding wordt weergegeven. Het kan tevens bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `True` wanneer de afbeelding is herschaald of bijgesneden en `False` wanneer geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/picturescompression/) waarde wanneer een standaard doelresolutie voldoende is:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een enumeratiewaarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metafile‑inhoud worden niet gereduceerd door deze raster‑compressieworkflow. Vergeet ook niet dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie gebaseerd op de grootste weergave‑ of exportgrootte van de afbeelding in plaats van de laagste DPI globaal toe te passen.

## **Beeldtransformaties beheren**

Voor een volledige workflow die helderheid, contrast, kleursveranderingen, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/slides/nl/python-net/image-transform-effects/).

## **Geometrie van afbeeldingframe vergrendelen**

De instellingen van [PictureFrameLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/) bepalen welke bewerkingsacties voor een picture frame worden uitgeschakeld. Bijvoorbeeld, de eigenschap [aspect_ratio_locked](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) behoudt de verhoudingen van de vorm terwijl deze wordt vergroot of verkleind.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

De vergrendeling heeft betrekking op het picture‑frame‑object. Het dwingt de bronafbeelding niet af om opnieuw te worden gesampled of permanent te worden aangepast aan dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de picture‑fill‑modus “stretch” is, definiëren de stretch‑offset waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) het vulrechthoek ten opzichte van de begrenzingsdoos van het picture frame. Positieve percentages creëren een inset vanaf een rand, terwijl negatieve percentages een outset vormen.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare picture‑fill wordt uitgerekt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik stretch‑offsets voor de plaatsing van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn gemakkelijker te beheren wanneer beeldopslag en picture‑frame‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelf‑containend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor oversized rasterafbeeldingen, maar het schaft in op de bronresolutie. Het moet worden toegepast nadat de beoogde weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer het behoud van vectorinformatie belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten, wanneer mogelijk, een bestaande [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑resource hergebruiken in plaats van steeds opnieuw hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is beeldoptimalisatie doorgaans het meest effectief wanneer deze selectief wordt uitgevoerd: houd logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een picture frame en een afbeeldingsbron?**

Een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar beheerd kunnen worden.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Standaard bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) of afbeeldingcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggegooid.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden gebieden wist afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken met hoge resolutie vereist kan zijn.

**Hoe moet ik SVG‑afbeeldingen behandelen?**

Houd SVG‑inhoud als SVG wanneer vector‑fidelity van belang is. De ingesloten [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je picture‑frame‑specifieke leden gebruikt. Het gebruik van `isinstance(shape, slides.PictureFrame)` voorkomt ongeldige casts en laat de code dia’s die geen picture frames bevatten correct afhandelen.