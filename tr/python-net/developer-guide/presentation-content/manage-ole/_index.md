---
title: Python Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/python-net/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömülmesi
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlantılı nesne
- bağlantılı dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkar
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)**, bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlanmasını veya gömülmesini sağlar.

{{% /alert %}}

Örneğin, Microsoft Excel'de oluşturulan ve bir PowerPoint slaytına yerleştirilen bir grafik bir OLE nesnesidir.

- Bir OLE nesnesi bir simge olarak görünebilir. Simgeye çift tıkladığınızda nesne ilişkili uygulamasında (örn. Excel) açılır veya açmak/düzenlemek için bir uygulama seçmenizi ister.
- Bir OLE nesnesi içeriğini (örneğin bir grafiği) gösterebilir. Bu durumda PowerPoint gömülü nesneyi etkinleştirir, grafik arayüzünü yükler ve grafiğin verilerini PowerPoint içinde düzenlemenize izin verir.

Aspose.Slides for Python, OLE nesnelerini slaytlara OLE nesne çerçeveleri olarak eklemenizi sağlar ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE Nesnelerini Slaytlara Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduysanız ve Aspose.Slides for Python kullanarak bunu bir OLE nesne çerçevesi olarak bir slayta gömmek istiyorsanız, aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slayta indeksine göre bir referans alın.
3. Excel dosyasını bir byte dizisine okuyun.
4. Slayta bir [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ekleyin ve byte dizisini ve diğer OLE nesne ayrıntılarını sağlayın.
5. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, bir Excel dosyasından alınan bir grafik, bir [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) olarak bir slayta gömülür.

**Not:** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) yapıcı (constructor) gömülebilir nesnenin dosya uzantısını ikinci parametre olarak alır. PowerPoint bu uzantıyı dosya türünü tanımlamak ve OLE nesnesini açmak için uygun uygulamayı seçmek üzere kullanır.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE nesnesi için verileri hazırlayın.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Slayta bir OLE nesne çerçevesi ekleyin.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Bağlantılı OLE Nesnelerini Ekleme**

Aspose.Slides for Python, verileri gömmek yerine bir dosyaya bağlanan bir [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) eklemenizi sağlar.

Aşağıdaki Python örneği, bir slayta Excel dosyasına bağlanan bir [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) eklemenin yolunu gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE Nesnelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona aşağıdaki şekilde erişebilirsiniz:

1. Gömülü OLE nesnesini içeren sunumu, Presentation sınıfının bir örneğini oluşturarak yükleyin.
2. Slayta indeksine göre bir referans alın.
3. OleObjectFrame şekline erişin.
4. OLE nesne çerçevesine sahip olduğunuzda, üzerinde gerekli işlemleri gerçekleştirin.

Aşağıdaki örnek, OLE nesne çerçevesine (gömülü bir Excel grafiği) erişir ve dosya verisini alır. Bu örnekte, ilk slaytta tek bir şekil bulunan bir PPTX kullanıyoruz.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Gömülü dosya verisini al.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Gömülü dosyanın uzantısını al.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Bağlantılı OLE Nesne Özelliklerine Erişim**

Aspose.Slides, bağlantılı bir OLE nesne çerçevesinin özelliklerine erişmenizi sağlar.

Aşağıdaki Python örneği, bir OLE nesnesinin bağlantılı olup olmadığını kontrol eder ve bağlantılıysa dosya yolunu alır:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE nesnesinin bağlanıp bağlanmadığını kontrol edin.
        if ole_frame.is_object_link:
            # Bağlantılı dosyanın tam yolunu yazdır.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Bağlantılı dosyanın göreli yolunu, mevcutsa yazdır.
            # Yalnızca .ppt sunumları göreli yol içerebilir.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" title="Note" %}}

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona erişebilir ve verisini aşağıdaki gibi değiştirebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak sunumu yükleyin.
2. Hedef slayta indeksine göre ulaşın.
3. [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) şekline erişin.
4. OLE nesne çerçevesine sahip olduğunuzda, gerekli işlemleri gerçekleştirin.
5. Bir `Workbook` nesnesi oluşturun ve OLE verisini okuyun.
6. İstenen `Worksheet` (çalışma sayfasını) açın ve veriyi düzenleyin.
7. Güncellenen `Workbook`'u bir stream'e kaydedin.
8. OLE nesnesinin verisini o stream'i kullanarak değiştirin.

Aşağıdaki örnekte, bir OLE nesne çerçevesine (gömülü bir Excel grafiği) erişilir ve dosya verisi grafiği güncellemek için değiştirilir. Örnek, ilk slaytta tek bir şekil bulunan önceden oluşturulmuş bir PPTX kullanır.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # OLE nesnesi verisini Workbook nesnesi olarak okuyun.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Workbook verisini değiştirin.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE çerçeve nesnesi verisini değiştirin.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dosyaları Slaytlara Gömme**

Excel grafiklerine ek olarak, Aspose.Slides for Python, slaytlara diğer dosya türlerini de gömebilir. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Bir kullanıcı eklenen nesneye çift tıkladığında, otomatik olarak ilişkili uygulamada açılır veya uygun bir program seçmesi istenir.

Bu Python kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken, eski OLE nesnelerini yeniyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen birine takas etmek isteyebilirsiniz. Aspose.Slides for Python, gömülü bir nesnenin dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçeve verisini veya dosya uzantısını güncelleyebilirsiniz.

Bu Python kodu, gömülü OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Dosya türünü ZIP olarak değiştir.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gömülü Nesneler İçin Simge Görüntülerini ve Başlıkları Ayarlama**

Bir OLE nesnesi gömdükten sonra, otomatik olarak simge temelli bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for Python ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu Python kodu, gömülü bir nesne için simge görüntüsü ve başlığı ayarlamayı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Sunum kaynaklarına bir resim ekleyin.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE önizlemesi için bir başlık ve resmi ayarlayın.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE Nesne Çerçevelerinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bir bağlantılı OLE nesnesini bir slayta ekledikten sonra, PowerPoint sunumu açtığınızda bağlantıları güncellemeyi isteyebilir. Bağlantıları Güncelle'yi seçmek, PowerPoint'in önizlemeyi bağlantılı nesnenin verileriyle yenilemesi nedeniyle OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesne verilerini güncellemeyi sormasını önlemek için, [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sınıfının `update_automatic` özelliğini `False` olarak ayarlayın:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Python, slaytlara OLE nesneleri olarak gömülmüş dosyaları aşağıdaki gibi çıkarmanızı sağlar:

1. Çıkarmak istediğiniz OLE nesnelerini içeren [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunumdaki tüm şekilleri döngüyle gezerek OLEObjectFrame şekillerini bulun.
3. Her bir [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) içinden gömülü dosya verisini alın ve diske yazın.

Aşağıdaki Python kodu, bir slaytta OLE nesneleri olarak gömülü dosyaların nasıl çıkarılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **SSS**

**Slaytları PDF/görsellere dışa aktarırken OLE içeriği oluşturulacak mı?**

Slaytta görülen şey (simge/yerine geçen görüntü - önizleme) oluşturulur. "Canlı" OLE içeriği oluşturma sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme görüntünüzü ayarlayın.

Gömülü dosyayı bir PDF eki olarak da korumak için, [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) özelliğini `True` olarak ayarlayın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve eki kontrol etme talimatları için, [Preserve Embedded OLE Files as PDF Attachments](/slides/tr/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) sayfasına bakın.

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint'te taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides, [shape-level locks](/slides/tr/python-net/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "zıplar" ya da boyutu değişir?**

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Daha stabil bir görünüm için, [Working Solution for Worksheet Resizing](/slides/tr/python-net/working-solution-for-worksheet-resizing/) yönergelerini izleyin—ya çerçeveyi aralığa göre ayarlayın, ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir yer tutucu görüntü ayarlayın.

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunacak mı?**

PPTX formatında "göreceli yol" bilgisi bulunmaz—sadece tam yol vardır. Göreceli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'ler veya gömme tercih edin.