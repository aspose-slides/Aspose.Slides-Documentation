---
title: Ersetzen von Bildern in der Präsentationsbildsammlung
type: docs
weight: 90
url: /de/cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides für C++ ermöglicht es Ihnen, die in Folienformen hinzugefügten Bilder zu ersetzen. In diesem Artikel erfahren Sie, wie Sie das Bild in der Präsentationsbildsammlung auf verschiedene Weise ersetzen können.

{{% /alert %}} 
## **Ersetzen des Bildes in einer Präsentationsbildsammlung**
Aspose.Slides für C++ bietet eine einfache API-Methode, mit der Sie das Bild in einer Präsentationsbildsammlung wie folgt ersetzen können:

1. Laden Sie die Präsentationsdatei mit einem Bild darin mithilfe der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Laden Sie ein Bild aus einer Datei in ein Byte-Array.
1. Verwenden Sie eine dieser Methoden:
   - Erste Methode: Ersetzen Sie das Zielbild durch das neue Bild im Byte-Array.
   - Zweite Methode: Laden Sie das Bild in ein [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) Objekt und ersetzen Sie das Zielbild durch das geladene Bild.
   - Dritte Methode: Ersetzen Sie das Bild durch das bereits hinzugefügte Bild in der Präsentationsbildsammlung.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Beispielcode zeigt Ihnen, wie Sie das Bild in einer Präsentationsbildsammlung ersetzen können:

``` cpp
// Instanz der Präsentation erstellen
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// Die erste Methode
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// Die zweite Methode
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Die dritte Methode
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Präsentation speichern
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```