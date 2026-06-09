---
title: Master Slayt
type: docs
weight: 30
url: /tr/cpp/examples/elements/master-slide/
keywords:
- kod örneği
- master slayt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ master slide örneklerini keşfedin: PPT, PPTX ve ODP'de net C++ kodu ile master'ları, yer tutucuları ve temaları oluşturun, düzenleyin ve stil verin."
---
Master slaytlar, PowerPoint'teki slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. Bir **master slide** ortak tasarım öğeleri olan arka planlar, logolar ve metin biçimlendirmesini tanımlar. **Layout slides** master slaytlardan miras alır ve **normal slides** layout slaytlardan miras alır.

Bu makale, Aspose.Slides for C++ kullanarak master slaytlarını oluşturma, değiştirme ve yönetme yöntemlerini göstermektedir.

## **Master Slayt Ekle**

Bu örnek, varsayılan slaytı klonlayarak yeni bir master slayt oluşturmayı gösterir. Ardından, layout miras yoluyla tüm slaytlara şirket adı bannerı ekler.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Varsayılan master slaytı klonla.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Master slaytın üst kısmına şirket adı içeren bir banner ekle.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Yeni master slaytı bir layout slayta ata.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Layout slaytı sunumdaki ilk slayta ata.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Master slaytlar, tüm slaytlara tutarlı bir marka kimliği veya ortak tasarım öğeleri uygulama imkanı sağlar. Master üzerinde yapılan herhangi bir değişiklik, bağımlı layout ve normal slaytlara otomatik olarak yansır.

> 💡 **Note 2:** Master slayta eklenen şekil veya biçimlendirmeler layout slaytlara, ardından da bu layoutları kullanan tüm normal slaytlara miras alınır.  
> Aşağıdaki resim, bir master slayta eklenen metin kutusunun son slaytta otomatik olarak nasıl render edildiğini gösterir.

![Master Inheritance Example](master-slide-banner.png)

## **Master Slayta Erişim**

Master slaytlara, sunum master koleksiyonunu kullanarak erişebilirsiniz. İşte bunları nasıl alıp çalıştıracağınıza dair bir örnek:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Arka plan tipini değiştir.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Master Slaytı Kaldır**

Master slaytlar, indeks veya referans kullanılarak kaldırılabilir.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // İndeksle bir master slaytı kaldır.
    presentation->get_Masters()->RemoveAt(0);

    // Referansla bir master slaytı kaldır.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Kullanılmayan Master Slaytları Kaldır**

Bazı sunumlarda kullanılmayan master slaytlar bulunabilir. Bu slaytları kaldırmak dosya boyutunun azalmasına yardımcı olur.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Kullanılmayan tüm master slaytları kaldır (Koruma olarak işaretlenenler dahil).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```