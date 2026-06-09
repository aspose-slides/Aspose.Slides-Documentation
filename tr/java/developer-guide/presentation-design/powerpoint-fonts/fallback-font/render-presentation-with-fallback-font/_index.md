---
title: Java'da Yedek Yazı Tipleriyle Sunumları Renderleme
linktitle: Sunumları Renderle
type: docs
weight: 30
url: /tr/java/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint renderleme
- sunum renderleme
- slayt renderleme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile yedek yazı tipleri kullanarak sunumları renderleyin – PPT, PPTX ve ODP arasında metni tutarlı tutan adım adım Java kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları renderlemenizi sağlar. Bu makale, yedek yazı tipi kurallarının koleksiyonunun nasıl oluşturulacağını, kuralların yedek yazı tipleri kaldırılarak veya eklenerek nasıl değiştirileceğini ve koleksiyonun `FontsManager.setFontFallBackRulesCollection` yöntemiyle nasıl atanacağını gösterir.

Yedek yazı tipi kurallarının koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, renderleme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt mini resmini renderlerken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kurallarını Kullanarak Slayt Renderleme**

Aşağıdaki örnek şu adımları içerir:

1. [Yedek yazı tipi kurallarının koleksiyonunu oluşturuyoruz](/slides/tr/java/create-fallback-fonts-collection/).
1. [Kaldır](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) bir yedek yazı tipi kuralını ve [addFallBackFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekleyin.
1. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metoduna ayarlayın.
1. [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanarak sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek yazı tipi kurallarının koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager) üzerine ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, renderleme, dönüştürme vb.

```java
// Kural koleksiyonunun yeni bir örneğini oluştur
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //    Yüklenen kurallardan Yedek Yazı Tipi "Tahoma"'yı kaldırmaya çalışıyor
    fallBackRule.remove("Tahoma");

    //    Ve belirtilen aralık için kuralları güncellemeye
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list
// Ayrıca listeden mevcut herhangi bir kuralı kaldırabiliriz
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //    Kullanım için hazırlanmış kural listesini atama
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
    //    Başlatılmış kural koleksiyonunu kullanarak küçük resim renderleme ve JPEG olarak kaydetme
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Save the image to disk in JPEG format
   //   Görüntüyü JPEG formatında diske kaydet
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Daha fazla bilgi için [Javada PPT ve PPTX'i JPG'ye Dönüştür](/slides/tr/java/convert-powerpoint-to-jpg/).
{{% /alert %}}