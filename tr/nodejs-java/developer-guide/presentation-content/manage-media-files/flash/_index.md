---
title: JavaScript'te Sunumlardan Flash Nesnelerini Çıkarma
linktitle: Flash
type: docs
weight: 10
url: /tr/nodejs-java/flash/
keywords:
- flash çıkar
- flash nesnesi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile JavaScript kullanarak PowerPoint ve OpenDocument slaytlarından Flash nesnelerini nasıl çıkaracağınızı, eksiksiz kod örnekleri ve en iyi uygulamaları öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardan Flash nesnelerini nasıl çıkaracağınızı açıklar. Bir slaytın kontrol koleksiyonunda ad ile bir Flash kontrolünü bulmayı ve gömülü SWF nesne verileriyle çalışmayı gösterir.

## **Sunumdan Flash Nesnelerini Çıkarma**

Aspose.Slides for Node.js via Java, bir sunumdan flash nesnelerini çıkarmak için bir özellik sağlar. Flash kontrolüne ad ile erişebilir ve sunumdan çıkarabilirsiniz; ayrıca SWF nesne verilerini depolayabilirsiniz.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Flash içeriği çıkarılırken hangi sunum formatları desteklenir?**

[Aspose.Slides supports](/slides/tr/nodejs-java/supported-file-formats/) ana PowerPoint formatları PPT ve PPTX gibi, çünkü bu kapsayıcıları yükleyebilir ve kontrollerine, Flash ile ilgili ActiveX öğeleri dahil, erişebilir.

**Flash içeren bir sunumu HTML5'e dönüştürüp Flash etkileşimini koruyabilir miyim?**

Hayır. Aspose.Slides SWF içeriğini çalıştırmaz veya etkileşimini dönüştürmez. [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/tr/nodejs-java/export-to-html5/) dışa aktarımı destekleniyor olsa da, Flash modern tarayıcılarda destek süresi dolduğundan çalışmaz. Tavsiye edilen yol, dışa aktarmadan önce Flash'ı video veya HTML5 animasyonları gibi alternatiflerle değiştirmektir.

**Güvenlik açısından, Aspose.Slides bir sunumu okurken SWF dosyalarını çalıştırır mı?**

Hayır. Aspose.Slides Flash'ı dosyaya gömülü ikili veri olarak ele alır ve işleme sırasında SWF içeriğini çalıştırmaz.

**Flash içeren ve aynı zamanda OLE aracılığıyla gömülü diğer dosyaları da içeren sunumları nasıl ele almalıyım?**

Aspose.Slides [gömülü OLE nesnelerinin çıkarılmasını](/slides/tr/nodejs-java/manage-ole/) destekler, böylece tüm ilgili gömülü içeriği tek seferde işleyebilir, Flash kontrollerini ve diğer OLE ile gömülmüş belgeleri birlikte ele alabilirsiniz.