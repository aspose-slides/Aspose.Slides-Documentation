---
title: ActiveX
type: docs
weight: 200
url: /es/net/examples/elements/activex/
keywords:
- ActiveX
- añadir ActiveX
- acceder ActiveX
- eliminar ActiveX
- propiedades ActiveX
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Consulte los ejemplos de ActiveX de Aspose.Slides for .NET: inserte, configure y controle objetos ActiveX en presentaciones PPT y PPTX con código C# claro."
---
Este artículo muestra cómo añadir, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for .NET**.

## **Agregar un control ActiveX**

Inserte un nuevo control ActiveX y, opcionalmente, establezca sus propiedades.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Añadir un nuevo control ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionalmente establecer algunas propiedades.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Acceder a un control ActiveX**

Lea información del primer control ActiveX en la diapositiva.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Acceder al primer control ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Eliminar un control ActiveX**

Elimine un control ActiveX existente de la diapositiva.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Eliminar el primer control ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Establecer propiedades del ActiveX**

Agregue un control y configure varias propiedades del ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Añadir un CommandButton y configurar propiedades.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```