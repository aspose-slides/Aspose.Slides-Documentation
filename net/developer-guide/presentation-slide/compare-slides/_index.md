---
title: Compare Slides
type: docs
weight: 50
url: /net/compare-slides/
---

## **Compare Two Slides**
Equals method has been added to [IBaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide) interface and [BaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/baseslide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Slides_Presentations_Layout();
using (Presentation presentation1 = new Presentation(daraDir + "AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation(dataDir + "HelloWorld.pptx"))
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

