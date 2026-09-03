---
title: "PowerPoint ve OpenDocument Sunumlarında .NET ile Metin Kutularını Yönetme"
linktitle: "Metin Kutusunu Yönet"
type: docs
weight: 20
url: /tr/net/manage-textbox/
keywords:
- "metin kutusu"
- "metin çerçevesi"
- "metin ekle"
- "metni güncelle"
- "metin kutusu oluştur"
- "metin kutusunu kontrol et"
- "metin sütunu ekle"
- "köprü ekle"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturun, tanımlayın, biçimlendirin ve güncelleyin."
---
## **Introduction**

Aspose.Slides for .NET'te slayt metni, şekillere ait metin çerçevelerinde saklanır. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) arabirimi en yaygın metin taşıyan şekli temsil eder ve metnini [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/textframe/) özelliği aracılığıyla sunar.

{{% alert color="info" title="Note" %}}

Her otomatik şekil [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) uygular, ancak her şekil bir otomatik şekil değildir veya bir metin çerçevesi desteklemez. Mevcut bir sunumu işlerken, metnine erişmeden önce bir şeklin `IAutoShape` uygular olduğundan emin olun.

{{% /alert %}}

## **Create a Text Box on a Slide**

Bir metin kutusu oluşturmak için bir otomatik şekil slayta ekleyin, metin çerçevesine metin ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addautoshape/) metoduna geçirilen koordinatlar ve boyutlar puan cinsindendir. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/addtextframe/) metin çerçevesini sağlanan metinle başlatır.

## **Check for a Text Box Shape**

Bir otomatik şeklin metin kutusu olarak ele alınıp alınmadığını belirlemek için [AutoShape.IsTextBox](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/istextbox/) özelliğini kullanın. Bu, bir sunumun hem metin taşıyan hem de sadece grafiksel otomatik şekiller içerdiği durumlarda faydalıdır.

![A text box and a shape](istextbox.png)

Aşağıdaki örnek, bir sunumdaki her otomatik şekli inceler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Yeni eklenen bir otomatik şekil, içinde boş olmayan metin bulunduğunda metin kutusu olarak kabul edilir. Bu metni [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/addtextframe/) veya [ITextFrame.Text](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/text/) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, `IsTextBox` özelliğini `false` olarak bırakır:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

İlk iki çağrı `True` yazdırır; son iki çağrı `False` yazdırır.

## **Find the Shape That Owns a Text Frame**

Genel metin işleme kodu, hangi sunum nesnesinin içinde bulunduğunu bilmeden bir [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) alabilir. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) nesnesine geri dönmek için sadece‑okunur [ITextFrame.ParentShape](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentshape/) özelliğini kullanın.

Bir otomatik şekil veya başka bir metin taşıyan şekil tarafından sahip olunan bir metin çerçevesi için `ParentShape` sahibi içerir ve [ITextFrame.ParentCell](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/parentcell/) `null` olur. Erişmeden önce döndürülen değeri kontrol edin. Şekil ve tablo‑hücre sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içerecek şekilde tanımlamak için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Add Columns to a Text Box**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/columncount/) özelliği metin çerçevesini sütunlara bölürken, [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/columnspacing/) sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki ayar da [ITextFrameFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/) içinde bulunur ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında akış sağlar; başka bir şekle devam etmez.

Aşağıdaki örnek, sütunlar arasında 10 puan boşluk bırakarak üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve ayarları çıktı dosyasından geri okur:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Extract Text from Individual Columns**

Mevcut bir metin çerçevesindeki her görsel sütuna atanmış metni almak için [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/splittextbycolumns/) metodunu kullanın. Metot, sütun‑bazlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi tek öğeli bir dizi üretir ve boş bir sütun boş dizeyle temsil edilir. Dize yalnızca düz metin içerir; bölüm‑seviyesindeki biçimlendirme korunmaz.

Bu özellik aşağıdaki durumlarda faydalıdır:

- Metni sütun‑bazlı okuma sırasını koruyarak çıkarmak.
- Çok‑sütunlu slaytların içeriğini dizine eklemek veya karşılaştırmak.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe aktarmak.
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/columnspacing/), yazı tipi veya metin‑çerçeve boyutu değiştirildiğinde metnin nasıl yeniden dağıtıldığını incelemek.

Metot, mevcut [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) içindeki dağıtılan metni rapor eder; ayrı şekiller veya metin kutuları arasında otomatik akış sağlamaz. Sütun dağılımı kullanılabilir yazı tiplerine ve diğer metin‑dizayn ayarlarına bağlı olabilir; tutarlı sonuçların önemli olduğu durumlarda gereken yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesine sahip ilk çok‑sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütundan metni ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Update Text**

Bir sunumda metni güncellemek için slaytları ve şekilleri döngüye alın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenize olanak tanır.

Aşağıdaki örnek, otomatik‑şekil metnindeki tüm `years` ifadelerini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Bu gezinme yalnızca otomatik şekillerdeki metni günceller. Tablolarda, grafiklerde, SmartArt’ta veya gruplanmış şekillerde saklanan metin, bu nesnelerin kendi koleksiyonları içinde gezilerek güncellenmelidir.

## **Add a Text Box with a Hyperlink**

Bir köprü belirli bir metin bölümüne atanabilir; böylece sadece o metin tıklanabilir bağlantı olur. Bölümü harici bir URL ile ilişkilendirmek için [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) kullanın.

Aşağıdaki örnek bağlantılı metin oluşturur ve bir sunuma kaydeder:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

Bir [placeholder](/slides/tr/net/manage-placeholder/) konumunu ve biçimini bir [master slide](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslide/) veya [layout slide](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve düzen değiştiğinde placeholder davranışı kazanmaz.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Geçişi, [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) uygulayan şekillerle sınırlayın; bu, Metni Güncelle örneğinde gösterildiği gibi yapılır. Grafikler, tablolar ve SmartArt, kendi nesne modellerinde metin depolar; bu döngü tarafından değiştirilmezler.