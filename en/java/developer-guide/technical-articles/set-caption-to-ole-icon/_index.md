---
title: Set Caption to OLE Icon
type: docs
weight: 130
url: /java/set-caption-to-ole-icon/
---

New methods **getSubstitutePictureTitle** and **setSubstitutePictureTitle** has been added to **IOleObjectFrame** interface and **OleObjectFrame** class. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add an OLE object to the slide
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// Add an image to the presentation's image collection
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// Set the image as an icon for the OLE object
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// Set a caption to the OLE icon
oleFrame.setSubstitutePictureTitle("Caption example");
```
