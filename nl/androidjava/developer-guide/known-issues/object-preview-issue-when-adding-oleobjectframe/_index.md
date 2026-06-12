---
title: Objectpreview-probleem bij het toevoegen van OleObjectFrame
linktitle: OLE-objectprobleem
type: docs
weight: 10
url: /nl/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- previewprobleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectpreview
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides voor Android via Java en hoe u previewproblemen in PPT, PPTX en ODP-presentaties kunt oplossen."
---
## **Introductie**

Met Aspose.Slides for Android via Java, wanneer je een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/oleobjectframe/) aan een dia toevoegt, wordt er een bericht “EMBEDDED OLE OBJECT” op de uitvoer-dia weergegeven. Dit bericht is opzettelijk en GEEN fout.

Voor meer informatie over het werken met OLE‑objecten, zie [Beheer OLE](/slides/nl/androidjava/manage-ole/). 

## **Uitleg en Oplossing**

Aspose.Slides toont het bericht “EMBEDDED OLE OBJECT” om je te laten weten dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Bijvoorbeeld, als je een Microsoft Excel‑grafiek als een [OleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/oleobjectframe/) aan een dia toevoegt (voor meer details, zie het artikel “Beheer OLE”) en vervolgens de presentatie opent in Microsoft PowerPoint, zie je deze afbeelding op de dia:

![OLE‑object bericht](OLE_object_message.png)

Als je wilt controleren en bevestigen dat je OLE‑object aan de dia is toegevoegd, moet je dubbelklikken op het bericht “EMBEDDED OLE OBJECT”, of je kunt er met de rechtermuisknop op klikken en via **Object > Bewerken** gaan.

![OLE object > Bewerken](OLE_object_edit.png)

PowerPoint opent dan het ingesloten OLE‑object.

![OLE‑object gegevens](OLE_object_data.png)

De dia kan het bericht “EMBEDDED OLE OBJECT” behouden. Zodra je op het OLE‑object klikt, wordt de dia‑preview bijgewerkt en wordt het bericht “EMBEDDED OLE OBJECT” vervangen door de daadwerkelijke afbeelding van het OLE‑object. 

![OLE‑object preview](OLE_object_preview.png)

Nu wil je misschien je presentatie opslaan om ervoor te zorgen dat de afbeelding voor het OLE‑object correct wordt bijgewerkt. Op die manier zie je na het opslaan en opnieuw openen van de presentatie het bericht “EMBEDDED OLE OBJECT” NIET meer. 

## **Andere Oplossingen**

### **Oplossing 1: Vervang het “Embedded OLE Object”‑bericht door een afbeelding**

Als je het “EMBEDDED OLE OBJECT”‑bericht niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kun je het bericht vervangen door je gewenste voorbeeldafbeelding. De volgende code‑regels laten het proces zien:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Voeg een afbeelding toe aan de presentatieresources.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Stel een titel en de afbeelding in voor de preview van het OLE-object.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

De dia met de `OleObjectFrame` verandert dan in dit:

![Nieuwe OLE‑object afbeelding](OLE_object_new_image.png)

### **Oplossing 2: Maak een add‑on voor PowerPoint**

Je kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE‑objecten bijwerkt wanneer je presentaties in het programma opent.