---
title: Ersetzen von Bildern in der Präsentationsbildsammlung
type: docs
weight: 80
url: /java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides für Java ermöglicht das Ersetzen von Bildern in Folienformen. Dieser Artikel erklärt, wie man ein Bild, das zur Präsentationsbildsammlung hinzugefügt wurde, mit verschiedenen Ansätzen ersetzt.

{{% /alert %}} 
## **Ersetzen von Bildern in der Präsentationsbildsammlung**
Aspose.Slides für Java bietet einfache API-Methoden zum Ersetzen der Bilder in der Präsentationsbildsammlung. Bitte folgen Sie den folgenden Schritten:

1. Laden Sie die Präsentationsdatei mit dem Bild darin unter Verwendung der Presentation-Klasse.
1. Laden Sie ein Bild aus einer Datei in ein Byte-Array.
1. Ersetzen Sie das Zielbild durch das neue Bild im Byte-Array.
1. Im zweiten Ansatz laden Sie das Bild in ein Image-Objekt und ersetzen das Zielbild durch das geladene Bild.
1. Im dritten Ansatz ersetzen Sie das Bild durch ein bereits hinzugefügtes Bild in der Präsentationsbildsammlung.
1. Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

```java
// Präsentation instanziieren
Presentation presentation = new Presentation("presentation.pptx");

// der erste Weg
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

// der zweite Weg
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

// der dritte Weg
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

// Präsentation speichern
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```