---
title: ActiveX
type: docs
weight: 200
url: /hi/net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX जोड़ें
- ActiveX पहुंचें
- ActiveX हटाएँ
- ActiveX गुण
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ActiveX उदाहरण देखें: PPT और PPTX प्रस्तुतियों में ActiveX ऑब्जेक्ट्स को सम्मिलित, कॉन्फ़िगर और नियंत्रित करें, स्पष्ट C# कोड के साथ."
---
यह लेख प्रस्तुति में **Aspose.Slides for .NET** का उपयोग करके ActiveX नियंत्रणों को जोड़ने, पहुँचने, हटाने और कॉन्फ़िगर करने का प्रदर्शन करता है।

## **एक ActiveX नियंत्रण जोड़ें**

एक नया ActiveX नियंत्रण सम्मिलित करें और वैकल्पिक रूप से उसकी गुण सेट करें।

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // नया ActiveX नियंत्रण जोड़ें.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // वैकल्पिक रूप से कुछ गुण सेट करें.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **एक ActiveX नियंत्रण को एक्सेस करें**

स्लाइड पर पहले ActiveX नियंत्रण से जानकारी पढ़ें।

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // पहले ActiveX नियंत्रण को एक्सेस करें.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **एक ActiveX नियंत्रण हटाएँ**

स्लाइड से मौजूदा ActiveX नियंत्रण को हटाएँ।

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // पहले ActiveX नियंत्रण को हटाएँ.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **ActiveX गुण सेट करें**

एक नियंत्रण जोड़ें और कई ActiveX गुण कॉन्फ़िगर करें।

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // CommandButton जोड़ें और गुण कॉन्फ़िगर करें.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```