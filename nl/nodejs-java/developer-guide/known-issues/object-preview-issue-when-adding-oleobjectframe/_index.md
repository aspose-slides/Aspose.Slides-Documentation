---
title: Probleem met objectvoorvertoning bij toevoegen van OleObjectFrame
linktitle: OLE Object Probleem
type: docs
weight: 10
url: /nl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- voorvertoningsprobleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectvoorvertoning
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides voor Node.js en hoe je voorvertoningsproblemen in PPT-, PPTX- en ODP-presentaties kunt oplossen."
---
## **Inleiding**

Met Aspose.Slides for Java, wanneer je een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/) aan een dia toevoegt, wordt een “EMBEDDED OLE OBJECT”‑bericht weergegeven op de uitvoer‑dia. Dit bericht is opzettelijk en GEEN bug.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/nodejs-java/manage-ole/). 

## **Uitleg en Oplossing**

Aspose.Slides toont het “EMBEDDED OLE OBJECT”‑bericht om je te laten weten dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Als voorbeeld, als je een Microsoft Excel‑grafiek toevoegt als een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/) aan een dia (voor meer details, zie het artikel “Manage OLE”) en daarna de presentatie opent in Microsoft PowerPoint, zie je de volgende afbeelding op de dia:

![OLE object message](OLE_object_message.png)

Wil je controleren en bevestigen dat je OLE‑object aan de dia is toegevoegd, moet je dubbelklikken op het “EMBEDDED OLE OBJECT”‑bericht, of je kunt er met de rechtermuisknop op klikken en de optie **Object > Bewerken** kiezen.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint opent vervolgens het ingesloten OLE‑object.

![OLE object data](OLE_object_data.png)

De dia kan het “EMBEDDED OLE OBJECT”‑bericht behouden. Zodra je op het OLE‑object klikt, wordt de dia‑preview bijgewerkt en wordt het “EMBEDDED OLE OBJECT”‑bericht vervangen door de werkelijke afbeelding van het OLE‑object. 

![OLE object preview](OLE_object_preview.png)

Nu wil je wellicht de presentatie opslaan om er zeker van te zijn dat de afbeelding van het OLE‑object correct wordt bijgewerkt. Zo zie je na het opslaan en opnieuw openen van de presentatie het “EMBEDDED OLE OBJECT”‑bericht NIET meer.

## **Andere Oplossingen**

### **Oplossing 1: Het “Embedded OLE Object”‑bericht vervangen door een afbeelding**

Als je het “EMBEDDED OLE OBJECT”‑bericht niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kun je het bericht vervangen door je gewenste voorbeeldafbeelding. Deze code‑regels illustreren het proces:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Voeg een afbeelding toe aan presentatie resources.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Stel een titel en de afbeelding in voor de OLE object preview.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

De dia met de `OleObjectFrame` wordt dan als volgt aangepast:

![New OLE object image](OLE_object_new_image.png)

### **Oplossing 2: Een add‑on voor PowerPoint maken**

Je kunt ook een add‑on voor Microsoft PowerPoint maken dat alle OLE‑objecten bijwerkt wanneer je presentaties opent in het programma.