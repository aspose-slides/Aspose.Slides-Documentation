---
title: SmartArt
type: docs
weight: 140
url: /tr/androidjava/examples/elements/smart-art/
keywords:
- kod örneği
- SmartArt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ta SmartArt ile çalışın: PowerPoint ve OpenDocument sunumları için Java kullanarak diyagramları oluşturun, düzenleyin, dönüştürün ve stil verin."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak SmartArt grafikleri eklemeyi, erişmeyi, kaldırmayı ve düzenleri değiştirmeyi gösterir.

## **SmartArt Ekle**

Yerleşik düzenlerden birini kullanarak bir SmartArt grafiği ekleyin.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt'a Erişim**

Bir slayttaki ilk SmartArt nesnesini alın.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt'ı Kaldır**

Slayttan bir SmartArt şekli silin.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt Düzenini Değiştir**

Mevcut bir SmartArt grafiğinin düzen türünü güncelleyin.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```