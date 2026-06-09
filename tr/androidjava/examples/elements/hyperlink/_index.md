---
title: Köprü
type: docs
weight: 130
url: /tr/androidjava/examples/elements/hyperlink/
keywords:
- kod örneği
- köprü
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de köprüleri ekleyin ve yönetin: metin köprüleri, şekiller ve görüntüler, PPT, PPTX ve ODP için hedef ve eylemler ayarlayın, Java örnekleriyle."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak şekillerdeki köprüleri ekleme, erişme, kaldırma ve güncelleme işlemlerini göstermektedir.

## **Köprü Ekle**

Dış bir web sitesine işaret eden bir köprüye sahip bir dikdörtgen şekil oluşturun.

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

## **Köprüyü Erişme**

Bir şeklin metin bölümünden köprü bilgisini okuyun.

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

## **Köprüyü Kaldır**

Şeklin metnindeki köprüyü temizleyin.

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

## **Köprüyü Güncelle**

Mevcut bir köprünün hedefini değiştirin. PowerPoint'in köprüleri güvenli bir şekilde güncelleme biçimini taklit eden `HyperlinkManager` kullanarak zaten bir köprü içeren metni değiştirin.

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

        // Mevcut metin içindeki bir köprüyü değiştirmek, şu şekilde yapılmalıdır
        // özelliği doğrudan ayarlamaktan ziyade HyperlinkManager kullanılarak.
        // Bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```