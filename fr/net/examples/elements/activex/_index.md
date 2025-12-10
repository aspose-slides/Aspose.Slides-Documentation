---
title: ActiveX
type: docs
weight: 200
url: /fr/net/examples/elements/activex/
keywords:
- Exemple ActiveX
- Contrôle ActiveX
- ajouter ActiveX
- accéder ActiveX
- supprimer ActiveX
- propriétés ActiveX
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment trouver, modifier et supprimer des contrôles ActiveX en C# avec Aspose.Slides, y compris les mises à jour des propriétés pour les présentations PowerPoint."
---

Démontre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation en utilisant **Aspose.Slides for .NET**.

## **Ajouter un contrôle ActiveX**

Insérez un nouveau contrôle ActiveX et définissez éventuellement ses propriétés.
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Ajouter un nouveau contrôle ActiveX (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Optionnellement définir quelques propriétés
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## **Accéder à un contrôle ActiveX**

Lisez les informations du premier contrôle ActiveX sur la diapositive.
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // Accéder au premier contrôle ActiveX
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
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Supprimer le premier contrôle ActiveX
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## **Définir les propriétés ActiveX**

Ajoutez un contrôle et configurez plusieurs propriétés ActiveX.
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Ajouter un CommandButton et configurer les propriétés
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
