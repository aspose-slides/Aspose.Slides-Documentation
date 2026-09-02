---
title: Python’da Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/python-net/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi öğrenin ve yer tutucu kalıtımını anlayın."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarları bir düzen slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/placeholder/) özelliği aracılığıyla sunar. Bu özellik, normal bir şekil için `None` döndürür veya bir [Placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [Placeholder.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholder/type/) özelliğini kullanın.

Şekil sınıfı, yer tutucu tipini öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholder/type/) hem de çalışma zamanındaki şekil sınıfını kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholder/type/) yer tutucunun rolünü tanımlar; şeklin çalışma zamanındaki sınıfını garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan kalıtım alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden kalıtım alabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) yöntemini çağırın. Bir slayt yer tutucusu genellikle düzen yer tutucusunu döndürür; bir düzen yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `None` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını raporlar:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzen ya da ana slaytı düzenlemek, hala bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları işgal ettiği için kalıtım başlamaz.

## **Yer Tutucuda Metni Değiştir**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metni destekler. [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/text_frame/) özelliğini kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) nesneleri olarak ele almayı önler. Ayrıca, kırılgan bir şekil indeksine dayanmak yerine yer tutucuyu amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarla**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Özel bir ipucu metnini normal bir slayttaki şekil koleksiyonundan almaya çalışmak yerine, düzen yer tutucusunda ayarlayın. Düzeni, [Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/) aracılığıyla erişin ve [LayoutSlide.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/shapes/) üzerinden döngü yapın.

Aşağıdaki örnek, ilk slayt tarafından kullanılan düzenin başlık ve alt‑başlık ipuçlarını değiştirir:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucunu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelle**

Ele alınması gereken iki durum vardır:

- Resim yer tutucusu zaten doluysa ve bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFillFormat.picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/picture/) ve [Picture.image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/image/) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucusuysa, [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucusunu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape.placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/placeholder/) yalnızca okunabilir. Ayrılmış konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisini korumak kritikse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) nesnesini güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Manage Picture Frames](/slides/tr/python-net/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi ya da resim doldurmasıyla ilgilidir, yer tutucu meta verisiyle ilgili değildir.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) ile temsil edilebilir. Bu örnek, grafik yer tutucusunu hem yer tutucu tipi hem de çalışma zamanındaki sınıfı kullanarak bulur, başlığını değiştirir ve dosyayı kaydeder:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType.OBJECT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/) tipine sahiptir. PowerPoint’te bu, grafikler, tablolar, diyagramlar, resimler ve medyalar gibi çeşitli içerik türlerini başlatan bir başlatıcı görevi görür. Doldurulduktan sonra, içinde ne olduğunu öğrenmek için gerçek şekil sınıfını inceleyin. Özelleştirilmiş düzenler ayrıca [PlaceholderType.CHART](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/), veya [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholdertype/) tiplerini ortaya koyabilir.

Aspose.Slides, sadece [Placeholder.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/placeholder/type/) değiştirerek boş bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) yer tutucusunu bir [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) haline getirmez; tip yalnızca okunabilir. Boş bir grafik ya da içerik alanını programlı olarak doldurmak için, gereken nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir grafik için yapar:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Eklenen grafik, sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan kalıtım almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek zorunda kalırsanız, ilgili [chart management articles](/slides/tr/python-net/powerpoint-charts/) bölümüne bakın.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelle**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, bir şekil indeksini varsaymaktan ya da her yer tutucuyu aynı şekil sınıfı olarak işlemektеn kaçınmak için bilinçli olarak tasarlanmıştır:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Temel yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun kalıtım yaptığı, düzen ya da ana slayttaki karşılık gelen şekildir. Onu elde etmek için [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) yöntemini kullanın. Normal bir yerel şekil `None` döndürür çünkü yer tutucu hiyerarşisinin bir parçası değildir.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden kalıtım alınan biçimlendirmeyi ya da ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncellemeniz gerekir.

**Tarih, slayt‑numarası, başlık ve altbilgi yer tutucularını nasıl yönetirim?**

Bu öğeler için uygun slayt, düzen, ana, not veya el ilanı kapsamındaki başlık ve altbilgi yöneticilerini kullanın. Ayrıntılı örnekler için [Manage Presentation Header and Footer](/slides/tr/python-net/presentation-header-and-footer/) bölümüne bakın.