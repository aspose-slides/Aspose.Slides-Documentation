---
title: PPTX in PPT konvertieren
linktitle: PPTX in PPT konvertieren
type: docs
weight: 21
url: /de/php-java/convert-pptx-to-ppt/
keywords: "PHP  PPTX in PPT konvertieren, PowerPoint-Präsentation konvertieren, PPTX in PPT, Java, Aspose.Slides"
description: "PowerPoint PPTX in PPT konvertieren"
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format in das PPT-Format mithilfe von PHP konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT konvertieren

## **Java PPTX in PPT konvertieren**

Für ein Java-Beispiel zur Konvertierung von PPTX in PPT siehe den Abschnitt unten d.h. [PPTX in PPT konvertieren](#convert-pptx-to-ppt). Es lädt die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe unterschiedlicher Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [Java PPTX in PDF konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPTX in XPS konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPTX in HTML konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPTX in ODP konvertieren](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPTX in Bild konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse. Das folgende PHP-Codebeispiel konvertiert eine Präsentation von PPTX in PPT mit den Standardeinstellungen.

```php
  # eine Präsentationsobjekt instanziieren, das eine PPTX-Datei darstellt
  $presentation = new Presentation("template.pptx");
  # die Präsentation als PPT speichern
  $presentation->save("output.ppt", SaveFormat::Ppt);
```