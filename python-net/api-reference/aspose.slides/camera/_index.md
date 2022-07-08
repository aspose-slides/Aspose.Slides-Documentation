---
title: Camera
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 190
url: /python-net/api-reference/aspose.slides/camera/
---

## Camera class

Represents Camera.

The Camera type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|camera_type|Camera type.<br/>            Read/write [CameraPresetType](/slides/python-net/api-reference/aspose.slides/camerapresettype/).|
|field_of_view_angle|Camera FOV (0-180 deg, field of View).<br/>            Read/write|
|zoom|Camera zoom (positive value in percentage).<br/>            Read/write|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
## Methods
| Name | Description |
| :- | :- |
|set_rotation(latitude, longitude, revolution)|A rotation is defined through the use of a latitude<br/>            coordinate, a longitude coordinate, and a revolution about the axis <br/>            as the latitude and longitude coordinates.<br/>            If any of coordinate value is float.NaN, all rotation is undefined.|
|get_rotation()|A rotation is defined through the use of a latitude<br/>            coordinate, a longitude coordinate, and a revolution about the axis <br/>            as the latitude and longitude coordinates.<br/>            first element in return array - latitude, second - longitude, third - revolution.<br/>            Returns null if no rotation defined.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

