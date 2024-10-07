---
title: PPT in PPTX in Java konvertieren
linktitle: PPT in PPTX konvertieren
type: docs
weight: 20
url: /androidjava/convert-ppt-to-pptx/
keywords: "Java PPT in PPTX konvertieren, PowerPoint PPT in PPTX in Java"
description: "PowerPoint PPT in PPTX in Java konvertieren."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPT-Format in das PPTX-Format mit Java und einer Online-PPT-zu-PPTX-Konvertierungsanwendung konvertiert. Folgendes Thema wird behandelt.

- PPT in PPTX in Java konvertieren

## **Java PPT in PPTX konvertieren**

Für Beispielcode in Java zur Konvertierung von PPT in PPTX siehe den Abschnitt unten d.h. [PPT in PPTX konvertieren](#convert-ppt-to-pptx). Es lädt einfach die PPT-Datei und speichert sie im PPTX-Format. Durch die Angabe verschiedener Speicherformate können Sie die PPT-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln behandelt.

- [Java PPT in PDF konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPT in XPS konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPT in HTML konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPT in ODP konvertieren](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPT in Bild konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Über die PPT zu PPTX-Konvertierung**
Konvertieren Sie das alte PPT-Format in PPTX mit der Aspose.Slides-API. Wenn Sie tausende von PPT-Präsentationen ins PPTX-Format konvertieren müssen, ist die beste Lösung, dies programmatisch zu tun. Mit der Aspose.Slides-API ist es möglich, dies in nur wenigen Zeilen Code zu tun. Die API unterstützt die volle Kompatibilität zur Konvertierung von PPT-Präsentationen in PPTX und es ist möglich:

- Komplizierte Strukturen von Master, Layouts und Folien zu konvertieren.
- Präsentationen mit Diagrammen zu konvertieren.
- Präsentationen mit Gruppenschablonen, Autoshapes (wie Rechtecken und Ellipsen), Formen mit benutzerdefinierter Geometrie zu konvertieren.
- Präsentationen mit Texturen und Bildern als Füllstile für Autoshapes zu konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textinhalten zu konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX-Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx) Anwendung:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), sodass Sie ein aktives Beispiel für grundlegende PPT zu PPTX-Konvertierungsfähigkeiten sehen können. Aspose.Slides Conversion ist eine Webanwendung, die es ermöglicht, eine Präsentationsdatei im PPT-Format abzulegen und sie konvertiert im PPTX-Format herunterzuladen.

Finden Sie weitere Live- [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Beispiele.
{{% /alert %}} 

## **PPT in PPTX konvertieren**
Aspose.Slides für Android über Java erleichtert es Entwicklern, auf PPT mit der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klasseninstanz zuzugreifen und diese in das jeweilige [PPTX](https://docs.fileformat.com/presentation/pptx/) Format zu konvertieren. Derzeit unterstützt es die teilweise Konvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) nach PPTX. Für weitere Details darüber, welche Funktionen in der PPT zu PPTX-Konvertierung unterstützt und nicht unterstützt werden, fahren Sie bitte mit diesem Dokumentations- [Link](/slides/androidjava/ppt-to-pptx-conversion/) fort.

Aspose.Slides für Android über Java bietet die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Klassen, die eine **PPTX** Präsentationsdatei repräsentiert. Die Presentation-Klasse kann jetzt auch auf **PPT** zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine PPT-Präsentation in eine PPTX-Präsentation konvertiert.

```java
// Instanziierung eines Presentation-Objekts, das eine PPTX-Datei repräsentiert
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
|**Abbildung : Quell-PPT-Präsentation**|

Der obige Codeausschnitt erzeugte die folgende PPTX-Präsentation nach der Konvertierung

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX-Präsentation nach der Konvertierung**|