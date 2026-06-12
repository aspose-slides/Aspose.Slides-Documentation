---
title: Probleem met Objectvoorbeeld bij Toevoegen van OleObjectFrame
linktitle: Probleem met OLE-object
type: docs
weight: 10
url: /nl/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- voorbeeldprobleem
- ingesloten object
- ingesloten bestand
- object gewijzigd
- objectvoorbeeld
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer waarom EMBEDDED OLE OBJECT verschijnt bij het toevoegen van OleObjectFrame in Aspose.Slides voor PHP en hoe u voorbeeldproblemen in PPT-, PPTX- en ODP-presentaties kunt oplossen."
---
## **Inleiding**

Wanneer u Aspose.Slides voor PHP via Java gebruikt en een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) aan een dia toevoegt, wordt op de uitvoerdia een bericht **EMBEDDED OLE OBJECT** weergegeven. Dit bericht is opzettelijk en GEEN fout.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/php-java/manage-ole/). 

## **Uitleg en Oplossing**

Aspose.Slides toont het bericht **EMBEDDED OLE OBJECT** om u te laten weten dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Voorbeeld: als u een Microsoft Excel‑grafiek als een [OleObjectFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/oleobjectframe/) aan een dia toevoegt (voor meer details, zie het artikel “Manage OLE”) en vervolgens de presentatie opent in Microsoft PowerPoint, ziet u deze afbeelding op de dia:

![OLE‑objectbericht](OLE_object_message.png)

Wilt u controleren en bevestigen dat uw OLE‑object aan de dia is toegevoegd, moet u dubbelklikken op het bericht **EMBEDDED OLE OBJECT**, of u kunt er met de rechtermuisknop op klikken en via **Object > Bewerken** kiezen.

![OLE object > Bewerken](OLE_object_edit.png)

PowerPoint opent vervolgens het ingebedde OLE‑object.

![OLE‑objectgegevens](OLE_object_data.png)

De dia kan het bericht **EMBEDDED OLE OBJECT** behouden. Zodra u op het OLE‑object klikt, wordt de voorbeeldweergave van de dia bijgewerkt en wordt het bericht **EMBEDDED OLE OBJECT** vervangen door de werkelijke afbeelding van het OLE‑object. 

![OLE‑objectvoorbeeld](OLE_object_preview.png)

U wilt nu misschien uw presentatie opslaan om er zeker van te zijn dat de afbeelding voor het OLE‑object correct wordt bijgewerkt. Op deze manier ziet u na het opslaan van de presentatie, wanneer u de presentatie opnieuw opent, het bericht **EMBEDDED OLE OBJECT** NIET meer. 

## **Andere Oplossingen**

### **Oplossing 1: Het bericht “Embedded OLE Object” vervangen door een afbeelding**

Als u het bericht **EMBEDDED OLE OBJECT** niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kunt u het bericht vervangen door uw gewenste voorbeeldafbeelding. Deze code‑fragmenten tonen het proces:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Voeg een afbeelding toe aan de presentatieresources.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Stel een titel en de afbeelding in voor de voorbeeldweergave van het OLE-object.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

De dia die het `OleObjectFrame` bevat, verandert vervolgens in dit:

![Nieuwe OLE‑objectafbeelding](OLE_object_new_image.png)

### **Oplossing 2: Een add‑on voor PowerPoint maken**

U kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE‑objecten bijwerkt wanneer u presentaties in het programma opent.