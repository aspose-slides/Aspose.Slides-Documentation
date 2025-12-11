---
title: PPTX in PPT auf Android konvertieren
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/androidjava/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX nach PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "PPTX einfach mit Aspose.Slides für Android via Java in PPT konvertieren - sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPTX-Format mit Java in das PPT-Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT mit Java konvertieren

## **PPTX in PPT auf Android konvertieren**

Für Java-Beispielcode zum Konvertieren von PPTX in PPT siehe den Abschnitt unten, d.h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe verschiedener Speicherformate kann die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. gespeichert werden, wie in diesen Artikeln beschrieben.

- [Java PPTX in PDF konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPTX in XPS konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPTX in HTML konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPTX in ODP konvertieren](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPTX in Bild konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, geben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) weiter. Das Java‑Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```java
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation presentation = new Presentation("template.pptx");

// Speichere die Präsentation als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im Legacy‑PPT‑Format (97–2003) erhalten?**

Nicht immer. Das PPT‑Format fehlt einige neuere Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Das direkte Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutz-/Verschlüsselungseinstellungen](/slides/de/androidjava/password-protected-presentation/) für das gespeicherte PPT konfigurieren.