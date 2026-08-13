---
title: ".NET'te PowerPoint Yazı Tiplerini Özelleştirme"
linktitle: "Özel Yazı Tipi"
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
description: "Sunumlarınızın her cihazda net ve tutarlı olmasını sağlamak için Aspose.Slides for .NET ile PowerPoint slaytlarındaki yazı tiplerini özelleştirin."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum işlendiğinde veya dışa aktarıldığında, örneğin PDF, görseller ve diğer desteklenen biçimlere, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini işleme için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin doğrudan sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="info" %}} 
Aspose Slides, bu yazı tiplerini [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemiyle yüklemenize izin verir:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurulum yapmadan yüklemenize olanak tanır. Bu, PDF, görseller ve diğer desteklenen biçimler gibi dışa aktarım çıktısını etkileyerek, ortaya çıkan belgelerin ortamlar arasında tutarlı görünmesini sağlar. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırın.
3. Sunumu yükleyin ve işleyin/ dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.ClearCache](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Özelleştirilmiş yazı tipi dosyalarını içeren klasörleri tanımlayın.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Belirtilen klasörlerden özelleştirilmiş yazı tiplerini yükleyin.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render edin/ dışa aktarın (ör. PDF, görseller veya diğer biçimler).
presentation.Save("output.pdf", SaveFormat.Pdf);

// İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts] yazı tipi arama yollarına ek klasörler ekler, ancak yazı tipi başlatma sırasını değiştirmez. Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/) üzerinden yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**
Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) yöntemini sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu C# kodu, [GetFontFolders](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/getfontfolders/) yönteminin nasıl kullanılacağını gösterir:

```c#
using Aspose.Slides;

// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleri olan klasörlerdir.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Sunumda Kullanılan Özel Yazı Tiplerini Belirtme**
Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirlemenize olanak tanıyan [DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğini sağlar.

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
    // Sunum üzerinde çalışın
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerinden gelen yazı tipleri sunumda kullanılabilir
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**
Aspose.Slides, harici yazı tiplerini ikili veriden yüklemenizi sağlayan [LoadExternalFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) yöntemini sunar.

Bu C# kodu, bayt dizisi ile yazı tipi yükleme sürecini gösterir: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // sunum ömrü boyunca dış yazı tipi yüklendi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**  
Evet. Bağlantılı yazı tipleri, işlemci tarafından tüm dışa aktarım formatlarında kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**  
Hayır. Bir yazı tipini işleme için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyası içinde taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/net/embedded-font/) kullanmalısınız.

**Bir özel yazı tipinde belirli glifler eksik olduğunda geri dönüş (fallback) davranışını kontrol edebilir miyim?**  
Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [yazı tipi ikamesi](/slides/tr/net/font-substitution/), [değiştirme kuralları](/slides/tr/net/font-replacement/) ve [geri dönüş setlerini](/slides/tr/net/fallback-font/) yapılandırabilirsiniz.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurulum yapmadan kullanabilir miyim?**  
Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

> **Linux/Docker için Not**: `FontsLoader.LoadExternalFonts` yöntemi çağrılırken, `directories` dizisindeki her girişin var olan bir klasöre boş olmayan bir yol içerdiğinden emin olun. Yazı tipi yolunu oluşturmak için kullanılan bir ortam değişkeni tanımsız veya boş ise, Aspose.Slides boş değeri tam bir yol olarak çözmeye çalışabilir ve bu da `System.ArgumentException` hatasına yol açar.

**Lisanslama konusunda ne durum? Herhangi bir özel yazı tipini sınırlama olmadan gömebilir miyim?**  
Yazı tipi lisans uyumluluğundan siz sorumlusunuz. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımını yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.