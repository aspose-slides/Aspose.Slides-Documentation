---
title: Mencegah Penyuntingan Presentasi dengan Kunci Shape di .NET
linktitle: Mencegah Penyuntingan Presentasi
type: docs
weight: 70
url: /id/net/applying-protection-to-presentation/
keywords:
- mencegah penyuntingan
- melindungi dari penyuntingan
- kunci shape
- kunci posisi
- kunci seleksi
- kunci ukuran
- kunci pengelompokan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk .NET mengunci atau membuka kunci shape dalam file PPT, PPTX, dan ODP, mengamankan presentasi sambil memungkinkan penyuntingan terkontrol."
---
## **Latar Belakang**

Penggunaan umum Aspose.Slides adalah untuk membuat, memperbarui, dan menyimpan presentasi Microsoft PowerPoint (PPTX) sebagai bagian dari alur kerja otomatis. Pengguna aplikasi yang memanfaatkan Aspose.Slides dengan cara ini memiliki akses ke presentasi yang dihasilkan, sehingga melindungi mereka dari penyuntingan menjadi perhatian umum. Penting agar presentasi yang dibuat secara otomatis mempertahankan format dan kontennya yang asli.

Artikel ini menjelaskan bagaimana presentasi dan slide disusun serta bagaimana Aspose.Slides untuk .NET dapat menerapkan perlindungan pada sebuah presentasi dan kemudian menghapusnya. Ini memberikan pengembang cara mengendalikan bagaimana presentasi yang dihasilkan aplikasi mereka digunakan.

## **Komposisi Slide**

Sebuah slide presentasi terdiri dari komponen seperti autoshape, tabel, objek OLE, grup shape, bingkai gambar, bingkai video, konektor, dan elemen lain yang digunakan untuk membangun presentasi. Di Aspose.Slides untuk .NET, setiap elemen pada slide direpresentasikan oleh objek yang mengimplementasikan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) atau mewarisi dari kelas yang melakukannya.

Struktur PPTX kompleks, sehingga tidak seperti PPT, di mana kunci generik dapat digunakan untuk semua jenis shape, tipe shape yang berbeda memerlukan kunci yang berbeda. Antarmuka [IBaseShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseshapelock/) adalah kelas kunci generik untuk PPTX. Tipe kunci berikut didukung dalam Aspose.Slides untuk .NET untuk PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshapelock/) mengunci autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/id/net/aspose.slides/iconnectorlock/) mengunci shape konektor.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/id/net/aspose.slides/igraphicalobjectlock/) mengunci objek grafis.  
- [IGroupShapeLock](https://reference.aspose.com/slides/id/net/aspose.slides/igroupshapelock/) mengunci grup shape.  
- [IPictureFrameLock](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframelock/) mengunci bingkai gambar.  

Setiap aksi yang dilakukan pada semua objek shape dalam objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) diterapkan pada seluruh presentasi.

## **Terapkan dan Hapus Perlindungan**

Menerapkan perlindungan memastikan bahwa sebuah presentasi tidak dapat diedit. Ini merupakan teknik yang berguna untuk melindungi konten presentasi.

### **Terapkan Perlindungan pada Shape PPTX**

Aspose.Slides untuk .NET menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) untuk bekerja dengan shape pada slide.

Seperti yang disebutkan sebelumnya, setiap kelas shape memiliki kelas kunci shape terkait untuk perlindungan. Artikel ini fokus pada kunci NoSelect, NoMove, dan NoResize. Kunci ini memastikan bahwa shape tidak dapat dipilih (melalui klik mouse atau metode seleksi lainnya) serta tidak dapat dipindahkan atau diubah ukurannya.

Contoh kode berikut menerapkan perlindungan pada semua tipe shape dalam sebuah presentasi.

```cs
// Membuat instance kelas Presentation yang mewakili file PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Menelusuri semua slide dalam presentasi.
foreach (ISlide slide in presentation.Slides)
{
    // Menelusuri semua shape dalam slide.
    foreach (IShape shape in slide.Shapes)
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

// Menyimpan file presentasi.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Hapus Perlindungan**

Untuk membuka kunci sebuah shape, tetapkan nilai kunci yang diterapkan menjadi `false`. Contoh kode berikut menunjukkan cara membuka kunci shape dalam presentasi yang terkunci.

```cs
// Membuat instance kelas Presentation yang mewakili file PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Menelusuri semua slide dalam presentasi.
foreach (ISlide slide in presentation.Slides)
{
    // Menelusuri semua shape dalam slide.
    foreach (IShape shape in slide.Shapes)
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

// Menyimpan file presentasi.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Kesimpulan**

Aspose.Slides menawarkan beberapa opsi untuk melindungi shape dalam sebuah presentasi. Anda dapat mengunci satu shape atau mengiterasi semua shape dalam presentasi dan mengunci masing‑masing untuk secara efektif mengamankan seluruh berkas. Anda dapat menghapus perlindungan dengan mengatur nilai kunci menjadi `false`.

## **FAQ**

**Apakah saya dapat menggabungkan kunci shape dan perlindungan password dalam satu presentasi?**

Ya. Kunci membatasi penyuntingan objek di dalam berkas, sementara [perlindungan password](/slides/id/net/password-protected-presentation/) mengontrol akses untuk membuka dan/atau menyimpan perubahan. Kedua mekanisme ini saling melengkapi dan bekerja bersama.

**Apakah saya dapat membatasi penyuntingan pada slide tertentu tanpa memengaruhi slide lain?**

Ya. Terapkan kunci pada shape di slide yang dipilih; slide lainnya tetap dapat diedit.

**Apakah kunci shape berlaku untuk objek grup dan konektor?**

Ya. Tipe kunci khusus didukung untuk grup, konektor, objek grafis, dan jenis shape lainnya.