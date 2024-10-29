---
title: PPT in PPTX in C# konvertieren
linktitle: PPT in PPTX konvertieren
type: docs
weight: 20
url: /de/net/convert-ppt-to-pptx/
keywords: "C# PPT in PPTX konvertieren, PowerPoint-Präsentation konvertieren, PPT in PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint PPT in PPTX in C# oder .NET konvertieren"
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPT-Format in das PPTX-Format mit C# und einer Online-PPT-zu-PPTX-Konvertierungs-App umwandelt. Folgendes Thema wird behandelt:

- [PPT in PPTX in C# konvertieren](#convert-ppt-to-pptx)

## **C# PPT in PPTX konvertieren**

Für C#-Beispielcode zur Konvertierung von PPT in PPTX siehe den folgenden Abschnitt, d.h. [PPT in PPTX konvertieren](#convert-ppt-to-pptx). Es lädt einfach die PPT-Datei und speichert sie im PPTX-Format. Durch Angabe verschiedener Speicherformate können Sie die PPT-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln behandelt.

- [C# PPT in PDF konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPT in XPS konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPT in HTML konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPT in ODP konvertieren](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPT in Bild konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Über die Konvertierung von PPT in PPTX**
Konvertieren Sie das alte PPT-Format mit der Aspose.Slides API in PPTX. Wenn Sie Tausende von PPT-Präsentationen in das PPTX-Format umwandeln müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides API ist es möglich, dies in nur wenigen Codezeilen zu tun. Die API unterstützt die volle Kompatibilität zur Konvertierung von PPT-Präsentationen in PPTX und es ist möglich:

- Komplexe Strukturen von Master, Layouts und Folien zu konvertieren.
- Präsentationen mit Diagrammen zu konvertieren.
- Präsentationen mit Gruppierungen, Auto-Formen (wie Rechtecken und Ellipsen), Formen mit benutzerdefinierter Geometrie zu konvertieren.
- Präsentationen zu konvertieren, die Texturen und Füllstile für Auto-Formen haben.
- Präsentationen mit Platzhaltern, Textfeldern und Textbehältern zu konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX-Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx) App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der **Aspose.Slides API**, sodass Sie ein lebendes Beispiel der grundlegenden PPT-zu-PPTX-Konvertierungsfähigkeiten sehen können. Aspose.Slides Conversion ist eine Webanwendung, die es ermöglicht, eine Präsentationsdatei im PPT-Format abzulegen und sie in PPTX konvertiert herunterzuladen.

Finden Sie weitere live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Beispiele.
{{% /alert %}} 


## **PPT in PPTX konvertieren**
Um eine PPT in PPTX zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse. Das folgende C#-Codebeispiel konvertiert eine Präsentation von PPT zu PPTX unter Verwendung der Standardoptionen.

```c#
// Erstellen Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Speichern der PPTX-Präsentation im PPTX-Format
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```



Lesen Sie mehr über die [**PPT vs PPTX**](/slides/de/net/ppt-vs-pptx/) Präsentationsformate und wie [**Aspose.Slides die PPT-zu-PPTX-Konvertierung unterstützt**](/slides/de/net/convert-ppt-to-pptx/).