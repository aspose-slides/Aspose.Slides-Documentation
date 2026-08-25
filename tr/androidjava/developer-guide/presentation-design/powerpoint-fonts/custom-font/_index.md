---
title: "Android'de PowerPoint Yazı Tiplerini Özelleştirme"
linktitle: "Özel Yazı Tipi"
type: docs
weight: 20
url: /tr/androidjava/custom-font/
keywords:
  - "yazı tipi"
  - "özel yazı tipi"
  - "harici yazı tipi"
  - "yazı tipi yükle"
  - "yazı tiplerini yönet"
  - "yazı tipi klasörü"
  - "PowerPoint"
  - "OpenDocument"
  - "sunum"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Android ile Java kullanarak PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, özel yazı tiplerini işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum renderlendiğinde veya dışa aktarıldığında, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı olmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini renderleme için kaydetmek, yazı tiplerini bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler yalnızca yazı tipi adlarını saklar, ancak yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/androidjava/script-specific-font-mappings/) adresine bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerini tutarlı bir renderleme için kullanılabilir hâle getirin.

{{% alert color="info" title="Not" %}}

Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.
3. Sunumu yükleyin ve render/ dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsLoader#clearCache--) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```java
import com.aspose.slides.*;

// Özel yazı tipi dosyalarını içeren klasörleri tanımla.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktar (örn. PDF, görüntüler veya diğer formatlar) .
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandığında yazı tipi önbelleğini temizle.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Not" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) font arama yollarına ek klasörler ekler, ancak font başlatma sırasını değiştirmez.
Fontlar aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/) üzerinden yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, font klasörlerini bulmanızı sağlayan [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metodunu sunar. Bu metot, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem font klasörlerini döndürür.

Aşağıdaki Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) yönteminin nasıl kullanılacağını gösterir:

```java
import com.aspose.slides.*;

// Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
// Bunlar LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirtmenizi sağlayan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar.

Aşağıdaki Java kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

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
    // Sunum üzerinde çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri sunuma kullanılabilir
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden harici yazı tiplerini yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metodunu sunar.

Aşağıdaki Java kodu, bayt dizisiyle yazı tipi yükleme sürecini göstermektedir:

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
        // sunum ömrü boyunca harici yazı tipi yüklendi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **SSS**

### Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?

Evet. Bağlı yazı tipleri, tüm dışa aktarma formatlarında renderlayıcı tarafından kullanılır.

### Özel yazı tipleri otomatik olarak oluşan PPTX dosyasına gömülür mü?

Hayır. Bir yazı tipini renderleme için kaydetmek, onu bir PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasında bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/androidjava/embedded-font/) kullanmalısınız.

### Özel bir yazı tipinde belirli glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?

Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak belirlemek için [font substitution](/slides/tr/androidjava/font-substitution/), [replacement rules](/slides/tr/androidjava/font-replacement/) ve [fallback sets](/slides/tr/androidjava/fallback-font/) yapılandırabilirsiniz.

### Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinize yönlendirin veya yazı tiplerini bayt dizilerinden yükleyin. Bu, konteyner görüntüsünde sistem font dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama konusunda ne? Herhangi bir özel yazı tipini sınırlama olmadan gömebilir miyim?

Yazı tipi lisansına uyumdan siz sorumlusunuz. Şartlar değişiklik gösterebilir; bazı lisanslar gömme veya ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.