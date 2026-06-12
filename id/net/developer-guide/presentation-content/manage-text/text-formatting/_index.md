---
title: Format Teks Presentasi di .NET
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/net/text-formatting/
keywords:
  - menyorot teks
  - ekspresi reguler
  - menyelaraskan paragraf
  - gaya teks
  - latar belakang teks
  - transparansi teks
  - jarak karakter
  - properti font
  - family font
  - rotasi teks
  - sudut rotasi
  - bingkai teks
  - jarak baris
  - properti autofit
  - jangkar frame teks
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

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Ini mencakup penyorotan, warna latar belakang, transparansi, jarak antar karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Dalam contoh di bawah, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Sorot Teks**

Gunakan metode [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/) saat Anda perlu menyorot teks yang cocok dengan contoh tertentu di dalam sebuah frame teks. Metode ini menerapkan warna sorotan pada fragmen teks yang cocok dan dapat digunakan bersama [TextSearchOptions](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/) untuk mengontrol cara pencarian dilakukan, misalnya, untuk mencocokkan hanya kata lengkap.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Ambil shape pertama dari slide pertama.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Sorot kata "try" di shape.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Sorot kata "to" di shape.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler. Di .NET, API ini tersedia pada [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).

Contoh kode di bawah menyorot semua kata yang mengandung **tujuh atau lebih karakter**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Sorot semua kata dengan tujuh atau lebih karakter.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Atur Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) untuk mengatur warna sorotan default untuk sebuah paragraf, atau gunakan [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/highlightcolor/) untuk bagian teks individual.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Atur warna sorotan untuk seluruh paragraf.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Hasilnya:

![Bagian teks abu-abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan [IParagraphFormat.Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) untuk mengatur perataan paragraf dalam sebuah frame teks. Nilainya dapat berupa tengah, rata kiri, rata kanan, rata kanan kiri (justified), dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Atur perataan paragraf ke tengah.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Atur Transparansi untuk Teks**

Transparansi teks diatur melalui komponen alfa dari warna yang ditetapkan pada [IPortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/fillformat/). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode di bawah menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Atur warna isi teks menjadi warna transparan.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Atur Jarak Karakter untuk Teks**

Gunakan [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/spacing/) untuk memperluas atau mempersempit jarak antar karakter dalam sebuah kotak teks.

Kode C# berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```cs
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

Contoh kode di bawah menunjukkan cara memperluas jarak karakter dalam **bagian teks dengan font tebal**:

```cs
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

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides mungkin terlihat sedikit lebih rapat dibandingkan teks yang sama ditampilkan di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, bahkan ketika font tersebut berisi informasi kerning yang valid dan kerning diaktifkan di pengaturan PowerPoint.

Untuk membuat output yang dirender lebih mirip dengan PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terpengaruh. Atur [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/kerningminimalsize/) ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```cs
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

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan rendering Aspose.Slides dengan output visual PowerPoint untuk font yang terpengaruh oleh perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada level paragraf melalui [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaultportionformat/) atau pada bagian individual melalui [IPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, garis bawah titik, dan font Times New Roman ke semua bagian dalam paragraf.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Atur properti font untuk paragraf.
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

Contoh kode di bawah menerapkan properti serupa pada **bagian teks dengan font tebal**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Hasilnya:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Atur Rotasi Teks**

Gunakan [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/textverticaltype/) untuk mengatur orientasi teks yang telah ditentukan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk menjadi `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Frame Teks**

Gunakan [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/rotationangle/) untuk mengatur sudut rotasi kustom untuk sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).

Contoh kode di bawah memutar frame teks sebesar 3 derajat searah jarum jam dalam bentuk:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacebefore/), dan [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/spacewithin/) untuk mengontrol jarak paragraf. Properti-properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```cs
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

## **Atur Tipe Autofit untuk Frame Teks**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/autofittype/) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks diperkecil, meluap, atau secara otomatis mengubah ukuran bentuk.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Atur Jangkar Frame Teks**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/anchoringtype/) menentukan bagaimana teks diposisikan secara vertikal di dalam sebuah bentuk, misalnya di atas, tengah, atau bawah.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Atur Tabulasi Teks**

Gunakan [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/defaulttabsize/) dan [IParagraphFormat.Tabs](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/tabs/) untuk mengkonfigurasi tab stop dalam sebuah paragraf.

```cs
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

![Tab paragraf](paragraph_tabs.png)

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan [IPortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/languageid/), yang memungkinkan Anda mengatur bahasa pemeriksaan untuk sebuah bagian teks. Bahasa pemeriksaan menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa pemeriksaan untuk sebuah bagian teks:

```cs
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

    // Atur Id bahasa pemeriksaan.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Atur Bahasa Default**

Gunakan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/) untuk mendefinisikan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Tambahkan shape persegi panjang baru dengan teks.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Periksa bahasa bagian pertama.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Atur Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada level presentasi, gunakan [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/defaulttextstyle/).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam presentasi baru.

```cs
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

## **Ekstrak Teks dengan Efek Semua Huruf Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Ketika Anda mengambil bagian teks seperti itu dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/net/aspose.slides/textcaptype/) dan konversi string yang dikembalikan menjadi huruf kapital ketika nilainya `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```cs
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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/). Iterasi melalui sel-sel dan perbarui setiap sel melalui [ICell.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/icell/textframe/) serta pemformatan paragraf melalui [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/paragraphformat/).

**Bagaimana cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [IPortionFormat.FillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/fillformat/). Atur [IFillFormat.FillType](https://reference.aspose.com/slides/id/net/aspose.slides/ifillformat/filltype/) menjadi [FillType.Gradient](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) dan konfigurasikan titik-titik gradien, arah, serta transparansi.