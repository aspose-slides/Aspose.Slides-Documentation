---
title: Optimieren der Bildverwaltung in Präsentationen mit C++
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/cpp/image/
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
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Raster- und SVG-Bilder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ hinzufügen, wiederverwenden, verknüpfen, ersetzen und verwalten."
---
## **Einleitung**

Aspose.Slides für C++ bietet mehrere Möglichkeiten zum Arbeiten mit Bildern, und jede dient einem anderen Zweck. Sie können ein Bild in einer Präsentation speichern, es in einem Bildrahmen anzeigen, es als Folienhintergrund verwenden, auf ein externes Bild verlinken, eine gemeinsam genutzte Bildressource ersetzen oder SVG-Inhalt in editierbare Formen konvertieren.

Dieser Artikel konzentriert sich auf Bildressourcen und deren Verwendung in einer Präsentation. Informationen zu Zuschneiden, Transparenz, Effekten, Dehnung und anderen Formatierungen, die auf einen einzelnen Bildrahmen angewendet werden, finden Sie unter [Picture Frame](/slides/de/cpp/picture-frame/).

## **Verstehen des Bildmodells**

- Die [presentation image collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/) speichert Bildressourcen, die von der Präsentation verwendet werden. Verwenden Sie [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/), um Bilddaten hinzuzufügen und eine [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)-Ressource zu erhalten.
- Ein [picture frame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist eine Form, die ein Bild auf einer Folie, einem Layout oder einem Master anzeigt. Verwenden Sie [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addpictureframe/), um eine Bildressource auf einer Folie zu platzieren.
- Ein Folienhintergrund verwendet ein Bild als Teil der Folienfüllung und nicht als Form. Daher verhält er sich nicht wie ein Bildrahmen.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/replaceimage/) ersetzt eine Bildressource. Wenn mehrere Präsentationselemente diese Ressource verwenden, nutzen sie alle die Ersetzung.
- Das Konvertieren eines SVG in Formen erzeugt editierbare Folienformen. Nach der Konvertierung wird der Inhalt nicht mehr als ein Bildressource verwaltet.

Ein typischer Arbeitsablauf ist daher: Bilddaten zur Bildsammlung hinzufügen, ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) erhalten und anschließend diese Ressource in einem oder mehreren Bildrahmen oder Füllungen verwenden.

## **Ein eingebettetes Bild hinzufügen**

Um ein lokales Bild einzufügen, lesen Sie die Datei, fügen dessen Daten zur Bildsammlung hinzu und erstellen einen Bildrahmen, der die zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)-Ressource verwendet.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das auf diese Weise hinzugefügte Bild ist in die Präsentation eingebettet, sodass die resultierende Datei nicht von der Verfügbarkeit der ursprünglichen Bilddatei abhängt.

### **Ein Bild aus dem Web hinzufügen**

Wenn ein Bild über HTTP oder HTTPS verfügbar ist, laden Sie dessen Bytes herunter, fügen sie zur Bildsammlung der Präsentation hinzu und verwenden die zurückgegebene Bildressource auf dieselbe Weise wie ein lokales Bild.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Validieren Sie Remote‑URLs, Antwortgrößen und Inhaltstypen, wenn die Quelle nicht vertrauenswürdig ist. In Anwendungen, die bereits einen anderen HTTP‑Client verwenden, können Sie das Bild mit diesem Client herunterladen und die resultierenden Bytes oder den Stream an [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/) übergeben.

## **Bilder über Folien hinweg wiederverwenden**

Falls dasselbe Bild mehrmals benötigt wird, fügen Sie es einmal zur Präsentation hinzu und verwenden die zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/), wenn Sie zusätzliche Bildrahmen erstellen. Dadurch wird das wiederholte Laden derselben Quelldaten vermieden und die Beziehung zwischen der gemeinsamen Bildressource und ihrer Verwendung eindeutig.

Für Grafiken, die automatisch auf vielen Folien erscheinen sollen, wie ein Firmenlogo, sollten Sie in Betracht ziehen, den Bildrahmen auf einem [slide master](/slides/de/cpp/slide-master/) oder Layout zu platzieren, anstatt für jede Folie eine entsprechende Form hinzuzufügen.

## **Ein Bild als Folienhintergrund verwenden**

Ein Hintergrundbild wird der Folienfüllung zugewiesen; es wird nicht als Bildrahmen‑Form hinzugefügt. Dies ist nützlich, wenn das Bild den Folienhintergrund abdecken und nicht wie ein normales Folienobjekt bearbeitet werden soll.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Weitere Hintergrundoptionen, einschließlich Master‑ und Layout‑Hintergründen, finden Sie unter [Presentation Background](/slides/de/cpp/presentation-background/).

## **Eingebettete und verknüpfte Bilder**

Eingebettete und verknüpfte Bilder haben unterschiedliche Kompromisse hinsichtlich Portabilität und Dateigröße:

- **Embedded image:** Die Bilddaten werden innerhalb der Präsentation gespeichert. Die Präsentation ist eigenständig, aber die Dateigröße enthält die Bilddaten.
- **Linked image:** Die Präsentation speichert einen Pfad oder eine URL zu einem externen Bild. Dies kann die Präsentationsgröße reduzieren, erfordert jedoch, dass die externe Ressource beim Öffnen oder Rendern der Präsentation erreichbar bleibt.

Ein verknüpftes Bild kann erstellt werden, indem der externe Pfad oder die URL über [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/set_linkpathlong/) zugewiesen wird, anstatt die Bilddaten einzubetten.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Verwenden Sie verknüpfte Bilder nur, wenn die Bereitstellungsumgebung zuverlässig auf die externe Ressource zugreifen kann. Für Präsentationen, die offline funktionieren oder zwischen Systemen verschoben werden müssen, sind eingebettete Bilder in der Regel sicherer.

## **Mit SVG-Bildern arbeiten**

SVG ist ein Vektorformat und eignet sich daher für Symbole, Diagramme und andere Grafiken, die ohne denselben Detailverlust wie Rasterbilder skalierbar sein sollen. Aspose.Slides unterstützt SVG sowohl als Bildressource als auch als Quelle für editierbare Folienformen.

### **Ein SVG als Bild hinzufügen**

Erstellen Sie ein [SvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/svgimage/), fügen Sie es zur Bildsammlung hinzu und platzieren Sie die resultierende Bildressource in einem Bildrahmen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **SVG-Dateien mit externen Ressourcen**

Ein SVG kann auf externe Bilder, Stylesheets oder Schriften verweisen. Für diese Fälle bietet [SvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/svgimage/) Konstruktoren, die einen [IExternalResourceResolver](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/) und eine Basis‑URI akzeptieren. Der Resolver kann eine relative URI einer zulässigen absoluten URI zuordnen und einen Stream für die angeforderte Ressource zurückgeben.

Der Resolver stellt externe Ressourcen während der Verarbeitung des SVG durch Aspose.Slides bereit, rewritet das SVG jedoch nicht zu einem eigenständigen Dokument. Sollte das SVG portabel bleiben, betten Sie die erforderlichen Ressourcen in das SVG selbst ein, zum Beispiel indem Sie `data:`‑URIs für verknüpfte Bilder verwenden.

Wenn SVG‑Dateien aus nicht vertrauenswürdigen Quellen stammen, beschränken Sie die Schemas, Dateipfade und Hosts, auf die der Resolver zugreifen kann. Netzwerk‑Resolver sollten zudem Zeitüberschreitungen, Größenbeschränkungen für Antworten und Inhaltsvalidierungen anwenden.

### **SVG in editierbare Formen konvertieren**

Aspose.Slides kann ein SVG in eine Gruppe editierbarer Folienformen konvertieren, ähnlich dem entsprechenden PowerPoint‑Befehl.

![PowerPoint Popup Menu](img_01_01.png)

Verwenden Sie die Überladung von [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addgroupshape/) die ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/) akzeptiert, um die Konversion durchzuführen.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Verwenden Sie die SVG‑zu‑Formen‑Konvertierung, wenn einzelne Vektorelemente als PowerPoint‑Formen bearbeitet werden müssen. Wenn das SVG nur angezeigt werden soll, ist das Beibehalten als Bild einfacher und vermeidet das Erzeugen vieler separater Formen.

## **Eine vorhandene Bildressource ersetzen**

Verwenden Sie [IPPImage::ReplaceImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/replaceimage/), wenn Sie eine vorhandene Bildressource ersetzen möchten. Dies ist besonders nützlich für gemeinsam genutzte Grafiken wie Logos.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wenn mehrere Bildrahmen, Hintergründe, Master oder Layouts dieselbe Bildressource verwenden, aktualisiert das Ersetzen dieser Ressource alle diese Verwendungen. Sollte nur ein Bildrahmen geändert werden, weisen Sie diesem Rahmen ein anderes Bild zu, anstatt die gemeinsam genutzte Ressource zu ersetzen.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/replaceimage/) bietet außerdem Überladungen, die ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) oder ein anderes [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) akzeptieren.

## **Praktische Hinweise zur Bildverwaltung**

### **Präsentationsgröße kontrollieren**

Große Rasterbilder können eine Präsentation unnötig groß machen. Verwenden Sie Quellbilder mit Abmessungen, die für die beabsichtigte Anzeigengröße geeignet sind, nutzen Sie nach Möglichkeit gemeinsam genutzte Bildressourcen wieder und vermeiden Sie das Einbetten mehrerer Kopien derselben hochauflösenden Grafik.

Für Rasterbilder, die bereits in Bildrahmen platziert wurden, kann [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/compressimage/) Bilddaten entsprechend der ausgewählten Auflösung und den Zuschnittseinstellungen reduzieren. Dies ist eine Bildrahmen‑Verarbeitung und keine Verwaltung der Bildsammlung; siehe daher [Picture Frame](/slides/de/cpp/picture-frame/) für verwandte Formatierungsoperationen.

### **Auswahl zwischen eingebettetem und verknüpftem Inhalt**

Durch Einbetten wird die Präsentation portabel, da alle erforderlichen Bilddaten mit der Datei mitgeliefert werden. Verknüpfungen können die Dateigröße reduzieren, führen jedoch eine externe Abhängigkeit ein. Verwenden Sie Verknüpfungen nur, wenn diese Abhängigkeit akzeptabel und stabil ist.

### **Gemeinsames Branding wiederverwenden**

Für wiederholte Logos, Wasserzeichen oder dekorative Grafiken verwenden Sie eine Bildressource und nutzen sie wieder. Wenn die Grafik zum Design der Präsentation und nicht zum Folieninhalt gehört, platzieren Sie sie auf einem Master oder Layout, damit sie von den entsprechenden Folien geerbt wird.

### **SVG-Ressourcen portabel halten**

Ein eigenständiges SVG ist leichter zu verschieben und konsistent zu rendern als ein SVG, das von externen Dateien oder Netzwerkressourcen abhängt. Wenn möglich, betten Sie erforderliche Ressourcen ein, bevor Sie das SVG importieren. Konvertieren Sie SVG in Formen nur, wenn die einzelnen Vektorelemente bearbeitet werden müssen.

### **Verwenden Sie die Aspose.Slides‑Image‑API**

Für C++‑Bild‑Workflows verwenden Sie die Aspose.Slides‑APIs [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) und [Images](https://reference.aspose.com/slides/de/cpp/aspose.slides/images/), wenn Sie ein Bildobjekt benötigen, und verwenden Sie [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/), wenn Sie Bilddaten als Präsentationsressource registrieren müssen. Die Überladungen der Sammlung unterstützen zudem Byte‑Arrays und Streams, was nützlich ist, wenn Bilddaten aus Dateien, Netzwerk‑Clients, Datenbanken oder anderen Bibliotheken stammen.

Die Erzeugung von EMF‑Inhalten aus Tabellenkalkulationen oder einem anderen Produkt ist ein separater Integrations‑Workflow und liegt außerhalb des Umfangs dieses Artikels. Wenn eine vorhandene WMF‑ oder EMF‑Datei nur in eine Präsentation eingefügt werden muss, übergeben Sie deren Daten an eine geeignete [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/)‑Überladung, ohne eine zweite Produktabhängigkeit in den Bildverwaltungs‑Workflow einzufügen.

## **FAQ**

**Was ist der Unterschied zwischen der Bildsammlung und einem Bildrahmen?**

Die Bildsammlung speichert wiederverwendbare Bildressourcen. Ein Bildrahmen ist eine Folienform, die eine dieser Ressourcen anzeigt und bildspezifische Formatierungen wie Zuschneiden und Effekte bereitstellt.

**Was ist der beste Weg, das gleiche Logo überall zu ersetzen?**

Wenn das Logo bereits als eine Bildressource gemeinsam genutzt wird, ersetzen Sie diese Ressource mit [IPPImage::ReplaceImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/replaceimage/). Für branding über die gesamte Präsentation hinweg kann das Platzieren des Logos auf einem Master oder Layout ebenfalls duplizierten Folieninhalt reduzieren.

**Warum verschwindet ein verknüpftes Bild auf einem anderen Computer?**

Ein verknüpftes Bild hängt von seiner externen Datei oder URL ab. Wenn diese Ressource vom anderen Computer aus nicht erreichbar ist, kann das verknüpfte Bild nicht verfügbar sein. Betten Sie das Bild ein, wenn die Präsentation eigenständig sein muss.

**Kann ein eingefügtes SVG als PowerPoint‑Formen bearbeitet werden?**

Ja. Konvertieren Sie das SVG mit [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addgroupshape/); die resultierende Gruppe enthält editierbare Folienformen statt eines einzigen SVG‑Bildes.

**Wie kann ich Präsentationen mit vielen Bildern kleiner halten?**

Verwenden Sie gemeinsam genutzte Bildressourcen erneut, vermeiden Sie unnötig große Rasterquellen, komprimieren Sie geeignete Rasterbilder, wenn sinnvoll, halten Sie wiederholtes Branding auf Mastern oder Layouts, und nutzen Sie verknüpfte Bilder nur, wenn eine externe Abhängigkeit akzeptabel ist.