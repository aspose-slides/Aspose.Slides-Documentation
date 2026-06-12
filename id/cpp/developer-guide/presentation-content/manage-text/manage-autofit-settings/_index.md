---
title: "Tingkatkan Presentasi Anda dengan AutoFit di C++"
linktitle: "Pengaturan Autofit"
type: docs
weight: 30
url: /id/cpp/manage-autofit-settings/
keywords:
- "kotak teks"
- "autofit"
- "tanpa autofit"
- "sesuaikan teks"
- "perkecil teks"
- "bungkus teks"
- "ubah ukuran bentuk"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Pelajari cara mengelola pengaturan AutoFit di Aspose.Slides untuk C++ guna mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument Anda serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, ketika Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fix text** untuk kotak teks—secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—meningkatkan tinggi—untuk memungkinkan menampung lebih banyak teks. 
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—mengurangi tinggi—untuk menghilangkan ruang yang berlebih. 

Di PowerPoint, ada 4 parameter atau opsi penting yang mengontrol perilaku autofit untuk kotak teks: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ menyediakan opsi serupa—beberapa metode di bawah kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi. 

## **Ubah Ukuran Bentuk Agar Muat Teks**

Jika Anda ingin teks dalam sebuah kotak selalu muat ke dalam kotak tersebut setelah perubahan pada teks, Anda harus menggunakan opsi **Resize shape to fix text**. Untuk menentukan pengaturan ini, set properti [AutofitType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format)) ke `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Kode C++ berikut menunjukkan cara menentukan bahwa teks harus selalu muat ke dalam kotaknya dalam presentasi PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (tinggi bertambah) untuk memastikan semua teks muat. Jika teks menjadi lebih pendek, hal sebaliknya terjadi. 

## **Jangan Autofit**

Jika Anda ingin sebuah kotak teks atau bentuk mempertahankan dimensinya apa pun perubahan pada teks yang dikandungnya, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, set properti [AutofitType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format)) ke `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Kode C++ berikut menunjukkan cara menentukan bahwa kotak teks harus selalu mempertahankan dimensinya dalam presentasi PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluap keluar. 

## **Kecilkan Teks saat Overflow**

Jika teks menjadi terlalu panjang untuk kotaknya, melalui opsi **Shrink text on overflow**, Anda dapat menentukan bahwa ukuran dan spasi teks harus diperkecil agar muat ke dalam kotaknya. Untuk menentukan pengaturan ini, set properti [AutofitType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format)) ke `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Kode C++ berikut menunjukkan cara menentukan bahwa teks harus diperkecil saat overflow dalam presentasi PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Ketika opsi **Shrink text on overflow** digunakan, pengaturan ini hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya. 
{{% /alert %}}

## **Bungkus Teks**

Jika Anda ingin teks dalam sebuah bentuk dibungkus di dalam bentuk tersebut ketika teks melewati batas bentuk (hanya lebar), Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, Anda harus mengatur properti [WrapText](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame_format)) ke `true`. 

Kode C++ berikut menunjukkan cara menggunakan pengaturan Wrap Text dalam presentasi PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Catatan" color="warning" %}} 
Jika Anda mengatur properti `WrapText` menjadi `False` untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas melewati batas bentuk dalam satu baris tunggal. 
{{% /alert %}}

## **FAQ**

**Apakah margin internal bingkai teks memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan aktif lebih awal—memperkecil font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum menyesuaikan AutoFit.

**Bagaimana AutoFit berinteraksi dengan jeda baris manual dan lunak?**

Jeda paksa tetap berada di tempatnya, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus jeda yang tidak diperlukan sering mengurangi kebutuhan AutoFit untuk memampatkan teks secara agresif.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti ke font dengan metrik glif yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir dan pembungkus baris. Setelah perubahan atau substitusi font apa pun, periksa kembali slide.