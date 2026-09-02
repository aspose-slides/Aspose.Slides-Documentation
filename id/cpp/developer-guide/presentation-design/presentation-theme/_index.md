---
title: Kelola Tema Presentasi dalam C++
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
- tema eksternal
- THMX
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
description: "Kuasai tema presentasi dalam Aspose.Slides untuk C++ untuk membuat, menyesuaikan, dan mengonversi file PowerPoint dengan merek yang konsisten."
---
## **Pendahuluan**

Tema presentasi menentukan satu set terkoordinasi warna, font, gaya latar belakang, isian, garis, dan efek. Objek yang menyadari tema merujuk pada definisi bersama ini alih-alih menyimpan setiap properti visual sebagai nilai tetap, sehingga perubahan tema dapat memperbarui banyak objek sekaligus.

Di Aspose.Slides, tema pada tingkat presentasi tersedia melalui [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_mastertheme/). Sebuah presentasi juga dapat berisi override tema pada tingkat yang lebih rendah. Master dapat menimpa tema presentasi melalui [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), sementara layout atau slide individu dapat menggunakan [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Pada praktiknya, tema efektif untuk sebuah slide diselesaikan melalui rantai pewarisan ini: tema presentasi, override master, override layout, dan override slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Bagian-bagian di bawah ini menunjukkan alur kerja tema yang paling umum: memeriksa tema, mengubah warna dan font, menyalin atau menerapkan tema, memperbarui gaya latar belakang dan efek, serta membaca nilai efektif setelah pewarisan dan override diselesaikan.

## **Memeriksa Tema**

Objek [MasterTheme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/mastertheme/) mengekspos metode [get_ColorScheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), dan [get_FormatScheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Memeriksa koleksi ini sebelum mengubahnya sangat berguna ketika sebuah presentasi berasal dari sumber eksternal karena jumlah dan isi entri gaya dapat bervariasi.

Contoh berikut membaca properti tema utama dan melaporkan berapa banyak gaya latar belakang, isian, garis, dan efek yang tersimpan dalam tema:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Jika sebuah berkas menggunakan beberapa master, jangan mengasumsikan bahwa setiap slide memiliki tema efektif yang sama. Periksa master yang terkait dengan slide, dan gunakan alur kerja tema-efektif yang ditunjukkan nanti dalam artikel ini ketika override layout atau slide mungkin ada.

## **Mengubah Warna Tema**

Isian, garis, dan teks yang menyadari tema dapat merujuk pada warna logis dari enumerasi [SchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/schemecolor/). Ketika Anda mengubah entri yang bersesuaian dalam [IColorScheme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/icolorscheme/), semua objek yang masih merujuk ke warna tema tersebut akan diselesaikan terhadap nilai baru. Objek yang menggunakan warna RGB langsung tidak akan berubah oleh pembaruan warna tema.

Contoh end-to-end berikut membuat sebuah shape yang menggunakan `Accent4`, mengubah warna tema `Accent4` menjadi merah, menyimpan presentasi, membuka kembali, dan mencetak warna isian efektif:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Karena persegi tetap terhubung ke `Accent4`, warnanya menjadi merah setelah tema diubah. Jika Anda mengganti warna skema dengan warna langsung pada shape, perubahan selanjutnya pada `Accent4` tidak lagi memengaruhi isian tersebut.

### **Gunakan Warna dari Palet Tambahan**

PowerPoint menghasilkan varian lebih terang dan lebih gelap dari warna tema dengan menerapkan transformasi warna. Aspose.Slides mengekspos transformasi ini melalui [ColorTransformOperation](https://reference.aspose.com/slides/id/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Warna tema utama.  

**2** - Varian lebih terang dan lebih gelap yang dihasilkan dari warna tema utama.

Contoh berikut membuat enam persegi berdasarkan `Accent4`, menerapkan transformasi luminansi pada lima di antaranya, dan menyimpan hasilnya:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Varian ini tetap berbasis pada warna tema. Jika `Accent4` berubah kemudian, warna yang telah ditransformasi akan dihitung ulang dari nilai `Accent4` yang baru.

### **Petakan Nilai `SchemeColor` ke Slot `IColorScheme`**

Enumerasi [SchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/schemecolor/) menggunakan `Text1`, `Background1`, `Text2`, dan `Background2`, sementara [IColorScheme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/icolorscheme/) mengekspos slot tema yang sama sebagai `Dark1`, `Light1`, `Dark2`, dan `Light2`. Pemetaan bersifat tetap:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Ini adalah nama alternatif untuk slot tema yang sama; bukan nilai yang dikonversi secara dinamis dari satu bentuk ke bentuk lainnya.

## **Mengubah Font Tema**

Skema font tema berisi set font utama untuk judul dan set font minor untuk teks isi. Metode [FontScheme::get_Major()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/fontscheme/get_major/) dan [FontScheme::get_Minor()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/fontscheme/get_minor/) mengekspos set tersebut.

Identifier font tema yang kompatibel dengan PowerPoint dapat digunakan dalam pemformatan teks:

* `+mn-lt` - Font Tubuh Latin (Minor Latin Font)  
* `+mj-lt` - Font Judul Latin (Major Latin Font)  
* `+mn-ea` - Font Tubuh Asia Timur (Minor East Asian Font)  
* `+mj-ea` - Font Judul Asia Timur (Major East Asian Font)

Contoh berikut membuat satu judul yang menggunakan font Latin utama tema dan satu baris isi yang menggunakan font Latin minor tema. Kemudian mengubah font tema dan menyimpan hasilnya:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Judul mengikuti font utama dan teks isi mengikuti font minor. Teks yang memiliki nama font eksplisit alih-alih identifier tema tidak akan beralih secara otomatis ketika skema font tema berubah.

Koleksi font utama dan minor juga dapat berisi pemetaan font untuk sistem penulisan individu, seperti Cyrillic, Arab, Jepang, Georgia, dan Thaana. Untuk memeriksa, menambah, mengganti, atau menghapus pemetaan ini, lihat [Script-Specific Theme Fonts](/slides/id/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Untuk informasi lebih lanjut tentang font presentasi, lihat [PowerPoint Fonts](/slides/id/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Menyalin atau Menerapkan Tema**

Alur kerja di bawah ini menyelesaikan berbagai masalah terkait tema.

### **Menerapkan Tema Eksternal pada Slide yang Bergantung pada Master**

Gunakan [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) ketika Anda memiliki berkas tema PowerPoint (`.thmx`) dan ingin mengubah gaya semua slide yang bergantung pada master tertentu. Pilih master dari koleksi [Presentation::get_Masters](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) yang mengimplementasikan [IMasterSlideCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/), lalu berikan jalur berkas tema ke metode tersebut.

Metode ini melakukan operasi berikut:

1. Membuat master slide baru berdasarkan master yang dipilih.  
1. Menerapkan tema eksternal ke master baru.  
1. Menetapkan master baru ke semua slide yang sebelumnya bergantung pada master yang dipilih.  
1. Mengembalikan [IMasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/) yang baru dibuat.

Contoh berikut menerapkan tema eksternal ke slide yang bergantung pada master pertama dan menyimpan presentasi:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Tema yang tidak valid, rusak, atau tidak didukung dapat memicu [PptxException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxexception/) atau salah satu subclass terkait formatnya. Validasi jalur yang diberikan pengguna, tangani kegagalan akses sistem berkas, dan simpan presentasi hanya setelah tema berhasil diterapkan.

Hanya slide yang bergantung pada master yang dipilih yang dipindahkan. Slide yang terkait dengan master lain mempertahankan master dan tema mereka yang ada. Warna, font, isian, garis, latar belakang, dan efek yang menyadari tema diselesaikan terhadap tema eksternal. Warna, font, isian, dan pemformatan eksplisit yang ditetapkan secara langsung mungkin tetap tidak berubah. Override pada tingkat layout dan slide juga dapat memiliki prioritas lebih tinggi daripada nilai yang diwarisi dari master baru.

Tema dapat merujuk pada font yang tidak tersedia di lingkungan runtime. Untuk konsistensi render dan ekspor, instal font yang diperlukan, sediakan melalui [custom font sources](/slides/id/cpp/custom-font/), atau konfigurasikan [font substitution](/slides/id/cpp/font-substitution/).

Ini adalah alur kerja tingkat master langsung: metode menerima jalur berkas `.thmx` dan tidak memerlukan pembuatan manual override tema pada tingkat slide atau layout.

### **Menerapkan Tema Eksternal yang Berbeda dalam Presentasi Multi-Master**

Ketika master yang relevan tidak diketahui sebelumnya, dapatkan dari slide representatif melalui [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/get_layoutslide/) dan [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilayoutslide/get_masterslide/). Simpan referensi master asli sebelum menerapkan tema apa pun karena setiap panggilan akan membuat master lain dalam presentasi.

Contoh berikut menggunakan slide dari dua bagian untuk menemukan master mereka dan menerapkan tema eksternal yang berbeda ke setiap grup:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Panggilan pertama memengaruhi hanya slide yang bergantung pada `firstGroupMaster`, dan panggilan kedua memengaruhi hanya slide yang bergantung pada `secondGroupMaster`. Slide yang termasuk dalam master lain tidak akan diubah gayanya.

### **Mempertahankan Tema Sumber saat Memindahkan Slide**

Jika Anda ingin memindahkan slide ke presentasi lain dan mempertahankan desain aslinya, kloning master sumber ke presentasi target dengan [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/addclone/), lalu kloning slide dengan [ISlideCollection::AddClone()](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/) dan master yang dikloning. Ini membawa master, layout‑nya, dan tema terkait bersamaan.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Ini adalah alur kerja yang disarankan ketika slide sumber harus tampak sama di tujuan. Sekadar mengkloning konten ke master tujuan yang tidak terkait dapat mengubah warna, font, latar belakang, dan efek yang dipengaruhi tema.

### **Menerapkan Nilai Tema ke Slide yang Ada**

Jika slide target harus tetap pada master dan layoutnya saat ini, inisialisasi override tingkat slide dari tema sumber. Metode [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), dan [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) menyalin tiga komponen utama tema ke dalam override.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Ini mengubah tema yang digunakan oleh slide tersebut tanpa mengubah tema yang diwarisi oleh slide lain. Untuk menghapus override lokal dan kembali ke nilai yang diwarisi, panggil [OverrideTheme::Clear()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/overridetheme/clear/).

### **Menerapkan Override Tema ke Layout**

Override tingkat layout berlaku untuk slide yang menggunakan layout tersebut, kecuali slide tertentu memiliki overridenya sendiri. Metode inisialisasi yang sama dapat digunakan melalui [IOverrideThemeManager](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ioverridethememanager/) milik layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Gunakan tema pada tingkat master atau presentasi ketika banyak layout dan slide harus berbagi desain dasar yang sama, gunakan override layout ketika satu keluarga layout memerlukan gaya yang berbeda, dan gunakan override slide hanya untuk pengecualian yang nyata. Override tingkat slide yang berlebihan membuat perubahan tema global di kemudian hari menjadi sulit diprediksi.

## **Memperbarui Gaya Latar Belakang Tema**

Isian latar belakang tema disimpan dalam [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint dapat menampilkan lebih banyak pilihan latar belakang di UI-nya dibandingkan jumlah definisi isian yang sebenarnya disimpan dalam koleksi ini karena UI dapat menggabungkan isian tema dengan warna tema dan referensi gaya lainnya.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Sebelum menggunakan gaya latar belakang, periksa koleksi yang disimpan dan [Background::get_StyleIndex()](https://reference.aspose.com/slides/id/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` menggunakan `0` untuk tidak ada isian bertema; nilai positif adalah referensi gaya latar belakang tema. Ini berbeda dari mengindeks koleksi C++ secara langsung dengan `idx_get(0)`, di mana `0` berarti item pertama yang disimpan. Jangan mengasumsikan setiap presentasi memiliki jumlah gaya isian latar belakang yang sama.

Contoh berikut melaporkan jumlah isian latar belakang yang tersedia, menetapkan referensi latar belakang bertema ke master pertama, dan menyimpan presentasi:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Hasil yang terlihat bergantung pada entri tema yang direferensikan oleh master dan pada override latar belakang di tingkat layout atau slide. Jika sebuah slide menggunakan latar belakangnya sendiri, mengubah hanya latar belakang master mungkin tidak mengubah slide tersebut. Gunakan [Background::GetEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides/background/geteffective/) ketika Anda perlu mengetahui latar belakang akhir setelah pewarisan diterapkan.

{{% alert color="warning" title="Warning" %}}
Jangan memperlakukan `StyleIndex` sebagai indeks koleksi berbasis nol. Hindari juga menghard‑code nomor gaya dari satu berkas dan mengasumsikan tampilannya sama di berkas lain; definisi gaya tema bersifat spesifik presentasi.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Untuk pemformatan latar belakang langsung dan pewarisan latar belakang, lihat [Presentation Background](/slides/id/cpp/presentation-background/).
{{% /alert %}}

## **Memperbarui Efek Tema**

Skema format tema berisi koleksi terpisah [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/formatscheme/get_linestyles/), dan [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Tema Office tipikal sering berisi tiga entri gaya utama yang secara visual sesuai dengan pemformatan halus, sedang, dan intens, tetapi kode harus memeriksa setiap koleksi alih-alih mengasumsikan jumlah tetap.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Saat mengakses koleksi ini di C++, indeks koleksi berbasis nol: `idx_get(0)` adalah gaya pertama yang disimpan dan `idx_get(2)` adalah yang ketiga. Indeks referensi gaya pada shape merupakan konsep terpisah, diekspos melalui [IShapeStyle](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapestyle/). Memodifikasi gaya tema memengaruhi shape yang merujuk ke gaya tema tersebut; shape dengan pemformatan langsung mungkin tetap tidak berubah.

Contoh berikut memeriksa keberadaan entri gaya yang diperlukan, mengubah gaya garis pertama, mengubah gaya isian ketiga, mengaktifkan bayangan luar pada gaya efek ketiga, dan menyimpan hasilnya:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Untuk shape yang merujuk ke slot ini, gaya garis tema pertama menjadi merah, gaya isian tema ketiga menjadi hijau hutan solid, dan gaya efek ketiga mendapatkan bayangan luar dengan jarak 10 poin. Hasil visual yang tepat tetap bergantung pada slot gaya yang dirujuk masing‑masing shape dan apakah pemformatan langsung menimpa tema.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Menentukan Apakah Isian Solid Efektif Menggunakan Warna Tema**

Isian dapat disimpan langsung pada objek atau diwarisi dari paragraf, layout, master, gaya tema, atau level pemformatan lainnya. Panggil [IFillFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformat/geteffective/) untuk menyelesaikan hierarki tersebut menjadi [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/) yang tidak dapat diubah. Pertama periksa [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Hanya ketika bernilai `FillType::Solid` Anda harus membaca properti isian solid.

Untuk isian solid, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) mengembalikan nilai RGB akhir setelah pewarisan, pencarian tema, dan transformasi warna diterapkan. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) mengembalikan slot logis [SchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/schemecolor/) yang bersangkutan, seperti `Text1` atau `Accent6`. Nilai `SchemeColor::NotDefined` berarti isian solid efektif tidak berbasis pada warna skema. Dalam alur kerja di mana isian berupa warna tema atau warna RGB langsung, nilai ini mengidentifikasi isian RGB langsung.

Jangan menggunakan nilai [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/icolorformat/get_schemecolor/) lokal saja untuk mengklasifikasikan isian. Misalnya, sebuah bagian teks dapat tidak memiliki warna skema yang didefinisikan secara lokal, sehingga nilainya `NotDefined`, sementara isian efektifnya mewarisi warna tema dan menyelesaikan ke `Text1` atau `Accent6`. Sebaliknya, `get_SolidFillSchemeColor` memberi tahu slot tema logis yang menghasilkan warna efektif, tetapi tidak memberi tahu apakah slot itu berasal dari objek, paragraf, layout, master, atau level hierarki pemformatan lainnya.

Contoh berikut memuat presentasi, mengaudit isian shape serta isian bagian teks, mencetak setiap nilai RGB akhir dan skema yang terkait, serta menandai isian solid yang tidak akan melacak perubahan warna tema:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

Cabang `NotDefined` memberikan daftar audit isian solid yang tidak akan merespon perubahan pada slot warna tema. Tinjau objek‑objek tersebut ketika sebuah presentasi harus mengikuti palet merek baru. Nilai RGB yang dilaporkan masih menunjukkan tampilan saat ini, sementara nilai skema menjelaskan apakah tampilan tersebut terhubung ke tema.

Objek format‑efektif adalah snapshot. Setelah mengubah tema presentasi, override tema, atau pemformatan yang diwarisi, panggil kembali `GetEffective` dan baca objek `IFillFormatEffectiveData` yang baru sebelum membandingkan atau melaporkan warna.

## **Membaca Nilai Tema Efektif**

Objek tema mentah memberi tahu apa yang didefinisikan pada level tertentu. Nilai efektif memberi tahu apa yang sebenarnya digunakan oleh slide atau shape setelah pewarisan dan override lokal diselesaikan. Untuk slide, panggil [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Untuk latar belakang, gunakan [Background::GetEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides/background/geteffective/), dan untuk isian, gunakan [FillFormat::GetEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/geteffective/).

Contoh berikut membaca tema efektif, latar belakang, dan isian shape pertama dari sebuah slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Gunakan data efektif untuk diagnostik render, validasi, dan perbandingan. Jika Anda hanya memeriksa [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_mastertheme/), Anda dapat melewatkan master, layout, slide, atau override shape yang mengubah tampilan akhir.

## **FAQ**

**Apakah menerapkan tema eksternal memengaruhi setiap slide dalam presentasi?**

Tidak. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) hanya memindahkan slide yang bergantung pada master yang dipilih. Slide yang menggunakan master lain mempertahankan tema yang ada.

**Bisakah saya menerapkan tema ke satu slide tanpa mengubah master?**

Ya. Gunakan [IOverrideThemeManager](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ioverridethememanager/) slide tersebut dan inisialisasi tema override‑nya. Perubahan tetap lokal pada slide itu; slide lain tetap mewarisi tema mereka yang ada.

**Apa cara paling aman untuk membawa tema dari satu presentasi ke presentasi lain?**

Saat memindahkan slide dan mempertahankan tampilan sumbernya, kloning master sumber ke tujuan dan kloning slide dengan master tersebut menggunakan [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/id/cpp/aspose.slides/imasterslidecollection/addclone/) serta [ISlideCollection::AddClone()](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecollection/addclone/). Ini menjaga master, layout, dan tema tetap bersama.

**Bagaimana saya dapat melihat nilai efektif setelah pewarisan dan override?**

Gunakan [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) untuk slide atau layout tema dan metode data‑efektif yang bersangkutan untuk objek format seperti [Background::GetEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides/background/geteffective/) dan [FillFormat::GetEffective()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fillformat/geteffective/). API‑API ini mengembalikan nilai yang sudah diselesaikan setelah pewarisan dan override diterapkan.