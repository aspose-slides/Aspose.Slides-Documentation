---
title: PowerPoint Metnini .NET'te Canlandırma
linktitle: Animasyonlu Metin
type: docs
weight: 60
url: /tr/net/animated-text/
keywords:
- animasyonlu metin
- metin animasyonu
- animasyonlu paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarında dinamik animasyonlu metin oluşturun, kolay takip edilebilen, optimize edilmiş C# kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides’ta animasyonlu metinle çalışmayı, tek tek paragraflara animasyon efektleri uygulamayı ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri almayı açıklar. Sunumda paragraf‑düzeyi animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

[**AddEffect()**](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/sequence/methods/addeffect/index) yöntemini [**Sequence**](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/sequence) ve [**ISequence**](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence) sınıflarına ekledik. Bu yöntem, tek bir paragrafa animasyon efekti eklemenizi sağlar. Aşağıdaki örnek kod, tek bir paragrafa animasyon efekti eklemenizi gösterir:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // efekt eklemek için paragrafı seç
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // seçilen paragraf üzerine Uçuş animasyon efekti ekle
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Paragraflar İçin Animasyon Efektlerini Alın**

Bir paragrafın üzerine eklenen animasyon efektlerini öğrenmek isteyebilirsiniz—örneğin, bir senaryoda bir paragraftaki animasyon efektlerini alıp bu efektleri başka bir paragraf ya da şekle uygulamak isteyebilirsiniz.

Aspose.Slides for .NET, bir metin çerçevesinde (şekil) bulunan paragraflara uygulanmış tüm animasyon efektlerini almanıza olanak tanır. Aşağıdaki örnek kod, bir paragraftaki animasyon efektlerini nasıl alacağınızı gösterir:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilirler mi?**

Metin animasyonları, bir slayttaki nesnenin zaman içinde davranışını kontrol ederken, [transitions](/slides/tr/net/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilirler; oynatma sırası, animasyon zaman çizelgesi ve geçiş ayarları tarafından belirlenir.

**Metin animasyonları PDF ya da görüntülere dışa aktarıldığında korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden hareket olmadan slaydın tek bir durumunu görürsünüz. hareketi korumak için [video](/slides/tr/net/convert-powerpoint-to-video/) ya da [HTML](/slides/tr/net/export-to-html5/) dışa aktarma yöntemlerini kullanın.

**Metin animasyonları düzenlerde ve slayt ana temasında çalışır mı?**

Düzen/ana tema nesnelerine uygulanan efektler slaytlara miras olarak geçer, ancak bunların zamanlaması ve slayt‑düzeyi animasyonlarla etkileşimi, slayttaki son sıralamaya bağlıdır.