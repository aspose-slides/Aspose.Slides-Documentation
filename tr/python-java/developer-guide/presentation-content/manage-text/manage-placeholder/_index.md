---
title: Python'da Sunum Yer Tutucularını Yönet
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
- istem metni
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile metin, resim, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi ve yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape.getPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getPlaceholder) yöntemiyle sağlar. Bu yöntem normal bir şekil için `None` ya da bir [Placeholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [Placeholder.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/#getType) kullanın.

Şekil tipi, yer tutucu tipini öğrendikten sonra da önem taşır:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu birçok içerik türünü barındırabilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/#getType) hem de çalışma zamanındaki şekil tipini kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/#getType) bir yer tutucunun rolünü açıklar; şeklin çalışma zamanındaki tipini garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana seviyesindeki yer tutucuları tanımlar.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan yerleşimi tanımlar ve ana slayttan devralabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden devralabilir.

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) yöntemiyle bu hiyerarşide bir seviye yukarı çıkın. Bir slayt yer tutucusu genellikle düzen yer tutucusunu döndürür; bir düzen yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `None` döndürür.

Aşağıdaki örnek ilk slayttaki yer tutucuları listeler ve temel yer tutucularını raporlar:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için bir yerel geçersiz kılma oluşturur veya değiştirir. İlgili düzeni veya anayı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kapladığı için devralmaya başlamaz.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış başlık, alt başlık, gövde ve metin yer tutucuları normalde metni destekler. [getTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#getTextFrame) yöntemini kullanmadan önce [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) olup olmadığını kontrol edin.

Bu örnek ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) olarak işlemeyi önler. Ayrıca yer tutucuyu kırılgan bir şekil indeksine güvenmek yerine amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda görüntülenen tasarım zamanı talimatıdır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine, düzen yer tutucusunda özel bir ipucu metni ayarlayın. Düzeni, [Slide.getLayoutSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getLayoutSlide) yöntemiyle alın ve [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyon üzerinde döngü yapın.

Aşağıdaki örnek ilk slayt tarafından kullanılan düzen üzerindeki başlık ve alt başlık ipuçlarını değiştirir:

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

İpucu metni normal slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içeriği sağladığında, ipucu artık gösterilmez. Bir ipucu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

Ele alınması gereken iki durum vardır:

- Resim yer tutucusu zaten doldurulmuş ve bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFillFormat.getPicture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#getPicture) ve [Picture.setImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#setImage) yöntemleriyle değiştirin.
- Eğer hâlâ boş bir yer tutucuysa, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) ile yer tutucunun koordinatlarına bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değişiklik, bir yeni yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape.getPlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getPlaceholder) bir ayarlayıcı sunmaz. Ayrılan konumu korur ancak artık yer tutucuya özgü davranışı devralmaz. Yer tutucu ilişkisini korumak önemliyse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından ortaya çıkan [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) nesnesini Aspose.Slides ile güncelleyin.

Görüntü şeffaflığı, kırpma ve diğer resim‑özel efektler için [Resim Çerçevelerini Yönet](/slides/tr/python-java/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesine veya resim doldurmasına aittir, yer tutucu meta verilerine değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, bu grafiği hem yer tutucu tipine hem de çalışma zamanı tipine göre bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Object) tipine sahiptir. PowerPoint'te bu, grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türlerini başlatan bir araçtır. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil tipini inceleyin. Özelleştirilmiş düzenler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Media) veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholdertype/#Diagram) tiplerini ortaya çıkarabilir.

Aspose.Slides, bir boş [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) yer tutucusunu yalnızca [Placeholder.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/placeholder/#getType) değiştirerek bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) haline getirmez; tip API üzerinden değiştirilemez. Boş bir grafik ya da içerik alanını programlı olarak doldurmak için gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenen grafik, sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan devralmaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [grafik yönetimi makalelerini](/slides/tr/python-java/powerpoint-charts/) kullanın.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelleme**

Aşağıdaki uçtan uca örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan ve her yer tutucuyu aynı tipte kabul etmekten kasıtlı olarak kaçınır.

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

## **SSS**

**Temel yer tutucu nedir?**

Temel bir yer tutucu, başka bir yer tutucunun devraldığı düzen veya ana üzerindeki karşılık gelen şekildir. Onu almak için [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığından `None` döndürür.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda saklanır. Sunumdaki gerçek başlık metnini değiştirmek için slaytları döngüye alıp her başlık yer tutucusunu güncelleyin.

**Tarih, slayt numarası, başlık ve altbilgi yer tutucularını nasıl yönetebilirim?**

İlgili slayt, düzen, ana, not veya dağıtım kapsamında başlık ve altbilgi yöneticilerini kullanın. Tam örnekler için [Sunum Başlık ve Altbilgi Yönetimi](/slides/tr/python-java/presentation-header-and-footer/) bölümüne bakın.