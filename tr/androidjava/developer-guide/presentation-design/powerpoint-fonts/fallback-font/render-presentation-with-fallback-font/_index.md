---
title: Android'de Geri Dönüş Fontlarıyla Sunumları Renderle
linktitle: Sunumları Renderle
type: docs
weight: 30
url: /tr/androidjava/render-presentation-with-fallback-font/
keywords:
- geri dönüş fontu
- PowerPoint'i renderle
- sunumu renderle
- slaytı renderle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides'te geri dönüş fontlarıyla sunumları renderleyin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım Java kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, geri dönüş font kurallarını kullanarak sunumları renderlemenizi sağlar. Bu makale, bir geri dönüş font kuralı koleksiyonu oluşturmayı, kuralları geri dönüş fontlarını kaldırarak veya ekleyerek değiştirmeyi ve koleksiyonu `FontsManager.setFontFallBackRulesCollection` yöntemiyle atamayı gösterir.

Geri dönüş font kuralı koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, renderleme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi renderlenirken ve JPEG görüntüsü olarak kaydedilirken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Geri Dönüş Font Kurallarıyla Bir Slaytı Renderle**

Aşağıdaki örnek bu adımları içerir:

1. Biz [geri dönüş font kuralları koleksiyonu oluştururuz](/slides/tr/androidjava/create-fallback-fonts-collection/).
2. [Kaldır](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) bir geri dönüş font kuralını ve [addFallBackFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekleyin.
3. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) yöntemiyle ayarlayın.
4. [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Geri dönüş font kuralı koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager)'a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, renderleme, dönüştürme, vb.

```java
import com.aspose.slides.*;

// Yeni bir kural koleksiyonu örneği oluştur
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// bir dizi kural oluştur
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Yüklenen kurallardan Geri Dönüş fontu "Tahoma"yı kaldırmaya çalışıyor
    fallBackRule.remove("Tahoma");

    // Belirtilen aralık için kuralları güncellemeye
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Ayrıca listeden mevcut kuralları kaldırabiliriz, render için en az bir kural tutarak
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Kullanım için hazırlanmış kural listesini atama
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Başlatılmış kural koleksiyonunu kullanarak thumbnail renderleme ve JPEG olarak kaydetme
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Görüntüyü JPEG formatında diske kaydet
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
Android'de PPT ve PPTX'i JPG'ye dönüştürme hakkında daha fazla bilgi edinin [Android'de PPT ve PPTX'i JPG'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}