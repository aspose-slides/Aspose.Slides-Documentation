---
title: Master Slayt
type: docs
weight: 30
url: /tr/python-java/examples/elements/master-slide/
keywords:
- kod örneği
- master slayt
- master slayt ekle
- master slayta eriş
- master slaytı kaldır
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile master slaytları yönetin: PowerPoint ve OpenDocument sunumlarında masterları oluşturun, erişin, kaldırın ve temizleyin."
---
Ana slaylar, PowerPoint'te slay kalıtım hiyerarşisinin üst seviyesini oluşturur. Bir **master slide** arka planlar, logolar ve metin biçimlendirmesi gibi ortak tasarım öğelerini tanımlar. **Layout slides** master slaytlardan, **normal slides** ise düzen slaytlarından kalıtım alır.

Bu makale, **Aspose.Slides for Python via Java** kullanarak master slaytların nasıl oluşturulacağını, değiştirileceğini ve yönetileceğini gösterir.

Paketi, [Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı şekilde kurun. Her örnek, JVM'i başlatmadan önce `asposeslides` paketini içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır.

## **Add a Master Slide**

Bu örnek, varsayılan master slaytı klonlayarak yeni bir master slayt oluşturmayı gösterir. Ardından, düzen kalıtımı yoluyla tüm slaytlara şirket adı afişi ekler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Varsayılan master slaytı klonlayın.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Master slaydın üst kısmına şirket adını içeren bir afiş ekleyin.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Yeni master slaytı bir düzen slaytına atayın.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Düzen slaytını sunumdaki ilk slayta atayın.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Master slaytlar, tüm slaytlarda tutarlı marka kimliği veya ortak tasarım öğeleri uygulamanın bir yolunu sağlar. Bir master slaytta yapılan değişiklikler, bağımlı düzen ve normal slaytlara otomatik olarak yansır.
{{% /alert %}}

{{% alert color="info" title="Not" %}}
Bir master slayta eklenen şekiller ve biçimlendirmeler, düzen slaytları tarafından ve ardından bu düzenleri kullanan tüm normal slaytlar tarafından kalıtım alınır. Aşağıdaki resim, bir master slayta eklenen metin kutusunun son slaytta otomatik olarak nasıl oluşturulduğunu gösterir.
{{% /alert %}}

![Master Kalıtım Örneği](master-slide-banner.png)

## **Access a Master Slide**

Master slaytlara, sunumun master koleksiyonu üzerinden erişebilirsiniz. Bu örnek, ilk master slaytı alır ve arka plan tipini değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Remove a Master Slide**

Bir master slayt, artık kullanılmadığında indeks veya referans yoluyla kaldırılabilir. Bu örnek, bir klonlanmış master slaytı sunuma atar ve ardından orijinal master slaytı indeksle kaldırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Kullanılmayan orijinal master slaytı indeksle kaldır.
    presentation.getMasters().removeAt(0)

    # Alternatif olarak, kullanılmayan bir master slaytı referansla kaldır:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Remove Unused Master Slides**

Bazı sunumlar kullanılmayan master slaytlar içerir. Bu slaytların kaldırılması dosya boyutunun azaltılmasına yardımcı olabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Tüm kullanılmayan master slaytları, Preserve olarak işaretlenmiş olanlar da dahil, kaldır.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```