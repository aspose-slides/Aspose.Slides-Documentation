---
title: ActiveX
type: docs
weight: 200
url: /fr/python-net/examples/elements/activex/
keywords:
- ActiveX
- contrôle ActiveX
- ajouter ActiveX
- accéder à ActiveX
- supprimer ActiveX
- propriétés ActiveX
- exemples de code
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment trouver, modifier et supprimer des contrôles ActiveX en Python avec Aspose.Slides, y compris les mises à jour des propriétés pour les présentations PowerPoint."
---
Démontre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation à l'aide de **Aspose.Slides for Python via .NET**.

## **Ajouter un contrôle ActiveX**

Insérer un nouveau contrôle ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter un nouveau contrôle ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Accéder à un contrôle ActiveX**

Lire les informations du premier contrôle ActiveX sur la diapositive.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier contrôle ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Afficher le nom du contrôle.
            print(f"Control Name: {control.name}")
```

## **Supprimer un contrôle ActiveX**

Supprimer un contrôle ActiveX existant de la diapositive.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Supprimer le premier contrôle ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Définir les propriétés ActiveX**

Configurer plusieurs propriétés ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # En supposant que la collection de contrôles contient au moins un contrôle.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```