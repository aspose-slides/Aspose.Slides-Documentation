---
title: Manage Presentation Headers and Footers in Java
linktitle: Header and Footer
type: docs
weight: 140
url: /java/presentation-header-and-footer/
keywords:
- header
- header text
- footer
- footer text
- set header
- set footer
- handout
- notes
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Use Aspose.Slides for Java to add and customize headers and footers in PowerPoint and OpenDocument presentations for a professional look."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/java/) provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/java/) provides the feature for managing headers and footers inside presentation slides. These are in fact managed on presentation master level.

## **Manage Headers and Footers in a Presentation**
Notes of some specific slide could be removed as shown in example below:

```java
// Load Presentation
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Setting Footer
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Access and Update Header
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Save presentation
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Method to set Header/Footer Text
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Manage Headers and Footers on Handout and Notes Slides**
Aspose.Slides for Java supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in below Example.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Change Header and Footer settings for notes master and all notes slides
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // make the master notes slide and all child Footer placeholders visible
        headerFooterManager.setFooterAndChildFootersVisibility(true); // make the master notes slide and all child Header placeholders visible
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // make the master notes slide and all child SlideNumber placeholders visible
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // make the master notes slide and all child Date and time placeholders visible

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // set text to master notes slide and all child Header placeholders
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // set text to master notes slide and all child Footer placeholders
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // set text to master notes slide and all child Date and time placeholders
    }

    // Change Header and Footer settings for first notes slide only
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // make this notes slide Header placeholder visible

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // make this notes slide Footer placeholder visible

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // make this notes slide SlideNumber placeholder visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // make this notes slide Date-time placeholder visible

        headerFooterManager.setHeaderText("New header text"); // set text to notes slide Header placeholder
        headerFooterManager.setFooterText("New footer text"); // set text to notes slide Footer placeholder
        headerFooterManager.setDateTimeText("New date and time text"); // set text to notes slide Date-time placeholder
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I add a "header" to regular slides?**

In PowerPoint, "Header" exists only for notes and handouts; on regular slides, the supported elements are the footer, date/time, and slide number. In Aspose.Slides this matches the same limitations: header only for Notes/Handout, and on slides—Footer/DateTime/SlideNumber.

**What if the layout doesn’t contain a footer area—can I "turn on" its visibility?**

Yes. Check the visibility via the header/footer manager and enable it if needed. These API indicators and methods are designed for cases when the placeholder is missing or hidden.

**How do I make the slide number start from a value other than 1?**

Set the presentation’s [first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); after that, all numbering is recalculated. For example, you can start at 0 or 10, and hide the number on the title slide.

**What happens to headers/footers when exporting to PDF/images/HTML?**

They are rendered as regular text elements of the presentation. That is, if the elements are visible on slides/notes pages, they will also appear in the output format along with the rest of the content.
