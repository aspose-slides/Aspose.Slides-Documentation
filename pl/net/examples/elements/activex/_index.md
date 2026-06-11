---
title: ActiveX
type: docs
weight: 200
url: /pl/net/examples/elements/activex/
keywords:
- ActiveX
- dodaj ActiveX
- dostęp do ActiveX
- usuń ActiveX
- właściwości ActiveX
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zobacz przykłady ActiveX w Aspose.Slides for .NET: wstawianie, konfigurowanie i kontrolowanie obiektów ActiveX w prezentacjach PPT i PPTX przy użyciu przejrzystego kodu C#."
---
Ten artykuł demonstruje, jak dodać, uzyskać dostęp, usunąć i skonfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for .NET**.

## **Dodaj kontrolkę ActiveX**

Wstaw nową kontrolkę ActiveX i opcjonalnie ustaw jej właściwości.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Dodaj nową kontrolkę ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcjonalnie ustaw niektóre właściwości.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Uzyskaj dostęp do pierwszej kontrolki ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Usuń pierwszą kontrolkę ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Ustaw właściwości ActiveX**

Dodaj kontrolkę i skonfiguruj kilka właściwości ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Dodaj przycisk CommandButton i skonfiguruj właściwości.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```