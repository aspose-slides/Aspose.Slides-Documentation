---
title: Compare Slides
type: docs
weight: 50
url: /nodejs-java/compare-slides/
---

## **Compare Two Slides**
Equals method has been added to [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) class and [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content. 

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```
