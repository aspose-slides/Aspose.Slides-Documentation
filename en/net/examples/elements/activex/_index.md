---
title: ActiveX
type: docs
weight: 200
url: /net/examples/elements/activex/
keywords:
- ActiveX
- add ActiveX
- access ActiveX
- remove ActiveX
- ActiveX properties
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "See Aspose.Slides for .NET ActiveX examples: insert, configure, and control ActiveX objects in PPT and PPTX presentations with clear C# code."
---

This article demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for .NET**.

The checks verify stored controls and properties. Opening or executing ActiveX controls requires a compatible Windows host and its security permissions.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Add a new ActiveX control.
var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

// Optionally set some properties.
control.Properties["Value"] = "Text";

presentation.Save("add_activex.pptm", SaveFormat.Pptm);
```

## **Access an ActiveX Control**

Create a control with a known Value, then read that property from the first control by index.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var controls = slide.Controls;

// Seed one control so index 0 is available for the access example.
var addedControl = controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);
addedControl.Properties["Value"] = "Text";

var control = controls[0];
Console.WriteLine($"Control Name: {control.Name}");
Console.WriteLine($"Value: {control.Properties["Value"]}");

presentation.Save("activex-02.pptm", SaveFormat.Pptm);
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

slide.Controls.RemoveAt(0);

presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Add a Windows Media Player control and configure its properties.
var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
control.Properties["Caption"] = "Run";
control.Properties["Enabled"] = "true";

presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
```
