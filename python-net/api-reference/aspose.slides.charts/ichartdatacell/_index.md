---
title: IChartDataCell
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 520
url: /python-net/api-reference/aspose.slides.charts/ichartdatacell/
---

## IChartDataCell class

Represents cell for chart data.

The IChartDataCell type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|row|Returns the index of the row of worksheet in which the cell is located.<br/>            Read-only|
|column|Returns the index of the column of worksheet in which the cell is located.<br/>            Read-only|
|value|Gets or sets the value.<br/>            Read/write object.|
|formula|Gets or sets the formula in A1-style.|
|r1c1_formula|Gets or sets the formula in R1C1-style.|
|chart_data_worksheet|Gets the worksheet.<br/>            Read-only [IChartDataWorksheet](/slides/python-net/api-reference/aspose.slides.charts/ichartdataworksheet/).|
|is_hidden|Determines whether the cell is hidden.<br/>            Read-only bool.|
|custom_number_format|Gets or sets the custom display format of numbers and dates. <br/>            If value is empty will be used PresetNumberFormat value.<br/>            Read/write string.|
|preset_number_format|Gets or sets the built-in display format of numbers and dates. Preset number must be in [0..22] or [37..49].<br/>             Read/write int.|
## Methods
| Name | Description |
| :- | :- |
|calculate(update_values)|If the cell contains a formula, the value will be updated base on that formula.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

