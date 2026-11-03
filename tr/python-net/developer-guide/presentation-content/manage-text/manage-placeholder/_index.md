---
title: Python'da Sunum Yer Tutucularını Yönet
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
description: "Aspose.Slides for Python via .NET kullanarak metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi, ayrıca yer tutucu kalıtımını nasıl anlayacağınızı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytı ya da ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) özelliği aracılığıyla sunar. Bu özellik, normal bir şekil için `None` ya da bir [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) kullanın.

Yer tutucu türünü öğrendikten sonra şekil sınıfı hâlâ önemlidir:

- Boş metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) hem de çalışma zamanındaki şekil sınıfını kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) bir yer tutucunun rolünü açıklar; şeklin çalışma zamanı sınıfını garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tür kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan kalıtım alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve kendi düzeninden kalıtım alabilir.

[Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) metodunu çağırarak bu hiyerarşide bir seviye yukarı çıkabilirsiniz. Bir slayt yer tutucusu normalde düzen yer tutucusunu döndürür; bir düzen yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `None` döndürür.

Aşağıdaki örnek, birinci slayttaki yer tutucuları listeler ve temel yer tutucularını rapor eder:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma yaratır veya değiştirir. İlgili düzeni veya ana slaytı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları işgal ettiği için kalıtım başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut bir nesneyi normal bir şekil olarak tutmak için [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) kullanın. Bunun [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) özelliği `None` olur, ancak şekil slayt koleksiyonunda kalır. Bunun tersine, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) şekli koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve birinci slaytta boş olmayan bir metin yer tutucusunu içeren bir `template.pptx` dosyası gerektirir. Düzen veya ana slayttan devralınan biçimlendirmeye sahip bir yer tutucuyu kullanarak ilişkiyi kaldırmanın etkisini görebilirsiniz. Örnek, aynı şeklin kaldığını kontrol eder, yöntemi artık normal şekil üzerinde tekrar çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunu kaldırmak, devralınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek bu ayarları bilerek değiştirmeden bırakır, bu nedenle çıktı farklı görünebilir. Konumu ve boyutu tamamen devralınmış bir şekil, çağrı sonrasında sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelebilir.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Normal bir şekil üzerinde yöntemi çağırmanın bir etkisi yoktur.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Uygun bir yer tutucu için üç kontrol de `True` yazdırır. Metin kalır, ancak devralınan konum, boyut, dönüş, yazı tipi, paragraf hizalaması, metin çerçevesi kenar boşlukları, dikey tutma, dolgu ve çizgi ayarları yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, devralınan başlık biçimlendirmesi normal metin biçimlendirmesine geri dönebilir. Düzenler hakkında daha fazla bilgi için [Slayt Düzeni](/slides/tr/python-net/slide-layout/) bölümüne bakın.

İstenen görünümü korumak için, çağrıdan önce çözümlenmiş konum, boyut ve dönüşü yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), ve [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) üzerinden alın. Yalnızca etkili‑format nesnelerine güvenmeyin, çünkü ilişki kaldırıldıktan sonra metin‑biçimleme değerleri değişebilir. Yakalanan değerleri normal şekle sonradan açıkça uygulayın; buna şablonunuzda kullanılan yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, dolgu ve çizgi dahildir.

Devralınan şekil geometrisi ayrıca [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) üzerinden açıkça atanabilir. Dikdörtgen bir metin yer tutucusu için bu, [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) atanması anlamına gelir; yalnızca dolgu ve çizgiyi geri yüklemek görünür dikdörtgeni geri getirmeyebilir. Ek efektler veya daha karmaşık biçimlendirme içeren şablonlar da bu ayarların ele alınmasını gerektirir.

## **Yer Tutucuda Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metin destekler. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) özelliğini kullanın.

Bu örnek, birinci slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) nesnesi olarak ele almaktan kaçınır. Ayrıca, kırılgan bir şekil indeksine dayanmaktansa yer tutucuyu amacına göre tanımlar.

## **Bir Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda gösterilen tasarım‑zamanı yönergesidir; örnek: *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine düzen yer tutucusunda özel bir ipucu metni ayarlayın. Düzeni, [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) aracılığıyla alın ve [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) üzerinden gezin.

Aşağıdaki örnek, birinci slayt tarafından kullanılan düzen üzerindeki başlık ve alt‑başlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Kullanıcı veya program gerçek içeriği sağladığında ipucu artık gösterilmez. Bir ipucunu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

Ele alınması gereken iki durum vardır:

- Resim yer tutucusu zaten dolu ve bir [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) ve [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) aracılığıyla değiştirin.
- Henüz boş bir yer tutucuysa, [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değişim, yeni bir yer tutucu değil yerel bir resim çerçevesidir; çünkü [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) yalnızca okunur. Ayrılmış konumu tutar ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisini korumak önemliyse, önce PowerPoint’te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile ortaya çıkan [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel etkiler için [Resim Çerçevelerini Yönet](/slides/tr/python-net/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesine veya resim dolgusuna aittir, yer tutucu meta verisine değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) ile temsil edilebilir. Bu örnek, hem yer tutucu türüne hem de çalışma zamanındaki sınıfa göre böyle bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) değeri taşır. PowerPoint’te bu, grafik, tablo, diyagram, resim ve medya dahil olmak üzere çeşitli içerik türlerini başlatan bir tetikleyici görevi görür. Doldurulduktan sonra, içinde ne olduğunu öğrenmek için gerçek şekil sınıfını inceleyin. Özelleşmiş düzenler ayrıca [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), veya [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) türlerini ortaya çıkarabilir.

Aspose.Slides, sadece [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) değerini değiştirerek boş bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) yer tutucusunu bir [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) haline getirmez; tür sadece okunur. Boş bir grafik veya içerik alanını programlı olarak doldurmak için gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir grafik için yapar:

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

Eklenen grafik, normal bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan kalıtım almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek istediğinizde özel [grafik yönetimi makaleleri](/slides/tr/python-net/powerpoint-charts/) kullanın.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelleme**

Aşağıdaki uçtan uca örnek bir şablon açar, birinci slaytta başlık veya resim yer tutucusunu arar, yer tutucu ve şekil türlerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı şekil sınıfı gibi davranmaktan bilinçli olarak kaçınır.

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

**Bir temel yer tutucu nedir?**

Temel bir yer tutucu, başka bir yer tutucunun devraldığı düzen veya ana slayttaki karşılık gelen şekildir. Onu elde etmek için [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `None` döndürür.

**Bir düzen yer tutucusunu düzenleyerek tüm slayt başlıklarını değiştirebilir miyim?**

Düzen üzerinden devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda saklanır. Sunumdaki tüm başlık metinlerini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncellemeniz gerekir.

**Tarih, slayt numarası, üstbilgi ve altbilgi yer tutucularını nasıl yönetirim?**

İlgili slayt, düzen, ana, notlar veya el ilanı kapsamındaki üstbilgi ve altbilgi yöneticilerini kullanın. Tam örnekler için [Sunum Üstbilgi ve Altbilgi Yönetimi](/slides/tr/python-net/presentation-header-and-footer/) bölümüne bakın.