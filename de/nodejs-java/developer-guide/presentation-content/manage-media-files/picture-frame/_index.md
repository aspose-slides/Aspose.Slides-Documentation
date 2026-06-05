---
title: Bildrahmen in Präsentationen mit JavaScript verwalten
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/nodejs-java/picture-frame/
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
- Beschnittbereich
- StretchOff‑Eigenschaft
- Bildrahmenformatierung
- Bildrahmen‑Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Foliendesign."
---
## **Einführung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Erstellen Sie ein `PPImage`-Objekt, indem Sie ein Bild zur [ImagesCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Ausfüllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes, über die Methode `addPictureFrame`, die vom Form‑Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie Sie einen Bildrahmen erstellen:

```javascript
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Instanziert die Image-Klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Fügt einen Bildrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bildrahmen ermöglichen es, schnell Präsentationsfolien basierend auf Bildern zu erstellen. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Eingabe‑/Ausgabe‑Operationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren.

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PPImage)-Objekt, indem Sie ein Bild zur [ImagesCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Ausfüllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser JavaScript‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:

```javascript
// Instanziert die Presentation-Klasse, die das PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Instanziert die Image-Klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Setzt relative Skalierung von Breite und Höhe
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PictureFrame)-Objekten extrahieren und sie im PNG-, JPG‑ und anderen Formaten speichern. Das nachstehende Codebeispiel demonstriert, wie ein Bild aus dem