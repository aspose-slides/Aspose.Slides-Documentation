---
title: Convert Powerpoint PPT(X) to JPG
type: docs
weight: 60
url: /cpp/convert-powerpoint-ppt-and-pptx-to-jpg/
keywords: "Convert PowerPoint to JPG"
description: "Convert PowerPoint to JPG: PPT to JPG, PPTX to JPG in C++"
---

## **Convert Presentation to Set of Images**

In some cases, it is necessary to convert the entire presentation into a set of images, 
the same as PowerPoint allows. The following example demonstrates this possibility:

``` cpp 
System::String outputDir = u"D:\\PresentationImages";
    
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Render presentation to images array slide by slide
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Control hidden slides (do not render hidden slides)
    if (pres->get_Slides()->idx_get(i)->get_Hidden())
    {
        continue;
    }
    
    // Convert slide to a Bitmap object
    System::SharedPtr<Bitmap> bmp = pres->get_Slides()->idx_get(i)->GetThumbnail(2.f, 2.f);

    // Create file name for an image
    System::String outputFilePath = Path::Combine(outputDir, System::String(u"Slide_") + i + u".jpg");
    
    // Save the image in PNG format
    bmp->Save(outputFilePath, ImageFormat::get_Png());
}
```

{{% alert  title="Tip" color="primary" %}} 

To see how Aspose.Slides API handles PPT/PPTX to JPG conversion, you may want to try [**Aspose.Slides Converter**](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

## **Render Comments when Saving Presentation into Image**

Aspose.Slides for C++ provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into an image.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RenderComments-RenderComments.cpp" >}}