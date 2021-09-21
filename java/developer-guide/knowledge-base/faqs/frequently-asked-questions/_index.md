---
title: Frequently Asked Questions
type: docs
weight: 10
url: /java/frequently-asked-questions/
---

{{% alert color="primary" %}} 

This page collects a number of frequently asked questions about:

- [Supported file formats](/slides/java/frequently-asked-questions/).
- [Exceptions](/slides/java/frequently-asked-questions/).
- [Working with slides](/slides/java/frequently-asked-questions/).
- [Cloning slides](/slides/java/frequently-asked-questions/).
- [Working with presentations](/slides/java/frequently-asked-questions/).
- [Formatting and images](/slides/java/frequently-asked-questions/).

{{% /alert %}} 
## **Supported File Formats**
### **Q: What file formats does Aspose.Slides for Java support?**
**A**: Aspose.Slides for Java supports the following file formats:

- Microsoft PowerPoint 97 – 2003 Presentation (PPT)
- Microsoft PowerPoint 97 – 2003 Template (POT)
- Microsoft PowerPoint 97 – 2003 SlideShow (PPS)
- Microsoft PowerPoint 2007-2010 Presentation (PPTX)
- Microsoft PowerPoint 2007 -2010Template (POTX)
- Microsoft PowerPoint 2007-2010 SlideShow (PPSX)
- Open Document Format presentations (ODP)
  Read more about supported file formats in the [File Formats and Conversions](/slides/java/file-formats-and-conversions/) section of the documentation.
## **Exceptions**
### **Q: I am getting an OutOfMemory exception while importing a large PPT file with images to MemoryStream. Is there a limitation in Aspose.Slides regarding file size?**
**A** : There is no specific formula for calculating the presentation size support by Aspose.Slides. There should be enough space to accommodate the whole presentation structure and images in the presentation. Normally, the images in the memory occupy more space than hard disk especially when there are effects on it as well.

In general, Aspose.Slides for Java can easily handle presentation files around 300 MB on a server with 4 GB RAM.
## **Working with Slides**
### **Q: Can I change the size of the slides in a presentation?**
**A** : You can use the SlideSize property exposed by the Presentation class to define the size of the slides in a presentation.
### **Q: Is there a way to define slides of different size in a presentation?**
**A**: Since the size of slides is defined at presentation level in Microsoft PowerPoint, there is no way to do this.
### **Q: Does Aspose.Slides for Java support previewing a slide before saving?**
**A**: You can render the slides in the presentation to the image and can use these images for previewing the slides.
## **Cloning Slides**
### **Q: What is the purpose of the SortedList parameter in the CloneSlide method?**
**A**: The SortedList parameter is used by the CloneSlide method to hold temporary information about the master slides of the source presentation as the slide being cloned may inherit its layout from the master.
### **Q: When I clone a slide, the notes associated with the slide are ignored?**
**A**: Notes associated with a slide cannot be cloned as it is prohibited by the PPT documentation. You can add notes associated with a slide using the following code:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Notes-AddNotesWithSlide-AddNotesWithSlide.java" >}}
### **Q: Why are internal hyperlinks lost when slides are cloned ?**
**A**: There is no way to preserve internal links when slides are cloned. The reason being there can be different numbers of slides in the new presentation and their order can be different from the source presentation. So cloning the slide in target presentation may not point to desired slide link. That is why all internal hyperlinks should be reset after slides cloning if necessary.
## **Working with Presentations**
### **Q: When I open a PPT file with slides created with Aspose.Slide and then press F5 for the presentation mode, I only see the first slide.**
The rest of the slides are not shown in this mode. If I open the presentation settings (strg-c strg-s) then the fields slide from and to are set to 1 and 1.

Is it possible to change these values?

**A**: You can use the StartingSlide and EndingSlide properties of the SlideShowSettings class to control these settings.
### **Q: Is it possible to scan text from a presentation?**
**A** : Aspose.Slides for Java 4 and later provides the PresentationScanner class under the com.aspose.slides.Util namespace that provides various methods for retrieving whole text from the presentations.
### **Q: Why do internal hyperlinks are lost when slides are cloned ?**
**A** : There is no way to preserve internal links in case slide is cloned. The reason being there can be different number slides and their order in target presentation as compared to source presentation. So cloning the slide in target presentation may not point to desired slide link. That is why all internal hyperlinks should be reset after slides cloning if necessary.
## **Formatting and Images**
### **Q: How can I set the color of a table's border?**
**A**: You can change the border for all borders in a table or just border around whole table. For changing all borders, please check the Table.SetBorders function. For border of table, you should iterate cell and change color of external borders.
### **Q: What measure does Aspose.Slides for Java use to place pictures? Is it point?**
**A**: It's pixels and resolution of slides is 576 pixels per inch.
### **Q: What is default DPI of the slide in PDF and images generated using Aspose.Slides for Java?**
**A**: By default, Aspose.Slides generate the PDF and Slide thumbnails with DPI 72. The default DPI for MS PowerPoint is 96. Aspose.Slides does offer to generate the slide thumbnails with varying DPIs.
