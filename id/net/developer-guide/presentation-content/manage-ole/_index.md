---
title: Kelola Objek OLE dalam Presentasi di .NET
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
description: "Optimalkan pengelolaan objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat di satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam hal ini, ketika Anda mengklik ganda ikon, diagram akan dibuka di aplikasi terkait (Excel), atau Anda diminta memilih aplikasi untuk membuka atau mengedit objek. 
- Sebuah objek OLE dapat menampilkan kontennya yang sebenarnya, seperti isi sebuah diagram. Dalam hal ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Menambahkan Bingkai Objek OLE ke Slide**

Misalkan Anda sudah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for .NET, Anda dapat melakukannya dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Baca file Excel sebagai array byte.  
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) ke slide dengan menyertakan array byte dan informasi lain tentang objek OLE.  
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami menambahkan sebuah diagram dari file Excel ke slide sebagai [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) menggunakan Aspose.Slides for .NET.  
**Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) mengambil ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

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

### **Menambahkan Bingkai Objek OLE yang Ditautkan**

Aspose.Slides for .NET memungkinkan Anda menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) tanpa menyematkan data tetapi hanya dengan tautan ke file.

Kode C# berikut menunjukkan cara menambahkan sebuah [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) dengan file Excel yang ditautkan ke slide:

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

## **Mengakses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Dapatkan referensi slide dengan menggunakan indeksnya.  
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut menjadi [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Ini adalah bingkai objek OLE yang ingin diakses.  
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan shape pertama sebagai bingkai objek OLE.
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

### **Mengakses Properti Bingkai OLE yang Ditautkan**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE yang ditautkan.

Kode C# berikut menunjukkan cara memeriksa apakah sebuah objek OLE ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan shape pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Periksa apakah objek OLE ditautkan.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Tampilkan jalur lengkap ke file yang ditautkan.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Tampilkan jalur relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Mengubah Data Objek OLE**

{{% alert color="info" title="Note" %}}

Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat instance kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses shape [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut menjadi [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Ini adalah bingkai objek OLE yang ingin diakses.  
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.  
5. Buat objek `Workbook` dan akses data OLE.  
6. Akses `Worksheet` yang diinginkan dan ubah datanya.  
7. Simpan `Workbook` yang diperbarui ke dalam sebuah stream.  
8. Ganti data objek OLE dari stream tersebut.

Pada contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan shape pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Baca data objek OLE sebagai objek Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modifikasi data workbook.
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

## **Menyematkan Tipe File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for .NET memungkinkan Anda menyematkan tipe file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, itu secara otomatis terbuka di program terkait, atau pengguna diminta memilih program yang sesuai untuk membukanya.

Kode C# berikut menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

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

## **Mengatur Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for .NET memungkinkan Anda mengatur tipe file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi filenya.

Kode C# berikut menunjukkan cara mengatur tipe file untuk objek OLE yang disematkan menjadi `zip`:

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

Setelah menyematkan sebuah objek OLE, pratinjau berupa gambar ikon ditambahkan secara otomatis. Pratinjau ini adalah apa yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for .NET.

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

## **Mencegah Bingkai Objek OLE Diubah Ukuran dan Posisinya**

Setelah Anda menambahkan objek OLE yang ditautkan ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, mungkin akan muncul pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta pembaruan data objek, atur properti `UpdateAutomatic` pada antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) menjadi `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Pertahankan ukuran dan posisi bingkai objek OLE ketika PowerPoint memperbarui tautan.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Mengekstrak File yang Disematkan**

Aspose.Slides for .NET memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) yang berisi objek OLE yang ingin Anda ekstrak.  
2. Loop melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode C# berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

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

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Apa yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "hidup" tidak dijalankan selama rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

Untuk juga mempertahankan file yang disematkan sebagai lampiran PDF, atur [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) ke `true`. Opsi ini dinonaktifkan secara default. Untuk contoh dan petunjuk memeriksa lampiran, lihat [Preserve Embedded OLE Files as PDF Attachments](/slides/id/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan [shape-level locks](/slides/id/net/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah pengeditan dan pemindahan tidak sengaja.

**Mengapa objek Excel yang ditautkan "melompat" atau berubah ukuran saat saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/net/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan mengatur gambar pengganti yang sesuai.

**Apakah jalur relatif untuk objek OLE yang ditautkan akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan di format PPT yang lebih lama. Untuk portabilitas, gunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.