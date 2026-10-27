---
title: Work with ActiveX controls
description: Read and update ActiveX controls already present in slides.
type: docs
url: /features/activex-controls/
weight: 620
feature_id: activex-controls
feature_group: shapes
translationKey: slides-feature-activex-controls
feature_catalogue_version: 3
feature_guides:
- /slides/net/activex/
---

## **Overview**

Inspect existing ActiveX controls, change their properties and adjust their frames in a presentation. This allows an application to maintain control content already present in a deck. The saved file can keep the control and its associated data.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

Download the public [ActiveX sample presentation](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/ActiveX/ActiveX.pptm) as ActiveX.pptm. This C# example changes the stored value of its existing TextBox1 control and saves the macro-enabled format. It does not activate the control or regenerate its cached preview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");
foreach (var control in presentation.Slides[0].Controls)
{
    if (control.Name == "TextBox1" && control.Properties != null)
    {
        control.Properties["Value"] = "Updated control text";
        Console.WriteLine("Updated TextBox1.");
    }
}
presentation.Save("activex-controls.pptm", SaveFormat.Pptm);
```

## **FAQ**

### **Can I create every type of ActiveX control?**

Creation is limited to the supported Windows Media Player control. Reading or modifying an existing control has a broader scope.

### **Can I execute an ActiveX control through the library?**

No. You can inspect and modify stored controls without running their interactive behavior. Activation and events belong to a compatible host application and its security settings.

### **What should I expect when rendering a slide with controls?**

Rendering uses the control’s stored substitute image. A property edit may require you to update that image separately; it does not automatically run the control to create a new preview.

## **Guides**

- [Manage ActiveX Controls in Presentations in .NET](/slides/net/activex/)
