---
title: PHP Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetin
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/php-java/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme konularını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynağı olarak kullanmayı kapsar. Örnekler, harici bir çalışma kitabını nasıl oluşturup atayacağınızı, bir grafikle ilişkili harici çalışma kitabının yolunu nasıl alacağınızı ve çalışma kitabı mevcut olduğunda grafik verilerini nasıl düzenleyeceğinizi gösterir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, [readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar; bu yöntemler, (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) grafik veri çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu PHP kodu bir örnek işlemi gösterir:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart::validateChartLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/validatechartlayout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```php
// Çalışma kitabı akışı değiştirildikten sonra (ör. Aspose.Cells kullanarak)
$updatedWorkbook = $chartData->readWorkbookStream();

// Mevcut veri referanslarını temizleyin.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar; böylece `validateChartLayout` hatasız tamamlanır.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden bir slayt referansı alın.  
1. Bazı veriler içeren bir Bubble grafiği ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.

Bu PHP kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Sunum dosyasını temsil eden bir sunum sınıfını örnekler
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Çalışma Sayfalarını Yönetme**

Bu PHP kodu, [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getWorksheets) metodunun bir çalışma sayfası koleksiyonuna nasıl erişileceğini gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veri Kaynağı Tipini Belirtme**

Bu PHP kodu bir veri kaynağı için tipin nasıl belirtileceğini gösterir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/workbooktype/) enumarasyonunu kullanabilirsiniz.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
      continue;
    }

    # Burada grafik çalışma kitabı verilerini okuyun veya değiştirin.
  }
} finally {
  $presentation->dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını destekler.

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını harici hâle getirebilirsiniz.

Bu PHP kodu harici çalışma kitabı oluşturma sürecini gösterir:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Harici Çalışma Kitabı Atama**

**`setExternalWorkbook`** metodunu kullanarak bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu (yolu taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Harici çalışma kitabı için bir göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu PHP kodu bir harici çalışma kitabını nasıl atayacağınızı gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`setExternalWorkbook` metodundaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirlemek için kullanılır.  

* `ChartData` değeri **false** olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayar kullanılabilir.  
* `ChartData` değeri **true** olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden bir slayt referansı alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) kaynak türü nesnesini oluşturun.  
1. Kaynak türü, harici çalışma kitabı veri kaynağı türü ile aynı olduğunda ilgili koşulu belirtin.

Bu PHP kodu işlemi gösterir:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Sunumu kaydeder
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitapları gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu PHP kodu açıklanan sürecin bir uygulamasıdır:

```php
  # Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya ulaşılabilir olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumdaki önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu çağırın.

Aşağıdaki PHP örneği, bir grafik tarafından referans edilen erişilemez bir harici çalışma kitabına sahip bir sunumu açar ve kurtarılan verileri [Chart::getChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#getChartData) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
} finally {
    $presentation->dispose();
}
```

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Kurtarmayı yalnızca önbellekteki grafik verilerini kullanmanın kabul edilebilir bir geri dönüş olduğu durumlarda etkinleştirin; çünkü önbellek, sunum son güncellendiğinde harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı tipi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**  
Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunum, mutlak yolu PPTX dosyasında saklar.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides'tan uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez—sadece kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides harici XLSX'i üzerinize yazıyor mu?**  
Hayır. Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar ve veriyi okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde harici dosya değişmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresiz bir kopya (örneğin [Aspose.Cells](/cells/php-java/) ile) hazırlayıp o kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede tüm grafiklerde yansır.