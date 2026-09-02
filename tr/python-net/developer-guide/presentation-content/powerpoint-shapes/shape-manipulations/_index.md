---
title: Python'da Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/python-net/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil klonlama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliği alma
- şekil alternatif metni
- şekil ayar noktası
- önceden tanımlı şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye
- şekli hizala
- şekli çevir
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum şekillerini tanımlamayı, ayarlamayı, klonlamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bir slayd üzerindeki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmanın yanı sıra yığılma sırasının kaynağıdır: `0` dizini en arkadaki şekli, son dizin ise en öndeki şekli temsil eder.

Bu makale bu modeli takip eder. Önce bir şekli güvenilir bir şekilde tanımlamayı ve önceden tanımlı şekil ayar noktalarını değiştirmeyi açıklar, ardından şekilleri klonlama, kaldırma, gizleme ve yeniden sıralamayı gösterir. Son bölümler, düzen‑seviyesi biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indisleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğu ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Shape.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/name/) geliştirici‑kontrolündeki şablonlar için yararlıdır ve PowerPoint’in Seçim Bölmesi’nde kolayca incelenebilir. İsimler düzenlenebilir ve benzersiz oldukları garanti edilmez; kod bu isimlere dayanıyorsa bir adlandırma kuralları oluşturun.
- [Shape.alternative_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/alternative_text/) bir erişilebilirlik açıklaması veya yazar‑tarafından sağlanan etiket zaten şekli tanımlıyorsa uygundur. Kullanıcılara görünür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce veritabanı anahtarı olarak yeniden kullanmayın.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/office_interop_shape_id/) sadece okuma izni olan bir tanımlayıcıdır, slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile entegrasyon yaparken veya bir şeklin ömrü boyunca belirsiz olmayan bir referansa ihtiyaç duyduğunuzda bunu kullanın. Klonlanmış veya yeniden yaratılmış bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [Shape.unique_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/unique_id/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmış olup yeniden atanabilir. Kalıcı dış anahtar olarak görülmemelidir. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, `name` ile tam karşılaştırma yaparak arama yapar ve slayt‑kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu raporlar.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyeleri kullanmadan önce türü kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ise metni ve alternatif metni günceller.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Önceden Tanımlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden tanımlı geometrik şekiller, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktalarına sahip olabilir. Bu noktalara yalnızca okuma izni olan [GeometryShape.adjustments](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometryshape/adjustments/) koleksiyonu üzerinden erişilir. Koleksiyon şekil tarafından sağlanır, ancak her [AdjustValue](https://reference.aspose.com/slides/tr/python-net/aspose.slides/adjustvalue/) değiştirilebilir bir değer içerir.

Sabit bir koleksiyon indeksiyle sınırlı kalmayın. Ayarları yineleyin ve yalnızca okuma izni olan [AdjustValue.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/adjustvalue/type/) özelliğine bakın; bu özelliğin [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini açıklar. Okuma izni olan [AdjustValue.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/adjustvalue/name/) özelliği ek kimlik bilgisi sağlar ve aynı anlamsal tipe sahip birden fazla ayar bulunduğunda özellikle yararlıdır.

Ayara karşılık gelen anlamı taşıyan değer özelliğini kullanın:

| Ayarlama tipi | Amaç | Değiştirilecek değer |
|---|---|---|
| `CORNER_SIZE` | Yuvarlak köşelerin boyutu | [raw_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Ok kuyruğunun kalınlığı | `raw_value` |
| `ARROWHEAD_LENGTH` | Ok başının uzunluğu | `raw_value` |
| `ARROWHEAD_WIDTH` | Ok başının genişliği | `raw_value` |
| `START_ANGLE` | Daire dilimi veya yay için başlangıç açısı | [angle_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Daire dilimi veya yay için bitiş açısı | `angle_value` |

`type` ve `name` atanamaz. `raw_value`, önceden tanımlı şeklin özgün geometri birimlerinde okuma‑yazma tam sayı iken, `angle_value` derece cinsinden okuma‑yazma açı değeridir. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden tanımlı [GeometryShape.shape_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/geometryshape/shape_type/) değerine bağlıdır. Bir önceden tanımlı için geçerli bir değer, başka bir önceden tanımlı için geçersiz olabilir ya da farklı bir etki yaratabilir.

`type` değeri `ShapeAdjustmentType.CUSTOM` olduğunda API standart bir anlamsal anlam tanımaz. `name`, önceden tanımlı tipi ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanımlı tipler için bile aynı tip birden fazla kez ortaya çıkıyorsa, bir değer seçmeden önce bunu kontrol edin. [Connector](/slides/tr/python-net/connector/) makalesi, bağlayıcı bükülme ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden tanımlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı iterasyonla dolaşır, `name` ve `type` bilgilerini raporlar, boyutla ilgili değerleri `raw_value` ile, açıları `angle_value` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlak dikdörtgen, dört yönlü ok ve dilimi gösterir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan ve ayarlanmış şekil sütunları için başlık ekleyin.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Değiştirilecek değerden önce anlamsal tipi kontrol etmek, kodun amacını açıkça belirtir ve farklı önceden tanımlı şekillerde aynı koleksiyon indeksinin aynı anlama gelmediği varsayımını önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, klonla, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştirirse, o işlemden önce yakalanan indisleri kullanmaya devam etmeyin.

### **Bir Şekli Kopyala**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_clone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/insert_clone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinat kabul eden aşırı yüklemeler klonu yeniden boyutlandırmadan taşırken, genişlik ve yükseklik kabul eden aşırı yüklemeler de yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne klonlar ve ikinci bir klonu arka tarafa ekler. Her iki klon üzerindeki değişiklikler kaynak şekli etkilemez.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Klonlama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa, klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi olarak yeni bir şekil kimliğine sahiptir.

### **Şekilleri Kaldır**

[ShapeCollection.remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden çok eşleşme kaldırılırken, her kalan indeksin geçerli kalması için sondan başlanarak geçiş yapın.

Bu örnek, belirlenmiş bir isimle eşleşen tüm şekilleri kaldırır. Sabit bir koleksiyon öğesi değil, `slide.shapes[index]` okunur ve şekil gereksiz olarak tip dönüşümü yapılmaz.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar, kaydedilmiş indislerden daha güvenilirdir. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizle**

[Shape.hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/hidden/) özelliğini `True` olarak ayarlamak, şekli koleksiyonda tutar ancak normal sunumda görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği kod tarafından erişilebilir kalır; bu nedenle daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Gizleme, silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından yeniden görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olmaya devam eder.

### **Z‑Sırasını Değiştir**

Üst üste binen şekiller koleksiyon sırasına göre çizilir. [ShapeCollection.reorder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/reorder/) mevcut bir şekli yeni bir indeksle klonlamadan taşır. `0` indeksi arka, `len(slide.shapes) - 1` indeksi öndedir.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında öne gelir. Tüm ilgili şekiller eklendikten ya da klonlandıktan sonra z‑sırasını sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve amaçlanan yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İncele**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slayttaki aynı konumdaki şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [Shape.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/fill_format/) ve [Shape.line_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/line_format/) değerlerini okur; her şeklin bir `AutoShape` olup olmadığını varsaymaz.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma mı içerdiğini belirleyin ve bu düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktar**

[Shape.write_as_svg](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, tüm slayt arka planını veya komşu şekilleri değil, yalnızca şekli içerir.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ile görseller gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaydı dışa aktarın. Çağıran akımı sahiplenir ve kapatması gerekir.

## **Şekilleri Hizala**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/align_shapes/) aşırı yüklemeleri, tüm şekilleri veya seçili koleksiyon indislerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `align_to_slide` değerini `True` yaparsanız slayt kenarları kullanılır; `False` yaparsanız seçili şekiller birbirlerine göre hizalanır.

Bu örnek üç şekli slaydın üst kenarına hizalar. Mevcut indeksleri hizalamadan hemen önce çözülür.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Hizalama konumları değiştirir, z‑sırasını değil. Göreli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise aralığı tanımlamak için yeterli sayıda şekil ister. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevir**

[ShapeFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile döndürmeyi depolar. `flip_h` ve `flip_v` değerleri [NullableBool](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) kullanır: `TRUE` çevirme etkin, `FALSE` devre dışı, `NOT_DEFINED` belirtilmemiş ya da varsayılan durumu korur.

Aşağıdaki sunum, çevirilmemiş bir şekil içerir.

![Döndürülmeden önceki şekil](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir; yeni bir [Shape.frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/frame/) atamak çerçevenin tamamını değiştirir.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen şekil, konum, boyut ve döndürmeyi korurken yatay ve dikey olarak yansıtılmıştır.

![Döndürülmüş şekil](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksini kullanmalı mıyım?**

Sadece koleksiyon işlem sırasında değişmeyecek ve indeksin kullanılacağı süre kısa olduğunda. Yazar‑tarafından hazırlanmış şablonlar için doğrulanmış bir `name` veya `alternative_text` konvansiyonu tercih edin; slayt‑kapsamlı interop çalışmaları için `office_interop_shape_id` kullanın.

**Bir şekli gizlemek, onu z‑sırasından çıkarır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Klonlanan bir şekil neden başka bir şeklin önünde göründü?**

`add_clone` klonu koleksiyonun sonuna ekler; koleksiyonun sonu z‑sırasının önüdür. Başlangıç indeksini seçmek için `insert_clone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden tanımlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece kesin önceden tanımlı ve koleksiyon düzeni doğrulandıysa. `GeometryShape.adjustments` içinde yineleyin ve `AdjustValue.type` kontrol edin; aynı anlamsal tip birden çok kez göründüğünde ek bilgi için `AdjustValue.name` kullanın.