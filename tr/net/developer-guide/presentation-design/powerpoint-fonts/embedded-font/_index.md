---
title: .NET'te Sunumlara Yazı Tipi Gömme
linktitle: Yazı Tipi Gömme
type: docs
weight: 40
url: /tr/net/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi göm
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarına TrueType yazı tipleri gömerek, tüm platformlarda doğru render alınmasını sağlar."
---
## **Giriş**

**PowerPoint'te yazı tiplerini gömmek**, sunumunuzun farklı sistemlerde bile istediği görünümünü korumasını sağlar. Yaratıcılık için benzersiz yazı tipleri ya da standart olanları kullansanız da, yazı tiplerini gömmek metin ve düzen bozulmalarını önler.

Çalışmanızda yaratıcılık göstermek için üçüncü taraf veya standart dışı bir yazı tipi kullandıysanız, yazı tipinizi gömmek için daha da fazla nedeniniz olur. Aksi takdirde (gömülü yazı tipleri olmadan), slaytlarınızdaki metinler veya sayılar, düzen, stil vb. değişebilir veya karışık dikdörtgenlere dönüşebilir.

Gömülü yazı tiplerini yönetmek için [FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/tr/net/aspose.slides/fontdata/) ve [Compress](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/) sınıflarını kullanın.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Bir sunumdan gömülü yazı tiplerini kolayca almak veya kaldırmak için [GetEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts) ve [RemoveEmbeddedFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/removeembeddedfont) yöntemlerini kullanın.

Bu C# kodu, bir sunumdan gömülü yazı tiplerini nasıl alıp kaldıracağınızı gösterir:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Gömülü "FunSized" kullanan bir metin çerçevesi içeren slaytı render eder
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // "Calibri" yazı tipini bulur
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // "Calibri" yazı tipini kaldırır
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Sunumu render eder; "Calibri" yazı tipi mevcut bir yazı tipiyle değiştirilir
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Sunumu gömülü "Calibri" yazı tipi olmadan diske kaydeder
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Gömülü Yazı Tipi Ekle**

[EmbedFontCharacters](https://reference.aspose.com/slides/tr/net/aspose.slides.export/embedfontcharacters/) enum'ını ve [AddEmbeddedFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/addembeddedfont/) yönteminin iki aşırı yüklemesini kullanarak, bir sunumda yazı tiplerini gömmek için tercih ettiğiniz (gömme) kuralını seçebilirsiniz. Bu C# kodu, bir sunuma nasıl yazı tipi gömeceğinizi ve ekleyeceğinizi gösterir:

```c#
// Sunumu yüklüyor
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Sunumu diske kaydediyor
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Gömülü Yazı Tiplerini Sıkıştır**

Gömülü yazı tiplerini sıkıştırarak dosya boyutunu küçültmek için [CompressEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/compressembeddedfonts/) özelliğini kullanın.

Sıkıştırma için örnek kod:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir sunumdaki belirli bir yazı tipinin gömülmüş olmasına rağmen yine de render sırasında değiştirileceğini nasıl anlayabilirim?**

Yazı tipi yöneticisindeki [substitution information](/slides/tr/net/font-substitution/) ve [fallback/substitution rules](/slides/tr/net/fallback-font/) bağlantılarını kontrol edin: yazı tipi kullanılamaz veya kısıtlıysa, bir yedek yazı tipi kullanılacaktır.

**Arial/Calibri gibi "sistem" yazı tiplerini gömmek değerli mi?**

Genellikle hayır—bu yazı tipleri neredeyse her zaman mevcuttur. Ancak "ince" ortamlar (Docker, önceden yüklü yazı tipleri olmayan bir Linux sunucusu) içinde tam taşınabilirlik için sistem yazı tiplerini gömmek beklenmedik değişim riskini ortadan kaldırabilir.