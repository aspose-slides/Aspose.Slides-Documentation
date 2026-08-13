---
title: Yedek Fontlarla C++'ta Sunum Oluşturma
linktitle: Sunum Oluşturma
type: docs
weight: 30
url: /tr/cpp/render-presentation-with-fallback-font/
keywords:
- yedek font
- PowerPoint oluştur
- sunum oluştur
- slayt oluştur
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta yedek fontlarla sunumları oluşturun – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım C++ kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek font kurallarını kullanarak sunumları oluşturmanıza olanak tanır. Bu makale, yedek font kuralı koleksiyonunu nasıl oluşturacağınızı, kuralları yedek fontları kaldırarak veya ekleyerek nasıl değiştireceğinizi ve koleksiyonu `FontsManager::set_FontFallBackRulesCollection` yöntemiyle nasıl atayacağınızı gösterir.

Yedek font kuralı koleksiyonu sunumun `FontsManager`'ına atandıktan sonra, kurallar kaydetme, oluşturma ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmini oluştururken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Font Kurallarını Kullanarak Bir Slaytı Oluşturma**

Aşağıdaki örnek şu adımları içerir:

1. Biz [yedek font kuralı koleksiyonunu oluştururuz](/slides/tr/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/remove/) bir yedek font kuralını kaldırır ve başka bir kurala [AddFallBackFonts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) ekler.
1. Kurallar koleksiyonunu [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) yöntemine gönderin.
1. [Presentation::Save()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemiyle sunumu aynı formatta kaydedebilir ya da başka bir formata kaydedebiliriz. Yedek font kuralı koleksiyonu FontsManager'a ayarlandıktan sonra, bu kurallar kaydetme, oluşturma, dönüştürme gibi sunum üzerindeki tüm işlemler sırasında uygulanır.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// Yeni bir kural koleksiyonu örneği oluştur
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Birkaç kural oluştur
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Yüklenen kurallardan "Tahoma" yedek fontunu kaldırmayı deniyor
	fallBackRule->Remove(u"Tahoma");

	// Ve belirtilen aralık için kuralları güncellemeyi
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
// Kullanım için hazırlanan kural listesini atama
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Başlatılmış kural koleksiyonunu kullanarak küçük resim oluşturma ve PNG olarak kaydetme
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Daha fazla bilgi için [Convert PowerPoint Slides to PNG in C++](/slides/tr/cpp/convert-powerpoint-to-png/). 
{{% /alert %}}