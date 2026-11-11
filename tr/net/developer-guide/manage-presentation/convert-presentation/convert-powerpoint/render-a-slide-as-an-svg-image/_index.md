---
title: .NET'te Sunum Slaytlarını SVG Görüntülerine Dönüştür
linktitle: Slayttan SVG'ye
type: docs
weight: 50
url: /tr/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'tan SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarım seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET'te PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile fontları, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides her slaytı ayrı bir SVG dosyasına aktarır ve metin, fontlar, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Kompakt, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gereken dışa aktarılan SVG'yi kullanmanız gerektiğinde [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarın**

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun, bir slayt seçin ve akışa yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Dosya adı, döngü indeksi yerine [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyacı olduğunda, [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) SVG işleme kontrol eder. Metin çerçeveleri için, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) metin çerçevesini işleme alanına dahil eder ve [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz render edilmesi gerektiğinde [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) değerini `true` olarak ayarlayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Ok Uçlarındaki Çizgi Sonu Kesimini Kontrol Etme**

SVG 1.1, bir çizginin ok ucunun altında nerede durması gerektiğini belirten bir marker içi ayarı sunmaz. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi, darbeyi (stroke) marker üzerinden çıkmayacak şekilde kısaltır. [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) değerini `true` olarak ayarlayarak darbeyi çizginin orijinal uç noktasına kadar çizin. Bu ayar yalnızca SVG çıktısını etkiler. Çizgi slayttaki konumunu ve uzunluğunu korur.

Örnek, 2 ve 10 puan genişliğindeki çizgilere üçgen ve elmas ok uçları çizer. Aynı slaytı sadece kırpma seçeneğini değiştirerek iki kez dışa aktarır.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Karşılaştırma, 10 puanlık çizgi üzerindeki üçgen ok ucunu gösterir. Kırpma etkin olduğunda, uç keskindir. Kırpma devre dışı olduğunda, darbe marker'ın eğimli kenarlarından dışarı çıkar ve düz bir uç bırakır.

![Kırpma etkin olduğunda keskin bir uca, devre dışı olduğunda düz bir uca sahip büyütülmüş 10 puanlık üçgen](line-end-cropping.png)

Örnekteki diğer çizgilerde, dışarı çıkan darbe 2 puanlık üçgende daha az görülür. Dolu elmas, her iki genişlikte de darbenin ucunu kapatır.

## **Metin ve Yazı Tiplerini Kontrol Etme**

Slaytları SVG olarak dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiklerine dönüştürülüp dönüştürülmeyeceğini ve dış yazı tiplerinin nasıl ekleneceğini veya referans verileceğini kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçilebilirliği ve yazı tipi bağımlılıkları arasında denge kurmanıza yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) değerini `true` olarak ayarlayarak tüm slayt metnini vektör grafik olarak yazın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Dış Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) dışarıdan yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed`, dış yazı tiplerini kullanan metni yalnızca grafik olarak işlemek için `Vectorize` seçeneğini seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Gömülü Görüntü Boyutunu Azaltma**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) kullanarak gömülü resimlerin çözünürlüğünü düşürebilir, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) ile kırpılmış kaynak bölgelerini atlayabilir ve [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ile JPEG kodlama kalitesini kontrol edebilirsiniz. Bu ayarlar, dosya boyutunu azaltırken görüntü doğruluğu veya tutulan görüntü verisi pahasına gerçekleşir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Metafile Tarama Çözünürlüğünü Kontrol Etme**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) SVG dışa aktarım sırasında metafile'ların rasterleştirilmesi için alt çözünürlük sınırını belirler. Bir EMF veya WMF görüntüsü rasterleştirildiğinde ayrıntı ile dosya boyutunu dengelemek için kullanın. Bu, SVG için küresel bir DPI tanımlamaz ve slayttaki her nesnenin raster görüntüye dönüşmesini zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; içinde sık aralıklı diyagonal çizgileri olan bir EMF görüntüsü vardır. Aşağıdaki örnek, ilk slaytını üç rasterleştirme çözünürlüğünde [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) aracılığıyla dışa aktarır. Diğer tüm dışa aktarma ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

| Metafile rasterleştirme DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, aynı büyütülmüş görüntü boyutunda gömülü rasterin aynı alanını gösterir. Diyagonal çizgiler 72 DPI'de belirgin pikselleşme gösterirken, daha yüksek çözünürlüklerde daha pürüzsüz kenarlar ortaya çıkar ve SVG dosyası büyür. Değeri artırmak, her detayı iyileştirmez veya her dışa aktarılan görüntüyü değiştirmez.

![72, 150 ve 300 DPI'de büyütülmüş diyagonal çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) görüntü çözünürlüğü azaltmayı kontrol eder ve metafile rasterleştirme çözünürlüğündeki değişikliğin etkisini gizleyebilir. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) JPEG kodlama kalitesini kontrol eder, metafile rasterleştirme çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Her SVG şekli için [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) ayarlamak üzere [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğeleri için de [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) değerlerini ayarlamak istiyorsanız, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) uygulayın. Her iki denetleyiciyi de [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

Aşağıdaki denetleyici, şeklin ömrü boyunca kararlı olan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) ve metin spanları için tekrarlanabilir bir sayıcı kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumu sonrasında işlemek için uygun olmasını sağlar.

## **SVG Olay İşleyicileri Ekleme**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) içinde, dışa aktarılmış bir şekle JavaScript olay işleyicisi eklemek için [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) metodunu bir [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) değeriyle çağırın. Denetleyiciyi [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın ve sonucu barındıran sayfada ya da SVG belgesinde JavaScript işlevini tanımlayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Barındırıcı sayfa, işleyici tarafından referans verilen JavaScript işlevini tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) ne zaman kullanılmalı?**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanılmalıdır. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) ise yalnızca dış yazı tipleri kullanan metnin grafik olarak dönüştürülmesi gerektiğinde kullanılmalıdır.

**Bir SVG'yi küçültmenin en iyi yolu nedir?**

İlk adım, gömülü resimleri sıkıştırmak, kırpılmış görüntü alanlarını silmek ve hedef ortam bu dosyaları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçmektir. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin, kalite ve boyut açısından farklı ticaret-off'lar sunar.

**Dışa aktarılan SVG öğelerini dışa aktarım sonrası değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından post‑işleme aracınızda veya tarayıcı betiğinizde eşleşen SVG öğelerini seçin.