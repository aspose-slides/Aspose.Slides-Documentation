---
title: Kelola OLE Objects dalam Presentasi di .NET
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/net/manage-ole/
keywords:
- objek OLE
- Pengaitan & Penyematan Objek
- tambahkan OLE
- sematkan OLE
- tambahkan objek
- sematkan objek
- tambahkan file
- sematkan file
- objek tertaut
- file tertaut
- ubah OLE
- ikon OLE
- judul OLE
- ekstrak OLE
- ekstrak objek
- ekstrak file
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET. Sematkan, perbarui, dan ekspor konten OLE dengan lancar."
---
## **Pendahuluan**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda diminta memilih aplikasi untuk membuka atau mengedit objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/id/net/) memungkinkan Anda menyisipkan OLE Objects ke slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe)).

## **Menambahkan Bingkai OLE Object ke Slide**

Misalkan Anda sudah membuat diagram di Microsoft Excel dan ingin menyematkannya ke slide sebagai bingkai objek OLE menggunakan Aspose.Slides for .NET, Anda dapat melakukannya dengan cara berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Baca file Excel sebagai array byte. 
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) ke slide yang berisi array byte dan informasi lainnya tentang objek OLE. 
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX. 

Dalam contoh di bawah, kami menambahkan diagram dari file Excel ke slide sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) menggunakan Aspose.Slides for .NET.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/net/aspose.slides.dom.ole/oleembeddeddatainfo/) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Siapkan data untuk objek OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Tambahkan bingkai objek OLE ke slide.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Menambahkan Bingkai OLE Object Tertaut**

Aspose.Slides for .NET memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) tanpa menyematkan data tetapi hanya dengan tautan ke file.

Kode C# berikut menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) dengan file Excel yang ditautkan ke slide:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan bingkai objek OLE dengan file Excel yang ditautkan.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mengakses Bingkai OLE Object**

Jika sebuah objek OLE sudah disematkan di slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat presentasi dengan objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide menggunakan indeksnya. 
3. Akses bentuk [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe).  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu bentuk pada slide pertama. Kemudian kami *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe). Ini adalah bingkai OLE object yang diinginkan untuk diakses. 
4. Setelah bingkai OLE object diakses, Anda dapat melakukan operasi apa pun padanya. 

Dalam contoh di bawah, sebuah bingkai OLE object (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan bentuk pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Dapatkan data file yang disematkan.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Dapatkan ekstensi file yang disematkan.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Mengakses Properti Bingkai OLE Object Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai OLE object yang ditautkan.

Kode C# berikut menunjukkan cara memeriksa apakah sebuah OLE object ditautkan dan kemudian mendapatkan path ke file yang ditautkan:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan bentuk pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Periksa apakah objek OLE ditautkan.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Cetak path lengkap ke file yang ditautkan.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Cetak path relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi path relatif.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Mengubah Data OLE Object**

{{% alert color="info" %}} 

Pada bagian ini, contoh kode di bawah ini menggunakan [Aspose.Cells for .NET](/cells/net/). 

{{% /alert %}}

Jika sebuah OLE object sudah disematkan di slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi data-nya dengan cara berikut:

1. Muat presentasi dengan OLE object yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses bentuk [OLEObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe).  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu bentuk pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe). Ini adalah bingkai OLE object yang diinginkan untuk diakses. 
4. Setelah bingkai OLE object diakses, Anda dapat melakukan operasi apa pun padanya. 
5. Buat objek `Workbook` dan akses data OLE. 
6. Akses `Worksheet` yang diinginkan dan ubah data. 
7. Simpan `Workbook` yang telah diperbarui ke dalam stream. 
8. Ubah data OLE object dari stream. 

Dalam contoh di bawah, sebuah bingkai OLE object (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan bentuk pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Baca data objek OLE sebagai objek Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Ubah data workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Ubah data objek bingkai OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Menyematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for .NET memungkinkan Anda menyematkan jenis file lain ke slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, ia secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode C# berikut menunjukkan cara menyematkan HTML dan ZIP ke slide:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti OLE object lama dengan yang baru atau mengganti OLE object yang tidak didukung dengan yang didukung. Aspose.Slides for .NET memungkinkan Anda mengatur jenis file untuk objek yang disematkan, memungkinkan Anda memperbarui data bingkai OLE atau ekstensi-nya.

Kode C# berikut menunjukkan cara mengatur jenis file untuk OLE object yang disematkan menjadi `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Ubah tipe file menjadi ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mengatur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan OLE object, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau ini adalah yang dilihat pengguna sebelum mengakses atau membuka OLE object. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for .NET.

Kode C# berikut menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disematkan: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Tambahkan gambar ke sumber daya presentasi.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Atur judul dan gambar untuk pratinjau OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mencegah Bingkai OLE Object Diubah Ukuran dan Posisi**

Setelah Anda menambahkan OLE object yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai OLE object karena PowerPoint memperbarui data dari OLE object yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta memperbarui data objek, atur properti `UpdateAutomatic` dari antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe/) ke `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Pertahankan ukuran dan posisi bingkai objek OLE saat PowerPoint memperbarui tautan.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for .NET memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai OLE objects dengan cara berikut:
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi OLE objects yang ingin Anda ekstrak. 
2. Lakukan iterasi melalui semua bentuk dalam presentasi dan akses bentuk [OLEObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe). 
3. Akses data file yang disematkan dari bingkai OLE object dan tulis ke disk. 

Kode C# berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai OLE objects:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

### Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE yang “hidup” tidak dijalankan selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

### Bagaimana cara mengunci OLE object pada slide agar pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?

Kunci bentuk: Aspose.Slides menyediakan [shape-level locks](/slides/id/net/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah edit dan pergerakan yang tidak disengaja.

### Mengapa objek Excel yang ditautkan “melompat” atau mengubah ukuran ketika saya membuka presentasi?

PowerPoint mungkin menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/net/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan mengatur gambar pengganti yang sesuai.

### Apakah path relatif untuk OLE object yang ditautkan akan dipertahankan dalam format PPTX?

Dalam PPTX, informasi “path relatif” tidak tersedia—hanya path lengkap. Path relatif ditemukan pada format PPT lama. Untuk portabilitas, gunakan path absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.