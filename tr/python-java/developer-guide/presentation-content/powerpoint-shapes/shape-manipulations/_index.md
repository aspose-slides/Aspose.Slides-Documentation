---
title: Python üzerinden Java ile Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/python-java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil klonlama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil ayar noktası
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil yerleşim formatları
- şekil SVG olarak
- şekil SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunum şekillerini tanımlama, ayarlama, klonlama, kaldırma, gizleme, yeniden sıralama, dışa aktarma, hizalama ve çevirme konusunda bilgi edinin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, bir slayd üzerindeki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirildiğiniz yer olduğu gibi yığılma sırasının da kaynağıdır: indeks `0` en arkadaki şekli, son indeks ise en öndeki şekli temsil eder.

Bu makale bu modele dayanır. Öncelikle bir şekli güvenilir şekilde nasıl tanımlayacağınızı ve önceden ayarlanmış şekil ayar noktalarını nasıl değiştireceğinizi açıklar, ardından şekilleri nasıl klonlayacağınızı, kaldıracağınızı, gizleyeceğinizi ve yeniden sıralayacağınızı gösterir. Son bölümler, slayt düzeyi biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınız için gereken işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak istikrarlı tanımlayıcılar değildir. Bir şeklin eklenmesi, kaldırılması veya yeniden sıralanması indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name] geliştirici‑kontrolünde şablonlar için kullanışlıdır ve PowerPoint'in Seçim Bölmesi'nde incelenmesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garanti edilmez, bu yüzden koda bağımlıysanız bir adlandırma konvansiyonu oluşturun.
- [AlternativeText] erişilebilirlik açıklaması veya yazar‑tarafından eklenmiş bir etiket zaten şekli tanımlıyorsa faydalıdır. Kullanıcılar tarafından görülebilir, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini gizli bir veri tabanı anahtarı olarak sessizce yeniden kullanmayın.
- [OfficeInteropShapeId] yalnızca okunabilen bir tanımlayıcıdır, slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin yaşam süresi boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Klonlanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [getUniqueId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getUniqueId) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak kullanılmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, isme tam eşleşme ile arama yapar ve slayt kapsamlı interop kimliğini rapor eder. Şablon beklenen şekli içermediğinde kod, yanlış nesne ile devam etmek yerine bu sonucu raporlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Bir işlem belirli bir şekil türüne özgüyse, tür‑özel üyelere erişmeden önce türü kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) ise yalnızca metni ve alternatif metni günceller.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Önceden Ayarlanmış Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden ayarlanmış geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktalarına sahip olabilir. Bu noktalara, yalnızca okunabilen [GeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#getAdjustments) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her bir [AdjustValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/) değiştirilebilen bir değer içerir.

Sabit bir koleksiyon indeksine güvenmeyin. Ayarları dolaşın ve yalnızca okunabilen [getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getType) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/) değeri ayarın neyi kontrol ettiğini tanımlar. Ayrıca yalnızca okunabilen [getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getName) yöntemi ek tanımlama bilgisi sağlar ve aynı anlamsal tipe sahip birden fazla ayar bulunduğunda özellikle yararlıdır.

Ayarlamanın anlamına uyan değer yöntemini kullanın:

| Ayarlama türü | Amaç | Değiştirilecek değer |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Ok kuyruğunun kalınlığı | [setRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Ok başının uzunluğu | [setRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Ok başının genişliği | [setRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Pasta ya da yay başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Pasta ya da yay bitiş açısı | [setAngleValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getType) ve [getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getName) yalnızca okunabilen bilgi döndürür. [getRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getRawValue) ve [setRawValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setRawValue), önceden ayarlanmışın yerel geometri biriminde bir tamsayı ile çalışır; [getAngleValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getAngleValue) ve [setAngleValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#setAngleValue) ise derece cinsinden bir açı ile çalışır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#getShapeType) değerine bağlıdır. Bir önceden ayarlanmış için geçerli olan bir değer, başka bir önceden ayarlanmışta geçersiz olabilir veya farklı bir etki yaratabilir.

[getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getType) [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeadjustmenttype/#Custom) döndürdüğünde API standart bir anlamsal anlam tanımaz. [getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getName), önceden ayarlanmış türü ve mevcut değeri inceleyin ve beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tipler için bile aynı tip birden fazla kez göründüğünde bir değer seçmeden önce kontrol edin. Bağlayıcı bükülme ayarlarıyla ilgili örnek için [Connector](/slides/tr/python-java/connector/) makalesine bakın.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı dolaşır, adını ve tipini raporlar, boyutla ilgili değerleri [setRawValue] ile, açıları ise [setAngleValue] ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlak dikdörtgen, dört yönlü ok ve pasta gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan ve ayarlanmış şekil sütunları için başlıklar ekler.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Değiştirmeden önce anlamsal tipi kontrol etmek, kodun amacını açıkça belirtir ve farklı önceden ayarlanmış şekillerde aynı koleksiyon indeksinin aynı anlama gelmesini varsaymayı önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, klonla, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanmış indekslere dayanmayın.

### **Bir Şekli Klonlama**

[addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addClone) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [insertClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#insertClone) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler klonu boyutunu değiştirmeden taşırken, genişlik ve yükseklik kabul edenler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli dikdörtgeni öne klonlar ve ikinci bir klonu arkaya ekler. Her iki klon üzerindeki değişiklikler kaynak şekli etkilemez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klonlama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de içerir. Bu değerlerin benzersiz olması gerektiğinde klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak klon yeni bir koleksiyon öğesi olarak yeni bir şekil kimliğine sahiptir.

### **Şekilleri Kaldırma**

[remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#remove) belirli bir şekil nesnesini koleksiyonundan siler. Birden fazla eşleşmeyi indeksli döngüde kaldırırken, kalan indekslerin geçerli kalması için sondan başlayarak gezin.

Bu örnek, belirli bir isimle işaretlenmiş tüm şekilleri kaldırır. Şekli sabit bir koleksiyon öğesi olarak değil, geçerli indeksteki şekli okur ve gereksiz dönüşüm yapmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca bağlayıcılar, animasyonlar ve kaldırılan nesneye referans veren diğer özellikleri de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını etkileyebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setHidden) özelliğini `True` yapmak, şekli koleksiyonda tutar ancak normal gösterimde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ ulaşılabilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gizleme silme veya güvenlik değildir. Nesne hâlâ keşfedilebilir ve kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; aynı zamanda sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste binen şekiller, koleksiyon sırasına göre çizilir. [reorder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#reorder) mevcut bir şekli klonlamadan hedef indekse taşır. İndeks `0` en arkadadır; koleksiyon [size](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#size) eksi bir ise ön taraftadır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dikdörtgen ilk oluşturulduğunda elipsin arkasında durur. Son indekse taşındığında öne gelir. Tüm ilişkili şekiller eklendikten ya da klonlandıktan sonra z‑sırasını sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığılımı değiştirebilir.

## **Düzen (Layout) Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, aynı konumdaki normal bir slayt üzerindeki şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getFillFormat) ve [LineFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getLineFormat) öğesini okur; her şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) olduğunu varsaymaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkiler. Bir düzen şekli değiştirmeden önce, normal bir slaydın nesneyi devralıp devralmadığını ya da yerel bir geçersiz kılma içerip içermediğini belirleyin ve bu düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfının `writeAsSvg` yöntemi, tek bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını ya da komşu şekilleri içermez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyonu istiyorsanız, tek bir şekil yerine slaydı dışa aktarın. Çağıran, akımı sahiplenir ve kapatmalıdır.

## **Şekilleri Hizalama**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slideutil/#alignShapes) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `align_to_slide` değerini `True` yaparak slayt kenarlarını, `False` yaparak seçili şekilleri birbirlerine göre hizalayabilirsiniz.

Bu örnek, üç şekli slaydın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce geçerli indekslerine dönüştürülür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hizalama, konumları değiştirir; z‑sırasını etkilemez. Göreli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise aralığı tanımlamak için yeterli sayıda şekil gerektirir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile dönüşümleri depolar. [getFlipH](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeframe/#getFlipH) ve [getFlipV](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapeframe/#getFlipV) değerleri [NullableBool](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` ise belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevirilmemiş tek bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setFrame) atanması, çerçevenin tamamını değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydedilen şekil, konumunu, boyutunu ve dönüşünü korurken yatay ve dikey olarak yansıtılmış olur.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksini şekil tanımlayıcısı olarak kullanmalı mıyım?**

Sadece koleksiyonun değişmeyeceği ve indeksin kullanılmadan önce değişmeyeceği kısa ömürlü işlemler için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir [Name] veya [AlternativeText] konvansiyonu, slayt‑kapsamlı işler için ise [OfficeInteropShapeId] tercih edilmelidir.

**Bir şekli gizlemek, onu z‑sıradan kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden klonlanan bir şekil başka bir şeklin önünde göründü?**

[addClone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addClone) klonu koleksiyonun sonuna ekler; bu, z‑sırasının ön kısmıdır. Başlangıç indeksini seçmek için [insertClone] kullanın veya tüm şekiller eklendikten sonra [reorder] ile konumlandırın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece belirli bir önceden ayarlanmış ve koleksiyon düzeni doğrulandıktan sonra kullanılabilir. [GeometryShape.getAdjustments](https://reference.aspose.com/slides/tr/python-java/aspose.slides/geometryshape/#getAdjustments) üzerinden döngü yapmayı ve [AdjustValue.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getType) kontrol etmeyi tercih edin; aynı anlamsal tip birden çok kez ortaya çıktığında ek bilgi olarak [AdjustValue.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/adjustvalue/#getName) kullanın.