---
title: Fallback Fontlarla .NET'te Sunumları Render Et
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/net/render-presentation-with-fallback-font/
keywords:
- yedek font
- PowerPoint'ı render et
- sunumu render et
- slaytı render et
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile fallback fontlar kullanarak sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutun, adım adım C# kod örnekleriyle."
---
## **Genel Bakış**

Aspose.Slides, fallback font kurallarını kullanarak sunumları render etmenizi sağlar. Bu makale, bir fallback font kurallar koleksiyonunun nasıl oluşturulacağını, kuralların fallback fontları kaldırarak veya ekleyerek nasıl değiştirileceğini ve koleksiyonun `FontsManager.FontFallBackRulesCollection` özelliğine nasıl atanacağını gösterir.

Fallback font kurallar koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi render ederken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Fallback Font Kuralları Kullanarak Bir Slaytı Render Etme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [fallback font kurallar koleksiyonunu oluştururuz](/slides/tr/net/create-fallback-fonts-collection/).
2. Bir fallback font kuralını [Remove()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/remove) kaldırır ve başka bir kurala [AddFallBackFonts()](https://reference.aspose.com/slides/tr/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ekleriz.
3. Kurallar koleksiyonunu [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) özelliğine ayarlayın.
4. [Presentation.Save()](https://reference.aspose.com/slides/tr/net/aspose.slides.presentation/save/methods/4) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Fallback font kurallar koleksiyonu FontsManager'a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme vb.

```c#
 // Create new instance of a rules collection
// Yeni bir kural koleksiyonu örneği oluştur
 IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
// Bir dizi kural oluştur
 rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

 foreach (IFontFallBackRule fallBackRule in rulesList)
 {
	//Trying to remove FallBack font "Tahoma" from loaded rules
	// Yüklenen kurallardan FallBack fontu "Tahoma" kaldırmaya çalışılıyor
	fallBackRule.Remove("Tahoma");

	//And to update of rules for specified range
	// Belirtilen aralık için kuralları güncellemeye
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
 }

//Also we can remove any existing rules from list
// Ayrıca listeden mevcut kuralları kaldırabiliriz
 if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

 using (Presentation pres = new Presentation("input.pptx"))
 {
	//Assigning a prepared rules list for using
	// Kullanım için hazırlanmış kural listesini atama
	pres.FontsManager.FontFallBackRulesCollection = rulesList;

	// Rendering of thumbnail with using of initialized rules collection and saving to PNG
	// Başlatılmış kural koleksiyonunu kullanarak küçük resim render edilip PNG olarak kaydediliyor
	using (IImage image = pres.Slides[0].GetImage(1f, 1f))
	{
		image.Save("Slide_0.png", ImageFormat.Png);
	}
 }
```

{{% alert color="primary" %}} 
Sunumda Kaydetme ve Dönüştürme hakkında daha fazla bilgi edinin.
{{% /alert %}}