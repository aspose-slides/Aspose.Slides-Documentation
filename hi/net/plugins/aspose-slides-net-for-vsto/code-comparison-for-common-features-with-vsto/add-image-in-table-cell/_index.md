---
title: तालिका कोशिका में चित्र जोड़ें
type: docs
weight: 10
url: /hi/net/add-image-in-table-cell/
---
## **VSTO**
नीचे तालिका कोशिका में चित्र जोड़ने का कोड दिया गया है:

``` csharp

    //टेबल को शामिल करने वाली प्रेज़ेंटेशन क्लास खोलें

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //पहली स्लाइड प्राप्त करें

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
Aspose.Slides for .NET ने तालिकाएँ बनाने के लिए सबसे सरल API प्रदान किया है। नई तालिका बनाते समय तालिका कोशिका में चित्र जोड़ने के लिए, कृपया नीचे दी गई चरणों का पालन करें:

- Presentation क्लास का एक उदाहरण बनाएँ
- इसके Index का उपयोग करके किसी स्लाइड का रेफ़रेंस प्राप्त करें
- चौड़ाई के साथ कॉलम की Array निर्धारित करें
- ऊँचाई के साथ पंक्तियों की Array निर्धारित करें
- IShapes ऑब्जेक्ट द्वारा उजागर किए गए AddTable मेथड का उपयोग करके स्लाइड में एक Table जोड़ें
- चित्र फ़ाइल को रखने के लिए एक Bitmap ऑब्जेक्ट बनाएँ
- Bitmap चित्र को IPPImage ऑब्जेक्ट में जोड़ें
- Table Cell की Fill Format को Picture सेट करें
- चित्र को तालिका की पहली कोशिका में जोड़ें
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //पहली स्लाइड प्राप्त करें

  ISlide sld = MyPresentation.Slides[0];

  //छवि फ़ाइल को रखने के लिए एक Bitmap Image ऑब्जेक्ट बनाना

  using IImage image = Images.FromFile(ImageFile);

  //Bitmap ऑब्जेक्ट का उपयोग करके एक IPPImage ऑब्जेक्ट बनाएं

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //पहली तालिका कोशिका में छवि जोड़ें

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //PPTX को डिस्क पर सहेजें

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);
``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)