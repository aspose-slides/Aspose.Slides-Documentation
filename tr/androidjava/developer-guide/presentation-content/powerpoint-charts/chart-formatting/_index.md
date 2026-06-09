---
title: Android'de Sunum Grafiklerini Biçimlendir
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/androidjava/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir tarzla yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Ekseni, ızgara çizgileri, başlıklar, lejandlar, çizim alanı ve duvar doldurmaları gibi temel grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir. Ayrıca grafik metni için yazı tipi özelliklerini ayarlamayı, grafik verilerine önceden tanımlı ve özel sayısal formatları uygulamayı ve grafik alanı için yuvarlatılmış köşeleri etkinleştirmeyi de gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin görsel stilini ve veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendirme**
Aspose.Slides for Android via Java, geliştiricilerin sıfırdan slaytlarına özel grafikler eklemesine olanak tanır. Bu makale, grafik kategori ve değer ekseni dahil olmak üzere farklı grafik varlıklarını nasıl biçimlendireceğinizi açıklar.

Aspose.Slides for Android via Java, farklı grafik varlıklarını yönetmek ve bunları özel değerlerle biçimlendirmek için basit bir API sağlar:

1. Bir [**Presentation**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayd referansı alın.
1. İstenilen türde (bu örnekte ChartType.LineWithMarkers kullanacağız) varsayılan veriyle bir grafik ekleyin.
1. Grafiğin Değer Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Değer Ekseni Ana Izgara Çizgileri için **Line format** ayarlama
   1. Değer Ekseni Alt Izgara Çizgileri için **Line format** ayarlama
   1. Değer Ekseni için **Number Format** ayarlama
   1. Değer Ekseni için **Min, Max, Major and Minor units** ayarlama
   1. Değer Ekseni verileri için **Text Properties** ayarlama
   1. Değer Ekseni için **Title** ayarlama
   1. Değer Ekseni için **Line Format** ayarlama
1. Grafiğin Kategori Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Kategori Ekseni Ana Izgara Çizgileri için **Line format** ayarlama
   1. Kategori Ekseni Alt Izgara Çizgileri için **Line format** ayarlama
   1. Kategori Ekseni verileri için **Text Properties** ayarlama
   1. Kategori Ekseni için **Title** ayarlama
   1. Kategori Ekseni için **Label Positioning** ayarlama
   1. Kategori Ekseni etiketleri için **Rotation Angle** ayarlama
1. Grafiğin Legend'e erişin ve **Text Properties** ayarlayın
1. Grafik Legendını çakışma olmadan göster
1. Grafiğin **Secondary Value Axis** (İkincil Değer Ekseni) erişin ve aşağıdaki özellikleri ayarlayın:
   1. İkincil **Value Axis** (Değer Ekseni) etkinleştir
   1. İkincil Değer Ekseni için **Line Format** ayarlama
   1. İkincil Değer Ekseni için **Number Format** ayarlama
   1. İkincil Değer Ekseni için **Min, Max, Major and Minor units** ayarlama
1. Şimdi ilk grafik serisini İkincil Değer Ekseni üzerine çizin
1. Grafik arka duvar dolgu rengini ayarlayın
1. Grafik çizim alanı dolgu rengini ayarlayın
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk slayta erişim
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

    // Değer ekseni için Ana ızgara çizgileri biçimini ayarlama
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Değer ekseni için Alt ızgara çizgileri biçimini ayarlama
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Değer ekseni sayı biçimini ayarlama
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Grafiğin maksimum, minimum değerlerini ayarlama
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

    // Kategori ekseni için Ana ızgara çizgileri biçimini ayarlama
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Kategori ekseni için Alt ızgara çizgileri biçimini ayarlama
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

    // Kategori ekseni etiket dönüş açısını ayarlama
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Lejant Metin Özelliklerini Ayarlama
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Grafikle çakışmadan lejantları göster

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

    // Grafiğin maksimum, minimum değerlerini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Grafiğin arka duvar rengini ayarlama
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

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Android via Java, grafik için yazı tipiyle ilgili özellikleri ayarlamayı destekler. Aşağıdaki adımları izleyerek grafik için yazı tipi özelliklerini ayarlayın.

- Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıf nesnesi oluşturun.
- Slayta bir grafik ekleyin.
- Yazı tipi yüksekliğini ayarlayın.
- Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek verilmektedir.

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

## **Sayısal Formatı Ayarlama**
Aspose.Slides for Android via Java, grafik veri formatını yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayd referansı alın.
1. İstenilen türde (bu örnek **ChartType.ClusteredColumn** kullanır) varsayılan veriyle bir grafik ekleyin.
1. Olabilecek önceden tanımlı değerlerden bir ön ayarlı sayı formatı ayarlayın.
1. Her grafik serisindeki grafik veri hücresinde dolaşarak grafik veri sayı formatını ayarlayın.
1. Sunumu kaydedin.
1. Özel sayı formatını ayarlayın.
1. Her grafik serisinin içindeki veri hücresinde dolaşarak farklı bir grafik veri sayı formatı ayarlayın.
1. Sunumu kaydedin.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // İlk sunum slaytına erişim
    ISlide slide = pres.getSlides().get_Item(0);

    // Varsayılan kümelenmiş sütun grafiği ekleme
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Grafik serileri koleksiyonuna erişim
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Tüm grafik serileri boyunca dolaşma
    for (IChartSeries ser : series) 
    {
        // Serideki her veri hücresi boyunca dolaşma
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Sayı formatını ayarlama
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Sunumu kaydetme
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Kullanılabilecek olası önceden tanımlı sayı formatı değerleri ve bunların indeksleri aşağıda verilmiştir:

|**0**|Genel|
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

## **Grafik Alanı Yuvarlatılmış Kenarlıkları Ayarlama**
Aspose.Slides for Android via Java, grafik alanını ayarlama desteği sağlar. [**hasRoundedCorners**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) ve [**setRoundedCorners**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) yöntemleri [IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChart) arabirimi ve [Chart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Chart) sınıfına eklenmiştir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıf nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin doldurma türünü ve doldurma rengini ayarlayın
1. Yuvarlatılmış köşe özelliğini True yapın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek verilmektedir.  

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

**Sütunlar/alanlar için yarı saydam doldurmaları kenarı opak tutarak ayarlayabilir miyim?**

Evet. Dolgu şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Etiketler çakıştığında veri etiketleriyle nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket ofsetini/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya formatı "değer + lejand" olarak değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen dolgular genellikle mevcuttur. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.