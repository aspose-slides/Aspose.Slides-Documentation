---
title: Android'de PowerPoint Yazı Tiplerini Özelleştirme
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java kullanarak PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine yüklemeden sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge seviyesindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum PDF, görüntüler ve diğer desteklenen biçimlere dışa aktarılırken veya işlenirken kullanılır. Bu, farklı ortamlar arasında sunum çıktısının tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini işleme kaydetmek, bir PPTX dosyasına gömülmesinden ayrı bir işlemdir. Bir yazı tipinin sunumun içinde depolanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

{{% alert color="info" %}} 
Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenizi sağlar:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, sistemde kurulum yapmadan bir sunumda kullanılan yazı tiplerini yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen biçimler gibi dışa aktarım çıktılarını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı dosyalarını içeren bir veya daha fazla klasör belirtin.  
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.  
3. Sunumu yükleyin ve render/dışa aktarın.  
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsLoader#clearCache--) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```java
import com.aspose.slides.*;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Yüklenen yazı tiplerini kullanarak sunumu işleyin/dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Not" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
2. [FontsLoader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Almak**
Aspose.Slides, yazı tipi klasörlerini bulmanıza izin veren [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) yöntemini sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) kullanımını göstermektedir:

```java
import com.aspose.slides.*;

// Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Bir Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**
Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirlemenizi sağlayan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar.

Bu Java kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

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
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ile alt klasörlerindeki yazı tipleri sunuma kullanılabilir
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemenize izin veren [loadExternalFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu Java kodu, bayt dizisi üzerinden yazı tipi yükleme sürecini göstermektedir:

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
        // sunum ömrü boyunca dış yazı tipi yüklendi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **SSS**

### Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?

Evet. Bağlantılı yazı tipleri, renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

### Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?

Hayır. Bir yazı tipini işleme kaydetmek, onu PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyası içinde taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/androidjava/embedded-font/) kullanmalısınız.

### Bir özel yazı tipi belirli gliflere sahip değilse geri dönüş davranışını kontrol edebilir miyim?

Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/), [değiştirme kuralları](/slides/tr/androidjava/font-replacement/) ve [geri dönüş setleri](/slides/tr/androidjava/fallback-font/) yapılandırabilirsiniz.

### Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama konusunda—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?

Yazı tipi lisans uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişkenlik gösterir; bazı lisanslar gömme veya ticari kullanım yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.