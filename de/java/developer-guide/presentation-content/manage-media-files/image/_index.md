---
title: Optimieren der Bildverwaltung in Präsentationen mit Java
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/java/image/
keywords:
- Bild hinzufügen
- Bild einfügen
- Bild ersetzen
- Bilderkollektion
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java hinzufügen, wiederverwenden, verknüpfen, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides for Java bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede davon dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, es als Folienhintergrund verwenden, zu einem externen Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalt in bearbeitbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnung und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Picture Frame](/slides/de/java/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind aber nicht austauschbar:

- Die [presentation image collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagecollection/) speichert von der Präsentation verwendete Bildressourcen. Verwenden Sie [ImageCollection.addImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/imagecollection/), um Bilddaten hinzuzufügen und eine [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)-Ressource zu erhalten.
- Ein [picture frame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einem Master anzeigt. Verwenden Sie [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erstellt bearbeitbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als eine Bildressource verwaltet.

Ein typischer Arbeitsablauf ist daher: Bilddaten zur Bildsammlung hinzufügen, ein [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) erhalten und dann diese Ressource in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, laden Sie die Datei, fügen sie zur Bildsammlung hinzu und erstellen einen Bildrahmen, der das zurückgegebene `IPPImage` verwendet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das auf diese Weise hinzugefügte Bild ist in die Präsentation eingebettet, sodass die resultierende Datei nicht davon abhängt, dass die ursprüngliche Bilddatei weiterhin verfügbar ist.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen sie zur Präsentations‑Bildsammlung hinzu und verwenden die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In langlaufenden Anwendungen sollten Sie einen HTTP‑Client oder eine Verbindungsverwaltungsstrategie wiederverwenden, die für die Anwendung geeignet ist, anstatt wiederholt unnötige Netzwerk‑Infrastruktur zu erstellen. Validieren Sie außerdem Remote‑URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) erneut, wenn Sie weitere Bildrahmen erstellen. Dies verhindert das wiederholte Laden derselben Quelldaten und macht die Beziehung zwischen der geteilten Bildressource und ihrer Verwendung explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, z. B. ein Firmenlogo, sollten Sie in Erwägung ziehen, den Bildrahmen auf einen [slide master](/slides/de/java/slide-master/) oder ein Layout zu setzen, anstatt in jeder Folie eine entsprechende Form hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bild‑Rahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild die Folienhintergrundfläche abdecken und nicht wie ein normales Folienobjekt bearbeitet werden soll.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Presentation Background](/slides/de/java/presentation-background/).

## **Eingebettete Bilder und verknüpfte Bilder**

Eingebettete und verknüpfte Bilder haben unterschiedliche Portabilitäts- und Dateigrößen‑Abwägungen:

- **Embedded image:** Die Bilddaten werden in der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße enthält die Bilddaten.
- **Linked image:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Präsentationsgröße reduzieren, erfordert jedoch, dass die externe Ressource beim Öffnen oder Rendern der Präsentation zugänglich bleibt.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidespicture/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie verknüpfte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Mit SVG‑Bildern arbeiten**

SVG ist ein Vektorformat und eignet sich daher für Symbole, Diagramme und andere Grafiken, die ohne denselben Detailverlust wie Rasterbilder skalieren sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für bearbeitbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgimage/), fügen Sie es zur Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑Dateien mit externen Ressourcen**

Ein SVG kann externe Bilder, Stylesheets oder Schriftarten referenzieren. Für diese Fälle stellt [SvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgimage/) Konstruktoren bereit, die einen [IExternalResourceResolver](https://reference.aspose.com/slides/de/java/com.aspose.slides/iexternalresourceresolver/) und eine Basis‑URI akzeptieren. Der Resolver kann eine relative URI in eine zulässige absolute URI übersetzen und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides zur Verfügung, rewritet das SVG jedoch nicht in ein eigenständiges Dokument. Wenn das SVG portabel bleiben muss, betten Sie die erforderlichen Ressourcen im SVG selbst ein, beispielsweise indem Sie `data:`‑URIs für verknüpfte Bilder verwenden.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, schränken Sie die Schemas, Dateipfade und Hosts ein, auf die der Resolver zugreifen darf. Netzwerk‑Resolver sollten zudem Zeitüberschreitungen, Begrenzungen der Antwortgröße und Inhaltsvalidierung anwenden.

### **SVG in bearbeitbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe bearbeitbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die Überladung von [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/), die ein [ISvgImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgimage/) akzeptiert, um die Konvertierung durchzuführen.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie die SVG‑zu‑Formen‑Konvertierung, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist es einfacher, es als Bild zu belassen, und es werden keine vielen separaten Formen erstellt.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [IPPImage.replaceImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn mehrere Bildrahmen, Hintergründe, Master oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Soll nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die geteilte Ressource zu ersetzen.

`replaceImage` bietet außerdem Überladungen, die ein Byte‑Array oder ein anderes [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) akzeptieren.

## **Praktische Bildverwaltungs‑Richtlinien**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig vergrößern. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, nutzen Sie nach Möglichkeit gemeinsam genutzte Bildressourcen wieder und vermeiden Sie das Einbetten mehrfacher Kopien derselben hochauflösenden Grafik.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipicturefillformat/) Bilddaten entsprechend der ausgewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und keine Verwaltung der Bildsammlung, daher siehe [Picture Frame](/slides/de/java/picture-frame/) für verwandte Formatierungs‑Operationen.

### **Wählen Sie zwischen eingebettetem und verknüpftem Inhalt**

Einbetten macht die Präsentation portabel, da alle erforderlichen Bilddaten mit der Datei mitgeliefert werden. Verknüpfen kann die Dateigröße reduzieren, führt jedoch eine externe Abhängigkeit ein. Verwenden Sie Verknüpfungen nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsame Markenbilder wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen sie erneut. Gehört die Grafik zum Design der Präsentation und nicht zum Folieninhalt, platzieren Sie sie auf einem Master oder Layout, damit sie von den entsprechenden Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Betten Sie nach Möglichkeit die erforderlichen Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG in Formen nur, wenn einzelne Vektorelemente bearbeitet werden müssen.

### **Verwenden Sie die moderne plattformübergreifende Image‑API**

Für neuen Java‑Code verwenden Sie die Aspose.Slides‑[IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑ und [Images](https://reference.aspose.com/slides/de/java/com.aspose.slides/images/)‑APIs anstelle der veralteten öffentlichen API, die auf `java.awt.image.BufferedImage` basiert. Siehe [Modern API](/slides/de/java/modern-api/) für Migrationshinweise.

WMF und EMF erfordern besondere Berücksichtigung. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) übergeben werden, konvertiert [ImageCollection.addImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/imagecollection/) die Metadatei vor dem Einfügen in eine Raster‑PNG‑Darstellung. Wenn die Erhaltung der Metadatei wichtig ist, verwenden Sie stattdessen eine strombasierte Überladung von [ImageCollection.addImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/imagecollection/). Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Was ist der beste Weg, dasselbe Logo überall zu ersetzen?**

Wenn das Logo bereits als eine Bildressource geteilt wird, ersetzen Sie diese Ressource mit [IPPImage.replaceImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/). Für eine markenweite Gestaltung kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verknüpftes Bild auf einem anderen Computer?**

Ein verknüpftes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, kann das verknüpfte Bild nicht verfügbar sein. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/); die resultierende Gruppe enthält bearbeitbare Folienformen statt eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Verwenden Sie gemeinsam genutzte Bildressourcen wieder, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder bei Bedarf, halten Sie wiederholte Markenbilder auf Mastern oder Layouts und nutzen Sie verknüpfte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.