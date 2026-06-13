---
title: VBA मैक्रो
type: docs
weight: 150
url: /hi/net/examples/elements/vba-macro/
keywords:
- VBA मैक्रो
- VBA मैक्रो जोड़ें
- VBA मैक्रो तक पहुँचें
- VBA मैक्रो हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुतियों को स्वचालित करें: PPT, PPTX, और ODP में स्पष्ट C# उदाहरणों का उपयोग करके VBA मैक्रो बनाएं, चलाएँ, आयात करें और सुरक्षित रखें।"
---
यह लेख **Aspose.Slides for .NET** का उपयोग करके VBA मैक्रो को जोड़ने, पहुँचने और हटाने का प्रदर्शन करता है।

## **VBA मैक्रो जोड़ें**

VBA प्रोजेक्ट और एक सरल मैक्रो मॉड्यूल के साथ प्रेजेंटेशन बनाएँ।

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **VBA मैक्रो तक पहुँचें**

VBA प्रोजेक्ट से पहला मॉड्यूल प्राप्त करें।

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **VBA मैक्रो हटाएँ**

VBA प्रोजेक्ट से एक मॉड्यूल हटाएँ।

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```