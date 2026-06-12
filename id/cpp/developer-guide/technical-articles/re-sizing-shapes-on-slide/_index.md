---
title: Ubah Ukuran Bentuk pada Slide Presentasi
type: docs
weight: 100
url: /id/cpp/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Ikhtisar**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides untuk C++ adalah bagaimana mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak selaras saat ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk agar sesuai dengan tata letak slide yang baru.

```cpp
// Muat file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Dapatkan ukuran slide asli.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ubah ukuran slide tanpa menskalakan bentuk yang ada.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Dapatkan ukuran slide baru.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Skala ukuran bentuk.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam kasus tersebut, setiap sel dalam tabel harus diubah ukurannya.{{% /alert %}} 

Gunakan kode berikut di sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, mengatur lebar atau tinggi merupakan kasus khusus: Anda harus menyesuaikan tinggi baris individu dan lebar kolom untuk mengubah ukuran keseluruhan tabel.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dapatkan ukuran slide asli.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ubah ukuran slide tanpa menskalakan bentuk yang ada.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Dapatkan ukuran slide baru.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skala ukuran bentuk.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skala posisi bentuk.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Mengapa bentuk terdistorsi atau terpotong setelah mengubah ukuran slide?**

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk tidak selaras.

**Apakah kode yang diberikan bekerja untuk semua jenis bentuk?**

Contoh dasar bekerja untuk sebagian besar jenis bentuk (kotak teks, gambar, diagram, dll.). Namun, untuk tabel, Anda perlu menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel‑sel individual.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Anda harus melintasi semua baris dan kolom tabel dan mengubah ukuran tinggi serta lebar mereka secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

**Apakah perubahan ukuran ini bekerja untuk master slide dan layout slide?**

Ya, tetapi Anda juga harus melintasi [Masters](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) dan [Layout slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_layoutslides/) serta menerapkan logika skala yang sama pada bentuk‑bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

**Bisakah saya mengubah orientasi slide (potret/landskap) bersama dengan mengubah ukuran?**

Ya. Anda dapat menggunakan [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/set_orientation/) untuk mengubah orientasi. Pastikan Anda menyesuaikan logika skala secara tepat untuk mempertahankan tata letak.

**Apakah ada batasan ukuran slide yang dapat saya atur?**

Aspose.Slides mendukung ukuran khusus, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Anda dapat memeriksa metode `get_AspectRatioLocked` pada bentuk sebelum melakukan skala. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional alih‑alih men-skala keduanya secara terpisah.