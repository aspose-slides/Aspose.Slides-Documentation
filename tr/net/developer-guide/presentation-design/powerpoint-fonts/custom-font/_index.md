---
title: PowerPoint Yazı Tiplerini .NET'te Özelleştirin
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/net/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint slaytlarındaki yazı tiplerini Aspose.Slides for .NET ile özelleştirerek sunumlarınızın her cihazda net ve tutarlı olmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunularda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesindeki font kaynakları aracılığıyla belirli bir sunum için font sağlayabilir veya dış yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, görsel ve diğer desteklenen biçimlere aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlarda tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Render için özel yazı tiplerini kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Eğer bir yazı tipinin sunum içinde saklanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 

Aspose Slides, bu yazı tiplerini [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemiyle yüklemenize izin verir:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükle**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurulum yapmadan yüklemenizi sağlar. Bu, PDF, görseller ve diğer desteklenen biçimler gibi dışa aktarım çıktısını etkileyerek belgelerin farklı ortamlarda tutarlı görünmesini sağlar. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı dosyalarını içeren bir veya birden fazla klasör belirleyin.  
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) metodunu çağırın.  
3. Sunumu yükleyin ve render/aktarım işlemini gerçekleştirin.  
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.ClearCache](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/clearcache/) metodunu çağırın.

Aşağıdaki kod örneği yazı tipi yükleme sürecini gösterir:

```cs
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/aktar (ör. PDF, görseller veya diğer formatlar).
presentation.Save("output.pdf", SaveFormat.Pdf);

// İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri font arama yollarına ekler, ancak font başlatma sırasını değiştirmez.  
Fontlar şu sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**
Aspose.Slides, font klasörlerini bulmanızı sağlayan [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) metodunu sunar. Bu metod, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem font klasörlerini döndürür.

Aşağıdaki C# kodu, [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) kullanımını gösterir:

```c#
// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Sunumda Kullanılan Özel Yazı Tiplerini Belirle**
Aspose.Slides, sunumla birlikte kullanılacak dış fontları belirlemenizi sağlayan [DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğini sunar.

Aşağıdaki C# kodu, [DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğinin nasıl kullanılacağını gösterir:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Sunumla çalışın
    // CustomFont1, CustomFont2 ve assets\fonts ve global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri sunumda kullanılabilir
}
```

## **Yazı Tiplerini Harici Olarak Yönet**

Aspose.Slides, dış fontları ikili veri üzerinden yüklemenizi sağlayan [LoadExternalFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) metodunu sunar.

Aşağıdaki C# kodu, bayt dizisi ile font yükleme sürecini göstermektedir: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // sunum ömrü süresince yüklenen harici yazı tipi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**

Evet. Bağlı yazı tipleri render motoru tarafından tüm dışa aktarım formatlarında kullanılır.

**Özel yazı tipleri otomatik olarak oluşturulan PPTX dosyasına gömülür mü?**

Hayır. Render için bir fontun kaydedilmesi, PPTX dosyasına gömülmesiyle aynı şey değildir. Fontun sunum dosyasının içinde taşınması gerekiyorsa, açıkça [gömme özelliklerini](/slides/tr/net/embedded-font/) kullanmanız gerekir.

**Bir özel font belirli glifleri içermediğinde geri dönüş davranışını kontrol edebilir miyim?**

Evet. [Font ikamesi](/slides/tr/net/font-substitution/), [değiştirme kuralları](/slides/tr/net/font-replacement/) ve [geri dönüş setleri](/slides/tr/net/fallback-font/) yapılandırarak istenen glif eksik olduğunda hangi fontun kullanılacağını tam olarak tanımlayabilirsiniz.

**Linux/Docker konteynerlerinde fontları sistem genelinde kurulum yapmadan kullanabilir miyim?**

Evet. Kendi font klasörlerinizi gösterebilir veya fontları bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem font dizinlerine bağımlılığı ortadan kaldırır.

**Lisanslama açısından özelleştirilmiş bir fontu sınırlama olmadan gömebilir miyim?**

Font lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımını yasaklar. Çıktıları dağıtmadan önce fontun EULA'sını mutlaka inceleyin.