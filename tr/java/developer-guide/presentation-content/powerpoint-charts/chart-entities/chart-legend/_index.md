---
title: Java Kullanarak Sunumlarda Grafik Açıklama Kutularını Özelleştirme
linktitle: Grafik Açıklama Kutusu
type: docs
url: /tr/java/chart-legend/
keywords:
- grafik açıklama kutusu
- açıklama kutusu konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile grafik açıklama kutularını özelleştirerek, PowerPoint sunumlarını özel açıklama kutusu biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında grafik açıklama kutularını özelleştirme seçenekleri sunar. Bu makale, bir açıklama kutusunun konumlandırılması ve boyutlandırılması, tüm açıklama kutusunun yazı tipi boyutunun ayarlanması ve tek bir açıklama kutusu girişine biçimlendirme uygulanmasını gösterir.

Ayrıca SSS bölümünde, açıklama kutusuna yer açmak için bindirme (overlay) modunun kullanılmaması, uzun açıklama etiketlerinin otomatik olarak satır başına kaydırılması veya satır sonu karakterleriyle zorlanması ve açıklama kutusunun biçimlendirmesinin, açıkça metin ve dolgu ayarları belirtilmediğinde sunum temasından devralınması gibi ilgili davranışlar ele alınmaktadır.

## **Açıklama Kutusu Konumlandırma**
Açıklama kutusu özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Slayta bir grafik ekleyin.
- Açıklama kutusunun özelliklerini ayarlayın.
- Sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, grafik açıklama kutusu için konum ve boyut ayarlanmıştır.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Slaydın referansını al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Slayta bir kümelenmiş sütun grafik ekle
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Açıklama Kutusu Özelliklerini Ayarla
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

## **Bir Açıklama Kutusunun Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for Java, geliştiricilerin açıklama kutusunun yazı tipi boyutunu ayarlamasına izin verir. Lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

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

## **Bireysel Bir Açıklama Kutusu Girişinin Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for Java, geliştiricilerin bireysel açıklama kutusu girişlerinin yazı tipi boyutunu ayarlamasına izin verir. Lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Açıklama kutusu girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske yazın.

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

**Açıklama kutusunu etkinleştirerek grafiğin üzerine bindirmek yerine otomatik olarak alan ayırmasını sağlayabilir miyim?**

Evet. Bindirmeme modunu kullanın ([setOverlay(false)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/legend/#setOverlay-boolean-)); bu durumda, çizim alanı açıklama kutusuna yer açacak şekilde küçülür.

**Açıklama kutusu etiketlerini çok satırlı yapabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak satır başına kaydırılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Açıklama kutusunun sunum temasının renk şemasını takip etmesini nasıl sağlayabilirim?**

Açıklama kutusu veya metni için açıkça renk, dolgu veya yazı tipi ayarlamayın. Bu durumda, tema üzerinden devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.