---
title: ActiveX
type: docs
weight: 200
url: /hi/cpp/examples/elements/activex/
keywords:
- कोड उदाहरण
- ActiveX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की ActiveX उदाहरण देखें: PPT और PPTX प्रस्तुतियों में ActiveX वस्तुओं को सम्मिलित, कॉन्फ़िगर और नियंत्रित करें स्पष्ट C++ कोड के साथ।"
---
यह लेख प्रस्तुति में **Aspose.Slides for C++** का उपयोग करके ActiveX नियंत्रणों को जोड़ने, पहुँचने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **ActiveX नियंत्रण जोड़ें**

एक नया ActiveX नियंत्रण सम्मिलित करें और वैकल्पिक रूप से उसके गुण सेट करें।

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // नया ActiveX नियंत्रण जोड़ें.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // वैकल्पिक रूप से कुछ गुण सेट करें.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX नियंत्रण तक पहुँचें**

स्लाइड पर पहले ActiveX नियंत्रण से जानकारी पढ़ें।

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // पहले ActiveX नियंत्रण तक पहुँचें.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **ActiveX नियंत्रण हटाएँ**

स्लाइड से मौजूदा ActiveX नियंत्रण को हटाएँ।

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // पहला ActiveX नियंत्रण हटाएँ.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **ActiveX गुण सेट करें**

एक नियंत्रण जोड़ें और कई ActiveX गुण कॉन्फ़िगर करें।

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Windows Media Player नियंत्रण जोड़ें और गुण कॉन्फ़िगर करें.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```