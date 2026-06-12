---
title: Kelola Kontrol ActiveX dalam Presentasi Menggunakan C++
linktitle: ActiveX
type: docs
weight: 80
url: /id/cpp/activex/
keywords:
- ActiveX
- Kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk C++ memanfaatkan ActiveX untuk mengotomatisasi dan meningkatkan presentasi PowerPoint, memberikan kontrol yang kuat bagi pengembang atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk C++ memungkinkan Anda mengelola kontrol ActiveX, namun pengelolaannya sedikit lebih rumit dan berbeda dari bentuk presentasi biasa. Mulai Aspose.Slides untuk C++ 18.1, komponen ini mendukung pengelolaan kontrol ActiveX. Saat ini, Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya dengan menggunakan berbagai properti. Ingat, kontrol ActiveX bukan bentuk (shape) dan tidak termasuk dalam IShapeCollection presentasi tetapi berada di IControlCollection terpisah. Artikel ini menunjukkan cara bekerja dengan mereka.

## **Memodifikasi Kontrol ActiveX**
Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah pada sebuah slide:

1. Buat instance kelas Presentation dan muat presentasi yang berisi kontrol ActiveX.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Akses kontrol ActiveX pada slide dengan mengakses IControlCollection.
1. Akses kontrol ActiveX TextBox1 menggunakan objek ControlEx.
1. Ubah berbagai properti kontrol ActiveX TextBox1 termasuk teks, font, tinggi font, dan posisi frame.
1. Akses kontrol kedua yang bernama CommandButton1.
1. Ubah caption tombol, font, dan posisi.
1. Geser posisi frame kontrol ActiveX.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Potongan kode di bawah ini memperbarui kontrol ActiveX pada slide presentasi seperti yang ditunjukkan.

```cpp
// Mengakses presentasi dengan  kontrol ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Mengakses slide pertama dalam presentasi
auto slide = presentation->get_Slides()->idx_get(0);

// mengubah teks TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // mengubah gambar pengganti. Powerpoint akan mengganti gambar ini selama aktivasi activeX, jadi kadang diperbolehkan membiarkan gambar tidak berubah.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// mengubah caption Tombol
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // mengubah pengganti
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Memindahkan frame ActiveX turun 100 poin
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Simpan presentasi dengan Kontrol ActiveX yang Diedit
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Sekarang menghapus kontrol
slide->get_Controls()->Clear();

// Menyimpan presentasi dengan kontrol ActiveX yang dibersihkan
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Menambahkan Kontrol ActiveX Media Player**
Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk C++ memungkinkan Anda menambah dan mengelola kontrol ActiveX, namun pengelolaannya sedikit lebih rumit dan berbeda dari bentuk presentasi biasa. Mulai Aspose.Slides untuk C++ 18.1, dukungan untuk menambahkan kontrol ActiveX Media Player telah ditambahkan dalam Aspose.Slides. Ingat, kontrol ActiveX bukan bentuk dan tidak termasuk dalam IShapeCollection presentasi tetapi berada di IControlExCollection terpisah. Artikel ini menunjukkan cara bekerja dengan mereka. Untuk mengelola kontrol ActiveX Media Player, ikuti langkah‑langkah berikut:

1. Buat instance kelas Presentation dan muat contoh presentasi yang berisi kontrol ActiveX Media Player.
1. Buat instance kelas Presentation target dan hasilkan instance presentasi kosong.
1. Kloning slide yang berisi kontrol ActiveX Media Player dari presentasi templat ke Presentation target.
1. Akses slide hasil kloning di Presentation target.
1. Akses kontrol ActiveX pada slide dengan mengakses IControlCollection.
1. Akses kontrol ActiveX Media Player dan tetapkan jalur video dengan menggunakan propertinya.
1. Simpan presentasi ke file PPTX.

```cpp
// Membuat instance kelas Presentation yang mewakili file PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Membuat instance presentasi kosong
auto newPresentation = System::MakeObject<Presentation>();

// Menghapus slide default
newPresentation->get_Slides()->RemoveAt(0);

// Mengkloning slide dengan Kontrol ActiveX Pemutar Media
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Mengakses kontrol ActiveX Pemutar Media dan mengatur jalur video
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Menyimpan Presentasi
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan kembali jika kontrol tersebut tidak dapat dijalankan di runtime C++?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/memodifikasi properti serta frame mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam presentasi?**

Kontrol ActiveX adalah kontrol interaktif yang dikelola (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/cpp/manage-ole/) mengacu pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan ditangani secara berbeda serta memiliki model properti yang berbeda.

**Apakah peristiwa ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya dapat dijalankan di PowerPoint pada Windows ketika keamanan memperbolehkannya. Perpustakaan tidak mengeksekusi VBA.