---
title: ActiveX
type: docs
weight: 200
url: /de/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX hinzufügen
- ActiveX zugreifen
- ActiveX entfernen
- ActiveX-Eigenschaften
- Codebeispiele
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie ActiveX-Steuerelemente in Python mit Aspose.Slides finden, bearbeiten und entfernen, einschließlich der Aktualisierung von Eigenschaften für PowerPoint-Präsentationen."
---
Demonstriert, wie man ActiveX-Steuerelemente zu einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for Python via .NET** verwendet wird.

## **ActiveX-Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX-Steuerelement ein.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Fügen Sie ein neues ActiveX-Steuerelement (TextBox) hinzu.
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Zugriff auf ein ActiveX-Steuerelement**

Lesen Sie Informationen des ersten ActiveX-Steuerelements auf der Folie.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Greifen Sie auf das erste ActiveX-Steuerelement zu.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Drucken Sie den Steuerelementnamen.
            print(f"Control Name: {control.name}")
```

## **ActiveX-Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX-Steuerelement von der Folie.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Entfernen Sie das erste ActiveX-Steuerelement.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX-Eigenschaften festlegen**

Konfigurieren Sie mehrere ActiveX-Eigenschaften.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die Steuerelementsammlung enthält mindestens ein Steuerelement.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```