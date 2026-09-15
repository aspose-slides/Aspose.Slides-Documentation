---
title: Probleem met preview van object bij het toevoegen van OleObjectFrame
linktitle: OLE‑objectprobleem
type: docs
weight: 10
url: /nl/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- preview probleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectpreview
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides for Java en hoe u preview-problemen in PPT, PPTX en ODP-presentaties kunt oplossen."
---
## **Inleiding**

Met Aspose.Slides for Java, wanneer je een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe/) toevoegt aan een dia, wordt er een "EMBEDDED OLE OBJECT"-bericht weergegeven op de uitvoerdia. Dit bericht is bewust en GEEN bug.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/java/manage-ole/). 

## **Uitleg en oplossing**

Aspose.Slides toont het "EMBEDDED OLE OBJECT"-bericht om je te informeren dat het OLE‑object is gewijzigd en de voorbeeldafbeelding moet worden bijgewerkt. 

Bijvoorbeeld, als je een Microsoft Excel‑grafiek toevoegt als een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe/) aan een dia (voor meer details, zie het artikel "Manage OLE") en vervolgens de presentatie opent in Microsoft PowerPoint, zie je deze afbeelding op de dia:

![OLE object message](OLE_object_message.png)

Als je wilt controleren en bevestigen dat je OLE‑object aan de dia is toegevoegd, moet je dubbelklikken op het "EMBEDDED OLE OBJECT"-bericht, of je kunt er met de rechtermuisknop op klikken en via **Object > Edit** gaan.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint opent dan het ingebedde OLE‑object.

![OLE object data](OLE_object_data.png)

De dia kan het "EMBEDDED OLE OBJECT"-bericht behouden. Zodra je op het OLE‑object klikt, wordt de dia‑preview bijgewerkt en wordt het "EMBEDDED OLE OBJECT"-bericht vervangen door de daadwerkelijke afbeelding van het OLE‑object. 

![OLE object preview](OLE_object_preview.png)

Nu wil je mogelijk je presentatie opslaan om ervoor te zorgen dat de afbeelding voor het OLE‑object correct wordt bijgewerkt. Op die manier zie je na het opslaan van de presentatie, wanneer je de presentatie opnieuw opent, GEEN "EMBEDDED OLE OBJECT"-bericht meer. 

## **Andere oplossing**

Als je het "EMBEDDED OLE OBJECT"-bericht niet wilt verwijderen door de presentatie te openen in PowerPoint en vervolgens op te slaan, kun je het bericht vervangen door je gewenste voorbeeldafbeelding. Deze code‑regels tonen het proces:

```java
import com.aspose.slides.*;

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

De dia die het `OleObjectFrame` bevat, verandert dan in het volgende:

![New OLE object image](OLE_object_new_image.png)