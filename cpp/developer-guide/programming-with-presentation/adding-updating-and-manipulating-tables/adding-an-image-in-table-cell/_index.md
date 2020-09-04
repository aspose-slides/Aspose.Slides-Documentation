---
title: Adding an Image in Table Cell
type: docs
weight: 30
url: /cpp/adding-an-image-in-table-cell/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ also facilitates developers to add images to table cells. In this topic, we will explain that how developers can add an image to a cell of a table using Aspose.Slides for C++.

{{% /alert %}} 
## **Adding Image inside a Table Cell**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using AddTable method exposed by IShapes object
- Create a Bitmap object to hold the image file
- Add the Bitmap image to IPPImage Object
- Set Fill Format of the Table Cell as Picture
- Add the image to the first cell of the table
- Save the modified presentation as a PPTX file

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddImageinsideTableCell-AddImageinsideTableCell.cpp" >}}
