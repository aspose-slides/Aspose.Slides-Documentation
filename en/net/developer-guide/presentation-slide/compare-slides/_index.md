---
title: Compare Presentation Slides in .NET
linktitle: Compare Slides
type: docs
weight: 50
url: /net/compare-slides/
keywords:
- compare slides
- slide comparison
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Compare PowerPoint and OpenDocument presentations programmatically with Aspose.Slides for .NET. Identify slide differences in code quickly."
---

## **Compare Two Slides**
Equals method has been added to [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) interface and [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) is a presentation/playback-level property, not visual content. The equality of two specific slides is determined by their structure and static content; the mere fact that a slide is hidden does not make the slides different.

**Are hyperlinks and their parameters taken into account?**

Yes. Links are part of a slide’s static content. If the URL or the hyperlink action differs, this is usually treated as a difference in static content.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

No. The comparison is performed based on the slides themselves. External data sources are generally not read at comparison time; only what is present in the slide’s structure and static state is considered.
