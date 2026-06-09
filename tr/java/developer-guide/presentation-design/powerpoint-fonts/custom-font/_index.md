---
title: Java'da PowerPoint Yazı Tiplerini Özelleştirme
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
description: "Aspose.Slides for Java ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızın her cihazda net ve tutarlı kalmasını sağlayın."
---
## **Overview**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyinde font kaynakları aracılığıyla belirli bir sunum için font sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum işlenirken veya dışa aktarılırken, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Özel yazı tiplerini işleme için kaydetmek, yazı tiplerini bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 

Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Daha fazla bilgi için [TrueType](https://en.wikipedia.org/wiki/TrueType) sayfasına bakın.

* OpenType (.otf) yazı tipleri. Daha fazla bilgi için [OpenType](https://en.wikipedia.org/wiki/OpenType) sayfasına bakın.

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize izin verir. Bu durum, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini çağırın.
3. Sunumu yükleyin ve işleyin/ dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader#clearCache--) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```java
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Yüklenen yazı tiplerini kullanarak sunumu işleyin/dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş bittiğinde yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) font arama yollarına ek klasörler ekler, ancak font başlatma sırasını değiştirmez.  
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) yöntemini sunar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--) kullanımını gösterir:

```java
// Bu satır, yazı tipi dosyalarının arandığı klasörleri verir.
// Bunlar, LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides, sunumla kullanılacak dış yazı tiplerini belirtmenizi sağlayan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar.  

Bu Java kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri sunuma açıktır
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Fonts Externally**

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu Java kodu, bayt dizisi üzerinden yazı tipi yükleme sürecini gösterir:

```java
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

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Evet. Bağlantılı yazı tipleri, renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

**Are custom fonts automatically embedded into the resulting PPTX?**

Hayır. Bir yazı tipini işleme için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/java/embedded-font/) kullanmalısınız.

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Evet. İstenen glif eksik olduğunda hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [font ikamesi](/slides/tr/java/font-substitution/), [değiştirme kuralları](/slides/tr/java/font-replacement/) ve [yedek setleri](/slides/tr/java/fallback-font/) yapılandırabilirsiniz.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Evet. Kendi yazı tipi klasörlerinize yönlendirebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

**What about licensing—can I embed any custom font without restrictions?**

Yazı tipi lisansına uyumluluktan siz sorumlusunuz. Şartlar farklılık gösterebilir; bazı lisanslar gömme veya ticari kullanımını yasaklayabilir. Çıktıları dağıtmadan önce her zaman yazı tipinin son kullanıcı lisans sözleşmesini (EULA) inceleyin.