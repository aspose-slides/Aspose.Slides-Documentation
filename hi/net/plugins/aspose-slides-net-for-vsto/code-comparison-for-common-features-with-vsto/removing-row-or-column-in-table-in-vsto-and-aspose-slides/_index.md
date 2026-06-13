---
title: VSTO और Aspose.Slides में टेबल में पंक्ति या कॉलम हटाना
type: docs
weight: 130
url: /hi/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
नीचे VSTO Presentation का उपयोग करके टेबल से पंक्तियों या स्तंभों को हटाने का कोड दिया गया है।

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //पहली स्लाइड प्राप्त करें

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
Aspose.Slides for .NET ने तालिकाएँ बनाने के लिए सबसे सरल API प्रदान किया है। स्लाइड में एक तालिका बनाने और तालिका पर कुछ मूलभूत कार्य करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें।

- Presentation क्लास का एक उदाहरण बनाएं
- उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें
- चौड़ाई के साथ कॉलम की एरे परिभाषित करें
- ऊँचाई के साथ पंक्तियों की एरे परिभाषित करें
- IShapes ऑब्जेक्ट द्वारा प्रदान किए गए AddTable मेथड का उपयोग करके स्लाइड में एक तालिका जोड़ें
- तालिका की पंक्ति हटाएं
- तालिका का स्तंभ हटाएं
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //पहली स्लाइड प्राप्त करें

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)