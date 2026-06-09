---
title: Android'de PowerPoint Yazı Tiplerini Özelleştirin
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
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PowerPoint slaytlarında yazı tiplerini özelleştirin; böylece sunumlarınız her cihazda keskin ve tutarlı olur."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tipleri kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum PDF, resim ve diğer desteklenen formatlara render edildiğinde veya dışa aktarıldığında kullanılır. Bu sayede çıktı, farklı ortamlar arasında tutarlı kalır. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Render için özel yazı tiplerinin kaydedilmesi, bir PPTX dosyasına gömülmesinden ayrı bir işlemdir. Yazı tipinin sunumun içinde saklanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 

Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenizi sağlar:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, sistemde kurulum yapmadan bir sunumda kullanılan yazı tiplerini yüklemenizi sağlar. Bu, PDF, resim ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasörü belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metodunu çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsLoader#clearCache--) metodunu çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini göstermektedir:

```java
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktar (örn. PDF, resimler veya diğer formatlar).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Alma**
Aspose.Slides, yazı tipi klasörlerini bulmanızı sağlayan [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) metodunu sunar. Bu metod, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu Java kodu, [getFontFolders](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) kullanımını gösterir:

```java
// Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
// Bunlar, LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleridir.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Bir Sunumla Kullanılan Özel Yazı Tiplerini Belirtme**
Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirtmenizi sağlayan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğini sunar.

Bu Java kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

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

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metodunu sunar.

Bu Java kodu, bayt dizisiyle yazı tipi yükleme sürecini gösterir:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        //        sunum ömrü süresince harici yazı tipi yüklendi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlarda (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?**  

Evet. Bağlı yazı tipleri, renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**  

Hayır. Render için bir yazı tipini kaydetmek, onu PPTX içine gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/androidjava/embedded-font/) kullanmanız gerekir.

**Özel bir yazı tipinde eksik glifler olduğunda yedekleme davranışını kontrol edebilir miyim?**  

Evet. [Yazı tipi ikamesi](/slides/tr/androidjava/font-substitution/), [değiştirme kuralları](/slides/tr/androidjava/font-replacement/) ve [yedekleme setleri](/slides/tr/androidjava/fallback-font/) yapılandırarak isteğe bağlı glif eksik olduğunda hangi yazı tipinin kullanılacağını kesin olarak tanımlayabilirsiniz.

**Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?**  

Evet. Kendi yazı tipi klasörlerinize işaret ederek veya bayt dizilerinden yazı tipleri yükleyerek konteyner görüntüsündeki sistem yazı tipi dizinlerine bağımlılığı ortadan kaldırabilirsiniz.

**Lisanslama hakkında—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**  

Yazı tipi lisans uyumluluğundan siz sorumlusunuz. Şartlar farklılık gösterir; bazı lisanslar gömme ya da ticari kullanımını yasaklayabilir. Çıktıları dağıtmadan önce yazı tipinin EULA'sını her zaman inceleyin.