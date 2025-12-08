---
title: PPTX nach PPT in JavaScript konvertieren
linktitle: PPTX nach PPT konvertieren
type: docs
weight: 21
url: /de/nodejs-java/convert-pptx-to-ppt/
keywords: "Java PPTX nach PPT konvertieren, PowerPoint-Präsentation konvertieren, PPTX nach PPT, Java, Aspose.Slides"
description: "PowerPoint PPTX in PPT mit JavaScript konvertieren"
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit JavaScript in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT mit JavaScript konvertieren

## **Java PPTX nach PPT konvertieren**

Für JavaScript‑Beispielcode zum Konvertieren von PPTX nach PPT siehe den untenstehenden Abschnitt, d.h.[Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe anderer Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln erläutert. 

- [Java PPTX nach PDF konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java PPTX nach XPS konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java PPTX nach HTML konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java PPTX nach ODP konvertieren](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java PPTX nach Bild konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**

Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Der untenstehende JavaScript‑Codebeispiel konvertiert eine Präsentation von PPTX nach PPT mit den Standardeinstellungen.
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
var presentation = new aspose.slides.Presentation("template.pptx");
// speichere die Präsentation als PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003) erhalten?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Funktionen (z. B. bestimmten Effekten, Objekten und Verhaltensweisen), sodass Features während der Konvertierung vereinfacht oder rasterisiert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Das direkte Speichern richtet sich an die gesamte Präsentation. Um einzelne Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern sie als PPT; alternativ können Sie einen Dienst/eine API nutzen, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutz‑/Verschlüsselungseinstellungen](/slides/de/nodejs-java/password-protected-presentation/) für das gespeicherte PPT konfigurieren.