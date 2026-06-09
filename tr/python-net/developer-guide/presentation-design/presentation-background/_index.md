---
title: Python'da Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/python-net/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- düz renk
- degrade renk
- görüntü arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument dosyalarında Aspose.Slides for Python via .NET kullanarak dinamik arka planları nasıl ayarlayacağınızı, sunumlarınızı güçlendirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Düz renkler, degradeler ve görüntüler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **ana slayt** (birden çok slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Slayt için Düz Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için arka planı düz renk olarak ayarlamanıza olanak tanır—sunum bir ana slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/backgroundtype/) değerini `OWN_BACKGROUND` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) değerini `SOLID` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/) üzerindeki `solid_fill_color` özelliğini kullanarak düz arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, normal bir slayt için mavi düz renk arka planının nasıl ayarlanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Slaytın arka plan rengini mavi olarak ayarlayın.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Sunumu diske kaydedin.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ana Slayt için Düz Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slayt için arka planı düz renk olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle ana slaytın arka planı için düz bir renk seçtiğinizde, bu renk her slayta uygulanır.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/backgroundtype/) (via `masters`) değerini `OWN_BACKGROUND` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) değerini `SOLID` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/) üzerindeki `solid_fill_color` özelliğini kullanarak düz arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, ana slayt için düz bir renk (orman yeşili) arka planının nasıl ayarlanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Master slaytının arka plan rengini Orman Yeşili olarak ayarlayın.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Sunumu diske kaydedin.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt için Degrade Arka Planı Ayarlama**

Degrade, renklerin yavaş yavaş değişmesiyle oluşturulan görsel bir etkidir. Slayt arka planı olarak kullanıldığında, degradeler sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için arka plan olarak bir degrade renk ayarlamanıza olanak tanır.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/backgroundtype/) değerini `OWN_BACKGROUND` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) değerini `GRADIENT` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/) üzerindeki `gradient_format` özelliğini kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir slayt için degrade renk arka planının nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Arka plana bir degrade efekti uygulayın.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Sunumu diske kaydedin.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Slayt Arka Planı Olarak Görüntü Ayarlama**

Düz ve degrade doldurmaların yanı sıra, Aspose.Slides slayt arka planı olarak görüntüler kullanmanıza da izin verir.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/backgroundtype/) değerini `OWN_BACKGROUND` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) değerini `PICTURE` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun image koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/) üzerindeki `picture_fill_format` özelliğini kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir slayt için görüntüyü arka plan olarak nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Arka plan görüntüsü özelliklerini ayarlayın.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Görüntüyü yükleyin.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Sunumu diske kaydedin.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki kod örneği, arka plan doldurma tipini döşeli bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Arka plan doldurması için kullanılan görüntüyü ayarlayın.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Görüntü doldurma modunu Döşeme olarak ayarlayın ve döşeme özelliklerini düzenleyin.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Daha fazla oku: [**Kare Görüntüyü Doku Olarak**](/slides/tr/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slayt arka planı görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz, böylece slayt içeriği daha belirgin olur. Aşağıdaki Python kodu, slayt arka planı görüntüsünün şeffaflığını nasıl değiştireceğinizi gösterir:

```python
transparency_value = 30  # Örneğin.

# Resim dönüşüm işlemleri koleksiyonunu al.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Mevcut bir sabit yüzde şeffaflık etkisini bulun.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Yeni şeffaflık değerini ayarlayın.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Slayt Arka Planı Değerini Al**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için [IBackgroundEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ibackgroundeffectivedata/) sınıfını sağlar. Bu sınıf, etkili [FillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/effectformat/) bilgilerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/) sınıfının `background` özelliğini kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki Python örneği, bir slaytın etkili arka plan değerini nasıl alacağınızı gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Ana slayt, yerleşim ve temayı dikkate alarak etkili arka planı alın.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **SSS**

**Özel bir arka planı sıfırlayıp tema/yerleşim arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel dolgusunu kaldırın, böylece arka plan tekrar ilgili [yerleşim](/slides/tr/python-net/slide-layout/)/[ana](/slides/tr/python-net/slide-master/) slaytından (yani [tema arka planı](/slides/tr/python-net/presentation-theme/)) devralınır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Bir slaytın kendi dolgu ayarı varsa, bu değişmez. Arka plan [yerleşim](/slides/tr/python-net/slide-layout/)/[ana](/slides/tr/python-net/slide-master/) slaytından devralınmışsa, yeni tema ile eşleşecek şekilde güncellenir.