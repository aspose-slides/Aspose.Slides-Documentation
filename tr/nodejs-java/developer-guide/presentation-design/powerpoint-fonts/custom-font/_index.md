---
title: JavaScript ile PowerPoint Yazı Tiplerini Özelleştir
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
description: "JavaScript ve Aspose.Slides for Node.js kullanarak Java üzerinden PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızın her cihazda keskin ve tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine yüklemeden sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge düzeyindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum PDF, resimler ve diğer desteklenen biçimlere dışa aktarılırken veya render edilirken kullanılır. Bu, farklı ortamlar arasında sunum çıktısının tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Render için özel yazı tiplerini kaydetmek, bir PPTX dosyasına yazı tiplerini gömmekten ayrı bir işlemdir. Bir yazı tipinin sunumun içinde saklanması gerekiyorsa, gömme özelliklerini açıkça kullanın.

Bir sunum teması, bireysel yazı sistemleri için farklı yazı tipi ailelerine referans verebilir. Bu eşlemeler yalnızca yazı tipi adlarını saklar, ancak yazı tipi dosyalarını yüklemez veya kurmaz. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/nodejs-java/script-specific-font-mappings/) bölümüne bakın ve aşağıdaki yükleme seçeneklerini kullanarak referans verilen yazı tiplerini tutarlı render için kullanılabilir hale getirin.

{{% alert color="info" title="Not" %}}

Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize izin verir:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükle**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize izin verir. Bu, PDF, resimler ve diğer desteklenen biçimler gibi dışa aktarım çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.  
2. Statik [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) yöntemini çağırarak bu klasörlerden yazı tiplerini yükleyin.  
3. Sunumu yükleyin ve render/​dışa aktarın.  
4. Yazı tipi önbelleğini temizlemek için [FontsLoader.clearCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/clearcache/) yöntemini çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Yüklenen yazı tiplerini kullanarak sunumu render/ dışa aktar (ör. PDF, resimler veya diğer formatlar).
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Not" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ek klasörleri yazı tipi arama yollarına ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri şu sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörünü Al**

Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [getFontFolders](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) yöntemini sağlar. Bu yöntem, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu JavaScript kodu, [getFontFolders](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) yönteminin nasıl kullanılacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Bu satır, yazı tipi dosyalarının aranacağı klasörleri çıktılar.
// Bunlar LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleridir.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Sunumla Kullanılacak Özel Yazı Tiplerini Belirt**

Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirtmenize olanak tanıyan [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) özelliğini sunar.

Bu JavaScript kodu, [setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) özelliğinin nasıl kullanılacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Sunumla çalış
    // CustomFont1, CustomFont2 ve assets\fonts & global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri sunum için kullanılabilir
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yazı Tiplerini Dışarıdan Yönet**

Aspose.Slides, dış yazı tiplerini ikili veriden yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yöntemini sunar.

Bu JavaScript kodu, bayt dizisi üzerinden yazı tipi yükleme sürecini gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // sunum ömrü boyunca dış yazı tipi yüklendi
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **SSS**

### Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarımı etkiler mi?

Evet. Bağlı yazı tipleri, renderlayıcı tarafından tüm dışa aktarım formatlarında kullanılır.

### Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?

Hayır. Bir yazı tipini render için kaydetmek, onu PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasının içinde taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/nodejs-java/embedded-font/) kullanmanız gerekir.

### Özel bir yazı tipinde bazı glifler eksik olduğunda geri dönüş davranışını kontrol edebilir miyim?

Evet. [Yazı tipi ikamesi](/slides/tr/nodejs-java/font-substitution/), [değiştirme kuralları](/slides/tr/nodejs-java/font-replacement/) ve [geri dönüş setleri](/slides/tr/nodejs-java/fallback-font/) yapılandırarak istenen glif eksik olduğunda tam olarak hangi yazı tipinin kullanılacağını belirleyebilirsiniz.

### Linux/Docker konteynerlerinde yazı tiplerini sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner görüntüsündeki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama hakkında—herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?

Yazı tipi lisans uyumluluğundan siz sorumlusunuz. Şartlar değişir; bazı lisanslar gömme veya ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA’sını gözden geçirin.