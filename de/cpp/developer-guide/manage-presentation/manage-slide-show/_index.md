---
title: "Slide Show verwalten in C++"
linktitle: "Bildschirmpräsentation"
type: docs
weight: 90
url: /de/cpp/manage-slide-show/
keywords:
- "Show-Typ"
- "Präsentiert vom Sprecher"
- "Durchsucht von Einzelperson"
- "Durchsucht am Kiosk"
- "Show-Optionen"
- "Kontinuierlich wiederholen"
- "Show ohne Erzählung"
- "Show ohne Animation"
- "Stiftfarbe"
- "Folien anzeigen"
- "Benutzerdefinierte Show"
- "Folien vorwärts schalten"
- "Manuell"
- "Mit Zeiten"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Bildschirmschauen in Aspose.Slides für C++ verwalten. Steuern Sie Folienübergänge, Zeiten und mehr in den Formaten PPT, PPTX und ODP mühelos."
---

In Microsoft PowerPoint sind die **Slide Show**-Einstellungen ein wichtiges Werkzeug zur Vorbereitung und Durchführung professioneller Präsentationen. Eine der wichtigsten Funktionen in diesem Abschnitt ist **Set Up Show**, mit der Sie Ihre Präsentation an bestimmte Bedingungen und Zielgruppen anpassen können, was Flexibilität und Komfort gewährleistet. Mit dieser Funktion können Sie den Show‑Typ auswählen (z. B. präsentiert von einem Sprecher, von einer Einzelperson durchgesehen oder an einem Kiosk durchgesehen), das Looping ein- oder ausschalten, bestimmte Folien zur Anzeige auswählen und Zeitpunkte verwenden. Dieser Vorbereitungsschritt ist entscheidend, um Ihre Präsentation wirksamer und professioneller zu machen.

`get_SlideShowSettings` ist eine Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, die ein Objekt vom Typ [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/) zurückgibt, mit dem Sie die Slide-Show-Einstellungen in einer PowerPoint-Präsentation verwalten können. In diesem Artikel untersuchen wir, wie Sie diese Methode verwenden, um verschiedene Aspekte der Slide-Show-Einstellungen zu konfigurieren und zu steuern. 

## **Show-Typ auswählen**

`SlideShowSettings.set_SlideShowType` definiert den Typ der Slide-Show, der eine Instanz einer der folgenden Klassen sein kann: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), oder [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). Mit dieser Methode können Sie die Präsentation an verschiedene Nutzungsszenarien anpassen, z. B. automatisierte Kioske oder manuelle Präsentationen.

Das folgende Codebeispiel erstellt eine neue Präsentation und setzt den Show-Typ auf „Browsed by an individual“, ohne die Bildlaufleiste anzuzeigen.
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Show-Optionen aktivieren**

`SlideShowSettings.set_Loop` bestimmt, ob die Slide-Show in einer Schleife wiederholt werden soll, bis sie manuell gestoppt wird. Dies ist nützlich für automatisierte Präsentationen, die kontinuierlich laufen müssen. `SlideShowSettings.set_ShowNarration` legt fest, ob Sprachkommentare während der Slide-Show abgespielt werden sollen. Das ist nützlich für automatisierte Präsentationen, die eine Sprachführung für das Publikum enthalten. `SlideShowSettings.set_ShowAnimation` entscheidet, ob hinzugefügte Animationen von Folienobjekten abgespielt werden sollen. Dies ist hilfreich, um den vollen visuellen Effekt der Präsentation zu gewährleisten.

Das folgende Codebeispiel erstellt eine neue Präsentation und lässt die Slide-Show wiederholen.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Folien zum Anzeigen auswählen**

`SlideShowSettings.set_Slides`-Methode ermöglicht es Ihnen, einen Bereich von Folien auszuwählen, die während der Präsentation angezeigt werden sollen. Dies ist nützlich, wenn Sie nur einen Teil der Präsentation und nicht alle Folien zeigen möchten. Das folgende Codebeispiel erstellt eine neue Präsentation und legt den Folienbereich von Folie `2` bis `9` fest.
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Automatisches Vorwärtsblättern verwenden**

`SlideShowSettings.set_UseTimings`-Methode ermöglicht das Aktivieren oder Deaktivieren der Verwendung vordefinierter Zeiten für jede Folie. Dies ist nützlich, um Folien automatisch mit festgelegten Anzeigedauern zu zeigen. Das folgende Codebeispiel erstellt eine neue Präsentation und deaktiviert die Verwendung von Zeiten.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Mediensteuerungen anzeigen**

`SlideShowSettings.set_ShowMediaControls`-Methode bestimmt, ob Mediensteuerungen (wie Wiedergabe, Pause und Stopp) während der Slide-Show angezeigt werden sollen, wenn multimediale Inhalte (z. B. Video oder Audio) abgespielt werden. Dies ist nützlich, wenn Sie dem Präsentierenden die Kontrolle über die Medienwiedergabe während der Präsentation geben möchten.

Das folgende Codebeispiel erstellt eine neue Präsentation und aktiviert die Anzeige von Mediensteuerungen.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**Kann ich eine Präsentation so speichern, dass sie direkt im Slide-Show-Modus geöffnet wird?**

Ja. Speichern Sie die Datei als PPSX oder PPSM; diese Formate starten die Slide-Show direkt, wenn sie in PowerPoint geöffnet werden. In Aspose.Slides wählen Sie das entsprechende Speicherformat [bei Export](/slides/de/cpp/save-presentation/).

**Kann ich einzelne Folien aus der Show ausschließen, ohne sie aus der Datei zu löschen?**

Ja. Markieren Sie eine Folie als [hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/). Versteckte Folien bleiben in der Präsentation, werden jedoch während der Slide-Show nicht angezeigt.

**Kann Aspose.Slides eine Slide-Show abspielen oder eine Live-Präsentation auf dem Bildschirm steuern?**

Nein. Aspose.Slides bearbeitet, analysiert und konvertiert Präsentationsdateien; die eigentliche Wiedergabe wird von einer Anzeiganwendung wie PowerPoint übernommen.