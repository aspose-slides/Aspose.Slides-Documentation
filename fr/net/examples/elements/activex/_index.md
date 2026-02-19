---
title: ActiveX
type: docs
weight: 200
url: /fr/net/examples/elements/activex/
keywords:
- ActiveX
- ajouter ActiveX
- accéder à ActiveX
- supprimer ActiveX
- propriétés ActiveX
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Voir les exemples ActiveX d'Aspose.Slides for .NET: insérer, configurer et contrôler des objets ActiveX dans des présentations PPT et PPTX avec du code C# clair."
---
Cet article montre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un contrôle ActiveX**

Insérez un nouveau contrôle ActiveX et définissez éventuellement ses propriétés.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ajouter un nouveau contrôle ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Définir éventuellement certaines propriétés.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Accéder à un contrôle ActiveX**

Lisez les informations du premier contrôle ActiveX sur la diapositive.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Accéder au premier contrôle ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Supprimer un contrôle ActiveX**

Supprimez un contrôle ActiveX existant de la diapositive.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Supprimer le premier contrôle ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Définir les propriétés ActiveX**

Ajoutez un contrôle et configurez plusieurs propriétés ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ajouter un CommandButton et configurer les propriétés.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```