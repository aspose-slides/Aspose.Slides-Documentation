---
title: IAudioFrame Class
type: docs
weight: 800
url: /python-net/api-reference/aspose.slides/iaudioframe/
---

Represents an audio clip on a slide.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IAudioFrame

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IAudioFrame type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|audio_cd_start_track|Returns or sets a start track index.<br/>            Read/write|
|audio_cd_start_track_time|Returns or sets a start track time.<br/>            Read/write|
|audio_cd_end_track|Returns or sets a last track index<br/>            Read/write|
|audio_cd_end_track_time|Returns or sets a last track time.<br/>            Read/write|
|volume|Returns or sets the audio volume.<br/>            Read/write [AudioVolumeMode](/python-net/api-reference/aspose.slides/audiovolumemode/).|
|play_mode|Returns or sets the audio play mode.<br/>            Read/write [AudioPlayModePreset](/python-net/api-reference/aspose.slides/audioplaymodepreset/).|
|hide_at_showing|Determines whether an AudioFrame is hidden.<br/>            Read/write bool.|
|play_loop_mode|Determines whether an audio is looped.<br/>            Read/write bool.|
|play_across_slides|Determines whether an audio is playing across the slides.<br/>             Read/write bool.|
|rewind_audio|Determines whether an audio is automatically rewinded to start after playing.<br/>             Read/write bool.|
|embedded|Determines whether a sound is embedded to a presentation.<br/>            Read-only bool.|
|link_path_long|Returns or sets the name of an audio file which is linked to an AudioFrame.<br/>            Read/write string.|
|embedded_audio|Returns or sets embedded audio object.<br/>            Read/write [IAudio](/python-net/api-reference/aspose.slides/iaudio/).|
|as_ipicture_frame|Allows to get base IPictureFrame interface.<br/>            Read-only [IPictureFrame](/python-net/api-reference/aspose.slides/ipictureframe/).|
|shape_lock|Returns shape's locks.<br/>            Read-only [IBaseShapeLock](/python-net/api-reference/aspose.slides/ibaseshapelock/).|
|picture_frame_lock|Returns PictureFrame's locks.<br/>            Read-only [IPictureFrameLock](/python-net/api-reference/aspose.slides/ipictureframelock/).|
|picture_format|Returns the PictureFillFormat object for a picture frame.<br/>            Read-only [IPictureFillFormat](/python-net/api-reference/aspose.slides/ipicturefillformat/).|
|relative_scale_height|Returns or sets the scale of height(relative to original picture size) of the picture frame. Value 1.0 corresponds to 100%.<br/>            Read/write|
|relative_scale_width|Returns or sets the scale of width (relative to original picture size) of the picture frame. Value 1.0 corresponds to 100%.<br/>            Read/write|
|as_igeometry_shape|Allows to get base IGeometryShape interface.<br/>            Read-only [IGeometryShape](/python-net/api-reference/aspose.slides/igeometryshape/).|
|shape_style|Returns shape's style object.<br/>            Read-only [IShapeStyle](/python-net/api-reference/aspose.slides/ishapestyle/).|
|shape_type|Returns or sets the geometry preset type.<br/>            Note: on value changing all adjustment values will reset to their default values.<br/>            Read/write [ShapeType](/python-net/api-reference/aspose.slides/shapetype/).|
|adjustments|Returns a collection of shape's adjustment values.<br/>            Read-only [IAdjustValueCollection](/python-net/api-reference/aspose.slides/iadjustvaluecollection/).|
|as_ishape|Allows to get base IShape interface.<br/>            Read-only [IShape](/python-net/api-reference/aspose.slides/ishape/).|
|is_text_holder|Determines whether the shape is TextHolder.<br/>            Read-only bool.|
|placeholder|Returns the placeholder for a shape.<br/>            Read-only [IPlaceholder](/python-net/api-reference/aspose.slides/iplaceholder/).|
|custom_data|Returns the shape's custom data.<br/>            Read-only [ICustomData](/python-net/api-reference/aspose.slides/icustomdata/).|
|raw_frame|Returns or sets the raw shape frame's properties.<br/>            Read/write [IShapeFrame](/python-net/api-reference/aspose.slides/ishapeframe/).|
|frame|Returns or sets the shape frame's properties.<br/>            Read/write [IShapeFrame](/python-net/api-reference/aspose.slides/ishapeframe/).|
|line_format|Returns the LineFormat object that contains line formatting properties for a shape.<br/>            Read-only [ILineFormat](/python-net/api-reference/aspose.slides/ilineformat/).|
|three_dformat|Returns the ThreeDFormat object that contains line formatting properties for a shape.<br/>            Read-only [IThreeDFormat](/python-net/api-reference/aspose.slides/ithreedformat/).|
|effect_format|Returns the EffectFormat object which contains pixel effects applied to a shape.<br/>            Read-only [IEffectFormat](/python-net/api-reference/aspose.slides/ieffectformat/).|
|fill_format|Returns the FillFormat object that contains fill formatting properties for a shape.<br/>            Read-only [IFillFormat](/python-net/api-reference/aspose.slides/ifillformat/).|
|hidden|Determines whether the shape is hidden.<br/>            Read/write bool.|
|zorder_position|Returns the position of a shape in the z-order.<br/>            Shapes[0] returns the shape at the back of the z-order,<br/>            and Shapes[Shapes.Count - 1] returns the shape at the front of the z-order.<br/>            Read-only|
|connection_site_count|Returns the number of connection sites on the shape.<br/>            Read-only|
|rotation|Returns or sets the number of degrees the specified shape is rotated around<br/>            the z-axis. A positive value indicates clockwise rotation; a negative value<br/>            indicates counterclockwise rotation.<br/>            Read/write|
|x|Returns or sets the x-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|y|Returns or sets the y-coordinate of the upper-left corner of the shape.<br/>            Read/write|
|width|Returns or sets the width of the shape.<br/>            Read/write|
|height|Returns or sets the height of the shape.<br/>            Read/write|
|alternative_text|Returns or sets the alternative text associated with a shape.<br/>            Read/write string.|
|alternative_text_title|Returns or sets the title of alternative text associated with a shape.<br/>            Read/write string.|
|name|Returns or sets the name of a shape.<br/>            Read/write string.|
|unique_id|Gets unique shape identifier in presentation scope.<br/>            Read-only int.<br/>            See also [office_interop_shape_id](/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in slide scope.|
|office_interop_shape_id|Gets unique shape identifier in slide scope.<br/>            Read-only int.<br/>            See also [unique_id](/python-net/api-reference/aspose.slides/ishape/) for getting unique shape identifier in presentation scope.|
|is_grouped|Determines whether the shape is grouped.<br/>            Read-only bool.|
|black_white_mode|Property specifies how a shape will render in black-and-white display mode..<br/>            Read/write [BlackWhiteMode](/python-net/api-reference/aspose.slides/blackwhitemode/).|
|parent_group|Returns parent GroupShape object if shape is grouped. Otherwise returns null.<br/>            Read-only [IGroupShape](/python-net/api-reference/aspose.slides/igroupshape/).|
|as_ihyperlink_container|Allows to get base IHyperlinkContainer interface.<br/>            Read-only [IHyperlinkContainer](/python-net/api-reference/aspose.slides/ihyperlinkcontainer/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
|hyperlink_click|Returns or sets the hyperlink defined for mouse click.<br/>            Read/write [IHyperlink](/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_mouse_over|Returns or sets the hyperlink defined for mouse over.<br/>            Read/write [IHyperlink](/python-net/api-reference/aspose.slides/ihyperlink/).|
|hyperlink_manager|Hyperlinks manager<br/>            Read-only [IHyperlinkManager](/python-net/api-reference/aspose.slides/ihyperlinkmanager/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_thumbnail()|Returns shape thumbnail.<br/>            ShapeThumbnailBounds.Shape shape thumbnail bounds type is used by default.|
|get_thumbnail(bounds, scale_x, scale_y)|Returns shape thumbnail.|
|write_as_svg(stream)|Saves content of Shape as SVG file.|
|write_as_svg(stream, svg_options)|Saves content of Shape as SVG file.|
|get_geometry_paths()|Returns the copy of path of the geometry shape. Coordinates are relative to the left top corner of the shape.|
|set_geometry_path(geometry_path)|Updates shape geometry from [IGeometryPath](/python-net/api-reference/aspose.slides/igeometrypath/) object. Coordinates must be relative to the left<br/>             top corner of the shape.<br/>             Changes the type of the shape ([shape_type](/python-net/api-reference/aspose.slides/igeometryshape/)) to [CUSTOM](/python-net/api-reference/aspose.slides/shapetype/).|
|set_geometry_paths(geometry_paths)|Updates shape geometry from array of [IGeometryPath](/python-net/api-reference/aspose.slides/igeometrypath/). Coordinates must be relative to the left<br/>             top corner of the shape.<br/>             Changes the type of the shape ([shape_type](/python-net/api-reference/aspose.slides/igeometryshape/)) to [CUSTOM](/python-net/api-reference/aspose.slides/shapetype/).|
|create_shape_elements()|Creates and returns array of shape's elements.|
|add_placeholder(placeholder_to_copy_from)|Adds a new placeholder if there is no and sets placeholder properties to a specified one.|
|remove_placeholder()|Defines that this shape isn't a placeholder.|