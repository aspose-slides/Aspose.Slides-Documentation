---
title: Probleem met voorbeeld van object bij toevoegen van OleObjectFrame
linktitle: OLE Object Probleem
type: docs
weight: 10
url: /nl/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- voorbeeldprobleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectvoorbeeld
- presentatie
- PowerPoint
- Python
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides voor Python en hoe u voorbeeldproblemen in PPT-, PPTX- en ODP-presentaties kunt oplossen."
---
## **Inleiding**

Met Aspose.Slides for Python via .NET, wanneer je een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) aan een dia toevoegt, wordt er een "EMBEDDED OLE OBJECT" bericht getoond op de resulterende dia. Dit bericht is opzettelijk en NOT een bug.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/python-net/manage-ole/). 

## **Uitleg en oplossing**

Aspose.Slides toont het "EMBEDDED OLE OBJECT" bericht om je te laten weten dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Als voorbeeld, als je een Microsoft Excel‑grafiek toevoegt als een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) aan een dia (voor meer details, zie het artikel “Manage OLE”) en vervolgens de presentatie opent in Microsoft PowerPoint, zie je deze afbeelding op de dia:

![OLE object message](OLE_object_message.png)

Wil je controleren en bevestigen dat je OLE‑object aan de dia is toegevoegd, moet je dubbelklikken op het "EMBEDDED OLE OBJECT" bericht, of je kunt er met de rechtermuisknop op klikken en via de optie **Object > Edit** gaan.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint opent vervolgens het ingesloten OLE‑object.

![OLE object data](OLE_object_data.png)

De dia kan het "EMBEDDED OLE OBJECT" bericht behouden. Zodra je op het OLE‑object klikt, wordt de voorbeeldweergave van de dia bijgewerkt en wordt het "EMBEDDED OLE OBJECT" bericht vervangen door de werkelijke afbeelding van het OLE‑object. 

![OLE object preview](OLE_object_preview.png)

Nu wil je mogelijk de presentatie opslaan om ervoor te zorgen dat de afbeelding van het OLE‑object correct wordt bijgewerkt. Op die manier zie je na het opslaan van de presentatie, bij het opnieuw openen, NOT het "EMBEDDED OLE OBJECT" bericht.

## **Andere oplossingen**

### **Oplossing 1: Vervang het "Embedded OLE Object" bericht door een afbeelding**

Als je het "EMBEDDED OLE OBJECT" bericht niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kun je het bericht vervangen door je gewenste voorbeeldafbeelding. Deze code‑regels demonstreren het proces:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Voeg een afbeelding toe aan presentatiebronnen.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Stel een titel en de afbeelding in voor de OLE-objectvoorbeeld.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

De dia die het `OleObjectFrame` bevat, verandert vervolgens in dit:

![New OLE object image](OLE_object_new_image.png)

### **Oplossing 2: Maak een add‑on voor PowerPoint**

Je kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE‑objecten bijwerkt wanneer je presentaties in het programma opent.