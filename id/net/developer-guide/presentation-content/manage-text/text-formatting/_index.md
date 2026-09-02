---  
title: Format Teks Presentasi di .NET  
linktitle: Pemformatan Teks  
type: docs  
weight: 50  
url: /id/net/text-formatting/  
keywords:  
- menyelaraskan paragraf  
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
- penjepakan bingkai teks  
- tabulasi teks  
- bahasa default  
- PowerPoint  
- OpenDocument  
- presentasi  
- .NET  
- C#  
- Aspose.Slides  
description: "Format dan gayakan teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Sesuaikan font, warna, penjajaran, dan lainnya."  
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Artikel ini mencakup warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penjepakan teks, tabulasi, dan pengaturan bahasa.

Dalam contoh di bawah ini, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Cari dan Ganti Teks](/slides/id/net/search-and-replace-text/).

## **Set Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) untuk mengatur warna sorot default untuk sebuah paragraf, atau gunakan [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/highlightcolor/) untuk bagian teks individual.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**: 

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Tetapkan warna sorot untuk seluruh paragraf.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah ini menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan huruf tebal**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Tetapkan warna sorot untuk bagian teks.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Bagian teks abu-abu](gray_text_portions.png)

## **Sejajarkan Paragraf Teks**

Gunakan [IParagraphFormat.Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) untuk mengatur penjajaran paragraf di dalam bingkai teks. Nilainya dapat berupa rata tengah, rata kiri, rata kanan, rata kiri-kanan, dan sebagainya.

Contoh kode berikut menunjukkan cara menyelaraskan paragraf ke **tengah**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Tetapkan penjajaran paragraf ke tengah.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf yang diselaraskan](aligned_paragraph.png)

## **Set Transparansi untuk Teks**

Transparansi teks dikendalikan melalui komponen alfa dari warna yang ditetapkan ke [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fillformat/). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode di bawah ini menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Tetapkan warna isi teks menjadi warna transparan.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan huruf tebal**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Tetapkan transparansi bagian teks.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Set Jarak Karakter untuk Teks**

Gunakan [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/spacing/) untuk memperluas atau memperkecil jarak antar karakter dalam sebuah kotak teks.

Kode C# berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Perluas jarak karakter.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah ini menunjukkan cara memperluas jarak karakter dalam **bagian teks dengan huruf tebal**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Hasilnya:

![Jarak karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat dibandingkan teks yang sama ditampilkan di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, bahkan ketika font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat output yang dirender lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terpengaruh. Atur [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/kerningminimalsize/) ke nilai yang secara signifikan lebih besar daripada ukuran font sebenarnya:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan render Aspose.Slides dengan output visual PowerPoint untuk font yang terpengaruh oleh perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) atau pada bagian individu melalui [IPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: menerapkan ukuran font, tebal, miring, garis bawah bertitik, dan font Times New Roman ke semua bagian dalam paragraf.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Tetapkan properti font untuk paragraf.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode di bawah ini menerapkan properti serupa pada **bagian teks dengan huruf tebal**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Tetapkan properti font untuk bagian teks.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Set Rotasi Teks**

Gunakan [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/textverticaltype/) untuk mengatur orientasi teks yang telah ditentukan sebelumnya di dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk menjadi `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Set Rotasi Kustom untuk Bingkai Teks**

Gunakan [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/rotationangle/) untuk mengatur sudut rotasi kustom untuk sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).

Contoh kode di bawah ini memutar bingkai teks sebesar 3 derajat searah jarum jam di dalam bentuk:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Rotasi teks kustom](custom_text_rotation.png)

## **Set Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacebefore/), dan [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacewithin/) untuk mengontrol jarak paragraf. Properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Jarak baris dalam paragraf](line_spacing.png)

## **Set Tipe Autofit untuk Bingkai Teks**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/autofittype/) menentukan bagaimana teks berperilaku ketika melebihi batas wadahnya. Gunakan untuk mengontrol apakah teks menyusut, meluap, atau mengubah ukuran bentuk secara otomatis.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Set Penjepakan Bingkai Teks**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/anchoringtype/) menentukan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di bagian atas, tengah, atau bawah.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Set Tabulasi Teks**

Gunakan [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaulttabsize/) dan [IParagraphFormat.Tabs](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/tabs/) untuk mengonfigurasi tabulasi dalam sebuah paragraf.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Tabulasi paragraf](paragraph_tabs.png)

## **Set Bahasa Pemeriksaan**

Aspose.Slides menyediakan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/), yang memungkinkan Anda mengatur bahasa pemeriksaan untuk sebuah bagian teks. Bahasa pemeriksaan menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa pemeriksaan untuk sebuah bagian teks:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Tetapkan Id bahasa pemeriksaan.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Set Bahasa Default**

Gunakan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/) untuk menentukan bahasa default bagi teks yang dibuat saat memuat atau membuat presentasi.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Tambahkan bentuk persegi panjang baru dengan teks.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Periksa bahasa bagian pertama.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Set Gaya Teks Default**

Untuk menerapkan format teks default pada tingkat presentasi, gunakan [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/defaulttextstyle/).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam presentasi baru.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Dapatkan format paragraf tingkat atas.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Ekstrak Teks dengan Efek Semua Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Ketika Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/net/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf kapital ketika nilainya `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek Semua Kapital](all_caps_effect.png)

Contoh kode di bawah ini menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Keluaran:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/). Iterasi melalui sel-sel dan perbarui setiap sel melalui [ICell.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/icell/textframe/) serta format paragraf melalui [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/paragraphformat/).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/fillformat/). Atur [IFillFormat.FillType](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformat/filltype/) ke [FillType.Gradient](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) dan konfigurasikan titik-titik gradien, arah, serta transparansi.