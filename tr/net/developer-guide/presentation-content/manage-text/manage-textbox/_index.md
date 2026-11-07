---
title: Sunumlarda .NET ile Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/net/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturma, tanımlama, biçimlendirme ve güncelleme."
---
## **Giriş**

Aspose.Slides for .NET'te slayt metni, şekillere ait metin çerçevelerinde depolanır. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) arayüzü en yaygın metin içeren şekli temsil eder ve metnini [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) özelliği aracılığıyla ortaya çıkar.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arayüzünü uygular, ancak her şekil bir otomatik şekil değildir ve bir metin çerçevesini desteklemeyebilir. Mevcut bir sunumu işlerken, metnine erişmeden önce şeklin `IAutoShape` arayüzünü uyguladığını kontrol edin.
{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için slayta bir otomatik şekil ekleyin, metin çerçevesine metin ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/)'a geçirilen koordinatlar ve boyutlar nokta cinsindendir. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) metin çerçevesini verilen metinle başlatır.

## **Metin Kutusu Şekli İçin Kontrol**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) özelliğini kullanarak bir otomatik şeklin metin kutusu olarak kabul edilip edilmediğini belirleyebilirsiniz. Bu, bir sunumun hem metin içeren hem de yalnızca grafiksel otomatik şekiller içermesi durumunda faydalıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki her otomatik şekli inceler:

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

Yeni eklenen bir otomatik şekil, içinde boş olmayan bir metin bulunana kadar metin kutusu olarak değerlendirilmez. Bu metni [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) veya [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, `IsTextBox` değerinin `false` kalmasına neden olur:

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

İlk iki çağrı `True`, son iki çağrı `False` yazdırır.

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel bir metin işleme kodu, hangi sunum nesnesinin içinde olduğunu bilmeden bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) alabilir. Sahibi olan [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) nesnesine geri dönmek için yalnızca okunabilir olan [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) özelliğini kullanın.

Bir metin çerçevesi bir otomatik şekil ya da başka bir metin içeren şekil tarafından sahiplenildiğinde, `ParentShape` sahibi içerir ve [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) `null` olur. Erişmeden önce döndürülen değeri kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de tanımlamak için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Şeklin Metin Dikdörtgenini Al**

Aspose.Slides for .NET 26.11 sürümünden itibaren, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) ana şeklin geometrisi tarafından tanımlanan metin alanını döndürür. Koordinatları ve boyutları nokta cinsindendir ve o şeklin sol‑üst köşesine göre görecelidir. Örneğin, bir elips dış sınırlarından daha küçük bir metin dikdörtgenine sahiptir.

Bu dikdörtgen şekli tanımlar, işlenen karakterleri değil. Metni ya da metin‑çerçeve kenar boşluklarını değiştirmek, onu doldurulan metnin ölçümü haline getirmez. İşlenen metin ölçümleri için [paragraph bounds](/slides/tr/net/paragraph-bounds/) veya [portion bounds](/slides/tr/net/portion-bounds/) kullanın.

[Aspose.Slides for .NET](/slides/tr/net/installation/) 26.11 veya sonraki sürümünü kurduktan sonra, bu örneği çalıştırarak geometrinin metin dikdörtgenini kırmızı olarak çizin. Şekiller döndürülmemiş ve gruplandırılmamış olduğundan, X/Y konumlarını eklemek, bindirmeyi slayta yerleştirmek için yeterlidir.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Yukarıdaki 200 × 100 noktalık şekiller için dikdörtgen `(0, 0, 200, 100)` döndürür; elips yaklaşık olarak `(29.289, 14.645, 141.421, 70.711)` döndürür. Yöntem ayrıca özel bir geometrinin bildirilen metin dikdörtgenini okur. Slayt‑alanı dönüşleri veya grup dönüşümlerini uygulamaz; bindirme konumlandırılırken bunları ayrı olarak hesaba katın. Geometri şekli olmayan bir metin çerçevesi (ör. tablo‑hücre metin çerçevesi) `InvalidOperationException` hatası oluşturabilir.

## **Metin Kutusuna Sütun Ekleme**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) özelliği metin çerçevesini sütunlara böler, [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) ise sütunlar arasındaki boşluğu nokta cinsinden ayarlar. Her iki ayar da [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) içinde yer alır ve mevcut bir metin kutusunun metin çerçevesi üzerinden değiştirilebilir. Metin aynı şekil içinde sütunlar arasında akış sağlar; başka bir şekle geçmez.

Aşağıdaki örnek, sütunlar arasında 10 nokta boşlukla üç sütunlu bir metin kutusu oluşturur, sunumu kaydeder ve ayarları çıktıyı dosyasından geri okur:

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

## **Tek Tek Sütunlardan Metin Çıkarma**

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) yöntemini kullanarak mevcut bir metin çerçevesindeki her görsel sütuna atanmış metni alabilirsiniz. Yöntem her sütun için bir dize döndürür; sütun‑tabanlı okuma sırasına göre. Tek sütunlu bir metin çerçevesi bir elemanlı bir dizi üretir, boş bir sütun ise boş dize ile temsil edilir. Dönüş değerleri yalnızca düz metin içerir; bölüm‑seviyesi biçimlendirme korunmaz.

Bu, aşağıdaki durumlarda faydalıdır:

- Metni, sütun‑tabanlı okuma sırasını koruyarak çıkarmak.
- Çok sütunlu slaytların içeriğini indekslemek veya karşılaştırmak.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe aktarmak.
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), yazı tipini veya metin‑çerçeve boyutunu değiştirdikten sonra metnin nasıl yeniden dağıtıldığını incelemek.

Yöntem, mevcut [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) içinde dağıtılan metni raporlar; ayrı şekiller ya da metin kutuları arasında otomatik akış sağmaz. Sütun dağılımı kullanılabilir yazı tiplerine ve diğer metin‑dizayn ayarlarına bağlı olabilir; tutarlı sonuçların önemli olduğu durumlarda gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, metin çerçevesi olan ilk çok‑sütunlu otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütunun metnini ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

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

## **Metni Güncelleme**

Bir sunumdaki tüm metni güncellemek için slaytları ve şekilleri döngüye alın, otomatik şekilleri seçin ve ardından metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirmenize olanak tanır.

Aşağıdaki örnek, otomatik‑şekil metnindeki her `years` ifadesini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

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

Bu geçiş yalnızca otomatik şekillerdeki metni günceller. Tablolarda, grafiklerde, SmartArt’ta veya gruplandırılmış şekillerde saklanan metin, ilgili nesnelerin kendi koleksiyonları üzerinden dolaşılmasını gerektirir.

## **Bir Metin Kutusuna Köprü Ekleme**

Bir köprü, yalnızca belirli bir metin bölümüne atanabilir; böylece sadece o metin tıklanabilir bir bağlantı olur. Bölümü dış URL’ye bağlamak için [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) yöntemini kullanın.

Aşağıdaki örnek, bağlantılı metin oluşturur ve bir sunuma kaydeder:

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

## **SSS**

**Bir ana / yerleşim slaytındaki metin kutusu ile metin yer tutucusu arasındaki fark nedir?**

Bir [yer tutucu](/slides/tr/net/manage-placeholder/) konum ve biçimlendirmesini bir [ana slayttan](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) veya [yerleşim slaytından](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) miras alabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve yerleşim değiştiğinde yer tutucu davranışı kazanmaz.

**Grafiklerde, tablolarda veya SmartArt’ta metni değiştirmeden metni nasıl değiştirebilirim?**

Metin güncelleme örneğinde gösterildiği gibi gezinmeyi yalnızca [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) uygulayan şekillerle sınırlayın. Grafikler, tablolar ve SmartArt, kendi nesne modellerinde metin depolar; bu döngü onları değiştirmez.