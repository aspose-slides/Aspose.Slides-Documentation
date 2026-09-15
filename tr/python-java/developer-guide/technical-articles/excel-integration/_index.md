---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/python-java/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel oku
- Excel'i entegre et
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'den PowerPoint'e
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "ExcelDataWorkbook API'sini kullanarak Java üzerinden Python için Aspose.Slides içinde Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış veri kaynağı olarak mükemmel iken PowerPoint bu verileri izleyiciye görselleştirmede üstünlüğe sahiptir.

Excel ve PowerPoint'in birleştirilmesinin gerekli olduğu birçok pratik senaryo vardır: postala birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt oluşturma), eğitim materyalleri hazırlama ve birden çok Excel raporunu tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için gereğinden fazla karmaşık ve maliyetli olabiliyor.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve akıcı hâle getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma içe aktarma için yeni sınıflar sundu. Bu özellik, sunum iş akışları içinde Excel'i veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni imkanlar açıyor.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM) içine entegre edilmemiştir. Bu, *Excel dosyalarını düzenleme veya kaydetme* imkanı sağlamaz — yalnızca çalışma kitaplarını açmak ve içeriklerinde gezerek hücre verilerini almak için vardır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/exceldataworkbook/) sınıfı bulunur. Bu sınıf, yerel bir dosyadan veya bir akıştan Excel çalışma kitabı yüklemenize olanak tanır. Yüklendikten sonra, [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/exceldataworkbook/#getCell) metodunun birkaç aşırı yüklemesini kullanarak belirli hücreleri konumlarına (örn. satır ve sütun indeksleri ya da adlandırılmış aralıklar) göre alabilirsiniz.

Her [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/exceldataworkbook/#getCell) çağrısı bir [ExcelDataCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/exceldatacell/) nesnesi döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Bir Excel Şeması İçe Aktar**

İşlevselliği genişletmenin bir sonraki adımı, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma içe aktarma işlevi sunar. [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metodunun çeşitli aşırı yüklemeleri, belirtilen Excel çalışma kitabından seçilen şemayı alıp verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemenize yardımcı olur.

#### **Bir Excel Tablosu İçe Aktar**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/excelworkbookimporter/) sınıfı ayrıca [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) metodunun çeşitli aşırı yüklemelerini içerir. Bu yöntemler, belirli bir çalışma sayfasından belirtilen hücre aralığını içe aktarmanıza ve verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda bir tablo olarak eklemenize olanak tanır.

Özetle, bu, tam bir elektronik tablo işleme kütüphanesinin getirdiği yük olmadan, birçok geliştiricinin ihtiyaç duyduğu Excel verilerini okumak için hafif ve doğrudan bir API'dir.

## **Kod Yazalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verileri temel alarak birden çok sunum üreten basit bir posta birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:

1. Veriyi içeren bir Excel çalışma kitabı

![Excel data example](example1_image0.png)

2. Bir PowerPoint sunum şablonu

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Çalışan verileri içeren Excel çalışma kitabını yükle.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Sunum şablonunu yükle.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Excel satırları üzerinde döngü oluştur (0. satırdaki başlığı hariç).
    for row_index in range(1, 5):

        # Her çalışan kaydı için bir sunum oluştur.
        employee_presentation = Presentation()

        try:
            # Varsayılan boş slaytı kaldır.
            employee_presentation.getSlides().removeAt(0)

            # Şablon slaytı sunuma kopyala.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Hedef şekilden paragrafları al (şekil indeksinin 1 olduğu varsayılır).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Yer tutucuları Excel'deki verilerle değiştir.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundan verileri kopyalayıp PowerPoint slaytında daha görsel olarak çekici bir biçimde gösteriyoruz.

Bu örnekte, aynı Excel çalışma kitabını yeniden kullanıyoruz; bu kitap basit bir çalışan tablosu içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Çalışan verilerini içeren Excel çalışma kitabını yükle.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# PowerPoint sunumu oluştur.
presentation = Presentation()

try:
    # İlk slayta bir tablo şekli ekle.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # PowerPoint tablosunu Excel çalışma kitabından gelen verilerle doldur.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Excel Şeması İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir şema içe aktarıyoruz. Şema, sonuç sunumda harici çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayanarak Excel çalışma kitabına bir pasta şeması ekliyoruz.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint sunumu oluştur.
presentation = Presentation()
try:
    # İlk slaytın şekil koleksiyonunu al.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Çalışma kitabının ilk sayfasından "Chart 1" adlı şemayı içe aktar ve şekil koleksiyonuna ekle.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **Tüm Excel Şemalarını İçe Aktarma Örneği**

Bir Excel çalışma kitabının içinde birçok şema olduğunu ve bunların hepsini bir sunuma içe aktarmanız gerektiğini hayal edin. Her şema yeni bir slayta yerleştirilecektir.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her sayfadan şemaları çıkarır ve her şemayı boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Sonuç sunumda yalnızca şema verileri gömülü olacaktır, tüm çalışma kitabı değil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Çalışan verilerini içeren Excel çalışma kitabını yükle.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# PowerPoint sunumu oluştur.
presentation = Presentation()
try:
    # Boş slayt düzenini al.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Varsayılan slaytı kaldır, böylece sonuç her şema için bir slayt içerir.
    presentation.getSlides().removeAt(0)

    # Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Çalışma sayfası için şema indekslerini şema adlarıyla eşleyen bir harita al.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Boş düzeni kullanarak bir slayt ekle.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Belirtilen şemayı Excel çalışma kitabından slaydın şekil koleksiyonuna içe aktar.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Excel Tablosu İçe Aktarma Örneği**

Bu örnekte, bir Excel çalışma sayfasından biçimlendirilmiş bir tabloyu doğrudan bir PowerPoint sunumuna içe aktarıyoruz.

Kaynak Excel çalışma sayfası, çalışan verileri içeren biçimlendirilmiş bir tablo içerir:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint sunumu oluştur.
presentation = Presentation()
try:
    # İlk slaytı ve şekil koleksiyonunu al.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Tabloyu çalışma kitabının ilk sayfasından içe aktar ve şekil koleksiyonuna ekle.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Oluşan sunumu bir dosyaya kaydet.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **Özet**

Bu mekanizma, doğrudan Aspose.Slides içinde bulunur ve Excel verileriyle sunumları tek bir yerde birleştirir. Ek kitaplıklar veya karmaşık entegrasyonlar olmadan, görsel şemalar ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanıza olanak tanır.