---
title: Solusi Bekerja untuk Perubahan Ukuran Diagram di PPTX
type: docs
weight: 60
url: /id/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- perubahan ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk C++. Pelajari dua metode dengan kode untuk menjaga ukuran tetap konsisten."
---
## **Latar Belakang**

Diketahui bahwa diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose diubah ukurannya ke skala yang tidak ditentukan setelah aktivasi pertama. Perilaku ini menyebabkan perbedaan visual yang jelas dalam presentasi antara keadaan diagram sebelum dan sesudah aktivasi. Tim Aspose telah menyelidiki masalah ini secara detail dan menemukan solusi. Artikel ini menjelaskan penyebab masalah dan perbaikan yang sesuai.

Di [artikel sebelumnya](/slides/id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk C++ dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk C++. Untuk mengatasi [masalah pratinjau objek](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram tersebut. Dalam presentasi hasil, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun yang diinginkan pada buku kerja Excel yang mendasarinya dan kemudian kembali ke slide yang bersangkutan dengan mengklik di luar buku kerja yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Namun, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran dan mempertahankan proporsi yang tepat sebagai bagian dari proses penyematan. Bergantung pada perbedaan antara ukuran jendela Excel dan ukuran atau posisi bingkai objek OLE, perubahan ukuran terjadi.

## **Solusi yang Berjalan**

Ada dua skenario yang mungkin untuk membuat presentasi PowerPoint menggunakan Aspose.Slides untuk C++.

**Skenario 1:** Buat presentasi berdasarkan templat yang ada.

**Skenario 2:** Buat presentasi dari awal.

Solusi yang kami berikan di sini berlaku untuk kedua skenario. Dasar semua pendekatan solusi adalah sama: **ukuran jendela objek OLE yang disematkan harus cocok dengan bingkai objek OLE di slide PowerPoint**. Sekarang kami akan membahas dua pendekatan untuk solusi ini.

## **Pendekatan Pertama**

Dalam pendekatan ini, kita akan mempelajari cara mengatur ukuran jendela buku kerja Excel yang disematkan agar sesuai dengan ukuran bingkai objek OLE di slide PowerPoint.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Anggap ada sebuah bentuk pada indeks 2 dalam templat di mana kami ingin menempatkan bingkai OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran bingkai objek OLE sudah ditentukan sebelumnya—ukuran tersebut cocok dengan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran jendela buku kerja agar sama dengan ukuran bentuk tersebut. Potongan kode berikut memenuhi tujuan ini:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Tentukan ukuran diagram dengan jendela. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Atur lebar jendela buku kerja dalam inci (dibagi 72 karena PowerPoint menggunakan 72 piksel per inci).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Atur tinggi jendela buku kerja dalam inci.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Simpan buku kerja ke aliran memori.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Skenario 2**

Katakanlah kami ingin membuat presentasi dari awal dan menyertakan bingkai objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat bingkai objek OLE dengan tinggi 4 inci dan lebar 9,5 inci pada x = 0,5 inci dan y = 1 inci di slide. Kemudian kami mengatur jendela buku kerja Excel ke ukuran yang sama—tinggi 4 inci dan lebar 9,5 inci.

```cpp
// Tinggi yang diinginkan.
int32_t desiredHeight = 288; // 4 inci (4 * 72)

// Lebar yang diinginkan.
int32_t desiredWidth = 684; // 9.5 inci (9.5 * 72)

// Tentukan ukuran diagram dengan jendela. 
chart->SetSizeWithWindow(true);

// Atur lebar jendela buku kerja dalam inci.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Atur tinggi jendela buku kerja dalam inci.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Simpan buku kerja ke aliran memori.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Buat bingkai objek OLE dengan data Excel yang disematkan.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Pendekatan Kedua**

Dalam pendekatan ini, kita akan mempelajari cara mengatur ukuran diagram dalam buku kerja Excel yang disematkan agar sesuai dengan ukuran bingkai objek OLE di slide PowerPoint. Pendekatan ini berguna ketika ukuran diagram sudah diketahui sebelumnya dan tidak akan berubah.

**Skenario 1**

Misalkan kami telah mendefinisikan sebuah templat dan ingin membuat presentasi berdasarkan templat tersebut. Anggap ada sebuah bentuk pada indeks 2 dalam templat di mana kami bermaksud menempatkan bingkai OLE yang berisi buku kerja Excel yang disematkan. Dalam skenario ini, ukuran bingkai OLE sudah ditentukan—sesuai dengan ukuran bentuk pada indeks 2 dalam templat. Yang perlu kami lakukan hanyalah mengatur ukuran diagram dalam buku kerja agar sama dengan ukuran bentuk tersebut. Potongan kode berikut memenuhi tujuan ini:

```cpp
// Tentukan ukuran diagram tanpa jendela. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Atur lebar diagram dalam piksel (kalikan dengan 96 karena Excel menggunakan 96 piksel per inci).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Atur tinggi diagram dalam piksel.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Tentukan ukuran cetak diagram.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Simpan buku kerja ke aliran memori.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Buat bingkai objek OLE dengan data Excel yang disematkan.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Skenario 2**

Misalkan kami ingin membuat presentasi dari awal dan menyertakan bingkai objek OLE dengan ukuran apa pun yang berisi buku kerja Excel yang disematkan. Pada potongan kode berikut, kami membuat bingkai objek OLE dengan tinggi 4 inci dan lebar 9,5 inci di slide pada x = 0,5 inci dan y = 1 inci. Kami juga mengatur ukuran diagram yang sesuai ke dimensi yang sama: tinggi 4 inci dan lebar 9,5 inci.

```cpp
// Tinggi yang diinginkan.
int32_t desiredHeight = 288; // 4 inci (4 * 576)

// Lebar yang diinginkan.
int32_t desiredWidth = 684; // 9.5 inci(9.5 * 576)

// Tentukan ukuran diagram tanpa jendela. 
chart->SetSizeWithWindow(false);

// Atur lebar diagram dalam piksel.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Atur tinggi diagram dalam piksel.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Simpan buku kerja ke aliran memori.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Buat bingkai objek OLE dengan data Excel yang disematkan.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Kesimpulan**

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran diagram. Pilihan pendekatan tergantung pada kebutuhan dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi sendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan mencocokkan ukuran jendela buku kerja Excel atau ukuran diagram dengan ukuran bingkai objek OLE sebelum penyematan, Anda dapat menjaga konsistensi ukuran diagram.

**Pendekatan mana yang harus saya gunakan, mengatur ukuran jendela buku kerja atau mengatur ukuran diagram?**

Gunakan **Pendekatan 1 (ukuran jendela)** jika Anda ingin mempertahankan rasio aspek buku kerja dan mungkin memungkinkan perubahan ukuran di kemudian hari.  
Gunakan **Pendekatan 2 (ukuran diagram)** jika dimensi diagram bersifat tetap dan tidak akan berubah setelah penyematan.

**Apakah metode ini akan berfungsi dengan presentasi berbasis templat dan presentasi baru?**

Ya. Kedua pendekatan bekerja sama untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai objek OLE?**

Tidak. Anda dapat mengatur bingkai OLE ke ukuran berapa pun selama skala sesuai dengan ukuran buku kerja atau diagram.

**Bisakah saya menggunakan metode ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh-contoh dirancang untuk diagram Excel yang dibuat dengan Aspose.Cells, tetapi prinsipnya berlaku untuk program spreadsheet lain yang kompatibel dengan OLE selama mereka mendukung opsi pengaturan ukuran serupa.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)