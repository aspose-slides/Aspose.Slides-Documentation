---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 3170
url: /python-net/api-reference/aspose.slides/oleobjectframe/
---

Represents an OLE object on a slide.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.OleObjectFrame

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The OleObjectFrame type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|is_text_holder|Determines whether the shape is TextHolder.<br/>            Read-only bool.|
|placeholder|Returns the placeholder for a shape.<br/>            Read-only [IPlaceholder](/python-net/api-reference/aspose.slides/iplaceholder/).|
|custom_data|Returns the shape's custom data.<br/>            Read-only [ICustomData](/python-net/api-reference/aspose.slides/icustomdata/).|
|raw_frame|Returns or sets the raw shape frame's properties.<br/>            Read/write [IShapeFrame](/python-net/api-reference/aspose.slides/ishapeframe/).|
|frame|Returns or sets the shape frame's properties.<br/>            Read/write [IShapeFrame](/python-net/api-reference/aspose.slides/ishapeframe/).|
|line_format|Returns the LineFormat object that contains line formatting properties for a shape.<br/>            Read-only [ILineFormat](/python-net/api-reference/aspose.slides/ilineformat/).|
|three_dformat|Returns the ThreeDFormat object that contains line formatting properties for a shape.<br/>            Read-only [IThreeDFormat](/python-net/api-reference/aspose.slides/ithreedformat/).|
|effect_format|Returns the EffectFormat object which contains pixel effects applied to a shape.<br/>            Read-only [IEffectFormat](/python-net/api-reference/aspose.slides/ieffectformat/).|
|fill_format|Returns the FillFormat object that contains fill formatting properties for a shape.<br/>            Read-only [IFillFormat](/python-net/api-reference/aspose.slides/ifillformat/).|
|hyperlink_click|Returns or sets the hyperlink defined for mouse click.<br/>            Read/write [IHyperlink](/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_mouse_over|Returns or sets the hyperlink defined for mouse over.<br/>            Read/write [IHyperlink](/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_manager|Hyperlinks manager<br/>            Read-only [IHyperlinkManager](/python-net/api-reference/aspose.slides/ihyperlinkmanager/).|
|hidden|Determines whether the shape is hidden.<br/>            Read/write bool.|
|zorder_position|Returns the position of a shape in the z-order.<br/>            Shapes[0] returns the shape at the back of the z-order,<br/>            and Shapes[Shapes.Count - 1] returns the shape at the front of the z-order.<br/>            Read-only|
|connection_site_count|Returns the number of connection sites on the shape.<br/>            Read-only|
|rotation|Returns or sets the number of degrees the specified shape is rotated around<br/>            the z-axis. A positive value indicates clockwise rotation; a negative value<br/>            indicates counterclockwise rotation.<br/>            Read/write|
|x|Returns or sets the x-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|y|Returns or sets the y-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|width|Returns or sets the width of the shape.<br/>            Read/write|
|height|Returns or sets the height of the shape.<br/>            Read/write|
|black_white_mode|Property specifies how a shape will render in black-and-white display mode..<br/>            Read/write [BlackWhiteMode](/python-net/api-reference/aspose.slides/blackwhitemode/).|
|unique_id|Gets unique shape identifier in presentation scope.<br/>            Read-only int.<br/>            See also [office_interop_shape_id](/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in slide scope.|
|office_interop_shape_id|Gets unique shape identifier in slide scope.<br/>            Read-only int.<br/>            See also [unique_id](/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in presentation scope.|
|alternative_text|Returns or sets the alternative text associated with a shape.<br/>            Read/write string.|
|alternative_text_title|Returns or sets the title of alternative text associated with a shape.<br/>            Read/write string.|
|name|Returns or sets the name of a shape.<br/>            Read/write string.|
|shape_lock|Returns shape's locks.<br/>            Read-only [IGraphicalObjectLock](/python-net/api-reference/aspose.slides/igraphicalobjectlock/).|
|is_grouped|Determines whether the shape is grouped.<br/>            Read-only bool.|
|parent_group|Returns parent GroupShape object if shape is grouped. Otherwise returns null.<br/>            Read-only [IGroupShape](/python-net/api-reference/aspose.slides/igroupshape/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
|graphical_object_lock|Returns shape's locks.<br/>            Read-only [IGraphicalObjectLock](/python-net/api-reference/aspose.slides/igraphicalobjectlock/).|
|substitute_picture_format|Returns OleObject image fill properties object.<br/>            Read-only [IPictureFillFormat](/python-net/api-reference/aspose.slides/ipicturefillformat/).|
|substitute_picture_title|Returns or sets the title for OleObject icon.<br/>            Read/write string.|
|object_name|Returns or sets the name of an object.<br/>            Read/write string.|
|object_prog_id|Returns the ProgID of an object.<br/>            Read only string.|
|object_data|Returns or sets embedded object as byte array.<br/>            Read/write int[].|
|link_file_name|Returns the full path to a linked file. Short file name will be used.<br/>            Read-only string.|
|link_path_long|Returns the full path to a linked file. Long file name will be used.<br/>            Read/write string.|
|embedded_file_label|Returns the file name of embedded OLE object|
|embedded_file_name|Returns the path of embedded OLE object|
|embedded_file_extension|Returns the file extension for the current embedded object or empty string if object is not a link|
|embedded_file_data|Returns the file data of embedded OLE object|
|embedded_data|Gets or sets information about OLE embedded data.<br/>            Read/write [IOleEmbeddedDataInfo](/python-net/api-reference/aspose.slides/ioleembeddeddatainfo/).|
|is_object_icon|Determines whether an object is visible as icon.<br/>            Read/write bool.|
|is_object_link|Determines whether an object is linked to external file.<br/>            Read-only bool.|
|as_igraphical_object|Allows to get base IGraphicalObject interface.<br/>            Read-only [IGraphicalObject](/python-net/api-reference/aspose.slides/igraphicalobject/).|
|update_automatic|Determines if the linked embedded object is automatically updated when the presentation is opened or printed.<br/>            Read/write bool.|
|as_ihyperlink_container|Allows to get base IHyperlinkContainer interface.<br/>            Read-only [IHyperlinkContainer](/python-net/api-reference/aspose.slides/ihyperlinkcontainer/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|as_ishape|Allows to get base IShape interface.<br/>            Read-only [IShape](/python-net/api-reference/aspose.slides/ishape/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_thumbnail()|Returns shape thumbnail.<br/>            ShapeThumbnailBounds.Shape shape thumbnail bounds type is used by default.|
|get_thumbnail(bounds, scale_x, scale_y)|Returns shape thumbnail.|
|write_as_svg(stream)|Saves content of Shape as SVG file.|
|write_as_svg(stream, svg_options)|Saves content of Shape as SVG file.|
|remove_placeholder()|Defines that this shape isn't a placeholder.|
|add_placeholder(placeholder_to_copy_from)|Adds a new placeholder if there is no and sets placeholder properties to a specified one.|
|set_embedded_data(embedded_data)|Sets information about OLE embedded data.|
