---
title: Chart Class
type: docs
weight: 70
url: /python-net/api-reference/aspose.slides.charts/chart/
---

Represents an graphic chart on a slide.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.Chart

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The Chart type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|is_text_holder|Determines whether the shape is TextHolder.<br/>            Read-only bool.|
|placeholder|Returns the placeholder for a shape.<br/>            Read-only [IPlaceholder](/slides/python-net/api-reference/aspose.slides/iplaceholder/).|
|custom_data|Returns the shape's custom data.<br/>            Read-only [ICustomData](/slides/python-net/api-reference/aspose.slides/icustomdata/).|
|raw_frame|Returns or sets the raw shape frame's properties.<br/>            Read/write [IShapeFrame](/slides/python-net/api-reference/aspose.slides/ishapeframe/).|
|frame|Returns or sets the shape frame's properties.<br/>            Read/write [IShapeFrame](/slides/python-net/api-reference/aspose.slides/ishapeframe/).|
|line_format|Returns the LineFormat object that contains line formatting properties for a shape.<br/>            Read-only [ILineFormat](/slides/python-net/api-reference/aspose.slides/ilineformat/).|
|three_dformat|Returns the ThreeDFormat object that contains line formatting properties for a shape.<br/>            Read-only [IThreeDFormat](/slides/python-net/api-reference/aspose.slides/ithreedformat/).|
|effect_format|Returns the EffectFormat object which contains pixel effects applied to a shape.<br/>            Read-only [IEffectFormat](/slides/python-net/api-reference/aspose.slides/ieffectformat/).|
|fill_format|Returns the FillFormat object that contains fill formatting properties for a shape.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|hyperlink_click|Returns or sets the hyperlink defined for mouse click.<br/>            Read/write [IHyperlink](/slides/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_mouse_over|Returns or sets the hyperlink defined for mouse over.<br/>            Read/write [IHyperlink](/slides/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_manager|Hyperlinks manager<br/>            Read-only [IHyperlinkManager](/slides/python-net/api-reference/aspose.slides/ihyperlinkmanager/).|
|hidden|Determines whether the shape is hidden.<br/>            Read/write bool.|
|zorder_position|Returns the position of a shape in the z-order.<br/>            Shapes[0] returns the shape at the back of the z-order,<br/>            and Shapes[Shapes.Count - 1] returns the shape at the front of the z-order.<br/>            Read-only|
|connection_site_count|Returns the number of connection sites on the shape.<br/>            Read-only|
|rotation|Returns or sets the number of degrees the specified shape is rotated around<br/>            the z-axis. A positive value indicates clockwise rotation; a negative value<br/>            indicates counterclockwise rotation.<br/>            Read/write|
|x|Returns or sets the x-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|y|Returns or sets the y-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|width|Returns or sets the width of the shape.<br/>            Read/write|
|height|Returns or sets the height of the shape.<br/>            Read/write|
|black_white_mode|Property specifies how a shape will render in black-and-white display mode..<br/>            Read/write [BlackWhiteMode](/slides/python-net/api-reference/aspose.slides/blackwhitemode/).|
|unique_id|Gets unique shape identifier in presentation scope.<br/>            Read-only int.<br/>            See also [office_interop_shape_id](/slides/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in slide scope.|
|office_interop_shape_id|Gets unique shape identifier in slide scope.<br/>            Read-only int.<br/>            See also [unique_id](/slides/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in presentation scope.|
|alternative_text|Returns or sets the alternative text associated with a shape.<br/>            Read/write string.|
|alternative_text_title|Returns or sets the title of alternative text associated with a shape.<br/>            Read/write string.|
|name|Returns or sets the name of a shape.<br/>            Read/write string.|
|shape_lock|Returns shape's locks.<br/>            Read-only [IGraphicalObjectLock](/slides/python-net/api-reference/aspose.slides/igraphicalobjectlock/).|
|is_grouped|Determines whether the shape is grouped.<br/>            Read-only bool.|
|parent_group|Returns parent GroupShape object if shape is grouped. Otherwise returns null.<br/>            Read-only [IGroupShape](/slides/python-net/api-reference/aspose.slides/igroupshape/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|graphical_object_lock|Returns shape's locks.<br/>            Read-only [IGraphicalObjectLock](/slides/python-net/api-reference/aspose.slides/igraphicalobjectlock/).|
|plot_visible_cells_only|Determines whether the only visible cells are plotted. False to plot both visible and hidden cells.<br/>            Read/write bool.|
|display_blanks_as|Returns or sets the way to plot blank cells on a chart.<br/>            Read/write [DisplayBlanksAsType](/slides/python-net/api-reference/aspose.slides.charts/displayblanksastype/).|
|chart_data|Returns information about the linked or embedded data associated with a chart.<br/>            Read-only [IChartData](/slides/python-net/api-reference/aspose.slides.charts/ichartdata/).|
|has_title|Determines whether a chart has a visible title.<br/>            Read/write bool.|
|chart_title|Returns or sets a chart title.<br/>            Read-only [IChartTitle](/slides/python-net/api-reference/aspose.slides.charts/icharttitle/).|
|has_data_table|Determines whether a chart has a data table.<br/>            Read/write bool.|
|has_legend|Determines whether a chart has a legend.<br/>            Read/write bool.|
|legend|Returns or sets a legend for a chart.<br/>            Read-only [ILegend](/slides/python-net/api-reference/aspose.slides.charts/ilegend/).|
|chart_data_table|Returns a data table of a chart.<br/>            Read-only [IDataTable](/slides/python-net/api-reference/aspose.slides.charts/idatatable/).|
|style|Returns or sets the chart style.<br/>            Read/write [StyleType](/slides/python-net/api-reference/aspose.slides.charts/styletype/).|
|type|Returns or sets the chart type.<br/>            Read/write [ChartType](/slides/python-net/api-reference/aspose.slides.charts/charttype/).|
|plot_area|Represents the plot area of a chart.<br/>            Read-only [IChartPlotArea](/slides/python-net/api-reference/aspose.slides.charts/ichartplotarea/).|
|rotation3_d|Returns a 3D rotation of a chart.<br/>            Read-only [IRotation3D](/slides/python-net/api-reference/aspose.slides.charts/irotation3d/).|
|back_wall|Returns an object which allows to change format of the back wall of a 3D chart.<br/>            Read-only [IChartWall](/slides/python-net/api-reference/aspose.slides.charts/ichartwall/).|
|side_wall|Returns an object which allows to change format of the side wall of a 3D chart.<br/>            Read-only [IChartWall](/slides/python-net/api-reference/aspose.slides.charts/ichartwall/).|
|floor|Returns an object which allows to change format of the floor of a 3D chart.<br/>            Read-only [IChartWall](/slides/python-net/api-reference/aspose.slides.charts/ichartwall/).|
|text_format|Returns chart text format.<br/>            Read-only [IChartTextFormat](/slides/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|theme_manager|Returns theme manager.<br/>            Read-only [IOverrideThemeManager](/slides/python-net/api-reference/aspose.slides.theme/ioverridethememanager/).|
|user_shapes|Specify the shapes drawn on top of the chart.<br/>            Read-only [IGroupShape](/slides/python-net/api-reference/aspose.slides/igroupshape/).|
|axes|Provide access to chart axes.<br/>            Read-only [IAxesManager](/slides/python-net/api-reference/aspose.slides.charts/iaxesmanager/).|
|show_data_labels_over_maximum|Specifies data labels over the maximum of the chart shall be shown.<br/>            Read/write bool.|
|has_rounded_corners|Specifies the chart area shall have rounded corners.<br/>            Read/write bool.|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/slides/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|as_ithemeable|Allows to get base IThemeable interface.<br/>            Read-only [IThemeable](/slides/python-net/api-reference/aspose.slides.theme/ithemeable/).|
|as_ihyperlink_container|Allows to get base IHyperlinkContainer interface.<br/>            Read-only [IHyperlinkContainer](/slides/python-net/api-reference/aspose.slides/ihyperlinkcontainer/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|as_ishape|Allows to get base IShape interface.<br/>            Read-only [IShape](/slides/python-net/api-reference/aspose.slides/ishape/).|
|as_igraphical_object|Allows to get base IGraphicalObject interface.<br/>            Read-only [IGraphicalObject](/slides/python-net/api-reference/aspose.slides/igraphicalobject/).|
|as_ioverride_themeable|Returns IOverrideThemeable interface.<br/>            Read-only [IOverrideThemeable](/slides/python-net/api-reference/aspose.slides.theme/ioverridethemeable/).|
|as_ichart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|chart|Returns the chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_thumbnail()|Returns shape thumbnail.<br/>            ShapeThumbnailBounds.Shape shape thumbnail bounds type is used by default.|
|get_thumbnail(bounds, scale_x, scale_y)|Returns shape thumbnail.|
|write_as_svg(stream)|Saves content of Shape as SVG file.|
|write_as_svg(stream, svg_options)|Saves content of Shape as SVG file.|
|remove_placeholder()|Defines that this shape isn't a placeholder.|
|add_placeholder(placeholder_to_copy_from)|Adds a new placeholder if there is no and sets placeholder properties to a specified one.|
|validate_chart_layout()|Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface <br/>            (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight)<br/>            and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, <br/>            IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale)|
|create_theme_effective()|Returns an effective theme for this chart.|
