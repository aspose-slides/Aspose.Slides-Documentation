---
title: Objectvoorbeeld-plaatshouder bij toevoegen van OleObjectFrame
linktitle: OLE voorbeeld-plaatshouder
type: docs
weight: 10
url: /nl/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- voorbeeldprobleem
- voorbeeld-plaatshouder
- volgens ontwerp
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectvoorbeeld
- presentatie
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Waarom een OLE-object dat met Aspose.Slides voor .NET is toegevoegd een EMBEDDED OLE OBJECT-plaatshouder toont totdat het voorbeeld wordt bijgewerkt, en hoe je je eigen voorbeeldafbeelding kunt instellen."
---
## **Introductie**

Met Aspose.Slides voor .NET, wanneer je een [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) aan een dia toevoegt, wordt er een "EMBEDDED OLE OBJECT"-bericht getoond op de gegenereerde dia. Dit bericht is opzettelijk en GEEN bug.

Voor meer informatie over het werken met OLE-objecten, zie [OLE beheren](/slides/nl/net/manage-ole/).

## **Uitleg en oplossing**

Aspose.Slides toont het "EMBEDDED OLE OBJECT"-bericht om je te laten weten dat het OLE-object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt.

Bijvoorbeeld, als je een Microsoft Excel-grafiek toevoegt als een [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) aan een dia (voor meer details, zie het artikel "Manage OLE") en vervolgens de presentatie opent in Microsoft PowerPoint, zie je deze afbeelding op de dia:

![OLE-object bericht](OLE_object_message.png)

Als je wilt controleren en bevestigen dat je OLE-object aan de dia is toegevoegd, moet je dubbelklikken op het "EMBEDDED OLE OBJECT"-bericht, of je kunt er met de rechtermuisknop op klikken en via de optie **Object > Edit** gaan.

![OLE-object > Bewerken](OLE_object_edit.png)

PowerPoint opent vervolgens het ingebedde OLE-object.

![OLE-object gegevens](OLE_object_data.png)

De dia kan het "EMBEDDED OLE OBJECT"-bericht behouden. Zodra je op het OLE-object klikt, wordt de voorbeeldweergave van de dia bijgewerkt en wordt het "EMBEDDED OLE OBJECT"-bericht vervangen door de daadwerkelijke afbeelding van het OLE-object.

![OLE-object voorbeeld](OLE_object_preview.png)

Nu wil je misschien de presentatie opslaan om ervoor te zorgen dat de afbeelding voor het OLE-object correct wordt bijgewerkt. Op deze manier zie je na het opslaan van de presentatie, wanneer je de presentatie opnieuw opent, het "EMBEDDED OLE OBJECT"-bericht NIET.

## **Andere oplossingen**

### **Oplossing 1: Vervang het "Embedded OLE Object"-bericht door een afbeelding**

Als je het "EMBEDDED OLE OBJECT"-bericht niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kun je het bericht vervangen door je gewenste voorbeeldafbeelding. De volgende code‑regels demonstreren het proces:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

De dia die de `OleObjectFrame` bevat verandert vervolgens in het volgende:

![Nieuwe OLE-object afbeelding](OLE_object_new_image.png)

### **Oplossing 2: Maak een add‑on voor PowerPoint**

Je kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE-objecten bijwerkt wanneer je presentaties in het programma opent.