---
title: Membatasi Penyuntingan Presentasi dengan Kunci Bentuk di .NET
linktitle: Membatasi Penyuntingan Presentasi
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
description: "Pelajari cara mengunci dan membuka kunci bentuk dalam presentasi PPTX dengan Aspose.Slides untuk .NET guna membatasi pemilihan, pergerakan, pengubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides untuk .NET adalah membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada bentuk dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan cara bentuk diatur pada slide serta cara menerapkan dan menghapus kunci bentuk dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshapes, tabel, objek OLE, bentuk yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides untuk .NET, setiap elemen pada slide direpresentasikan oleh sebuah objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai tipe bentuk memiliki opsi penguncian yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci bentuk. Aspose.Slides untuk .NET menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) mengunci autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) mengunci bentuk konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) mengunci bentuk grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterasikan slide‑slidenya dan atur kunci yang sesuai pada setiap bentuk yang didukung.

## **Terapkan dan Hapus Perlindungan**

Editor presentasi yang kompatibel menggunakan kunci bentuk untuk membatasi operasi penyuntingan individu. Enkripsi file dan perlindungan penulisan tingkat dokumen adalah [pengaturan perlindungan presentasi](/slides/id/net/password-protected-presentation/) yang terpisah.

### **Terapkan Perlindungan pada Bentuk PPTX**

Aspose.Slides untuk .NET menyediakan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) untuk bekerja dengan bentuk pada sebuah slide.

Contoh ini mengatur [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), dan [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) menjadi `true` untuk autoshapes, dengan kunci yang setara untuk bentuk grup, konektor, dan bingkai gambar. Konektor menggunakan [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) untuk pergerakan; grup juga menggunakan [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) untuk membatasi pengelompokan.

Contoh ini memuat presentasi PPTX yang ada, memeriksa bentuk‑bentuk dalam koleksi bentuk setiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Bentuk di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri bentuk anak di dalam sebuah grup.

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

### **Hapus Perlindungan**

Untuk menghapus kunci bentuk, atur nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci bentuk dan menghapus pembatasan pemilihan, pergerakan, dan perubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Contoh ini juga menghapus [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

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

### **Pertahankan Pemotongan Gambar**

Tempatkan foto bernama `photo.jpg` di direktori kerja. Contoh ini memotong 12 % dari kiri dan 8 % dari kanan, lalu mengatur [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) pada bingkai gambar. Bendera ini membatasi pemotongan lebih lanjut dan mempertahankan pemotongan yang sudah ada.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` menyimpan kunci pemotongan sebagai `true`. Di PowerPoint, perintah **Crop** dinonaktifkan ketika foto dipilih.

### **Jaga Diagram Tetap Dikelompokkan**

Contoh ini mengelompokkan sebuah persegi panjang dan sebuah panah, lalu mengatur [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) pada grup itu sendiri untuk menjaga komponen diagram tetap bersama. Penyuntingan lain, seperti memindahkan grup atau mengubah isi komponen, tetap tersedia.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` menyimpan kunci pembongkaran sebagai `true`. Di PowerPoint, perintah **Ungroup** dinonaktifkan ketika seluruh diagram dipilih.

### **Laporkan Kunci Bentuk yang Ada**

Untuk meninjau sebuah templat, bukalah dan baca objek kunci untuk tiap bentuk. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) bernilai `true` ketika semua bendera pada objek tersebut dinonaktifkan dan `false` ketika setidaknya satu bendera diaktifkan. Sebuah grup dan anak‑anaknya memiliki objek kunci terpisah, jadi inspeksi anak‑anak bahkan ketika grup tidak memiliki kunci.

Contoh ini memeriksa pergerakan untuk autoshapes, bingkai gambar, dan grup, pemotongan untuk gambar, serta pembongkaran untuk grup. Ia melaporkan bendera yang dikenali dan menandai tipe bentuk yang tidak diperiksa.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Misalkan slide 1 dari `Sample.pptx` berisi sebuah grup bernama `Layout` dengan pembongkaran terkunci, sebuah gambar bernama `Photo` di dalamnya dengan pemotongan terkunci, dan sebuah persegi panjang tidak terkunci bernama `Free`. Laporan melewatkan `Free` dan mencetak dua baris berikut:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Laporan membaca bendera penyuntingan tingkat bentuk yang disimpan tanpa mengubahnya atau menyimpan presentasi. Perlindungan penulisan tingkat dokumen adalah pengaturan terpisah, dan penegakan tiap bendera bergantung pada editor.

### **Kesimpulan**

Aspose.Slides untuk .NET memungkinkan Anda membatasi operasi penyuntingan tertentu pada bentuk individu atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh tiap tipe bentuk, dan atur nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **FAQ**

**Apakah saya dapat menggabungkan kunci bentuk dan perlindungan kata sandi dalam satu presentasi?**

Ya. Kunci bentuk membatasi operasi penyuntingan tertentu, sementara [perlindungan kata sandi](/slides/id/net/password-protected-presentation/) dapat membatasi pembukaan atau modifikasi presentasi. Anda dapat menggunakan keduanya dalam file yang sama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada bentuk di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana cara menerapkan kunci pada bentuk individu di dalam sebuah grup?**

Iterasikan koleksi [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grup dan terapkan kunci yang sesuai pada tiap bentuk anak. Ulangi proses ini untuk setiap grup bersarang, mengikuti penelusuran pada contoh pelaporan.