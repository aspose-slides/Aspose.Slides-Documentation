---
title: ActiveX
type: docs
weight: 200
url: /hi/androidjava/examples/elements/activex/
keywords:
- कोड उदाहरण
- ActiveX
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ActiveX उदाहरण देखें: PPT और PPTX प्रस्तुतियों में ActiveX ऑब्जेक्ट्स को सम्मिलित, कॉन्फ़िगर और नियंत्रित करें, स्पष्ट Java कोड के साथ।"
---
यह लेख प्रस्तुति में **Aspose.Slides for Android via Java** का उपयोग करके ActiveX नियंत्रणों को जोड़ने, एक्सेस करने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **Add an ActiveX Control**
एक नया ActiveX नियंत्रण सम्मिलित करें और वैकल्पिक रूप से उसकी विशेषताओं को सेट करें।

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // नया ActiveX नियंत्रण जोड़ें।
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // वैकल्पिक रूप से कुछ गुण सेट करें।
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an ActiveX Control**
स्लाइड पर पहले ActiveX नियंत्रण से जानकारी पढ़ें।

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहले ActiveX नियंत्रण तक पहुंचें।
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove an ActiveX Control**
स्लाइड से मौजूदा ActiveX नियंत्रण को हटाएं।

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहला ActiveX नियंत्रण हटाएं।
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Set ActiveX Properties**
एक नियंत्रण जोड़ें और कई ActiveX विशेषताओं को कॉन्फ़िगर करें।

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Windows Media Player नियंत्रण जोड़ें और गुण कॉन्फ़िगर करें।
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```