---
title: "Python’da PowerPoint Oluşturmayı Otomatikleştirme: Dinamik Sunumları Kolayca Oluşturun"
linktitle: PowerPoint Oluşturmayı Otomatikleştirme
type: docs
weight: 20
url: /tr/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- bulut platformları
- bulut entegrasyonu
- PowerPoint oluşturmayı otomatikleştir
- programlı olarak sunumlar oluştur
- PowerPoint otomasyonu
- dinamik slayt oluşturma
- otomatik iş raporları
- PPT otomasyonu
- Python sunumu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint oluşturmayı otomatikleştirin: bulut uygulamalarında grafikler, tablolar ve madde işaretli noktalar içeren bir iş sunumu oluşturun."
---
## **Giriş**

Sunumları elle oluşturmak, içeriği sık sık değiştiğinde tekrar edici bir hâl alır. Haftalık raporlar, eğitim materyalleri ve müşteri sunumları genellikle ortak bir yapıyı paylaşır ancak her teslimat için yeni verilere ihtiyaç duyar.

Aspose.Slides for Python via Java, bu sunumları Python uygulamalarından üretmenizi sağlar. Veritabanları, API’ler veya yüklenen dosyalar gibi kaynaklardan gelen verileri kullanarak kaydırı oluşturmayı web portallarına, zamanlanmış görevlere ve bulut çalışanlarına entegre edebilirsiniz.

## **Python’da PowerPoint Otomasyonu İçin Yaygın Kullanım Senaryoları**

- **İş raporları ve gösterge panoları:** satış rakamları ve performans metriklerini grafik ve tablolara dönüştürün.
- **Kişiselleştirilmiş satış sunumları:** tutarlı bir tasarımı korurken slaytları müşteri‑spesifik verilerle doldurun.
- **Eğitim içeriği:** yapılandırılmış materyallerden dersler, testler ve kurs özetleri oluşturun.
- **Veri ve AI destekli içgörüler:** analiz veya dil işleme servislerinin sonuçlarını sunum içeriği olarak kullanın.
- **Medya tabanlı slaytlar:** yüklenen görselleri veya ekran görüntülerini açıklayıcı metinle birleştirin.
- **Belge iş akışları:** diğer araçlarla çıkarılan içeriği sunum düzenlerine haritalayın.
- **Geliştirici araçları:** proje verilerinden sürüm özetleri, teknik bakış açıları veya demo sunumları üretin.

## **Önkoşullar**

Python, Java, JPype ve Aspose.Slides kurulumunu yapmak için [Installation](/slides/tr/python-java/installation/) sayfasını izleyin. Bulut dağıtımı için ayrıca [Slides on Cloud Platforms](/slides/tr/python-java/slides-on-cloud-platforms/) bölümüne bakın.

Örnek, bir veritabanı veya dış hizmet gerektirmeyecek sabit iş verileri kullanır. Bunu rapor iş akışınıza entegre ederken değerleri uygulamanızdan gelen verilerle değiştirin.

{{% alert color="info" title="Not" %}}

Lisans olmadan örneği deneyebilirsiniz, ancak değerlendirme çıktısı bir filigran içerir ve değerlendirme kısıtlamalarına tabidir. Ayrıntılar ve geçici lisans bilgileri için [Evaluate Aspose.Slides](/slides/tr/python-java/evaluate-aspose-slides/) sayfasına bakın.

{{% /alert %}}

## **Sunumu Oluşturma**

Aşağıdaki tam betik, dört slayttan oluşan tek bir sunum oluşturur. Her adım aynı sunumu kullanır ve son adım `presentation.pptx` olarak kaydeder.

### **Başlık Slaydı Oluşturma**

Yeni bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) içinde ilk slaytı kullanın ve başlık düzenini uygulayın. Başlık ve alt başlık yer tutucularını rapor başlığı ve hedef kitle ile doldurun.

![Başlık slaydı](slide_0.png)

### **Sütun Grafiği İçeren Slayt Ekleme**

Boş bir slayt ekleyin ve [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addChart) ile bir grafik oluşturun. Gömülü çalışma sayfasını beş bölge ve bir satış serisi ile doldurun. Değerler PowerPoint içinde düzenlenebilir kalır.

![Grafikli slayt](slide_1.png)

### **Tablo İçeren Slayt Ekleme**

[ShapeCollection.addTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addTable) ile bir tablo oluşturun ve iki sütunu metrik adları ve değerleriyle doldurun. Örnek, JPype üzerinden kolon genişlikleri ve satır yükseklikleri için açık Java double dizilerini geçirir.

![Tablolu slayt](slide_2.png)

### **Madde İşaretli Özet Slaytı Ekleme**

Bir metin şekli oluşturun ve her eylem öğesi için bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) ekleyin. Her paragraf için sembolik madde işareti ve siyah metin uygulayın; şeklin dolgu ve konturunu kaldırın.

![Özet slaytı](slide_3.png)

### **Sunumu Kaydetme**

PowerPoint dosyasını yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu kullanın. `finally` bloğunda [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) ile sunumu serbest bırakın.

### **Tam Python Örneği**

Bu betiği yazılabilir bir klasöre kaydedin ve yukarıda yapılandırılmış Python ortamı ile çalıştırın. JVM yalnızca gerekli olduğunda başlatılır ve süreç sonlanana kadar kullanılabilir durumda kalır. Notebook ve servis kullanımı için [JVM lifecycle guidance](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) bölümüne bakın.

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Başlık slaytını oluştur.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Grafik slaytı ekle.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Tablo slaytı ekle.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Özet slaytı ekle.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İllustrasyonlar, Java örneğindeki karşılık gelen slaytları gösterir. Görünüm, yüklü yazı tiplerine ve değerlendirme moduna bağlı olarak değişebilir.

## **Bulut Uygulamasında Örneği Kullanma**

Sunumu oluştururken rapor verilerini alın, ardından grafiğe, tabloya ve metin‑üretim adımlarına geçirin. Her görev için ayrı bir çıkış yolu kullanın. Kaydettikten sonra uygulamanız dosyayı nesne depolamaya yükleyebilir veya indirme olarak döndürebilir.

JVM’i aynı çalışan süreç içinde görevler arasında çalışır durumda tutun ve her sunum işi bittiğinde serbest bırakın. Rapor tasarımınızın gerektirdiği yazı tiplerini dağıtıma ekleyerek ortamlar arasındaki farkları azaltın.

## **Sonuç**

Bu örnek, düzenlenebilir grafikler, tablolar ve metinler kullanarak Python’dan tam bir iş sunumu üretir. Örnek veriyi uygulama verileriyle değiştirerek aynı yaklaşımı yineleyen raporlar, müşteri sunumları ve eğitim materyalleri için kullanabilirsiniz.

## **SSS**

**Betik Microsoft PowerPoint veya Excel gerektiriyor mu?**

Hayır. Aspose.Slides, slaytları ve grafiğin gömülü çalışma sayfasını hiçbir uygulamaya ihtiyaç duymadan oluşturur.

**Tablo örneği neden Java dizileri kullanıyor?**

Altta yatan metod, Java double dizileri kabul eder. Açık diziler, JPype üzerinden geçirilen sayısal tiplerin net olmasını sağlar.

**Aynı sunumu PDF veya ODP olarak kaydedebilir miyim?**

Evet. Serbest bırakmadan önce, uygun [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) değeriyle başka bir çıktı dosya adına kaydedin. Format‑spesifik yetenekler için [Supported File Formats](/slides/tr/python-java/supported-file-formats/) bölümüne bakın.

**Markalı bir şablon kullanabilir miyim?**

Evet. Boş bir sunum oluşturmak yerine şablonunuzu yükleyin, ardından düzen ve yer tutucu seçimlerini o şablona göre uyarlayın. Örnek, yeni bir varsayılan sunumun yer tutucu sırası ve düzenlerini varsayar.