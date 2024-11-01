---
title: PPTX in PPT in Java konvertieren
linktitle: PPTX in PPT konvertieren
type: docs
weight: 21
url: /de/java/convert-pptx-to-ppt/
keywords: "Java PPTX in PPT konvertieren, PowerPoint-Präsentation konvertieren, PPTX in PPT, Java, Aspose.Slides"
description: "PowerPoint PPTX in PPT in Java konvertieren"
---

## **Überblick**

In diesem Artikel wird erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format in das PPT-Format mithilfe von Java konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT in Java konvertieren

## **Java PPTX in PPT konvertieren**

Für Beispiele von Java-Code zur Konvertierung von PPTX in PPT siehe den Abschnitt unten, d.h. [PPTX in PPT konvertieren](#convert-pptx-to-ppt). Es lädt einfach die PPTX-Datei und speichert sie im PPT-Format. Durch die Angabe verschiedener Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln besprochen. 

- [Java PPTX in PDF konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java PPTX in XPS konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java PPTX in HTML konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java PPTX in ODP konvertieren](https://docs.aspose.com/slides/java/save-presentation/)
- [Java PPTX in Bild konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse. Der folgende Java-Code konvertiert eine Präsentation von PPTX in PPT mit den Standardoptionen.

```java
// Ein Presentation-Objekt instanziieren, das eine PPTX-Datei repräsentiert
Presentation presentation = new Presentation("template.pptx");

// Präsentation als PPT speichern
presentation.save("output.ppt", SaveFormat.Ppt);  
```