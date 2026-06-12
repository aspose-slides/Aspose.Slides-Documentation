---
title: Kelola Workbook Chart dalam Presentasi Menggunakan C++
linktitle: Workbook Chart
type: docs
weight: 70
url: /id/cpp/chart-workbook/
keywords:
- workbook chart
- data chart
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan Aspose.Slides untuk C++: kelola workbook chart dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan workbook chart di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data chart melalui aliran workbook, menggunakan sel workbook sebagai label data chart, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai chart.

Artikel ini juga membahas penggunaan workbook eksternal sebagai sumber data chart. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke chart, dan mengedit data chart ketika workbook tersedia.

## **Membaca dan Menulis Data Chart dari Workbook**

Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis workbook data chart (yang berisi data chart yang diedit dengan Aspose.Cells). **Catatan** bahwa data chart harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Kode C++ ini menunjukkan operasi untuk menetapkan workbook data chart:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Menetapkan Sel Workbook sebagai Label Data Chart**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan chart Bubble dengan beberapa data.
1. Akses seri chart.
1. Tetapkan sel workbook sebagai label data.
1. Simpan presentasi.

Kode C++ ini menunjukkan cara menetapkan sel workbook sebagai label data chart:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Membuat instance kelas Presentation yang mewakili file presentasi 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Mengelola Worksheet**

Kode C++ ini menunjukkan operasi di mana metode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) digunakan untuk mengakses koleksi worksheet:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Menentukan Tipe Sumber Data**

Kode C++ ini menunjukkan cara menentukan tipe untuk sumber data:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Mendeteksi Format Workbook Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat tersemat dalam beberapa chart. Anda dapat menggunakan metode `get_EmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichartdata/) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan chart tersebut.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Workbook tersemat berformat .xlsb, yang tidak didukung.
        continue;
    }

    // Baca atau ubah data workbook chart di sini.
}
```

## **Workbook Eksternal**

{{% alert color="primary" %}} 
Di [Aspose.Slides](https://releases.aspose.com/slides/id/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, kami menambahkan dukungan untuk workbook eksternal sebagai sumber data bagi chart.
{{% /alert %}} 

### **Membuat Workbook Eksternal**

Dengan metode **`ReadWorkbookStream`** dan **`SetExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode C++ ini menunjukkan proses pembuatan workbook eksternal:

```c++
auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Menetapkan Workbook Eksternal**

Dengan metode **`IChartData::SetExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke sebuah chart sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut secara otomatis akan dikonversi menjadi jalur lengkap.

Kode C++ ini menunjukkan cara menetapkan workbook eksternal:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

Parameter `updateChartData` (di bawah metode `SetExternalWorkbook`) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak. 

* Ketika nilai `updateChartData` disetel ke `false`, hanya jalur workbook yang diperbarui — data chart tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia. 
* Ketika nilai `updateChartData` disetel ke `true`, data chart diperbarui dari workbook target.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Mendapatkan Jalur Workbook Sumber Data Eksternal dari Sebuah Chart**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk bentuk chart.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data chart.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber workbook eksternal.

Kode C++ ini menunjukkan operasi tersebut:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Menyimpan presentasi
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Mengedit Data Chart**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilemparkan.

Kode C++ ini merupakan implementasi proses yang dijelaskan:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah chart terhubung ke workbook eksternal atau tersemat?**

Ya. Sebuah chart memiliki [tipe sumber data](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perhatikan bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang terletak pada sumber daya/jaringan bersama?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook remote secara langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak dimodifikasi saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan yang umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/cpp/)) dan menautkan ke salinan tersebut.

**Apakah beberapa chart dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap chart menyimpan tautannya masing‑masing. Jika semua chart menunjuk ke file yang sama, pembaruan file tersebut akan tercermin pada setiap chart pada saat data dimuat berikutnya.