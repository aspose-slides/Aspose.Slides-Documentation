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
- Formenhintergrund
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java extrahieren - schnelle, code-freundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) hinzugefügt, was eine Sammlung von [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) Objekten ist.

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchgehen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. 
```php

```


## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Formtransformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [Bildsammlung](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/), was die ursprünglichen Pixel ohne Zuschneiden oder Styling‑Effekte bedeutet. Der Ablauf geht durch die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) Objekte, die die Rohdaten speichern.

**Besteht das Risiko, beim gleichzeitigen Speichern vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles ungefiltert speichern. Die [Bildsammlung](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) einer Präsentation kann identische Binärdaten enthalten, die von verschiedenen Formen oder Folien referenziert werden. Um Duplikate zu vermeiden, vergleichen Sie Hashes, Größen oder Inhalte der extrahierten Daten, bevor Sie schreiben.

**Wie kann ich bestimmen, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverknüpfungen von [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung manuell eine Zuordnung: Wann immer Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, wie z. B. angehängte Dokumente?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und dann dessen Inhalt mit separaten Werkzeugen analysieren. Präsentations‑Bildformen arbeiten über [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.