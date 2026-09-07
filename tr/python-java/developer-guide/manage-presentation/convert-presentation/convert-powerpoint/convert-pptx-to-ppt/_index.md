---
title: Python'da PPTX'i PPT'ye Dönüştür
linktitle: PPTX'ten PPT'ye
type: docs
weight: 21
url: /tr/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPTX'i dönüştür
- PPTX'ten PPT'ye
- PPTX'i PPT olarak kaydet
- PPTX'i PPT'ye dışa aktar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak Python'da PPTX'i eski PPT formatına dönüştürün. Bir kod örneği ve uyumluluk ile korumalı dosyalar hakkında notlar içerir."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, Microsoft PowerPoint yüklü olmadan, PPTX sunumunu PowerPoint 97–2003 tarafından kullanılan eski PPT formatına dönüştürmenizi sağlar. Aşağıda gösterildiği gibi PPTX dosyasını yükleyin ve PPT çıktı formatıyla kaydedin.

## **PPTX'yi PPT'ye Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından çıktı yolunu ve [SaveFormat.Ppt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Ppt) ile [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu çağırın.

Aşağıdaki örnek, gerekirse Java sanal makinesini başlatır ve `template.pptx` dosyasını varsayılan seçeneklerle `output.ppt` olarak dönüştürür. Yolları kendi dosya adlarınızla değiştirin. `finally` bloğu, kaydetme başarısız olsa bile sunum kaynaklarını serbest bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# PPTX sunumunu yükle.
presentation = Presentation("template.pptx")
try:
    # Sunumu PPT formatında kaydet.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Ppt) argümanı çıktı formatını seçer; yalnızca dosya uzantısını değiştirmek bir sunumu dönüştürmez. Yeni bir özelliğin PPT'de eşdeğeri yoksa geri dönmek için orijinal PPTX dosyasını saklayın.

## **PPTX'yi Diğer Formatlara Dönüştür**

Aspose.Slides ayrıca diğer çıktı formatlarını da destekler. Biçim‑özel seçenekler ve örnekler için ilgili makalelere bakın:

- [PowerPoint'i Python'da PDF'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-pdf/)
- [PowerPoint'i Python'da XPS'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-xps/)
- [PowerPoint'i Python'da HTML'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-html/)
- [Sunumları Python'da ODP Olarak Kaydet](/slides/tr/python-java/save-presentation/)
- [PowerPoint'i Python'da PNG'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-png/)

## **SSS**

**Tüm PPTX efektleri ve özellikleri PPT'ye dönüşümde korunur mu?**

Her zaman değil. Eski PPT formatı, PPTX'te mevcut olan tüm özellikleri desteklemez. Bazı efektler, nesneler veya davranışlar basitleştirilebilir veya farklı gösterilebilir. Dönüştürülen sunumu hedef görüntüleyicide gözden geçirin, özellikle yeni PowerPoint özellikleri içeriyorsa.

**Yalnızca seçili slaytları PPT'ye dönüştürebilir miyim?**

PPT'ye kaydetme tüm sunumu yazar. Seçili slaytları dönüştürmek için yeni bir sunum oluşturun, ilk boş slaytı kaldırın, gereken slaytları ona kopyalayın ve PPT olarak kaydedin. Bkz. [Clone Slides in Python](/slides/tr/python-java/clone-slides/).

**Şifre korumalı bir PPTX dosyasını dönüştürebilir miyim?**

Evet, kaynak sunumu yüklerken doğru şifreyi sağlarsanız. Çıktı dosyası için de koruma yapılandırabilirsiniz. Bkz. [Password-Protected Presentations](/slides/tr/python-java/password-protected-presentation/).