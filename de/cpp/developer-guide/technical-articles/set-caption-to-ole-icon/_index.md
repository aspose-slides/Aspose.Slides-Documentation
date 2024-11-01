---
title: Bildunterschrift für OLE-Icon festlegen
type: docs
weight: 110
url: /de/cpp/set-caption-to-ole-icon/
---

Neue **get_SubstitutePictureTitle()** und **set_SubstitutePictureTitle()** Methoden wurden zu den Klassen **IOleObjectFrame** und **OleObjectFrame** hinzugefügt. Sie ermöglichen das Abrufen, Setzen oder Ändern der Bildunterschrift eines OLE-Icons. Der folgende Code-Schnipsel zeigt ein Beispiel zum Erstellen eines Excel-Objekts und zum Festlegen seiner Bildunterschrift.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fügen Sie dem Folien ein OLE-Objekt hinzu
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Setzen Sie das Bild als Icon für das OLE-Objekt
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// Setzen Sie eine Bildunterschrift für das OLE-Icon
oleFrame->set_SubstitutePictureTitle(u"Beispiel für eine Bildunterschrift");
```