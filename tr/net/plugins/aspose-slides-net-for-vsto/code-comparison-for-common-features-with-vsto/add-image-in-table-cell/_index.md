---
title: Tablo Hücresine Resim Ekle
type: docs
weight: 10
url: /tr/net/add-image-in-table-cell/
---
## **VSTO**
Aşağıda tablo hücresine resim eklemek için kod bulunmaktadır:

``` csharp

    //Tabloyu içeren Presentation sınıfını aç

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //İlk slaytı al

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
Aspose.Slides for .NET, tabloları en kolay şekilde oluşturmak için en basit API'yi sağlamaktadır. Yeni bir tablo oluştururken tablo hücresine resim eklemek için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaytın referansını, indeksini kullanarak edinin
- Genişliği belirlenmiş Sütun Dizisini tanımlayın
- Yüksekliği belirlenmiş Satır Dizisini tanımlayın
- IShapes nesnesi tarafından sağlanan AddTable yöntemiyle slayta bir Tablo ekleyin
- Görüntü dosyasını tutmak için bir Bitmap nesnesi oluşturun
- Bitmap görüntüyü IPPImage nesnesine ekleyin
- Tablo hücresinin Doldurma Biçimini Resim olarak ayarlayın
- Görüntüyü tablonun ilk hücresine ekleyin
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //İlk Slaytı Al

  ISlide sld = MyPresentation.Slides[0];

  //Görüntü dosyasını tutmak için bir Bitmap Image nesnesi oluşturma

  using IImage image = Images.FromFile(ImageFile);

  //Bitmap nesnesini kullanarak bir IPPImage nesnesi oluşturma

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //İlk tablo hücresine resmi ekle

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //PPTX'yi diske kaydet

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)