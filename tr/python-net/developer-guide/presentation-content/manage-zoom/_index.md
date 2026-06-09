---
title: Python ile Sunumlarda Yakınlaştırmaları Yönetme
linktitle: Yakınlaştırma
type: docs
weight: 60
url: /tr/python-net/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırması
- yakınlaştırma ekle
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile Yakınlaştırma oluşturun ve özelleştirin — bölümler arasında geçiş yapın, PPT, PPTX ve ODP sunumları için küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Yakınlaştırmalar, belirli slaytlar, bölümler ve bir sunumun bölümleri arasında atlamanızı sağlar. Sunum yaparken, içeriği hızlıca dolaşma yeteneği çok faydalı olabilir. 

![genel bakış](overview.png)

* Bir bütün sunumu tek bir slaytta özetlemek için bir [Özet Yakınlaştırma](#Summary-Zoom) kullanın.
* Yalnızca seçili slaytları göstermek için bir [Slayt Yakınlaştırması](#Slide-Zoom) kullanın.
* Tek bir bölümü göstermek için bir [Bölüm Yakınlaştırması](#Section-Zoom) kullanın.

## **Slayt Yakınlaştırması**

Bir slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirebilir ve istediğiniz sırada slaytlar arasında kesintisiz bir şekilde özgürce dolaşmanızı sağlar. Slayt yakınlaştırmaları, çok bölümlü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.  

Slayt yakınlaştırmaları, tek bir tuvaldeymiş gibi hissederken birden fazla bilgi parçasına derinlemenizi sağlar. 

![slayt yakınlaştırma seçimi](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için Aspose.Slides, [ZoomImageType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/zoomimagetype/) enum'ını, [ZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/zoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfındaki bazı yöntemleri sağlar.

### **Zoom Çerçeveleri Oluşturma**

Bir slayta zoom çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Bağlantı vermek istediğiniz yeni slaytlar oluşturun.  
3.	Oluşturulan slaytlara tanımlama metni ve arka plan ekleyin.  
4.	İlk slayta zoom çerçevelerini (oluşturulan slaytlara referansları içeren) ekleyin.  
5.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Sunuma yeni slaytlar ekle
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # İkinci slayt için bir arka plan oluştur
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # İkinci slayt için bir metin kutusu oluştur
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Üçüncü slayt için bir arka plan oluştur
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Üçüncü slayt için bir metin kutusu oluştur
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame nesneleri ekle
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Sunumu kaydet
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Özel Görsellerle Zoom Çerçeveleri Oluşturma**

Aspose.Slides for Python via .NET ile, slayt önizleme görüntüsü dışında bir görsel kullanarak zoom çerçevesi oluşturabilirsiniz:

1.	`Presentation` sınıfının bir örneğini oluşturun.  
2.	Bağlantı vermek istediğiniz yeni bir slayt oluşturun.  
3.	Oluşturulan slayta tanımlama metni ve arka plan ekleyin.  
4.	Çerçeveyi doldurmak için Presentation nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
5.	İlk slayta zoom çerçevelerini (oluşturulan slayta referansı içeren) ekleyin.  
6.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekle
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # İkinci slayt için bir arka plan oluştur
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Üçüncü slayt için bir metin kutusu oluştur
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Zoom nesnesi için yeni bir görsel oluştur
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrame nesnesi ekle
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Sunumu kaydet
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Zoom Çerçevelerinin Biçimlendirilmesi**

Yukarıdaki bölümlerde basit zoom çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık zoom çerçeveleri oluşturmak için çerçevelerin biçimlendirmesini değiştirmeniz gerekir. Bir zoom çerçevesine uygulayabileceğiniz çeşitli biçimlendirme ayarları vardır.  

Bir slayttaki zoom çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	`Presentation` sınıfının bir örneğini oluşturun.  
2.	Bağlantı vermek için yeni slaytlar oluşturun.  
3.	Oluşturulan slaytlara tanımlama metni ve arka plan ekleyin.  
4.	İlk slayta zoom çerçevelerini (oluşturulan slaytlara referansları içeren) ekleyin.  
5.	Çerçeveyi doldurmak için Presentation nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
6.	İlk zoom çerçeve nesnesi için özel bir görsel ayarlayın.  
7.	İkinci zoom çerçeve nesnesi için çizgi biçimini değiştirin.  
8.	İkinci zoom çerçeve nesnesinin görselinden arka planı kaldırın.  
9.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Add yeni slaytları sunuma ekle
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Create a background for the second slide
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Create a text box for the second slide
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Create a background for the third slide
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Create a text box for the third slide
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame nesneleri ekle
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Create a new image for the zoom object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Set custom image for zoomFrame1 object
    zoomFrame1.image = image

    # Set a zoom frame format for the zoomFrame2 object
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Do not show background for zoomFrame2 object
    zoomFrame2.show_background = False

    # Save the presentation
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Bölüm Yakınlaştırması**

Bölüm yakınlaştırması, sunumunuzdaki bir bölüme verilen bir bağlantıdır. Bölüm yakınlaştırmalarını, gerçekten vurgulamak istediğiniz bölümlere geri dönmek için kullanabilirsiniz. Ya da sunumunuzun belirli bölümlerinin nasıl bağlandığını göstermek için kullanabilirsiniz.  

![bölüm yakınlaştırma seçimi](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için Aspose.Slides, [SectionZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectionzoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfındaki bazı yöntemleri sağlar.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Bir slayta bölüm yakınlaştırma çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Yeni bir slayt oluşturun.  
3.	Oluşturulan slayta tanımlama arka planı ekleyin.  
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5.	İlk slayta bölüm yakınlaştırma çerçevesini (oluşturulan bölüme referansları içeren) ekleyin.  
6.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Sunuma yeni bir bölüm ekler
    pres.sections.add_section("Section 1", slide)

    # Bir SectionZoomFrame nesnesi ekler
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Sunumu kaydeder
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Aspose.Slides for Python kullanarak, farklı bir slayt önizleme görseli ile bölüm yakınlaştırma çerçevesi oluşturabilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Yeni bir slayt oluşturun.  
3.	Oluşturulan slayta tanımlama arka planı ekleyin.  
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5.	Çerçeveyi doldurmak için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
6.	İlk slayta bölüm yakınlaştırma çerçevesini (oluşturulan bölüme referans içeren) ekleyin.  
7.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Sunuma yeni bir bölüm ekler
    pres.sections.add_section("Section 1", slide)

    # Zoom nesnesi için yeni bir görsel oluşturur
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Bir SectionZoomFrame nesnesi ekler
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Sunumu kaydeder
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Bölüm Yakınlaştırma Çerçevelerinin Biçimlendirilmesi**

Daha karmaşık bölüm yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir bölüm yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır.  

Bir slayttaki bölüm yakınlaştırma çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Yeni bir slayt oluşturun.  
3.	Oluşturulan slayta tanımlama arka planı ekleyin.  
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5.	İlk slayta bölüm yakınlaştırma çerçevesini (oluşturulan bölüme referansları içeren) ekleyin.  
6.	Oluşturulan bölüm yakınlaştırma nesnesinin boyutunu ve konumunu değiştirin.  
7.	Çerçeveyi doldurmak için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
8.	Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.  
9.	*Bağlı bölümden orijinal slayta geri dönme* özelliğini ayarlayın.  
10.	Bölüm yakınlaştırma çerçevesi nesnesinin görselinden arka planı kaldırın.  
11.	İkinci zoom çerçeve nesnesi için çizgi biçimini değiştirin.  
12.	Geçiş süresini değiştirin.  
13.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Sunuma yeni bir Bölüm ekler
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrame nesnesi ekle
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrame için biçimlendirme
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Sunumu kaydeder
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Özet Yakınlaştırması**

Özet yakınlaştırması, sunumunuzun tüm parçalarının bir kerede gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı kullanarak sunumunuzdaki bir yerden başka bir yere istediğiniz sırada geçiş yapabilirsiniz. Yaratıcı olabilir, ilerleyebilir ya da slayt gösterinizin bölümlerine kesintisiz bir şekilde geri dönebilirsiniz.  

![özet yakınlaştırma](summaryzoom.png)

Özet yakınlaştırma nesneleri için Aspose.Slides, [SummaryZoomFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomsection/) ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomsectioncollection/) sınıflarını ve [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) sınıfındaki bazı yöntemleri sağlar.

### **Özet Yakınlaştırma Oluşturma**

Bir slayta özet yakınlaştırma çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümlerle yeni slaytlar oluşturun.  
3.	Özet yakınlaştırma çerçevesini ilk slayta ekleyin.  
4.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Slayt dizisini oluştur
    for slideNumber in range(5):
        # Sunuma yeni slaytlar ekle
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Slayt için bir arka plan oluştur
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Slayt için bir metin kutusu oluştur
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # İlk slayttaki tüm slaytlar için zoom nesneleri oluştur
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ReturnToParent özelliğini ayarlayarak ilk slayta geri dön
        zoomFrame.return_to_parent = True

    # Sunumu kaydet
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```
### **Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

Bir özet yakınlaştırma çerçevesindeki tüm bölümler, [SummaryZoomSection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomsection/) nesneleriyle temsil edilir ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/summaryzoomsectioncollection/) içinde depolanır. Bir özet yakınlaştırma bölümü nesnesini eklemek veya kaldırmak için [SummaryZoomSectionCollection] sınıfını şu şekilde kullanabilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümlerle yeni slaytlar oluşturun.  
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4.	Sunuma yeni bir slayt ve bölüm ekleyin.  
5.	Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.  
6.	İlk bölümü özet yakınlaştırma çerçevesinden kaldırın.  
7.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Yeni bir bölüm ekler
    pres.sections.add_section("Section 1", slide)

    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Yeni bir bölüm ekler
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame nesnesi ekler
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Yeni bir bölüm ekler
    section3 = pres.sections.add_section("Section 3", slide)

    # Summary Zoom'a bir bölüm ekler
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Summary Zoom'dan bölümü kaldırır
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Sunumu kaydeder
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Özet Yakınlaştırma Bölümlerinin Biçimlendirilmesi**

Daha karmaşık özet yakınlaştırma bölümü nesneleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir özet yakınlaştırma bölümü nesnesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır.  

Bir özet yakınlaştırma çerçevesindeki özet yakınlaştırma bölümü nesnesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümlerle yeni slaytlar oluşturun.  
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4.	`SummaryZoomSectionCollection` içinden ilk nesne için bir özet yakınlaştırma bölümü nesnesi alın.  
5.	Çerçeveyi doldurmak için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesine bağlı images koleksiyonuna bir görsel ekleyerek bir `PPImage` nesnesi oluşturun.  
6.	Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.  
7.	*Bağlı bölümden orijinal slayta geri dönme* özelliğini ayarlayın.  
8.	İkinci zoom çerçeve nesnesi için çizgi biçimini değiştirin.  
9.	Geçiş süresini değiştirin.  
10.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Yeni bir bölüm ekler
    pres.sections.add_section("Section 1", slide)

    #Sunuma yeni bir slayt ekler
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Yeni bir bölüm ekler
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame nesnesi ekler
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # İlk SummaryZoomSection nesnesini alır
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # SummaryZoomSection nesnesi için biçimlendirme
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Sunumu kaydeder
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Hedef gösterildikten sonra 'ana' slayta dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sectionzoomframe/) `return_to_parent` davranışına sahiptir; etkinleştirildiğinde, izleyicileri hedef içeriği ziyaret ettikten sonra orijinal slayta geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, `transition_duration` ayarlamayı destekler; böylece atlama animasyonunun ne kadar süreceğini kontrol edebilirsiniz.

**Bir sunum kaç Zoom nesnesi içerebilir konusunda sınırlamalar var mı?**

Belirtilen kesin bir API sınırı yoktur. Pratik sınırlamalar, sunumun genel karmaşıklığına ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutunu ve render süresini göz önünde bulundurun.