---
title: Bild
type: docs
weight: 10
url: /de/cpp/image/
---


## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Orten in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen durch verschiedene Verfahren.

{{% alert title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten, insbesondere wenn Sie planen, Standardformatierungsoptionen zu verwenden, um dessen Größe zu ändern, Effekte hinzuzufügen usw., siehe [Bilderrahmen](/slides/de/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Eingabe-/Ausgabeoperationen im Zusammenhang mit Bildern und PowerPoint-Präsentationen manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Sehen Sie sich diese Seiten an: konvertieren [Bild zu JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und anderen. 

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können eines oder mehrere Bilder von Ihrem Computer auf eine Folie in einer Präsentation hinzufügen. Dieser Beispielcode in C++ zeigt Ihnen, wie man ein Bild zu einer Folie hinzufügt:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Hinzufügen von Bildern aus dem Web zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, auf Ihrem Computer nicht verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Bild aus dem Web zu einer Folie in C++ hinzufügen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[ERSETZEN SIE MIT URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Hinzufügen von Bildern zu Folienvorlagen**

Eine Folienmaster ist die oberste Folie, die Informationen (Thema, Layout usw.) über alle darunter liegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einer Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie unter dieser Folienmaster. 

Dieser C++ Beispielcode zeigt Ihnen, wie Sie ein Bild zu einer Folienmaster hinzufügen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Hinzufügen von Bildern als Folienhintergrund**

Sie können sich entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall müssen Sie *[Bilder als Hintergründe für Folien festlegen](https://docs.aspose.com/slides/cpp/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **Einfügen/Hinzufügen von SVG in Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen oder hinzufügen, indem Sie die [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) Methode des [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Interfaces verwenden.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie es folgendermaßen tun:

1. Erstellen Sie ein SvgImage-Objekt, um es in ImageShapeCollection einzufügen
2. Erstellen Sie ein PPImage-Objekt aus ISvgImage
3. Erstellen Sie ein PictureFrame-Objekt mit der IPPImage-Schnittstelle

Dieser Beispielcode zeigt Ihnen, wie Sie die oben beschriebenen Schritte umsetzen, um ein SVG-Bild in eine Präsentation hinzuzufügen:
``` cpp 
// Der Pfad zum Dokumentenverzeichnis
System::String dataDir = u"D:\\Documents\\";

// Quell-SVG-Dateiname
System::String svgFileName = dataDir + u"sample.svg";

// Ausgabedateiname der Präsentation
System::String outPptxPath = dataDir + u"presentation.pptx";

// Erstellen Sie eine neue Präsentation
auto p = System::MakeObject<Presentation>();

// SVG-Dateiinhalt lesen
System::String svgContent = File::ReadAllText(svgFileName);

// Erstellen Sie ein SvgImage-Objekt
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Erstellen Sie ein PPImage-Objekt
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Erstellt ein neues PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Speichern Sie die Präsentation im PPTX-Format
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Konvertieren von SVG in eine Gruppe von Formen**
Die Konvertierung von SVG in eine Gruppe von Formen in Aspose.Slides ist ähnlich der PowerPoint-Funktionalität, die verwendet wird, um mit SVG-Bildern zu arbeiten:


![PowerPoint Popup-Menü](img_01_01.png)

Die Funktionalität wird von einem der Überladungen der [AddGroupShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) Methode der [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Schnittstelle bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_svg_image) Objekt als ersten Parameter akzeptiert.

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Methode verwenden, um eine SVG-Datei in eine Gruppe von Formen zu konvertieren:

``` cpp 
// Der Pfad zum Dokumentenverzeichnis
System::String dataDir = u"D:\\Documents\\";

// Quell-SVG-Dateiname
System::String svgFileName = dataDir + u"sample.svg";

// Ausgabedateiname der Präsentation
System::String outPptxPath = dataDir + u"presentation.pptx";

// Erstellen Sie eine neue Präsentation
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG-Dateiinhalt lesen
System::String svgContent = File::ReadAllText(svgFileName);

// Erstellen Sie ein SvgImage-Objekt
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Holen Sie sich die Foliengröße
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Konvertieren Sie das SVG-Bild in eine Gruppe von Formen und skalieren Sie es auf die Foliengröße
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Speichern Sie die Präsentation im PPTX-Format
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für C++ ermöglicht es Ihnen, EMF-Bilder aus Excel-Blättern zu generieren und die Bilder als EMF in Folien mit Aspose.Cells hinzuzufügen. 

Dieser Beispielcode zeigt Ihnen, wie Sie die beschriebene Aufgabe ausführen:

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

// Speichern Sie die Arbeitsmappe im Stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Seite" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter können Sie Texte einfach animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}