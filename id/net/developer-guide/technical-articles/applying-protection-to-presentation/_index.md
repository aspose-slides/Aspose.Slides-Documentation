---
title: Batasi Penyuntingan Presentasi dengan Kunci Bentuk di .NET
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 70
url: /id/net/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci bentuk
- kunci posisi
- kunci pemilihan
- kunci pengubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk .NET untuk membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides for .NET adalah untuk membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, pembatasan perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana bentuk diatur pada slide dan cara menerapkan serta menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Di Aspose.Slides for .NET, setiap elemen pada slide diwakili oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai tipe bentuk menyediakan opsi penguncian yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci bentuk. Aspose.Slides for .NET menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) mengunci autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) mengunci bentuk konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) mengunci bentuk grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterasi melalui slide‑slidenya dan tetapkan kunci yang sesuai pada setiap bentuk yang didukung.

## **Menerapkan dan Menghapus Perlindungan**

Kunci bentuk membatasi operasi seperti memilih, memindahkan, dan mengubah ukuran bentuk. Kunci ini tidak membuat seluruh presentasi tidak dapat diedit.

### **Menerapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides for .NET menyediakan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) untuk bekerja dengan bentuk pada slide.

Contoh ini menetapkan [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), dan [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) menjadi `true` untuk autoshapes, dengan kunci yang setara untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) untuk pergerakan; grup juga menggunakan [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) untuk membatasi pengelompokan.

Contoh ini memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop ini tidak menelusuri bentuk anak di dalam grup.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Menghapus Perlindungan**

Untuk menghapus kunci bentuk, setel nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan pengubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Ini juga menghapus [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Kesimpulan**

Aspose.Slides for .NET memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individual atau menerapkan pembatasan yang sama pada seluruh slide. Pilih kunci yang didukung oleh setiap tipe bentuk, dan setel nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam presentasi yang sama?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [password protection](/slides/id/net/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada bentuk individual di dalam suatu grup?**

Iterasi melalui koleksi [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grup dan terapkan kunci yang sesuai pada setiap bentuk anak. Ulangi proses ini untuk grup yang bersarang. Contoh di atas hanya memproses koleksi bentuk slide, sehingga tidak menetapkan kunci pada anggota grup individual.