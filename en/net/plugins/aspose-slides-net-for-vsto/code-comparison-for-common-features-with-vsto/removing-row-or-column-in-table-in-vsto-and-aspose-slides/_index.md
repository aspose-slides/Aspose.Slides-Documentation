---
title: Removing row or column in Table in VSTO and Aspose.Slides
type: docs
weight: 130
url: /net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Below is code for removing rows or columns from table using VSTO Presentation:

``` csharp
using Aspose.Slides;


    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides for .NET has provided the simplest API to work with tables in an easiest way. To remove a row from a table that already exists in a presentation, please follow the steps below:

- Create an instance of Presentation class from the existing file
- Obtain the reference of a slide by using its Index
- Find the table shape on the slide
- Remove table row by calling RemoveAt on the Rows collection
- Write the modified presentation as a PPTX file

A column is removed the same way, through the `Columns` collection of the same table.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName, SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)
