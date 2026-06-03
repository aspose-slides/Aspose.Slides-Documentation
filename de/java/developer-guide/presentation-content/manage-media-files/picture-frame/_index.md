---
title: Verwalten von Bildrahmen in Präsentationen mit Java
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/java/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design der Folien."
---
## **Einleitung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose stellt kostenlose Konverter bereit—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

## **Erstellen eines Bildrahmens**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Erstellen Sie ein [IPPImage]()‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IImageCollection) hinzufügen, das dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/PictureFrame) basierend auf der Bildbreite und -höhe, über die Methode `AddPictureFrame`, die vom Form‑Objekt im referenzierten Folien‑Objekt bereitgestellt wird.
6. Fügen Sie dem Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser