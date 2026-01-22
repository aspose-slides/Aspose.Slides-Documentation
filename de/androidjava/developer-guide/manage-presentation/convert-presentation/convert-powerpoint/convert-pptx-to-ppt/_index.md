---
title: PPTX in PPT auf Android konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "PPTX einfach mit Aspose.Slides für Android via Java in PPT konvertieren - sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPTX‑Format mit Java in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT mit Java konvertieren

## **PPTX in PPT unter Android konvertieren**

Für Java‑Beispielcode zur Konvertierung von PPTX in PPT siehe den Abschnitt unten, also [PPTX in PPT konvertieren](#convert-pptx-to-ppt). Er lädt einfach die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [PPTX in PDF konvertieren unter Android](/slides/de/androidjava/convert-powerpoint-to-pdf/)
- [PPTX in XPS konvertieren unter Android](/slides/de/androidjava/convert-powerpoint-to-xps/)
- [PPTX in HTML konvertieren unter Android](/slides/de/androidjava/convert-powerpoint-to-html/)
- [PPTX in ODP konvertieren unter Android](/slides/de/androidjava/save-presentation/)
- [PPTX in PNG konvertieren unter Android](/slides/de/androidjava/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Der Java‑Code unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation presentation = new Presentation("template.pptx");

// Speichern Sie die Präsentation als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im Legacy‑PPT‑Format (97–2003)?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Möglichkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Direktes Speichern zielt auf die gesamte Präsentation ab. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation mit nur diesen Folien und speichern sie als PPT; alternativ verwenden Sie einen Dienst/API, der Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und auch [Schutz‑/Verschlüsselungseinstellungen](/slides/de/androidjava/password-protected-presentation/) für das gespeicherte PPT konfigurieren.