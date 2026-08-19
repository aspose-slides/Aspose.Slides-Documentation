---
title: Optimieren der Bildverwaltung in Präsentationen mit JavaScript
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/nodejs-java/image/
keywords:
- Bild hinzufügen
- Bild hinzufügen
- Bild ersetzen
- Bildsammlung
- Bildrahmen
- Verknüpftes Bild
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- SVG zu Formen
- externe SVG-Ressourcen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js über Java hinzufügen, wiederverwenden, verknüpfen, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für Node.js über Java bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, als Folienhintergrund verwenden, zu einem externen Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalte in editierbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Für Zuschneiden, Transparenz, Effekte, Dehnung und weitere Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, siehe [Picture Frame](/slides/de/nodejs-java/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind jedoch nicht austauschbar:

- Die [presentation image collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/) speichert Bildressourcen, die von der Präsentation verwendet werden. Verwenden Sie [ImageCollection.addImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/), um Bilddaten hinzuzufügen und eine [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)-Ressource zu erhalten.
- Ein [picture frame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einer Master‑Folie anzeigt. Verwenden Sie [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [PPImage.replaceImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Die Konvertierung eines SVG in Formen erzeugt editierbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als eine Bildressource verwaltet.

Ein typischer Arbeitsablauf ist daher: Bilddaten zur ImageCollection hinzufügen, ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) erhalten und diese Ressource dann in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, laden Sie die Datei, fügen sie der ImageCollection hinzu und erstellen einen Bildrahmen, der die zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)-Ressource verwendet.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das auf diese Weise hinzugefügte Bild ist in die Präsentation eingebettet, sodass die resultierende Datei nicht von der Verfügbarkeit der ursprünglichen Bilddatei abhängt.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen sie der Präsentations‑ImageCollection hinzu und verwenden die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

In langfristig laufenden Anwendungen sollten Sie einen HTTP‑Client oder eine Verbindungs‑Management‑Strategie wiederverwenden, die für die Anwendung geeignet ist, anstatt wiederholt unnötige Netzwerk‑Infrastruktur zu erzeugen. Validieren Sie außerdem Remote‑URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) erneut, wenn weitere Bildrahmen erstellt werden. So vermeiden Sie das wiederholte Laden derselben Quelldaten und machen die Beziehung zwischen der gemeinsam genutzten Bildressource und ihren Verwendungen explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, z. B. ein Firmenlogo, sollten Sie den Bildrahmen auf einem [slide master](/slides/de/nodejs-java/slide-master/) oder Layout platzieren, anstatt in jeder Folie eine entsprechende Form hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild den Folienhintergrund abdecken soll und nicht wie ein normales Folienobjekt manipuliert werden soll.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Presentation Background](/slides/de/nodejs-java/presentation-background/).

## **Eingebettete und verlinkte Bilder**

Eingebettete und verlinkte Bilder weisen unterschiedliche Portabilitäts‑ und Dateigrößen‑Abwägungen auf:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, jedoch enthält die Dateigröße die Bilddaten.
- **Verlinktes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dadurch kann die Präsentationsgröße reduziert werden, aber die externe Ressource muss beim Öffnen oder Rendern der Präsentation zugänglich bleiben.

Ein verlinktes Bild kann erstellt werden, indem der externe Pfad oder die URL über [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie verlinkte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Mit SVG‑Bildern arbeiten**

SVG ist ein Vektorformat und eignet sich daher für Symbole, Diagramme und andere Grafiken, die ohne denselben Detailverlust wie Rasterbilder skalieren sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für editierbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/), fügen Sie es der ImageCollection hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑Dateien mit externen Ressourcen**

Ein SVG kann externe Bilder, Stylesheets oder Schriftarten referenzieren. Für diese Fälle bietet [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) Konstruktoren, die einen [ExternalResourceResolver](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/externalresourceresolver/) und einen Basis‑URI akzeptieren. Der Resolver kann einen relativen URI in einen zulässigen absoluten URI umwandeln und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides bereit, schreibt das SVG jedoch nicht in ein eigenständiges Dokument um. Wenn das SVG portabel bleiben muss, betten Sie die erforderlichen Ressourcen im SVG selbst ein, z. B. durch Verwendung von `data:`‑URIs für verlinkte Bilder.

Stammen SVG‑Dateien aus nicht vertrauenswürdigen Quellen, beschränken Sie die Schemas, Dateipfade und Hosts, auf die der Resolver zugreifen darf. Netzwerk‑Resolver sollten zudem Zeitüberschreitungen, Begrenzungen der Antwortgröße und Inhaltsvalidierungen anwenden.

### **SVG in editierbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe editierbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die Überladung [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/), die ein SVG‑Bild akzeptiert, um die Konvertierung durchzuführen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie die SVG‑zu‑Formen‑Konvertierung, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden sollen. Wenn das SVG nur angezeigt werden muss, ist das Beibehalten als Bild einfacher und vermeidet die Erstellung vieler separater Formen.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [PPImage.replaceImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn mehrere Bildrahmen, Hintergründe, Master‑Folien oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Soll nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die gemeinsam genutzte Ressource zu ersetzen.

[PPImage.replaceImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) bietet außerdem Überladungen, die ein Byte‑Array oder ein anderes [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) akzeptieren.

## **Praktische Anleitung zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig groß machen. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, wiederverwenden Sie gemeinsam genutzte Bildressourcen, wo möglich, und vermeiden Sie das Einbetten mehrfacher Kopien derselben Bilddatei in voller Auflösung.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) Bilddaten basierend auf der gewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und keine Verwaltung der ImageCollection, siehe daher [Picture Frame](/slides/de/nodejs-java/picture-frame/) für zugehörige Formatierungs‑Operationen.

### **Auswahl zwischen eingebettetem und verlinktem Inhalt**

Einbetten macht die Präsentation portabel, da alle erforderlichen Bilddaten mit der Datei mitgeliefert werden. Verlinken kann die Dateigröße reduzieren, führt jedoch eine externe Abhängigkeit ein. Verwenden Sie Links nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsames Branding wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen sie wieder. Gehört die Grafik zum Design der Präsentation und nicht zum Folieninhalt, platzieren Sie sie auf einem Master oder Layout, sodass sie von den entsprechenden Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG ist leichter zu verschieben und konsistent zu rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Betten Sie nach Möglichkeit erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG zu Formen nur, wenn einzelne Vektorelemente bearbeitet werden müssen.

### **Die moderne plattformübergreifende Image‑API verwenden**

Für neuen Node.js‑via‑Java‑Code verwenden Sie die Aspose.Slides‑APIs [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) und [Images](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/images/) anstelle der veralteten öffentlichen API, die auf `java.awt.image.BufferedImage` basiert. Siehe [Modern API](/slides/de/nodejs-java/modern-api/) für Migrationshinweise.

WMF‑ und EMF‑Formate erfordern besondere Berücksichtigung. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) übergeben werden, konvertiert [ImageCollection.addImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/) die Metadatei vor dem Einfügen in eine rasterbasierte PNG‑Darstellung. Wenn das Beibehalten der Metadatei wichtig ist, verwenden Sie stattdessen eine stream‑basierte Überladung von [ImageCollection.addImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/). Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Arbeitsablauf und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der ImageCollection und einem Bildrahmen?**

Die ImageCollection speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Was ist der beste Weg, dasselbe Logo überall zu ersetzen?**

Wenn das Logo bereits als eine Bildressource gemeinsam genutzt wird, ersetzen Sie diese Ressource mit [PPImage.replaceImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/). Für eine Präsentations‑weite Markenbildung kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verlinktes Bild auf einem anderen Computer?**

Ein verlinktes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, kann das verlinkte Bild nicht verfügbar sein. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/); die resultierende Gruppe enthält editierbare Folienformen anstelle eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern klein halten?**

Wiederverwenden Sie gemeinsam genutzte Bildressourcen, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder, wenn es passt, halten Sie wiederholtes Branding auf Mastern oder Layouts und verwenden Sie verlinkte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.