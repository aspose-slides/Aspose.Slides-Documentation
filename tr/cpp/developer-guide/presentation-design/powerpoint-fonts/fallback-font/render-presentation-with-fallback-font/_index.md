---
title: Yedek Yazı Tipleriyle Sunumları Render Etme C++'ta
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/cpp/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint render et
- sunum render et
- slayt render et
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta yedek yazı tipleriyle sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım C++ kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, sunumları yedek yazı tipi kuralları kullanarak render etmenizi sağlar. Bu makale, bir yedek yazı tipi kuralı koleksiyonu oluşturmayı, kuralları yedek yazı tiplerini kaldırarak veya ekleyerek değiştirmeyi ve koleksiyonu `FontsManager::set_FontFallBackRulesCollection` yöntemiyle atamayı gösterir.

Yedek yazı tipi kuralı koleksiyonu sunumun `FontsManager`ına atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi render ederken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kuralları Kullanarak Bir Slaytı Render Etme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [yedek yazı tipi kuralları koleksiyonu oluştururuz](/slides/tr/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/remove/) bir yedek yazı tipi kuralını kaldırır ve [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) başka bir kurala ekler.
3. Kurallar koleksiyonunu [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) yöntemine iletin.
4. [Presentation::Save()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek yazı tipi kuralı koleksiyonu FontsManager’a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme, vb.

``` cpp
// Kurallar koleksiyonunun yeni bir örneğini oluştur
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Bir dizi kural oluştur
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Yüklenmiş kurallardan geri dönüş (FallBack) yazı tipi "Tahoma"yı kaldırmaya çalışılıyor
	fallBackRule->Remove(u"Tahoma");

	// Ve belirtilen aralık için kuralları güncellemeye
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Ayrıca listedeki mevcut kuralları kaldırabiliriz
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Kullanım için hazırlanmış kurallar listesini atama
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Başlatılmış kurallar koleksiyonu kullanılarak küçük resim render edilip PNG olarak kaydediliyor
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Daha fazla bilgi için [C++'ta PowerPoint Slaytlarını PNG'ye Dönüştürme](/slides/tr/cpp/convert-powerpoint-to-png/) konusunu okuyun.
{{% /alert %}}