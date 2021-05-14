---
title: Presentation Header and Footer
type: docs
weight: 140
url: /java/presentation-header-and-footer/
keywords: "PowerPoint header and footer in Java"
description: "PowerPoint header and footer in Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/java/) provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/java/) provides the feature for managing headers and footers inside presentation slides. These are in fact managed on presentation master level.

## **Manage Header and Footer in Presentation**
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
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **Manage Header and Footer in Handout and Notes Slides**
Aspose.Slides for Java supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) containing a video.
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
