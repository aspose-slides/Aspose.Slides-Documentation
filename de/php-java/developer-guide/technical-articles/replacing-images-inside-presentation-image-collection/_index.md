---
title: Ersetzen von Bildern in der Präsentationsbildsammlung
type: docs
weight: 80
url: /de/php-java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java ermöglicht es, Bilder in Folienformen zu ersetzen. Dieser Artikel erklärt, wie man ein Bild in der Präsentationsbildsammlung mit verschiedenen Ansätzen ersetzen kann.

{{% /alert %}} 
## **Bild in der Präsentationsbildsammlung ersetzen**
Aspose.Slides für PHP über Java bietet einfache API-Methoden zum Ersetzen von Bildern in der Präsentationsbildsammlung. Bitte folgen Sie den untenstehenden Schritten:

1. Laden Sie die Präsentationsdatei mit dem Bild darin mithilfe der Klasse Presentation.
1. Laden Sie ein Bild aus einer Datei in ein Byte-Array.
1. Ersetzen Sie das Zielbild durch das neue Bild im Byte-Array.
1. Im zweiten Ansatz laden Sie das Bild in ein Image-Objekt und ersetzen das Zielbild durch das geladene Bild.
1. Im dritten Ansatz ersetzen Sie das Bild durch ein bereits hinzugefügtes Bild in der Präsentationsbildsammlung.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplaceImage-ReplaceImage.java" >}}