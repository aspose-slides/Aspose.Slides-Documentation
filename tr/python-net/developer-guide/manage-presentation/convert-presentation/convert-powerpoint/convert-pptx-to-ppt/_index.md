---
title: Python'da PPTX'i PPT'ye Dönüştür
linktitle: PPTX'ten PPT'ye
type: docs
weight: 21
url: /tr/python-net/convert-pptx-to-ppt/
keywords:
- PPTX'ten PPT'ye
- PPTX'i PPT'ye dönüştür
- PowerPoint'i dönüştür
- sunumu dönüştür
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET üzerinden PPTX'i kolayca PPT'ye dönüştürün—PowerPoint formatlarıyla sorunsuz uyumluluk sağlayın ve sunumunuzun düzeni ve kalitesini koruyun."
---
## **Genel Bakış**

Aspose.Slides for Python, modern PPTX sunumlarını tamamen kod içinde eski PPT formatına dönüştürmenizi sağlar. Bir PPTX dosyasını açın ve sunumun içeriği ve düzenini koruyarak PPT olarak dışa aktarın, böylece sonuç daha eski PowerPoint sürümleriyle uyumlu olur. Aynı iş akışı PDF, XPS, ODP, HTML veya görüntüler gibi diğer çıktıları da üretebilir; bu sayede betiklerde, CI boru hatlarında ve toplu işleme sorunsuzca entegre olur.

## **PPTX'i PPT'ye Dönüştür**

PPTX'i PPT'ye dönüştürmek için, dosya adını ve kaydetme biçimini [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) metoduna [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının üzerinden basitçe iletin. Aşağıdaki Python örneği, varsayılan seçenekleri kullanarak bir sunumu PPTX'ten PPT'ye dönüştürür.

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını oluşturun.
presentation = slides.Presentation("presentation.pptx")

# Sunumu PPT dosyası olarak kaydedin.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **SSS**

**Tüm PPTX efektleri ve özellikleri eski PPT (97–2003) formatına kaydedildiğinde korunur mu?**

Her zaman değil. PPT formatı bazı yeni yeteneklerden yoksundur (ör. belirli efektler, nesneler ve davranışlar), bu nedenle özellikler dönüşüm sırasında sadeleştirilebilir veya rasterleştirilebilir.

**Tüm sunum yerine yalnızca seçili slaytları PPT'ye dönüştürebilir miyim?**

Doğrudan kaydetme tüm sunumu hedef alır. Belirli slaytları dönüştürmek için, sadece o slaytları içeren yeni bir sunum oluşturup PPT olarak kaydedin; alternatif olarak, slayt başına dönüşüm parametrelerini destekleyen bir hizmet/API kullanabilirsiniz.

**Şifre korumalı sunumlar destekleniyor mu?**

Evet. Bir dosyanın korumalı olup olmadığını tespit edebilir, şifreyle açabilir ve ayrıca kaydedilen PPT için [koruma/şifreleme ayarlarını yapılandırabilirsiniz](/slides/tr/python-net/password-protected-presentation/).

**Ayrıca bakınız:**
- [Python'da PPT & PPTX'i PDF'ye Dönüştür | Gelişmiş Seçenekler](/slides/tr/python-net/convert-powerpoint-to-pdf/)
- [Python'da PowerPoint Sunumlarını XPS'ye Dönüştür](/slides/tr/python-net/convert-powerpoint-to-xps/)
- [Python'da PowerPoint Sunumlarını HTML'ye Dönüştür](/slides/tr/python-net/convert-powerpoint-to-html/)
- [Python'da PowerPoint Slaytlarını PNG'ye Dönüştür](/slides/tr/python-net/convert-powerpoint-to-png/)