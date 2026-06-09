---
title: Mürekkep
type: docs
weight: 180
url: /tr/java/examples/elements/ink/
keywords:
- kod örneği
- mürekkep
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile Mürekkep üzerinde çalışın: darbeleri çizin, içe aktarın ve düzenleyin, renk ve genişliği ayarlayın ve Java örnekleri kullanarak PPT, PPTX ve ODP'ye dışa aktarın."
---
Bu makale, mevcut mürekkep şekillerine erişme ve bunları **Aspose.Slides for Java** kullanarak kaldırma örnekleri sağlar.

> ❗ **Not:** Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girdisini temsil eder. Aspose.Slides programlı olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.

## **Mürekkebe Erişim**

Bir slayttaki ilk mürekkep şeklinin etiketlerini okuyun.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // tagName'i gerektiği gibi kullan.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Mürekkebi Kaldır**

Eğer mevcutsa, slayttan bir mürekkep şekli silin.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```