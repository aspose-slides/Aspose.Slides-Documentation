---
title: Ana Slayt
type: docs
weight: 30
url: /tr/python-net/examples/elements/master-slide/
keywords:
- ana slayt
- ana slayt ekle
- ana slayta eriş
- ana slaytı kaldır
- kullanılmayan ana slayt
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides ile ana slaytları yönetin: temaları, arka planları, yer tutucuları oluşturun, düzenleyin, kopyalayın ve biçimlendirerek PowerPoint ve OpenDocument'ta slaytları birleştirin."
---
Ana slaytlar, PowerPoint'te slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. **Ana slayt**, arka planlar, logolar ve metin biçimlendirme gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, ana slaytlardan, **normal slaytlar** ise düzen slaytlarından kalıtım alır.

Bu makale, Aspose.Slides for Python via .NET kullanarak ana slaytların nasıl oluşturulacağını, değiştirileceğini ve yönetileceğini gösterir.

## **Ana Slayt Ekle**

Bu örnek, varsayılan ana slaytı kopyalayarak yeni bir ana slayt oluşturmayı gösterir.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Varsayılan ana slaytı kopyala.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **İpucu 1:** Ana slaytlar, tüm slaytlarda tutarlı bir marka kimliği veya paylaşılan tasarım öğeleri uygulamanın bir yolunu sağlar. Ana slaytta yapılan herhangi bir değişiklik, bağlı düzen ve normal slaytlarda otomatik olarak yansır.

> 💡 **İpucu 2:** Ana slayta eklenen herhangi bir şekil veya biçimlendirme, düzen slaytları ve dolayısıyla bu düzenleri kullanan tüm normal slaytlar tarafından miras alınır.  
> Görsel, ana slayta eklenen bir metin kutusunun son slaytta otomatik olarak nasıl görüntülendiğini gösterir.

![Ana Slayt Kalıtım Örneği](master-slide-banner.png)

## **Ana Slayta Erişmek**

Ana slaytlara, `Presentation.masters` koleksiyonunu kullanarak erişebilirsiniz. İşte onları nasıl alıp çalıştırabileceğiniz:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # İlk ana slayta eriş.
        first_master_slide = presentation.masters[0]
```

## **Ana Slaytı Kaldır**

Ana slaytlar, indeks ya da referans yoluyla kaldırılabilir.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # İndeks ile kaldır.
        presentation.masters.remove_at(0)

        # Ya da referans ile kaldır.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kullanılmayan Ana Slaytları Kaldır**

Bazı sunumlar, kullanılmayan ana slaytlar içerir. Bu slaytları kaldırmak dosya boyutunu azaltmaya yardımcı olabilir.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Kullanılmayan tüm ana slaytları kaldır (Koruma olarak işaretlenenler dahil).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **İpucu:** Kullanılmayan ana slaytları temizlemek ve sunum boyutunu küçültmek için `remove_unused(True)` komutunu kullanın.