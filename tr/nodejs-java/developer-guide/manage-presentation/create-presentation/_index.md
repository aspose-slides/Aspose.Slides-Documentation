---
title: JavaScript ile Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/nodejs-java/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için bunları programlı olarak kaydedin."
---
## **Overview**

Bu makale Aspose.Slides'te bir sunum oluşturmayı, ilk slaytına bir metin kutusu eklemeyi ve sonucu bir dosya olarak kaydetmeyi gösterir.

Başlamadan önce, npm üzerinden `aspose.slides.via.java` paketini, ihtiyacı olan JDK, Python ve C++ derleme araçlarıyla birlikte kurun. Bakınız [Installation](/slides/tr/nodejs-java/installation/).

## **Create a PowerPoint Presentation**

Bir sunum oluşturup ilk slaytına bir metin kutusu eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. Yeni bir sunum zaten bir boş slayt içerir.  
2. O slaytı, [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) üzerinden indeksine göre alın, 0.  
3. [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) yöntemiyle bir dikdörtgen ekleyin ve metnini [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/) ile ayarlayın.  
4. Sunumu, [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) yöntemiyle bir PPTX dosyası olarak kaydedin.  
5. Sunumu, [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) yöntemiyle serbest bırakın ve işlemi sonlandırın.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides bir Java sanal makinesinde çalışır ve Node.js'in çalışmasını sürdürür, bu yüzden işlemi açıkça sonlandırın.
process.exit(0);
```

Dikdörtgenin sol üst köşesi slaytın sol kenarından ve üst kenarından 50 puan uzakta, genişliği 400 puan ve yüksekliği 100 puandır. Kodu proje klasörünüzde *hello.js* olarak kaydedin ve `node hello.js` komutunu çalıştırın: mevcut klasöre *hello.pptx* dosyasını kaydeder; bu dosya bir slayt içerir ve içinde bu dikdörtgen ve metni barındırır.

Aspose.Slides, Node.js sürecinin içinde `java` paketi tarafından başlatılan bir Java sanal makinesinde çalışır. Bu sanal makine, betik tamamlandığında Node.js'in otomatik olarak çıkmasını engeller, bu yüzden örnek `process.exit(0)` ile sonlanır.

Lisans olmadan Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; bkz. [Licensing](/slides/tr/nodejs-java/licensing/).

## **FAQ**

### What formats can I save a new presentation to?

Sunumu [PPTX, PPT, and ODP](/slides/tr/nodejs-java/save-presentation/) formatlarında kaydedebilir ve [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/tr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) ve [images](/slides/tr/nodejs-java/convert-powerpoint-to-png/) gibi formatlara dışa aktarabilirsiniz.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [are supported](/slides/tr/nodejs-java/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

[slide size](/slides/tr/nodejs-java/slide-size/) ayarlayın (4:3 ve 16:9 gibi ön ayarlar ya da özel boyutlar) ve içeriğin nasıl ölçekleneceğini seçin.

### In what units are sizes and coordinates measured?

Puan cinsinden: 1 inç 72 birime eşittir.

### How do I handle very large presentations (with many media files) to reduce memory usage?

[BLOB management strategies](/slides/tr/nodejs-java/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Can I create/save presentations in parallel?

Aynı [Presentation](/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini birden çok [multiple threads](/slides/tr/nodejs-java/multithreading/) üzerinden çalıştıramazsınız. Her iş parçacığı ya da süreç için ayrı, izole örnekler çalıştırın.

### How do I remove the trial watermark and limitations?

Her süreçte bir kez [Apply a license](/slides/tr/nodejs-java/licensing/) uygulayın. Lisans XML dosyası değiştirilmeden kalmalı ve birden çok iş parçacığı kullanıyorsanız lisans kurulumu senkronize edilmelidir.

### Can I digitally sign the PPTX I create?

Evet. [Digital signatures](/slides/tr/nodejs-java/digital-signature-in-powerpoint/) (ekleme ve doğrulama) sunumlar için desteklenir.

### Are macros (VBA) supported in created presentations?

Evet. [create/edit VBA projects](/slides/tr/nodejs-java/presentation-via-vba/) yapabilir ve PPTM/PPSM gibi makro‑etkin dosyaları kaydedebilirsiniz.