---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 720
url: /python-net/api-reference/aspose.slides/hyperlink/
---

Represents a hyperlink.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.Hyperlink

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The Hyperlink type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|Hyperlink(url)|Initializes a new instance of the Hyperlink class|
|Hyperlink(slide)|Initializes a new instance of the Hyperlink class|
|Hyperlink(source, target_frame, tooltip, history, stop_sounds_on_click, highlight_click)|Initializes a new instance of the Hyperlink class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|no_action|Returns a special "do nothing" hyperlink.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|media|Returns a special "play mediafile" hyperlink. Used in AudioFrame and VideoFrame.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|next_slide|Returns a hyperlink to the next slide.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|previous_slide|Returns a hyperlink to the previous slide.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|first_slide|Returns a hyperlink to the first slide of the presentation.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|last_slide|Returns a hyperlink to the last slide of the presentation.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|last_vieved_slide|Returns a hyperlink to the last viewed slide.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|end_show|Returns a hyperlink which ends the show.<br/>            Read-only [Hyperlink](/python-net/api-reference/aspose.slides/hyperlink/).|
|action_type|Returns type of Hyperlink's action.<br/>            Read-only [HyperlinkActionType](/python-net/api-reference/aspose.slides/hyperlinkactiontype/).|
|external_url|Specifies the external URL.<br/>            Read-only string.|
|target_slide|If the Hyperlink targets specific slide returns this slide.<br/>            Read-only [ISlide](/python-net/api-reference/aspose.slides/islide/).|
|target_frame|Returns the frame within the parent HTML frameset for the target<br/>            of the parent hyperlink when one exists.<br/>            Read/wite string.|
|tooltip|Returns the string which may be surfaced in a user interface<br/>            as associated with the parent hyperlink.<br/>            Read/write string.|
|history|Determines whether the target of the parent hyperlink shall be added<br/>            to a list of viewed hyperlinks when it is invoked.<br/>            Read/write bool.|
|highlight_click|Determines whether the hyperlink should be highlighted on click.<br/>            Read/write bool.|
|stop_sound_on_click|Determines whether the sound should be stopped on hyperlink click.<br/>            Read/write bool.|
|color_source|Represents the source of hyperlink color - either styles or portion format.<br/>            Read/write [HyperlinkColorSource](/python-net/api-reference/aspose.slides/hyperlinkcolorsource/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|equals(hlink)|Determines whether the two Hyperlink instances are equal.|
