---
title: Python'da Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/python-java/manage-placeholder/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi, ayrıca yer tutucu kalıtımını nasıl anlayacağınızı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytından veya ana slayttan miras alabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) yöntemi aracılığıyla sunar. Bu yöntem normal bir şekil için `None` yerine bir [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne tür içerik barındırması gerektiğini belirlemek için [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) yöntemini kullanın.

Şekil tipi, yer tutucu tipini öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucu genellikle bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucu bir [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucu bir [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucu birkaç farklı içerik türü barındırabilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) hem de çalışma zamanı şekil tipini kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı tipini garanti etmez. Metin, resim, grafik, tablo veya medya özgü üyelere erişmeden önce her zaman tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana düzeyinde yer tutucuları tanımlar.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan miras alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden miras alabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) yöntemini çağırın. Bir slayt yer tutucusu normalde düzen yer tutucusunu döndürür; bir düzen yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu olmadığında yöntem `None` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve bunların temel yer tutucularını raporlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzeni veya ana slaytı düzenlemek, bu ayarı hâlâ miras alan tüm slaytları etkileyebilir. Yerel normal bir şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları kapladığı için miras almaya başlamaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut bir nesneyi normal bir şekil olarak tutmak için [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) yöntemini kullanın. Bunun [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) yöntemi `None` döndürür, ancak şekil slaytın koleksiyonunda kalır. Buna karşılık, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusunu içeren `template.pptx` dosyasını gerektirir. İlişkinin kaldırılmasının etkisini görmek için biçimlendirmesi düzeninden veya ana slayttan miras alınmış bir yer tutucu kullanın. Örnek, aynı şeklin kaldığını kontrol eder, yöntemi artık normal şekil üzerinde tekrar çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunun kaldırılması, miras alınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek, bu ayarları kasıtlı olarak değiştirmeden bırakır, bu yüzden çıktı farklı görünebilir. Pozisyonu ve boyutu tamamen miras alınan bir şekil, çağrı sonrası sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelebilir.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Normal bir şekil üzerinde yöntemi çağırmak hiçbir etki yapmaz.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Uyan bir yer tutucu için, üç kontrol de `True` yazdırır. Metin kalır, ancak yer tutucu ilişkisi kaldırıldığında miras alınan konum, boyut, döndürme, yazı tipi, paragraf hizalaması, metin çerçevesi kenar boşlukları, dikey sabitleme, dolgu ve çizgi ayarları değişebilir. Örneğin, miras alınan başlık biçimlendirmesi normal metin biçimlendirmesine geri dönebilir. Düzenler hakkında daha fazla bilgi için [Slide Layout](/slides/tr/python-java/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce hesaplanmış konum, boyut ve döndürmeyi yakalayın ve gerekli etkin biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) ve [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) yöntemleriyle alın. Yalnızca etkin biçim nesnelerine güvenmeyin, çünkü ilişkisi kaldırıldıktan sonra metin biçimlendirme değerleri değişebilir. Yakalanan değerleri daha sonra normal şekle açıkça uygulayın; buna şablonunuzda kullanılan yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin çerçevesi ayarları, dolgu ve çizgi dahildir.

Miras alınan şekil geometrisi ayrıca [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) ile açıkça atanabilir. Dikdörtgen bir metin yer tutucu için bu, [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) atanması demektir; yalnızca dolgu ve çizgi geri yüklendiğinde görünür dikdörtgen geri gelmeyebilir. Ek efektler veya daha karmaşık biçimlendirmeye sahip şablonlarda bu ayarların da ele alınması gerekir.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış başlık, alt başlık, gövde ve metin yer tutucuları normalde metni destekler. [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra its [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) metodunu kullanın.

Aşağıdaki örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) olarak ele almaktan kaçınır. Ayrıca, kırılgan bir şekil indeksine dayanmak yerine yer tutucuyu amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda görünen tasarım zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaydın şekil koleksiyonundan erişmeye çalışmak yerine, düzen yer tutucusunda özel ipucu metni ayarlayın. Düzenine [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) ile erişin ve [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyonu döngüyle gezinin.

Aşağıdaki örnek, ilk slayt tarafından kullanılan düzen üzerindeki başlık ve alt başlık ipuçlarını değiştirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Bir kullanıcı veya program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum ele alınmalıdır:

- Eğer resim yer tutucu zaten dolu ve bir [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) ve [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) aracılığıyla değiştirin.
- Eğer hâlâ boş bir yer tutucu ise, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) ile yer tutucunun koordinatlarına bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Boş bir yer tutucu için oluşturulan yedekleme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) bir ayarlayıcı sağlamaz. Ayrılmış konumu tutar ancak artık yer tutucuya özgü davranışı miras almaz. Yer tutucu ilişkisini korumak önemliyse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından oluşan [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) nesnesini Aspose.Slides ile güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim‑özel efektler için [Manage Picture Frames](/slides/tr/python-java/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verileriyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucu bir [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, yer tutucu tipi ve çalışma zamanı tipiyle bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) tipindedir. PowerPoint'te bu, grafikler, tablolar, diyagramlar, resimler ve medya gibi çeşitli içerik türlerini başlatan bir araç görevi görür. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil tipini inceleyin. Özelleşmiş düzenler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) tiplerini de sunabilir.

Aspose.Slides, sadece [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) değiştirerek boş bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) yer tutucusunu bir [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) haline dönüştürmez; tip API aracılığıyla değiştirilemez. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eklenen grafik, normal bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan miras almaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek istediğinizde ilgili [chart management articles](/slides/tr/python-java/powerpoint-charts/) sayfalarını kullanın.

## **Tam Örnek: Metin veya Görsel İçeriği Güncelleme**

Aşağıdaki uçtan uca örnek, bir şablonu açar, ilk slaytta bir başlık veya resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, bir şekil indeksini varsaymaktan veya her yer tutucuyu aynı tip olarak işlemekten kasıtlı olarak kaçınır.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Temel bir yer tutucu nedir?**

Temel bir yer tutucu, başka bir yer tutucunun miras aldığı düzen veya ana slayttaki karşılık gelen şekildir. Onu almak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) yöntemini kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığı için `None` döndürür.

**Bir düzen yer tutucusunu düzenleyerek tüm slayt başlıklarını değiştirebilir miyim?**

Bir düzen aracılığıyla kalıtılmış biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytların üzerinden geçip her başlık yer tutucusunu güncelleyin.

**Tarih, slayt numarası, başlık ve alt bilgi yer tutucularını nasıl yönetebilirim?**

Uygun slayt, düzen, ana slayt, not veya dağıtım kapsamında başlık ve alt bilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/python-java/presentation-header-and-footer/) sayfasına bakın.