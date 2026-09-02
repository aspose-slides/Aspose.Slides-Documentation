---
title: PHP Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for PHP via Java'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Grafik verilerini çalışma kitabı akışları aracılığıyla okuyup yazmayı, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanmayı, çalışma sayfası koleksiyonlarına erişmeyi ve grafik değerleri için veri kaynağı türünü belirtmeyi gösterir.

Ayrıca, dış çalışma kitaplarının grafik veri kaynakları olarak kullanılması da ele alınır. Örnekler, dış bir çalışma kitabının nasıl oluşturulup atandığını, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunun nasıl alındığını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini) okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu PHP kodu örnek bir işlemi gösterir:

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

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kaydıranın indeksine göre bir slayt referansı alın.
1. Birkaç veri ile Balon chart ekleyin.
1. Grafik serilerine erişin.
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
1. Sunumu kaydedin.

Bu PHP kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Sunum dosyasını temsil eden bir sunum sınıfı örneklenir
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

Bu PHP kodu, [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getWorksheets) yönteminin bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi gösterir:

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

## **Veri Kaynağı Türünü Belirtme**

Bu PHP kodu, bir veri kaynağı için tür nasıl belirtileceğini gösterir:

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafiklerden kaçınmak için [ChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` yöntemini [WorkbookType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/workbooktype/) enum'ı ile birlikte kullanabilirsiniz.

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

    # Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
  }
} finally {
  $presentation->dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını destekler.

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak sıfırdan bir harici çalışma kitabı oluşturabilir veya iç bir çalışma kitabını harici hâle getirebilirsiniz.

Bu PHP kodu, harici çalışma kitabı oluşturma sürecini gösterir:

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

### **Harici Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** yöntemini kullanarak, bir grafiğe veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem ayrıca harici çalışma kitabının yolunu (eğer taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu kitapları hâlâ harici bir veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu PHP kodu, harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

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

`setExternalWorkbook` yöntemindeki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayarı kullanmak isteyebilirsiniz. 
* `ChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kaydıranın indeksine göre bir slayt referansı alın.
1. Grafik şekli için bir nesne oluşturun.
1. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.
1. Kaynak türünün harici çalışma kitabı veri kaynağı türü ile aynı olmasına bağlı olarak ilgili koşulu belirtin.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriklerinde değişiklik yapıyormuş gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu PHP kodu, açıklanan sürecin bir uygulamasıdır:

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

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya erişilemeyen bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. Sunumu açmadan önce [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve `true` ile [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) çağırın.

Aşağıdaki PHP örneği, grafiği mevcut olmayan bir harici çalışma kitabına referans veren bir sunumu açar ve kurtarılan verilere [Chart::getChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#getChartData) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Burada kurtarılan çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
} finally {
    $presentation->dispose();
}
```

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakıldıysa, Aspose.Slides bir istisna fırlatır. Önbelleğe alınmış grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise kurtarmayı etkinleştirin; çünkü önbellek, sunumun en son güncellenmesinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafik, bir [data source type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) özelliğine sahiptir; kaynak harici bir çalışma kitabı ise, harici bir dosyanın kullanıldığından emin olmak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için uygundur; ancak sunumun PPTX dosyasında mutlak yolu saklayacağını unutmayın.

**Ağ kaynakları/paylaşımlarındaki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides üzerinden düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar ve veri okumak için bunu kullanır. Sunum kaydedildiğinde dış dosya kendisi değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlama sırasında bir şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak veya şifresi çözülmüş bir kopya (örneğin [Aspose.Cells](/cells/php-java/)) hazırlayıp bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler veri bir sonraki yüklendiğinde her grafiğe yansır.