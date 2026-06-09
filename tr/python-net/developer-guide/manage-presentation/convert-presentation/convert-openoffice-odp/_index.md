---
title: Python'da OpenDocument Sunumlarını Dönüştürme
linktitle: OpenDocument Dönüştür
type: docs
weight: 10
url: /tr/python-net/convert-openoffice-odp/
keywords:
- OpenDocument dönüştür
- ODP dönüştür
- ODP'den PDF'ye
- ODP'den PPT'ye
- ODP'den PPTX'e
- ODP'den XPS'e
- ODP'den HTML'e
- ODP'den TIFF'e
- ODP'den SWF'e
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da OpenDocument ODP'yi PDF, PPT, PPTX, XPS, HTML, TIFF veya SWF formatlarına dönüştürün: kod örnekleri, yüksek doğruluk, toplu dönüşüm ve özelleştirme."
---
## **Giriş**

[**Aspose.Slides API**](https://products.aspose.com/slides/tr/python-net/) OpenDocument (ODP) sunumlarını birçok formata (HTML, PDF, TIFF, SWF, XPS, vb.) dönüştürmenizi sağlar. ODP dosyalarını diğer belge formatlarına dönüştürmek için kullanılan API, PowerPoint (PPT ve PPTX) dönüşüm işlemleri için kullanılanla aynıdır.

Örneğin, bir ODP sunumunu PDF'ye dönüştürmeniz gerekiyorsa, aşağıdaki gibi yapabilirsiniz:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **SSS**

**LibreOffice veya OpenOffice kurmadan ODP'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides, hem PowerPoint hem de OpenOffice formatlarını dış uygulamalara ihtiyaç duymadan işleyen tamamen bağımsız bir kütüphanedir.

**Aspose.Slides, şifre korumalı ODP/OTP dosyalarını açıp kaydedebilir mi?**

Evet. Şifreyi sağladığınızda [şifreli sunumları yükleyebilir](/slides/tr/python-net/password-protected-presentation/) ve aynı zamanda şifreleme ve koruma ayarlarıyla sunumları kaydedebilir.

**Bir ODP'yi dönüştürmeden önce gömülü medya dosyalarını (ses/video) çıkarabilir miyim?**

Evet. Aspose.Slides, sunumlardan gömülü [ses](/slides/tr/python-net/audio-frame/) ve [video](/slides/tr/python-net/video-frame/) dosyalarına erişmenizi ve bunları çıkarmanızı sağlar; bu, dönüştürmeden önce işlem yapma veya ayrı ayrı yeniden kullanım için yararlıdır.

**Dönüştürülen ODP'yi Katı Office Open XML olarak kaydedebilir miyim?**

Evet. PPTX olarak kaydederken, daha katı uyumluluk gereksinimlerini karşılamak için [kaydetme seçenekleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/pptxoptions/) üzerinden Strict OOXML'i etkinleştirebilirsiniz.