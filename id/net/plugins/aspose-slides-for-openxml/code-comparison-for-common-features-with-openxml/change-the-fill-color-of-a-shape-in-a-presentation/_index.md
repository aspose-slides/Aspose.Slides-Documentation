---
title: Ubah warna isi sebuah bentuk dalam presentasi
type: docs
weight: 40
url: /id/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **Presentasi OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Ubah warna isi sebuah bentuk.

// File uji harus memiliki bentuk berisi sebagai bentuk pertama pada slide pertama.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Dapatkan ID hubungan slide pertama.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Dapatkan bagian slide dari ID hubungan.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Dapatkan pohon bentuk yang berisi bentuk yang akan diubah.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Dapatkan bentuk pertama dalam pohon bentuk.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Dapatkan gaya bentuk.

                ShapeStyle style = shape.ShapeStyle;

                // Dapatkan referensi isian.

                Drawing.FillReference fillRef = style.FillReference;

                // Atur warna isian ke SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Simpan slide yang telah dimodifikasi.

                slide.Slide.Save();

            }

        }

    }

}
``` 
## **Aspose.Slides**
Kita perlu mengikuti langkah‑langkah berikut untuk mengisi bentuk pada presentasi:

- Buat instance kelas Presentation.
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan IShape ke slide.
- Setel Tipe Isi Shape menjadi Solid.
- Setel warna Shape.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Instansiasi kelas PrseetationEx yang mewakili PPTX 
using (Presentation pres = new Presentation())

{

    //Dapatkan slide pertama

    ISlide sld = pres.Slides[0];

    //Tambahkan autoshape tipe persegi panjang

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Setel tipe isian menjadi Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Setel warna persegi panjang

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Tulis file PPTX ke disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Unduh Contoh Kode yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Contoh Kode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)