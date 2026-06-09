---
title: JavaScript'te Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/nodejs-java/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik nesnesi
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te JavaScript kullanarak grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarındaki grafiklerin nasıl biçimlendirileceğini açıklar. Ekseni, ızgara çizgileri, başlıkları, lejantları, çizim alanını ve duvar dolgularını özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca grafik metni için yazı tipi özelliklerini ayarlamayı, grafik verilerine ön tanımlı ve özel sayısal formatlar uygulamayı ve grafik alanı için yuvarlatılmış köşeleri etkinleştirmeyi de gösterir. Bu örnekler, bir sunumdaki grafiklerin görsel stilini ve veri sunumunu nasıl kontrol edeceğinizi ortaya koyar.

## **Grafik Nesnelerini Biçimlendirme**

Aspose.Slides for Node.js via Java, geliştiricilerin sıfırdan slaytlarına özel grafikler eklemesine olanak tanır. Bu makale, grafik kategorisi ve değer ekseni gibi farklı grafik nesnelerinin nasıl biçimlendirileceğini açıklar.

Aspose.Slides for Node.js via Java, farklı grafik nesnelerini yönetmek ve bunları özel değerlerle biçimlendirmek için basit bir API sağlar:

1. [**Presentation**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. İstenilen türde (bu örnekte ChartType.LineWithMarkers kullanılacaktır) varsayılan veriyle bir grafik ekleyin.
1. Grafiğin Değer Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Değer Ekseni Ana Izgara Çizgileri için **Satır formatını** ayarlama
   1. Değer Ekseni Küçük Izgara Çizgileri için **Satır formatını** ayarlama
   1. Değer Ekseni için **Sayı Formatını** ayarlama
   1. Değer Ekseni için **Min, Max, Ana ve Küçük birimleri** ayarlama
   1. Değer Ekseni verileri için **Metin Özelliklerini** ayarlama
   1. Değer Ekseni için **Başlığı** ayarlama
   1. Değer Ekseni için **Satır Formatını** ayarlama
1. Grafiğin Kategori Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Kategori Ekseni Ana Izgara Çizgileri için **Satır formatını** ayarlama
   1. Kategori Ekseni Küçük Izgara Çizgileri için **Satır formatını** ayarlama
   1. Kategori Ekseni verileri için **Metin Özelliklerini** ayarlama
   1. Kategori Ekseni için **Başlığı** ayarlama
   1. Kategori Ekseni için **Etiket Konumlandırmasını** ayarlama
   1. Kategori Ekseni etiketleri için **Döndürme Açısını** ayarlama
1. Grafiğin Lejantına erişin ve **Metin Özelliklerini** ayarlayın
1. Grafik Lejantının grafikle çakışmadan gösterilmesini ayarlayın
1. Grafiğin **İkincil Değer Eksenine** erişin ve aşağıdaki özellikleri ayarlayın:
   1. İkincil **Değer Eksenini** etkinleştirin
   1. İkincil Değer Ekseni için **Satır Formatını** ayarlayın
   1. İkincil Değer Ekseni için **Sayı Formatını** ayarlayın
   1. İkincil Değer Ekseni için **Min, Max, Ana ve Küçük birimleri** ayarlayın
1. Şimdi ilk grafik serisini İkincil Değer Ekseni üzerine çizin
1. Grafiğin arka duvar dolgu rengini ayarlayın
1. Grafiğin çizim alanı dolgu rengini ayarlayın
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın

```javascript
// Presentation sınıfının bir örneğini oluşturun
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişiliyor
    var slide = pres.getSlides().get_Item(0);
    // Örnek grafiği ekleme
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Grafik Başlığını Ayarlama
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Değer ekseni için Ana ızgara çizgileri formatını ayarlama
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Değer ekseni için Küçük ızgara çizgileri formatını ayarlama
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Değer ekseni sayı formatını ayarlama
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Grafik maksimum, minimum değerlerini ayarlama
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Değer Ekseni Metin Özelliklerini Ayarlama
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Değer ekseni başlığını ayarlama
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Kategori ekseni için Ana ızgara çizgileri formatını ayarlama
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Kategori ekseni için Küçük ızgara çizgileri formatını ayarlama
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Kategori Ekseni Metin Özelliklerini Ayarlama
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Kategori Başlığını Ayarlama
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Kategori ekseni etiket konumunu ayarlama
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Kategori ekseni etiket döndürme açısını ayarlama
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Lejant Metin Özelliklerini Ayarlama
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Grafik lejantlarını grafikle çakışmadan gösterme
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // İkincil değer eksenini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // İkincil değer ekseni Sayı formatını ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Grafik maksimum, minimum değerlerini ayarlama
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Grafik arka duvar rengini ayarlama
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Çizim alanı rengini ayarlama
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Sunumu Kaydet
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**

Aspose.Slides for Node.js via Java, grafik için yazı tipi ile ilgili özelliklerin ayarlanmasını destekler. Grafik için yazı tipi özelliklerini ayarlamak için aşağıdaki adımları izleyin.

- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı nesnesinin bir örneğini oluşturun.
- Slayda bir grafik ekleyin.
- Yazı tipi yüksekliğini ayarlayın.
- Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek verilmiştir.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sayısal Formatı Ayarlama**

Aspose.Slides for Node.js via Java, grafik veri formatını yönetmek için basit bir API sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. İstenilen türde (bu örnek **ChartType.ClusteredColumn** kullanır) varsayılan veriyle bir grafik ekleyin.
1. Olası ön ayar değerlerinden birini seçerek ön tanımlı sayı formatını ayarlayın.
1. Her grafik serisindeki grafik veri hücresini dolaşarak grafik veri sayı formatını ayarlayın.
1. Sunumu kaydedin.
1. Özel sayı formatını ayarlayın.
1. Her grafik serisindeki veri hücresini dolaşarak farklı bir grafik veri sayı formatı belirleyin.
1. Sunumu kaydedin.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // İlk sunum slaydına eriş
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan küme sütun grafiği ekleniyor
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Grafik seri koleksiyonuna erişiliyor
    var series = chart.getChartData().getSeries();
    // Her bir grafik serisi üzerinden dolaş
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Serideki her veri hücresi üzerinde dolaş
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Sayı formatı ayarlanıyor
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Sunumu kaydet
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Aşağıda ön tanımlı sayı formatı değerleri, indeksleri ve kullanılabilecekleri listelenmiştir:

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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Grafik Alanı Yuvarlatılmış Kenarları Ayarlama**

Aspose.Slides for Node.js via Java, grafik alanı için yuvarlatılmış köşe ayarlarını destekler. [**hasRoundedCorners**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) ve [**setRoundedCorners**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) metodları [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart) sınıfına eklenmiştir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slayda bir grafik ekleyin.
1. Grafiğin dolgu türünü ve dolgu rengini ayarlayın
1. Yuvarlatılmış köşe özelliğini **True** olarak ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek verilmiştir.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Sütunların/alanların kenarını opak tutarken yarı saydam dolgu ayarlayabilir miyim?**

Evet. Dolgu şeffaflığı ve kontur ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verinin okunabilirliğini artırmaya yardımcı olur.

**Etiketler çakıştığında nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin kategoriler), etiket kaydırmasını/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya formatı “değer + lejant” olarak değiştirin.

**Serilere degrade veya desen dolgusu uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen dolguları genellikle mevcuttur. Pratikte, degrade kullanımını sınırlı tutun ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.

---
title: JavaScript'te Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/nodejs-java/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik nesnesi
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te JavaScript kullanarak grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---