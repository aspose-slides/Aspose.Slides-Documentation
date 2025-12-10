---
title: Optimieren der Bildverwaltung in Präsentationen mit C++
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/cpp/image/
keywords:
- Bild hinzufügen
- Bild hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Bild ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- EMF
- SVG
- C++
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für C++, um die Leistung zu verbessern und Ihren Arbeitsablauf zu automatisieren."
---

## **Bilder in Präsentationsfolien**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Speicherorten in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren. 

{{% alert title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten – besonders wenn Sie planen, Standardformatierungsoptionen zu verwenden, um seine Größe zu ändern, Effekte hinzuzufügen usw. – siehe [Picture Frame](/slides/de/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Sie können Ein- und Ausgabevorgänge, die Bilder und PowerPoint-Präsentationen betreffen, manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: konvertieren [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); konvertieren [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); konvertieren [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), konvertieren [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); konvertieren [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), konvertieren [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Vorgänge mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und andere. 

## **Lokale Bilder zu Folien hinzufügen**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Dieser Beispielcode in C++ zeigt, wie Sie ein Bild zu einer Folie hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```




## **Bilder aus dem Web zu Folien hinzufügen**

Falls das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt, wie Sie ein Bild aus dem Web zu einer Folie in C++ hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) für alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie unter diesem Folienmaster. 

Dieser C++‑Beispielcode zeigt, wie Sie ein Bild zu einem Folienmaster hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Bilder als Folienhintergrund hinzufügen**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall sollten Sie *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)* lesen.

## **SVG zu Präsentationen hinzufügen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) verwenden, die zur Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) gehört.

So erstellen Sie ein Bildobjekt basierend auf einem SVG‑Bild:
1. Erstellen Sie ein SvgImage‑Objekt, um es in die ImageShapeCollection einzufügen.
2. Erstellen Sie ein PPImage‑Objekt aus ISvgImage.
3. Erstellen Sie ein PictureFrame‑Objekt mithilfe der IPPImage‑Schnittstelle.

Dieser Beispielcode zeigt, wie Sie die oben genannten Schritte implementieren, um ein SVG‑Bild in eine Präsentation einzufügen:
``` cpp 
// Der Pfad zum Dokumentenverzeichnis
System::String dataDir = u"D:\\Documents\\";

// Name der Quell SVG-Datei
System::String svgFileName = dataDir + u"sample.svg";

// Dateiname der Ausgabepäsentation
System::String outPptxPath = dataDir + u"presentation.pptx";

// Neue Präsentation erstellen
auto p = System::MakeObject<Presentation>();

// SVG-Dateiinhalt lesen
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage-Objekt erstellen
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage-Objekt erstellen
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Erzeugt einen neuen PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Präsentation im PPTX-Format speichern
p->Save(outPptxPath, SaveFormat::Pptx);
```


## **SVG in eine Menge von Formen konvertieren**
Die Konvertierung von SVG in eine Menge von Formen durch Aspose.Slides ist ähnlich der PowerPoint‑Funktionalität zum Arbeiten mit SVG‑Bildern:

![PowerPoint Popup Menu](img_01_01.png)

Die Funktionalität wird von einer der Überladungen der Methode [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) der Schnittstelle [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image)‑Objekt als erstes Argument übernimmt.

Dieser Beispielcode zeigt, wie Sie die beschriebene Methode verwenden, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:
``` cpp 
// Der Pfad zum Dokumentenverzeichnis
System::String dataDir = u"D:\\Documents\\";

// Name der Quell‑SVG‑Datei
System::String svgFileName = dataDir + u"sample.svg";

// Dateiname der Ausgabepäsentation
System::String outPptxPath = dataDir + u"presentation.pptx";

// Neue Präsentation erstellen
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG-Dateiinhalt lesen
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage-Objekt erstellen
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Foliengröße abrufen
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG-Bild in eine Gruppe von Formen konvertieren und auf Foliengröße skalieren
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Präsentation im PPTX‑Format speichern
presentation->Save(outPptxPath, SaveFormat::Pptx);
```


## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides für C++ ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Blättern und das Hinzufügen dieser Bilder als EMF zu Folien mit Aspose.Cells. 

Dieser Beispielcode zeigt, wie Sie die beschriebene Aufgabe ausführen:
``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```


## **Bilder in der Bildersammlung ersetzen**
Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildersammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen verwendeten). Dieser Abschnitt zeigt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet einfache Methoden, um ein Bild mit rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/)‑Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild zu ersetzen.

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
1. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
1. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
1. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildersammlung der Präsentation vorhanden ist.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Der erste Weg.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Der zweite Weg.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Der dritte Weg.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Speichern Sie die Präsentation in einer Datei.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif)‑Konverter können Sie Texte einfach animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quellpixel werden beibehalten, aber das endgültige Aussehen hängt davon ab, wie das [picture](/slides/de/cpp/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, dasselbe Logo gleichzeitig auf Dutzenden von Folien zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildersammlung der Präsentation – die Änderungen werden an alle Elemente, die diese Ressource verwenden, weitergegeben.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, wobei die einzelnen Teile anschließend mit den Standard‑Formeigenschaften editierbar werden.

**Wie kann ich ein Bild als Hintergrund für mehrere Folien gleichzeitig festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/cpp/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass die Präsentation aufgrund vieler Bilder stark anwächst?**

Verwenden Sie eine einzelne Bildressource statt Duplikaten, wählen Sie vernünftige Auflösungen, wenden Sie beim Speichern Kompression an und halten Sie wiederholte Grafiken, wenn sinnvoll, im Master.