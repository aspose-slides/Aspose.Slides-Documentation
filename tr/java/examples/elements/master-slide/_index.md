---
title: Master Slayt
type: docs
weight: 30
url: /tr/java/examples/elements/master-slide/
keywords:
- kod örneği
- master slayt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java master slayt örneklerini keşfedin: net Java kodu ile PPT, PPTX ve ODP'de masterları, yer tutucuları ve temaları oluşturun, düzenleyin ve biçimlendirin."
---
Master slaytlar, PowerPoint’te slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. Bir **master slayt**, arka planlar, logolar ve metin biçimlendirmesi gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, master slaytlardan, **normal slaytlar** ise düzen slaytlarından miras alır.

Bu makale, Aspose.Slides for Java kullanarak master slaytları oluşturma, değiştirme ve yönetme yollarını gösterir.

## **Master Slayt Ekle**

Bu örnek, varsayılan master slaytı klonlayarak yeni bir master slayt oluşturmayı gösterir. Ardından, düzen kalıtımı yoluyla şirket adı afişini tüm slaytlara ekler.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Varsayılan master slaytı klonlayın.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Şirket adı afişini master slaytın üstüne ekleyin.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Yeni master slaytı bir düzen slaytına atayın.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Düzen slaytı sunumdaki ilk slayta atayın.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not 1:** Master slaytlar, tüm slaytlarda tutarlı marka kimliği veya ortak tasarım öğeleri uygulamanın bir yolunu sağlar. Master’da yapılan herhangi bir değişiklik, bağımlı düzen ve normal slaytlara otomatik olarak yansır.

> 💡 **Not 2:** Master slayta eklenen tüm şekil ve biçimlendirmeler, düzen slaytları tarafından ve dolayısıyla bu düzenleri kullanan tüm normal slaytlara miras alınır.
> Aşağıdaki görsel, master slayta eklenen bir metin kutusunun nihai slaytta otomatik olarak nasıl görüntülendiğini gösterir.

![Master Kalıtım Örneği](master-slide-banner.png)

## **Master Slayta Erişim**

Sunum master koleksiyonunu kullanarak master slaytlara erişebilirsiniz. İşte bunları alıp çalışmanın yolu:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Arka plan tipini değiştirin.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Master Slaytı Kaldır**

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // İndeks ile bir master slaytı kaldırın.
        presentation.getMasters().removeAt(0);

        // Referans ile bir master slaytı kaldırın.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Master Slaytları Kaldır**

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Kullanılmayan tüm master slaytları kaldırın (Preserve olarak işaretlenmiş olanları dahil).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```