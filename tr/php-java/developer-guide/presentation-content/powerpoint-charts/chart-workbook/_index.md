---
title: Sunumlarda Grafik Çalışma Kitaplarını PHP Kullanarak Yönetme
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
- dış çalışma kitabı
- dış veri
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişeceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirteceğinizi gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynağı olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabının nasıl oluşturulup atandığını, bir grafikle ilişkili dış çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içeren) okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sunar. **Not** grafik verilerinin aynı şekilde organize edilmesi veya kaynağa benzer bir yapıya sahip olması gerekir.

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

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden bir slayt referansı alın.  
1. Bazı verilerle bir Bubble (Balon) grafik ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.  

Bu PHP kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Bir sunum dosyasını temsil eden bir sunum sınıfının örneğini oluşturur
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

## **Veri Kaynağı Türünü Belirleme**

Bu PHP kodu, bir veri kaynağı için türün nasıl belirleneceğini gösterir:

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu [WorkbookType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/workbooktype/) enum'ı ile birlikte kullanabilirsiniz.

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

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak destekler.

### **Dış Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir dış çalışma kitabı oluşturabilir ya da bir iç çalışma kitabını dış hale getirebilirsiniz.

Bu PHP kodu, dış çalışma kitabı oluşturma sürecini gösterir:

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

### **Dış Çalışma Kitabı Ayarlama**

**`setExternalWorkbook`** yöntemini kullanarak bir dış çalışma kitabını bir grafiğin veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının yolunu (eğer taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ dış veri kaynağı olarak kullanabilirsiniz. Dış çalışma kitabı için bir göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu PHP kodu, dış bir çalışma kitabının nasıl ayarlanacağını gösterir:

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

`ChartData` parametresi (`setExternalWorkbook` yöntemi altında), bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayarı, hedef çalışma kitabı mevcut değilse veya erişilemezse kullanmak isteyebilirsiniz.  
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

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://apireference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden bir slayt referansı alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
1. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olması koşuluna göre ilgili durumu belirtin.  

Bu PHP kodu, bu işlemi gösterir:

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

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğini değiştirmeniz gibi düzenleyebilirsiniz. Bir dış çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

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

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabıysa, dış dosyanın kullanıldığından emin olmak için tam yolu okuyabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için kullanışlıdır; ancak, sunumun PPTX dosyasında mutlak yolu depolayacağını unutmayın.

**Ağ kaynakları/paylaşımlarındaki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides üzerinden düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**  
Hayır. Sunum, bir [dış dosyaya bağlantı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) depolar ve verileri okumak için bunu kullanır. Sunum kaydedildiğinde dış dosya kendisi değişmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides bağlantı sırasında bir şifre kabul etmez. Yaygın bir yöntem, korumayı önceden kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/php-java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**  
Evet. Her grafik kendi bağlantısını depolar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler veri bir sonraki yüklendiğinde her grafiğe yansır.