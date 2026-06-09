---
title: Master Slayt
type: docs
weight: 30
url: /tr/nodejs-java/examples/elements/master-slide/
keywords:
- kod örneği
- master slayt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js master slayt örneklerini keşfedin: PPT, PPTX ve ODP'de master slaytları, yer tutucuları ve temaları net kodla oluşturun, düzenleyin ve biçimlendirin."
---
Master slaytlar, PowerPoint'te slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. Bir **master slayt**, arka planlar, logolar ve metin biçimlendirmesi gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, master slaytlardan kalıtım alır ve **normal slaytlar** düzen slaytlarından kalıtım alır.

Bu makale, Aspose.Slides for Node.js via Java kullanarak master slaytların nasıl oluşturulacağını, değiştirileceğini ve yönetileceğini gösterir.

## **Master Slayt Ekle**

Bu örnek, varsayılan master slaytı klonlayarak yeni bir master slayt oluşturmanın nasıl yapılacağını gösterir. Ardından, düzen kalıtımı yoluyla tüm slaytlara şirket adı afişi ekler.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Varsayılan master slaytı kopyala.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Master slaytın üst kısmına şirket adı içeren bir afiş ekle.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Yeni master slaytı bir düzen slaytına ata.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Düzen slaytı sunumdaki ilk slayta ata.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not 1:** Master slaytlar, tüm slaytlara tutarlı marka veya paylaşılan tasarım öğeleri uygulamanın bir yolunu sağlar. Master üzerinde yapılan herhangi bir değişiklik, bağımlı düzen ve normal slaytlara otomatik olarak yansır.

> 💡 **Not 2:** Bir master slayta eklenen herhangi bir şekil veya biçimlendirme, düzen slaytları tarafından ve ardından bu düzenleri kullanan tüm normal slaytlar tarafından kalıtılır.  
> Aşağıdaki resim, master slayta eklenen bir metin kutusunun son slaytta otomatik olarak nasıl görüntülendiğini gösterir.

![Ana Şablon Kalıtım Örneği](master-slide-banner.png)

## **Master Slayta Erişim**

Sunum master koleksiyonunu kullanarak master slaytlara erişebilirsiniz. İşte bunları nasıl alıp çalışabileceğiniz:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Arka plan türünü değiştir.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Master Slaytı Kaldır**

Master slaytlar, indeks ya da referans kullanılarak kaldırılabilir.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Bir master slaytı indeksle kaldır.
        presentation.getMasters().removeAt(0);

        // Bir master slaytı referansla kaldır.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kullanılmayan Master Slaytları Kaldır**

Bazı sunumlar, kullanılmayan master slaytlar içerir. Bu slaytları kaldırmak dosya boyutunu azaltmaya yardımcı olabilir.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Kullanılmayan tüm master slaytları kaldır (Koruma olarak işaretlenmiş olanlar dahil).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```