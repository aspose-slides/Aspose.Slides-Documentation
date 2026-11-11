---
title: ".NET'te Sunum Slaytlarını SVG Görüntüleri Olarak Renderleme"
linktitle: "Slayttan SVG"
type: docs
weight: 50
url: /tr/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint'tan SVG'ye"
- "sunumdan SVG'ye"
- "slayttan SVG'ye"
- "PPT'den SVG'ye"
- "PPTX'ten SVG'ye"
- "SVG dışa aktarma seçenekleri"
- "etkileşimli SVG"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET'te PowerPoint slaytlarını SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik sonrası işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü biçimidir. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin sıkı, tarayıcılar arasında öngörülebilir veya etkileşimli kullanıma hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktar**

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun, bir slaytı seçin ve onu bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Dosya adı, döngü indeksinin yerine [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyaç duyduğu durumlarda [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) ile bireysel bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandır**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) metin çerçevesini renderleme alanına ekler ve [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürsüz renderlenmesi gerektiğinde [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) değerini `true` olarak ayarlayın.

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

## **Metin ve Yazı Tiplerini Kontrol Et**

Slaytları SVG olarak dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiklerine dönüştürüleceğini ve harici yazı tiplerinin nasıl dahil edileceğini veya referans alınacağını kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçimi ve yazı tipi bağımlılıkları arasında denge kurmanıza yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) değerini `true` olarak ayarlayın; bu, slayt metninin tamamını vektör grafikleri olarak yazar. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucun tarayıcılar arasında daha tutarlı olmasını sağlar, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

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

### **Harici Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, SVG'ye yazı tipi verisini dahil etmek için `Embed`, harici yazı tipleri kullanan metni yalnızca grafik olarak renderlemek için `Vectorize` seçin. Yazı tiplerini gömmeden önce lisans koşullarını doğrulayın.

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

## **Gömülü Görüntü Boyutunu Azalt**

[Gömülü resimlerin çözünürlüğünü azaltmak için [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) kullanın, kırpılmış kaynak alanlarını dışlamak için [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) ve JPEG kodlama kalitesini kontrol etmek için [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) kullanın. Bu ayarlar, dosya boyutunu azaltırken görüntü doğruluğu veya kalan görüntü verisi pahasına olur.

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

## **Metafile Tarama Çözünürlüğünü Kontrol Et**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) SVG dışa aktarımı sırasında metafile'ların rasterleştirilmesi için alt çözünürlük sınırını belirler. EMF veya WMF görüntüsü rasterleştirildiğinde ayrıntı ile dosya boyutu arasında denge sağlamak için bunu kullanın. Bu, SVG için küresel bir DPI tanımlamaz veya slayttaki her nesnenin bir raster görüntüsü olmasını zorlamaz.

EMF görüntüsü, sık aralıklı köşegen çizgiler içeren [metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin. Aşağıdaki örnek, [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) aracılığıyla ilk slaytını üç farklı tarama çözünürlüğünde dışa aktarır. Diğer tüm dışa aktarım ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

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

Çıktıda, EMF her SVG'de tek bir gömülü PNG'ye dönüşmüştür. Aşağıdaki ölçümler sağlanan sunum içindir; DPI'yi piksel boyutlarına dönüştürmek için genel bir formül değildir.

| Metafile tarama DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, gömülü rasterin aynı alanını aynı büyütülmüş görüntü boyutunda gösterir. Köşegen çizgiler 72 DPI'de belirgin pikselleşme, daha yüksek çözünürlüklerde ise daha düzgün kenarlar gösterirken SVG dosyası büyür. Değeri artırmak her detayı iyileştirmez veya her dışa aktarılan görüntüyü değiştirmez.

![Büyütülmüş köşegen çizgi detayı 72, 150 ve 300 DPI'de](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) görüntü çözünürlüğü azaltmayı kontrol eder ve metafile tarama çözünürlüğündeki değişimin etkisini maskeleyebilir. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) JPEG kodlama kalitesini kontrol eder, metafile tarama çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Atama**

Her SVG şekli için [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) ayarlamak üzere [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğeleri için de [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) değerlerini ayarlamak istiyorsanız [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) uygulayın. Her iki kontrolleyiciyi de [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın.

Aşağıdaki kontrolleyici, şeklin ömrü boyunca kararlı olan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) ve metin span'leri için tekrarlanabilir bir sayaç kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumun sonrası işlenmesi için uygun olmasını sağlar.

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

## **SVG Olay İşleyicileri Ekle**

Bir [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) içinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) yöntemini bir [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) değeriyle çağırın. Kontrolleyiciyi [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın ve sonucu barındıran sayfada veya SVG belgesinde JavaScript işlevini tanımlayın.

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

Ana sayfa, işleyici tarafından referans verilen JavaScript işlevini tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) ne zaman kullanılmalı?**

Tüm metnin yazı tiplerinden bağımsız olması gerektiğinde [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) kullanın. Yalnızca harici yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

Öncelikle gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite‑boyut dengeleri sunar.

**Dışa aktarılan SVG öğelerini dışa aktarım sonrası değiştirebilir miyim?**

Evet. Bir biçimlendirme kontrolleyicisi aracılığıyla kimlikler atayın, ardından bu kimliklere uygun SVG öğelerini sonrası‑işleme aracınızda veya tarayıcı betiğinizde seçip değiştirebilirsiniz.