---
title: Manage Presentation Headers and Footers in .NET
linktitle: Header and Footer
type: docs
weight: 140
url: /net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Use Aspose.Slides for .NET to add and customize headers and footers in PowerPoint and OpenDocument presentations for a professional look."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/net/) provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/net/) provides the feature for managing headers and footers inside presentation slides. These are in fact managed on the presentation master level.
## **Manage Header and Footer Text**
Notes of some specific slide could be updated as shown in the example below:

```c#
// Load Presentation
Presentation pres = new Presentation("headerTest.pptx");

// Setting Footer
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Access and Update Header
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Save presentation
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Method to set Header/Footer Text
public static void UpdateHeaderFooterText(IBaseSlide master)
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
Aspose.Slides for .NET supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in the below Example.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Change Header and Footer settings for notes master and all notes slides
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // make the master notes slide and all child Footer placeholders visible
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // make the master notes slide and all child Header placeholders visible
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // make the master notes slide and all child SlideNumber placeholders visible
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // make the master notes slide and all child Date and time placeholders visible

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // set text to master notes slide and all child Header placeholders
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // set text to master notes slide and all child Footer placeholders
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // set text to master notes slide and all child Date and time placeholders
	}

	// Change Header and Footer settings for first notes slide only
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // make this notes slide Header placeholder visible

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // make this notes slide Footer placeholder visible

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // make this notes slide SlideNumber placeholder visible

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // make this notes slide Date-time placeholder visible

		headerFooterManager.SetHeaderText("New header text"); // set text to notes slide Header placeholder
		headerFooterManager.SetFooterText("New footer text"); // set text to notes slide Footer placeholder
		headerFooterManager.SetDateTimeText("New date and time text"); // set text to notes slide Date-time placeholder
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Can I add a "header" to regular slides?**

In PowerPoint, "Header" exists only for notes and handouts; on regular slides, the supported elements are the footer, date/time, and slide number. In Aspose.Slides this matches the same limitations: header only for Notes/Handout, and on slides—Footer/DateTime/SlideNumber.

**What if the layout doesn’t contain a footer area—can I "turn on" its visibility?**

Yes. Check the visibility via the header/footer manager and enable it if needed. These API indicators and methods are designed for cases when the placeholder is missing or hidden.

**How do I make the slide number start from a value other than 1?**

Set the presentation’s [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/); after that, all numbering is recalculated. For example, you can start at 0 or 10, and hide the number on the title slide.

**What happens to headers/footers when exporting to PDF/images/HTML?**

They are rendered as regular text elements of the presentation. That is, if the elements are visible on slides/notes pages, they will also appear in the output format along with the rest of the content.
