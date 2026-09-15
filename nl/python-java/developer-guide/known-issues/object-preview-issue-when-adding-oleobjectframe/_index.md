---
title: Probleem met Voorbeeld van Object bij Toevoegen van OleObjectFrame
linktitle: OLE Object Probleem
type: docs
weight: 10
url: /nl/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- voorbeeldprobleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- object voorbeeld
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides voor Python via Java en hoe u voorbeeldproblemen in PPT-, PPTX- en ODP-presentaties kunt oplossen."
---
## **Introductie**

Wanneer u Aspose.Slides voor Python via Java gebruikt om een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) aan een dia toe te voegen, wordt op de resulterende dia een bericht “EMBEDDED OLE OBJECT” weergegeven. Dit bericht is opzettelijk en is geen bug.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/python-java/manage-ole/).

## **Uitleg en Oplossing**

Aspose.Slides toont het bericht “EMBEDDED OLE OBJECT” om u te laten weten dat het OLE‑object is gewijzigd en de voorbeeldafbeelding moet worden bijgewerkt.

Bijvoorbeeld, als u een Microsoft Excel‑grafiek als een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) aan een dia toevoegt (voor meer details, zie het artikel “Manage OLE”) en vervolgens de presentatie opent in Microsoft PowerPoint, ziet u deze afbeelding op de dia:

![OLE‑objectbericht](OLE_object_message.png)

Om te bevestigen dat uw OLE‑object aan de dia is toegevoegd, dubbelklikt u op het bericht “EMBEDDED OLE OBJECT”, of klikt u er met de rechtermuisknop op en selecteert u **Object > Edit**.

![OLE‑object > Edit](OLE_object_edit.png)

PowerPoint opent vervolgens het ingebedde OLE‑object.

![OLE‑objectgegevens](OLE_object_data.png)

De dia kan het bericht “EMBEDDED OLE OBJECT” behouden. Zodra u op het OLE‑object klikt, wordt de diavoorbeeld bijgewerkt en wordt het bericht “EMBEDDED OLE OBJECT” vervangen door de werkelijke afbeelding van het OLE‑object.

![OLE‑objectvoorbeeld](OLE_object_preview.png)

Sla uw presentatie op om de bijgewerkte voorbeeldafbeelding van het OLE‑object te behouden. Wanneer u de presentatie opnieuw opent, ziet u het bericht “EMBEDDED OLE OBJECT” niet meer.

## **Andere Oplossing**

Als u het bericht “EMBEDDED OLE OBJECT” niet wilt verwijderen door de presentatie te openen in PowerPoint en vervolgens op te slaan, kunt u het bericht vervangen door uw voorkeursvoorbeeldafbeelding. De volgende code toont het proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Voeg een afbeelding toe aan de presentatieresources.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Stel een titel en de afbeelding in voor het voorbeeld van het OLE-object.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De dia die het [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) bevat, verandert vervolgens in dit:

![Nieuwe OLE‑objectafbeelding](OLE_object_new_image.png)

## **FAQ**

**Waarom verschijnt het bericht “EMBEDDED OLE OBJECT”?**

Het bericht geeft aan dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. Dit gedrag is opzettelijk.

**Hoe kan ik het voorbeeld bijwerken in PowerPoint?**

Dubbelklik op het bericht of selecteer **Object > Edit** om het ingebedde OLE‑object te openen. Klik op het OLE‑object om het voorbeeld bij te werken en sla vervolgens de presentatie op.

**Kan ik het bericht vervangen zonder de presentatie te openen in PowerPoint?**

Ja. U kunt een voorkeursvoorbeeldafbeelding toewijzen aan het OLE‑object, zoals weergegeven in het bovenstaande code‑voorbeeld.