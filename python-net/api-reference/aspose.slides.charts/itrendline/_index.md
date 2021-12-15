---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 950
url: /python-net/api-reference/aspose.slides.charts/itrendline/
---

Class represents trend line of chart series

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.ITrendline

**Assembly:**  Aspose.Slides Version: 21.11.0.0

The ITrendline type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|trendline_name|Gets or sets  name of the trendline.<br/>            Read/write string.|
|trendline_type|Gets or sets type of trend line. <br/>            Read/write [trendline_type](/python-net/api-reference/aspose.slides.charts/itrendline/).|
|format|Represents the format of the trend line.<br/>            Read/write [IFormat](/python-net/api-reference/aspose.slides.charts/iformat/).|
|backward|Specifies the number of categories (or units on a scatter chart) that the trend line extends before<br/>            the data for the series that is being trended. On scatter and non-scatter charts, the value shall be any nonnegative<br/>            value.<br/>            Read/write float.|
|forward|Specifies the number of categories (or units on a scatter chart) that the trendline extends after the<br/>            data for the series that is being trended. On scatter and non-scatter charts, the value shall be any non-negative<br/>            value.<br/>            Read/write float.|
|intercept|Specifies the value where the trendline shall cross the y axis. This property shall be supported only<br/>            when the trendline type is exp, linear, or poly.<br/>            Read/write float.|
|display_equation|Specifies that the equation for the trendline is displayed on the chart (in the same label as the Rsquaredvalue).<br/>            Read/write bool.|
|order|Specifies the order of the polynomial trend line. It is ignored for other trend line types. Value must be between 2 and 6.<br/>            Read/write int.|
|period|Specifies the period of the trend line for a moving average trend line. It is ignored for other trend<br/>            line variants. Value must be between 2 and 255.<br/>            Read/write int.|
|display_rsquared_value|Specifies that the R-squared value of the trendline is displayed on the chart (in the same label as the equation).<br/>            Read/write bool.|
|related_legend_entry|Represents legend entry related with this trendline<br/>            Read-only [ILegendEntryProperties](/python-net/api-reference/aspose.slides.charts/ilegendentryproperties/).|
|as_ioverridable_text|Returns IOverridableText interface.<br/>            Read-only [IOverridableText](/python-net/api-reference/aspose.slides.charts/ioverridabletext/).|
|text_frame_for_overriding|Can contain a rich formatted text. If this property is not null then this <br/>            formatted text value overrides auto-generated text.<br/>            Auto-generated text is an implicit property of the data label, the display <br/>            unit label of the value axis, the axis title, the chart title, the label of the trendline.<br/>            Auto-generated text is formatted with the IFormattedTextContainer.TextFormat property.<br/>            Read-only [ITextFrame](/python-net/api-reference/aspose.slides/itextframe/).|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|text_format|Returns chart text format.<br/>            Read-only [IChartTextFormat](/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|as_ichart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|chart|Returns the chart.<br/>            Read-only [IChart](/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_text_frame_for_overriding(text)|Initialize TextFrameForOverriding with the text in paramener "text".<br/>            If TextFrameForOverriding is already initialized then simply changes its text.|
