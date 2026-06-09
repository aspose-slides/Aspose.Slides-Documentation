---
title: Android'de Sunumlarda Grafik Açıklamalarını Özelleştir
linktitle: Grafik Açıklaması
type: docs
url: /tr/androidjava/chart-legend/
keywords:
- grafik açıklaması
- açıklama konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile grafik açıklama bölümlerini özelleştirerek, PowerPoint sunumlarını özel açıklama biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında grafik açıklama bölümlerini özelleştirme seçenekleri sunar. Bu makale, bir açıklamanın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm açıklamanın yazı tipi boyutunu nasıl belirleyeceğinizi ve tek bir açıklama girişine nasıl biçimlendirme uygulayacağınızı gösterir.

Ayrıca SSS bölümünde, açıklamanın yer alması için grafik alanının yer açması amacıyla örtüşme dışı (non‑overlay) modunun kullanılması, uzun açıklama etiketlerinin satır sonu ile kaydırılması veya satır sonu karakteriyle bölünebilmesi ve açıklama biçimlendirmesinin, açıkça metin ve dolgu ayarları uygulanmadığında sunum temasından devralınması gibi ilgili davranışlar ele alınmaktadır.

## **Açıklama Konumlandırma**
Açıklama özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Slayta bir grafik ekleyin.
- Açıklama özelliklerini ayarlayın.
- Sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, Grafik açıklamasının konumunu ve boyutunu ayarladık.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Slayın referansını al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Slayta bir kümeleme sütun grafiği ekle
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Açıklama Özelliklerini Ayarla
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Sunumu diske kaydet
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for Android via Java, geliştiricilerin açıklamanın yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske kaydedin.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tek Bir Açıklamanın Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for Android via Java, geliştiricilerin tek tek açıklama girişlerinin yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Açıklama girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske kaydedin.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Grafiğin açıklamayı otomatik olarak yer ayırmasını, üzerine bindirmek yerine etkinleştirebilir miyim?**

Evet. Örtüşme dışı modu kullanın ([setOverlay(false)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); bu durumda, grafik alanı açıklamayı barındıracak şekilde küçülür.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak kaydırılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Açıklamanın sunum temasının renk şemasını izlemesini nasıl sağlayabilirim?**

Açıklama veya metni için açık renkler/dolgular/yazı tipleri ayarlamayın. Böylece tema tarafından devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.