---
title: Compare Presentation Slides on Android
linktitle: Compare Slides
type: docs
weight: 50
url: /androidjava/compare-slides/
keywords:
- compare slides
- slide comparison
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Compare PowerPoint and OpenDocument presentations programmatically with Aspose.Slides for Android. Identify slide differences in Java code quickly."
---

## **Compare Two Slides**
Equals method has been added to [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) interface and [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content. 

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) is a presentation/playback-level property, not visual content. The equality of two specific slides is determined by their structure and static content; the mere fact that a slide is hidden does not make the slides different.

**Are hyperlinks and their parameters taken into account?**

Yes. Links are part of a slide’s static content. If the URL or the hyperlink action differs, this is usually treated as a difference in static content.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

No. The comparison is performed based on the slides themselves. External data sources are generally not read at comparison time; only what is present in the slide’s structure and static state is considered.
