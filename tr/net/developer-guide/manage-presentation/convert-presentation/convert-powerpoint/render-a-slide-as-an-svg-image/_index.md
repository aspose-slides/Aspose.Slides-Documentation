---
title: Sunum Slaytlarını .NET'te SVG Görüntüleri Olarak İşleyin
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- SVG dışa aktarma seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint slaytlarını .NET'te SVG görüntüleri olarak dışa aktarın ve Aspose.Slides ile yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik son işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG'nin sıkışık, tarayıcılar arasında öngörülebilir ya da etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktar**

Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) oluşturun, bir slayt seçin ve onu bir akışa yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Dosya adı, döngü indeksinin yerine [ISlide.SlideNumber](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/slidenumber/) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca belirli bir şekle ihtiyacı olduğunda [IShape.WriteAsSvg](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/writeassvg/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandır**

[SVGOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/) SVG renderlemesini kontrol eder. Metin çerçeveleri için, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/useframesize/) metin çerçevesini renderleme alanına dahil eder ve [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/useframerotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatürler olmadan renderlenmesi gerektiğinde [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/disablefontligatures/) değerini `true` olarak ayarlayın.

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

### **Tüm Metni Vektörleştir**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/vectorizetext/) değerini `true` olarak ayarlayarak tüm slayt metnini vektör grafik olarak yazın. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hâle getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/externalfontshandling/) harici olarak yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, SVG'ye yazı tipi verisini eklemek için `Embed`, harici yazı tipleri kullanan metni yalnızca grafik olarak renderlemek için ise `Vectorize` seçeneğini tercih edin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

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

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/picturescompression/) ile gömülü resimlerin çözünürlüğünü azaltın, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) ile kırpılmış kaynak alanlarını atlayın ve [SVGOptions.JpegQuality](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/jpegquality/) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, dosya boyutunu azaltır ancak görüntü doğruluğu veya saklanan görüntü verisi pahasına olur.

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

## **Şekillere ve Metne Kararlı Kimlikler Ata**

Her bir SVG şekli için [ISvgShape.Id](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshape/id/) ayarlamak üzere [ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshapeformattingcontroller/) kullanın. Metin `tspan` öğeleri için de [ISvgTSpan.Id](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgtspan/id/) değerlerini ayarlamak istiyorsanız [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) uygulayın. Kontrolörlerden birini [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın.

Aşağıdaki kontrolör, şeklin ömrü boyunca kararlı olan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/officeinteropshapeid/) ve metin span'ları için tekrar eden bir sayacı kullanır. Bu, oluşturulan kimliklerin değişmemiş bir sunumu sonradan işlemek için uygun olmasını sağlar.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshapeformattingcontroller/) içinde, dışa aktarılmış bir şekle JavaScript olay işleyicisi eklemek için [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshape/seteventhandler/) metodunu bir [SvgEvent](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgevent/) değeriyle çağırın. Kontrolörü [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) ile atayın ve JavaScript işlevini sonucu barındıran sayfada veya SVG belgesinde tanımlayın.

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

Barındırıcı sayfa, işleyici tarafından başvurulan JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**Ne zaman [SVGOptions.VectorizeText](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/vectorizetext/) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgexternalfontshandling/) kullanmalıyım?**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/vectorizetext/) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgexternalfontshandling/) yalnızca harici yazı tipleri kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**Bir SVG'yi daha küçük yapmak için en iyi yol nedir?**

İlk olarak gömülü resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bu dosyaları sunabiliyorsa bağlanmış yazı tipi dosyalarını seçin. Sonucu test edin; çünkü daha düşük görüntü çözünürlüğü, daha düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengelerine sahiptir.

**Dışa aktarılan SVG öğelerini dışa aktarımdan sonra değiştirebilir miyim?**

Evet. Bir formatlama kontrolörü aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini post‑işleme aracınızda veya tarayıcı betiğinizde seçin.