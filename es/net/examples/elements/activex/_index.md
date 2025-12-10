---
title: ActiveX
type: docs
weight: 200
url: /es/net/examples/elements/activex/
keywords:
- Ejemplo de ActiveX
- Control ActiveX
- agregar ActiveX
- acceder a ActiveX
- eliminar ActiveX
- propiedades ActiveX
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo encontrar, editar y eliminar controles ActiveX en C# con Aspose.Slides, incluyendo actualizaciones de propiedades para presentaciones de PowerPoint."
---

Demuestra cómo agregar, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for .NET**.

## **Agregar un control ActiveX**

Inserte un nuevo control ActiveX y, opcionalmente, establezca sus propiedades.
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Agregar un nuevo control ActiveX (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionalmente establecer algunas propiedades
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## **Acceder a un control ActiveX**

Lea información del primer control ActiveX en la diapositiva.
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // Acceder al primer control ActiveX
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
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Eliminar el primer control ActiveX
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## **Establecer propiedades ActiveX**

Agregue un control y configure varias propiedades ActiveX.
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Agregar un CommandButton y configurar propiedades
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
