---
title: Python Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/python-net/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlı nesne
- bağlı dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkar
- nesneyi çıkar
- dosyayı çıkar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamada bağlanmasını veya gömülmesini sağlar.

{{% /alert %}}

Örneğin, Microsoft Excel'de oluşturulan ve bir PowerPoint slaytına yerleştirilen bir grafik bir OLE nesnesidir.

- bir OLE nesnesi bir simge olarak görünebilir. Simgeye çift tıklamak nesneyi ilişkili uygulamasında (ör. Excel) açar ya da açma/düzenleme için bir uygulama seçmenizi ister.
- bir OLE nesnesi içeriğini (örneğin bir grafiği) gösterebilir. Bu durumda PowerPoint gömülü nesneyi etkinleştirir, grafik arayüzünü yükler ve grafiğin verilerini PowerPoint içinde düzenlemenizi sağlar.

Aspose.Slides for Python, OLE nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar.

## **Slaytlara OLE Nesneleri Ekle**

Microsoft Excel'de zaten bir grafik oluşturduysanız ve Aspose.Slides for Python kullanarak bunu bir OLE nesne çerçevesi olarak slayta gömmek istiyorsanız aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
1. Slaydın indeksine göre bir referans alın.
1. Excel dosyasını bir bayt dizisine okuyun.
1. OleObjectFrame ekleyin, bayt dizisini ve diğer OLE nesne ayrıntılarını sağlayarak.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, bir Excel dosyasındaki grafik bir OleObjectFrame ([OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/)) olarak slayta gömülmüştür.

**Not:** OleEmbeddedDataInfo ([OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/)) yapıcısı, gömülecek nesnenin dosya uzantısını ikinci parametre olarak alır. PowerPoint bu uzantıyı dosya türünü tanımlamak ve OLE nesnesini açmak için uygun uygulamayı seçmek amacıyla kullanır.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # OLE nesnesi için veriyi hazırlayın.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Slayta bir OLE nesne çerçevesi ekleyin.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Bağlantılı OLE Nesneleri Ekle**

Aspose.Slides for Python, verisini gömmek yerine bir dosyaya bağlanan bir OleObjectFrame eklemenizi sağlar.

Aşağıdaki Python örneği, bir slayta Excel dosyasına bağlanan bir OleObjectFrame eklemenin nasıl yapılacağını gösterir:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Bağlantılı bir Excel dosyasıyla bir OLE nesne çerçevesi ekleyin.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE Nesnelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, aşağıdaki şekilde erişebilirsiniz:

1. Presentation sınıfının bir örneğini oluşturarak gömülü OLE nesnesini içeren sunumu yükleyin.
1. Slaydın indeksine göre bir referans alın.
1. OleObjectFrame şekline erişin.
1. OLE nesne çerçevesine sahip olduğunuzda, üzerinde gerekli işlemleri gerçekleştirin.

Aşağıdaki örnek, OLE nesne çerçevesine — gömülü bir Excel grafiğine — erişir ve dosya verisini alır. Bu örnekte, ilk slaytta tek bir şekil bulunan bir PPTX kullanıyoruz.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Gömülü dosya verisini alın.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Gömülü dosyanın uzantısını alın.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Bağlantılı OLE Nesne Özelliklerine Erişim**

Aspose.Slides, bağlantılı bir OLE nesne çerçevesinin özelliklerine erişmenizi sağlar.

Aşağıdaki Python örneği, bir OLE nesnesinin bağlantılı olup olmadığını kontrol eder ve bağlantılı dosyanın yolunu alır:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # OLE nesnesinin bağlı olup olmadığını kontrol edin.
        if ole_frame.is_object_link:
            # Bağlı dosyanın tam yolunu yazdır.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Bağlı dosyanın göreceli yolunu (varsa) yazdır.
            # Yalnızca .ppt sunumları göreceli yol içerebilir.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE Nesne Verisini Değiştir**

{{% alert color="primary" %}}

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Python via .NET](/cells/python-net/) kullanır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, aşağıdaki gibi erişebilir ve verisini değiştirebilirsiniz:

1. Presentation sınıfının bir örneğini oluşturarak sunumu yükleyin.
1. İlgili slaydı indeksine göre alın.
1. OleObjectFrame şekline erişin.
1. OLE nesne çerçevesine sahip olduğunuzda, gerekli işlemleri gerçekleştirin.
1. Bir `Workbook` nesnesi oluşturun ve OLE verisini okuyun.
1. İstenen `Worksheet`i açın ve veriyi düzenleyin.
1. Güncellenmiş `Workbook`u bir akısa (stream) kaydedin.
1. OLE nesnesinin verisini bu akışı kullanarak değiştirin.

Aşağıdaki örnek, bir OLE nesne çerçevesine (gömülü bir Excel grafiğine) erişir ve dosya verisini değiştirerek grafiği günceller. Örnek, ilk slaytta tek bir şekil bulunan önceden oluşturulmuş bir PPTX kullanır.

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
            # OLE nesne verilerini bir Workbook nesnesi olarak okuyun.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Workbook verilerini değiştirin.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # OLE çerçeve nesnesi verilerini değiştirin.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dosyaları Slaytlara Göm**

Excel grafiklerine ek olarak, Aspose.Slides for Python diğer dosya türlerini de slaytlara gömmenizi sağlar. Örneğin HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, ilişkilendirilmiş uygulamada otomatik olarak açılır veya uygun bir program seçmesi istenir.

Bu Python kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```py
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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarla**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmeniz veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmeniz gerekebilir. Aspose.Slides for Python, gömülü bir nesnenin dosya türünü ayarlamanızı sağlar; bu sayede OLE çerçeve verisini veya dosya uzantısını güncelleyebilirsiniz.

Bu Python kodu, gömülü OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir:

```py
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

## **Gömülü Nesneler İçin Simge Görüntülerini ve Başlıkları Ayarla**

Bir OLE nesnesini gömdükten sonra otomatik olarak bir simge önizlemesi eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for Python ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu Python kodu, gömülü bir nesne için simge görüntüsü ve başlığını ayarlamayı gösterir:

```py
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

## **OLE Nesne Çerçevelerinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önle**

Bir bağlantılı OLE nesnesini bir slayta ekledikten sonra PowerPoint, sunumu açtığınızda bağlantıları güncellemenizi isteyebilir. Bağlantıları Güncelle seçeneği, PowerPoint bağlantılı nesneden gelen verilerle önizlemeyi yenilediği için OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncellemenizi istemesini önlemek için, OleObjectFrame sınıfının `update_automatic` özelliğini `False` olarak ayarlayın:

```py
ole_frame.update_automatic = False
```

## **Gömülü Dosyaları Çıkar**

Aspose.Slides for Python, slaytlara OLE nesneleri olarak gömülmüş dosyaları aşağıdaki gibi çıkarabilir:

1. OLE nesnelerini içeren bir Presentation sınıfının örneğini oluşturun.
1. Sunumdaki tüm şekilleri dolaşın ve OleObjectFrame şekillerini bulun.
1. Her OleObjectFrame'ten gömülü dosya verisini alın ve diske yazın.

Aşağıdaki Python kodu, bir slaytta OLE nesneleri olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:

```py
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

**OLE içeriği slaytlar PDF/görsellere dışa aktarılırken renderlanacak mı?**

Slaytta görülen şey renderlanır — simge/ikame resmi (önizleme). "Canlı" OLE içeriği renderleme sırasında yürütülmez. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme resminizi ayarlayın.

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint'te nesneyi taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides, [şekil düzeyinde kilitler](/slides/tr/python-net/applying-protection-to-presentation/) sağlar. Bu bir şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "zıplıyor" ya da boyutu değişiyor?**

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Stabil bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma için Çözüm](/slides/tr/python-net/working-solution-for-worksheet-resizing/) uygulamalarını izleyin — çerçeveyi aralığa uydurun veya aralığı sabit bir çerçeveye ölçekleyin ve uygun bir ikame resmi ayarlayın.

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunur mu?**

PPTX formatında "göreceli yol" bilgisi bulunmaz — yalnızca tam yol vardır. Göreceli yollar daha eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'ler veya gömme tercih edin.