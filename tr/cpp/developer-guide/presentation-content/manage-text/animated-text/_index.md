---
title: C++ ile PowerPoint Metnini Canlandırın
linktitle: Animasyonlu Metin
type: docs
weight: 60
url: /tr/cpp/animated-text/
keywords:
- animasyonlu metin
- metin animasyonu
- animasyonlu paragraf
- paragraf animasyonu
- animasyon etkisi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarında dinamik animasyonlu metin oluşturun, kolay anlaşılır ve optimize edilmiş C++ kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te animasyonlu metinle nasıl çalışılacağını, bireysel paragraflara animasyon efektleri uygulayarak ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri alarak açıklar. Sunumda paragraf düzeyinde animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

Biz, [**AddEffect()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) yöntemini [**Sequence**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.sequence) ve [**ISequence**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.i_sequence) sınıflarına ekledik. Bu yöntem, tek bir paragrafa animasyon efektleri eklemenizi sağlar. Aşağıdaki örnek kod, tek bir paragrafa animasyon efekti eklemeyi gösterir:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// etki eklemek için paragrafı seç
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// seçilen paragrafa Fly animasyon etkisi ekle
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Paragraflar için Animasyon Efektlerini Almak**

Örneğin, bir paragrafta eklenen animasyon efektlerini öğrenmek isteyebilirsiniz; bir senaryoda, bu efektleri başka bir paragraf veya şekle uygulamayı planladığınız için bir paragraftaki animasyon efektlerini almak isteyebilirsiniz.

Aspose.Slides for C++ , bir metin çerçevesi (şekil) içinde bulunan paragraflara uygulanan tüm animasyon efektlerini almanıza olanak tanır. Aşağıdaki örnek kod, bir paragraftaki animasyon efektlerini nasıl alacağınızı gösterir:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilirler mi?**

Metin animasyonları, bir slayt üzerindeki nesnenin zaman içinde davranışını kontrol ederken, [transitions](/slides/tr/cpp/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilirler; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından yönetilir.

**Metin animasyonları PDF veya görüntülere dışa aktarılırken korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden slaytın hareket olmadan tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/cpp/convert-powerpoint-to-video/) veya [HTML](/slides/tr/cpp/export-to-html5/) dışa aktarmasını kullanın.

**Metin animasyonları düzenlerde ve slayt ana modelinde çalışır mı?**

Düzen/ana model nesnelerine uygulanan efektler slaytlara miras geçer, ancak bunların zamanlaması ve slayt düzeyindeki animasyonlarla etkileşimi slayttaki nihai sıraya bağlıdır.