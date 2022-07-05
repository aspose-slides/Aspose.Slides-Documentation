---
title: IMasterSlide
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1890
url: /python-net/api-reference/aspose.slides/imasterslide/
---

## IMasterSlide class

Represents a master slide in a presentation.

The IMasterSlide type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|header_footer_manager|Returns HeaderFooter manager of the master slide.<br/>            Read-only [IMasterSlideHeaderFooterManager](/slides/python-net/api-reference/aspose.slides/imasterslideheaderfootermanager/).|
|title_style|Returns the style of a title text.<br/>            Read-only [ITextStyle](/slides/python-net/api-reference/aspose.slides/itextstyle/).|
|body_style|Returns the style of a body text.<br/>            Read-only [ITextStyle](/slides/python-net/api-reference/aspose.slides/itextstyle/).|
|other_style|Returns the style of an other text.<br/>            Read-only [ITextStyle](/slides/python-net/api-reference/aspose.slides/itextstyle/).|
|layout_slides|Returns the collection of child layout slides for this master slide.<br/>            Read-only [IMasterLayoutSlideCollection](/slides/python-net/api-reference/aspose.slides/imasterlayoutslidecollection/).|
|preserve|Determines whether the corresponding master is deleted when all <br/>            the slides that follow that master are deleted.<br/>            Note: Aspose.Slides will never remove any unused master by itself, <br/>            to actually remove unused masters call|
|has_depending_slides|Returns true if there exists at least one slide that depends on this master slide.<br/>            Read-only bool.|
|as_ibase_slide|Allows to get base IBaseSlide interface.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_imaster_themeable|Returns IMasterThemeable interface.<br/>            Read-only [IMasterThemeable](/slides/python-net/api-reference/aspose.slides.theme/imasterthemeable/).|
|shapes|Returns the shapes of a slide.<br/>            Read-only [IShapeCollection](/slides/python-net/api-reference/aspose.slides/ishapecollection/).|
|controls|Returns the collection of ActiveX controls on a slide.<br/>            Read-only [IControlCollection](/slides/python-net/api-reference/aspose.slides/icontrolcollection/).|
|name|Returns or sets the name of a slide.<br/>            Read/write string.|
|slide_id|Returns the ID of a slide.<br/>            Read-only int.|
|custom_data|Returns the slide's custom data.<br/>            Read-only [ICustomData](/slides/python-net/api-reference/aspose.slides/icustomdata/).|
|timeline|Returns animation timeline object.<br/>            Read-only [IAnimationTimeLine](/slides/python-net/api-reference/aspose.slides/ianimationtimeline/).|
|slide_show_transition|Returns the TransitionEx object which contains information about<br/>            how the specified slide advances during a slide show.<br/>            Read-only [ISlideShowTransition](/slides/python-net/api-reference/aspose.slides/islideshowtransition/).|
|background|Returns slide's background.<br/>            Read-only [IBackground](/slides/python-net/api-reference/aspose.slides/ibackground/).|
|hyperlink_queries|Provides easy access to contained hyperlinks.<br/>            Read-only [IHyperlinkQueries](/slides/python-net/api-reference/aspose.slides/ihyperlinkqueries/).|
|show_master_shapes|Specifies if shapes on the master slide should be shown on slides or not.<br/>            For master slide itself this property always returns|
|as_islide_component|Returns ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|theme_manager|Returns master theme manager.<br/>            Read-only [IMasterThemeManager](/slides/python-net/api-reference/aspose.slides.theme/imasterthememanager/).|
## Methods
| Name | Description |
| :- | :- |
|apply_external_theme_to_depending_slides(fname)|Creates a new master slide based on the current one, applying an external theme to it <br/>            and applies the created master slide to all dependent slides.|
|get_depending_slides()|Returns an array with all slides, which depend on this master slide.|
|find_shape_by_alt_text(alt_text)|Finds first occurrence of a shape with the specified alternative text.|
|join_portions_with_same_formatting()|Joins runs with same formatting in all paragraphs in all acceptable shapes.|
|equals(slide)|Determines whether the two IBaseSlide instances are equal.<br/>            Returning value is calculated based on slide's structure and static content.<br/>            Two slides are equal if all shapes, styles, texts, animation and other settings. etc. are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.|
|create_theme_effective()|Returns an effective theme for this themeable object.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

