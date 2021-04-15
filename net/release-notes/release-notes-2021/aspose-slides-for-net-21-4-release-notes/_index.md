---
title: Aspose.Slides for .NET 21.4 Release Notes
type: docs
weight: 30
url: /net/aspose-slides-for-net-21-4-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for .NET 21.4](https://www.nuget.org/packages/Aspose.Slides.NET/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESNET-42393|The PDF generated is of huge size comparing to presentaion|Investigation|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/#convert-powerpoint-to-pdf-with-custom-options>
|SLIDESNET-41895|Support for CompoundFile management in Aspose.Slides|Feature|<https://docs.aspose.com/slides/net/manage-ole/>
|SLIDESNET-41258|Ability to create 2D shapes with complex path|Feature|<https://docs.aspose.com/slides/net/custom-shape/>
|SLIDESNET-39022|Support for getting coordinates for callout shapes|Feature|<https://docs.aspose.com/slides/net/custom-shape/>
|SLIDESNET-34362|Support for drawing freeform or sketch using Aspose.Slides|Feature|<https://docs.aspose.com/slides/net/custom-shape/>
|SLIDESNET-30876|3-D effects on shapes are lost in exported PDF, TIFF|Feature|<https://docs.aspose.com/slides/net/3d-presentation/>
|SLIDESNET-42457|Extend SlideUtil.AlignShape() to support alignment within GroupShape|Enhancement|<https://docs.aspose.com/slides/net/custom-shape/>
|SLIDESNET-42407|Constant size of slide text array from a presentation text|Enhancement|<https://docs.aspose.com/slides/net/extract-text-from-presentation/#categorized-and-fast-text-extraction>
|SLIDESNET-42191|Embedded font cannot be installed in resaved presentation|Enhancement|<https://docs.aspose.com/slides/net/embedded-font/>
|SLIDESNET-41047|Add clone taking long time |Enhancement|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-35644|Unable to modify the GraphicsPath of shapes|Enhancement|<https://docs.aspose.com/slides/net/custom-shape/>
|SLIDESNET-42511|Continuation ticket of SLIDESNET-42404 - Aspose.Slides aborts on files with .EMF content|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42501|Failure on Loading Presentation File|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42496|Issue with TextAutofitType|Bug|<https://docs.aspose.com/slides/net/text-formatting/>
|SLIDESNET-42495|Repair message when loading and saving a file |Bug|<https://docs.aspose.com/slides/net/save-presentation/>
|SLIDESNET-42494|Modified OLE Excel file cannot be opened in PowerPoint on double clicking|Bug|<https://docs.aspose.com/slides/net/manage-ole/>
|SLIDESNET-42487|Incorrect rendering of PPTX SmartArt shapes in PDF|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42484|Tables in PDF out are not showing|Bug|< https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42476|PptxReadException while attempting to open PPTX file|Bug|<https://docs.aspose.com/slides/net/open-presentation/>
|SLIDESNET-42475|Wrong portion coordinates|Bug|<https://docs.aspose.com/slides/net/portion/#get-position-coordinates-of-portion>
|SLIDESNET-42473|NullReferenceException while trying to save Shape to SVG format|Bug|<https://docs.aspose.com/slides/net/shape-manipulations/#render-shape-as-svg>
|SLIDESNET-42469|Color changes on image when slide is exported|Bug|<https://docs.aspose.com/slides/net/convert-slide/>
|SLIDESNET-42468|Repair message after cloning attached|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-42465|Charts are not showing on some slides|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-42460|Aspose.Slides 21.2: Object reference not set to an instance of an object.|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-42435|Chart missing in generated Thumbnail|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-42434|Table borders incorrectly cloned|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-42429|Audio setting seems to be wrong|Bug|<https://docs.aspose.com/slides/net/audio-frame/>
|SLIDESNET-42428|AutoShapes in presentation are cropped when are exported to SVG|Bug|<https://docs.aspose.com/slides/net/shape-manipulations/#render-shape-as-svg>
|SLIDESNET-42427|Image shrinks when converting a PowerPoint into a PDF|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/>
|SLIDESNET-42409|PPTX - Slide clonning is not correct|Bug|<https://docs.aspose.com/slides/net/clone-slides/>
|SLIDESNET-42386|Font embedding doesn?t work with all font files|Bug|<https://docs.aspose.com/slides/net/embedded-font/>
|SLIDESNET-42371|Aspose.Slides for Java failed to open pptx file containing Chart|Bug|<https://docs.aspose.com/slides/net/powerpoint-charts/>
|SLIDESNET-42283|Can no longer use IFilter to extract text from pptx documents saved by Slides.NET 20.3 and later|Bug|<https://docs.aspose.com/slides/net/save-presentation/#save-presentation-to-file>
|SLIDESNET-42203|Low quality gradient shape in generated thumbnail|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-jpg/>
|SLIDESNET-42154|Text is improperly rendered in generated thumbnail|Bug|<https://docs.aspose.com/slides/net/convert-powerpoint-ppt-and-pptx-to-jpg/>
|SLIDESNET-39946|Pptx to Thumbnail not properly converted|Bug|<https://docs.aspose.com/slides/net/convert-slide/#convert-slide-to-bitmap>
|SLIDESNET-35673|Shape content does not change in scaled shape thumbnail|Bug|<https://docs.aspose.com/slides/net/create-shape-thumbnails/>

== Public API Changes ==

=== IAudioFrame.PlayAcrossSlides and IAudioFrame.RewindAudio properties have been added ===

=== InClickSequence value has been added to AudioPlayModePreset enumeration ===

=== InClickSequence value has been added to VideoPlayModePreset enumeration ===

=== IOleObjectFrame.SetEmbeddedData method and IOleObjectFrame.EmbeddedData property have been added ===

=== New overloadings for the SlideUtil.AlignShapes method have been added ===