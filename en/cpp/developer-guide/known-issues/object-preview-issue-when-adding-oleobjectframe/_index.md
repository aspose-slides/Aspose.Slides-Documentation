---
title: Object Preview Issue When Adding OleObjectFrame
linktitle: OLE Object Issue
type: docs
weight: 10
url: /cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- preview issue
- embed object
- embed file
- object changed
- object preview
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn why EMBEDDED OLE OBJECT appears when adding OleObjectFrame in Aspose.Slides for C++ and how to fix preview issues in PPT, PPTX and ODP presentations."
---

## **Introduction**

Using Aspose.Slides for C++, when you add [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) to a slide, an "EMBEDDED OLE OBJECT" message is shown on the output slide. This message is intentional and NOT a bug.

For more information on working with OLE objects, see [Manage OLE](/slides/cpp/manage-ole/). 

## **Explanation and Solution**

Aspose.Slides displays the "EMBEDDED OLE OBJECT" message to notify you that the OLE object has been changed and the preview image has to be updated. 

For example, if you add a Microsoft Excel сhart as an [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) to a slide (for more details, see the "Manage OLE" article) and then open the presentation in the Microsoft PowerPoint, you will see this image on the slide:

![OLE object message](OLE_object_message.png)

If you want to check and confirm that your OLE object was added to the slide, you have to double-click on the "EMBEDDED OLE OBJECT" message, or you can right-click on it and go through **Object > Edit** option.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint then opens the embedded OLE object.

![OLE object data](OLE_object_data.png)

The slide may retain the "EMBEDDED OLE OBJECT" message. Once you click the OLE object, the slide preview gets updated and the "EMBEDDED OLE OBJECT" message is replaced by the actual image for the OLE object. 

![OLE object preview](OLE_object_preview.png)

Now, you may want to save your presentation to ensure the image for the OLE Object gets updated correctly. This way, after saving the presentation, when you open the presentation again, you will NOT see the "EMBEDDED OLE OBJECT" message. 

## **Other Solutions**

### **Solution 1: Replace the "Embedded OLE Object" Message with an Image**

If you do not want to remove the "EMBEDDED OLE OBJECT" message by opening the presentation in PowerPoint and then saving it, you can replace the message with your preferred preview image. These lines of code demonstrate the process:

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

The slide containing the `OleObjectFrame` then changes to this:

![New OLE object image](OLE_object_new_image.png)

### **Solution 2: Create an Add-On for PowerPoint**

You can also create an add-on for Microsoft PowerPoint that updates all OLE objects when you open presentations in the program. 
