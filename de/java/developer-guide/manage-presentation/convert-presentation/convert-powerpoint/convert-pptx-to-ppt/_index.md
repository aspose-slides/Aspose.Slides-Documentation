---
title: PPTX in PPT mit Java konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX zu PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "PPTX einfach mit Aspose.Slides für Java in PPT konvertieren - sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie eine PowerPoint-Präsentation im PPTX-Format mit Java in das PPT-Format konvertieren. Das folgende Thema wird behandelt.

- PPTX in PPT mit Java konvertieren

## **PPTX in PPT mit Java konvertieren**

Für Java-Beispielcode zur Konvertierung von PPTX in PPT siehe den Abschnitt unten, d. h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln erläutert.

- [PPTX in PDF mit Java konvertieren](/slides/de/java/convert-powerpoint-to-pdf/)
- [PPTX in XPS mit Java konvertieren](/slides/de/java/convert-powerpoint-to-xps/)
- [PPTX in HTML mit Java konvertieren](/slides/de/java/convert-powerpoint-to-html/)
- [PPTX in ODP mit Java konvertieren](/slides/de/java/save-presentation/)
- [PPTX in PNG mit Java konvertieren](/slides/de/java/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). Das untenstehende Java-Codebeispiel konvertiert eine Presentation von PPTX nach PPT mit den Standardoptionen.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation presentation = new Presentation("template.pptx");

// Speichern Sie die Präsentation als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Bleiben alle PPTX-Effekte und -Funktionen beim Speichern im alten PPT-Format (97–2003) erhalten?**

Nicht immer. Das PPT-Format fehlt es an einigen neueren Möglichkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), daher können Funktionen bei der Konvertierung vereinfacht oder gerastert werden.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Direktes Speichern richtet sich an die gesamte Präsentation. Um einzelne Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem [Schutz-/Verschlüsselungseinstellungen](/slides/de/java/password-protected-presentation/) für das gespeicherte PPT konfigurieren.