---
title: Kelola Objek OLE dalam Presentasi di .NET
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/net/manage-ole/
keywords:
- objek OLE
- Penautan & Penyematan Objek
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
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET. Sematkan, perbarui, dan ekspor konten OLE dengan mulus."
---
## **Pendahuluan**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 

{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel tersebut dianggap sebagai objek OLE. 

- Sebuah objek OLE dapat muncul sebagai ikon. Dalam hal ini, ketika Anda mengklik ganda ikon, diagram akan terbuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau menyunting objek. 
- Sebuah objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam hal ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/id/net/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe)).

## **Tambah Bingkai Objek OLE ke Slide**

Misalkan Anda sudah membuat sebuah diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai objek OLE menggunakan Aspose.Slides for .NET, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Baca file Excel sebagai array byte.
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) ke slide yang berisi array byte dan informasi lain tentang objek OLE.
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah, kami menambahkan sebuah diagram dari file Excel ke slide sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) menggunakan Aspose.Slides for .NET. **Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/net/aspose.slides.dom.ole/oleembeddeddatainfo/) menerima ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint untuk menginterpretasikan jenis file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

```csharp 
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

### **Tambah Bingkai Objek OLE Tertaut**

Aspose.Slides for .NET memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) tanpa menyematkan data tetapi hanya dengan tautan ke file.

Kode C# berikut menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe) dengan file Excel yang tertaut ke sebuah slide:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan bingkai objek OLE dengan file Excel yang tertaut.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Akses Bingkai Objek OLE**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Akses shape [OleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe).
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

```csharp 
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

### **Akses Properti Bingkai Objek OLE Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai objek OLE tertaut.

Kode C# berikut menunjukkan cara memeriksa apakah sebuah objek OLE tertaut dan kemudian mendapatkan jalur ke file yang tertaut:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Dapatkan shape pertama sebagai bingkai objek OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Periksa apakah objek OLE tertaut.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Cetak jalur lengkap ke file yang tertaut.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Cetak jalur relatif ke file yang tertaut jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Ubah Data Objek OLE**

{{% alert color="primary" %}} 

Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe).
   Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu shape pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe). Ini adalah bingkai objek OLE yang diinginkan untuk diakses.
4. Setelah bingkai objek OLE diakses, Anda dapat melakukan operasi apa pun padanya.
5. Buat objek `Workbook` dan akses data OLE.
6. Akses `Worksheet` yang diinginkan dan ubah data.
7. Simpan `Workbook` yang diperbarui ke dalam stream.
8. Ubah data objek OLE dari stream.

Dalam contoh di bawah, sebuah bingkai objek OLE (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Ubah data workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

## **Sematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for .NET memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, objek tersebut secara otomatis terbuka di program yang relevan, atau pengguna akan diminta memilih program yang sesuai untuk membukanya.

Kode C# berikut menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

```c#
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

## **Atur Jenis File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for .NET memungkinkan Anda mengatur jenis file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensi nya.

Kode C# berikut menunjukkan cara mengatur jenis file untuk objek OLE yang disematkan menjadi `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Ubah jenis file menjadi ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Atur Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan objek OLE, sebuah pratinjau yang terdiri dari gambar ikon ditambahkan secara otomatis. Pratinjau ini adalah apa yang dilihat pengguna sebelum mengakses atau membuka objek OLE. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat mengatur gambar ikon dan judul menggunakan Aspose.Slides for .NET.

Kode C# berikut menunjukkan cara mengatur gambar ikon dan judul untuk objek yang disematkan: 

```c#
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

## **Cegah Bingkai Objek OLE Diubah Ukuran dan Posisi**

Setelah Anda menambahkan objek OLE tertaut ke slide presentasi, ketika Anda membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai objek OLE karena PowerPoint memperbarui data dari objek OLE tertaut dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta memperbarui data objek, atur properti `UpdateAutomatic` dari antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ioleobjectframe/) menjadi `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Ekstrak File yang Disematkan**

Aspose.Slides for .NET memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai objek OLE dengan cara berikut:
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi objek OLE yang ingin Anda ekstrak.
2. Loop melalui semua shape dalam presentasi dan akses shape [OLEObjectFrame](https://reference.aspose.com/slides/id/net/aspose.slides/oleobjectframe).
3. Akses data file yang disematkan dari bingkai objek OLE dan tulis ke disk.

Kode C# berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai objek OLE:

```c#
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

Yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dieksekusi selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan pada PDF yang diekspor.

**Bagaimana cara mengunci objek OLE pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci shape: Aspose.Slides menyediakan [kunci pada level shape](/slides/id/net/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah penyuntingan dan pemindahan yang tidak disengaja.

**Mengapa objek Excel yang tertaut "melompat" atau berubah ukuran saat saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang tertaut. Untuk tampilan yang stabil, ikuti praktik [Working Solution for Worksheet Resizing](/slides/id/net/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan mengatur gambar pengganti yang sesuai.

**Apakah jalur relatif untuk objek OLE yang tertaut akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan pada format PPT yang lebih lama. Untuk portabilitas, lebih pilih jalur absolut yang dapat diandalkan/URI yang dapat diakses atau penyematan.