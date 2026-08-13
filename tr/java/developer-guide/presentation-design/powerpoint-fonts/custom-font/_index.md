---
title: "Java'da PowerPoint Yazı Tiplerini Özelleştirme"
linktitle: "Özel Yazı Tipi"
type: docs
weight: 20
url: /tr/java/custom-font/
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
  - Java
  - Aspose.Slides
description: "Java için Aspose.Slides ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum oluşturulurken veya dışa aktarılırken, örneğin PDF, görüntüler ve diğer desteklenen biçimlere dönüştürülürken kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini oluşturma için kaydetmek, yazı tiplerini bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin doğrudan sunum içinde depolanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="info" %}} 
Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Daha fazla bilgi için [TrueType](https://en.wikipedia.org/wiki/TrueType) sayfasına bakın.

* OpenType (.otf) yazı tipleri. Daha fazla bilgi için [OpenType](https://en.wikipedia.org/wiki/OpenType) sayfasına bakın.
{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurulum yapmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen biçimler gibi dışa aktarım çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya birden fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.
3. Sunumu yükleyin ve oluşturun/dışa aktarın.
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader#clearCache--) yöntemini çağırarak yazı tipi önbelleğini temizleyin.

Aşağıdaki kod örneği yazı tipi yükleme sürecini gösterir:

```java
import com.aspose.slides.*;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Yüklenen yazı tiplerini kullanarak sunumu oluşturun/dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yazı tipi arama yollarına ek klasörler ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Alma**

Aspose.Slides, yazı tipi klasörlerini bulmanızı sağlayan [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) yöntemini sunar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) yönteminin nasıl kullanılacağını gösterir:

```java
import com.aspose.slides.*;

// Bu satır, yazı tipi dosyalarının aranacağı klasörleri listeler.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirtmenizi sağlayan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar. 

Bu Java kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Sunum üzerinde çalışın
    // CustomFont1, CustomFont2 ve assets\fonts ile global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunuma kullanılabilir
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yazı Tiplerini Harici Olarak Yönetme**

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu Java kodu, bayt dizisi kullanarak yazı tipi yükleme sürecini gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // sunum süresi boyunca dış yazı tipi yüklendi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **SSS**

### Özel yazı tipleri tüm biçimlere (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?

Evet. Bağlantılı yazı tipleri, oluşturucu tarafından tüm dışa aktarma biçimlerinde kullanılır.

### Özel yazı tipleri otomatik olarak ortaya çıkan PPTX dosyasına gömülür mü?

Hayır. Bir yazı tipini oluşturma için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasında bulunmasını istiyorsanız, açık [gömme özelliklerini](/slides/tr/java/embedded-font/) kullanmalısınız.

### Bir özel yazı tipinde bazı glifler eksik olduğunda geri dönüş (fallback) davranışını kontrol edebilir miyim?

Evet. [Yazı tipi ikamesi](/slides/tr/java/font-substitution/), [değiştirme kuralları](/slides/tr/java/font-replacement/) ve [geri dönüş setleri](/slides/tr/java/fallback-font/) yapılandırarak istenen glif eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak tanımlayabilirsiniz.

### Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurulum yapmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinize yönlendirebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama nasıl—herhangi bir özel yazı tipini sınırlama olmadan gömebilir miyim?

Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişebilir; bazı lisanslar gömmeyi veya ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.