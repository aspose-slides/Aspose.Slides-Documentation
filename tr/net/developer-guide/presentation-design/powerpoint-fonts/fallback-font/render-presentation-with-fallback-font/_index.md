---
title: Fallback Fontlarla .NET'te Sunumları Görüntüle
linktitle: Sunumları Görüntüle
type: docs
weight: 30
url: /tr/net/render-presentation-with-fallback-font/
keywords:
- yedek font
- PowerPoint render et
- sunum render et
- slayt render et
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te yedek fontlarla sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım C# kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek font kurallarını kullanarak sunumları görüntülemenizi sağlar. Bu makale, bir yedek font kuralı koleksiyonu oluşturmayı, kuralları yedek fontları kaldırarak veya ekleyerek değiştirmeyi ve koleksiyonu `FontsManager.FontFallBackRulesCollection` özelliğine atamayı gösterir.

Yedek font kuralı koleksiyonu sunumun `FontsManager`ına atandığında, kurallar kaydetme, görüntüleme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmini oluştururken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Font Kuralları Kullanarak Bir Slaytı Görüntüleme**

Aşağıdaki örnek şu adımları içerir:

1. [create fallback font rules collection](/slides/tr/net/create-fallback-fonts-collection/) oluşturuyoruz.
1. [Remove()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/remove) bir yedek font kuralını kaldırın ve [AddFallBackFonts()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) başka bir kurala ekleyin.
1. Kurallar koleksiyonunu [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) özelliğine ayarlayın.
1. [Presentation.Save()](https://reference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/4) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek font kuralları koleksiyonu FontsManager’a ayarlandığında, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydet, görüntüle, dönüştür, vb.

```c#
using Aspose.Slides;

// Kurallar koleksiyonunun yeni bir örneğini oluştur
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// bir dizi kural oluştur
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Yüklenen kurallardan FallBack fontu "Tahoma" kaldırmaya çalışılıyor
	fallBackRule.Remove("Tahoma");

	// Ve belirtilen aralık için kuralları güncellemeye
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Ayrıca listeden mevcut kuralları kaldırabiliriz, render etmek için en az bir kural tutarak
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Kullanım için hazırlanmış kurallar listesini atama
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Başlatılan kurallar koleksiyonunu kullanarak küçük resim oluşturma ve PNG olarak kaydetme
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="info" %}} 
[Save and Convertion in Presentation](/slides/tr/net/convert-powerpoint-to-png/) hakkında daha fazla bilgi edinin.
{{% /alert %}}