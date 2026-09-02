---
title: .NET için PowerPoint Yazı Tiplerini Özelleştirin
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
description: "PowerPoint slaytlarındaki yazı tiplerini Aspose.Slides for .NET ile özelleştirerek sunumlarınızın her cihazda net ve tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak sağlar. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, görüntüler ve diğer desteklenen biçimlere dışa aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini render için kaydetmek, yazı tiplerini bir PPTX dosyasına gömmekten ayrıdır. Bir yazı tipinin sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 
Aspose Slides, bu yazı tiplerini **[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/)** yöntemiyle yüklemenize izin verir:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. **[TrueType](https://en.wikipedia.org/wiki/TrueType)**.
* OpenType (.otf) yazı tipleri. Bkz. **[OpenType](https://en.wikipedia.org/wiki/OpenType)**.
{{% /alert %}}

## **Özel Yazı Tiplerini Yükle**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurulum yapmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen biçimler gibi dışa aktarım çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik **[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/)** yöntemini çağırın.
3. Sunumu yükleyin ve render/ dışa aktarın.
4. **[FontsLoader.ClearCache](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/clearcache/)** yöntemini çağırarak yazı tipi önbelleğini temizleyin.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
presentation.Save("output.pdf", SaveFormat.Pdf);

// İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Not" %}}
**[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/)** ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
1. **[FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/)** aracılığıyla yüklü yollar.  
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, **[GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/)** yöntemini sağlayarak yazı tipi klasörlerini bulmanıza yardımcı olur. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C# kodu, **[GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/)** yönteminin nasıl kullanılacağını gösterir:

```c#
using Aspose.Slides;

// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Bir Sunumda Kullanılan Özel Yazı Tiplerini Belirt**

Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirtmenize olanak tanıyan **[DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/)** özelliğini sağlar.

Bu C# kodu, **[DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/)** özelliğinin nasıl kullanılacağını gösterir:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunumda kullanılabilir
}
```

## **Yazı Tiplerini Harici Olarak Yönet**

Aspose.Slides, ikili veriden harici yazı tiplerini yüklemenizi sağlayan **[LoadExternalFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)** yöntemini sunar.

Bu C# kodu, bayt dizisiyle yazı tipi yükleme sürecini göstermektedir:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // sunum ömrü boyunca dışarıdan yüklenen yazı tipi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**  
Evet. Bağlı yazı tipleri, render tarafından tüm dışa aktarım formatlarında kullanılır.

**Özel yazı tipleri otomatik olarak sonuç PPTX dosyasına gömülür mü?**  
Hayır. Bir yazı tipini render için kaydetmek, onu bir PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde taşınmasını istiyorsanız, açıkça **[gömme özelliklerini](/slides/tr/net/embedded-font/)** kullanmalısınız.

**Bir özel yazı tipinde belirli glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?**  
Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak tanımlamak için **[yazı tipi ikamesi](/slides/tr/net/font-substitution/)**, **[değiştirme kuralları](/slides/tr/net/font-replacement/)** ve **[geri dönüş setleri](/slides/tr/net/fallback-font/)** yapılandırabilirsiniz.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurulum yapmadan kullanabilir miyim?**  
Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine bağımlılığı ortadan kaldırır.

> **Not for Linux/Docker**: `FontsLoader.LoadExternalFonts` çağrılırken, `directories` dizisindeki her öğenin mevcut bir klasöre ait boş olmayan bir yol içerdiğinden emin olun. Bir ortam değişkeni kullanılarak yazı tipi yolu oluşturuluyorsa ve bu değişken tanımsız ya da boş ise, Aspose.Slides boş değeri tam yol olarak çözmeye çalışabilir ve bu da `System.ArgumentException` ile sonuçlanır.

**Lisanslama hakkında ne söyleyebilirsiniz—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**  
Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımını yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA’sını gözden geçirin.