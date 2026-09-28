---
title: Format Teks Presentasi di .NET
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/net/text-formatting/
keywords:
- perataan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- penambatan bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Ini mencakup warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab, dan pengaturan bahasa.

Kecuali dinyatakan lain, contoh menggunakan [sample.pptx](sample.pptx). Bentuk pertama pada slide pertama adalah kotak teks, dan paragraf pertamanya berisi teks yang ditampilkan di bawah ini. Indeks slide dan bentuk mulai dari nol. Contoh yang menyorot bagian tebal menggunakan format efektif, termasuk format tebal yang diwarisi:

![Sample text](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Search and Replace Text](/slides/id/net/search-and-replace-text/).

## **Mengatur Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) untuk mengatur warna sorotan default untuk sebuah paragraf, atau gunakan [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/highlightcolor/) untuk bagian teks individu.

Contoh berikut mengatur sorotan abu‑abu terang sebagai default untuk paragraf pertama. Warna sorotan eksplisit pada bagian individu memiliki prioritas lebih tinggi daripada default ini:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Atur warna sorotan untuk seluruh paragraf.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The gray paragraph](gray_paragraph.png)

Contoh kode di bawah ini memperlihatkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Atur warna sorotan untuk bagian teks.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The gray text portions](gray_text_portions.png)

## **Meratakan Paragraf Teks**

Gunakan [IParagraphFormat.Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) untuk mengatur perataan paragraf dalam bingkai teks. Nilainya dapat berupa rata tengah, rata kiri, rata kanan, rata kanan‑kiri, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Atur perataan paragraf ke tengah.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The aligned paragraph](aligned_paragraph.png)

## **Mengatur Transparansi untuk Teks**

Transparansi teks dikontrol melalui komponen alfa dari warna yang ditetapkan pada [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fillformat/). Pada contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode berikut menunjukkan cara menerapkan transparansi ke **seluruh paragraf**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Atur isi hitam setengah transparan untuk teks.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The transparent paragraph](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi ke **bagian teks dengan font tebal**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Atur transparansi bagian teks.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The transparent text portions](transparent_text_portions.png)

## **Mengatur Jarak Karakter untuk Teks**

Gunakan [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/spacing/) untuk memperlebar atau mempersempit jarak antar karakter dalam kotak teks. Contoh menambahkan 3 poin jarak; nilai negatif mempersempit teks.

C# berikut memperlihatkan cara memperlebar jarak karakter dalam **seluruh paragraf**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Perluas jarak karakter.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Contoh kode di bawah ini memperlihatkan cara memperlebar jarak karakter dalam **bagian teks dengan font tebal**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
        portion.PortionFormat.Spacing = 3;  // Perluas jarak karakter.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Menonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat daripada teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan di pengaturan PowerPoint.

Untuk membuat output yang lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terdampak. Atur [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/kerningminimalsize/) ke nilai yang lebih besar daripada ukuran font sebenarnya. Contoh ini memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Ia memeriksa nama font efektif, termasuk font yang diwarisi, dan menetapkan ambang 100 poin untuk bagian yang menggunakan Roboto. Ini menonaktifkan kerning untuk bagian yang cocok dengan ukuran font di bawah 100 poin:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Untuk teks yang cocok di bawah ambang, pengaturan ini mencegah kerning dan dapat membantu menyamakan hasil render Aspose.Slides dengan tampilan visual PowerPoint untuk font yang dipengaruhi perilaku khusus PowerPoint ini.

## **Mengelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) atau pada bagian individu melalui [IPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/).

Contoh berikut mengatur font default paragraf pertama menjadi Times New Roman 12 poin dengan format tebal, miring, dan garis bawah titik. Format eksplisit pada bagian individu memiliki prioritas lebih tinggi daripada default ini:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Atur properti font untuk paragraf.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Contoh berikut menerapkan Times New Roman 13 poin, format miring, dan garis bawah titik pada bagian yang format efektifnya tebal:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Atur properti font untuk bagian teks.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Mengatur Rotasi Teks**

Gunakan [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/textverticaltype/) untuk mengatur orientasi teks yang telah ditentukan sebelumnya di dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke [TextVerticalType.Vertical270](https://reference.aspose.com/slides/id/net/aspose.slides/textverticaltype/), yang memutar teks **90 derajat berlawanan arah jarum jam**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The text rotation](text_rotation.png)

## **Mengatur Rotasi Kustom untuk Bingkai Teks**

Gunakan [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/rotationangle/) untuk mengatur sudut rotasi kustom bagi sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).

Contoh kode di bawah ini memutar bingkai teks sebesar 3 derajat searah jarum jam di dalam bentuk:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The custom text rotation](custom_text_rotation.png)

## **Mengatur Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacebefore/), dan [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacewithin/) untuk mengontrol jarak paragraf. Properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh berikut mengatur jarak dalam paragraf pertama menjadi 200 % dari tinggi baris (spasi ganda):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The line spacing within the paragraph](line_spacing.png)

## **Mengontrol Pemotongan Baris**

Aturan pemotongan baris paragraf berguna pada blok teks sempit dan presentasi yang mencampur teks Latin dan Asia Timur. Properti berikut merupakan milik [IParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/), sehingga berlaku untuk seluruh paragraf:

- [LatinLineBreak](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/latinlinebreak/) mengontrol aturan pemotongan baris Latin. Pada teks campuran, mengubahnya juga dapat mengubah tempat pembungkus teks dan tanda baca Asia Timur yang berdekatan.
- [EastAsianLineBreak](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/eastasianlinebreak/) mengontrol aturan pemotongan baris Asia Timur, termasuk pembatasan karakter di awal dan akhir baris.

Aturan ini tidak menggantikan [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/wraptext/), yang mengaktifkan pembungkus otomatis dalam bingkai teks. Mereka memengaruhi tata letak ketika pembungkus terjadi; mereka tidak menyisipkan karakter pemotongan baris. Pemotongan baris eksplisit memaksa baris baru dalam paragraf terlepas dari lebar yang tersedia.

Contoh mandiri berikut membuat blok teks sempit yang berisi teks Cina dan Latin. Ia secara eksplisit mengatur kedua properti pemotongan baris dan menyimpan "line_breaking.pptx". Untuk bereksperimen dengan salah satu aturan, ubah nilai properti itu sementara nilai yang lain tetap. Contoh ini menggunakan Arial 24 poin dan SimSun dengan lebar bingkai 160 poin serta margin horizontal bingkai teks nol. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/autofittype/) diatur ke [TextAutofitType.None](https://reference.aspose.com/slides/id/net/aspose.slides/textautofittype/) sehingga ukuran teks dan dimensi bingkai tetap tetap.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Mengontrol Tanda Baca Menggantung**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/hangingpunctuation/) memungkinkan tanda baca yang memenuhi syarat melampaui tepi kanan baris teks alih-alih menempati baris berikutnya. Ia berlaku untuk seluruh paragraf dan berbeda dari inden menggantung.

Contoh mandiri berikut mengaktifkan tanda baca menggantung dalam bingkai teks lebar 100 poin dan menyimpan "hanging_punctuation.pptx". Dengan Arial 24 poin dan margin horizontal bingkai teks nol, titik akhir tetap berada setelah "sentence" dan melampaui tepi kanan teks. Atur properti ke [NullableBool.False](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/) untuk membandingkan: dengan pengaturan ini, titik berada pada baris terpisah. Pembungkus diaktifkan dan autofit dinonaktifkan agar lebar yang tersedia tetap tetap.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Tidak setiap tanda baca dapat menggantung. [Kondisi font dan tata letak yang dijelaskan di atas](#conditions-and-limitations) juga berlaku untuk perbandingan ini: mengubah font, lebar tersedia, margin, atau pengaturan autofit dapat menghilangkan perbedaan yang terlihat.

## **Mengatur Jenis Autofit untuk Bingkai Teks**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/autofittype/) menentukan bagaimana teks berperilaku ketika melebihi batas wadahnya. Gunakan untuk mengontrol apakah teks menyusut, meluber, atau mengubah ukuran bentuk secara otomatis. Contoh berikut mengonfigurasi bentuk agar menyesuaikan ukuran sesuai teks dan menyimpan hasilnya ke "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Untuk menghitung baris setelah pembungkus otomatis dan melihat bagaimana perubahan lebar teks atau bentuk memengaruhi hasil, lihat [Count Rendered Lines](/slides/id/net/manage-paragraph/). Jumlah baris saja tidak menunjukkan apakah teks meluber dari wadahnya.

## **Mengatur Penambatan Bingkai Teks**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/anchoringtype/) mendefinisikan bagaimana teks diposisikan secara vertikal di dalam sebuah bentuk, misalnya di atas, tengah, atau bawah. Contoh berikut menambatkan teks ke bagian bawah bentuk pertama dan menyimpan hasilnya ke "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Mengatur Tabulasi Teks**

Gunakan [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaulttabsize/) dan [IParagraphFormat.Tabs](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/tabs/) untuk mengonfigurasi berhenti tab dalam sebuah paragraf. Contoh berikut mengatur interval tab default menjadi 100 poin dan menambahkan berhenti tab rata kiri pada 30 poin. Pengaturan ini memengaruhi teks yang berisi karakter tab.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Hasilnya:

![The paragraph tabs](paragraph_tabs.png)

## **Mengatur Bahasa Proofing**

Aspose.Slides menyediakan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/), yang memungkinkan Anda mengatur bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh berikut memerlukan "presentation.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama dan setidaknya satu paragraf. Ia mengganti isi paragraf pertama dengan "1。", menetapkan SimSun sebagai fontnya, dan menetapkan bahasa proofing Mandarin Sederhana (`zh-CN`). Hasil disimpan ke "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Atur bahasa proofing ke Cina Sederhana.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Mengatur Bahasa Default**

Gunakan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/) untuk mendefinisikan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi. Contoh berikut membuat presentasi dengan bahasa teks Inggris Amerika sebagai default, menambahkan kotak teks, dan mencetak `en-US` untuk bagian teks pertamanya.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Tambahkan bentuk persegi panjang baru dengan teks.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Periksa bahasa bagian pertama.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Mengatur Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada tingkat presentasi, gunakan [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/defaulttextstyle/).

Contoh berikut menetapkan font tebal 14 poin sebagai default untuk paragraf tingkat atas dalam presentasi baru dan menyimpannya ke "default_text_style.pptx". Teks dapat mewarisi default ini kecuali ada pemformatan yang lebih spesifik yang menimpanya.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Dapatkan format paragraf tingkat atas.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Mengekstrak Teks dengan Efek All‑Caps**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks tampil dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, pustaka mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/net/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf kapital ketika nilainya `All`.

Contoh ini memerlukan "sample2.pptx" dengan kotak teks sebagai bentuk pertama pada slide pertama. Bagian pertama paragraf pertamanya berisi "Hello, Aspose!" dengan efek All Caps diterapkan, seperti yang ditunjukkan di bawah.

![The All Caps effect](all_caps_effect.png)

Contoh kode di bawah ini menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara mengubah teks dalam tabel pada slide?**

Untuk mengubah teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/). Iterasi sel-sel dan perbarui setiap sel melalui [ICell.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/icell/textframe/) serta pemformatan paragraf melalui [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/paragraphformat/).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fillformat/). Atur [IFillFormat.FillType](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformat/filltype/) ke [FillType.Gradient](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) dan konfigurasikan titik gradien, arah, serta transparansi.