---
title: PPTX in PPT konvertieren in .NET
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PPTX ganz einfach in PPT mit Aspose.Slides für .NET – gewährleisten Sie nahtlose Kompatibilität mit PowerPoint-Formaten und bewahren Sie das Layout sowie die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit C# in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT mit C# konvertieren

## **PPTX in PPT mit .NET konvertieren**

Für C#‑Beispielcode zum Konvertieren von PPTX in PPT siehe den Abschnitt unten, d.h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Es lädt einfach die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben. 

- [PPTX in PDF konvertieren in .NET](/slides/de/net/convert-powerpoint-to-pdf/)
- [PPTX in XPS konvertieren in .NET](/slides/de/net/convert-powerpoint-to-xps/)
- [PPTX in HTML konvertieren in .NET](/slides/de/net/convert-powerpoint-to-html/)
- [PPTX in ODP konvertieren in .NET](/slides/de/net/save-presentation/)
- [PPTX in PNG konvertieren in .NET](/slides/de/net/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. Der C#‑Code‑Beispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("presentation.pptx");

// Speichern der PPTX-Präsentation im PPT-Format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Überleben alle PPTX‑Effekte und -Funktionen beim Speichern im legacy PPT (97–2003)-Format?**

Nicht immer. Das PPT‑Format fehlt einige neuere Fähigkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen während der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Direktes Speichern zielt auf die gesamte Präsentation ab. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation nur mit diesen Folien und speichern Sie sie als PPT; alternativ verwenden Sie einen Service/API, der Konvertierungsparameter pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und auch [Schutzeinstellungen konfigurieren](/slides/de/net/password-protected-presentation/) für das gespeicherte PPT festlegen.