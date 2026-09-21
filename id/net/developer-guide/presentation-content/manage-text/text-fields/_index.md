---
title: Kelola Bidang Teks dalam Presentasi PowerPoint di .NET
linktitle: Bidang Teks
type: docs
weight: 52
url: /id/net/text-fields/
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
- C#
- Aspose.Slides
description: "Buat, inspeksi, modifikasi, dan hapus bidang teks dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Pertahankan pemformatan dan verifikasi file PPTX dan PPT yang disimpan."
---
## **Gambaran Umum**

Sebuah paragraf teks terdiri dari bagian-bagian. Sebuah [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) biasa berisi teks literal; bagian bidang juga memiliki [IField](https://reference.aspose.com/slides/id/net/aspose.slides/ifield/) yang tipenya mengidentifikasi nilai yang diperbarui secara otomatis, seperti nomor slide atau tanggal. Dua bagian dapat menampilkan karakter yang sama sementara hanya satu yang berisi bidang.

Gunakan [IPortion.Field](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/field/) untuk membedakannya: nilainya `null` untuk teks biasa. [IPortion.AddField](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/addfield/) mengubah bagian yang ada menjadi bidang. Simpan label dan nilai dinamisnya dalam bagian terpisah sehingga mengonversi nilai tidak juga menggantikan label.

Panduan ini mencakup bidang di dalam teks, pemformatannya, dan penyimpanan dalam PPTX serta PPT. Untuk bingkai teks dan paragraf, lihat [Manage Text](/slides/id/net/manage-text/).

## **Buat Bidang Nomor Slide**

Contoh lengkap berikut membuat sebuah kotak teks yang berisi label literal `Slide ` diikuti oleh angka yang diperbarui secara otomatis. Ia mengatur ukuran, ketebalan, dan warna angka sebelum menambahkan bidang, kemudian membuka kembali presentasi yang disimpan dan memeriksa tipe bidang, teks, dan pemformatannya. Tidak diperlukan file input.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Presentasi baru dimulai dengan nomor slide 1, sehingga teksnya adalah `Slide 1`, dan kedua pemeriksaan mencetak `True`. Angka tersebut tetap menjadi bidang setelah dibuka kembali; itu bukan literal `1`. Cast dan indeks dalam verifikasi merujuk pada bentuk dan bagian yang dibuat oleh contoh ini.

## **Pilih Tipe Bidang**

[FieldType](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/) mengimplementasikan [IFieldType](https://reference.aspose.com/slides/id/net/aspose.slides/ifieldtype/) dan menyediakan nilai-nilai bawaan berikut. Kirim nilai yang sesuai ke [AddField](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/addfield/).

| Nilai | Tujuan |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/slidenumber/) | Nomor slide saat ini. |
| [DateTime](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime/) | Tanggal/waktu dalam format default aplikasi rendering. |
| [DateTime1](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime9/) | Format tanggal atau kombinasi tanggal/waktu yang telah ditentukan. |
| [DateTime10](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime13/) | Format waktu yang telah ditentukan, dengan opsi detik dan jam 12. |
| [Header](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/header/) | Bidang header; lihat placeholder dan batasan format di bawah. |
| [Footer](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/footer/) | Bidang footer. |

Sebagai contoh, [DateTime3](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/datetime3/) mewakili hari, nama bulan lengkap, dan tahun dalam bahasa Inggris. Ini adalah format bidang yang telah ditentukan, bukan string format tanggal .NET sembarangan. [LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/) pada bagian dan aplikasi yang memproses presentasi dapat memengaruhi hasil yang ditampilkan.

## **Buat Bidang dari String Internal**

Overload string dari [AddField](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/addfield/) menerima pengidentifikasi bidang internal. Gunakan ini ketika mempertahankan pengidentifikasi yang diberikan oleh aplikasi lain yang tidak memiliki nilai bawaan. Anda juga dapat membuat [FieldType](https://reference.aspose.com/slides/id/net/aspose.slides/fieldtype/fieldtype/) dari pengidentifikasi tersebut. [IFieldType.InternalString](https://reference.aspose.com/slides/id/net/aspose.slides/ifieldtype/internalstring/) menampilkan pengidentifikasi itu untuk inspeksi.

Contoh ini menyimpan bidang `custom-report-id` spesifik aplikasi dengan teks cadangan `Report-042`. Pengidentifikasi tersebut tidak mendaftarkan perhitungan: Aspose.Slides tidak menghasilkan ID laporan untuk tipe yang tidak dikenal. Aplikasi yang memahami pengidentifikasi ini harus menyediakan maknanya dan memperbarui nilainya.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Setelah siklus PPTX ini, tipe menjadi `custom-report-id` dan teksnya `Report-042`. Mengirim string seperti `yyyy-MM-dd` akan memberi nama tipe bidang; itu tidak akan mengonfigurasi format tanggal khusus. Untuk tanggal tetap dalam format apa pun, gunakan teks biasa.

## **Periksa, Modifikasi, dan Hapus Bidang Tanggal/Waktu**

Baca dan ubah bidang yang ada melalui [IField.Type](https://reference.aspose.com/slides/id/net/aspose.slides/ifield/type/). Periksa bahwa bidang ada sebelum mengakses tipe-nya. Untuk menghentikan pembaruan otomatis, panggil [IPortion.RemoveField](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/removefield/). Ini mempertahankan bagian dan teksnya saat ini sambil menghapus asosiasi bidang. Jika Anda memerlukan nilai tetap tertentu, tetapkan teks tersebut setelah menghapus bidang.

Untuk pengaturan API yang terkait dengan pemrosesan bidang tanggal/waktu, lihat [Presentation.CurrentDateTime](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/currentdatetime/). Contoh di bawah ini menggunakan tanggal persetujuan eksplisit saat mengonversi bidang menjadi teks biasa.

Unduh [sample.pptx](sample.pptx) dan letakkan di direktori kerja. File ini berisi dua bentuk teks bernama, `UpdatedAt` dan `ApprovedDate`, masing-masing dengan bidang tanggal/waktu, plus label teks biasa. Contoh berikut menelusuri bentuk teks tingkat atas pada slide reguler. Ia mengubah bidang tanggal/waktu menjadi format tanggal panjang dan membuatnya mirik, sambil mempertahankan pemformatan lainnya. Hanya bidang dalam `ApprovedDate` yang menjadi teks tetap.

Contoh mengenali pengidentifikasi internal bawaan `datetime` dan `datetime1` hingga `datetime13`. Grup, tabel, catatan, tata letak, dan master memerlukan penelusuran kontainer teks mereka sendiri dan berada di luar ruang lingkup contoh ini.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Setelah dibuka kembali, `UpdatedAt` memiliki tipe `datetime3` dan tetap dinamis. `ApprovedDate` tidak memiliki bidang dan berisi `05 April 2030`. Kedua bagian tanggal tersebut miring, dan ukuran font, pengaturan tebal, serta warna asli mereka tetap utuh. Label teks biasa tidak berubah. Verifikasi membaca bagian pertama dari dua bentuk yang diketahui dalam sampel yang disediakan.

## **Pertahankan Pemformatan Teks**

Bekerja dengan bagian yang ada saat menambahkan bidang, mengubah tipenya, atau menghapusnya. Operasi ini mempertahankan pemformatan bagian tersebut. Gunakan [IPortion.PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/portionformat/) untuk mengubah hanya properti yang diperlukan, seperti contoh untuk warna atau miring.

Hindari membangun kembali seluruh bingkai teks hanya untuk memperbarui satu bidang: melakukan hal itu dapat kehilangan batas bagian asli dan pemformatannya masing-masing. Juga bedakan pemformatan yang ditetapkan secara eksplisit dari pemformatan yang diwarisi dari paragraf, tata letak, atau tema. Lihat [Text Formatting](/slides/id/net/text-formatting/) untuk opsi pemformatan yang lebih luas.

## **Bidang dan Placeholder Header/Footer**

Bidang merupakan bagian dari sebuah bagian teks. Placeholder adalah sebuah bentuk dengan peran presentasi, seperti footer atau nomor slide. Menambahkan bidang ke kotak teks biasa tidak menjadikan bentuk tersebut sebagai placeholder.

Manajer header/footer mengontrol teks placeholder dan visibilitas pada slide, tata letak, dan master, termasuk propagasi ke slide yang tergantung. Oleh karena itu, bidang nomor dalam kotak teks khusus dapat berguna meskipun Anda tidak menggunakan placeholder nomor slide. Sebaliknya, mengubah visibilitas placeholder tidak menghapus bidang dari kotak teks yang tidak terkait.

Tipe header dan footer bawaan tidak membuat placeholder yang sesuai atau menyediakan kontennya. Secara khusus, slide PowerPoint biasa tidak memiliki placeholder header; header berada pada halaman catatan dan handout. Jangan menganggap bahwa bidang header atau footer dalam bentuk apa pun akan secara otomatis memperoleh teks yang dikonfigurasi melalui manajer placeholder. Untuk alur kerja itu, lihat [Presentation Headers and Footers](/slides/id/net/presentation-header-and-footer/).

## **Batasan PPTX dan PPT**

Periksa baik tipe bidang maupun teks hasilnya setelah menyimpan dan membuka kembali. Mempertahankan pengidentifikasi tidak membuktikan bahwa sebuah aplikasi dapat menghitung atau menampilkan nilainya.

| Format | Perilaku bidang dan batasan |
|---|---|
| PPTX | Menyimpan identifier bidang internal bersama teks bidang. Dalam pemeriksaan siklus, tipe bawaan dan identifier khusus yang digunakan di atas tetap setelah penyimpanan dan pembukaan kembali. Tipe khusus yang tidak dikenal mempertahankan teks cadangannya; tidak memperoleh logika perhitungan otomatis. Aplikasi lain mungkin memperlakukan identifier yang tidak didukung secara berbeda. |
| PPT | Menggunakan representasi bidang warisan dan memiliki kompatibilitas yang lebih terbatas. Dalam pemeriksaan siklus, bidang nomor slide dan bidang tanggal/waktu bawaan tetap setelah penyimpanan dan pembukaan kembali. Bidang khusus dalam kotak teks slide biasa dibuka kembali dengan identifier-nya namun dengan teks `*`; bidang header dalam konteks yang sama juga menghasilkan `*`. Jangan mengandalkan bidang khusus atau konteks bidang yang tidak didukung untuk mempertahankan teks terlihatnya. |

Untuk output yang dapat dipindahkan dan tetap, konversi bidang yang tidak didukung menjadi teks biasa dan tetapkan nilai yang diinginkan secara eksplisit sebelum menyimpan. Ini mempertahankan teks yang dipilih tetapi secara sengaja menghentikan pembaruan otomatis. Uji juga aplikasi target ketika perhitungan ulang bidangnya menjadi bagian dari alur kerja Anda.

## **FAQ**

**Bagaimana saya dapat mengetahui apakah angka atau tanggal yang ditampilkan adalah sebuah bidang?**

Periksa [IPortion.Field](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/field/). Nilai yang tidak null mengidentifikasi sebuah bidang; teks yang ditampilkan saja tidak dapat memberi tahu Anda.

**Apakah menghapus sebuah bidang menghapus teks atau pemformatannya?**

Tidak. [RemoveField](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/removefield/) mengubah bagian yang ada menjadi teks biasa. Tetapkan nilai eksplisit setelahnya jika Anda memerlukan tanggal beku tertentu atau nilai cadangan.

**Bisakah string internal mendefinisikan format tanggal atau formula baru?**

Tidak. Itu mengidentifikasi tipe bidang. Identifier yang tidak dikenal tidak menyediakan evaluator atau pola format tanggal .NET. Gunakan tipe bawaan yang didukung atau format nilai sendiri sebagai teks biasa.

**Mengapa memeriksa kembali presentasi setelah menyimpannya?**

Identifier bidang, teks yang dihitung, dan pemformatan adalah hal terpisah yang perlu diverifikasi. Konversi format dapat mengubah hasil yang terlihat bahkan ketika identifier bidang masih ada.