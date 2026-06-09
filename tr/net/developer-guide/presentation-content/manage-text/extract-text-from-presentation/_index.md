---
title: .NET'te Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metni Çıkar
type: docs
weight: 90
url: /tr/net/extract-text-from-presentation/
keywords:
- metin çıkarma
- slayttan metin çıkarma
- sunumdan metin çıkarma
- PowerPoint'tan metin çıkarma
- OpenDocument'ten metin çıkarma
- PPT'den metin çıkarma
- PPTX'ten metin çıkarma
- ODP'den metin çıkarma
- metin alma
- slayttan metin alma
- sunumdan metin alma
- PowerPoint'tan metin alma
- OpenDocument'ten metin alma
- PPT'den metin alma
- PPTX'ten metin alma
- ODP'den metin alma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarından hızlıca metin çıkarın. Zaman kazanmak için basit, adım adım kılavuzumuzu izleyin."
---
## **Genel Bakış**

Sunumlardan metin çıkarma, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak hayati bir görevdir. Microsoft PowerPoint dosyaları PPT ya da PPTX formatında ya da OpenDocument sunumları (ODP) ile çalışıyor olun, metinsel verilere erişmek ve bunları almak analiz, otomasyon, indeksleme veya içerik taşıma amaçları için kritik olabilir.

Bu makale, Aspose.Slides for .NET kullanarak PPT, PPTX ve ODP gibi çeşitli sunum formatlarından metni verimli bir şekilde çıkarmak için kapsamlı bir rehber sunar. Sunum öğeleri üzerinde sistematik olarak nasıl iterasyon yapılacağını ve ihtiyacınız olan metin içeriğini doğru bir şekilde nasıl elde edeceğinizi öğreneceksiniz.

## **Slayttan Metin Çıkarma**

Aspose.Slides for .NET, [Aspose.Slides.Util](https://reference.aspose.com/slides/tr/net/aspose.slides.util/) ad alanını sağlar; bu ad alanı [SlideUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/) sınıfını içerir. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için bir dizi aşırı yüklenmiş static yöntemi sunar. Bir sunumdaki slayttan metin çıkarmak için [GetAllTextBoxes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextboxes/) yöntemini kullanın. Bu yöntem, parametre olarak [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) tipinde bir nesne alır. Çalıştırıldığında, yöntem tüm slaytı metin için tarar ve metin biçimlendirmesini koruyarak [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) tipinde nesneler dizisi döndürür.

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

Tüm sunumdaki metni taramak için [SlideUtil](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/) sınıfı tarafından sunulan [GetAllTextFrames](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/getalltextframes/) static yöntemini kullanın. Bu yöntem iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir [IPresentation](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/) nesnesi.
2. İkinci olarak, ana slaytların tarama sırasında dahil edilip edilmeyeceğini belirten bir `Boolean` değeri.

Yöntem, metin biçimlendirme bilgilerini içeren [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) tipinde nesneler dizisi döndürür. Aşağıdaki kod, ana slaytlar dahil olmak üzere bir sunumun metin ve biçimlendirme ayrıntılarını tarar.

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

[PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için yöntemler sunar:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/net/aspose.slides/textextractionarrangingmode/) enum bağımsız değişkeni, metin çıkarma sonucunun düzenlenme biçimini belirtir ve aşağıdaki değerlerden birine ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin slayttaki sırayla düzenlenir.

Düzenlenmemiş (unarranged) mod, hız kritik olduğunda kullanılabilir; düzenli (arranged) moddan daha hızlıdır.

[IPresentationText](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationtext/) sunumdan çıkarılan ham metni temsil eder. `SlidesText` özelliği, [ISlideText](https://reference.aspose.com/slides/tr/net/aspose.slides/islidetext/) tipinde nesneler dizisi döndürür. Her nesne ilgili slayttaki metni temsil eder. [ISlideText](https://reference.aspose.com/slides/tr/net/aspose.slides/islidetext/) tipindeki nesnenin aşağıdaki özellikleri vardır:

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

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve [büyük sunumları](/slides/tr/net/open-presentation/) işleyebilir; bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides sunumlardaki tablolar ve grafiklerden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafikle ilgili nesneler dahil olmak üzere birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapılarındaki metinsel içeriğe erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metni ücretsiz deneme sürümünü kullanarak çıkarabilirsiniz, ancak bu sürüm [belirli sınırlamalara](/slides/tr/net/licensing/) sahiptir; örneğin yalnızca sınırlı sayıda slayt işlenebilir. Sınırsız kullanım ve daha büyük sunumları işlemek için tam bir lisans satın almanız önerilir.