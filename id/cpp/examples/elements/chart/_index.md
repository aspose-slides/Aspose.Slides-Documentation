---
title: Grafik
type: docs
weight: 60
url: /id/cpp/examples/elements/chart/
keywords:
- contoh kode
- grafik
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi grafik dengan Aspose.Slides for C++: buat, format, hubungkan data, dan ekspor grafik dalam PPT, PPTX, dan ODP dengan contoh C++."
---
Contoh menambahkan, mengakses, menghapus, dan memperbarui berbagai jenis grafik dengan **Aspose.Slides for C++**. Potongan kode di bawah ini menunjukkan operasi grafik dasar.

## **Menambahkan Grafik**

Metode ini menambahkan grafik area sederhana ke slide pertama.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tambahkan grafik area sederhana ke slide pertama.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Mengakses Grafik**

Setelah membuat grafik, Anda dapat mengambilnya melalui koleksi shape.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Akses grafik pertama pada slide.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Menghapus Grafik**

Kode berikut menghapus grafik dari sebuah slide.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Hapus grafik.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Memperbarui Data Grafik**

Anda dapat mengubah properti grafik seperti judul.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Ubah judul grafik.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```