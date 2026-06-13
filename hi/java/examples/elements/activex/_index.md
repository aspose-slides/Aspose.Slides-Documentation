---
title: ActiveX
type: docs
weight: 200
url: /hi/java/examples/elements/activex/
keywords:
- कोड उदाहरण
- ActiveX
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के ActiveX उदाहरण देखें: PPT और PPTX प्रस्तुतियों में ActiveX ऑब्जेक्ट्स को सम्मिलित करना, कॉन्फ़िगर करना और नियंत्रित करना, स्पष्ट Java कोड के साथ।"
---
यह लेख प्रस्तुति में **Aspose.Slides for Java** का उपयोग करके ActiveX नियंत्रणों को जोड़ने, पहुँचने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **ActiveX नियंत्रण जोड़ें**

एक नया ActiveX नियंत्रण डालें और वैकल्पिक रूप से उसकी विशेषताओं को सेट करें।

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक नया ActiveX नियंत्रण जोड़ें।
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // वैकल्पिक रूप से कुछ गुण सेट करें।
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX नियंत्रण तक पहुँचें**

स्लाइड पर पहले ActiveX नियंत्रण से जानकारी पढ़ें।

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहले ActiveX नियंत्रण तक पहुँचें।
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX नियंत्रण हटाएँ**

स्लाइड से मौजूदा ActiveX नियंत्रण को हटाएँ।

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // पहले ActiveX नियंत्रण को हटाएँ।
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX गुण सेट करें**

एक नियंत्रण जोड़ें और कई ActiveX गुणों को कॉन्फ़िगर करें।

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // एक Windows Media Player नियंत्रण जोड़ें और गुण कॉन्फ़िगर करें।
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```