---
title: PPTX nach PPT in PHP konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "PPTX mühelos mit Aspose.Slides in PPT konvertieren — gewährleisten Sie nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten dabei das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit PHP in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT konvertieren

## **PPTX in PPT mit PHP konvertieren**

Für Java‑Beispielcode zum Konvertieren von PPTX in PPT siehe den Abschnitt unten, d.h.[Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln erläutert.

- [Java PPTX nach PDF konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPTX nach XPS konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPTX nach HTML konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPTX nach ODP konvertieren](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPTX nach Bild konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**

Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Das PHP‑Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```php
  # instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $presentation = new Presentation("template.pptx");
  # speichern Sie die Präsentation als PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003)?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Fähigkeiten (z. B. bestimmten Effekten, Objekten und Verhaltensweisen), sodass Funktionen während der Konvertierung vereinfacht oder rasterisiert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Direktes Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, der/die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutz‑/Verschlüsselungseinstellungen](/slides/de/php-java/password-protected-presentation/) für das gespeicherte PPT konfigurieren.