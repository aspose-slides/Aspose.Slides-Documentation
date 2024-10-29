---
title: Set Caption to OLE Icon
type: docs
weight: 110
url: /cpp/set-caption-to-ole-icon/
---

New **get_SubstitutePictureTitle()** and **set_SubstitutePictureTitle()** methods have been added to **IOleObjectFrame** and **OleObjectFrame** classes. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add an OLE object to the slide
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// Add an image to the presentation's image collection
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Set the image as an icon for the OLE object
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// Set a caption to the OLE icon
oleFrame->set_SubstitutePictureTitle(u"Caption example");
```
