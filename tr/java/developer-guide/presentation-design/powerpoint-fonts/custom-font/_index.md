---
title: Java'da PowerPoint Yazı Tiplerini Özelleştirin
linktitle: Özel Yazı Tipi
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

Aspose.Slides, işletim sistemine yüklemeden sunularda özel yazı tiplerini kullanmanıza olanak sağlar. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde font kaynakları aracılığıyla belirli bir sunum için font sağlayabilir veya dış fontları doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen fontlar, bir sunum oluşturulurken veya dışa aktarılırken, örneğin PDF, görüntüler ve diğer desteklenen biçimlere, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasını sağlar. Makale ayrıca Aspose.Slides tarafından kullanılan font klasörlerinin nasıl inceleneceğini ve dış fontlarla çalıştıktan sonra font önbelleğinin nasıl temizleneceğini açıklar.

Özel fontların oluşturma için kaydedilmesi, bir PPTX dosyasına gömülmesinden ayrı bir işlemdir. Bir fontun sunumun içinde saklanması gerekiyorsa, font gömme özelliklerini açıkça kullanın.

Bir sunum teması, farklı yazı sistemleri için çeşitli yazı tipi ailelerine referans verebilir. Bu eşlemeler yalnızca font adlarını saklar, ancak font dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/java/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak referans verilen fontların tutarlı oluşturma için kullanılabilir olmasını sağlayın.

{{% alert color="info" title="Not" %}}

Aspose Slides, bu fontları [loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize izin verir:

* TrueType (.ttf) ve TrueType Collection (.ttc) fontları. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) fontları. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Fontları Yükle**

Aspose.Slides, bir sunumda kullanılan fontları sisteme kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen biçimler gibi dışa aktarma çıktısını etkiler; böylece oluşturulan belgeler farklı ortamlar arasında tutarlı görünür. Fontlar özel dizinlerden yüklenir.

1. Font dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden font yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.
3. Sunumu yükleyin ve oluşturun/dışa aktarın.
4. Font önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader#clearCache--) yöntemini çağırın.

```java
import com.aspose.slides.*;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Yüklenen yazı tiplerini kullanarak sunumu oluşturun/dışa aktarın (ör. PDF, görüntüler veya diğer biçimler).
Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Yüklenen yazı tiplerini kullanarak sunumu oluşturun/dışa aktarın (ör. PDF, görüntüler veya diğer biçimler).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Not" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ek klasörleri font arama yollarına ekler, ancak font başlatma sırasını değiştirmez.
Fontlar şu sırayla başlatılır:

1. Varsayılan işletim sistemi font yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Font Klasörlerini Al**

Aspose.Slides, font klasörlerini bulmanıza olanak tanıyan [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) yöntemini sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem font klasörlerini döndürür.

```java
import com.aspose.slides.*;

// Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemi aracılığıyla eklenen ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Bir Sunumda Kullanılan Özel Fontları Belirleyin**

Aspose.Slides, sunumla birlikte kullanılacak dış fontları belirtmenize olanak tanıyan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar.

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
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerindeki fontlar sunuma kullanılabilir
} finally {
    if (pres != null) pres.dispose();
}
```

## **Fontları Dışarıdan Yönetmek**

Aspose.Slides, ikili veriden dış fontları yüklemenize olanak tanıyan [loadExternalFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

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
        // sunum ömrü boyunca dış font yüklendi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **SSS**

### Özel fontlar tüm biçimlere (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?

Evet. Bağlı fontlar, oluşturucu tarafından tüm dışa aktarım biçimlerinde kullanılır.

### Özel fontlar otomatik olarak ortaya çıkan PPTX dosyasına gömülür mü?

Hayır. Bir fontu oluşturma için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Fontun sunum dosyasının içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/java/embedded-font/) kullanmalısınız.

### Bir özel font belirli gliflere sahip olmadığında geri dönüş (fallback) davranışını kontrol edebilir miyim?

Evet. İstenen glif eksik olduğunda hangi fontun kullanılacağını tam olarak tanımlamak için [font ikamesi](/slides/tr/java/font-substitution/), [yerine koyma kuralları](/slides/tr/java/font-replacement/) ve [geri dönüş setleri](/slides/tr/java/fallback-font/) yapılandırabilirsiniz.

### Fontları Linux/Docker konteynerlerinde sistem çapında kurmadan kullanabilir miyim?

Evet. Kendi font klasörlerinize işaret ederek veya fontları bayt dizilerinden yükleyerek. Bu, konteyner imajındaki sistem font dizinlerine herhangi bir bağımlılığı ortadan kaldırır.

### Lisanslama konusunda ne yapılmalı—herhangi bir özel fontu kısıtlamasız gömebilir miyim?

Font lisans uyumluluğundan siz sorumlusunuz. Koşullar değişiklik gösterir; bazı lisanslar gömülmesini veya ticari kullanımını yasaklar. Çıktıları dağıtmadan önce fontun EULA'sını mutlaka gözden geçirin.