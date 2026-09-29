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
description: "Aspose.Slides for Java ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek, sunumlarınızı her cihazda net ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, görüntüler ve diğer desteklenen formatlara dışa aktarıldığında kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini render için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde depolanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı tipi ailelerine referans verebilir. Bu eşlemeler yalnızca yazı tipi adlarını depolar ancak yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/java/script-specific-font-mappings/) adresine bakın ve aşağıdaki yükleme seçeneklerini kullanarak referans verilen yazı tiplerini tutarlı render için kullanılabilir hâle getirin.

{{% alert color="info" title="Note" %}}
Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bakınız [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) yazı tipleri. Bakınız [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarım çıktısını etkiler; böylece oluşan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel klasörlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#clearCache--) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```java
import com.aspose.slides.*;

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktar (örn., PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yazı tipi arama yollarına ek klasörler ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri bu sırayla başlatılır:
1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, yazı tipi klasörlerini bulmanızı sağlayan [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) yöntemini sunar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) kullanımını gösterir:

```java
import com.aspose.slides.*;

// Bu satır, yazı tipi dosyalarının arandığı klasörleri gösterir.
// Bunlar, LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Sunumda Kullanılan Özel Yazı Tiplerini Belirtme**

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
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunuma kullanılabilir
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden dış yazı tiplerini yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu Java kodu, bayt dizisi ile yazı tipi yükleme sürecini göstermektedir:

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
        // sunum ömrü boyunca yüklenen harici yazı tipi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?

Evet. Bağlı yazı tipleri, renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

### Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?

Hayır. Bir yazı tipini render için kaydetmek, onu PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasında bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/java/embedded-font/) kullanmalısınız.

### Bir özel yazı tipinde bazı glifler eksik olduğunda geri dönüş (fallback) davranışını kontrol edebilir miyim?

Evet. [Yazı tipi ikamesi](/slides/tr/java/font-substitution/), [değiştirme kuralları](/slides/tr/java/font-replacement/) ve [geri dönüş kümeleri](/slides/tr/java/fallback-font/) yapılandırarak, istenen glif eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak belirleyebilirsiniz.

### Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurmadan kullanabilir miyim?

Kısmen. Aspose.Slides, yazı tiplerini kendi klasörlerinizden veya bayt dizilerinden kurulum yapmadan kullanabilir, ancak Java'nın yazı tipi desteği görüntü içinde en az bir kurulu yazı tipine ihtiyaç duyar. Bir yazı tipi bulunmadığında, yükleme "Fontconfig head is null, check your fonts or fonts configuration" hatasıyla başarısız olur. Bakınız [Yazı Tiplerini Dağıtma](/slides/tr/java/deploy-fonts/).

### Lisanslama konusunda ne? Herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?

Yazı tipi lisansına uyumdan siz sorumlusunuz. Şartlar farklılık gösterir; bazı lisanslar gömme ya da ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin son kullanıcı lisans sözleşmesini (EULA) inceleyin.