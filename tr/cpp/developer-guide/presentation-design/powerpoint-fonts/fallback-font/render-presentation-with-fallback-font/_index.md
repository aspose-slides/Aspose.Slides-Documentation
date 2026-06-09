---
title: Yedek Yazı Tipleriyle Sunumları С++'ta Render Et
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/cpp/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint render et
- sunumu render et
- slaytı render et
- PowerPoint
- OpenDocument
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides için С++'ta yedek yazı tipleriyle sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım С++ kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları render etmenizi sağlar. Bu makale, yedek yazı tipi kurallar koleksiyonunu nasıl oluşturacağınızı, kuralları yedek yazı tiplerini kaldırarak veya ekleyerek nasıl değiştireceğinizi ve koleksiyonu `FontsManager::set_FontFallBackRulesCollection` yöntemiyle nasıl atayacağınızı gösterir.

Yedek yazı tipi kuralları koleksiyonu sunumun `FontsManager`'ına atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi render ederken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını göstermektedir.

## **Yedek Yazı Tipi Kurallarını Kullanarak Bir Slaytı Render Etme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [yedek yazı tipi kuralları koleksiyonunu oluştur](/slides/tr/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/remove/) bir yedek yazı tipi kuralını kaldırın ve [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) başka bir kurala ekleyin.
3. Kurallar koleksiyonunu [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) yöntemine gönderin.
4. [Presentation::Save()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek yazı tipi kuralları koleksiyonu FontsManager'a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme vb.

``` cpp
// Bir kural koleksiyonunun yeni örneğini oluştur
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Birkaç kural oluştur
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Yüklenmiş kurallardan yedek yazı tipi "Tahoma"yı kaldırmaya çalışıyor
	fallBackRule->Remove(u"Tahoma");

	// Ve belirtilen aralık için kuralları güncellemeye
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Ayrıca listeden mevcut kuralları kaldırabiliriz
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Kullanım için hazırlanmış kural listesini atama
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Başlatılmış kural koleksiyonunu kullanarak küçük resim oluşturma ve PNG olarak kaydetme
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
[PowerPoint Slaytlarını C++'ta PNG'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-png/) hakkında daha fazla bilgi edinin.
{{% /alert %}}