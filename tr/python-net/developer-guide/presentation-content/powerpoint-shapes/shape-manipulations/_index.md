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
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil düzen formatları
- Şekli SVG olarak
- Şekli SVG'ye
- şekli hizalama
- şekli döndürme
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum şekillerini tanımlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve döndürmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bir slayttaki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmasının yanı sıra yığın sırasının kaynağıdır: `0` indeksi en arka şekildir, son indeks ise en ön şekildir.

Bu makale o modeli izler. Önce bir şeklin güvenilir bir şekilde nasıl tanımlanacağını açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler düzen seviyesi biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece iş akışınızın gerektirdiği işlemleri yalnızca kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri, bilinen bir dosyayı işlerken kullanışlıdır, ancak kararlı tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve yönetildiğine göre bir tanımlayıcı seçin:

- [Shape.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/name/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde denetlenmesi kolaydır. İsimler düzenlenebilir ve benzersiz olduğu garantilenmez; bu nedenle kod bu isimlere bağımlıysa bir adlandırma kuralı belirleyin.
- [Shape.alternative_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/alternative_text/) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa yararlıdır. Kullanıcılar tarafından görülebilir, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olduğu garantilenmez. Anlamlı erişilebilirlik metnini sessizce veritabanı anahtarı olarak yeniden kullanmayın.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/office_interop_shape_id/) okunabilir yalnızca bir tanımlayıcıdır ve bir slayt içinde benzersizdir, PowerPoint interop'unda kullanılan şekil kimliğine karşılık gelir. PowerPoint ile entegrasyon yaparken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyacınız olduğunda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [Shape.unique_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/unique_id/) özelliği sunum kapsamındadır, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek `name` ile tam karşılaştırma yaparak arama yapar ve slayt kapsamında interop kimliğini raporlar. Şablon beklenen şekli içermediğinde kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem şekil türüne özgü ise, tür‑spesifik üyeleri kullanmadan önce türü kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ise yalnızca metni ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere dayanmayı bırakın.

### **Bir Şekli Kopyalama**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_clone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/insert_clone/) da bir kopya oluşturur ancak belirtilen z‑sırası indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik alan aşırı yüklemeler de yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arkaya ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de içerecek şekilde kopyalar. Bu değerlerin benzersiz olması gerekiyorsa kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekiller tarafından kullanılan kaynaklar sunum tarafından yönetilir, ancak bir kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olarak kalır.

### **Şekilleri Kaldırma**

[ShapeCollection.remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. Birden fazla eşleşmeyi indeksli yineleme sırasında kaldırırken, her kalan indeksin geçerli kalması için sondan itibaren dolaşın.

Bu örnek, belirli bir isimle her şekli kaldırır. Sabit bir koleksiyon öğesi değil, `slide.shapes[index]` okunur ve şekil gereksiz yere dönüştürülmez.

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

Kaldırma sonrasında şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yönelik referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum özelliklerini göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Shape.hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/hidden/) değerini `True` olarak ayarlamak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeks, biçimlendirme ve içerik koda hâlâ erişilebilir, bu yüzden gizleme, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

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

Gizleme bir silme veya güvenlik işlemi değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından yeniden görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre çizilir. [ShapeCollection.reorder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/reorder/) mevcut bir şekli kopyalamadan hedef indekse taşır. `0` indeksi arka; `len(slide.shapes) - 1` indeksi ön demektir.

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

Dikdörtgen ilk oluşturulduğunda elipsin arkasında yer alır. Son indekse taşındığında ön tarafa gelir. Tüm ilgili şekiller eklendikten veya kopyalandıktan sonra z‑sırasını sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, aynı konumda bir normal slaytdaki şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [Shape.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/fill_format/) ve [Shape.line_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/line_format/) özelliklerini okur; tüm şekillerin `AutoShape` olduğu varsayımı yapılmaz.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce normal bir slaytın nesneyi devralıp devralmadığını veya yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Şekli SVG Olarak Dışa Aktarma**

[Shape.write_as_svg](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç şekli içerir, tüm slayt arka planını veya komşu şekilleri içermez.

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

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akışı çağıran taraf sahiplenir ve kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.util/slideutil/align_shapes/) aşırı yüklemeleri, ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `align_to_slide` değerini `True` yaparsanız slayt kenarları kullanılır; `False` yaparsanız seçili şekiller birbirlerine göre hizalanır.

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

Hizalama konumları değiştirir, z‑sırasını değiştirmaz. Göreli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise boşlukları tanımlamak için yeterli şekle ihtiyaç duyar. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve döndürmeyi tutar. `flip_h` ve `flip_v` değerleri [NullableBool](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) kullanır: `TRUE` çevirme etkin, `FALSE` devre dışı, `NOT_DEFINED` belirtilmemiş veya varsayılan durumu korur.

Aşağıdaki sunumda tek bir çevrilmemiş şekil bulunur.

![Şekil döndürülmeden önce](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Shape.frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/frame/) atamak çerçevenin tamamını değiştirir.

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

Kaydedilen şekil, konumunu, boyutunu ve döndürmesini korurken yatay ve dikey olarak yansıtılmıştır.

![Şekil döndürüldükten sonra](flipped_shape.png)

## **FAQ**

**Koleksiyon indeksini şekil tanımlayıcısı olarak kullanmalı mıyım?**

Yalnızca indeksin kullanılmadan önce koleksiyonun değişmeyeceği kısa vadeli işlemler için. Oluşturulmuş şablonlar için doğrulanmış bir `name` veya `alternative_text` konvansiyonu, slayt kapsamında interop çalışması için `office_interop_shape_id` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden kopyalanan bir şekil, başka bir şeklin önünde göründü?**

`add_clone` kopyayı koleksiyonun sonuna ekler; bu, z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için `insert_clone` kullanın veya tüm şekiller eklendikten sonra `reorder` ile konumlandırın.