---
title: ActiveX
type: docs
weight: 200
url: /sv/net/examples/elements/activex/
keywords:
- ActiveX
- lägg till ActiveX
- åtkomst till ActiveX
- ta bort ActiveX
- ActiveX-egenskaper
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Se Aspose.Slides for .NET ActiveX-exempel: infoga, konfigurera och styra ActiveX-objekt i PPT- och PPTX-presentationer med tydlig C#-kod."
---
Den här artikeln visar hur du lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en ActiveX‑kontroll**

Infoga en ny ActiveX‑kontroll och ange eventuellt dess egenskaper.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Lägg till en ny ActiveX‑kontroll.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Ställ in eventuellt några egenskaper.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Få åtkomst till en ActiveX‑kontroll**

Läs information från den första ActiveX‑kontrollen på bilden.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Åtkomst till den första ActiveX-kontrollen.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Ta bort en ActiveX‑kontroll**

Ta bort en befintlig ActiveX‑kontroll från bilden.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Ta bort den första ActiveX-kontrollen.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Ställ in ActiveX‑egenskaper**

Lägg till en kontroll och konfigurera flera ActiveX‑egenskaper.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Lägg till en CommandButton och konfigurera egenskaper.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```