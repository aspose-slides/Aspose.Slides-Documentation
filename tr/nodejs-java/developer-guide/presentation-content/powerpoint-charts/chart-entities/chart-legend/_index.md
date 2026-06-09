---
title: JavaScript Kullanarak Sunumlarda Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejantı
type: docs
url: /tr/nodejs-java/chart-legend/
keywords:
- grafik lejantı
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak grafik lejantlarını özelleştirerek, PowerPoint sunumlarını özel lejant biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides PowerPoint sunumlarında grafik lejantlarını özelleştirmek için seçenekler sunar. Bu makale, bir lejantın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm lejant için yazı tipi boyutunu nasıl belirleyeceğinizi ve tek bir lejant girdisine nasıl biçimlendirme uygulayacağınızı gösterir.

Ayrıca SSS bölümünde ilgili birkaç davranışı da kapsar; lejant için alan bırakmak amacıyla örtüşme dışı modu kullanmak, uzun lejant etiketlerinin satır sonuna sarmasını veya satır sonları eklemesini sağlamak ve lejant biçimlendirmesinin, açıkça metin ve dolgu ayarları uygulanmadığında sunum temasından devralınmasını sağlamak.

## **Lejant Konumlandırma**

Lejant özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Slayta bir grafik ekleyin.
- Lejantın özelliklerini ayarlayın.
- Sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, grafik lejantının konumunu ve boyutunu ayarladık.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Slaydın referansını al
    var slide = pres.getSlides().get_Item(0);
    // Slayda bir küme sütun grafiği ekle
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Lejant özelliklerini ayarla
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Sunumu diske kaydet
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lejantın Yazı Tipi Boyutunu Ayarlama**

Aspose.Slides for Node.js via Java, geliştiricilerin lejantın yazı tipi boyutunu ayarlamasına izin verir. Aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tek Tek Lejant Girdisinin Yazı Tipi Boyutunu Ayarlama**

Aspose.Slides for Node.js via Java, geliştiricilerin tek tek lejant girdilerinin yazı tipi boyutunu ayarlamasına izin verir. Aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Lejant girdisine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Lejantı etkinleştirerek grafiğin onu otomatik olarak yer ayırmasını, üzerine binmek yerine sağlayabilir miyim?**

Evet. Örtüşme dışı modu ([setOverlay(false)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/legend/setoverlay/)) kullanın; bu durumda, çizim alanı lejantı içerecek şekilde küçülecektir.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak satır sonuna sarılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Lejantın, sunum temasının renk şemasını takip etmesini nasıl sağlarım?**

Lejant veya metni için açık renkler/dolgular/yazı tipleri ayarlamayın. Böylece tema üzerinden devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.