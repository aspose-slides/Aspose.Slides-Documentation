---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 2680
url: /python-net/api-reference/aspose.slides/itextframe/
---

Represents a TextFrame.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ITextFrame

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ITextFrame type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|paragraphs|Returns the list of all paragraphs in a frame.<br/>            Read-only [IParagraphCollection](/python-net/api-reference/aspose.slides/iparagraphcollection/).|
|text|Gets or sets the plain text for a TextFrame.<br/>            Read/write string.|
|text_frame_format|Returns the formatting object for this TextFrame object.<br/>            Read-only [ITextFrameFormat](/python-net/api-reference/aspose.slides/itextframeformat/).|
|hyperlink_queries|Provides easy access to contained hyperlinks.<br/>            Read-only [IHyperlinkQueries](/python-net/api-reference/aspose.slides/ihyperlinkqueries/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|highlight_text(text, highlight_color)|Highlight all matches of sample in text frame text using specified color.|
|highlight_text(text, highlight_color, options)|Highlight all matches of sample in text frame text using specified color.|
|join_portions_with_same_formatting()|Joins runs with same formatting in all paragraphs.|
|highlight_regex(regex, highlight_color, options)|Highlight all matches of regular expression in text frame text using specified color.|
