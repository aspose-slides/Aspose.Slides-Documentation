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
import aspose.pydrawing as draw
import aspose.slides as slides

# Method to set Header/Footer text
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "HI there new header"

# Load Presentation
with slides.Presentation("combined_with_master.pptx") as pres:
    # Setting Footer
    pres.header_footer_manager.set_all_footers_text("My Footer text")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # Access and Update Header
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # save presentation
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
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
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# make the master notes slide and all child Footer placeholders visible
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# set text to master notes slide and all child Header placeholders
		headerFooterManager.set_header_and_child_headers_text("Header text") 
		headerFooterManager.set_footer_and_child_footers_text("Footer text") 
		headerFooterManager.set_date_time_and_child_date_times_text("Date and time text") 

	# Change Header and Footer settings for first notes slide only
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# make notes slide Header placeholder visible

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# set text to notes slide Header placeholder
		headerFooterManager.set_header_text("New header text") 
		headerFooterManager.set_footer_text("New footer text") 
		headerFooterManager.set_date_time_text("New date and time text") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```

