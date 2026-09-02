---
title: Optimierung der Bildverwaltung in Präsentationen für Android
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/androidjava/image/
keywords:
- Bild hinzufügen
- Grafik hinzufügen
- Bild ersetzen
- Bildsammlung
- Bildrahmen
- Verknüpftes Bild
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- SVG zu Formen
- Externe SVG-Ressourcen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java hinzufügen, wiederverwenden, verknüpfen, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides for Android via Java bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, es als Folienhintergrund verwenden, zu einem externen Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalte in editierbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Für Zuschneiden, Transparenz, Effekte, Dehnung und andere Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, siehe [Bildrahmen](/slides/de/androidjava/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind jedoch nicht austauschbar:

- Die [presentation image collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagecollection/) speichert Bildressourcen, die von der Präsentation verwendet werden. Verwenden Sie [ImageCollection.addImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imagecollection/), um Bilddaten hinzuzufügen und eine [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)-Ressource zu erhalten.
- Ein [picture frame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einer Masterfolie anzeigt. Verwenden Sie [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erstellt editierbare Folienformen. Nach der Konversion wird der Inhalt nicht mehr als eine Bildressource verwaltet.

Ein typischer Arbeitsablauf ist daher: Bilddaten zur Bildsammlung hinzufügen, ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) erhalten und diese Ressource dann in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, laden Sie die Datei, fügen Sie sie zur Bildsammlung hinzu und erstellen Sie einen Bildrahmen, der das zurückgegebene `IPPImage` verwendet.

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

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie die Bytes herunter, fügen Sie sie zur Bildsammlung der Präsentation hinzu und verwenden Sie die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

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

In langlaufenden Anwendungen sollten Sie einen HTTP‑Client oder eine Verbindungs‑Management‑Strategie wiederverwenden, die für die Anwendung geeignet ist, anstatt wiederholt unnötige Netzwerk‑Infrastruktur zu erstellen. Validieren Sie außerdem Remote‑URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) erneut, wenn Sie weitere Bildrahmen erstellen. Dies vermeidet das wiederholte Laden derselben Quelldaten und macht die Beziehung zwischen der gemeinsam genutzten Bildressource und ihren Verwendungen explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, wie z. B. ein Unternehmenslogo, sollten Sie in Betracht ziehen, den Bildrahmen auf einem [Folienmaster](/slides/de/androidjava/slide-master/) oder Layout zu platzieren, anstatt in jeder Folie eine entsprechende Form hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild den Folienhintergrund abdecken und nicht wie ein normales Folienobjekt bearbeitet werden soll.

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

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Präsentationshintergrund](/slides/de/androidjava/presentation-background/).

## **Eingebettete Bilder und verknüpfte Bilder**

Eingebettete und verknüpfte Bilder haben unterschiedliche Portabilitäts‑ und Dateigrößen‑Abwägungen:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße enthält die Bilddaten.
- **Verknüpftes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Dateigröße reduzieren, aber die externe Ressource muss beim Öffnen oder Rendern der Präsentation erreichbar bleiben.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/) zugewiesen wird, anstatt die Bilddaten einzubetten.

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

## **Arbeiten mit SVG-Bildern**

SVG ist ein Vektorformat und kann nützlich für Symbole, Diagramme und andere Grafiken sein, die ohne denselben Detailverlust wie Rasterbilder skalieren sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für editierbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgimage/), fügen Sie es zur Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

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

Ein SVG kann externe Bilder, Stylesheets oder Schriftarten referenzieren. Für diese Fälle stellt [SvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgimage/) Konstruktoren bereit, die einen [IExternalResourceResolver](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iexternalresourceresolver/) und eine Basis‑URI akzeptieren. Der Resolver kann eine relative URI in eine erlaubte absolute URI umwandeln und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides bereit, schreibt das SVG jedoch nicht in ein eigenständiges Dokument um. Wenn das SVG portabel bleiben muss, betten Sie die benötigten Ressourcen im SVG selbst ein, zum Beispiel indem Sie `data:`‑URIs für verknüpfte Bilder verwenden.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, beschränken Sie die Schemas, Dateipfade und Hosts, auf die der Resolver zugreifen kann. Netzwerk‑Resolver sollten zudem Zeitlimits, Beschränkungen der Antwortgröße und Inhaltsvalidierung anwenden.

### **SVG in editierbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe editierbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die Überladung [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/) , die ein [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/) akzeptiert, um die Konvertierung durchzuführen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie die SVG‑zu‑Formen‑Konvertierung, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist es einfacher, es als Bild beizubehalten, und es werden nicht viele separate Formen erzeugt.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [IPPImage.replaceImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

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

Wenn mehrere Bildrahmen, Hintergründe, Master oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Wenn nur ein Bildrahmen geändert werden soll, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die gemeinsam genutzte Ressource zu ersetzen.

`replaceImage` bietet außerdem Überladungen, die ein Byte‑Array oder ein anderes [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) akzeptieren.

## **Praktische Leitlinien zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig groß machen. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, wiederverwenden Sie nach Möglichkeit gemeinsam genutzte Bildressourcen und vermeiden Sie das Einbetten mehrfacher Kopien derselben hochauflösenden Grafik.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) Bilddaten gemäß der ausgewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und nicht das Management der Bildsammlung, siehe daher [Bildrahmen](/slides/de/androidjava/picture-frame/) für verwandte Formatierungsoperationen.

### **Wahl zwischen eingebettetem und verknüpftem Inhalt**

Einbetten macht die Präsentation portabel, da alle benötigten Bilddaten mit der Datei transportiert werden. Verknüpfen kann die Dateigröße reduzieren, führt jedoch eine externe Abhängigkeit ein. Verwenden Sie Verknüpfungen nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsames Branding wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen sie erneut. Wenn die Grafik zum Design der Präsentation und nicht zum Folieninhalt gehört, platzieren Sie sie auf einem Master oder Layout, sodass sie von den entsprechenden Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Wenn möglich, betten Sie erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG in Formen nur, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Die moderne plattformübergreifende Image‑API verwenden**

Für neuen Android‑via‑Java‑Code verwenden Sie die Aspose.Slides [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/)‑ und [Images](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/images/)‑APIs anstelle der veralteten öffentlichen API, die auf `android.graphics.Bitmap` basiert. Siehe [Modern API](/slides/de/androidjava/modern-api/) für Migrationshinweise.

WMF und EMF erfordern besondere Beachtung. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) übergeben werden, konvertiert [ImageCollection.addImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imagecollection/) die Metadatei vor dem Einfügen in eine Raster‑PNG‑Darstellung. Wenn die Erhaltung der Metadatei wichtig ist, verwenden Sie stattdessen die strombasierte Überladung von [ImageCollection.addImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imagecollection/). Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Was ist der beste Weg, das gleiche Logo überall zu ersetzen?**

Wenn das Logo bereits als eine Bildressource geteilt wird, ersetzen Sie diese Ressource mit [IPPImage.replaceImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/). Für branding‑weite Präsentationen kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verknüpftes Bild auf einem anderen Computer?**

Ein verknüpftes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreicht werden kann, ist das verknüpfte Bild nicht verfügbar. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/); die resultierende Gruppe enthält editierbare Folienformen anstelle eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Wiederverwenden Sie gemeinsam genutzte Bildressourcen, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder bei Bedarf, platzieren Sie wiederholtes Branding auf Mastern oder Layouts und verwenden Sie verknüpfte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.