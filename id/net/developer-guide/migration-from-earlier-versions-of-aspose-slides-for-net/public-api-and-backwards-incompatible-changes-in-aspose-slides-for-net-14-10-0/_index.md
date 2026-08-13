---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 14.10.0
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
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk .NET guna memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan lain‑lain yang [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) serta perubahan lain yang diperkenalkan dengan API Aspose.Slides untuk .NET 14.10.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Aspose.Slides.FieldType.Footer Field Type Telah Ditambahkan**
Tipe bidang Footer telah ditambahkan untuk memungkinkan pembuatan bidang dengan tipe ini dan untuk serialisasi presentasi yang valid.
#### **Enum Element ShapeElementFillSource.Own Telah Dihapus**
Elemen enum ShapeElementFillSource.Own telah dihapus karena duplikat. Gunakan ShapeElementFillSource.Shape sebagai pengganti ShapeElementFillSource.Own.
#### **Metode untuk Menghapus Titik Data Diagram dan Kategori Telah Ditambahkan**
Metode‑metode berikut, yang memungkinkan penghapusan titik data diagram dari koleksi titik data diagram, telah ditambahkan:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

Metode berikut, yang memungkinkan penghapusan kategori diagram dari koleksi yang menampungnya, telah ditambahkan:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Properti Aspose.Slides.ParagraphFormat yang Usang Telah Dihapus**
Properti BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle telah dihapus. Mereka telah ditandai usang sejak lama.
#### **Konstruktor yang Tidak Berguna dan Usang Telah Dihapus**
Konstruktor‑konstruktor berikut telah dihapus:

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