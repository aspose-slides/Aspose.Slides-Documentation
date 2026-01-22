---
title: PPTX zu PPT in PHP konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPTX konvertieren
- PPTX zu PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "PPTX einfach mit Aspose.Slides in PPT konvertieren – sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPTX-Format mit PHP in das PPT-Format konvertiert. Folgende Themen werden behandelt.

- PPTX in PPT konvertieren

## **PPTX in PPT mit PHP konvertieren**

Für Beispielcode in Java zum Konvertieren von PPTX zu PPT siehe den Abschnitt unten, also [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [PPTX in PDF mit PHP konvertieren](/slides/de/php-java/convert-powerpoint-to-pdf/)
- [PPTX in XPS mit PHP konvertieren](/slides/de/php-java/convert-powerpoint-to-xps/)
- [PPTX in HTML mit PHP konvertieren](/slides/de/php-java/convert-powerpoint-to-html/)
- [PPTX in ODP mit PHP konvertieren](/slides/de/php-java/save-presentation/)
- [PPTX in PNG mit PHP konvertieren](/slides/de/php-java/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Das PHP-Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```php
  # instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $presentation = new Presentation("template.pptx");
  # speichere die Präsentation als PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**Überleben alle PPTX-Effekte und -Funktionen beim Speichern im alten PPT-Format (97–2003)?**

Nicht immer. Das PPT-Format verfügt nicht über einige neuere Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Das direkte Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und außerdem die [Schutz-/Verschlüsselungseinstellungen](/slides/de/php-java/password-protected-presentation/) für das gespeicherte PPT konfigurieren.