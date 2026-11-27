---
title: Android'de Sunum Grafiklerini Biçimlendir
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/androidjava/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik formatlama
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
description: "Java aracılığıyla Android için Aspose.Slides'te grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı formatları ve yuvarlatılmış grafik kenarları ile PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Grafik verilerinin görünümünü ve okunabilirliğini artırmak için eksenler, ızgara çizgileri, başlıklar, lejantlar, çizin alanı ve duvar dolgu gibi temel grafik öğelerinin nasıl özelleştirileceğini gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerinin nasıl ayarlanacağını, grafik verilerine önceden tanımlı sayısal biçimlerin nasıl uygulanacağını ve grafik alanı için yuvarlatılmış köşelerin nasıl etkinleştirileceğini gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edileceğini gösterir.

Yükselen ve düşen aralıklar için ayrı dolgu ve kenarlıklar hakkında, [hisse senedi grafik örneği](/slides/tr/androidjava/create-chart/#create-stock-charts) bölümüne bakın.

## **Grafik Varlıklarını Biçimlendir**

Grafik başlıklarını, eksenleri, ızgara çizgilerini, lejantları ve çizin alanını biçimlendirmek için [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) kullanın. Bu örnek, işaretçiler ve varsayılan veri ile bir çizgi grafiği oluşturur, ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları nokta cinsinden belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) kullanır. Ölçeği -2 ile 15 arasında, büyük aralıkları 2 ve küçük aralıkları 0.5 olarak ayarlanmıştır. Örnek ayrıca, yüzde biçimlendirmesini [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) binlere ayarlanmış olarak birleştirir; bu ayarları verinizin anlamına ve büyüklüğüne göre uyarlayın. Lejant, [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) `false` ile çağrıldığı için çizin alanının dışında kalır. Arka duvar ve zemin dolguları [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) ve [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) aracılığıyla yapılandırılır, ancak bu yüzeyler yalnızca 3B grafiklerde görülür.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarla**

Grafik metni için varsayılan yazı tipi boyutunu [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) aracılığıyla ayarlayın. Örnek, 20 nokta yazı tipine sahip bir gruplanmış sütun grafiği oluşturur ve ilk seri için değer etiketlerini [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ile etkinleştirir. Kendi açık yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanını geçersiz kılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grafik Lejantı İçin Metin Çerçevesi Biçimlendirmesini Yeniden Kullan**

Lejantı bir slayt başlığıyla eşleştirmek için, ilk paragrafta başlığın yazı tipini [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aracılığıyla ayarlayın. Lejantın [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) tarafından döndürülen format üzerinde [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) çağırın. Bu, metin çerçevesi ayarlarını, ilk paragrafın biçimini ve o paragrafın varsayılan yazı tipi özelliklerini kopyalar. Doğrudan bireysel bölümlere veya sonraki paragraflara uygulanan biçimlendirme, kaynağa özgü kalır.

Örnek, şablon olarak lacivertte kalın, 26 nokta Calibri başlık kullanır. Lejantı biçimlendirdikten sonra, aynı biçimlendirmeyi ayrı bir altyazıya uygulamak için [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) çağırır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunumda, lejant ve altyazı boyut, kalınlık ve renk açısından başlıkla eşleşir. Lejant, seri adlarını göstermeye devam eder ve altyazı kendi metnini korur. Altyazıdaki bir bölüm zaten açık bir yazı tipi boyutuna sahipse, bu boyut kopyalanan paragraf varsayılanının üzerine yazılır.

| Kopyalamadan önce | Kopyaladıktan sonra |
| --- | --- |
| ![Düzenli siyah lejant etiketleri ve siyah altyazı ile çeyrek dönem satış grafiği](legend-formatting-before.png) | ![Aynı grafik, daha büyük, kalın lacivert lejant etiketleri ve eşleşen altyazı ile](legend-formatting.png) |

## **Sayısal Biçimi Ayarla**

Grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulamak için [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) kullanın. Bu örnek, varsayılan hücre tabanlı verilerle bir gruplanmış sütun grafiği oluşturur ve her seri değer hücresine format indeksi 10 (`0.00%`) uygular. Bu, temel sayıları değiştirmeden değerlerin çalışma kitabında nasıl gösterileceğini değiştirir; örneğin 0.25, %25.00 olarak gösterilir. Eksen ve veri etiketi biçimleri ayrı ayrı yapılandırılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki tablo, İngilizce (Amerika Birleşik Devletleri) yerel ayarı için temsilci Excel biçimleriyle yerleşik sayı formatı indekslerini listeler. Tam biçim dizgileri ve gösterimleri uygulama ve yere göre değişebilir, özellikle para birimi ve tarih formatları için. Bazı Excel biçimleri, [Microsoft'un sayı formatı uygulama notlarında](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) açıklandığı gibi OOXML standardındaki varsayılanlardan da farklıdır.

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Grafik Alanı Yuvarlatılmış Kenarlar Ayarla**

[IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) `true` ile çağırarak grafik alanının köşelerini yuvarlatın. Örnek, bir gruplanmış sütun grafiği oluşturur ve kaydetmeden önce çerçevesine katı gri renk ve tek çizgi stili vermek için [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) kullanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mevcut Grafik Açıklamalarını Düzenle**

Bir grafik, bir raporun durumunu açıklayan metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) aracılığıyla erişin; aynı zamanda Chart API Referansında [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) altında listelenir. [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) tarafından döndürülen koleksiyon, grafik sahipliğindeki şekilleri içerir.

Grafiğin üzerine yerleştirilen sıradan bir metin kutusu, grafik parçası gibi görünse bile slayta aittir. [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) üzerinde yineleme yaparak grafiği ve sıradan slayt şekillerini bulur, ancak grafiğin içindeki bireysel şekilleri listeler. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyonda özel açıklama olarak yer almaz.

Uygulamanın çalışma dizinine [chart-annotations.pptx](chart-annotations.pptx) dosyasını indirin ve koyun. İlk slaytı, "Preliminary results" metninde bir ayrılmış açıklama, grafik sahipliğinde bir çizgi ve "Slide overlay" metninde bir sıradan slayt metin kutusu içeren bir grafik içerir. Örnek, o slayttaki ilk grafiği bulur ve rapor yayınlanmaya hazır olduğunda açıklamayı "Final results" olarak değiştirir. Boş bir koleksiyon olup olmadığını kontrol eder ve yalnızca [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) içinde, [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) tarafından döndürülen null olmayan bir metin çerçevesi ve beklenen metin bulunanları düzenler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Çizgi ve slayt metin kutusu değişmeden kalır. Aşağıdaki görseller giriş ve kaydedilip yeniden açılmış sonucu gösterir:

| Düzenleme Öncesi | Düzenleme Sonrası |
| --- | --- |
| ![Preliminary results okuyan grafik açıklaması](chart-annotations-before.png) | ![Final results okuyan grafik açıklaması](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca üst düzey grafik sahipliğindeki şekilleri inceler. Bir açıklama bir [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) içinde ise, o grubun [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) koleksiyonunu da inceleyin. İç içe gruplar için bu süreci yineleyin ve aynı metin kontrollerini alt şekillerine uygulayın. Bir grup kendisi bir kapsayıcıdır; onu bir metin kutusu gibi ele almayın.
{{% /alert %}}

## **SSS**

**Sütunlar/alanlar için yarı saydam dolgu ayarlarken kenarı opak tutabilir miyim?**

Evet. Dolgu saydamlığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verinin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste bindiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu azaltın, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiketleri gösterin veya formatı "değer + lejant" olarak değiştirin.

**Serilere degrade veya desen dolgular uygulayabilir miyim?**

Evet. Seriler katı, degrade ve desen dolgularını destekler. Uygulamada, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.