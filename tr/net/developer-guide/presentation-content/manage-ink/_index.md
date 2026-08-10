---
title: Sunum Mürekkep Nesnelerini .NET'te Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/net/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarım
- mürekkep işleme
- mürekkebi gizle
- IInkOptions
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve Aspose.Slides for .NET ile PDF, HTML, SVG, TIFF ve görüntü dışa aktarımları sırasında mürekkebin görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest çizgiler çizebilmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelerin dikkatini çekmek için kullanılabilir.

[Aspose.Slides.Ink](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/) ad alanı, mürekkep nesneleriyle çalışmak için gereken sınıfları ve arabirimleri içerir. Örneğin, [IInk](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iink/) arabirimi bir slayttaki mürekkep nesnesini temsil eder.

## **Normal Nesneler ve Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler genellikle şekil nesneleriyle temsil edilir. En basit biçimde bir şekil, nesnenin (çerçevesinin) alanını tanımlayan ve konteyner boyutu, şekil ve arka plan gibi özellikleri içeren bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/net/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak, PowerPoint bir mürekkep nesnesini işlediğinde, nesne çerçevesinin (kapsayıcının) tüm özelliklerini boyutu dışında görmezden gelir. Kapsayıcı alanının boyutu, standart [IShape.Width](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/width/) ve [IShape.Height](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/height/) özellikleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Mürekkep izi, bir kullanıcının dijital mürekkep yazarken kalemin izlemesini kaydetmek için kullanılan temel bir öğedir. Bir iz, birbirine bağlı noktaların bir sırasını saklar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlı noktalar işlendiğinde, aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, bir mürekkep izinin noktalarını bağlayan çizgileri çizmek için kullanılır. Fırçanın kendi rengi ve boyutu vardır ve bu, [IInkBrush.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iinkbrush/color/) ve [IInkBrush.Size](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iinkbrush/size/) özellikleriyle temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu C# kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Mürekkep Fırçası Boyutunu Ayarlama**

Bu C# kodu, bir mürekkep fırçasının boyutunu nasıl ayarlayacağınızı gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Genellikle, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri olur). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları gözden geçirelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu hesaba katmaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görüntüye bakınız).

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için izlerin fırça boyutu göz önünde bulundurulmalıdır. Burada, hedef nesne (el yazısı metin izi) kapsayıcının (çerçevenin) boyutuna göre ölçeklenmiştir. Kapsayıcının boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış kullanır:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarma ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, dışa aktarılmış veya işlenmiş çıktıda mürekkep nesnelerinin nasıl görüneceğini kontrol etmek için [IInkOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/) arabirimini sağlar. Özelliklerini kullanarak mürekkebi tamamen gizleyebilir veya mürekkep fırçası maske işlemlerinin yorumlanma şeklini değiştirebilirsiniz.

Ink options are available through the export or rendering options for several output types:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/inkoptions/) |

Bu özellikler aracılığıyla aynı iki ayar mevcuttur:

- [`HideInk`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/hideink/) , mürekkep nesnelerinin çıktıya dahil edilip edilmeyeceğini belirler. Varsayılan değeri `false`'tur.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) , bir mürekkep fırçası işlenirken maske işleminin opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `true`'dır; `false` olarak ayarlarsanız ROP işlemi kullanılır.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, mürekkep nesneleri dışa aktarma sırasında görünür kalır. El yazısı notları veya diğer mürekkep içeriği olmadan temiz bir çıktı gerektiğinde [IInkOptions.HideInk](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/hideink/) özelliğini `true` olarak ayarlayın.

Aşağıdaki C# örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Bir Slaytı Görüntü Olarak İşlerken Mürekkep Nesnelerini Gizleme**

Slaytları bitmap görüntüler olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions.InkOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/inkoptions/) özelliğini yapılandırın ve işleme seçeneklerini [ISlide.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/) yöntemine geçirin.

Aşağıdaki C# örneği, ilk slaytı mürekkep nesneleri olmadan PNG görüntüsü olarak işler:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Mürekkep Maske İşlemesini Kontrol Etme**

`[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/)` özelliği, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlanacağını kontrol eder. Varsayılan değer `true` olup, opaklık kullanır. `false` olarak ayarlarsanız ROP işlemi kullanılır.

Aşağıdaki C# örneği bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı işleme kullanır:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions.InkOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/inkoptions/) aracılığıyla uygulanabilir.

### **Mürekkebi Gizleme veya Koruma Seçimi**

Ortaya konmuş bir sunumun temiz bir sürümü, örneğin inceleme işaretleri olmadan dağıtım amaçlı son bir kopya olması gerektiğinde, [IInkOptions.HideInk](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/hideink/) özelliğini `true` olarak ayarlayın.

[IInkOptions.HideInk](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/hideink/) özelliğini varsayılan `false` değerinde bırakın; böylece mürekkep notları, el yazısı notlar, vurgulamalar veya çizimler gibi amaçlanan içerik parçası haline gelir ve dışa aktarılmış sonuçta görünür kalır. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve final çıktıları üretmesini sağlar.

## **SSS**

**Mevcut bir mürekkep çizgisinin rengini veya boyutunu değiştirebilir miyim?**

Evet. İz'i [IInk.Traces](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iink/traces/) üzerinden alın, ardından [IInkTrace.Brush](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iinktrace/brush/) özelliklerini değiştirin. Fırçanın [IInkBrush.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iinkbrush/color/) ve [IInkBrush.Size](https://reference.aspose.com/slides/tr/net/aspose.slides.ink/iinkbrush/size/) özelliklerini ayarlayabilirsiniz.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [IInkOptions.HideInk](https://reference.aspose.com/slides/tr/net/aspose.slides.export/iinkoptions/hideink/) yalnızca işlenmiş veya dışa aktarılmış sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarma formatları mürekkep seçeneklerini destekler?**

Yukarıda gösterilen ilgili dışa aktarma veya işleme seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**Daha fazla okuma**

* Genel olarak şekiller hakkında bilgi edinmek için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/net/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/net/shape-effective-properties/#get-effective-font-height-value) bölümüne bakın.
* PDF dışa aktarımıyla ilgili ayrıntılar için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/net/convert-powerpoint-to-pdf/) bölümüne bakın.
* HTML dışa aktarımıyla ilgili ayrıntılar için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/net/convert-powerpoint-to-html/) bölümüne bakın.
* SVG dışa aktarımıyla ilgili ayrıntılar için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/net/render-a-slide-as-an-svg-image/) bölümüne bakın.
* TIFF dışa aktarımıyla ilgili ayrıntılar için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/net/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slayttan görüntüye işleme ile ilgili ayrıntılar için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/net/convert-slide/) bölümüne bakın.