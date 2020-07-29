---
title: Managing Header and Footers
type: docs
weight: 60
url: /java/managing-header-and-footers/
---

{{% alert color="primary" %}} 

Aspose.Slides provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

Aspose.Slides for Java provides the feature for managing headers and footers inside presentation slides. These are in fact managed on presentation master level.
## **Managing Header and Footers in presentation**
Notes of some specific slide could be removed as shown in example below:

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-HeadersFooters-ManagingHeaderAndFooters-ManagingHeaderAndFooters.java" >}}
## **Setting Footer visibility Inside Slide**
Aspose.Slides for Java provides the feature for Setting footer visibility inside slide. To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using SetDateTime method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-HeaderFooterManager-HeaderFooterManager.java" >}}
## **Setting Child Footer visibility Inside Slide**
Aspose.Slides for Java provides the feature for Setting footer visibility inside slide. To set footer and child footer inside a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using SetFooterAndChildFootersText method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-SetChildFooterVisible-SetChildFooterVisible.java" >}}
## **Support for managing Header/Footer in handout and notes slides**
Aspose.Slides for Java supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a Presentation containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in below Example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Notes-HeaderAndFooterInNotesSlide-HeaderAndFooterInNotesSlide.java" >}}
