---
title: PPT in PPTX in Java konvertieren
linktitle: PPT in PPTX konvertieren
type: docs
weight: 20
url: /java/convert-ppt-to-pptx/
keywords: "Java PPT in PPTX konvertieren, PowerPoint PPT in PPTX in Java"
description: "PowerPoint PPT in PPTX in Java konvertieren."
---

## **Überblick**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPT-Format in das PPTX-Format mit Java und einer Online-PPT-zu-PPTX-Konvertierungs-App umwandelt. Folgendes Thema wird behandelt.

- PPT in PPTX in Java konvertieren

## **Java PPT in PPTX konvertieren**

Für Java-Beispielcode zur Konvertierung von PPT in PPTX siehe den folgenden Abschnitt, d.h. [PPT in PPTX konvertieren](#convert-ppt-to-pptx). Es lädt einfach die PPT-Datei und speichert sie im PPTX-Format. Durch Angabe verschiedener Speicherformate können Sie auch die PPT-Datei in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln besprochen.

- [Java PPT in PDF konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java PPT in XPS konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java PPT in HTML konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java PPT in ODP konvertieren](https://docs.aspose.com/slides/java/save-presentation/)
- [Java PPT in Bild konvertieren](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Über die PPT in PPTX-Konvertierung**
Konvertieren Sie das alte PPT-Format in PPTX mit der Aspose.Slides API. Wenn Sie Tausende von PPT-Präsentationen in das PPTX-Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides API ist es möglich, dies in nur wenigen Codezeilen zu tun. Die API unterstützt die vollständige Kompatibilität zur Konvertierung von PPT-Präsentationen in PPTX und es ist möglich:

- Komplizierte Strukturen von Master-, Layout- und Folien zu konvertieren.
- Präsentationen mit Diagrammen zu konvertieren.
- Präsentationen mit Gruppenschattierungen, Automatikformen (wie Rechtecke und Ellipsen), Formen mit benutzerdefinierter Geometrie zu konvertieren.
- Präsentationen zu konvertieren, die Texturen und Bilder als Füllstile für Automatikformen haben.
- Präsentationen mit Platzhaltern, Textfeldern und Textcontainern zu konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX-Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx) App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App wurde basierend auf der [**Aspose.Slides API**](https://products.aspose.com/slides/java/) entwickelt, sodass Sie ein Live-Beispiel der grundlegenden PPT-zu-PPTX-Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Webanwendung, die es ermöglicht, eine Präsentationsdatei im PPT-Format abzulegen und sie in das PPTX-Format herunterzuladen.

Finden Sie weitere Live-Beispiele für [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **PPT in PPTX konvertieren**
Aspose.Slides für Java ermöglicht es Entwicklern jetzt, auf das PPT über eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse zuzugreifen und dieses in das jeweilige [PPTX](https://docs.fileformat.com/presentation/pptx/) Format zu konvertieren. Derzeit unterstützt es die teilweise Konvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) in PPTX. Für weitere Einzelheiten zu den unterstützten und nicht unterstützten Funktionen bei der PPT-zu-PPTX-Konvertierung klicken Sie bitte auf diesen Dokumentations-[link](/slides/java/ppt-to-pptx-conversion/).

Aspose.Slides für Java bietet die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse, die eine **PPTX** Präsentationsdatei darstellt. Die Präsentationsklasse kann jetzt auch auf **PPT** zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine PPT-Präsentation in eine PPTX-Präsentation konvertiert.

```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("Aspose.ppt");
try {
// Speichern der PPTX-Präsentation im PPTX-Format
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung : Ausgangspräsentation PPT**|

Der obige Codeausschnitt erzeugte die folgende PPTX-Präsentation nach der Konvertierung.

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX-Präsentation nach der Konvertierung**|