---
title: Slide Section
type: docs
weight: 90
url: /java/slide-section/
---

## **Add or Remove Section in Slide**
Aspose.Slides for Java now allows developers to add a section or remove the section where a group of slides can be added or removed. Developers can also add a section at any desired location in the presentation. The code snippet below demonstrates how to use this feature.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISection section = (ISection)pres.getSections().get_Item(2);
    
    pres.getSections().reorderSectionWithSlides(section, 0);
    
    pres.getSections().removeSectionWithSlides(pres.getSections().get_Item(0));
    
    pres.getSections().appendEmptySection("Last empty section");
    pres.getSections().addSection("First empty", pres.getSlides().get_Item(0));
    
    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


