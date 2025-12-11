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
description: "Konvertieren Sie PPTX mühelos zu PPT mit Aspose.Slides für Android über Java – stellen Sie nahtlose Kompatibilität mit PowerPoint-Formaten sicher und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPTX‑Format mit Java in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT mit Java konvertieren

## **PPTX in PPT unter Android konvertieren**

Für Java‑Beispielcode zum Konvertieren von PPTX nach PPT siehe bitte den folgenden Abschnitt, d.h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate kann die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. gespeichert werden, wie in diesen Artikeln erläutert.

- [Java Convert PPTX zu PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java Convert PPTX zu XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java Convert PPTX zu HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java Convert PPTX zu ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java Convert PPTX zu Bild](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**

Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). Das Java‑Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation presentation = new Presentation("template.pptx");

// Speichern Sie die Präsentation als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im legacy PPT (97–2003)-Format?**

Nicht immer. Das PPT‑Format fehlt einige neuere Möglichkeiten (z.B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen während der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren anstatt der gesamten Präsentation?**

Ein direktes Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutz-/Verschlüsselungseinstellungen](/slides/de/androidjava/password-protected-presentation/) für das gespeicherte PPT konfigurieren.