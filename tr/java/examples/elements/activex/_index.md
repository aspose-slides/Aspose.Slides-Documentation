---
title: ActiveX
type: docs
weight: 200
url: /tr/java/examples/elements/activex/
keywords:
- kod örneği
- ActiveX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ActiveX örneklerini görün: PPT ve PPTX sunumlarında ActiveX nesnelerini ekleme, yapılandırma ve kontrol etme, net Java kodu ile."
---
Bu makale, **Aspose.Slides for Java** kullanarak bir sunumda ActiveX denetimlerini ekleme, erişme, kaldırma ve yapılandırma işlemlerini göstermektedir.

## **ActiveX Denetimi Ekle**

Yeni bir ActiveX denetimi ekleyin ve isteğe bağlı olarak özelliklerini ayarlayın.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Yeni bir ActiveX denetimi ekle.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // İsteğe bağlı olarak bazı özellikleri ayarla.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Denetimine Erişme**

Slayttaki ilk ActiveX denetiminden bilgi okuyun.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // İlk ActiveX denetimine eriş.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Denetimini Kaldırma**

Slayttan mevcut bir ActiveX denetimini silin.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // İlk ActiveX denetimini kaldır.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX Özelliklerini Ayarlama**

Bir denetim ekleyin ve çeşitli ActiveX özelliklerini yapılandırın.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Windows Media Player denetimi ekleyin ve özellikleri yapılandırın.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```