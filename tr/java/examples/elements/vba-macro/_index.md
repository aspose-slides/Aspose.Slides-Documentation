---
title: VBA Makro
type: docs
weight: 150
url: /tr/java/examples/elements/vba-macro/
keywords:
- kod örneği
- VBA
- makro
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunumları otomatikleştirin: PPT, PPTX ve ODP'de VBA makrolarını oluşturun, çalıştırın, içe aktarın ve güvenli hale getirin, net Java örnekleri kullanarak."
---
Bu makale, **Aspose.Slides for Java** kullanarak VBA makrolarını ekleme, erişme ve kaldırma işlemlerini göstermektedir.

## **VBA Makro Ekle**

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

## **VBA Makrosuna Erişim**

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