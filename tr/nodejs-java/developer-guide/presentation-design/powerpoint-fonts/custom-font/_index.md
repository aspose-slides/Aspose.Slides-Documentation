---
title: JavaScript'te PowerPoint Yazı Tiplerini Özelleştirme
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js üzerinden Java ile PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızı her cihazda keskin ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, özel yazı tiplerini işletim sistemine kurmadan sunumlarda kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge‑seviyesi yazı tipi kaynakları aracılığıyla belirli bir sunum için sağlayabilir veya dış yazı tiplerini doğrudan ikili veri üzerinden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya PDF, görüntüler ve diğer desteklenen formatlara dışa aktarıldığında kullanılır. Bu, farklı ortamlar arasında sunum çıktısının tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerinin nasıl inceleneceğini ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğinin nasıl temizleneceğini açıklar.

Render için özel yazı tiplerinin kaydedilmesi, bir PPTX dosyasına gömülmesinden ayrı bir işlemdir. Bir yazı tipinin sunumun içinde saklanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 
Aspose Slides, bu yazı tiplerini aşağıdaki [loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenizi sağlar:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize izin verir. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkiler; böylece oluşan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırarak bu klasörlerden yazı tiplerini yükleyin.
3. Sunumu yükleyin ve render/​dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği yazı tipi yükleme sürecini gösterir:

```js
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.
{{%/alert %}}

## **Özel Yazı Tipi Klasörünü Alma**
Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [getFontFolders](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) yöntemini sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu JavaScript kodu, [getFontFolders](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) nasıl kullanılacağını gösterir:

```javascript
// Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
// Bunlar LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Sunumda Kullanılan Özel Yazı Tiplerini Belirleme**
Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirlemenize olanak tanıyan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) özelliğini sunar.

Bu JavaScript kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörleri ve alt klasörlerindeki yazı tipleri sunum için kullanılabilir
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, dış yazı tiplerini ikili veri üzerinden yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu JavaScript kodu, bayt dizisi ile yazı tipi yükleme sürecini gösterir:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // sunum süresi boyunca dış yazı tipi yüklendi
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?**

Evet. Bağlantılı yazı tipleri, render tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri otomatik olarak oluşturulan PPTX dosyasına gömülür mü?**

Hayır. Render için bir yazı tipini kaydetmek, onu bir PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyası içinde taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/nodejs-java/embedded-font/) kullanmanız gerekir.

**Özel bir yazı tipinde belirli glifler eksik olduğunda yedekleme davranışını kontrol edebilir miyim?**

Evet. [Yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/), [değiştirme kuralları](/slides/tr/nodejs-java/font-replacement/) ve [yedekleme setleri](/slides/tr/nodejs-java/fallback-font/) yapılandırarak, istenen glif bulunamadığında hangi yazı tipinin kullanılacağını tam olarak tanımlayabilirsiniz.

**Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?**

Evet. Kendi yazı tipi klasörlerinize işaret ederek veya bayt dizilerinden yazı tiplerini yükleyerek bunu yapabilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine herhangi bir bağımlılığı ortadan kaldırır.

**Lisanslama konusunda ne söyleyebilirsiniz—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**

Yazı tipi lisanslama uyumluluğu sizin sorumluluğunuzdadır. Şartlar değişiklik gösterebilir; bazı lisanslar gömme veya ticari kullanımı yasaklayabilir. Çıktıları dağıtmadan önce her zaman ilgili yazı tipinin EULA'sını inceleyin.