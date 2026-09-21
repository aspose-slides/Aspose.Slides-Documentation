---
title: Kelola Bidang Teks dalam Presentasi PowerPoint di C++
linktitle: Bidang Teks
type: docs
weight: 52
url: /id/cpp/text-fields/
keywords:
- bidang teks
- teks otomatis
- nomor slide
- tanggal dan waktu
- header
- footer
- bagian teks
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus bidang teks dalam presentasi PowerPoint dengan Aspose.Slides untuk C++. Pertahankan pemformatan dan periksa file PPTX dan PPT yang disimpan."
---
## **Ikhtisar**

Sebuah paragraf teks terdiri dari bagian-bagian. Sebuah [IPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/) biasa berisi teks literal; bagian field juga memiliki [IField](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifield/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi field.

Gunakan [IPortion::get_Field](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/get_field/) untuk membedakannya: ia mengembalikan `nullptr` untuk teks biasa. [IPortion::AddField](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/addfield/) mengubah bagian yang ada menjadi field. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengubah nilai tidak juga menggantikan label.

Panduan ini mencakup field di dalam teks, pemformatannya, dan penyimpanannya dalam PPTX dan PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/cpp/manage-text/).

## **Buat Field Nomor Slide**

Contoh berikut membuat kotak teks yang berisi label literal `Slide ` diikuti oleh nomor yang diperbarui secara otomatis. Ia menetapkan ukuran, berat, dan warna nomor sebelum menambahkan field, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe field, teks, dan pemformatannya. Tidak diperlukan file masukan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teks yang diharapkan adalah `Slide 1`, dan kedua pemeriksaan harus mencetak `True`. Nomor tersebut tetap menjadi field setelah dibuka kembali; bukan literal `1`. Cast dan indeks dalam verifikasi merujuk pada shape dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Field**

[FieldType](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/) mengimplementasikan [IFieldType](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifieldtype/) dan menyediakan nilai-nilai bawaan berikut. Berikan nilai yang sesuai ke [AddField](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/addfield/).

| Aksesor | Tujuan |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_slidenumber/) | Nomor slide saat ini. |
| [get_DateTime](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime/) | Tanggal/waktu dalam format default aplikasi rendering. |
| [get_DateTime1](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime9/) | Format tanggal atau kombinasi tanggal/waktu yang telah ditentukan. |
| [get_DateTime10](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime13/) | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12 jam. |
| [get_Header](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_header/) | Field header; lihat batasan placeholder dan format di bawah. |
| [get_Footer](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_footer/) | Field footer. |

Sebagai contoh, [get_DateTime3](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/get_datetime3/) menyediakan hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format field bawaan, bukan string format tanggal sembarangan. Bahasa bagian, yang diatur dengan [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/set_languageid/), dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Field dari String Internal**

Overload string dari [AddField](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/addfield/) menerima pengenal field internal. Gunakan itu ketika mempertahankan pengenal yang diberikan oleh aplikasi lain yang tidak memiliki nilai bawaan. Anda juga dapat membuat [FieldType](https://reference.aspose.com/slides/id/cpp/aspose.slides/fieldtype/fieldtype/) dari pengenal tersebut. [IFieldType::get_InternalString](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifieldtype/get_internalstring/) menampilkan pengenal itu untuk inspeksi.

Contoh ini menyimpan field spesifik aplikasi `custom-report-id` dengan teks cadangan `Report-042`. Tidak diperlukan file masukan. Pengenal tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak diketahui. Aplikasi yang memahami pengenal ini harus menyediakan maknanya dan memperbarui nilainya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Setelah siklus PPTX ini, tipe yang diharapkan adalah `custom-report-id` dan teks yang diharapkan adalah `Report-042`. Memberikan string seperti `yyyy-MM-dd` akan menamai tipe field; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format apa pun, gunakan teks biasa.

## **Inspeksi, Modifikasi, dan Hapus Field Tanggal/Waktu**

Baca tipe field yang ada melalui [IField::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifield/get_type/) dan ubah melalui [IField::set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifield/set_type/). Periksa bahwa field ada sebelum mengakses tipenya. Untuk menghentikan pembaruan otomatis, panggil [IPortion::RemoveField](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/removefield/). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi field. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks itu setelah menghapus field.

Untuk pengaturan API yang terkait dengan pemrosesan field tanggal/waktu, lihat [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/set_currentdatetime/). Contoh di bawah menggunakan tanggal persetujuan eksplisit ketika mengonversi field menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File tersebut berisi dua shape teks bernama, `UpdatedAt` dan `ApprovedDate`, masing‑masing dengan field tanggal/waktu, plus label teks biasa. Contoh berikut menelusuri shape teks tingkat atas pada slide reguler. Ia mengubah field tanggal/waktu menjadi format tanggal panjang dan menjadikannya miring, sambil mempertahankan format lainnya. Hanya field di `ApprovedDate` yang menjadi teks tetap.

Sampel mengenali pengenal internal bawaan `datetime` dan `datetime1` sampai `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran container teks mereka masing‑masing dan berada di luar lingkup contoh ini.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Setelah dibuka kembali, `UpdatedAt` harus memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` harus tidak memiliki field dan berisi `05 April 2030`. Kedua bagian tanggal miring, dan ukuran font, pengaturan tebal, serta warna asli tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua shape yang dikenal dalam sampel yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerjalah dengan bagian yang sudah ada saat menambahkan field, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [IPortion::get_PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/get_portionformat/) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun kembali seluruh bingkai teks hanya untuk memperbarui satu field: hal itu dapat menghilangkan batas bagian asli dan pemformatan individualnya. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/cpp/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Field dan Placeholder Header/Footer**

Sebuah field adalah bagian dari teks. Placeholder adalah shape dengan peran presentasi, seperti footer atau nomor slide. Menambahkan field ke kotak teks biasa tidak mengubah shape tersebut menjadi placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitasnya pada slide, tata letak, dan master, termasuk propagasi ke slide turunan. Field nomor dalam kotak teks khusus dapat berguna bahkan jika Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus field dari kotak teks yang tidak terkait.

Tipe header dan footer bawaan tidak membuat placeholder yang bersesuaian atau menyediakan isinya. Khususnya, slide PowerPoint reguler tidak memiliki placeholder header; header masuk ke halaman catatan dan handout. Jangan menganggap bahwa field header atau footer dalam shape apa pun secara otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja itu, lihat [Presentation Headers and Footers](/slides/id/cpp/presentation-header-and-footer/).

## **Keterbatasan PPTX dan PPT**

Periksa baik tipe field maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan pengenal tidak membuktikan bahwa aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku dan keterbatasan field |
|---|---|
| PPTX | Menyimpan pengenal field internal bersama teks field. Gunakan contoh di atas untuk memeriksa tipe bawaan dan pengenal khusus setelah menyimpan dan membuka kembali. Tipe khusus yang tidak dikenal tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan pengenal yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi field legacy dan memiliki kompatibilitas yang lebih terbatas. Field nomor slide dan field tanggal/waktu bawaan memiliki representasi legacy. Field khusus atau header yang tidak didukung dalam kotak teks slide biasa dapat menghasilkan `*` sebagai teksnya. Jangan mengandalkan field khusus atau konteks field yang tidak didukung tetap mempertahankan teks yang terlihat. |

Untuk output tetap yang dapat dipindahkan, konversi field yang tidak didukung menjadi teks biasa dan tetapkan nilai yang diinginkan secara eksplisit sebelum menyimpan. Ini mempertahankan teks yang dipilih namun memang menghentikan pembaruan otomatis. Uji aplikasi target juga ketika perhitungan ulang field menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah angka atau tanggal yang ditampilkan adalah field?**

Periksa [IPortion::get_Field](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/get_field/). Nilai tidak‑null mengidentifikasi sebuah field; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus field menghapus teks atau formatnya?**

Tidak. [RemoveField](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/removefield/) mengonversi bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku atau nilai cadangan tertentu.

**Apakah string internal dapat mendefinisikan format tanggal atau rumus baru?**

Tidak. Itu mengidentifikasi tipe field. Pengenal yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal. Gunakan tipe bawaan yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Pengenal field, teks yang dihitung, dan pemformatan adalah hal terpisah yang perlu diverifikasi. Konversi format dapat mengubah hasil yang terlihat meskipun pengenal field masih ada.