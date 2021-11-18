---
title: Presentation Header and Footer
type: docs
weight: 140
url: /pythonnet/presentation-header-and-footer/
keywords: "Header, footer, set header, set footer, set headed and footer, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint header and footer in Python"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/pythonnet/) provides support to work with slide's headers and footers text that are actually maintained on Slide master level.

{{% /alert %}} 

[Aspose.Slides for Python via .NET](/slides/pythonnet/) provides the feature for managing headers and footers inside presentation slides. These are in fact managed on the presentation master level.
## **Manage Header and Footer Text**
Notes of some specific slide could be updated as shown in the example below:

```py
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



```py
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
Aspose.Slides for Python via .NET supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation)containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in the below Example.

```py
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

