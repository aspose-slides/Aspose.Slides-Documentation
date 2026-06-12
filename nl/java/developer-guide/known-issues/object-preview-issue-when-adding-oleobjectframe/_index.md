---
title: "Objectvoorbeeldprobleem bij het toevoegen van OleObjectFrame"
linktitle: "OLE‑objectprobleem"
type: docs
weight: 10
url: /nl/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- preview‑probleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectvoorbeeld
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer waarom het bericht EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides for Java en hoe u preview‑problemen in PPT‑, PPTX‑ en ODP‑presentaties kunt oplossen."
---
## **Inleiding**

Met Aspose.Slides for Java, wanneer u een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe/) toevoegt aan een dia, wordt er een bericht **\"EMBEDDED OLE OBJECT\"** weergegeven op de uiteindelijke dia. Dit bericht is opzettelijk en GEEN fout.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/java/manage-ole/). 

## **Uitleg en Oplossing**

Aspose.Slides toont het bericht **\"EMBEDDED OLE OBJECT\"** om u te informeren dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Bijvoorbeeld, als u een Microsoft Excel‑grafiek als een [OleObjectFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/oleobjectframe/) aan een dia toevoegt (voor meer details, zie het artikel **\"Manage OLE\"**) en vervolgens de presentatie opent in Microsoft PowerPoint, ziet u deze afbeelding op de dia:

![OLE‑objectbericht](OLE_object_message.png)

Als u wilt controleren en bevestigen dat uw OLE‑object aan de dia is toegevoegd, moet u dubbelklikken op het bericht **\"EMBEDDED OLE OBJECT\"**, of u kunt er met de rechtermuisknop op klikken en via de optie **Object > Bewerken** gaan.

![OLE‑object > Bewerken](OLE_object_edit.png)

PowerPoint opent vervolgens het ingebedde OLE‑object.

![OLE‑objectgegevens](OLE_object_data.png)

De dia kan het bericht **\"EMBEDDED OLE OBJECT\"** behouden. Zodra u op het OLE‑object klikt, wordt de voorvertoning van de dia bijgewerkt en wordt het bericht **\"EMBEDDED OLE OBJECT\"** vervangen door de daadwerkelijke afbeelding van het OLE‑object. 

![OLE‑objectvoorbeeld](OLE_object_preview.png)

Nu wilt u mogelijk de presentatie opslaan om te garanderen dat de afbeelding voor het OLE‑object correct wordt bijgewerkt. Op deze manier ziet u na het opslaan van de presentatie, wanneer u de presentatie opnieuw opent, het bericht **\"EMBEDDED OLE OBJECT\"** NIET meer. 

## **Andere Oplossingen**

### **Oplossing 1: Vervang het bericht \"Embedded OLE Object\" door een afbeelding**

Als u het bericht **\"EMBEDDED OLE OBJECT\"** niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kunt u het bericht vervangen door uw voorkeursvoorbeeldafbeelding. De volgende regels code demonstreren het proces:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Voeg een afbeelding toe aan de presentatieresources.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Stel een titel en de afbeelding in voor de weergave van het OLE-object.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

De dia die het `OleObjectFrame` bevat, verandert vervolgens in het volgende:

![Nieuwe OLE‑objectafbeelding](OLE_object_new_image.png)

### **Oplossing 2: Maak een add‑on voor PowerPoint**

U kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE‑objecten bijwerkt wanneer u presentaties opent in het programma.