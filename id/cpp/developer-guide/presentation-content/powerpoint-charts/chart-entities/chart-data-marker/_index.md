---
title: Kelola Penanda Data Diagram dalam Presentasi Menggunakan C++
linktitle: Penanda Data
type: docs
url: /id/cpp/chart-data-marker/
keywords:
- diagram
- titik data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data diagram di Aspose.Slides untuk C++, meningkatkan dampak presentasi di format PPT dan PPTX dengan contoh kode C++ yang jelas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan penanda data diagram di Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, mengakses seri dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang diperbarui. Artikel ini juga mencatat bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan bahwa tampilan penanda dipertahankan saat mengekspor diagram ke format raster atau SVG.

## **Set Penanda Diagram**
Aspose.Slides for C++ menyediakan API sederhana untuk mengatur penanda seri diagram secara otomatis. Pada fitur berikut, setiap seri diagram akan mendapatkan simbol penanda default yang berbeda secara otomatis.

Contoh kode di bawah ini menunjukkan cara mengatur penanda seri diagram secara otomatis.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Set Opsi Penanda Diagram**
Penanda dapat diatur pada titik data diagram dalam suatu seri tertentu. Untuk mengatur opsi penanda diagram, ikuti langkah-langkah di bawah ini:

- Instansiasi [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) class.
- Membuat diagram default.
- Mengatur gambar.
- Ambil seri diagram pertama.
- Tambahkan titik data baru.
- Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur opsi penanda diagram pada tingkat titik data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Set Penanda Diagram pada Tingkat Titik Data Seri**
Sekarang, penanda dapat diatur pada titik data diagram dalam suatu seri tertentu. Untuk mengatur opsi penanda diagram, ikuti langkah-langkah di bawah ini:

- Instansiasi Presentation class.
- Membuat diagram default.
- Mengatur gambar.
- Ambil seri diagram pertama.
- Tambahkan titik data baru.
- Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur opsi penanda diagram pada tingkat titik data.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instansiasi kelas Presentation yang mewakili file PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Akses slide pertama
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Tambahkan diagram dengan data default
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Menetapkan indeks lembar data diagram
int defaultWorksheetIndex = 0;

// Mendapatkan lembar kerja data diagram
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Hapus seri dan kategori yang dihasilkan secara default
chart->get_ChartData()->get_Series()->Clear();

// Sekarang, menambahkan seri baru
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Dapatkan gambar
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Tambahkan gambar ke koleksi gambar presentasi
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Tambahkan titik baru (1:3) di sana.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Terapkan Warna pada Titik Data**
Anda dapat menerapkan warna pada titik data dalam diagram menggunakan Aspose.Slides for C++. Kelas [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) dan **[IChartDataPointLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdatapointlevel/)** telah ditambahkan untuk mengakses properti tingkat titik data. Artikel ini menunjukkan cara mengakses dan menerapkan warna pada titik data dalam diagram.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Bentuk penanda apa yang tersedia secara bawaan?**

Bentuk standar tersedia (lingkaran, persegi, belah ketupat, segitiga, dll); daftar tersebut didefinisikan oleh enumerasi [MarkerStyleType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/markerstyletype/) . Jika Anda memerlukan bentuk yang tidak standar, gunakan penanda dengan isian gambar untuk meniru visual kustom.

**Apakah penanda dipertahankan saat mengekspor diagram ke gambar atau SVG?**

Ya. Saat merender diagram ke [format raster](/slides/id/cpp/convert-powerpoint-to-png/) atau menyimpan [bentuk sebagai SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilan dan pengaturannya, termasuk ukuran, isian, dan garis tepi.