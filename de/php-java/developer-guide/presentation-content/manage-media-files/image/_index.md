---
title: Optimieren der Bildverwaltung in Präsentationen mit PHP
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/php-java/image/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG‑Bilder in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für PHP über Java hinzufügen, wiederverwenden, verknüpfen, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für PHP über Java bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, als Folienhintergrund verwenden, auf ein externes Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalte in editierbare Formen umwandeln.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnung und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Bildrahmen](/slides/de/php-java/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in enger Beziehung, sind jedoch nicht austauschbar:

- Die [Präsentations‑Bildsammlung](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) speichert Bildressourcen, die in der Präsentation verwendet werden. Verwenden Sie [ImageCollection::addImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/), um Bilddaten hinzuzufügen und eine [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)-Ressource zu erhalten.
- Ein [Bildrahmen](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einem Master anzeigt. Verwenden Sie [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [PPImage::replaceImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erzeugt editierbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als ein einzelnes Bildressourcen‑Objekt verwaltet.

Ein typischer Workflow lautet daher: Bilddaten zur Bildsammlung hinzufügen, ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) erhalten und diese Ressource dann in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, laden Sie die Datei, fügen sie der Bildsammlung hinzu und erstellen einen Bildrahmen, der das zurückgegebene `PPImage` verwendet.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das auf diese Weise hinzugefügte Bild ist in der Präsentation eingebettet, sodass die resultierende Datei nicht davon abhängt, dass die Originalbilddatei weiterhin verfügbar ist.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen sie der Präsentations‑Bildsammlung hinzu und verwenden die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In langlaufenden Anwendungen sollten Sie einen HTTP‑Client oder eine Verbindungs‑Management‑Strategie wiederverwenden, die zur Anwendung passt, anstatt wiederholt unnötige Netzwerk‑Infrastruktur zu erstellen. Validieren Sie außerdem Remote‑URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Falls dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal der Präsentation hinzu und verwenden das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) bei der Erstellung weiterer Bildrahmen. Dadurch wird das wiederholte Laden derselben Quelldaten vermieden und die Beziehung zwischen der geteilten Bildressource und ihren Verwendungen wird explizit.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, z. B. ein Firmenlogo, sollten Sie den Bildrahmen auf einem [Folien‑Master](/slides/de/php-java/slide-master/) oder Layout platzieren, anstatt auf jeder Folie ein äquivalentes Objekt hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild den gesamten Folienhintergrund abdecken und nicht wie ein normales Folienobjekt manipuliert werden soll.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Weitere Optionen für Hintergründe, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Präsentations‑Hintergrund](/slides/de/php-java/presentation-background/).

## **Eingebettete Bilder und verlinkte Bilder**

Eingebettete und verlinkte Bilder haben unterschiedliche Portabilitäts‑ und Dateigrößen‑Kompromisse:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße enthält die Bilddaten.
- **Verlinktes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Präsentationsgröße reduzieren, erfordert jedoch, dass die externe Ressource beim Öffnen oder Rendern der Präsentation erreichbar bleibt.

Ein verlinktes Bild kann erstellt werden, indem der externe Pfad oder die URL über [Picture::setLinkPathLong](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verwenden Sie verlinkte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Arbeiten mit SVG‑Bildern**

SVG ist ein Vektorformat und daher nützlich für Symbole, Diagramme und andere Grafiken, die skalieren sollen, ohne Details wie bei Rasterbildern zu verlieren. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für editierbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/), fügen Sie es der Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG‑Dateien mit externen Ressourcen**

Ein SVG kann externe Bilder, Stylesheets oder Schriften referenzieren. Für diese Fälle stellt [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) Konstruktoren bereit, die einen [ExternalResourceResolver](https://reference.aspose.com/slides/de/php-java/aspose.slides/externalresourceresolver/) und eine Basis‑URI akzeptieren. Der Resolver kann eine relative URI auf eine zulässige absolute URI abbilden und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides bereit, überschreibt das SVG jedoch nicht zu einem eigenständigen Dokument. Sollte das SVG portabel bleiben, betten Sie die erforderlichen Ressourcen im SVG selbst ein, zum Beispiel über `data:`‑URIs für verlinkte Bilder.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, beschränken Sie die Schemas, Dateipfade und Hosts, zu denen der Resolver Zugriff hat. Netzwerk‑Resolver sollten außerdem Zeitlimits, Antwortgrößen‑Beschränkungen und Inhaltsvalidierung anwenden.

### **SVG in editierbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe editierbarer Folienformen umwandeln, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup-Menü](img_01_01.png)

Verwenden Sie die [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addgroupshape/)-Überladung, die ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) akzeptiert, um die Konvertierung durchzuführen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nutzen Sie die SVG‑zu‑Formen‑Konvertierung, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist das Beibehalten als Bild einfacher und vermeidet die Erstellung vieler separater Formen.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [PPImage::replaceImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Falls mehrere Bildrahmen, Hintergründe, Master oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Soll nur ein einzelner Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die geteilte Ressource zu ersetzen.

`PPImage::replaceImage` bietet zudem Überladungen, die ein Byte‑Array oder ein anderes [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) akzeptieren.

## **Praktische Empfehlungen zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig vergrößern. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, nutzen Sie nach Möglichkeit geteilte Bildressourcen und vermeiden Sie das Einbetten mehrfacher Kopien derselben hochauflösenden Grafik.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [PictureFillFormat::compressImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) die Bilddaten gemäß der ausgewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung, nicht das Management der Bildsammlung, siehe also [Bildrahmen](/slides/de/php-java/picture-frame/) für verwandte Formatierungs‑Operationen.

### **Zwischen eingebettetem und verlinktem Inhalt wählen**

Einbetten macht die Präsentation portabel, weil alle erforderlichen Bilddaten mit der Datei reisen. Verlinken kann die Dateigröße reduzieren, führt jedoch zu einer externen Abhängigkeit. Verwenden Sie Links nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsame Markenbilder wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen Sie sie wieder. Wenn die Grafik zum Design der Präsentation und nicht zum Folieninhalt gehört, platzieren Sie sie auf einem Master oder Layout, sodass sie von den entsprechenden Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerk‑Ressourcen abhängt. Wenn möglich, betten Sie erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG in Formen nur, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Die moderne plattformübergreifende Bild‑API verwenden**

Für neuen PHP‑via‑Java‑Code verwenden Sie die Aspose.Slides [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/)‑ und [Images](https://reference.aspose.com/slides/de/php-java/aspose.slides/images/)‑APIs anstelle der veralteten öffentlichen API, die auf `java.awt.image.BufferedImage` basierte. Siehe [Moderne API](/slides/de/php-java/modern-api/) für Migrationshinweise.

WMF und EMF erfordern besondere Überlegungen. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) weitergeleitet werden, konvertiert [ImageCollection::addImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/) die Metadatei vor dem Einfügen in eine Raster‑PNG‑Darstellung. Wenn das Beibehalten der Metadaten wichtig ist, verwenden Sie stattdessen die stream‑basierte [ImageCollection::addImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/)-Überladung. Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separates Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Wie ersetze ich dasselbe Logo überall am besten?**

Wenn das Logo bereits als eine Bildressource geteilt wird, ersetzen Sie diese Ressource mit [PPImage::replaceImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/). Für branding‑weite Änderungen kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verlinktes Bild auf einem anderen Computer?**

Ein verlinktes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, ist das Bild nicht verfügbar. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addgroupshape/); die resultierende Gruppe enthält editierbare Folienformen statt eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Wiederverwenden Sie geteilte Bildressourcen, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder, platzieren Sie wiederholtes Branding auf Mastern oder Layouts und verwenden Sie verlinkte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.