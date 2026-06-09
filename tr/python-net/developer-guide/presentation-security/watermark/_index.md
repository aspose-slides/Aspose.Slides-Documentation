---
title: Sunumlara Python'da Filigran Ekleme
linktitle: Filigran
type: docs
weight: 40
url: /tr/python-net/watermark/
keywords:
- filigran
- metin filigranı
- görüntü filigranı
- filigran ekle
- filigranı değiştir
- filigranı kaldır
- filigranı sil
- PPT'ye filigran ekle
- PPTX'e filigran ekle
- ODP'ye filigran ekle
- PPT'den filigranı kaldır
- PPTX'den filigranı kaldır
- ODP'den filigranı kaldır
- PPT'den filigranı sil
- PPTX'den filigranı sil
- ODP'den filigranı sil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python'da PowerPoint ve OpenDocument sunumlarında taslak, gizli bilgi, telif hakkı ve daha fazlasını göstermek için metin ve görüntü filigranlarını nasıl yöneteceğinizi öğrenin."
---
## **Giriş**

**Bir filigran** bir sunumda bir slayt üzerinde veya tüm sunum slaytları boyunca kullanılan bir metin ya da resim damgasıdır. Genellikle, bir filigran sunumun taslak olduğunu göstermek (ör. "Draft" filigranı), gizli bilgi içerdiğini göstermek (ör. "Confidential" filigranı), hangi şirkete ait olduğunu belirtmek (ör. "Company Name" filigranı), sunum yazarını tanımlamak vb. amaçlarla kullanılır. Bir filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

In [**Aspose.Slides**](https://products.aspose.com/slides/tr/python-net/), PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ve davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranları eklemek için [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) sınıfını, resim filigranları eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) sınıfını veya bir filigran şekline resmi doldurmayı kullanmanızdır. `PictureFrame`, [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfını uygular, bu sayede şekil nesnesinin tüm esnek ayarlarını kullanabilirsiniz. `TextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnesine sarmalanır.

Bir filigran iki şekilde uygulanabilir: tek bir slayta veya tüm sunum slaytlarına. Tüm sunum slaytlarına filigran uygulamak için Slayt Ana Şablonu (Slide Master) kullanılır — filigran Slayt Ana Şablonuna eklenir, orada tamamen tasarlanır ve bireysel slaytlarda filigranı düzenleme izni etkilenmeden tüm slaytlara uygulanır.

Bir filigranın genellikle diğer kullanıcılar tarafından düzenlenemez olduğu kabul edilir. Filigranın (daha doğrusu filigranın üst şeklinin) düzenlenmesini engellemek için Aspose.Slides şekil kilitleme işlevi sunar. Belirli bir şekil normal bir slaytta veya Slayt Ana Şablonunda kilitlenebilir. Filigran şekli Slayt Ana Şablonunda kilitlenirse, tüm sunum slaytlarında kilitli olur.

Filigrana bir ad atayabilirsiniz; böylece gelecekte silmek istediğinizde slaytın şekillerinde adıyla bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle filigranlarda ortak özellikler bulunur, örneğin ortalanmış hizalama, döndürme, ön konum vb. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

Bir PPT, PPTX veya ODP dosyasında metin filigranı eklemek için önce slayta bir şekil ekleyebilir, ardından bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) sınıfı ile temsil edilir. Bu sınıf [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfından türetilmediği için, filigranı esnek bir şekilde konumlandırmak için geniş bir özellik seti yoktur. Bu nedenle, [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) nesnesi bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnesine sarmalanır. Şekle filigran metni eklemek için aşağıdaki gibi [add_text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/add_text_frame/#str) metodunu kullanın.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfının Nasıl Kullanılacağını](/slides/tr/python-net/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Tüm sunuma (yani tüm slaytlara aynı anda) metin filigranı eklemek istiyorsanız, bunu [MasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslide/) içine ekleyin. Geri kalan mantık tek slayta filigran eklemekle aynıdır — bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesnesi oluşturun ve ardından [add_text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/add_text_frame/#str) metodunu kullanarak filigranı ona ekleyin.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır](/slides/tr/python-net/slide-master/)
{{% /alert %}}

### **Filigran Şekli Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekli dolgu ve çizgi renkleriyle biçimlendirilir. Aşağıdaki kod satırları şekli şeffaf yapar.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Metin Filigranı İçin Yazı Tipi Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için bu kodu kullanın:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Metin Filigranını Ortalamak**

Filigranı bir slaytta ortalamak mümkündür; bunun için aşağıdakileri yapabilirsiniz:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Sunuma Resim Filigranı Ekleme**

Sunum slaytına bir resim filigranı eklemek için aşağıdakileri yapabilirsiniz:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Filigranı Düzenlemeden Korumak**

Filigranın düzenlenmesini engellemek gerekiyorsa, şekil üzerinde [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/auto_shape_lock/) özelliğini kullanın. Bu özellik sayesinde şekli seçilmekten, yeniden boyutlandırılmaktan, konumlandırılmaktan, diğer öğelerle gruplanmaktan, metni düzenlemeden korumaktan ve daha fazlasından koruyabilirsiniz:

```py
# Filigran şeklinin değiştirilmesinden kilitle
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Filigranı Öne Getirme**

Aspose.Slides içinde şekillerin Z sırası, [ShapeCollection.reorder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) yöntemiyle ayarlanabilir. Bunun için sunum slaytları listesinden bu yöntemi çağırıp şekil referansını ve istenen sıra numarasını yönteme geçirmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir veya arkasına gönderebilirsiniz. Bu özellik, bir filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle faydalıdır:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Filigran Döndürmesini Ayarlama**

Aşağıda, filigranı slayt boyunca köşegen bir konuma getirmek için döndürmenin nasıl ayarlanacağına dair bir kod örneği verilmiştir:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Filigrana Bir Ad Atama**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte ona erişebilir, değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için [AutoShape.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/name/) özelliğine atama yapın:

```py
watermark_shape.name = "watermark"
```

## **Filigranı Kaldırma**

Filigran şeklini kaldırmak için [AutoShape.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/name/) metodunu kullanarak slayt şekilleri içinde bulabilirsiniz. Ardından, filigran şeklini [ShapeCollection.remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/remove/#ishape) metoduna geçirin:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Canlı Bir Örnek**

**Aspose.Slides ücretsiz** [Filigran Ekle](https://products.aspose.app/slides/tr/watermark) ve [Filigranı Kaldır](https://products.aspose.app/slides/tr/watermark/remove-watermark) çevrimiçi araçlarını inceleyebilirsiniz.

![Filigran ekleme ve kaldırma için çevrimiçi araçlar](online_tools.png)

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim örtüsüdür; fikir mülkiyetini korumaya, marka tanınırlığını artırmaya veya sunumların izinsiz kullanımını önlemeye yardımcı olur.

**Bir sunumdaki tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides her slayta filigran eklemenizi sağlar. Tüm slaytlar üzerinde döngü yaparak filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Filigranın şeffaflığını, şeklin dolgu ayarlarını ([FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/)) değiştirerek ayarlayabilirsiniz. Bu, filigranın hafif olmasını ve slayt içeriğinden dikkat çekmemesini sağlar.

**Filigranlar için hangi görüntü formatları destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası gibi çeşitli görüntü formatlarını destekler.

**Metin filigranının yazı tipini ve stilini özelleştirebilir miyim?**

Evet, herhangi bir yazı tipi, boyut ve stil seçerek sunum tasarımınıza ve marka tutarlılığına uyum sağlayabilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştiririm?**

[shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnesinin koordinatlarını, boyutunu ve döndürme özelliklerini değiştirerek konum ve yön ayarlarını yapabilirsiniz.