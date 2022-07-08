---
title: ITable
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 2680
url: /python-net/api-reference/aspose.slides/itable/
---

## ITable class

Represents a table on a slide.

The ITable type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|rows|Returns the collectoin of rows.<br/>            Read-only [IRowCollection](/slides/python-net/api-reference/aspose.slides/irowcollection/).|
|columns|Returns the collectoin of columns.<br/>            Read-only [IColumnCollection](/slides/python-net/api-reference/aspose.slides/icolumncollection/).|
|table_format|Returns the TableFormat object that contains formatting properties for this table.<br/>            Read-only [ITableFormat](/slides/python-net/api-reference/aspose.slides/itableformat/).|
|style_preset|Get's or sets builtin table style.<br/>            Read/write [TableStylePreset](/slides/python-net/api-reference/aspose.slides/tablestylepreset/).|
|right_to_left|Determines whether the table has right to left reading order.<br/>            Read-write bool.|
|first_row|Determines whether the first row of a table has to be drawn with a special formatting.<br/>            Read/write bool.|
|first_col|Determines whether the first column of a table has to be drawn with a special formatting.<br/>            Read/write bool.|
|last_row|Determines whether the last row of a table has to be drawn with a special formatting.<br/>            Read/write bool.|
|last_col|Determines whether the last column of a table has to be drawn with a special formatting.<br/>            Read/write bool.|
|horizontal_banding|Determines whether the even rows has to be drawn with a different formatting.<br/>            Read/write bool.|
|vertical_banding|Determines whether the even columns has to be drawn with a different formatting.<br/>            Read/write bool.|
|as_i_graphical_object|Allows to get base IGraphicalObject interface.<br/>            Read-only [IGraphicalObject](/slides/python-net/api-reference/aspose.slides/igraphicalobject/).|
|as_i_bulk_text_formattable|Allows to get base IBulkTextFormattable interface.<br/>            Read-only [IBulkTextFormattable](/slides/python-net/api-reference/aspose.slides/ibulktextformattable/).|
|shape_lock|Returns shape's locks.<br/>            Read-only [IBaseShapeLock](/slides/python-net/api-reference/aspose.slides/ibaseshapelock/).|
|graphical_object_lock|Returns shape's locks.<br/>            Read-only [IGraphicalObjectLock](/slides/python-net/api-reference/aspose.slides/igraphicalobjectlock/).|
|as_i_shape|Allows to get base IShape interface.<br/>            Read-only [IShape](/slides/python-net/api-reference/aspose.slides/ishape/).|
|is_text_holder|Determines whether the shape is TextHolder.<br/>            Read-only bool.|
|placeholder|Returns the placeholder for a shape.<br/>            Read-only [IPlaceholder](/slides/python-net/api-reference/aspose.slides/iplaceholder/).|
|custom_data|Returns the shape's custom data.<br/>            Read-only [ICustomData](/slides/python-net/api-reference/aspose.slides/icustomdata/).|
|raw_frame|Returns or sets the raw shape frame's properties.<br/>            Read/write [IShapeFrame](/slides/python-net/api-reference/aspose.slides/ishapeframe/).|
|frame|Returns or sets the shape frame's properties.<br/>            Read/write [IShapeFrame](/slides/python-net/api-reference/aspose.slides/ishapeframe/).|
|line_format|Returns the LineFormat object that contains line formatting properties for a shape.<br/>            Read-only [ILineFormat](/slides/python-net/api-reference/aspose.slides/ilineformat/).|
|three_d_format|Returns the ThreeDFormat object that contains line formatting properties for a shape.<br/>            Read-only [IThreeDFormat](/slides/python-net/api-reference/aspose.slides/ithreedformat/).|
|effect_format|Returns the EffectFormat object which contains pixel effects applied to a shape.<br/>            Read-only [IEffectFormat](/slides/python-net/api-reference/aspose.slides/ieffectformat/).|
|fill_format|Returns the FillFormat object that contains fill formatting properties for a shape.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|hidden|Determines whether the shape is hidden.<br/>            Read/write bool.|
|z_order_position|Returns the position of a shape in the z-order.<br/>            Shapes[0] returns the shape at the back of the z-order,<br/>            and Shapes[Shapes.Count - 1] returns the shape at the front of the z-order.<br/>            Read-only|
|connection_site_count|Returns the number of connection sites on the shape.<br/>            Read-only|
|rotation|Returns or sets the number of degrees the specified shape is rotated around<br/>            the z-axis. A positive value indicates clockwise rotation; a negative value<br/>            indicates counterclockwise rotation.<br/>            Read/write|
|x|Returns or sets the x-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|y|Returns or sets the y-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|width|Returns or sets the width of the shape.<br/>            Read/write|
|height|Returns or sets the height of the shape.<br/>            Read/write|
|alternative_text|Returns or sets the alternative text associated with a shape.<br/>            Read/write string.|
|alternative_text_title|Returns or sets the title of alternative text associated with a shape.<br/>            Read/write string.|
|name|Returns or sets the name of a shape.<br/>            Read/write string.|
|unique_id|Gets unique shape identifier in presentation scope.<br/>            Read-only int.<br/>            See also [office_interop_shape_id](/slides/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in slide scope.|
|office_interop_shape_id|Gets unique shape identifier in slide scope.<br/>            Read-only int.<br/>            See also [unique_id](/slides/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in presentation scope.|
|is_grouped|Determines whether the shape is grouped.<br/>            Read-only bool.|
|black_white_mode|Property specifies how a shape will render in black-and-white display mode..<br/>            Read/write [BlackWhiteMode](/slides/python-net/api-reference/aspose.slides/blackwhitemode/).|
|parent_group|Returns parent GroupShape object if shape is grouped. Otherwise returns null.<br/>            Read-only [IGroupShape](/slides/python-net/api-reference/aspose.slides/igroupshape/).|
|as_i_hyperlink_container|Allows to get base IHyperlinkContainer interface.<br/>            Read-only [IHyperlinkContainer](/slides/python-net/api-reference/aspose.slides/ihyperlinkcontainer/).|
|as_i_slide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|hyperlink_click|Returns or sets the hyperlink defined for mouse click.<br/>            Read/write [IHyperlink](/slides/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_mouse_over|Returns or sets the hyperlink defined for mouse over.<br/>            Read/write [IHyperlink](/slides/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_manager|Hyperlinks manager<br/>            Read-only [IHyperlinkManager](/slides/python-net/api-reference/aspose.slides/ihyperlinkmanager/).|
## Methods
| Name | Description |
| :- | :- |
|get_thumbnail()|Returns shape thumbnail.<br/>            ShapeThumbnailBounds.Shape shape thumbnail bounds type is used by default.|
|get_thumbnail(bounds, scale_x, scale_y)|Returns shape thumbnail.|
|write_as_svg(stream)|Saves content of Shape as SVG file.|
|write_as_svg(stream, svg_options)|Saves content of Shape as SVG file.|
|set_text_format(source)|Sets defined portion format properties to all element's portions.|
|set_text_format(source)|Sets defined paragraph format properties to all element's paragraphs.|
|set_text_format(source)|Sets defined text frame format properties to all element's text frames.|
|merge_cells(cell1, cell2, allow_splitting)|Merges neighbour cells.|
|add_placeholder(placeholder_to_copy_from)|Adds a new placeholder if there is no and sets placeholder properties to a specified one.|
|remove_placeholder()|Defines that this shape isn't a placeholder.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

