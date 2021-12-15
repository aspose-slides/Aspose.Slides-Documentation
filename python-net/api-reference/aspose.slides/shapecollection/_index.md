---
title: ShapeCollection Class
type: docs
weight: 3590
url: /slides/python-net/api-reference/aspose.slides/shapecollection/
---

Represents a collection of a shapes.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ShapeCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ShapeCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|parent_group|Returns parent GroupShape object for a shapes collection.<br/>            Read-only [IGroupShape](/python-net/api-reference/aspose.slides/igroupshape/).|
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the element at the specified index.<br/>            Read-only [IShape](/python-net/api-reference/aspose.slides/ishape/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_chart(type, x, y, width, height)|Creates a new Chart, initialize it with sample series data and settings and adds <br/>            it to the end of the collection.|
|add_chart(type, x, y, width, height, init_with_sample)|Creates a new Chart and adds it to the end of the collection.|
|insert_chart(type, x, y, width, height, index)|Creates a new Chart, initialize it with sample series data and settings and inserts <br/>            it to the specified position in the collection.|
|insert_chart(type, x, y, width, height, index, init_with_sample)|Creates a new Chart and inserts it to the specified position in the collection.|
|add_zoom_frame(x, y, width, height, slide)|Adds a new Zoom object to the end of a collection.|
|add_zoom_frame(x, y, width, height, slide, image)|Adds a new Zoom object to the end of a collection.|
|insert_zoom_frame(index, x, y, width, height, slide)|Creates a new Zoom object and inserts it to a collection at the specified index.|
|insert_zoom_frame(index, x, y, width, height, slide, image)|Creates a new Zoom object and inserts it to a collection at the specified index.|
|add_ole_object_frame(x, y, width, height, data_info)|Adds a new OLE object to the end of a collection.|
|add_ole_object_frame(x, y, width, height, class_name, path)|Adds a new OLE object to the end of a collection.|
|insert_ole_object_frame(index, x, y, width, height, data_info)|Creates a new OLE object and inserts it to a collection at the specified index.|
|insert_ole_object_frame(index, x, y, width, height, class_name, path)|Creates a new OLE object and inserts it to a collection at the specified index.|
|add_video_frame(x, y, width, height, fname)|Adds a new video frame to the end of a collection.|
|add_video_frame(x, y, width, height, video)|Adds a new video frame to the end of a collection.|
|add_audio_frame_embedded(x, y, width, height, audio_stream)|Adds a new audio frame with embedded audio file to the end of a collection.<br/>            Embedded audio file can be a WAV only.<br/>            It adds new audio into Presentation.Audios list.|
|add_audio_frame_embedded(x, y, width, height, audio)|Adds a new audio frame with embedded audio file to the end of a collection.<br/>            It uses audio file from Presentation.Audios list.|
|insert_audio_frame_embedded(index, x, y, width, height, audio_stream)|Insert an AudioFrame with embedded audio file.<br/>            Embedded audio file sound can be a WAV only.|
|insert_audio_frame_embedded(index, x, y, width, height, audio)|Insert an AudioFrame with embedded audio file.<br/>            It uses audio file from Presentation.Audios list.|
|to_array()|Creates and returns an array with all shapse in it.|
|to_array(start_index, count)|Creates and returns an array with all shapes from the specified range in it.|
|reorder(index, shape)|Moves a shape from the collection to the specified position.|
|reorder(index, shapes)|Moves shapes from the collection to the specified position.<br/>            Shapes will be placed starting from index in order they appear in list.|
|add_auto_shape(shape_type, x, y, width, height)|Creates a new AutoShape, tunes it from default template and adds it to the end of the collection.|
|add_auto_shape(shape_type, x, y, width, height, create_from_template)|Creates a new AutoShape and adds it to the end of the collection.|
|insert_auto_shape(index, shape_type, x, y, width, height)|Creates a new AutoShape, tunes it from default template and inserts it to <br/>            the collection at the specified index.<br/>            Note: the type of the shape will be determined by the shapeType parameter.|
|insert_auto_shape(index, shape_type, x, y, width, height, create_from_template)|Creates a new AutoShape and inserts it to the collection at the specified index.<br/>            Note: the type of the shape will be determined by the shapeType parameter.|
|add_group_shape()|Creates a new GroupShape and adds it to the end of the collection.<br/>            GroupShape frame size and position will be fitted to content when new shape will be added into the GroupShape.|
|add_group_shape(svg_image, x, y, width, height)|Creates a new GroupShape, fills it with converted shapes from SVG and adds it to the end of the collection.|
|add_connector(shape_type, x, y, width, height)|Creates a new Connector, tunes it from default template and adds it to the end of the collection.|
|add_connector(shape_type, x, y, width, height, create_from_template)|Creates a new Connector and adds it to the end of the collection.|
|insert_connector(index, shape_type, x, y, width, height)|Creates a new Connector, tunes it from default template and inserts it to <br/>            the collection at the specified index.|
|insert_connector(index, shape_type, x, y, width, height, create_from_template)|Creates a new Connector and inserts it to the collection at the specified index.|
|add_clone(source_shape, x, y, width, height)|Adds a copy of a specified shape to the end of the collection.|
|add_clone(source_shape, x, y)|Adds a copy of a specified shape to the end of the collection.|
|add_clone(source_shape)|Adds a copy of a specified shape to the end of the collection.|
|insert_clone(index, source_shape, x, y, width, height)|Inserts a copy of a specified shape to specified position of the collection.|
|insert_clone(index, source_shape, x, y)|Inserts a copy of a specified shape to specified position of the collection.|
|insert_clone(index, source_shape)|Inserts a copy of a specified shape to specified position of the collection.|
|add_smart_art(x, y, width, height, layout_type)|Add SmartArt diagram.|
|insert_video_frame(index, x, y, width, height, fname)|Creates a new video frame and inserts it to a collection at the specified index.|
|add_audio_frame_cd(x, y, width, height)|Adds an AudioFrame with CD to the end of collection.|
|insert_audio_frame_cd(index, x, y, width, height)|Insert an AudioFrame with CD.|
|add_audio_frame_linked(x, y, width, height, fname)|Adds a new audio frame with linked audio file to the end of a collection.|
|insert_audio_frame_linked(index, x, y, width, height, fname)|Creates a new audio frame with linked audio file and inserts it to a collection at the specified index.|
|index_of(shape)|Returns the zero-based index of the first occurrence of a shape in the collection.|
|add_math_shape(x, y, width, height)|Creates a new Autoshape tuned from default template to math content and adds it to the end of the collection.|
|insert_group_shape(index)|Creates a new GroupShape and inserts it to the collection at the specified index.<br/>            GroupShape frame size and position will be fitted to content when new shape will be added into the GroupShape.|
|add_picture_frame(shape_type, x, y, width, height, image)|Creates a new PictureFrame and adds it to the end of the collection.|
|insert_picture_frame(index, shape_type, x, y, width, height, image)|Creates a new PictureFrame and inserts it to the collection at the specified index.|
|add_table(x, y, column_widths, row_heights)|Creates a new Table and adds it to the end of the collection.|
|insert_table(index, x, y, column_widths, row_heights)|Creates a new Table and inserts it to the collection at the specified index.|
|remove_at(index)|Removes the element at the specified index of the collection.|
|remove(shape)|Removes the first occurrence of a specific shape from the collection.|
|clear()|Removes all shapes from the collection.|
