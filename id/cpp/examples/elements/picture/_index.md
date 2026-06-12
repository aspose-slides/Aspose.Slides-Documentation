---
title: Gambar
type: docs
weight: 50
url: /id/cpp/examples/elements/picture/
keywords:
- contoh kode
- gambar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan gambar di Aspose.Slides untuk C++: sisipkan, pangkas, kompres, ubah warna, dan ekspor gambar dengan contoh C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyisipkan dan mengakses gambar dari gambar dalam memori menggunakan **Aspose.Slides for C++**. Contoh di bawah membuat gambar dalam memori, menempatkannya pada slide, dan kemudian mengambilnya.

## **Menambahkan Gambar**

Kode ini menghasilkan bitmap kecil, mengkonversinya menjadi aliran, dan menyisipkannya sebagai bingkai gambar pada slide pertama.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Buat gambar dalam memori yang sederhana.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Konversi bitmap menjadi array byte.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Tambahkan gambar ke presentasi.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Mengakses Gambar**

Contoh ini memastikan sebuah slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```