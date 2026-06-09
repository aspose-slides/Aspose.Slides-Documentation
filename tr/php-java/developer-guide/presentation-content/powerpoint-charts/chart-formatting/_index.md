---
title: PHP'de Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/php-java/chart-formatting/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile grafik biçimlendirmeyi öğrenin ve profesyonel, göz alıcı stillerle PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Eksenler, ızgara çizgileri, başlıklar, açıklamalar, çizim alanı ve duvar dolgu gibi temel grafik öğelerinin nasıl özelleştirileceğini göstererek grafik verilerinin görünümünü ve okunabilirliğini artırır.

Ayrıca, grafik metni için yazı tipi özelliklerini ayarlamayı, grafik verilerine önceden tanımlı ve özel sayısal biçimler uygulamayı ve grafik alanı için yuvarlatılmış köşeleri etkinleştirmeyi gösterir. Bu örnekler, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendirme**
Aspose.Slides for PHP via Java, geliştiricilerin sıfırdan özel grafikler eklemesine olanak tanır. Bu makale, grafik kategori ve değer ekseni dahil olmak üzere farklı grafik varlıklarını nasıl biçimlendireceğinizi açıklar.

Aspose.Slides for PHP via Java, farklı grafik varlıklarını yönetmek ve özelleştirilmiş değerlerle biçimlendirmek için basit bir API sağlar:

1. Bir [**Presentation**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. İstenilen türden bir grafik ekleyin (bu örnekte ChartType::LineWithMarkers kullanılacaktır).
1. Grafik Değer Ekseni'ne erişin ve aşağıdaki özellikleri ayarlayın:
   1. Değer Ekseni Büyük Izgara çizgileri için **Satır biçimi** ayarlama
   1. Değer Ekseni Küçük Izgara çizgileri için **Satır biçimi** ayarlama
   1. Değer Ekseni için **Sayı Biçimi** ayarlama
   1. Değer Ekseni için **Min, Max, Büyük ve Küçük birimler** ayarlama
   1. Değer Ekseni verileri için **Metin Özellikleri** ayarlama
   1. Değer Ekseni için **Başlık** ayarlama
   1. Değer Ekseni için **Satır Biçimi** ayarlama
1. Grafik Kategori Ekseni'ne erişin ve aşağıdaki özellikleri ayarlayın:
   1. Kategori Ekseni Büyük Izgara çizgileri için **Satır biçimi** ayarlama
   1. Kategori Ekseni Küçük Izgara çizgileri için **Satır biçimi** ayarlama
   1. Kategori Ekseni verileri için **Metin Özellikleri** ayarlama
   1. Kategori Ekseni için **Başlık** ayarlama
   1. Kategori Ekseni için **Etiket Konumlandırma** ayarlama
   1. Kategori Ekseni etiketleri için **Dönme Açısı** ayarlama
1. Grafik Açıklaması'na erişin ve **Metin Özellikleri**'ni ayarlayın
1. Grafik açıklamalarını grafikle çakışmayacak şekilde gösterin
1. Grafik **İkincil Değer Ekseni**'ne erişin ve aşağıdaki özellikleri ayarlayın:
   1. İkincil **Değer Ekseni**'ni etkinleştir
   1. İkincil Değer Ekseni için **Satır Biçimi** ayarlama
   1. İkincil Değer Ekseni için **Sayı Biçimi** ayarlama
   1. İkincil Değer Ekseni için **Min, Max, Büyük ve Küçük birimler** ayarlama
1. İlk grafik serisini İkincil Değer Ekseni üzerinde çizin
1. Grafiğin arka duvar dolgu rengini ayarlayın
1. Grafiğin çizim alanı dolgu rengini ayarlayın
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # İlk slayta erişme
    $slide = $pres->getSlides()->get_Item(0);
    # Örnek grafiği ekleme
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Grafik Başlığını Ayarlama
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Değer ekseni için büyük ızgara çizgileri biçimini ayarlama
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Değer ekseni için küçük ızgara çizgileri biçimini ayarlama
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Değer ekseni sayı biçimini ayarlama
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Grafiğin maksimum, minimum değerlerini ayarlama
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Değer Ekseni Metin Özelliklerini Ayarlama
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Değer ekseni başlığını ayarlama
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Kategori ekseni için büyük ızgara çizgileri biçimini ayarlama
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Kategori ekseni için küçük ızgara çizgileri biçimini ayarlama
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Kategori Ekseni Metin Özelliklerini Ayarlama
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Kategori Başlığını Ayarlama
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Kategori ekseni etiket konumunu ayarlama
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Kategori ekseni etiket dönüş açısını ayarlama
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Açıklama Metin Özelliklerini Ayarlama
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Grafiğin açıklamaları çakışmadan gösterilsin
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # İkincil değer eksenini ayarlama
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # İkincil değer ekseni sayı biçimini ayarlama
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Grafiğin maksimum, minimum değerlerini ayarlama
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Grafiğin arka duvar rengini ayarlama
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Çizim alanı rengini ayarlama
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Sunumu Kaydet
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for PHP via Java, grafik için yazı tipiyle ilgili özellikleri ayarlama desteği sağlar. Grafik için yazı tipi özelliklerini ayarlamak için aşağıdaki adımları izleyin.

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı nesnesi oluşturun.
- Slayta bir grafik ekleyin.
- Yazı tipi yüksekliğini ayarlayın.
- Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sayısal Biçimi Ayarlama**
Aspose.Slides for PHP via Java, grafik veri biçimini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. İstenilen türden bir grafik ekleyin (bu örnek **ChartType::ClusteredColumn** kullanır).
1. Olabilir önceden tanımlı sayı biçimlerinden birini ayarlayın.
1. Her grafik serisindeki grafik veri hücresinde dolaşarak grafik veri sayı biçimini ayarlayın.
1. Sunumu kaydedin.
1. Özel sayı biçimini ayarlayın.
1. Her grafik serisindeki veri hücresinde dolaşarak farklı bir sayı biçimi ayarlayın.
1. Sunumu kaydedin.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    # İlk sunum slaytına eriş
    $slide = $pres->getSlides()->get_Item(0);
    # Varsayılan gruplanmış sütun grafiği ekleme
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Grafik serileri koleksiyonuna erişme
    $series = $chart->getChartData()->getSeries();
    # Her grafik serisi üzerinden dolaşma
    foreach($series as $ser) {
      # Serideki her veri hücresi üzerinden dolaşma
      foreach($ser->getDataPoints() as $cell) {
        # Sayı biçimini ayarlama
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # Sunumu kaydetme
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Kullanılabilecek olası önceden tanımlı sayı biçimi değerleri, ilgili indeksleriyle birlikte aşağıda verilmiştir:

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

## **Grafik Alanı Yuvarlatılmış Kenarlar Ayarlama**
Aspose.Slides for PHP via Java, grafik alanını ayarlama desteği sağlar. **hasRoundedCorners** ve **setRoundedCorners** yöntemleri [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Chart) sınıfına eklenmiştir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin dolgu tipini ve dolgu rengini ayarlayın.
1. Yuvarlatılmış köşe özelliğini **True** olarak ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Sütunlar/alanlar için yarı saydam dolgu ayarlarken kenarı opak tutabilir miyim?**

Evet. Dolgu şeffaflığı ve kenar ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için yararlıdır.

**Etiketler çakıştığında nasıl başa çıkabilirim?**

Yazı tipi boyutunu azaltın, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket ofsetini/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiketleri gösterin veya biçimi “değer + açıklama” şeklinde değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen dolgular genellikle mevcuttur. Uygulamada degradeleri sınırlı kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.