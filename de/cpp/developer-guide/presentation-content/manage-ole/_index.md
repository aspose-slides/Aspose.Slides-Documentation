---
title: OLE verwalten
type: docs
weight: 40
url: /de/cpp/manage-ole/
keywords:
- OLE hinzufügen
- OLE einbetten
- ein Objekt hinzufügen
- ein Objekt einbetten
- eine Datei einbetten
- verknüpftes Objekt
- Objektverknüpfung und -einbettung
- OLE-Objekt
- PowerPoint 
- Präsentation
- C++
- Aspose.Slides für C++
description: Fügen Sie OLE-Objekte in PowerPoint-Präsentationen in C++ hinzu.
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung durch Verknüpfungen oder Einbettungen zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint-Folie platziert. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet. 

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder es wird angezeigt, dass eine Anwendung zum Öffnen oder Bearbeiten des Objekts ausgewählt werden muss. 
- Ein OLE-Objekt kann den tatsächlichen Inhalt anzeigen - zum Beispiel den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen, und Sie können die Daten des Diagramms innerhalb der PowerPoint-App ändern.

[Aspose.Slides für C++](https://products.aspose.com/slides/cpp/) ermöglicht es Ihnen, OLE-Objekte in Folien als OLE-Objektrahmen ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)) einzufügen.



## **Hinzufügen von OLE-Objektrahmen zu Folien**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm als OLE-Objektrahmen in eine Folie einbetten, indem Sie Aspose.Slides für C++ verwenden. So können Sie vorgehen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.
2. Holen Sie sich die Referenz der Folie anhand ihres Index.
3. Öffnen Sie die Excel-Datei, die das Excel-Diagrammobjekt enthält, und speichern Sie es in `MemoryStream`.
4. Fügen Sie den [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) zur Folie hinzu, indem Sie das Byte-Array und andere Informationen über das OLE-Objekt bereitstellen.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei als [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) in eine Folie eingefügt, indem wir Aspose.Slides für C++ verwendet haben.  
**Hinweis:** Der [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info)-Konstruktor akzeptiert eine einbettbare Objekt-Erweiterung als zweiten Parameter. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung auszuwählen, um dieses OLE-Objekt zu öffnen.

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = u"";
// Instanziiert die Presentation-Klasse, die das PPTX repräsentiert
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// Lädt eine Excel-Datei in einen Stream
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// Erstellt ein Datenobjekt zum Einbetten
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// Fügt eine Ole Object Frame-Form hinzu
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf OLE-Objektrahmen**
Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt auf einfache Weise so finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.

2. Erhalten Sie die Referenz der Folie, indem Sie ihren Index verwenden.

3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)-Form zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie enthält. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) *casted*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.

4. Sobald der OLE-Objektrahmen zugegriffen ist, können Sie beliebige Operationen darauf durchführen.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in einer Folie eingebettetes Excel-Diagrammobjekt) zugegriffen - und dann werden die damit verbundenen Dateidaten in einer Excel-Datei geschrieben:

``` cpp
// Der Pfad zum Dokumentenverzeichnis.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Greift auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Castet die Form zu OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// Liest das OLE-Objekt und schreibt es auf die Festplatte
if (oleObjectFrame != nullptr)
{
    // Holt die eingebetteten Dateidaten
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // Holt die eingebettete Dateierweiterung
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // Erstellt einen Pfad zum Speichern der extrahierten Datei
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // Speichert die extrahierten Daten
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **Ändern der OLE-Objektdaten**
Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt auf einfache Weise zugreifen und seine Daten ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse erstellen.

2. Holen Sie sich die Referenz der Folie anhand ihres Index. 

3. Greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)-Form zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die eine Form auf der ersten Folie hat. Wir haben dann dieses Object als [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) *casted*. Dies war der gewünschte OLE-Objektrahmen, auf den zugegriffen werden sollte.

4. Sobald der OLE-Objektrahmen zugegriffen ist, können Sie beliebige Operationen auf ihm durchführen.

5. Erstellen Sie das Workbook-Objekt und greifen Sie auf die OLE-Daten zu.

6. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.

7. Speichern Sie das aktualisierte Workbook in Streams.

8. Ändern Sie die OLE-Objektdaten aus den Streamdaten.

Im folgenden Beispiel wird ein OLE-Objektrahmen (ein in einer Folie eingebettetes Excel-Diagrammobjekt) zugegriffen - und dann werden die damit verbundenen Dateidaten geändert, um die Diagrammdaten zu ändern:

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // Durchläuft alle Formen nach Ole-Frame
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // Liest die Objektdaten im Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // Ändert die Workbook-Daten
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // Ändert die Ole-Frame-Objektdaten
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## Einbettung anderer Dateitypen in Folien

Neben Excel-Diagrammen ermöglicht Aspose.Slides für C++, andere Arten von Dateien in Folien einzubetten. Zum Beispiel können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im entsprechenden Programm gestartet, oder der Benutzer wird aufgefordert, ein passendes Programm auszuwählen, um das Objekt zu öffnen. 

Dieser C++-Code zeigt Ihnen, wie man HTML und ZIP in eine Folie einbettet:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## Festlegen von Dateitypen für eingebettete Objekte

Beim Arbeiten an Präsentationen müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen. 

Aspose.Slides für C++ ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. Auf diese Weise können Sie die OLE-Rahmendaten oder seine Erweiterung ändern. 

Dieser C++-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"Die aktuelle eingebettete Daten-Erweiterung ist: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## Festlegen von Symbolbildern und Titeln für eingebettete Objekte

Nachdem Sie ein OLE-Objekt eingebettet haben, wird automatisch eine Vorschau mit einem Symbolbild und einem Titel hinzugefügt. Die Vorschau ist das, was die Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen. 

Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für C++ festlegen.

Dieser C++-Code zeigt Ihnen, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"Mein Titel");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **Verhindern, dass ein OLE-Objektrahmen geändert und repositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt zu einem Präsentations-Slide hinzugefügt haben, sehen Sie beim Öffnen der Präsentation in PowerPoint möglicherweise eine Meldung, die Sie auffordert, die Links zu aktualisieren. Wenn Sie auf die Schaltfläche "Links aktualisieren" klicken, kann die Größe und Position des OLE-Objektrahmens geändert werden, da PowerPoint die Daten aus dem verknüpften OLE-Objekt aktualisiert und die Objektvorschau erneuert. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Methode `set_UpdateAutomatic` des [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)-Interfaces auf `false`:

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## Extrahieren eingebetteter Dateien

Aspose.Slides für C++ ermöglicht es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien auf folgende Weise zu extrahieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse, die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)-Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei aus dem OLE-Objektrahmen zu und schreiben Sie sie auf die Festplatte. 

Dieser C++-Code zeigt Ihnen, wie Sie eine in einer Folie als OLE-Objekt eingebettete Datei extrahieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```