---
title: VSTO ve Aspose.Slides'te Tablo'dan Satır veya Sütun Kaldırma
type: docs
weight: 130
url: /tr/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Aşağıda VSTO Sunum kullanarak bir tablodan satır veya sütun kaldırmak için kod bulunmaktadır:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //İlk slaytı al

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
Aspose.Slides for .NET, tabloları en kolay şekilde oluşturmak için en basit API'yi sağlamıştır. Bir slaytta tablo oluşturmak ve tablo üzerinde bazı temel işlemleri gerçekleştirmek için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaydın referansını, dizinini (Index) kullanarak alın
- Genişlik ile sütunların bir dizisini tanımlayın
- Yükseklik ile satırların bir dizisini tanımlayın
- IShapes nesnesi tarafından sunulan AddTable yöntemiyle slayta bir tablo ekleyin
- Tablo satırını kaldırın
- Tablo sütununu kaldırın
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //İlk Slaytı Al

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