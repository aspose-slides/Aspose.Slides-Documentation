---
title: Sunumlardan Gelişmiş Metin Çıkarma .NET'te
linktitle: Metin Çıkarma
type: docs
weight: 90
url: /tr/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/tr/
keywords:
- metin çıkar
- slayttan metin çıkar
- sunumdan metin çıkar
- PowerPoint'tan metin çıkar
- OpenDocument'ten metin çıkar
- PPT'den metin çıkar
- PPTX'ten metin çıkar
- ODP'den metin çıkar
- metin al
- slayttan metin al
- sunumdan metin al
- PowerPoint'tan metin al
- OpenDocument'ten metin al
- PPT'den metin al
- PPTX'ten metin al
- ODP'den metin al
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarından hızlıca metin çıkarın. Zaman tasarrufu sağlamak için basit, adım adım rehberimizi izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarmak, slayt içeriği ile çalışan geliştiriciler için yaygın ancak kritik bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında olsun ya da OpenDocument sunumları (ODP) olsun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için hayati önem taşıyabilir.

Bu makale, Aspose.Slides for .NET kullanarak PPT, PPTX ve ODP dahil çeşitli sunum formatlarından metni verimli bir şekilde çıkarmanın kapsamlı bir rehberini sunar. Sunum öğeleri arasında sistematik olarak nasıl döngü oluşturup ihtiyaç duyduğunuz metin içeriğini doğru bir şekilde alacağınızı öğreneceksiniz.

## **Slayttan Metin Çıkarma**

Aspose.Slides for .NET, [Aspose.Slides.Util](https://reference.aspose.com/slides/tr/net/aspose.slides.util/) ad alanını sağlar; bu ad alanda [SlideUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/) sınıfı bulunur. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için bir dizi aşırı yüklenmiş statik yöntem sunar. Bir sunumdaki slayttan metin çıkarmak için [GetAllTextBoxes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextboxes/) yöntemini kullanın. Bu yöntem, parametre olarak [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) türünde bir nesne alır. Çalıştırıldığında, yöntem tüm slaytı metin için tarar ve [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) türündeki nesnelerin bir dizisini döndürür; metin biçimlendirmesini korur.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkarır:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Sunumdan Metin Çıkarma**

Tüm sunumdan metni taramak için, [SlideUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/) sınıfının sunduğu [GetAllTextFrames](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextframes/) statik yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir [IPresentation](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/) nesnesi.
1. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `Boolean` değeri.

Yöntem, metin biçimlendirme bilgilerini içeren [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) türündeki nesnelerin bir dizisini döndürür. Aşağıdaki kod, ana slaytlar da dahil olmak üzere bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Kategorize ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) sınıfı ayrıca sunumlardan tüm metni çıkarmak için yöntemler sağlar:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/net/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenlenme şeklini gösterir ve aşağıdaki değerlerden birine ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki aynı sırayla düzenlenir.

Hızın kritik olduğu durumlarda düzenlenmemiş (unarranged) mod kullanılabilir; bu mod, düzenli (arranged) moddan daha hızlıdır.

[IPresentationText](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationtext/) sunumdan çıkarılan ham metni temsil eder. `SlidesText` özelliği, [ISlideText](https://reference.aspose.com/slides/tr/net/aspose.slides/islidetext/) türündeki nesnelerin bir dizisini döndürür. Her nesne, ilgili slayttaki metni temsil eder. [ISlideText](https://reference.aspose.com/slides/tr/net/aspose.slides/islidetext/) türündeki nesnenin aşağıdaki özellikleri vardır:

- `Text` - Slayt şekillerindeki metin.
- `MasterText` - Bu slaytla ilişkili ana slayt şekillerindeki metin.
- `LayoutText` - Bu slaytla ilişkili yerleşim slaytı şekillerindeki metin.
- `NotesText` - Bu slaytla ilişkili not slaytı şekillerindeki metin.
- `CommentsText` - Bu slaytla ilişkili yorumlardaki metin.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarımı sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve [büyük sunumları](/slides/tr/net/open-presentation/) bile işleyebilir; bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides, tablolar ve grafiklerle ilişkili nesneler dahil olmak üzere sunumlardaki metni çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafiklerle ilişkili nesneler dahil olmak üzere birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapılarınızdaki metinsel içeriğe erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni ücretsiz deneme sürümü Aspose.Slides ile çıkarabilirsiniz, ancak bu sürüm [belirli kısıtlamalara](/slides/tr/net/licensing/) sahiptir; örneğin sadece sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları işlemek için tam bir lisans satın almanız tavsiye edilir.