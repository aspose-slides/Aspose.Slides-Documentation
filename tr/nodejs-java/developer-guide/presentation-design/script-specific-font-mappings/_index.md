---
title: "JavaScript'te Betik-Özgü Tema Yazı Tiplerini Yönetme"
linktitle: "Betik-Özgü Tema Yazı Tipleri"
type: docs
weight: 15
url: /tr/nodejs-java/script-specific-font-mappings/
keywords:
- betik-özgü yazı tipi
- tema yazı tipi eşlemesi
- çok dilli sunum
- yazı sistemi
- Kiril yazı tipi
- Arapça yazı tipi
- Japonca yazı tipi
- Gürcüce yazı tipi
- Thaana yazı tipi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint temalarında betik-özgü yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, çok dilli metnin hâlâ tema yazı tiplerini kullanarak bir koordineli yazı tipi şemasını takip etmesini ve Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer betikler için uygun yazı tiplerini kullanmasını sağlar.

Temanın [FontScheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) içinde genellikle başlıklar için kullanılan bir ana (major) yazı tipi koleksiyonu ve genellikle gövde metni için kullanılan bir yan (minor) yazı tipi koleksiyonu bulunur. Latin ve Doğu Asya yazı tipi ayarlarına ek olarak, her iki koleksiyon da [Fonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) sınıfı aracılığıyla yazı sistemi etiketlerinden yazı tipi aile adlarına eşlemeler sunar.

Bu makale, sunumun ana temasındaki bu eşlemeleri nasıl inceleyeceğinizi ve değiştireceğinizi ve değişikliklerin kaydedilip yeniden yükleme döngüsünde kalıcı olduğunu nasıl doğrulayacağınızı gösterir.

## **Betik Etiketlerini Anlama**

Betik yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 betik alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Betik etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, bireysel metin bölümlerine değil. Bir sunum, ana ve yan koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı betikler için eşlemeler atlayabilir.

## **Betik Yazı Tipi Eşlemelerine Erişme ve İnceleme**

Sunum seviyesindeki temaya erişmek için [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) kullanın. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontscheme/) yöntemleri iki [Fonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) koleksiyonunu döndürür.

Bir koleksiyondaki tüm eşlemeleri almak için [Fonts.getScriptFontMap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) çağırın. Tek bir yazı sistemini bulmak için, betik etiketiyle birlikte [Fonts.getScriptFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) çağırın. `getScriptFont`, ilgili koleksiyon istenen eşlemeyi tanımlamadığında `null` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

Eşleme oluşturmak veya mevcut yazı tipi ailesini değiştirmek için [Fonts.setScriptFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) kullanın. Bir eşlemeyi kaldırmak için [Fonts.removeScriptFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) kullanın.

Aşağıdaki uçtan uca örnek, mevcut tüm ana ve yan eşlemeleri okur, Japonca ana yazı tipini bulur, Kiril ana yazı tipini değiştirir, Thaana yan eşlemeyi kaldırır, sunumu kaydeder ve her iki değişikliği doğrulamak için yeniden açar. Kaldırma adımını başlangıç temasından bağımsız kılmak için örnek, Thaana eşlemesini yalnızca henüz tanımlı değilse oluşturur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Doğrulama, normal bir arama gibi aynı `null` davranışını kullanır: kaldırma kaydedildikten sonra, `getScriptFont("Thaa")` yan koleksiyon için `null` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayırma**

Betik‑özgü tema eşlemeleri yazı tipi seçimine katılır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş gibi farklı bir sorunu çözer:

| Mekanizma | Amaç | Tema eşlemesi değiştirildiğinde etkisi |
|---|---|---|
| Betik‑özgü tema yazı tipi eşlemesi | Bir yazı sistemi için ana veya yan tema yazı tipini seçer. | İlgili tema yazı tipini hâlâ kullanan metin, yeni eşlenen aileye çözümleyebilir. |
| Bir metin bölümüne açıkça atanan yazı tipi | Temaya dayanmak yerine o bölümde talep edilen yazı tipi ailesini sabitler. | Doğrudan biçimlendirme tema seçimini geçersiz kıldığından, bölüm değişmeden kalabilir. |
| Yazı tipi ikamesi | Talep edilen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında onu değiştirir. | Yazı tipi talep edildikten sonra devreye girer; temanın betik eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinin içermediği glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/nodejs-java/font-substitution/) ve [Fallback Fonts](/slides/tr/nodejs-java/fallback-font/) bölümlerine bakın.

[Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getmastertheme/) içinde bir eşlemenin değiştirilmesi yalnızca etkili biçimlendirmesi hâlâ o temaya bağlı olan içeriği etkiler. Metin, bir ana, düzen veya slayttan bir tema geçersiz kılmasını miras alabilir veya açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç sunum‑seviyesi eşlemeyi takip etmiyorsa bu seviyeleri inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getir ve Sonucu Doğrula**

Betik eşlemesi bir yazı tipi ailesi adını depolar; ilgili yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenen yazı tipi ortamda kurulu olmalı veya Aspose.Slides'e [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) veya [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) gibi özel bir kaynak aracılığıyla sağlanmalıdır. Mevcut yükleme seçenekleri için [Custom Fonts](/slides/tr/nodejs-java/custom-font/) bölümüne bakın.

Kayıtlı eşlemenin doğrulanması yalnızca tema tanımının korunduğunu onaylar. Yazı tipinin kullanılabilir olduğunu, tüm gerekli glifleri içerdiğini veya amaçlanan yerleşimi ürettiğini kanıtlamaz. Her gerekli yazı sistemi için temsilci bir metni görüntü veya PDF olarak render edip çıktıyı inceleyin. Bu, eksik yazı tiplerini, eksik glif kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki yerleşim değişikliklerini yakalar. Render ve dışa aktarım örnekleri için [Convert PowerPoint Presentations](/slides/tr/nodejs-java/convert-powerpoint/) bölümüne bakın.

## **SSS**

**Betik eşlenmediğinde `getScriptFont` ne döndürür?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) istenen betik eşlemesi o ana veya yan yazı tipi koleksiyonunda tanımlı olmadığında `null` döndürür.

**Betik zaten mevcut olduğunda `setScriptFont` ikinci bir eşleme ekler mi?**

Hayır. [Fonts.setScriptFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fonts/) eşleme eksik olduğunda oluşturur ve aynı betik etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Neden tema eşlemesinin değiştirilmesi bazı metinleri etkilemedi?**

Metin, açıkça atanmış bir yazı tipine sahip olabilir, bir geçersiz kılma aracılığıyla farklı bir temayı miras alabilir veya render sırasında ikame ya da geri dönüşten etkilenebilir. Sunum‑seviyesi betik eşlemesi yalnızca etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna referans veren metni kontrol eder.

**Kaydetmek ve yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak tema verilerinin kalıcılığını doğrular. Ayrıca, her gerekli yazı sisteminden temsilci bir metni render ederek eşlenen yazı tiplerinin kullanılabilir ve gerekli glifleri içerdiğini doğrulamak gerekir.