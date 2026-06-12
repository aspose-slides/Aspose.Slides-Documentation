---
title: Probleem met Voorbeeldweergave van Object bij Toevoegen van OleObjectFrame
linktitle: Probleem met OLE‑object
type: docs
weight: 10
url: /nl/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- probleem met voorbeeldweergave
- ingebed object
- ingebed bestand
- object gewijzigd
- voorbeeld van object
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer waarom de melding EMBEDDED OLE OBJECT verschijnt bij het toevoegen van een OleObjectFrame in Aspose.Slides voor C++ en hoe u voorbeeldproblemen in PPT-, PPTX- en ODP‑presentaties kunt oplossen."
---
## **Inleiding**

Met Aspose.Slides voor C++ toont het toevoegen van een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) aan een dia een melding “EMBEDDED OLE OBJECT” op de uitvoerdia. Deze melding is opzettelijk en GEEN fout.

Voor meer informatie over het werken met OLE‑objecten, zie [Manage OLE](/slides/nl/cpp/manage-ole/). 

## **Uitleg en Oplossing**

Aspose.Slides geeft de melding “EMBEDDED OLE OBJECT” weer om u te informeren dat het OLE‑object is gewijzigd en dat de voorbeeldafbeelding moet worden bijgewerkt. 

Bijvoorbeeld, als u een Microsoft Excel‑grafiek toevoegt als een [OleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/oleobjectframe/) aan een dia (voor meer details, zie het artikel “Manage OLE”) en vervolgens de presentatie opent in Microsoft PowerPoint, ziet u deze afbeelding op de dia:

![OLE object message](OLE_object_message.png)

Als u wilt controleren en bevestigen dat uw OLE‑object aan de dia is toegevoegd, moet u dubbelklikken op de “EMBEDDED OLE OBJECT”‑melding, of u kunt er met de rechtermuisknop op klikken en de optie **Object > Edit** kiezen.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint opent vervolgens het ingebedde OLE‑object.

![OLE object data](OLE_object_data.png)

De dia kan de melding “EMBEDDED OLE OBJECT” behouden. Zodra u op het OLE‑object klikt, wordt de voorbeeldweergave van de dia bijgewerkt en wordt de melding “EMBEDDED OLE OBJECT” vervangen door de daadwerkelijke afbeelding van het OLE‑object. 

![OLE object preview](OLE_object_preview.png)

Nu wilt u wellicht uw presentatie opslaan om ervoor te zorgen dat de afbeelding van het OLE‑object correct wordt bijgewerkt. Op die manier ziet u, nadat u de presentatie hebt opgeslagen en opnieuw opent, de melding “EMBEDDED OLE OBJECT” NIET. 

## **Andere Oplossingen**

### **Oplossing 1: Vervang de “Embedded OLE Object”‑melding door een afbeelding**

Als u de melding “EMBEDDED OLE OBJECT” niet wilt verwijderen door de presentatie in PowerPoint te openen en vervolgens op te slaan, kunt u de melding vervangen door uw gewenste voorbeeldafbeelding. De volgende code‑regels tonen het proces:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De dia die de `OleObjectFrame` bevat, verandert vervolgens in het volgende:

![New OLE object image](OLE_object_new_image.png)

### **Oplossing 2: Maak een add‑on voor PowerPoint**

U kunt ook een add‑on voor Microsoft PowerPoint maken die alle OLE‑objecten bijwerkt wanneer u presentaties in het programma opent.