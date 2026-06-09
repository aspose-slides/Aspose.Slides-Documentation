---
title: Python'da Yedek Yazı Tipleriyle Sunumları Render Etme
linktitle: Sunumları Render Et
type: docs
weight: 30
url: /tr/python-net/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint render et
- sunumu render et
- slaytı render et
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET üzerinden yedek yazı tipleri kullanarak sunumları render edin – PPT, PPTX ve ODP arasında metni tutarlı tutmak için adım adım kod örnekleri."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları render etmenizi sağlar. Bu makale, yedek yazı tipi kuralları koleksiyonunun nasıl oluşturulacağını, kuralların yedek yazı tipleri kaldırılarak veya eklenerek nasıl değiştirileceğini ve koleksiyonun `FontsManager.font_fall_back_rules_collection` özelliğine nasıl atanacağını gösterir.

Yedek yazı tipi kuralları koleksiyonu sunumun `fonts_manager` özelliğine atandığında, kurallar kaydetme, render etme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmi render edilirken ve PNG görüntüsü olarak kaydedilirken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kurallarını Kullanarak Bir Slaytı Render Etme**

Aşağıdaki örnek şu adımları içerir:

1. Biz [yedek yazı tipi kuralları koleksiyonunu oluştururuz](/slides/tr/python-net/create-fallback-fonts-collection/).
2. [Kaldır](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrule/remove/) bir yedek yazı tipi kuralını ve [add_fall_back_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) başka bir kurala ekleyin.
3. Kurallar koleksiyonunu [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) özelliğine ayarlayın.
4. [Presentation.save()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek yazı tipi kuralları koleksiyonu FontsManager'a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, render etme, dönüştürme, vb.

```py
import aspose.slides as slides

# Bir kural koleksiyonunun yeni örneğini oluştur
rulesList = slides.FontFallBackRulesCollection()

# Birkaç kural oluştur
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Yüklenmiş kurallardan "Tahoma" FallBack yazı tipini kaldırmaya çalışıyor
	fallBackRule.remove("Tahoma")

	# Belirtilen aralık için kuralları güncelleme
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Ayrıca listeden mevcut kuralları kaldırabiliriz
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Kullanım için hazırlanmış kural listesini atama
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Başlatılmış kural koleksiyonunu kullanarak küçük resim render'ı ve PNG olarak kaydetme
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Nasıl yapılacağını daha fazla öğrenmek için [Python'da PowerPoint Slaytlarını PNG'ye Dönüştür](/slides/tr/python-net/convert-powerpoint-to-png/). 
{{% /alert %}}