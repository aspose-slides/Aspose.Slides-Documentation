---
title: Android'de Sunumlardan Flash Nesnelerini Çıkarma
linktitle: Flash
type: docs
weight: 10
url: /tr/androidjava/flash/
keywords:
- flash çıkarma
- flash nesnesi
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da PowerPoint ve OpenDocument slaytlarından Flash nesnelerini nasıl çıkaracağınızı, tam kod örnekleri ve en iyi uygulamaları öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardan Flash nesnelerinin nasıl çıkarılacağını açıklar. Bir slaydın kontroller koleksiyonunda adıyla bir Flash kontrolünün nasıl bulunacağını ve gömülü SWF nesne verileriyle nasıl çalışılacağını gösterir.

## **Sunumlardan Flash Nesnelerini Çıkartma**

Aspose.Slides for Android via Java, bir sunumdan flash nesnelerini çıkarmak için bir özellik sunar. Flash kontrolüne adla erişebilir ve onu sunumdan çıkararak SWF nesne verilerini depolayabilirsiniz.

```java
// PPTX'i temsil eden Presentation sınıfını oluşturun
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Flash içeriği çıkarılırken hangi sunum formatları desteklenir?**

[Aspose.Slides destekler](/slides/tr/androidjava/supported-file-formats/) PPT ve PPTX gibi ana PowerPoint formatlarını, çünkü bu kapsayıcıları yükleyebilir ve kontrollerine, Flash ile ilgili ActiveX öğeleri de dahil olmak üzere, erişebilir.

**Flash içeren bir sunumu HTML5'e dönüştürüp Flash etkileşimini koruyabilir miyim?**

Hayır. Aspose.Slides SWF içeriğini çalıştırmaz veya etkileşimini dönüştürmez. [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/tr/androidjava/export-to-html5/) dışa aktarma destekleniyor olsa da, Flash modern tarayıcılarda artık desteklenmediği için çalışmaz. Önerilen yol, dışa aktarmadan önce Flash'ı video veya HTML5 animasyonları gibi alternatiflerle değiştirmektir.

**Güvenlik açısından, Aspose.Slides bir sunumu okurken SWF dosyalarını çalıştırıyor mu?**

Hayır. Aspose.Slides Flash'ı dosyaya gömülü ikili veri olarak ele alır ve işlem sırasında SWF içeriğini çalıştırmaz.

**OLE aracılığıyla gömülü diğer dosyalarla birlikte Flash içeren sunumları nasıl ele almalıyım?**

Aspose.Slides [gömülü OLE nesnelerinin çıkarılmasını](/slides/tr/androidjava/manage-ole/) destekler, böylece tüm ilgili gömülü içeriği tek seferde işleyebilir, Flash kontrollerini ve diğer OLE gömülü belgeleri birlikte ele alabilirsiniz.