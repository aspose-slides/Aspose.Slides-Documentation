---
title: Batasi Penyuntingan Presentasi dengan Kunci Shape di .NET
linktitle: Batasi Penyuntingan Presentasi
type: docs
weight: 70
url: /id/net/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci shape
- kunci posisi
- kunci pemilihan
- kunci perubahan ukuran
- kunci pengelompokan
- PowerPoint
- PPTX
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengunci dan membuka kunci shape dalam presentasi PPTX dengan Aspose.Slides untuk .NET guna membatasi pemilihan, pergerakan, perubahan ukuran, dan pengelompokan."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides untuk .NET adalah membuat, memperbarui, dan menyimpan presentasi PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Ketika pengguna menerima presentasi ini, membatasi perubahan pada shape dapat membantu mempertahankan tata letak dan konten yang dimaksud.

Artikel ini menjelaskan bagaimana shape diatur pada slide dan cara menerapkan serta menghapus kunci shape dalam presentasi PPTX. Kunci ini memungkinkan Anda membatasi operasi penyuntingan tertentu pada shape individual.

## **Komposisi Slide**

Slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, shape yang dikelompokkan, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Dalam Aspose.Slides untuk .NET, setiap elemen pada slide diwakili oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Berbagai tipe shape menyediakan opsi kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) adalah antarmuka dasar untuk kunci shape. Aspose.Slides untuk .NET menyediakan antarmuka kunci berikut:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) mengunci autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) mengunci shape konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) mengunci shape grup.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Untuk menerapkan kunci pada seluruh [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterasikan slide‑slidenya dan tetapkan kunci yang sesuai pada setiap shape yang didukung.

## **Terapkan dan Hapus Proteksi**

Editor presentasi yang kompatibel menggunakan kunci shape untuk membatasi operasi penyuntingan individual. Enkripsi file dan proteksi penulisan tingkat dokumen merupakan [pengaturan proteksi presentasi](/slides/id/net/password-protected-presentation/) yang terpisah.

### **Terapkan Proteksi pada Shape PPTX**

Aspose.Slides untuk .NET menyediakan antarmuka [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) untuk bekerja dengan shape pada slide.

Contoh tersebut mengatur [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), dan [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) menjadi `true` untuk autoshape, dengan kunci yang setara untuk shape grup, konektor, dan bingkai gambar. Konektor menggunakan [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) untuk pergerakan; grup juga menggunakan [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) untuk membatasi pengelompokan.

Contoh tersebut memuat presentasi PPTX yang ada, memeriksa shape dalam koleksi shape tiap slide, dan menyimpan salinan dengan pembatasan ini diterapkan. Shape di luar empat tipe yang ditangani dibiarkan tidak berubah. Loop tidak menelusuri shape anak di dalam sebuah grup.

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

### **Hapus Proteksi**

Untuk menghapus kunci shape, atur nilainya menjadi `false`. Contoh berikut memuat presentasi dengan kunci shape dan menghapus pembatasan pemilihan, pergerakan, serta pengubahan ukuran melalui [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), dan [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Itu juga menghapus [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) dan menyimpan salinan presentasi. Pengaturan kunci lainnya dibiarkan tidak berubah.

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

Letakkan foto bernama `photo.jpg` di direktori kerja. Contoh memotong 12% dari kiri dan 8% dari kanan, lalu mengatur [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) pada bingkai gambar. Bendera ini membatasi pemotongan lanjutan dan mempertahankan pemotongan yang ada.

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

`PictureLocked.pptx` menyimpan kunci pemotongan sebagai `true`. Di PowerPoint, perintah **Crop** dinonaktifkan saat foto dipilih.

### **Pertahankan Diagram Tetap Dikelompokkan**

Contoh tersebut mengelompokkan sebuah persegi panjang dan panah, lalu mengatur [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) pada grup itu sendiri untuk menjaga komponen diagram tetap bersama. Penyuntingan lain, seperti memindahkan grup atau mengubah isian komponen, tetap tersedia.

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

`DiagramLocked.pptx` menyimpan kunci ungrouping sebagai `true`. Di PowerPoint, perintah **Ungroup** dinonaktifkan ketika seluruh diagram dipilih.

### **Kesimpulan**

Aspose.Slides untuk .NET memungkinkan Anda membatasi operasi penyuntingan tertentu pada shape individual atau menerapkan pembatasan yang sama di seluruh slide. Pilih kunci yang didukung oleh tiap tipe shape, dan atur nilainya menjadi `false` ketika Anda perlu menghapus pembatasan tersebut.

## **Tanya Jawab**

**Apakah saya dapat menggabungkan kunci shape dan proteksi password dalam satu presentasi?**

Ya. Kunci shape membatasi operasi penyuntingan tertentu, sementara [proteksi password](/slides/id/net/password-protected-presentation/) dapat membatasi pembukaan atau pengubahan presentasi. Anda dapat menggunakan keduanya dalam satu file.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci hanya pada shape di slide yang dipilih. Ini tidak mengubah pengaturan kunci pada slide lain.

**Bagaimana saya dapat menerapkan kunci pada shape individual di dalam grup?**

Iterasikan koleksi [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) grup dan terapkan kunci yang sesuai pada setiap shape anak. Ulangi ini untuk setiap grup bersarang. Contoh di atas hanya memproses koleksi shape slide, sehingga tidak menetapkan kunci pada anggota grup individual.