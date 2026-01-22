---
title: PPTX nach PPT in JavaScript konvertieren
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PPTX mühelos mit Aspose.Slides nach PPT konvertieren – sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPTX‑Format mit JavaScript in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in JavaScript konvertieren

## **Java PPTX nach PPT konvertieren**

Für Beispielcode in JavaScript zum Konvertieren von PPTX nach PPT siehe den nachfolgenden Abschnitt, nämlich [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate kann die PPTX‑Datei außerdem in viele andere Formate wie PDF, XPS, ODP, HTML usw. gespeichert werden, wie in diesen Artikeln beschrieben.

- [PPTX nach PDF in JavaScript](/slides/de/nodejs-java/convert-powerpoint-to-pdf/)
- [PPTX nach XPS in JavaScript](/slides/de/nodejs-java/convert-powerpoint-to-xps/)
- [PPTX nach HTML in JavaScript](/slides/de/nodejs-java/convert-powerpoint-to-html/)
- [PPTX nach ODP in JavaScript](/slides/de/nodejs-java/save-presentation/)
- [PPTX nach PNG in JavaScript](/slides/de/nodejs-java/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**

Um ein PPTX nach PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Der untenstehende JavaScript‑Code zeigt ein Beispiel, das eine Präsentation von PPTX nach PPT mit den Standardoptionen konvertiert.
```javascript
// Ein Presentation-Objekt instanziieren, das eine PPTX-Datei repräsentiert
var presentation = new aspose.slides.Presentation("template.pptx");
// Die Präsentation als PPT speichern
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003)?**

Nicht immer. Das PPT‑Format enthält nicht alle neueren Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien nach PPT konvertieren statt der gesamten Präsentation?**

Das direkte Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern sie als PPT; alternativ nutzen Sie einen Dienst/eine API, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [configure protection/encryption settings](/slides/de/nodejs-java/password-protected-presentation/) für das gespeicherte PPT festlegen.