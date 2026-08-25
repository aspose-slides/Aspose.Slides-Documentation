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

Aspose.Slides, özel yazı tiplerini işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesi yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, görüntüler ve diğer desteklenen formatlara dışa aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Render için özel yazı tiplerini kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde depolanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler sadece yazı tipi adlarını saklar, ancak dosyaları kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/net/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerinin tutarlı render için kullanılabilir olmasını sağlayın.

{{% alert color="info" title="Note" %}}
Aspose Slides, bu yazı tiplerini [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize izin verir. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.  
2. Statik [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırarak bu klasörlerden yazı tiplerini yükleyin.  
3. Sunumu yükleyin ve render/ dışa aktarın.  
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.ClearCache](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği yazı tipi yükleme sürecini göstermektedir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Özel yazı tipi dosyalarını içeren klasörleri tanımla.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Belirtilen klasörlerden özel yazı tiplerini yükle.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/ dışa aktar (ör. PDF, görüntüler veya diğer formatlar).
presentation.Save("output.pdf", SaveFormat.Pdf);

// İş tamamlandıktan sonra yazı tipi önbelleğini temizle.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez. Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**
Aspose.Slides, [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) yöntemini sağlayarak yazı tipi klasörlerini bulmanıza olanak tanır. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C# kodu, [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) yönteminin nasıl kullanılacağını gösterir:

```c#
using Aspose.Slides;

// Bu satır, yazı tipi dosyalarının denetlendiği klasörleri çıktılar.
// Bunlar LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleridir.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Sunumla Kullanılacak Özel Yazı Tiplerini Belirtme**
Aspose.Slides, sunumla kullanılacak dış yazı tiplerini belirtmek için [DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğini sunar.

Bu C# kodu, [DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğinin nasıl kullanılacağını gösterir:

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
    // CustomFont1, CustomFont2 ve assets\fonts ile global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunuma kullanılabilir
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemek için [LoadExternalFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) yöntemini sunar.

Bu C# kodu, bayt dizisi üzerinden yazı tipi yükleme sürecini gösterir:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // dış yazı tipi sunum süresi boyunca yüklendi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlarda (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?**  
Evet. Bağlantılı yazı tipleri, render tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**  
Hayır. Bir yazı tipini render için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/net/embedded-font/) kullanmalısınız.

**Bir özel yazı tipi belirli glifleri içermediğinde geri dönüş davranışını kontrol edebilir miyim?**  
Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [font substitution](/slides/tr/net/font-substitution/), [replacement rules](/slides/tr/net/font-replacement/) ve [fallback sets](/slides/tr/net/fallback-font/) yapılandırabilirsiniz.

**Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?**  
Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine bağımlılığı ortadan kaldırır.

> **Note for Linux/Docker**: When calling `FontsLoader.LoadExternalFonts`, ensure that every entry in the `directories` array contains a non-empty path to an existing directory. If an environment variable used to construct a font path is undefined or empty, Aspose.Slides may attempt to resolve the empty value as a full path, resulting in `System.ArgumentException`.

**Lisanslama hakkında ne söyleyebilirsiniz—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**  
Yazı tipi lisans uyumluluğundan siz sorumlusunuz. Şartlar değişiklik gösterebilir; bazı lisanslar gömülmesini veya ticari kullanımını yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA sını inceleyin.