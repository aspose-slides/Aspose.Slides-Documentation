---
title: Ana Slayt
type: docs
weight: 30
url: /tr/androidjava/examples/elements/master-slide/
keywords:
- kod örneği
- ana slayt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ana slayt örneklerini keşfedin: PPT, PPTX ve ODP formatlarında net Java kodu ile ana slaytları, yer tutucuları ve temaları oluşturun, düzenleyin ve biçimlendirin."
---
Ana slaytlar, PowerPoint'te slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. Bir **ana slayt**, arka planlar, logolar ve metin biçimlendirme gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, ana slaytlardan kalıtım alır ve **normal slaytlar**, düzen slaytlarından kalıtım alır.

Bu makale, Aspose.Slides for Android via Java kullanarak ana slaytların nasıl oluşturulacağını, değiştirileceğini ve yönetileceğini gösterir.

## **Ana Slayt Ekle**

Bu örnek, varsayılan ana slaytı klonlayarak yeni bir ana slayt nasıl oluşturulacağını gösterir. Daha sonra, düzen kalıtımı yoluyla tüm slaytlara şirket adı bannerı ekler.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Varsayılan ana slaytı klonlayın.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Ana slaydın üst kısmına şirket adı içeren bir banner ekleyin.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Yeni ana slaytı bir düzen slaytına atayın.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Düzen slaytını sunumdaki ilk slayta atayın.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not 1:** Ana slaytlar, tüm slaytlarda tutarlı marka kimliği veya ortak tasarım öğeleri uygulamanın bir yolunu sağlar. Ana slaytta yapılan herhangi bir değişiklik, bağımlı düzen ve normal slaytlara otomatik olarak yansır.

> 💡 **Not 2:** Ana slayta eklenen herhangi bir şekil veya biçimlendirme, düzen slaytları tarafından ve ardından bu düzenleri kullanan tüm normal slaytlara kalıtım alır.  
> Aşağıdaki görüntü, ana slayta eklenen bir metin kutusunun son slaytta otomatik olarak nasıl render edildiğini gösterir.

![Ana Kalıtım Örneği](master-slide-banner.png)

## **Ana Slayta Erişim**

Sunum ana slayt koleksiyonunu kullanarak ana slaytlara erişebilirsiniz. İşte onları nasıl alıp çalışabileceğiniz:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Arka plan tipini değiştir.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Ana Slaytı Kaldır**

Ana slaytlar, indeks ya da referans yoluyla kaldırılabilir.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Bir ana slaytı indeks ile kaldır.
        presentation.getMasters().removeAt(0);

        // Bir ana slaytı referans ile kaldır.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Ana Slaytları Kaldır**

Bazı sunumlar kullanılmayan ana slaytlar içerir. Bu slaytları kaldırmak dosya boyutunu azaltmaya yardımcı olabilir.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Tüm kullanılmayan ana slaytları kaldır (Koruma olarak işaretlenmiş olanlar dahil).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```