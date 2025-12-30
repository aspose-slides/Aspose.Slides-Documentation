---
title: Bilder aus Formen einer Präsentation extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/php-java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- Folienhintergrund
- Formhintergrund
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java - schnelle, codefreundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/) hinzugefügt, das eine Sammlung von [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) Objekten ist.

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchgehen. Sobald das Bild gefunden oder ermittelt wurde, können Sie es extrahieren und als neue Datei speichern. 
```php

```


## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) der Präsentation, d. h. die Originalpixel ohne Zuschneiden oder Styling‑Effekte. Der Workflow durchläuft die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) Objekte, die die Rohdaten speichern.

**Gibt es das Risiko, beim gleichzeitigen Speichern vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles unkritisch speichern. Die [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) einer Präsentation kann identische Binärdaten enthalten, auf die von verschiedenen Formen oder Folien verwiesen wird. Um Duplikate zu vermeiden, vergleichen Sie vor dem Schreiben Hashes, Größen oder Inhalte der extrahierten Daten.

**Wie kann ich feststellen, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung manuell eine Zuordnung: Wann immer Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, beispielsweise in angehängten Dokumenten?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und anschließend dessen Inhalt mit separaten Werkzeugen analysieren. Präsentations‑Bildformen funktionieren über [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.