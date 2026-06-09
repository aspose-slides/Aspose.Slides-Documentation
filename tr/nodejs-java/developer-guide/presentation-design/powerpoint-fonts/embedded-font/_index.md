---
title: JavaScript Kullanarak Sunumlarda Yazı Tiplerini Gömme
linktitle: Yazı Tipi Gömme
type: docs
weight: 40
url: /tr/nodejs-java/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi göm
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "TrueType yazı tiplerini PowerPoint ve OpenDocument sunumlarına, Java üzerinden Node.js için Aspose.Slides ile gömerek, tüm platformlarda doğru görüntülenmeyi sağlamak."
---
## **Giriş**

**PowerPoint’te gömülü yazı tipleri**, sunumunuzun herhangi bir sistem veya cihazda açıldığında doğru görünmesini istediğinizde faydalıdır. Çalışmanızda yaratıcı olduğunuz için üçüncü taraf veya standart dışı bir yazı tipi kullandıysanız, yazı tipinizi gömmek için daha da fazla nedeniniz olur. Aksi takdirde (gömülü yazı tipleri olmadan), slaytlarınızdaki metin veya sayılar, düzen, stil vb. değişebilir veya karışık dikdörtgenlere dönüşebilir. 

FontsManager sınıfı, FontData sınıfı, Compress sınıfı ve bunların sınıfları, PowerPoint sunumlarında gömülü yazı tipleriyle çalışmak için ihtiyaç duyduğunuz çoğu özellik ve yöntemi içerir.

## **Sunumdan Gömülü Yazı Tiplerini Alın veya Kaldırın**

Aspose.Slides, bir sunumda gömülü olan yazı tiplerini almanıza (veya öğrenmenize) olanak tanıyan getEmbeddedFonts metodunu (FontsManager sınıfı tarafından sunulur) sağlar. Yazı tiplerini kaldırmak için aynı sınıf tarafından sunulan removeEmbeddedFont metodu kullanılır.

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Gömülü "FunSized" kullanan bir metin çerçevesi içeren slaytı oluşturur
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Resmi JPEG formatında diske kaydeder
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Tüm gömülü yazı tiplerini alır
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // "Calibri" yazı tipini bulur
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // "Calibri" yazı tipini kaldırır
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Sunumu oluşturur; "Calibri" yazı tipi mevcut bir yazı tipiyle değiştirilir
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Resmi JPEG formatında diske kaydeder
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Gömülü "Calibri" yazı tipi olmadan sunumu diske kaydeder
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunuma Gömülü Yazı Tipleri Ekleyin**

EmbedFontCharacters enumunu ve addEmbeddedFont metodunun iki aşırı yüklemesini kullanarak, sunuma yazı tiplerini gömmek için tercih ettiğiniz (gömme) kuralı seçebilirsiniz. Bu JavaScript kodu, bir sunuma nasıl yazı tipleri gömülür ve eklenir gösterir:

```javascript
// Sunumu yükler
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Sunumu diske kaydeder
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gömülü Yazı Tiplerini Sıkıştırın**

Bir sunumda gömülü olan yazı tiplerini sıkıştırarak dosya boyutunu küçültmenizi sağlamak için Aspose.Slides, Compress sınıfı tarafından sunulan compressEmbeddedFonts metodunu sağlar.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Sunumdaki belirli bir yazı tipinin gömülü olmasına rağmen, render sırasında hâlâ değiştirileceğini nasıl anlayabilirim?**

Yazı tipi yöneticisindeki [substitution information](/slides/tr/nodejs-java/font-substitution/) ve [fallback/substitution rules](/slides/tr/nodejs-java/fallback-font/) kontrol edin: yazı tipi bulunamazsa veya kısıtlıysa, bir yedek kullanılacaktır.

**Arial/Calibri gibi "system" yazı tiplerini gömmeye değer mi?**

Genellikle hayır—neredeyse her zaman mevcuttur. Ancak "ince" ortamlarda (Docker, önceden yüklü yazı tipleri olmayan bir Linux sunucusu) tam taşınabilirlik için sistem yazı tiplerini gömmek, beklenmeyen değişim riskini ortadan kaldırabilir.