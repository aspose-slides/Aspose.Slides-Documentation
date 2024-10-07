---
title: Ersetzen von Bildern in der Präsentation Bildsammlung
type: docs
weight: 110
url: /net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides für .NET ermöglicht es, die in Folienformen hinzugefügten Bilder zu ersetzen. Dieser Artikel erklärt, wie man das in der Präsentation Bildsammlung hinzugefügte Bild mit verschiedenen Ansätzen ersetzt.

{{% /alert %}} 
## **Bild in der Präsentation Bildsammlung ersetzen**
Aspose.Slides für .NET bietet einfache API-Methoden zum Ersetzen der Bilder in der Präsentation Bildsammlung. Bitte folgen Sie den nachstehenden Schritten:

1. Laden Sie die Präsentationsdatei mit dem Bild darin, indem Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse verwenden.
1. Laden Sie ein Bild aus einer Datei in ein Byte-Array.
1. Ersetzen Sie das Zielbild durch das neue Bild im Byte-Array.
1. Beim zweiten Ansatz laden Sie das Bild in ein Image-Objekt und ersetzen das Zielbild durch das geladene Bild.
1. Beim dritten Ansatz ersetzen Sie das Bild durch ein bereits hinzugefügtes Bild in der Präsentation Bildsammlung.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```c#
//Instanziieren Sie die Präsentation
using Presentation presentation = new Presentation("presentation.pptx");

//der erste Weg
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//der zweite Weg
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//der dritte Weg
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//Präsentation speichern
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```