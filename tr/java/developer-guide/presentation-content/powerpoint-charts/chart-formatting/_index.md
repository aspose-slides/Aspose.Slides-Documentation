---
title: Java'da Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/java/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlak kenar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarındaki grafiklerin biçimlendirilmesini açıklar. Eksenler, ızgara çizgileri, başlıklar, lejandlar, çizim alanı ve duvar dolguları gibi temel grafik bileşenlerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerini ayarlama, grafik verilerine önceden tanımlı ve özel sayısal biçimler uygulama ve grafik alanı için yuvarlak köşeleri etkinleştirme konularını da gösterir. Bu örnekler, bir sunumdaki grafiklerin görsel stilini ve veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendirme**
Aspose.Slides for Java, geliştiricilerin sıfırdan slaytlarına özel grafikler eklemelerine olanak tanır. Bu makale, grafik kategori ve değer ekseni dahil olmak üzere farklı grafik varlıklarını nasıl biçimlendireceğinizi açıklar.

Aspose.Slides for Java, farklı grafik varlıklarını yönetmek ve bunları özelleştirilmiş değerlerle biçimlendirmek için basit bir API sağlar:

1. [**Presentation**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. İstenilen türden (bu örnekte ChartType.LineWithMarkers kullanılacak) bir grafik ekleyin ve varsayılan verileri sağlayın.  
1. Grafik Değer Ekseni'ni erişin ve aşağıdaki özellikleri ayarlayın:  
   1. Değer Ekseni Ana Izgara çizgileri için **Çizgi biçimi** ayarlama  
   1. Değer Ekseni Alt Izgara çizgileri için **Çizgi biçimi** ayarlama  
   1. Değer Ekseni için **Sayı Biçimi** ayarlama  
   1. Değer Ekseni için **Min, Max, Ana ve Alt birimler** ayarlama  
   1. Değer Ekseni verileri için **Metin Özellikleri** ayarlama  
   1. Değer Ekseni için **Başlık** ayarlama  
   1. Değer Ekseni için **Çizgi Biçimi** ayarlama  
1. Grafik Kategori Ekseni'ni erişin ve aşağıdaki özellikleri ayarlayın:  
   1. Kategori Ekseni Ana Izgara çizgileri için **Çizgi biçimi** ayarlama  
   1. Kategori Ekseni Alt Izgara çizgileri için **Çizgi biçimi** ayarlama  
   1. Kategori Ekseni verileri için **Metin Özellikleri** ayarlama  
   1. Kategori Ekseni için **Başlık** ayarlama  
   1. Kategori Ekseni için **Etiket Konumlandırma** ayarlama  
   1. Kategori Ekseni etiketleri için **Döndürme Açısı** ayarlama  
1. Grafik Lejandını erişin ve **Metin Özellikleri**ni ayarlayın.  
1. Grafik Lejandlarının grafikle çakışmadan gösterilmesini sağlayın.  
1. Grafik **İkincil Değer Ekseni**ni erişin ve aşağıdaki özellikleri ayarlayın:  
   1. İkincil **Değer Ekseni**ni etkinleştirin.  
   1. İkincil Değer Ekseni için **Çizgi Biçimi** ayarlama  
   1. İkincil Değer Ekseni için **Sayı Biçimi** ayarlama  
   1. İkincil Değer Ekseni için **Min, Max, Ana ve Alt birimler** ayarlama  
1. İlk grafik serisini İkincil Değer Ekseni üzerine çizin.  
1. Grafiğin arka duvar dolgu rengini ayarlayın.  
1. Grafiğin çizim alanı dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk slayta erişme
    ISlide slide = pres.getSlides().get_Item(0);

    // Örnek grafiği ekleme
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Grafik Başlığını Ayarlama
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Değer ekseni için ana ızgara çizgileri biçimini ayarlama
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Değer ekseni için alt ızgara çizgileri biçimini ayarlama
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Değer ekseni sayı biçimini ayarlama
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Grafik maksimum, minimum değerlerini ayarlama
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Değer Ekseni Metin Özelliklerini Ayarlama
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Değer ekseni başlığını ayarlama
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Kategori ekseni için ana ızgara çizgileri biçimini ayarlama
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Kategori ekseni için alt ızgara çizgileri biçimini ayarlama
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Kategori Ekseni Metin Özelliklerini Ayarlama
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Kategori Başlığını Ayarlama
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Kategori ekseni etiket konumunu ayarlama
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Kategori ekseni etiket döndürme açısını ayarlama
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Lejand Metin Özelliklerini Ayarlama
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Grafik lejandlarını çakışmadan göster
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // İkincil değer eksenini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // İkincil değer ekseni sayı biçimini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Grafik maksimum, minimum değerlerini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Grafik arka duvar rengini ayarlama
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Çizim alanı rengini ayarlama
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Sunumu Kaydet
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Java, grafik için yazı tipiyle ilgili özellikleri ayarlamayı destekler. Grafik için yazı tipi özelliklerini ayarlamak üzere aşağıdaki adımları izleyin.

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı nesnesini başlatın.  
- Slayta bir grafik ekleyin.  
- Yazı tipi yüksekliğini ayarlayın.  
- Değiştirilmiş sunumu kaydedin.

Aşağıda örnek kod verilmiştir.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sayısal Biçimi Ayarlama**
Aspose.Slides for Java, grafik veri biçimini yönetmek için basit bir API sunar:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. İstenilen türden (bu örnek **ChartType.ClusteredColumn** kullanıyor) bir grafik ekleyin ve varsayılan verileri sağlayın.  
1. Olası önceden tanımlı değerlerden birini seçerek önceden tanımlı sayı biçimini ayarlayın.  
1. Her grafik serisindeki grafik veri hücresini dolaşın ve veri sayı biçimini ayarlayın.  
1. Sunumu kaydedin.  
1. Özel sayı biçimini ayarlayın.  
1. Her grafik serisi içindeki veri hücresini dolaşarak farklı bir sayı biçimi uygulayın.  
1. Sunumu kaydedin.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk sunum slaytına eriş
    ISlide slide = pres.getSlides().get_Item(0);

    // Varsayılan küme sütun grafiği ekle
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Grafik serileri koleksiyonuna eriş
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Her grafik serisini dolaş
    for (IChartSeries ser : series) 
    {
        // Serideki her veri hücresini dolaş
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Sayı biçimini ayarla
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Sunumu kaydet
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Aşağıda, kullanılabilecek önceden tanımlı sayı biçimi değerleri, ilgili indeksleriyle birlikte listelenmiştir:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Grafik Alanı Yuvarlak Kenarlıkları Ayarlama**
Aspose.Slides for Java, grafik alanı için yuvarlak köşeleri ayarlamayı destekler. [**hasRoundedCorners**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart#hasRoundedCorners--) ve [**setRoundedCorners**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) metodları [IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChart) arayüzüne ve [Chart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Chart) sınıfına eklenmiştir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfı nesnesini başlatın.  
1. Slayta bir grafik ekleyin.  
1. Grafiğin dolgu türünü ve dolgu rengini ayarlayın.  
1. Yuvarlak köşe özelliğini **True** olarak ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek kod verilmiştir.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Sütunlar/alanlar için yarı şeffaf dolgular ayarlarken kenarı opak tutabilir miyim?**

Evet. Dolgu şeffaflığı ve kenar ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Etiketler çakıştığında ne yapmalıyım?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini (örneğin kategorileri) devre dışı bırakın, etiket ofseti/konumunu ayarlayın, gerekirse yalnızca seçili noktalara etiket gösterin veya biçimi “değer + lejand” olarak değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**

Evet. Katı ve degrade/desen dolguları genellikle kullanılabilir. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.