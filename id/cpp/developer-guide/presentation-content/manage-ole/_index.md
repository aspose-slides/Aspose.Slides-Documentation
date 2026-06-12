---
title: Kelola OLE dalam Presentasi Menggunakan C++
linktitle: Kelola OLE
type: docs
weight: 40
url: /id/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "Optimalkan manajemen objek OLE dalam file PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++. Sematkan, perbarui, dan ekspor konten OLE secara mulus."
---
## **Pendahuluan**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) adalah teknologi Microsoft yang memungkinkan data dan objek yang dibuat dalam satu aplikasi ditempatkan di aplikasi lain melalui penautan atau penyematan. 
{{% /alert %}} 

Pertimbangkan sebuah diagram yang dibuat di MS Excel. Diagram tersebut kemudian ditempatkan di dalam slide PowerPoint. Diagram Excel itu dianggap sebagai objek OLE. 

- Objek OLE dapat muncul sebagai ikon. Dalam kasus ini, ketika Anda mengklik ganda ikon, diagram akan terbuka di aplikasi terkait (Excel), atau Anda akan diminta memilih aplikasi untuk membuka atau menyunting objek. 
- Objek OLE dapat menampilkan isi sebenarnya, seperti isi sebuah diagram. Dalam kasus ini, diagram diaktifkan di PowerPoint, antarmuka diagram dimuat, dan Anda dapat memodifikasi data diagram di dalam PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/id/cpp/) memungkinkan Anda menyisipkan OLE Objects ke dalam slide sebagai bingkai objek OLE ([OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/)).

## **Tambahkan Bingkai OLE Object ke Slide**

Anda sudah membuat diagram di Microsoft Excel dan ingin menyematkannya ke dalam slide sebagai bingkai OLE object menggunakan Aspose.Slides for C++, Anda dapat melakukannya dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Baca file Excel sebagai array byte. 
4. Tambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) ke slide yang berisi array byte dan informasi lain tentang objek OLE. 
5. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX. 

Pada contoh di bawah, kami menambahkan diagram dari file Excel ke slide sebagai [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) menggunakan Aspose.Slides for C++. **Catatan** bahwa konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) mengambil ekstensi objek yang dapat disematkan sebagai parameter kedua. Ekstensi ini memungkinkan PowerPoint menginterpretasikan tipe file dengan benar dan memilih aplikasi yang tepat untuk membuka objek OLE ini.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Tambahkan Bingkai OLE Object Tertaut**

Aspose.Slides for C++ memungkinkan Anda menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) tanpa menyematkan data, melainkan hanya dengan tautan ke file.

Kode C++ berikut menunjukkan cara menambahkan [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/) dengan file Excel yang ditautkan ke sebuah slide:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Tambah bingkai OLE object dengan file Excel yang ditautkan.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Akses Bingkai OLE Object**

Jika sebuah objek OLE sudah disematkan dalam slide, Anda dapat dengan mudah menemukannya atau mengaksesnya dengan cara berikut:

1. Muat sebuah presentasi dengan objek OLE yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation). 
2. Dapatkan referensi slide dengan menggunakan indeksnya. 
3. Akses bentuk [OleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang hanya memiliki satu bentuk pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/). Ini adalah bingkai OLE object yang diinginkan untuk diakses. 
4. Setelah bingkai OLE object diakses, Anda dapat melakukan operasi apa pun padanya. 

Pada contoh di bawah, sebuah bingkai OLE object (objek diagram Excel yang disematkan dalam slide) dan data file-nya diakses.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Dapatkan data file yang disematkan.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Dapatkan ekstensi file yang disematkan.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Akses Properti Bingkai OLE Object Tertaut**

Aspose.Slides memungkinkan Anda mengakses properti bingkai OLE object yang ditautkan.

Kode C++ berikut menunjukkan cara memeriksa apakah sebuah OLE object ditautkan dan kemudian memperoleh jalur ke file yang ditautkan:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Periksa apakah objek OLE ditautkan.
    if (oleFrame->get_IsObjectLink())
    {
        // Cetak jalur lengkap ke file yang ditautkan.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Cetak jalur relatif ke file yang ditautkan jika ada.
        // Hanya presentasi PPT yang dapat berisi jalur relatif.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Ubah Data OLE Object**

{{% alert color="primary" %}} 
Pada bagian ini, contoh kode di bawah menggunakan [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

Jika sebuah OLE object sudah disematkan dalam slide, Anda dapat dengan mudah mengakses objek tersebut dan memodifikasi datanya dengan cara berikut:

1. Muat sebuah presentasi dengan OLE object yang disematkan dengan membuat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation). 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses bentuk [OLEObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/). Dalam contoh kami, kami menggunakan PPTX yang sebelumnya dibuat yang memiliki satu bentuk pada slide pertama. Kami kemudian *cast* objek tersebut sebagai [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/). Ini adalah bingkai OLE object yang diinginkan untuk diakses. 
4. Setelah bingkai OLE object diakses, Anda dapat melakukan operasi apa pun padanya. 
5. Buat objek `Workbook` dan akses data OLE. 
6. Akses `Worksheet` yang diinginkan dan ubah data. 
7. Simpan `Workbook` yang diperbarui ke dalam stream. 
8. Ubah data OLE object dari stream. 

Pada contoh di bawah, sebuah bingkai OLE object (objek diagram Excel yang disematkan dalam slide) diakses, dan data file-nya dimodifikasi untuk memperbarui data diagram.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Dapatkan bentuk pertama sebagai bingkai objek OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Baca data objek OLE sebagai objek Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modifikasi data workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Ubah data objek bingkai OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Sematkan Jenis File Lain ke Slide**

Selain diagram Excel, Aspose.Slides for C++ memungkinkan Anda menyematkan jenis file lain ke dalam slide. Misalnya, Anda dapat menyisipkan file HTML, PDF, dan ZIP sebagai objek. Ketika pengguna mengklik ganda objek yang disisipkan, ia secara otomatis terbuka di program yang relevan, atau pengguna diminta memilih program yang sesuai untuk membukanya.

Kode C++ berikut menunjukkan cara menyematkan HTML dan ZIP ke dalam slide:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tetapkan Tipe File untuk Objek yang Disematkan**

Saat bekerja dengan presentasi, Anda mungkin perlu mengganti objek OLE lama dengan yang baru atau mengganti objek OLE yang tidak didukung dengan yang didukung. Aspose.Slides for C++ memungkinkan Anda menetapkan tipe file untuk objek yang disematkan, sehingga Anda dapat memperbarui data bingkai OLE atau ekstensinya.

Kode C++ berikut menunjukkan cara menetapkan tipe file untuk objek OLE yang disematkan menjadi `zip`:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Ubah tipe file menjadi ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tetapkan Gambar Ikon dan Judul untuk Objek yang Disematkan**

Setelah menyematkan sebuah OLE object, pratinjau yang terdiri dari gambar ikon secara otomatis ditambahkan. Pratinjau ini adalah apa yang dilihat pengguna sebelum mengakses atau membuka OLE object. Jika Anda ingin menggunakan gambar dan teks tertentu sebagai elemen dalam pratinjau, Anda dapat menetapkan gambar ikon dan judul menggunakan Aspose.Slides for C++.

Kode C++ berikut menunjukkan cara menetapkan gambar ikon dan judul untuk objek yang disematkan: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Tambahkan gambar ke sumber daya presentasi.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Cegah Bingkai OLE Object Agar Tidak Diubah Ukuran dan Posisi**

Setelah Anda menambahkan OLE object yang ditautkan ke slide presentasi, ketika membuka presentasi di PowerPoint, Anda mungkin melihat pesan yang meminta Anda memperbarui tautan. Mengklik tombol "Update Links" dapat mengubah ukuran dan posisi bingkai OLE object karena PowerPoint memperbarui data dari OLE object yang ditautkan dan menyegarkan pratinjau objek. Untuk mencegah PowerPoint meminta memperbarui data objek, setel metode `set_UpdateAutomatic` dari antarmuka [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/) ke `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Ekstrak File yang Disematkan**

Aspose.Slides for C++ memungkinkan Anda mengekstrak file yang disematkan dalam slide sebagai OLE objects dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) yang berisi OLE objects yang ingin Anda ekstrak. 
2. Loop melalui semua bentuk dalam presentasi dan akses bentuk [OLEObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/oleobjectframe/). 
3. Akses data file yang disematkan dari bingkai OLE object dan tulis ke disk. 

Kode C++ berikut menunjukkan cara mengekstrak file yang disematkan dalam slide sebagai OLE objects:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**Apakah konten OLE akan dirender saat mengekspor slide ke PDF/gambar?**

Apa yang terlihat pada slide yang dirender—ikon/gambar pengganti (pratinjau). Konten OLE "live" tidak dieksekusi selama proses rendering. Jika diperlukan, atur gambar pratinjau Anda sendiri untuk memastikan tampilan yang diharapkan dalam PDF yang diekspor.

**Bagaimana saya dapat mengunci OLE object pada slide sehingga pengguna tidak dapat memindahkan/mengeditnya di PowerPoint?**

Kunci bentuk: Aspose.Slides menyediakan [kunci tingkat bentuk](/slides/id/cpp/applying-protection-to-presentation/). Ini bukan enkripsi, tetapi secara efektif mencegah penyuntingan dan perpindahan tidak sengaja.

**Mengapa objek Excel yang ditautkan "melompat" atau berubah ukuran ketika saya membuka presentasi?**

PowerPoint mungkin menyegarkan pratinjau OLE yang ditautkan. Untuk tampilan yang stabil, ikuti praktik [Solusi Pengerjaan untuk Pengubahan Ukuran Worksheet](/slides/id/cpp/working-solution-for-worksheet-resizing/)—baik menyesuaikan bingkai dengan rentang, atau menskalakan rentang ke bingkai tetap dan mengatur gambar pengganti yang sesuai.

**Apakah jalur relatif untuk OLE object yang ditautkan akan dipertahankan dalam format PPTX?**

Dalam PPTX, informasi "jalur relatif" tidak tersedia—hanya jalur lengkap. Jalur relatif ditemukan di format PPT yang lebih lama. Untuk portabilitas, lebih baik menggunakan jalur absolut yang dapat diandalkan/URI yang dapat diakses atau menyematkan.