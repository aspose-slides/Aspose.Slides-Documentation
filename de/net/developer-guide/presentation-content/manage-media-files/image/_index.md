---
title: Optimieren der Bildverwaltung in Präsentationen in .NET
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/net/image/
keywords:
- Bild hinzufügen
- Bild einfügen
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET hinzufügen, wiederverwenden, verlinken, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für .NET bietet mehrere Möglichkeiten, mit Bildern zu arbeiten, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, als Folienhintergrund verwenden, auf ein externes Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG‑Inhalte in bearbeitbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung innerhalb einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnen und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Bildrahmen](/slides/de/net/picture-frame/).

## **Verstehen des Bildmodells**

Die folgenden API‑Konzepte stehen in engem Zusammenhang, sind jedoch nicht austauschbar:

- Die [Präsentations‑Bildsammlung](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection/) speichert Bildressourcen, die von der Präsentation verwendet werden. Verwenden Sie [ImageCollection.AddImage](https://reference.aspose.com/slides/de/net/aspose.slides/imagecollection/addimage/), um Bilddaten hinzuzufügen und eine [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)-Ressource zu erhalten.
- Ein [Bildrahmen](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einem Master anzeigt. Verwenden Sie [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Er verhält sich daher nicht wie ein Bildrahmen.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/replaceimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Die Konvertierung eines SVG in Formen erzeugt bearbeitbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als ein einzelnes Bild verwaltet.

Ein typischer Arbeitsablauf lautet daher: Bilddaten zur Bildsammlung hinzufügen, ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) erhalten und diese Ressource dann in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, lesen Sie die Datei, fügen Sie deren Daten zur Bildsammlung hinzu und erstellen Sie einen Bildrahmen, der das zurückgegebene `IPPImage` verwendet.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Das auf diese Weise hinzugefügte Bild ist in der Präsentation eingebettet, sodass die resultierende Datei nicht von der Verfügbarkeit der Originalbilddatei abhängt.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes mit `HttpClient` herunter, fügen Sie sie zur Präsentations‑Bildsammlung hinzu und verwenden Sie die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

In langlaufenden Anwendungen sollten Sie `HttpClient` wiederverwenden, anstatt für jede Anforderung eine neue Instanz zu erstellen. Validieren Sie außerdem entfernte URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist.

## **Bilder über Folien hinweg wiederverwenden**

Wenn dasselbe Bild mehr als einmal benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) beim Erstellen weiterer Bildrahmen. So vermeiden Sie wiederholtes Laden derselben Quelldaten und machen die Beziehung zwischen der gemeinsamen Bildressource und ihren Verwendungen eindeutig.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, beispielsweise ein Firmenlogo, sollten Sie den Bildrahmen auf einem [Folien‑Master](/slides/de/net/slide-master/) oder Layout platzieren, anstatt äquivalente Formen jeder Folie hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Das ist nützlich, wenn das Bild den Folienhintergrund vollständig abdecken und nicht wie ein normales Folienobjekt manipuliert werden soll.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Präsentations‑Hintergrund](/slides/de/net/presentation-background/).

## **Eingebettete Bilder und verknüpfte Bilder**

Eingebettete und verknüpfte Bilder haben unterschiedliche Portabilitäts‑ und Dateigrößen‑Kompromisse:

- **Eingebettetes Bild:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße beinhaltet die Bilddaten.
- **Verknüpftes Bild:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Präsentationsgröße reduzieren, erfordert jedoch, dass die externe Ressource beim Öffnen oder Rendern zugänglich bleibt.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/linkpathlong/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Verwenden Sie verknüpfte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Arbeiten mit SVG‑Bildern**

SVG ist ein Vektorformat und eignet sich daher gut für Symbole, Diagramme und andere Grafiken, die ohne Detailverlust skaliert werden sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für bearbeitbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erzeugen Sie ein [SvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/svgimage/), fügen Sie es der Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **SVG‑Dateien mit externen Ressourcen**

Ein SVG kann externe Bilder, Stylesheets oder Schriften referenzieren. In solchen Fällen bieten [SvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/svgimage/) Konstruktoren, die einen [IExternalResourceResolver](https://reference.aspose.com/slides/de/net/aspose.slides.import/iexternalresourceresolver/) und eine Basis‑URI akzeptieren. Der Resolver kann eine relative URI auf eine zulässige absolute URI abbilden und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides bereit, schreibt das SVG jedoch nicht in ein eigenständiges Dokument um. Wenn das SVG portabel bleiben muss, betten Sie die benötigten Ressourcen im SVG selbst ein, beispielsweise über `data:`‑URIs für verknüpfte Bilder.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, beschränken Sie die Schemas, Dateipfade und Hosts, auf die der Resolver zugreifen darf. Netzwerk‑Resolver sollten zudem Zeitlimits, Begrenzungen der Antwortgröße und Inhaltsvalidierungen anwenden.

### **SVG in bearbeitbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe bearbeitbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addgroupshape/)‑Überladung, die ein [ISvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/) akzeptiert, um die Konvertierung durchzuführen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Setzen Sie die SVG‑zu‑Formen‑Konvertierung ein, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist das Belassen als Bild einfacher und vermeidet die Erstellung vieler einzelner Formen.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [IPPImage.ReplaceImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/replaceimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Das ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Wenn mehrere Bildrahmen, Hintergründe, Master oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Sollte nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die gemeinsame Ressource zu ersetzen.

`ReplaceImage` bietet außerdem Überladungen, die ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) oder ein weiteres [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) akzeptieren.

## **Praktische Leitlinien zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig aufblähen. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigegröße geeignet sind, nutzen Sie nach Möglichkeit gemeinsam genutzte Bildressourcen und vermeiden Sie das Einbetten mehrerer Kopien derselben hochauflösenden Grafik.

Für bereits in Bildrahmen platzierte Rasterbilder kann [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/compressimage/) die Bilddaten gemäß der gewählten Auflösung und den Zuschnittseinstellungen reduzieren. Das ist eine Bildrahmen‑Verarbeitung und keine Verwaltung der Bildsammlung; siehe daher [Bildrahmen](/slides/de/net/picture-frame/) für verwandte Formatierungsoperationen.

### **Zwischen eingebettetem und verknüpftem Inhalt wählen**

Einbetten macht die Präsentation portabel, weil alle benötigten Bilddaten mit der Datei mitreisen. Verknüpfen kann die Dateigröße reduzieren, führt jedoch eine externe Abhängigkeit ein. Verwenden Sie Links nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsame Markenbilder wiederverwenden**

Für wiederkehrende Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen sie mehrfach. Gehört die Grafik zum Präsentationsdesign und nicht zum Folieninhalt, platzieren Sie sie auf einem Master oder Layout, damit sie von den jeweiligen Folien geerbt wird.

### **SVG‑Ressourcen portabel halten**

Ein eigenständiges SVG lässt sich leichter verschieben und konsistent rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Betten Sie nach Möglichkeit erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG in Formen nur, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Die moderne plattformübergreifende Bild‑API verwenden**

Für neuen .NET‑Code nutzen Sie die Aspose.Slides‑APIs [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) und [Images](https://reference.aspose.com/slides/de/net/aspose.slides/images/) anstelle von `System.Drawing.Image` oder `Bitmap`. Siehe [Moderne API](/slides/de/net/modern-api/) für Migrationshinweise.

WMF und EMF erfordern besondere Beachtung. Wenn diese Formate über ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) übergeben werden, konvertiert [ImageCollection.AddImage](https://reference.aspose.com/slides/de/net/aspose.slides/imagecollection/addimage/) die Metadatei vor dem Einfügen in eine Raster‑PNG‑Darstellung. Sollten die Metadaten erhalten bleiben, verwenden Sie stattdessen die strombasierte Überladung von [ImageCollection.AddImage](https://reference.aspose.com/slides/de/net/aspose.slides/imagecollection/addimage/). Das Erzeugen von EMF‑Inhalten aus Tabellenkalkulationen oder anderen Produkten ist ein separater Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschnitt und Effekte bereitstellt.

**Wie ersetze ich dasselbe Logo überall?**

Wenn das Logo bereits als eine Bildressource gemeinsam genutzt wird, ersetzen Sie diese Ressource mit [IPPImage.ReplaceImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/replaceimage/). Für präsentationsweite Markenführung kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verknüpftes Bild auf einem anderen Computer?**

Ein verknüpftes Bild hängt von seiner externen Datei oder URL ab. Kann von dem anderen Computer nicht auf die Ressource zugegriffen werden, ist das verknüpfte Bild nicht verfügbar. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addgroupshape/); die resultierende Gruppe enthält bearbeitbare Folienformen statt eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Gemeinsam genutzte Bildressourcen wiederverwenden, unnötig große Rasterquellen vermeiden, geeignete Rasterbilder bei Bedarf komprimieren, wiederholte Markenbilder auf Master‑ oder Layout‑Folien platzieren und verknüpfte Bilder nur verwenden, wenn eine externe Abhängigkeit akzeptabel ist.