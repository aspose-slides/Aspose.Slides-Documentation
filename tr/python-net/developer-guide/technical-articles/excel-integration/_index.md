---
title: PowerPoint Sunumlarına Excel Verilerini Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/python-net/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel oku
- Excel'i entegre et
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'i PowerPoint'e
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides'ta ExcelDataWorkbook API'sini kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış verilerin mükemmel bir kaynağını sağlarken PowerPoint, bu verileri izleyicilere görselleştirmede üstündür.

Excel ve PowerPoint'i birleştirmenin gerekli olduğu birçok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt üretimi), eğitim materyalleri oluşturma ve birden fazla Excel raporunu tek bir sunumda birleştirme gibi.

Şu ana kadar, Aspose.Slides API'siyle bu özellikleri uygulamak, Aspose.Cells gibi üçüncü taraf çözümlerine dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için aşırı karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve daha akıcı hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuyan ve içeriği bir sunuma içe aktaran yeni sınıflar tanıttı. Bu özellik, Excel'i sunum iş akışlarında bir veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olanaklar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM)'a entegre değildir. Bu, *Excel dosyalarını düzenlemeye veya kaydetmeye izin vermediği* anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almaktır.

Bu özelliğin temelinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.excel/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya akıştan yüklemenize olanak tanır. Yüklendikten sonra, konumlarına göre (ör. satır ve sütun indeksleri veya adlandırılmış aralıklar) belirli hücreleri almak için kullanabileceğiniz [get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) yönteminin çeşitli aşırı yüklemelerini sunar.

Her [get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.excel/exceldatacell/) sınıfından bir örnek döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Excel Grafik İçe Aktarma**

İşlevselliği genişletmenin bir sonraki adımı, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/python-net/aspose.slides.importing/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından sunuma içerik aktarma işlevi sağlar. Belirtilen Excel çalışma kitabından seçilen grafiği almanıza ve verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemenize yardımcı olan [add_chart_from_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) yönteminin çeşitli aşırı yüklemelerini içerir.

Kısacası, Excel verilerini okumak için hafif ve basit bir API'dir — tam bir elektronik tablo işleme kütüphanesinin getirdiği ek yüke ihtiyaç duymadan birçok geliştiricinin tam olarak aradığı şey.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında saklanan verilere dayanarak birden fazla sunum oluşturarak basit bir posta birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel data example](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint template example](example1_image1.png)

```py
import aspose.slides as slides

# Çalışan verileri içeren Excel çalışma kitabını yükle.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Sunum şablonunu yükle.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Excel satırları arasında döngü yap (satır 0 başlığı hariç).
    for row_index in range(1, 5):

        # Her çalışan kaydı için yeni bir sunum oluştur.
        with slides.Presentation() as employee_presentation:

            # Varsayılan boş slaytı kaldır.
            employee_presentation.slides.remove_at(0)

            # Şablon slaytı yeni sunuma kopyala.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Hedef şekilden paragrafları al (şekil indeksinin 1 olduğu varsayılır).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Yer tutucuları Excel'den gelen verilerle değiştir.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundan verileri kopyalayıp PowerPoint slaytında daha görsel açıdan çekici bir biçimde gösteriyoruz.

Bu örnekte, basit bir çalışan tablosu içeren ilk örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz.

```py
# Çalışan verilerini içeren Excel çalışma kitabını yükle.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Yeni bir PowerPoint sunumu oluştur.
with slides.Presentation() as presentation:

    # İlk slayta bir tablo şekli ekle.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example2_image0.png)

### **Excel Grafik İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, ortaya çıkan sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayanarak Excel çalışma kitabına bir Pasta grafiği ekliyoruz.

![Excel Chart example](example3_image0.png)

```py
# Yeni bir PowerPoint sunumu oluştur.
with slides.Presentation() as presentation:
    # İlk slaydın şekil koleksiyonunu al.
    shapes = presentation.slides[0].shapes

    # Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Result](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabınızın içinde birçok grafik olduğunu ve bunların tümünü bir sunuma içe aktarmanız gerektiğini hayal edelim. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her sayfadan grafikleri çıkarır ve boş bir slayt düzeni kullanarak her bir grafiği ayrı bir slayta ekler. Oluşan sunumda yalnızca grafik verileri gömülür, tüm çalışma kitabı eklenmez.

```py
# Çalışan verilerini içeren Excel çalışma kitabını yükle.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Yeni bir PowerPoint sunumu oluştur.
with slides.Presentation() as presentation:
    # Boş slayt düzenini al.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Çalışma sayfası için grafik indekslerini grafik adlarına eşleyen bir sözlük al.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Boş düzeni kullanarak yeni bir slayt ekle.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Belirtilen grafiği Excel çalışma kitabından slaytın şekil koleksiyonuna içe aktar.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Özet**

Aspose.Slides içinde doğrudan mevcut olan bu mekanizma, Excel verileriyle ve sunumlarla aynı yerde çalışmayı birleştirir. Görsel grafikler ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanıza olanak tanır - ek kütüphanelere veya karmaşık entegrasyonlara ihtiyaç duymadan.