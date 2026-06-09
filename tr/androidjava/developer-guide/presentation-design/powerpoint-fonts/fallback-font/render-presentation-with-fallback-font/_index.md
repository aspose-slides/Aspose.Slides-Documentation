---
title: Geri Dönüş Yazı Tipleriyle Android'de Sunumları Render Etme
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/androidjava/render-presentation-with-fallback-font/
keywords:
- geri dönüş yazı tipi
- PowerPoint render et
- sunum render et
- slayt render et
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de geri dönüş yazı tipleriyle sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım Java kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, sunumları geri dönüş yazı tipi kuralları kullanarak render etmenizi sağlar. Bu makale, bir geri dönüş yazı tipi kuralları koleksiyonu oluşturmayı, kuralları geri dönüş yazı tiplerini kaldırarak veya ekleyerek değiştirmeyi ve koleksiyonu `FontsManager.setFontFallBackRulesCollection` yöntemiyle atamayı gösterir.

Geri dönüş yazı tipi kuralları koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi render edilirken ve PNG görüntüsü olarak kaydedilirken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Geri Dönüş Yazı Tipi Kuralları Kullanarak Bir Slaytı Render Etme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [geri dönüş yazı tipi kuralları koleksiyonu oluşturuyoruz](/slides/tr/androidjava/create-fallback-fonts-collection/).
2. [Kaldır](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) bir geri dönüş yazı tipi kuralını ve [addFallBackFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekleyin.
3. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) yöntemiyle ayarlayın.
4. [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Geri dönüş yazı tipi kuralları koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager)‑a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme vb.

```java
// Kurallar koleksiyonunun yeni bir örneğini oluştur
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// bir dizi kural oluştur
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Yüklenen kurallardan Geri Dönüş yazı tipi "Tahoma"yı kaldırma girişimi
    fallBackRule.remove("Tahoma");

    //Belirtilen aralık için kuralları güncelle
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Ayrıca listeden mevcut kuralları kaldırabiliriz
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Kullanım için hazırlanmış kurallar listesini atama
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Başlatılmış kurallar koleksiyonunu kullanarak küçük resim oluşturma ve JPEG olarak kaydetme
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Görüntüyü JPEG formatında diske kaydet
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
Daha fazla bilgi için [Android'de PPT ve PPTX'i JPG'ye Dönüştürme](/slides/tr/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}