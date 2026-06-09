---
title: Python Kullanarak Sunumlarda Şekilleri Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/python-net/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen biçimleri
- şekil SVG olarak
- şekli SVG'ye
- şekli hizala
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak şekilleri oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint ve OpenDocument sunumları sunun."
---
## **Genel Bakış**

Bu kılavuz, .NET üzerinden Python için Aspose.Slides'de şekil manipülasyonunu tanıtır. Alternatif Metin ile birlikte şekilleri bulma, çoğaltma, silme veya gizleme, yeniden sıralama, hizalama ve çevirme, kimlikleri okuma ve düzen odaklı biçimlendirme, ayrıca bireysel şekilleri SVG olarak dışa aktarma gibi pratik desenleri [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) ve [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) API'lerini kullanarak öğrenin.

## **Slaytlarda Şekilleri Bulma**

PowerPoint, şekilleri yalnızca dahili kimlikleriyle tanır. Hedef şekle PowerPoint'te benzersiz bir Alt Text (Alternatif Metin) atayın, ardından Aspose.Slides for Python ile sunumu açın, slayt şekilleri üzerinde yineleme yapın ve Alt Text'i eşleşen şekli seçin. `find_shape` yöntemi bu yaklaşımı uygular ve eşleşen şekli döndürür.

```py
import aspose.slides as slides

# Bir slaytta alternatif metnine göre şekil bulur.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Bir sunum dosyasını temsil eden Presentation sınıfını örnekler.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Metin "Shape1" olan şekli bul.
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Şekilleri Kopyalama**

Bir kaynak slayttan yeni bir slayta şekilleri kopyalamak için Aspose.Slides'de şu adımları izleyin:

1. Kaynak dosyadan bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun.
1. İndeks ile kaynak slaytı ve onun şekil koleksiyonunu alın.
1. Ana slayttan boş bir düzen (layout) alın.
1. Bu düzeni kullanarak boş bir slayt ekleyin ve şekillerini alın.
1. Şekilleri hedef slayta kopyalayın.
1. Sunumu PPTX olarak kaydedin.

Aşağıdaki kod örneği bir slayttan diğerine şekilleri kopyalar.

```py
import aspose.slides as slides

# Presentation sınıfını örnekle.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekilleri Kaldırma**

Aspose.Slides, bir slayttan herhangi bir şekli kaldırmanıza izin verir. Örneğin, birincil slaydın bir şeklini Alternatif Metni ile silmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun ve dosyayı yükleyin.
1. Slayt koleksiyonundan ilk slayta erişin.
1. Alternatif Metin değeriyle şekli bulun.
1. Şekli slaydın şekil koleksiyonundan kaldırın.
1. Sunumu PPTX formatında diske kaydedin.

```py
import aspose.slides as slides

# Alternatif metnine göre bir slaytta şekil bulur.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Bir sunum dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Metin "User Defined" olan şekli bul.
    shape = find_shape(slide, "User Defined")
    # Şekli kaldır.
    slide.shapes.remove(shape)
    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekilleri Gizleme**

Aspose.Slides, bir slayttaki herhangi bir şekli gizlemenizi sağlar. Örneğin, birincil slayttaki bir şekli Alternatif Metni ile gizlemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun ve dosyayı yükleyin.
1. Slayt koleksiyonundan ilk slayta erişin.
1. Alternatif Metin değeriyle şekli bulun.
1. Şekli gizleyin.
1. Sunumu PPTX formatında diske kaydedin.

```py
# Alternatif metnine göre bir slaytta şekil bulur.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Bir sunum dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Metin "User Defined" olan şekli bul.
    shape = find_shape(slide, "User Defined")
    # Şekli gizle.
    shape.hidden = True
    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekillerin Sırasını Değiştirme**

Aspose.Slides, geliştiricilerin şekilleri yeniden sıralamasına (z-sırasını değiştirmesine) olanak tanır. Yeniden sıralama, hangi şeklin önde ya da arkada görüneceğini belirler. Örneğin, birinci slayttaki iki şekli yeniden sıralamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İlk slayta erişin.
1. İlk şekli ekleyin (örneğin bir dikdörtgen).
1. İkinci şekli ekleyin (örneğin bir üçgen).
1. Şekilleri, ikinci şekli koleksiyondaki ilk konuma taşıyarak yeniden sıralayın.
1. Sunumu diske kaydedin.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Slayta iki şekil ekle.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # İkinci şekli birinci konuma taşı.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Interop Şekil Kimliğini Al**

Aspose.Slides, bir şeklin benzersiz kimliğini slayt kapsamı içinde edinmenizi sağlar; bu, tüm sunumda benzersiz olan `unique_id` özelliğinden farklıdır. `office_interop_shape_id` özelliği [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfında bulunur. Bu değerin karşılığı, `Microsoft.Office.Interop.PowerPoint.Shape` nesnesinin `Id` değeridir. Aşağıda bir örnek kod parçacığı gösterilmiştir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Şeklin slayt içindeki benzersiz tanımlayıcısını al.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Şekiller için Alternatif Metin Ayarlama**

Aspose.Slides, geliştiricilerin herhangi bir şekil için alternatif metin ayarlamasına izin verir. Alternatif metni, bir sunumda şekilleri tanımlamak ve bulmak için kullanabilirsiniz. Alternatif metin özelliği, hem Aspose.Slides hem de Microsoft PowerPoint aracılığıyla okunup yazılabilir. Şekillere bu özellik etiketlendiğinde, daha sonra onları bir slaytta kaldırabilir, gizleyebilir veya yeniden sıralayabilirsiniz.

Bir şeklin alternatif metnini ayarlamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İlk slayta erişin.
1. Slayta bir şekil ekleyin.
1. Alternatif metni ayarlayın.
1. Sunumu diske kaydedin.

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekle.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Bir şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Şekil için alternatif metni ayarla.
    shape.alternative_text = "User Defined"
    # Sunumu diske kaydet.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekiller İçin Düzen Biçimlerine Erişim**

Aspose.Slides, şekiller için düzen biçimlerine erişim sağlayan basit bir API sunar. Bu bölüm, düzen biçimlerine nasıl erişileceğini gösterir.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Şekilleri SVG Olarak Oluşturma**

Aspose.Slides, şekilleri SVG olarak oluşturmayı destekler. [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfındaki `write_as_svg` metodu (ve aşırı yüklemeleri) bir şeklin içeriğini SVG görüntüsü olarak kaydetmenizi sağlar. Aşağıdaki kod parçacığı, bir şekli SVG dosyasına nasıl dışa aktarılacağını gösterir.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # İlk slaydın ilk şeklini al.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Şekli Hizalama**

[SlidesUtil](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/) sınıfındaki `align_shape` metodunu kullanarak şunları yapabilirsiniz:

* Şekilleri bir slaydın kenar boşluklarına göre hizalayabilirsiniz (Örnek 1'e bakın).
* Şekilleri birbirlerine göre hizalayabilirsiniz (Örnek 2'ye bakın).

[ShapesAlignmentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapesalignmenttype/) sayımı, kullanılabilir hizalama seçeneklerini tanımlar.

**Example 1**

Bu Python kodu, 1, 2 ve 4 indisindeki şekilleri slaydın üst kenarına nasıl hizalayacağınızı gösterir:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Example 2**

Bu Python örneği, bir koleksiyondaki tüm şekilleri o koleksiyondaki en alttaki şekle göre nasıl hizalayacağınızı gösterir:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Çevirme Özellikleri**

Aspose.Slides'te, [ShapeFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeframe/) sınıfı, şekillerin yatay ve dikey yansıtılmasını `flip_h` ve `flip_v` özellikleriyle kontrol etmenizi sağlar. Her iki özellik de [NullableBool](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) tipindedir; `TRUE` bir çevirme, `FALSE` çevirme yok ve `NOT_DEFINED` varsayılan davranışı kullanmak anlamına gelir. Bu değerler bir şeklin [Frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/frame/) üzerinden erişilebilir.

Çevirme ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `flip_h` ve `flip_v` değerleri ve dönüş açısı ile yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/frame/)’ine atanıp sunum kaydedildiğinde, yansıma dönüşümleri uygulanır ve çıkış dosyasına yazılır.

Örneğin, sample.pptx dosyamızın ilk slaydında varsayılan çevirme ayarlarına sahip tek bir şekil olduğunu varsayalım; aşağıda gösterildiği gibi.

![Çevrilecek şekil](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut çevirme özelliklerini alır ve hem yatay hem de dikey olarak çevirir.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Şeklin yatay çevirme özelliğini al.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Şeklin dikey çevirme özelliğini al.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Yatay ve dikey olarak çevir.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Çevrilmiş şekil](flipped_shape.png)

## **FAQ**

**Bir slaytta şekilleri (birleştirme/kesişim/çıkartma) masaüstü editöründe olduğu gibi birleştirebilir miyim?**

Yerleşik bir Boolean işlem API'si yoktur. İstenen konturu kendiniz oluşturarak yaklaşık bir çözüm elde edebilirsiniz; örneğin, sonucu geometriyi ([GeometryPath](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometrypath/)) kullanarak hesaplayıp bu kontura sahip yeni bir şekil oluşturabilir, isteğe bağlı olarak orijinal şekilleri kaldırabilirsiniz.

**Bir şeklin her zaman “üstte” kalması için yığın sırasını (z-sırası) nasıl kontrol edebilirim?**

Slaydın [shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/shapes/) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için, diğer tüm slayt değişikliklerinden sonra z-sırasını sonlandırın.

**PowerPoint'te kullanıcıların bir şekli düzenlemesini önlemek için şekli “kilitleyebilir” miyim?**

Evet. [shape-level protection flags](/slides/tr/python-net/applying-protection-to-presentation/) ayarlayın (örneğin seçim, hareket, yeniden boyutlandırma, metin düzenlemeleri kilitleme). Gerekirse, bu kısıtlamaları ana slaytta veya düzende yansıtabilirsiniz. Bunun bir UI düzeyi koruma olduğunu ve güvenlik özelliği olmadığını unutmayın; daha güçlü koruma için dosya düzeyi kısıtlamalarla (örneğin [salt okunur önerileri veya şifreler](/slides/tr/python-net/password-protected-presentation/)) birleştirin.