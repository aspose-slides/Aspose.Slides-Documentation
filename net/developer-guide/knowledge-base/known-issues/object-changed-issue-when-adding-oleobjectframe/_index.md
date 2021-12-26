---
title: Object Changed Issue When Adding OleObjectFrame
type: docs
weight: 10
url: /net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

Using Aspose.Slides for .NET, when you add **[OleObjectFrame](https://apireference.aspose.com/slides/net/aspose.slides/oleobjectframe)** to a slide, an **Object Changed** message message is shown on the output slide (and NOT on the OLE object). The described process is a deliberate action and NOT a bug. 

{{% /alert %}} 
## **Explanation** and Solution
Aspose.Slides displays the **Object Changed** message to notify you that the OLE object has been changed and the preview image has to be updated. 

For example, if you add a Microsoft Excel Chart as an [OleObjectFrame](https://apireference.aspose.com/slides/net/aspose.slides/oleobjectframe) to a slide (for more details, see the Manage OLE article) and then open the presentation in the Microsoft PowerPoint app, you will see this image on the slide:

~~Replace all images with new images~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

If you want to check and confirm that your OLE object was added to the slide, you have to double-click on the **Object Changed** message or you can right-click on it and go through **Worksheet Object >  Edit option.**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPoint then opens the embedded OLE object

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)



The slide may retain the **Object Changed** message. Once you click the OLE object, the slide preview gets updated and the **Object Changed** message get replaced by the actual image for the OLE object. 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

Now, you may want to save your presentation to ensure the image for the OLE Object gets updated correctly. This way, after saving the presentation, when you open the presentation again, you will NOT see the **Object Changed** message. 

## **Alternatives**
In the previous section, we demonstrated that it is possible to remove the **Object Changed** message (or update the preview image for an OLE object) by opening the presentation in the Microsoft PowerPoint app and then saving the presentation. This section contains 2 alternative solutions to the described procedure. 

### **Solution 1: Replace the Object Changed Message with an Image**

If you do not like the **Object Changed** message, you can replace that message with your preferred preview image. First, you have to add the image to presentation and then use the image's id to replace the **Object Changed** message. These lines of code demonstrate the process:

``` csharp 
//Adds the picture to presentation and removes the related picture object
IPPImage picObject = pres.Images.AddImage(File.ReadAllBytes("C:\\demo.png"));

//Assigns the picture object for the newly added picture to the Picture Format of 
//OleObjectFrame where oof represents an OleObjectFrame
oof.SubstitutePictureFormat.Picture.Image = picObject;
```

The slide containing the `OleObjectFrame` then changes to this:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **Solution 2: Create an Add-On for PowerPoint**
You can also create an add-on for Microsoft PowerPoint that updates all OLE objects when you open presentations in the program. 

