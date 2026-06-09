---
title: Köprü
type: docs
weight: 130
url: /tr/java/examples/elements/hyperlink/
keywords:
- kod örneği
- köprü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da hiperlinkleri ekleyin ve yönetin: metin, şekil ve görselleri bağlayın, PPT, PPTX ve ODP için hedefleri ve eylemleri, Java örnekleriyle ayarlayın."
---
Bu makale, **Aspose.Slides for Java** kullanarak şekillerdeki hiperlinkleri ekleme, erişme, kaldırma ve güncelleme işlemlerini göstermektedir.

## **Hiperlink Ekle**

Harici bir web sitesine yönlendiren bir hiperlink içeren dikdörtgen şekil oluşturun.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperlinke Eriş**

Bir şeklin metin bölümünden hiperlink bilgilerini okuyun.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperlinki Kaldır**

Bir şeklin metninden hiperlinki temizleyin.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Hiperlinki Güncelle**

Mevcut bir hiperlinkin hedefini değiştirin. `HyperlinkManager` kullanarak zaten bir hiperlink içeren metni değiştirin; bu, PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme şekline benzer.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Mevcut metin içindeki bir hiperlinki değiştirmek için
        // özelliği doğrudan ayarlamaktan ziyade HyperlinkManager kullanılmalıdır.
        // Bu, PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme şekline benzer.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```