---
title: Perubahan API Publik dan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.10.0
linktitle: Aspose.Slides untuk .NET 14.10.0
type: docs
weight: 120
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 
Halaman ini menampilkan semua kelas, metode, properti, dan lain-lain yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), serta perubahan lainnya yang diperkenalkan dengan API Aspose.Slides for .NET 14.10.0.
{{% /alert %}} 
## **Perubahan API Publik**
#### **Tipe Field Aspose.Slides.FieldType.Footer Telah Ditambahkan**
Tipe field Footer telah ditambahkan untuk memungkinkan pembuatan field tipe ini dan untuk serialisasi presentasi yang valid.
#### **Elemen Enum ShapeElementFillSource.Own Telah Dihapus**
Elemen enum ShapeElementFillSource.Own telah dihapus karena duplikat. Gunakan ShapeElementFillSource.Shape sebagai gantinya.
#### **Metode untuk Menghapus Titik Data dan Kategori Chart Telah Ditambahkan**
Metode berikut, yang memungkinkan penghapusan titik data chart dari koleksi titik data chart, telah ditambahkan:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Metode berikut, yang memungkinkan penghapusan kategori chart dari koleksi yang memuatnya, telah ditambahkan:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //hapus dengan ChartCategory.Remove()
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //hapus dengan ChartCategoryCollection.Remove()
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//hapus dengan ChartDataPoint.Remove()
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Properti Obsolete Aspose.Slides.ParagraphFormat Telah Dihapus**
Properti BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle telah dihapus. Properti‑properti ini telah ditandai sebagai usang sejak lama.
#### **Konstruktor yang Tidak Berguna dan Usang Telah Dihapus**
Konstruktor berikut telah dihapus:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)