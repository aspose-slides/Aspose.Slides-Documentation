---
title: PPTX in PPT in Java konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Einfach PPTX mit Aspose.Slides für Java in PPT konvertieren – sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPTX‑Format mit Java in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in Java konvertieren

## **PPTX nach PPT in Java konvertieren**

Für Java‑Beispielcode zum Konvertieren von PPTX zu PPT siehe den Abschnitt weiter unten, d. h.[PPTX nach PPT konvertieren](#convert-pptx-to-ppt). Er lädt einfach die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [Java PPTX nach PDF konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java PPTX nach XPS konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java PPTX nach HTML konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java PPTX nach ODP konvertieren](https://docs.aspose.com/slides/java/save-presentation/)
- [Java PPTX nach Bild konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse. Der nachstehende Java‑Code‑Beispiel konvertiert eine Presentation von PPTX nach PPT mit den Standardeinstellungen.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
Presentation presentation = new Presentation("template.pptx");

// Speichern Sie die Präsentation als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003) erhalten?**

Nicht immer. Das PPT‑Format fehlt einige neuere Fähigkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Direktes Speichern zielt auf die gesamte Präsentation ab. Um einzelne Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern sie als PPT; alternativ können Sie einen Service/API verwenden, der Konvertierungsparameter pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und auch [Schutzeinstellungen/Verschlüsselung konfigurieren](/slides/de/java/password-protected-presentation/) für das gespeicherte PPT.