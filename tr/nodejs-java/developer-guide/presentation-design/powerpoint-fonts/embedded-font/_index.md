---
title: JavaScript'te Sunumlarda Yazı Tipi Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/nodejs-java/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint'te gömülü yazı tiplerini yönetin. Yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın; metin görünümünü koruyun ve dosya boyutunu azaltın."
---
## **Giriş**

Yazı tiplerini gömmek, yazı tipi verilerini bir PowerPoint sunumunun içine depolar. Görüntüleyici gömülü yazı tiplerini desteklediğinde, hedef sistemde yüklü olmasalar bile metni bu yazı tipleriyle görüntüleyebilir. Bu, satır sonlarını, metin aralığını ve slayt düzenini korumaya yardımcı olur.

Aspose.Slides for Node.js via Java, [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/) sınıfı aracılığıyla gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak sağlar; bu sınıf [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getfontsmanager/) yönteminin döndürdüğü sınıftır. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verisinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, yazı tipi verisinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömmeyi izin verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Bir sunumda depolanan yazı tiplerini listelemek için [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) kullanın. Birini kaldırmak için, listeden bir yazı tipini [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/) metoduna aktarın ve ardından sunumu kaydedin.

Aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Bir gömülü yazı tipini kaldırmak, depolanan yazı tipi verisini siler; metne atanmış yazı tipini değiştirmez. Yazı tipi hedef sistemde yüklüyse metin hâlâ onu kullanabilir. Aksi takdirde, render işlemi [font substitution](/slides/tr/nodejs-java/font-substitution/) gerektirebilir ve bu da düzeni etkileyebilir.

## **Yazı Tipi Verisini ve Gömme İzinlerini İncele**

Yazı tiplerini gömmeden önce incelemek için [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/) sınıfını kullanın. Sunumda kullanılan yazı tiplerini almak için [FontsManager.getFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) metodunu çağırın. Her bir yazı tipi için bir [FontData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontdata/) nesnesi ve gereken [FontStyleType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontstyletype/) değerini [FontsManager.getFontBytes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) metoduna aktarın. Metod, ilgili yazı tipi stilinin ikili verisini döndürür; istenen yazı tipi veya stil bulunamazsa `null` döner. `null` sonucu [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) metoduna gönderilmemelidir, çünkü bu metod bir bayt dizisi gerektirir. Node.js'te, döndürülen JavaScript dizisini `java.newArray` ile bir Java bayt dizisine dönüştürüp `getFontEmbeddingLevel` metoduna aktarın.

[EmbeddingLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/embeddinglevel/) yazı tipinde depolanan gömme kısıtlamalarını bir bayrak kümesi olarak raporlar:

- `Installable` gömme ve başka bir sistemde kalıcı kurulum izni verir; bu, yazı tipi lisansına bağlıdır.
- `Restricted` gömme izni vermez; yalnızca kullanım-izin bayrağı olarak tek başına olduğunda, yazı tipinin yasal sahibinden izin alınması gerekir.
- `PreviewPrint` görüntüleme ve yazdırma için geçici kullanım izni verir; yazı tipini içeren belge yalnızca okuma iznine sahip olmalıdır.
- `Editable` geçici kullanım izni verir ve belgenin düzenlenip kaydedilebilmesini sağlar.
- `NoSubsetting` ek bir kısıtlamadır; yalnızca bir karakter alt kümesinin gömülmesini yasaklar. Bu bayrak mevcutsa tüm karakterler gömülmelidir.
- `BitmapOnly` ek bir kısıtlamadır; yalnızca bitmap vuruşlarının gömülmesine izin verir, kontur verisi gömülmez. Yazı tipinde bitmap vuruş yoksa gömülemez.

İlk dört değer kullanım iznini tanımlar, `NoSubsetting` ve `BitmapOnly` ise onlarla birleştirilebilir. Modifikatörleri bit düzeyinde işlemlerle kontrol edin. `Installable` sıfır olduğu için, kullanım-izin bitlerini maskeleyin ve sonucu `Installable` ile karşılaştırın; bayrak olarak kontrol etmeyin. Güncel yazı tipleri en fazla bir kullanım-izin biti ayarlamalıdır. Birden fazla izin biti ayarlayan eski yazı tipleriyle uyumluluk için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `getFonts` tarafından döndürülen her bir yazı tipi için normal, kalın, italik ve kalın-italik verilerini denetler. Kullanılamayan stilleri, kısıtlı yazı tiplerini, yalnızca bitmap olanları, önizleme ve yazdırma ile sınırlı olanları (çıktı hâlâ düzenlenebilir olduğundan) ve zaten gömülü olanları atlar. Kullanılabilir bir stil `NoSubsetting` içeriyorsa, o yazı tipi ailesi için tüm karakterler gömülür.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu inceleme, her bir yazı tipi dosyasında kodlanmış kısıtlamaları raporlar. Lisans vermez, yazı tipini yasal olarak elde ettiğinizi kanıtlamaz ve gömülü bir kopyayı dağıtmadan önce yazı tipi lisans sözleşmesini kontrol etmenizi yerine geçmez.

## **Gömülü Yazı Tipi Ekle**

Bir yazı tipini gömmek için [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) kullanın. Aşırı yüklemeleri, bir [FontData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontdata/) nesnesi ya da yazı tipi verisini içeren bir bayt dizisini kabul eder. [EmbedFontCharacters](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/embedfontcharacters/) hangi karakterlerin dahil edileceğini kontrol eder:

- `All` yazı tipindeki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin girmesi gerektiğinde bu seçeneği kullanın.
- `OnlyUsed` sadece sunumda kullanılan karakterleri gömer, böylece dosya boyutu azalır. Öncelikle görüntülenmesi amaçlanan tamamlanmış bir sunum için bu seçeneği seçin.

Aşağıdaki örnek, `Fonts.pptx` içinde kullanılan yazı tiplerini almak için [FontsManager.getFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) kullanır ve henüz gömülmemiş olanları gömer. Eklenecek yazı tiplerinin kodu çalıştıran makinede mevcut olması gerekir. Mevcut gömülü yazı tipleri mevcut karakter setlerini korur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gömülü Yazı Tiplerini Sıkıştır**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compress/compressembeddedfonts/) kullanılmayan karakterleri kaldırarak gömülü yazı tipi verisini azaltır. Zaten gömülü olan yazı tipleri üzerinde çalışır, bu nedenle boyut küçülmesi sunumun ne kadar kullanılmayan yazı tipi verisi içerdiğine bağlıdır.

İşte aşağıdaki örnek, `EmbeddedFonts.pptx` içindeki yazı tiplerini sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alıcıların daha sonra metin eklemesi gerekebileceği durumlar için orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, başlangıçta tüm karakterleri gömmüş olsanız bile gömülü yazı tipinde artık mevcut değildir.

## **SSS**

**Gömülü bir yazı tipinin render sırasında hâlâ değiştirilip değiştirilmeyeceğini nasıl kontrol edebilirim?**

Sunumu render ettiğiniz ortamda [FontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) metodunu çağırarak Aspose.Slides'in hangi yazı tiplerini değiştireceğini görebilirsiniz. Ayrıca [font substitution](/slides/tr/nodejs-java/font-substitution/) ayarlarını ve [font fallback](/slides/tr/nodejs-java/fallback-font/) kurallarını kontrol edin. Fallback, eksik karakterleri ele alır; bu yüzden bir yazı tipini gömmek, o yazı tipinin içinde bulunmayan karakterleri çözmez.

**Arial ve Calibri gibi yaygın yazı tiplerini gömmeli miyim?**

Kararı hedef ortama göre verin. Gerekli yazı tipleri, sunumu açan veya render eden her makinede mevcutsa, gömmek gereksiz dosya boyutu ekleyebilir. Alıcıların veya sunucuların bu yazı tiplerine sahip olmama ihtimali varsa, lisansları izin veriyorsa gömmek istenen görünümü korumaya yardımcı olur.