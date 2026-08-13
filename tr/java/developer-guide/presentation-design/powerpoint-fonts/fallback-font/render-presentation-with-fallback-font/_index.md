---
title: "Java'da Yedek Yazı Tipleriyle Sunumları Renderleme"
linktitle: "Sunumları Renderleme"
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
description: "Aspose.Slides for Java’da yedek yazı tipleriyle sunumları renderleyin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım Java kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları renderlemenizi sağlar. Bu makale, bir yedek yazı tipi kuralı koleksiyonunu nasıl oluşturacağınızı, kuralları yedek yazı tiplerini kaldırarak veya ekleyerek nasıl değiştireceğinizi ve koleksiyonu `FontsManager.setFontFallBackRulesCollection` yöntemiyle nasıl atayacağınızı gösterir.

Yedek yazı tipi kuralı koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, renderleme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmini renderlerken ve JPEG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kurallarını Kullanarak Bir Slaytı Renderleme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [yedek yazı tipi kurallarının koleksiyonunu oluştururuz](/slides/tr/java/create-fallback-fonts-collection/).
1. [Kaldır](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) bir yedek yazı tipi kuralını ve [addFallBackFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekleyin.
1. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) yöntemine ayarlayın.
1. [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) yöntemiyle sunumu aynı biçimde kaydedebilir veya başka bir biçime dönüştürebiliriz. Yedek yazı tipi kuralı koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsManager)’a ayarlandıktan sonra bu kurallar, sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, renderleme, dönüştürme vb.

```java
import com.aspose.slides.*;

// Kurallar koleksiyonunun yeni bir örneğini oluştur
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Yüklü kurallardan yedek yazı tipi "Tahoma"yı kaldırmaya çalışıyor
    fallBackRule.remove("Tahoma");

    //Ve belirtilen aralık için kuralları güncellemeye
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Ayrıca, listeden mevcut kuralları kaldırabiliriz, renderlamak için en az bir kuralı tutarak
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Kullanmak için hazırlanmış kurallar listesini atama
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
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

{{% alert color="info" %}} 
Daha fazla bilgi için Java’da [PPT ve PPTX’i JPG’ye Dönüştürme](/slides/tr/java/convert-powerpoint-to-jpg/) konusunu okuyun.
{{% /alert %}}