---
title: PPTX nach PPT in .NET konvertieren
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/net/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPTX konvertieren
- PPTX nach PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "PPTX ganz einfach mit Aspose.Slides für .NET in PPT konvertieren – gewährleisten Sie nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit C# in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C# konvertieren

## **C# PPTX nach PPT konvertieren**

Für C#‑Beispielcode zum Konvertieren von PPTX nach PPT siehe bitte den folgenden Abschnitt, nämlich [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt einfach die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben. 

- [C# PPTX nach PDF konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPTX nach XPS konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPTX nach HTML konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPTX nach ODP konvertieren](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPTX nach Bild konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. Der nachstehende C#‑Codebeispiel konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```c#
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("presentation.pptx");

// Speichere die PPTX-Präsentation im PPT-Format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Überleben alle PPTX‑Effekte und ‑Funktionen beim Speichern im legacy PPT (97–2003)-Format?**

Nicht immer. Das PPT‑Format fehlt einige neuere Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Direktes Speichern zielt auf die gesamte Präsentation ab. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ verwenden Sie einen Dienst/eine API, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und außerdem [Schutzeinstellungen/Verschlüsselung konfigurieren](/slides/de/net/password-protected-presentation/) für das gespeicherte PPT.