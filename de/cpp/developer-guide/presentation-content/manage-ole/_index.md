---
title: OLE in Präsentationen mit C++ verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/cpp/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- Verknüpftes Objekt
- Verknüpfte Datei
- OLE ändern
- OLE-Symbol
- OLE-Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für C++. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren Sie sie und exportieren Sie sie."
---
## **Einführung**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, mit der Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung platziert werden können. 

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint‑Folien platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt. 

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen bzw. Bearbeiten des Objekts auszuwählen. 
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides für C++](https://products.aspose.com/slides/cpp/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides für C++ als OLE‑Objekt‑Frame in eine Folie einbetten, dann gehen Sie folgendermaßen vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über ihren Index.  
3. Lesen Sie die Excel‑Datei als Byte‑Array ein.  
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im Beispiel unten fügen wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides für C++ als [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) zu einer Folie hinzu.  
**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) erwartet als zweiten Parameter eine Dateierweiterung des einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides für C++ ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Der folgende C++‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Füge ein OLE-Objekt-Frame mit einer verknüpften Excel-Datei hinzu.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Auf OLE‑Objekt‑Frames zugreifen**

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es wie folgt leicht finden bzw. darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf das [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) Shape zu.  
   In unserem Beispiel verwenden wir das zuvor erstellte PPTX, das auf der ersten Folie nur ein Shape enthält. Wir *casten* dieses Objekt anschließend zu einem [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Dies war das gewünschte OLE‑Objekt‑Frame, auf das zugegriffen werden soll.  
4. Sobald das OLE‑Objekt‑Frame erreicht ist, können Sie beliebige Operationen darauf ausführen.

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) sowie dessen Dateidaten abgerufen.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Hole die eingebetteten Dateidaten.
    // Hole die Erweiterung der eingebetteten Datei.
    // ...
}
```

### **Eigenschaften verknüpfter OLE‑Objekt‑Frames abrufen**

Aspose.Slides ermöglicht das Abrufen von Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Der folgende C++‑Code zeigt, wie Sie prüfen, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Überprüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame->get_IsObjectLink())
    {
        // Gibt den vollständigen Pfad zur verknüpften Datei aus.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Gibt den relativen Pfad zur verknüpften Datei aus, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Note" %}}

In diesem Abschnitt verwendet das nachfolgende Code‑Beispiel [Aspose.Cells für C++](https://docs.aspose.com/cells/cpp/).

{{% /alert %}}

Wenn ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie das Objekt leicht zugreifen und dessen Daten wie folgt ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse erstellen.  
2. Holen Sie die Referenz der Folie über ihren Index.  
3. Greifen Sie auf das [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) Shape zu.  
   In unserem Beispiel verwenden wir das zuvor erstellte PPTX, das ein Shape auf der ersten Folie enthält. Wir *casten* dieses Objekt anschließend zu einem [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Dies war das gewünschte OLE‑Objekt‑Frame, das zu bearbeiten ist.  
4. Sobald das OLE‑Objekt‑Frame erreicht ist, können Sie beliebige Operationen darauf ausführen.  
5. Erzeugen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.  
6. Greifen Sie das gewünschte `Worksheet` an und ändern Sie die Daten.  
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.  
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten modifiziert, um die Diagrammdaten zu aktualisieren.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells für C++ muss gestartet werden, bevor irgendein seiner Typen verwendet wird.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Lese die OLE-Objektdaten als Workbook-Objekt.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modifiziere die Workbook-Daten.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Ändere die OLE-Frame-Objektdaten.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides für C++ das Einbetten anderer Dateitypen in Folien. Sie können beispielsweise HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im zugehörigen Programm geöffnet oder der Benutzer wird aufgefordert, ein geeignetes Programm auszuwählen.

Der folgende C++‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen kann es vorkommen, dass alte OLE‑Objekte durch neue oder durch nicht unterstützte OLE‑Objekte durch unterstützte ersetzt werden müssen. Aspose.Slides für C++ erlaubt das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder deren Erweiterung aktualisieren können.

Der folgende C++‑Code zeigt, wie Sie den Dateityp eines eingebetteten OLE‑Objekts auf `zip` setzen:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Ändere den Dateityp zu ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau mit einem Symbolbild hinzugefügt. Diese Vorschau wird dem Benutzer angezeigt, bevor er das OLE‑Objekt öffnet. Möchten Sie ein bestimmtes Bild und einen bestimmten Text als Vorschau‑Elemente verwenden, können Sie das Symbolbild und den Titel mit Aspose.Slides für C++ festlegen.

Der folgende C++‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt setzen: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Bild zu den Präsentationsressourcen hinzufügen.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Titel und Bild für die OLE-Vorschau festlegen.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verhindern, dass ein OLE‑Objekt‑Frame in Größe und Position verändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint ein Hinweis erscheinen, der zum Aktualisieren der Verknüpfungen auffordert. Das Klicken auf die Schaltfläche „Update Links“ kann Größe und Position des OLE‑Objekt‑Frames ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau neu rendert. Um PowerPoint daran zu hindern, den Benutzer zum Aktualisieren der Objekt­daten aufzufordern, rufen Sie die Methode [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) des [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)‑Interfaces mit dem Wert `false` auf:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides für C++ ermöglicht das Extrahieren von in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.  
2. Durchlaufen Sie alle Shapes in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑Shapes zu.  
3. Greifen Sie auf die Daten der eingebetteten Dateien aus den OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.

Der folgende C++‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Es wird das gerendert, was auf der Folie sichtbar ist – das Symbol/Ersetzung‑Bild (Vorschau). Der „live“ OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie Ihr eigenes Vorschau‑Bild festlegen, um das erwartete Aussehen im exportierten PDF sicherzustellen.

Um die eingebettete Datei auch als PDF‑Anlage zu erhalten, rufen Sie [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) mit `true` auf. Diese Option ist standardmäßig deaktiviert. Ein Beispiel und Anweisungen zum Prüfen der Anlage finden Sie unter [Preserve Embedded OLE Files as PDF Attachments](/slides/de/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie das Shape: Aspose.Slides bietet [shape‑level locks](/slides/de/cpp/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild folgen Sie den bewährten Verfahren unter [Working Solution for Worksheet Resizing](/slides/de/cpp/working-solution-for-worksheet-resizing/) – entweder den Frame an den Bereich anpassen oder den Bereich an einen festen Frame skalieren und ein passendes Ersetzung‑Bild setzen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format werden keine „relativen Pfad“-Informationen gespeichert – nur der vollständige Pfad. Relative Pfade sind im älteren PPT‑Format zu finden. Für Portabilität sollten Sie zuverlässige absolute Pfade bzw. zugängliche URIs oder das Einbetten bevorzugen.