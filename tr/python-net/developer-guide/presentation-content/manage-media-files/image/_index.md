---
title: Python ile PowerPoint'te Görsel Yönetimini Optimize Edin
linktitle: Görselleri Yönetin
type: docs
weight: 10
url: /tr/python-net/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument'te görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha etkileyici ve ilgi çekici hâle getirir. Microsoft PowerPoint’te bir dosyadan, internetten ya da diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde Aspose.Slides de resimleri slaytlara çeşitli yollarla eklemenizi sağlar.

{{% alert title="İpucu" color="primary" %}}
Aspose, resimlerden hızlıca sunum oluşturmanıza olanak tanıyan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar.
{{% /alert %}}

{{% alert title="Bilgi" color="info" %}}
Resmi bir çerçeve nesnesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırma veya efekt uygulama gibi standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/tr/python-net/picture-frame/) bölümüne bakın.
{{% /alert %}}

{{% alert title="Not" color="warning" %}}
Resim ve sunum I/O işlemlerini kullanarak resimleri formatlar arasında dönüştürebilirsiniz. Şu sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/python-net/conversion/image-to-jpg/) dönüştürme; [JPG to image](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-image/) dönüştürme; [JPG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-png/) dönüştürme; [PNG to JPG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-jpg/) dönüştürme; [PNG to SVG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-svg/) dönüştürme; ve [SVG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/svg-to-png/) dönüştürme.
{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlarda resimlerle çalışmayı destekler.

## **Yerel Olarak Depolanan Resimleri Slaytlara Ekleyin**

Bilgisayarınızdan bir veya birden fazla resmi bir sunumun slaytına ekleyebilirsiniz. Aşağıdaki Python örneği bir resmi slayta nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Web’den Resim Ekleyin**

Eklemek istediğiniz resim bilgisayarınızda bulunmuyorsa, doğrudan web’den ekleyebilirsiniz.

Aşağıdaki Python örneği bir URL’den bir resmi slayta nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Üstatlarına Resim Ekleyin**

Slayt üstatı, altındaki tüm slaytlar için tema, düzen gibi bilgileri depolayan ve kontrol eden üst düzey slayttır. Bir slayt üstatına resmi eklerseniz, bu resim o üstatı kullanan her slaytta görünür.

Aşağıdaki Python örneği bir slayt üstatına resmi nasıl ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Resmi Slayt Arka Planı Olarak Ayarlayın**

Belirli bir slayt veya birden çok slayt için resmi arka plan olarak kullanmak isteyebilirsiniz. Ayrıntılar için [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/tr/python-net/presentation-background/#set-image-as-background-for-slide) bölümüne bakın.

## **Sunumlara SVG Ekleyin**

[ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfının [add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) yöntemini kullanarak herhangi bir resmi bir sunuma ekleyebilirsiniz.

SVG’den bir resim nesnesi oluşturmak için şu adımları izleyin:

1. Bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) oluşturun ve sunumun resim koleksiyonuna ekleyin.  
2. [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) üzerinden bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
3. [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) kullanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) nesnesi oluşturun.

Aşağıdaki Python örneği bu adımları kullanarak bir SVG resmini sunuma nasıl ekleyeceğinizi gösterir:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # SVG dosyasının içeriğini oku.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Bir SvgImage nesnesi oluştur.
        svg_image = slides.SvgImage(svg_content)

        # Bir PPImage nesnesi oluştur.
        pp_image = presentation.images.add_image(svg_image)

        # Yeni bir PictureFrame oluştur.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Sunumu PPTX formatında kaydet.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG’yi Şekil Kümesine Dönüştürün**

Aspose.Slides, SVG’leri PowerPoint’in SVG işleme şeklinde bir şekil kümesine dönüştürür.

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfındaki [add_group_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_group_shape/) yönteminin bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) alarak aşırı yüklenmiş sürümüyle sağlanır.

Aşağıdaki örnek kod bir SVG dosyasını şekil kümesine nasıl dönüştüreceğinizi gösterir:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG dosya içeriğini oku.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Bir SvgImage nesnesi oluştur.
        svg_image = slides.SvgImage(svg_content)

        # Slayt boyutunu al.
        slide_size = presentation.slide_size.size

        # SVG görüntüsünü şekil grubuna dönüştür ve slayt boyutuna ölçeklendir.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Sunumu PPTX formatında kaydet.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Resimleri EMF Olarak Slaytlara Ekleyin**

Aspose.Slides for Python, sunumlara Enhanced Metafile (EMF) resimleri eklemenizi sağlar.

Aşağıdaki Python örneği bunu gösterir:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Resim Koleksiyonundaki Resimleri Değiştirin**

Aspose.Slides, slayt şekilleri tarafından kullanılanlar da dahil olmak üzere bir sunumun resim koleksiyonunda depolanan resimleri değiştirmenize olanak tanır. Bu bölüm, koleksiyondaki resimleri güncellemenin çeşitli yaklaşımlarını açıklar. API, ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) örneği veya koleksiyonda zaten bulunan başka bir resimle bir resmi değiştirmek için doğrudan yöntemler sunar.

Şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfını kullanarak resimleri içeren sunumu yükleyin.  
2. Yeni resmi bir dosyadan bayt dizisine yükleyin.  
3. Bayt dizisini kullanarak hedef resmi yeni resimle değiştirin.  
4. Alternatif olarak, resmi bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) nesnesine yükleyin ve hedef resmi bu nesneyle değiştirin.  
5. Veya hedef resmi, sunumun resim koleksiyonunda zaten var olan bir resimle değiştirin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
with slides.Presentation("sample.pptx") as presentation:

    # İlk yöntem.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # İkinci yöntem.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Üçüncü yöntem.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Bilgi" color="info" %}}
Aspose’un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF oluşturabilirsiniz.
{{% /alert %}}

## **SSS**

**Ekleme sonrası orijinal resim çözünürlüğü korunur mu?**  
Evet. Kaynak pikseller korunur, ancak son görünüm resmin slayt üzerindeki [picture](/slides/tr/python-net/picture-frame/) ölçeklendirilme biçimine ve kaydedilirken uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu toplu olarak nasıl değiştiririm?**  
Logoyu ana slayta veya bir düzen şemasına yerleştirin ve sunumun resim koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen SVG düzenlenebilir şekillere dönüştürülebilir mi?**  
Evet. SVG bir şekil grubuna dönüştürülebilir; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden çok slaytın arka planı olarak aynı anda nasıl ayarlarım?**  
Resmi ana slaytta veya ilgili düzen şemasında arka plan olarak atayın; bu master/düzeni kullanan tüm slaytlar arka planı miras alır.

**Sunum çok sayıda resim nedeniyle şişmemesi için ne yapmalıyım?**  
Tek bir resim kaynağını yeniden kullanın, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve tekrarlanan grafiklerinizi mümkün olduğunca master’da tutun.