---
title: Add Image in Table Cell
type: docs
weight: 10
url: /net/add-image-in-table-cell/
---

## **VSTO**
Below is the code for adding image in Table cell:

``` csharp
using Aspose.Slides;


    //Open Prsentation class that contains the table

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides for .NET has provided the simplest API to work with tables in an easiest way. To add image in a cell of a table that already exists in a presentation, please follow the steps below:

- Create an instance of Presentation class from the file that contains the table
- Obtain the reference of a slide by using its Index
- Load the image file into an IImage object using the Images.FromFile method
- Add the loaded image to the presentation's image collection to get an IPPImage object
- Find the table among the shapes of the slide
- Set Fill Format of the Table Cell as Picture
- Add the image to the first cell of the table
- Save the modified presentation as a PPTX file

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string fileName = "Adding Image in Table Cell.pptx";
string imageFile = "AsposeLogo.jpg";

using Presentation presentation = new Presentation(fileName);

//Get First Slide
ISlide sld = presentation.Slides[0];

//Load the image file
using IImage image = Images.FromFile(imageFile);

//Create an IPPImage object using the loaded image
IPPImage imgx1 = presentation.Images.AddImage(image);

foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable tbl)
    {
        //Add image to first table cell
        tbl[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
        tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
        tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = imgx1;
    }
}

//Save PPTX to Disk
presentation.Save(fileName, SaveFormat.Pptx);
``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)
