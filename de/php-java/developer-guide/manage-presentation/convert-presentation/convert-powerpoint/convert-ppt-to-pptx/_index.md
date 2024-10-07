---
title: PPT in PPTX konvertieren
linktitle: PPT in PPTX konvertieren
type: docs
weight: 20
url: /php-java/convert-ppt-to-pptx/
keywords: "PHP  PPT in PPTX konvertieren, PowerPoint PPT in PPTX "
description: "PowerPoint PPT in PPTX konvertieren."
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPT-Format in das PPTX-Format mit PHP und einer Online-PPT-zu-PPTX-Konvertierungs-App umwandelt. Das folgende Thema wird behandelt.

- PPT in PPTX konvertieren

## **Java PPT in PPTX konvertieren**

Für den Java-Beispielcode zum Konvertieren von PPT in PPTX siehe den Abschnitt unten, d. h. [PPT in PPTX konvertieren](#convert-ppt-to-pptx). Es lädt die PPT-Datei und speichert sie im PPTX-Format. Durch die Angabe verschiedener Speicherformate können Sie die PPT-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln diskutiert.

- [Java PPT in PDF konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPT in XPS konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPT in HTML konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPT in ODP konvertieren](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPT in Bild konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Über die PPT in PPTX-Konvertierung**
Konvertieren Sie das alte PPT-Format mit der Aspose.Slides API in PPTX. Wenn Sie Tausende von PPT-Präsentationen in das PPTX-Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides API ist es möglich, dies in nur wenigen Codezeilen zu tun. Die API unterstützt die vollständige Kompatibilität zur Konvertierung von PPT-Präsentationen in PPTX und es ist möglich:

- Komplizierte Strukturen aus Master, Layouts und Folien zu konvertieren.
- Präsentationen mit Diagrammen zu konvertieren.
- Präsentationen mit Gruppenelementen, Auto-Formen (wie Rechtecken und Ellipsen), Formen mit benutzerdefinierter Geometrie zu konvertieren.
- Präsentationen mit Texturen und Bildern als Füllstile für Auto-Formen zu konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textcontainern zu konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX-Konvertierungs**](https://products.aspose.app/slides/conversion/ppt-to-pptx) App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App wurde auf der Grundlage der [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) entwickelt, sodass Sie ein lebendiges Beispiel für die grundlegenden PPT-zu-PPTX-Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Webanwendung, die es ermöglicht, eine Präsentationsdatei im PPT-Format abzulegen und sie konvertiert in PPTX herunterzuladen.

Finden Sie weitere Live- [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Beispiele.
{{% /alert %}} 

## **PPT in PPTX konvertieren**
Aspose.Slides für PHP über Java erleichtert es Entwicklern, über die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasseninstanz auf das PPT zuzugreifen und dies in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/) Format zu konvertieren. Derzeit unterstützt es die partielle Konvertierung von [PPT ](https://docs.fileformat.com/presentation/ppt/) in PPTX. Für weitere Details zu den unterstützten und nicht unterstützten Funktionen bei der PPT-zu-PPTX-Konvertierung wenden Sie sich bitte an diese Dokumentation [link](/slides/php-java/ppt-to-pptx-conversion/).

Aspose.Slides für PHP über Java bietet die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse, die eine **PPTX** Präsentationsdatei darstellt. Die Presentation-Klasse kann jetzt auch **PPT** über Presentation zugreifen, wenn das Objekt instanziiert ist. Das folgende Beispiel zeigt, wie man eine PPT-Präsentation in eine PPTX-Präsentation konvertiert.

```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("Aspose.ppt");
  try {
    # Speichern der PPTX-Präsentation im PPTX-Format
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung : Quell-PPT-Präsentation**|

Der obige Codeschnipsel erzeugte die folgende PPTX-Präsentation nach der Konvertierung

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX-Präsentation nach der Konvertierung**|