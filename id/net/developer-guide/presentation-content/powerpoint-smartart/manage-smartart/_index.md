---
title: Kelola SmartArt dalam Presentasi PowerPoint di .NET
linktitle: Kelola SmartArt
type: docs
weight: 10
url: /id/net/manage-smartart/
keywords:
- SmartArt
- Teks SmartArt
- tipe tata letak
- properti tersembunyi
- bagan organisasi
- bagan organisasi gambar
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat dan mengedit SmartArt PowerPoint dengan Aspose.Slides untuk .NET menggunakan contoh kode C# yang jelas dan mempercepat desain serta otomatisasi slide."
---
## **Gambaran Umum**

SmartArt adalah diagram PowerPoint yang dibuat dari node, bentuk node, dan tata letak. Dengan Aspose.Slides untuk .NET, Anda dapat membuat SmartArt, membaca teks dari node-nya, mengubah tata letaknya, memeriksa node tersembunyi, mengonfigurasi tata letak bagan organisasi, dan membuat bagan organisasi berbasis gambar.

## **Dapatkan Teks dari Objek SmartArt**

Sebuah node SmartArt dapat berisi satu atau beberapa bentuk. Untuk membaca teks yang terlihat, iterasi melalui [ISmartArt.AllNodes](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartart/allnodes/), lalu baca [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) yang dikembalikan oleh [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Ubah Tipe Tata Letak Objek SmartArt**

Tata letak SmartArt mengontrol cara node disusun dan dihubungkan. Contoh berikut membuat objek SmartArt dengan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, mengubahnya menjadi nilai `BasicProcess`, dan menyimpan presentasi.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Periksa Apakah Node SmartArt Tersembunyi**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartartnode/ishidden/) menunjukkan apakah node tersembunyi dalam model data SmartArt. Node tersembunyi dapat ada dalam struktur meskipun tata letak yang dipilih tidak menampilkannya sebagai elemen diagram yang terlihat.

Contoh berikut menambahkan node ke objek SmartArt yang menggunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` dan memeriksa status tersembunyi node tersebut.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Dapatkan atau Atur Tata Letak Bagan Organisasi**

Untuk diagram SmartArt yang menggunakan tata letak bagan organisasi, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) menentukan bagaimana node anak disusun di bawah node induk. Misalnya, Anda dapat mengatur node anak menggantung dari kiri, kanan, atau kedua sisi, tergantung pada [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/organizationchartlayouttype/) yang dipilih.

Contoh berikut membuat bagan organisasi dan mengatur tata letak untuk node pertama menjadi nilai [OrganizationChartLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Buat Bagan Organisasi Gambar**

Bagan organisasi gambar adalah tata letak SmartArt yang dirancang untuk diagram hierarki yang menyertakan placeholder gambar. Gunakan nilai [SmartArtLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` saat menambahkan objek SmartArt ke slide.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah SmartArt mendukung pencerminan atau pembalikan untuk bahasa RTL?**

Ya. Properti [IsReversed](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartart/isreversed/) mengubah arah diagram dari kiri-ke-kanan menjadi kanan-ke-kiri, atau sebaliknya, ketika tata letak SmartArt yang dipilih mendukung pembalikan.

**Bagaimana cara menyalin SmartArt ke slide yang sama atau ke presentasi lain sambil mempertahankan format?**

Anda dapat [mengklon bentuk SmartArt](/slides/id/net/shape-manipulations/) dengan [ShapeCollection.AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/shapecollection/addclone/) atau [mengklon seluruh slide](/slides/id/net/clone-slides/) yang berisi SmartArt. Kedua pendekatan mempertahankan ukuran, posisi, dan format.

**Bagaimana cara merender SmartArt ke gambar raster untuk pratinjau atau ekspor web?**

[Render slide](/slides/id/net/convert-powerpoint-to-png/) atau seluruh presentasi ke PNG atau JPEG. SmartArt dirender sebagai bagian dari slide.

**Bagaimana saya dapat menemukan objek SmartArt tertentu pada slide jika ada beberapa?**

Tetapkan nilai [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/shape/alternativetext/) atau [Name](https://reference.aspose.com/slides/id/net/aspose.slides/shape/name/) yang khas pada bentuk SmartArt, cari nilai tersebut di [Slide.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides/baseslide/shapes/), lalu periksa bahwa bentuk yang cocok adalah sebuah [ISmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartart/).