---
title: Slide-Show in Python verwalten
linktitle: Slide-Show
type: docs
weight: 90
url: /de/python-net/manage-slide-show/
keywords:
- Show-Typ
- von Sprecher präsentiert
- von Einzelperson angezeigt
- an Kiosk angezeigt
- Show-Optionen
- dauerhaft wiederholen
- ohne Erzählung anzeigen
- ohne Animation anzeigen
- Stiftfarbe
- Folien anzeigen
- Benutzerdefinierte Show
- Folien vorwärts
- manuell
- mit Zeitangaben
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Slide-Shows in Aspose.Slides für Python über .NET verwalten. Steuern Sie Folienübergänge, Zeitangaben und mehr problemlos in den Formaten PPT, PPTX und ODP."
---

In Microsoft PowerPoint sind die **Slide Show**-Einstellungen ein wichtiges Werkzeug zum Vorbereiten und Vortragen professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, die es Ihnen ermöglicht, Ihre Präsentation an spezielle Bedingungen und Zielgruppen anzupassen und so Flexibilität und Komfort zu gewährleisten. Mit dieser Funktion können Sie den Show‑Typ auswählen (z. B. präsentiert von einem Sprecher, durch einen einzelnen Benutzer angezeigt oder an einem Kiosk angezeigt), Schleifen aktivieren oder deaktivieren, bestimmte Folien zur Anzeige auswählen und Zeitsteuerungen verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirksamer und professioneller zu machen.

`slide_show_settings` ist eine Eigenschaft der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) vom Typ [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/), mit der Sie die Slide‑Show‑Einstellungen in einer PowerPoint‑Präsentation verwalten können. In diesem Artikel untersuchen wir, wie Sie diese Eigenschaft verwenden, um verschiedene Aspekte der Slide‑Show‑Einstellungen zu konfigurieren und zu steuern. 

## **Show‑Typ auswählen**

`SlideShowSettings.slide_show_type` definiert den Typ der Slide‑Show und kann eine Instanz einer der folgenden Klassen sein: [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/). Mit dieser Eigenschaft können Sie die Präsentation an unterschiedliche Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und setzt den Show‑Typ auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Show‑Optionen aktivieren**

`SlideShowSettings.loop` legt fest, ob die Slide‑Show in einer Schleife wiederholt wird, bis sie manuell gestoppt wird. Das ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen sollen. `SlideShowSettings.show_narration` bestimmt, ob während der Slide‑Show gesprochene Erzählungen abgespielt werden. Das ist hilfreich für automatisierte Präsentationen, die Sprachanweisungen für das Publikum enthalten. `SlideShowSettings.show_animation` gibt an, ob Animationen, die Folienobjekten hinzugefügt wurden, abgespielt werden. Das ist wichtig, um den vollen visuellen Effekt der Präsentation zu erzielen.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und lässt die Slide‑Show wiederholen.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Anzuzeigende Folien auswählen**

Die Eigenschaft `SlideShowSettings.slides` ermöglicht es Ihnen, einen Folienbereich auszuwählen, der während der Präsentation angezeigt werden soll. Das ist praktisch, wenn nur ein Teil der Präsentation und nicht alle Folien gezeigt werden sollen. Das folgende Code‑Beispiel erstellt eine neue Präsentation und legt den Anzeigebereich von Folie `2` bis `9` fest.
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Automatisches Voranschalten verwenden**

Die Eigenschaft `SlideShowSettings.use_timings` erlaubt es, die Verwendung vordefinierter Zeitangaben für jede Folie zu aktivieren oder zu deaktivieren. Das ist nützlich, um Folien automatisch mit festgelegten Anzeigedauern zu zeigen. Das folgende Code‑Beispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Timings.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Medien‑Steuerelemente anzeigen**

Die Eigenschaft `SlideShowSettings.show_media_controls` legt fest, ob während der Slide‑Show Medien‑Steuerelemente (wie Spielen, Pause und Stopp) angezeigt werden, wenn Multimedia‑Inhalte (z. B. Video oder Audio) abgespielt werden. Das ist praktisch, wenn Sie dem Vortragenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Code‑Beispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Medien‑Steuerelementen.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich eine Präsentation speichern, sodass sie direkt im Präsentationsmodus startet?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten beim Öffnen in PowerPoint direkt im Präsentationsmodus. In Aspose.Slides wählen Sie das entsprechende Speicherformat [during export](/slides/de/python-net/save-presentation/).

**Kann ich einzelne Folien von der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide‑Show nicht angezeigt.

**Kann Aspose.Slides eine Slide‑Show abspielen oder eine Live‑Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Viewer‑Anwendung wie PowerPoint übernommen.