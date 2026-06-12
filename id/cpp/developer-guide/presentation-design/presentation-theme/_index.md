---
title: Kelola Tema Presentasi di C++
linktitle: Tema Presentasi
type: docs
weight: 10
url: /id/cpp/presentation-theme/
keywords:
- Tema PowerPoint
- tema presentasi
- tema slide
- atur tema
- ubah tema
- kelola tema
- warna tema
- palet tambahan
- font tema
- gaya tema
- efek tema
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasai tema presentasi di Aspose.Slides untuk C++ untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan identitas merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi mendefinisikan properti elemen desain. Saat Anda memilih tema presentasi, Anda pada dasarnya memilih satu set elemen visual spesifik beserta propertinya.

Di PowerPoint, sebuah tema terdiri dari warna, [fonts](/slides/id/cpp/powerpoint-fonts/), [background styles](/slides/id/cpp/presentation-background/), dan efek.

![theme-constituents](theme-constituents.png)

## **Ubah Warna Tema**

Tema PowerPoint menggunakan satu set warna spesifik untuk elemen yang berbeda pada slide. Jika Anda tidak menyukai warnanya, Anda dapat mengubahnya dengan menerapkan warna baru untuk tema. Untuk memungkinkan Anda memilih warna tema baru, Aspose.Slides menyediakan nilai di bawah enumerasi [SchemeColor](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Kode C++ berikut menunjukkan cara mengubah warna aksen untuk sebuah tema:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Anda dapat menentukan nilai efektif warna yang dihasilkan dengan cara berikut:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Warna [A=255, R=128, G=100, B=162])
```

Untuk lebih mendemonstrasikan operasi perubahan warna, kami membuat elemen lain dan menetapkan warna aksen (dari operasi awal) kepadanya. Kemudian kami mengubah warna dalam tema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Warna baru secara otomatis diterapkan pada kedua elemen.

### **Atur Warna Tema dari Palet Tambahan**

Saat Anda menerapkan transformasi luminansi ke warna tema utama(1), warna dari palet tambahan(2) terbentuk. Anda kemudian dapat mengatur dan mengambil warna tema tersebut.

![additional-palette-colors](additional-palette-colors.png)

**1**- Warna tema utama

**2**- Warna dari palet tambahan.

Kode C++ berikut mendemonstrasikan operasi di mana warna palet tambahan diperoleh dari warna tema utama dan kemudian digunakan pada bentuk:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Pemetaan `SchemeColor` ke Warna `IColorScheme`**

Saat Anda bekerja dengan [SchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides.schemecolor/), Anda mungkin memperhatikan bahwa ia berisi nilai warna tema berikut:

`Background1`, `Background2`, `Text1`, dan `Text2`.

Namun, `Presentation::get_MasterTheme()::get_ColorScheme()` mengembalikan [IColorScheme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/icolorscheme/), yang mengekspos warna yang sesuai sebagai:

`Dark1`, `Dark2`, `Light1`, dan `Light2`.

Perbedaan ini hanya pada penamaan. Nilai-nilai tersebut merujuk pada slot warna tema yang sama dan pemetaannya tetap:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Tidak ada konversi dinamis antara `Text`/`Background` dan `Dark`/`Light`. Mereka hanya nama alternatif untuk warna tema yang sama.

Perbedaan penamaan ini berasal dari terminologi Microsoft Office. Versi Office lama menggunakan `Dark 1`, `Light 1`, `Dark 2`, dan `Light 2`, sementara versi UI baru menampilkan slot yang sama sebagai `Text 1`, `Background 1`, `Text 2`, dan `Background 2`.

## **Ubah Font Tema**

Untuk memungkinkan Anda memilih font untuk tema dan keperluan lainnya, Aspose.Slides menggunakan identifier khusus berikut (mirip dengan yang digunakan di PowerPoint):

* **+mn-lt** - Font Badan Latin (Minor Latin Font)
* **+mj-lt** - Font Heading Latin (Major Latin Font)
* **+mn-ea** - Font Badan Asia Timur (Minor East Asian Font)
* **+mj-ea** - Font Badan Asia Timur (Major East Asian Font)

Kode C++ berikut menunjukkan cara menetapkan font Latin ke elemen tema:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Kode C++ berikut menunjukkan cara mengubah font tema presentasi:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Font di semua kotak teks akan diperbarui.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [PowerPoint fonts](/slides/id/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Ubah Gaya Latar Belakang Tema**

Secara default, aplikasi PowerPoint menyediakan 12 latar belakang yang telah ditentukan, namun hanya 3 dari 12 latar belakang tersebut yang disimpan dalam presentasi tipikal.

![todo:image_alt_text](presentation-design_8.png)

Sebagai contoh, setelah Anda menyimpan presentasi di aplikasi PowerPoint, Anda dapat menjalankan kode C++ berikut untuk mengetahui jumlah latar belakang yang telah ditentukan dalam presentasi:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Menggunakan properti [BackgroundFillStyles](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.i_format_scheme/), Anda dapat menambah atau mengakses gaya latar belakang dalam tema PowerPoint. 
{{% /alert %}}

Kode C++ berikut menunjukkan cara mengatur latar belakang untuk sebuah presentasi:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Panduan indeks**: 0 digunakan untuk tanpa isi. Indeks dimulai dari 1.

{{% alert color="primary" title="TIP" %}} 
Anda mungkin ingin melihat [PowerPoint Background](/slides/id/cpp/presentation-background/).
{{% /alert %}}

## **Ubah Efek Tema**

Tema PowerPoint biasanya berisi 3 nilai untuk setiap array gaya. Array tersebut digabung menjadi 3 efek: subtle, moderate, dan intense. Misalnya, inilah hasil ketika efek diterapkan pada bentuk tertentu:

![todo:image_alt_text](presentation-design_10.png)

Dengan menggunakan 3 properti ([FillStyles](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) dari kelas [FormatScheme](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.theme.i_format_scheme/) Anda dapat mengubah elemen dalam tema (lebih fleksibel dibandingkan opsi di PowerPoint).

Kode C++ berikut menunjukkan cara mengubah efek tema dengan memodifikasi bagian-bagian elemen:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Perubahan yang dihasilkan pada warna isi, tipe isi, efek bayangan, dll:

![todo:image_alt_text](presentation-design_11.png)

## **Tanya Jawab**

**Apakah saya dapat menerapkan tema pada satu slide tanpa mengubah master?**

Ya. Aspose.Slides mendukung penimpaan tema tingkat slide, sehingga Anda dapat menerapkan tema lokal hanya pada slide tersebut sementara tema master tetap tidak berubah (melalui [SlideThemeManager](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/slidethememanager/)).

**Apa cara paling aman untuk memindahkan tema dari satu presentasi ke presentasi lain?**

[Clone slides](/slides/id/cpp/clone-slides/) bersama master-nya ke presentasi target. Ini mempertahankan master asli, tata letak, dan tema yang terkait sehingga tampilan tetap konsisten.

**Bagaimana saya dapat melihat nilai "effective" setelah semua pewarisan dan penimpaan?**

Gunakan tampilan ["effective"](/slides/id/cpp/shape-effective-properties/) API untuk tema/warna/font/efek. Tampilan ini mengembalikan properti yang telah diselesaikan dan final setelah menerapkan master serta penimpaan lokal.