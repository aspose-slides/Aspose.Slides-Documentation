---
title: How to Add Header Footer in a Presentation
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

A new [Aspose.Slides for .NET API](/slides/net/) has been released and now this single product supports the capability to generate PowerPoint documents from scratch and editing the existing ones.

{{% /alert %}} 
## **Support for Legacy code**
In order to use the legacy code developed with Aspose.Slides for .NET versions earlier to 13.x, you need to make some minor changes in your code and the code will work as earlier. All the classes that were present in old Aspose.Slides for .NET under Aspose.Slide and Aspose.Slides.Pptx namespaces are now merged in single Aspose.Slides namespace. Please take a look over the following simple code snippet for adding header footer in presentation in legacy Aspose.Slides API and follow the steps describing how to migrate to new merged API.
## **Legacy Aspose.Slides for .NET approach**
```c#
PresentationEx sourcePres = new PresentationEx();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Create the presentation
Presentation pres = new Presentation();

//Get first slide
Slide sld = pres.GetSlideByPosition(1);

//Access the Header / Footer of the slide
HeaderFooter hf = sld.HeaderFooter;

//Set Page Number Visibility
hf.PageNumberVisible = true;

//Set Footer Visibility
hf.FooterVisible = true;

//Set Header Visibility
hf.HeaderVisible = true;

//Set Date Time Visibility
hf.DateTimeVisible = true;

//Set Date Time format
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Set Header Text
hf.HeaderText = "Header Text";

//Set Footer Text
hf.FooterText = "Footer Text";

//Write the presentation to the disk
pres.Write("HeadFoot.ppt");
```



## **New Aspose.Slides for .NET 13.x approach**
```c#
Presentation sourcePres = new Presentation();

//Setting Header Footer visibility properties
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
```

