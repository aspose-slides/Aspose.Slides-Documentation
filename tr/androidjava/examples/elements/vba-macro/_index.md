---
title: VBA Makrosu
type: docs
weight: 150
url: /tr/androidjava/examples/elements/vba-macro/
keywords:
- kod örneği
- VBA
- makro
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile sunumları otomatikleştirin: PPT, PPTX ve ODP'de VBA makrolarını oluşturun, çalıştırın, içe aktarın ve güvenli hale getirin, net Java örnekleri kullanarak."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak VBA makrolarını eklemeyi, erişmeyi ve kaldırmayı gösterir.

## **VBA Makrosu Ekle**

VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **VBA Makrosuna Erişme**

VBA projesinden ilk modülü alın.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA Makrosunu Kaldır**

VBA projesinden bir modülü silin.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```