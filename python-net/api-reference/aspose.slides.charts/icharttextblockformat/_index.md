---
title: IChartTextBlockFormat Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 690
url: /python-net/api-reference/aspose.slides.charts/icharttextblockformat/
---

Represents formatting properties for chart text elements.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IChartTextBlockFormat

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IChartTextBlockFormat type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|anchoring_type|Returns or sets vertical anchor text in a TextFrame.<br/>            Read/write [TextAnchorType](/python-net/api-reference/aspose.slides/textanchortype/).|
|center_text|If NullableBool.True then text should be centered in box horizontally.<br/>            Read/write [NullableBool](/python-net/api-reference/aspose.slides/nullablebool/).|
|text_vertical_type|Determines text orientation.<br/>            The resulted value of visual text rotation summarized from this property and custom angle<br/>            in property RotationAngle.<br/>            Read/write [TextVerticalType](/python-net/api-reference/aspose.slides/textverticaltype/).|
|margin_left|Returns or sets the left margin (points) in a TextFrame.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).<br/>            Read/write float.|
|margin_right|Returns or sets the right margin (points) in a TextFrame.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).<br/>            Read/write float.|
|margin_top|Returns or sets the top margin (points) in a TextFrame.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).<br/>            Read/write float.|
|margin_bottom|Returns or sets the bottom margin (points) in a TextFrame.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).<br/>            Read/write float.|
|wrap_text|True if text is wrapped at TextFrame's margins.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2007/2013).<br/>            Read/write [NullableBool](/python-net/api-reference/aspose.slides/nullablebool/).|
|autofit_type|Returns or sets text's autofit mode.<br/>            Changing of this property can produce a certain influence only for these chart parts: <br/>            DataLabel and DataLabelFormat (full suport in PowerPoint 2013; in PowerPoint 2007 there is no effect for rendering).<br/>            Read/write [TextAutofitType](/python-net/api-reference/aspose.slides/textautofittype/).|
|rotation_angle|Specifies the custom rotation that is being applied to the text within the bounding box. If it not<br/>            specified, the rotation of the accompanying shape is used. If it is specified, then this is<br/>            applied independently from the shape. That is the shape can have a rotation applied in<br/>            addition to the text itself having a rotation applied to it.<br/>            The resulted value of visual text rotation summarized from this property and predefined<br/>            vertical type in property TextVerticalType.<br/>            Read/write|
