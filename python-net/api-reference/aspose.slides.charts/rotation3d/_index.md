---
title: Rotation3D Class
type: docs
weight: 1030
url: /python-net/api-reference/aspose.slides.charts/rotation3d/
---

Represents 3D rotation of a chart.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.Rotation3D

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The Rotation3D type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|rotation_x|Returns or sets the rotation degree around the X-axis, i.e. in the Y direction for 3D charts (between -90 and 90 degrees).<br/>            The property matches with the 21.2.2.157 rotX (X Rotation) item in ECMA-376 and with the "Y Rotation" option in PowerPoint 2007+.<br/>            Read/write int.|
|rotation_y|Returns or sets the rotation degree around the Y-axis, i.e. in the X direction for 3D charts (between 0 and 360 degrees).<br/>            The property matches with the 21.2.2.158 rotY (Y Rotation) item in ECMA-376 and with the "X Rotation" option in PowerPoint 2007+.<br/>            Read/write int.|
|perspective|Returns or sets the perspective value (field of view angle) for 3D charts (between 0 and 240).<br/>            Ignored if RightAngleAxes property value is true.<br/>            Read/write int.|
|right_angle_axes|Determines whether the chart axes are at right angles, rather than drawn in perspective.<br/>            In other words it determines whether the chart angles of axes are independent from chart <br/>            rotation or elevation.<br/>            Read/write bool.|
|depth_percents|Returns or sets the depth of a 3D chart as a percentage of a chart width (between 20 and 2000 percent).<br/>            Read/write int.|
|height_percents|Specifies the height of a 3-D chart as a percentage of the chart width (between 5 and 500 percent).<br/>            Read/write int.|
