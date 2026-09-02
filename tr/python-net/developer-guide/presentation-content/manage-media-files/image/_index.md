---
title: PowerPoint'te Python ile Görsel Yönetimini Optimize Edin
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/python-net/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görseli değiştir
- resmi değiştir
- webden
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument'te görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha çekici ve ilgi çekici hâle getirir. Microsoft PowerPoint'te, bir dosyadan, internetten veya diğer kaynaklardan resimler ekleyebilirsiniz. Benzer şekilde, Aspose.Slides slaytlara görselleri çeşitli yollarla eklemenizi sağlar.

{{% alert title="İpucu" color="primary" %}}
Aspose, ücretsiz dönüştürücüleri—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunarak görsellerden hızlı bir şekilde sunumlar oluşturmanıza imkan tanır.
{{% /alert %}}

{{% alert title="Bilgi" color="info" %}}
Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırma veya efekt uygulama gibi standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/tr/python-net/picture-frame/) sayfasına bakın.
{{% /alert %}}

{{% alert title="Not" color="warning" %}}
İmaj ve sunum I/O işlemlerini kullanarak görselleri formatlar arasında dönüştürebilirsiniz. Bu sayfalara bakın: convert [image to JPG](https://products.aspose.com/slides/tr/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-svg/); and convert [SVG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görsellerle çalışmayı destekler.

## **Yerel Olarak Depolanan Görselleri Slaytlara Ekle**

Bilgisayarınızdan bir veya daha fazla görseli bir sunumdaki slayta ekleyebilirsiniz. Aşağıdaki Python örneği bir görselin slayta nasıl ekleneceğini göstermektedir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Web'den Görselleri Slaytlara Ekle**

Bir slayta eklemek istediğiniz görsel bilgisayarınızda bulunmuyorsa, doğrudan webten ekleyebilirsiniz.

Aşağıdaki Python örneği bir URL'den görselin slayta nasıl ekleneceğini göstermektedir:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Görüntünün ham baytlarını indir.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Görselleri Slayt Üstatlarına Ekle**

Slayt üstü (slide master), altında bulunan tüm slaytlar için tema, düzen vb. bilgileri depolayan ve kontrol eden üst düzey slayttır. Bir görseli slayt üstadına eklediğinizde, o görsel o üstadı kullanan her slaytta görünür.

Aşağıdaki Python örneği bir slayt üstadına görselin nasıl ekleneceğini göstermektedir:

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

## **Görselleri Slayt Arka Planı Olarak Ekle**

Bir veya daha fazla slaytın arka planı olarak bir resmi kullanabilirsiniz. Ayrıntılar için *[Setting Images as Backgrounds for Slides](/slides/tr/python-net/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **SVG'yi Sunumlara Ekle**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Ortaya çıkan SVG görseli daha sonra sunumun image collection'ına eklenebilir ve bir picture frame oluşturmak için kullanılabilir.

Aşağıdaki Python örneği kendine özgü bir SVG dizesi içe aktarır. Bu SVG tarafından kullanılan tüm görseller, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG'yi Şekil Setine Dönüştür**

Aspose.Slides, SVG'leri PowerPoint'in SVG işleme şekline benzer bir biçimde şekil setine dönüştürür.

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, ilk argüman olarak bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) alan [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfındaki [add_group_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_group_shape/) metodunun bir aşırı yüklemesi tarafından sağlanır.  

Aşağıdaki örnek kod, bir SVG dosyasını şekil setine nasıl dönüştüreceğinizi gösterir.

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

        # SVG görüntüsünü bir şekil grubuna dönüştür ve slayt boyutuna ölçekle.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Sunumu PPTX formatında kaydet.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Görselleri EMF Olarak Slaytlara Ekle**

Aspose.Slides for Python, sunumlara Enhanced Metafile (EMF) görselleri eklemenizi sağlar.

Aşağıdaki Python örneği bunu göstermektedir:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMM.pptx", slides.export.SaveFormat.PPTX)
```

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, bir sunumun image collection'ında depolanan görselleri, slayt şekilleri tarafından kullanılanları da dahil olmak üzere değiştirmenize olanak tanır. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yaklaşımlarını açıklamaktadır. API, ham bayt verileri, bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görsel ile bir görseli değiştirmek için doğrudan yöntemler sunar.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin.  
1. Yeni bir görseli dosyadan bir bayt dizisine yükleyin.  
1. Hedef görseli yeni görselle bayt dizisini kullanarak değiştirin.  
1. Alternatif olarak, görseli bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin.  
1. Ya da hedef görseli, sunumun image collection'ında zaten mevcut olan bir görselle değiştirin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides

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
Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF oluşturabilirsiniz.
{{% /alert %}}

## **SSS**

**Ekleme sonrası özgün görsel çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [resim](/slides/tr/python-net/picture-frame/) ölçeklendirmesine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**

Logoyu master slaytına veya bir düzene yerleştirip, sunumun image collection'ında değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG, şekil grubuna dönüştürülebilir; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlayabilirim?**

[Resmi arka plan olarak atayın](/slides/tr/python-net/presentation-background/) master slaytta veya ilgili düzende—bu master/layoutı kullanan tüm slaytlar arka planı devralır.

**Bir sunumda çok sayıda resim nedeniyle dosya boyutu çok büyük olmaktan nasıl kaçınabilirim?**

Tek bir görsel kaynağını tekrar kullanın, uygun çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafik öğelerini gerektiğinde master’da tutun.