---
title: JavaScript'te Geri Dönüş Fontlarıyla Sunumları Render Etme
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/nodejs-java/render-presentation-with-fallback-font/
keywords:
- geri dönüş fontu
- PowerPoint'i renderleme
- sunumu renderleme
- slaytı renderleme
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te geri dönüş fontlarıyla sunumları render edin - PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım JavaScript kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, geri dönüş font kurallarını kullanarak sunumları işleyebilmenizi sağlar. Bu makale, geri dönüş font kuralları koleksiyonunu nasıl oluşturacağınızı, kuralları geri dönüş fontlarını kaldırarak veya ekleyerek nasıl değiştireceğinizi ve koleksiyonu `FontsManager.setFontFallBackRulesCollection` yöntemiyle nasıl atayacağınızı gösterir.

Geri dönüş font kuralları koleksiyonu sunumun `FontsManager`ına atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmini render ederken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını göstermektedir.

## **Geri Dönüş Font Kurallarıyla Bir Slaytı İşleme**

Aşağıdaki örnek şu adımları içerir:

1. [geri dönüş font kuralları koleksiyonunu oluştur](/slides/tr/nodejs-java/create-fallback-fonts-collection/).
2. [Kaldır](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) bir geri dönüş font kuralını ve [addFallBackFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekleyin.
3. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) yöntemine ayarlayın.
4. [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) yöntemiyle sunumu aynı formatta ya da başka bir formatta kaydedebiliriz. Geri dönüş font kuralları koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FontsManager)’a ayarlandığında, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme vb.

```javascript
// Kural koleksiyonunun yeni bir örneğini oluştur
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// create a number of rules
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Yüklenen kurallardan geri dönüş fontu "Tahoma"yı kaldırmaya çalışılıyor
    fallBackRule.remove("Tahoma");
    // Belirtilen aralık için kuralları güncellemeye
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Ayrıca listedeki mevcut kuralları da kaldırabiliriz
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Kullanım için hazırlanmış kural listesini atama
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Başlatılmış kural koleksiyonunu kullanarak küçük resim render etme ve JPEG olarak kaydetme
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Görüntüyü JPEG formatında diske kaydet
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
[JavaScript'te PPT ve PPTX'i JPG'ye Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-jpg/) hakkında daha fazla bilgi edinin.
{{% /alert %}}