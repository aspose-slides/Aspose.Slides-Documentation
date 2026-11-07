---
title: .NET'te PowerPoint Yazı Tiplerini Özelleştirme
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/net/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- dış yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine yüklemeden sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyindeki font kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum renderlandığında veya dışa aktarıldığında, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan font klasörlerini nasıl inceleyeceğinizi ve harici yazı tipleriyle çalıştıktan sonra font önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini render için kaydetmek, bir PPTX dosyasına yazı tiplerini gömmekten ayrı bir işlemdir. Bir yazı tipinin doğrudan sunum içinde depolanması gerekiyorsa, font gömme özelliklerini açıkça kullanın.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı ailelerine başvurabilir. Bu eşlemeler font adlarını saklar ancak font dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Betik‑Özelliğine Sahip Tema Yazı Tipleri](/slides/tr/net/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan fontların tutarlı render için kullanılabilir olmasını sağlayın.

{{% alert color="info" title="Note" %}}

Aspose Slides, bu yazı tiplerini [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sisteme yüklemeden yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktılarını etkiler; böylece elde edilen belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden fontları yüklemek için statik [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) yöntemini çağırarak font önbelleğini temizleyin.

Aşağıdaki kod örneği, font yükleme sürecini gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktarın (örn. PDF, görüntüler veya diğer formatlar).
presentation.Save("output.pdf", SaveFormat.Pdf);

// İşlem tamamlandıktan sonra font önbelleğini temizleyin.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) , font arama yollarına ek klasörler ekler, ancak font başlatma sırasını değiştirmez.  
Fontlar bu sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.
1. [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, font klasörlerini bulmanızı sağlayan [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) yöntemini sunar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem font klasörlerini döndürür.

Bu C# kodu, [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) kullanımını gösterir:

```c#
using Aspose.Slides;

// Bu satır, yazı tipi dosyaları için kontrol edilen klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem font klasörleridir.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Sunumda Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla kullanılacak harici yazı tiplerini belirtmenizi sağlayan [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğini sunar.

Bu C# kodu, [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) özelliğinin nasıl kullanılacağını gösterir:

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
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ile alt klasörlerindeki fontlar sunuma kullanılabilir
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden harici yazı tiplerini yüklemenizi sağlayan [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) yöntemini sunar.

Bu C# kodu, byte dizisiyle font yükleme sürecini gösterir:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // sunum süresi boyunca yüklenen harici yazı tipi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Dışa aktarma sırasında gömülü fontu kaldırmadan eşleşen kayıtlı bir fontun öncelik almasını sağlamak için [Kayıtlı Yazı Tiplerini Gömülü Yazı Tiplerine Üstün Tut](/slides/tr/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 veya daha yeni) bölümüne bakın.

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**  
Evet. Bağlı fontlar, render tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri oluşturulan PPTX dosyasına otomatik olarak gömülür mü?**  
Hayır. Bir fontu render için kaydetmek, PPTX e gömmekle aynı şey değildir. Eğer fontun sunum dosyasına dahil edilmesi gerekiyorsa, açıkça [gömme özelliklerini](/slides/tr/net/embedded-font/) kullanmalısınız.

**Bir özel yazı tipinde belirli glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?**  
Evet. İstenen glif eksik olduğunda hangi fontun kullanılacağını kesin olarak tanımlamak için [yazı tipi ikamesi](/slides/tr/net/font-substitution/), [yerine koyma kuralları](/slides/tr/net/font-replacement/) ve [geri dönüş setleri](/slides/tr/net/fallback-font/) yapılandırabilirsiniz.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde yüklemeden kullanabilir miyim?**  
Evet. Kendi font klasörlerinize işaret edebilir veya fontları byte dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem font dizinlerine olan bağımlılığı ortadan kaldırır.

> **Linux/Docker için Not**: `FontsLoader.LoadExternalFonts` yöntemini çağırdığınızda, `directories` dizisindeki her öğenin mevcut bir klasöre ait boş olmayan bir yol içerdiğinden emin olun. Bir font yolunu oluşturmak için kullanılan ortam değişkeni tanımsız veya boş ise, Aspose.Slides bu boş değeri tam bir yol olarak çözümlemeye çalışabilir ve bu da `System.ArgumentException` hatasına yol açar.

**Lisanslama hakkında ne söyleyebilirsiniz—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**  
Yazı tipi lisanslama uyumluluğu sizin sorumluluğunuzdadır. Şartlar farklılık gösterir; bazı lisanslar gömmeyi veya ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.