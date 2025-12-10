---
title: OLE in Präsentationen mit C++ verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/cpp/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbetten
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- verknüpftes Objekt
- verknüpfte Datei
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
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für C++. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, mittels Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren.
{{% /alert %}}

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in einer PowerPoint‑Folie platziert. Dieses Excel‑Diagramm gilt als OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird das Diagramm beim Doppelklick auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE‑Objekt kann seinen eigentlichen Inhalt anzeigen, z.B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **OLE-Objekt-Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mit Aspose.Slides for C++ als OLE‑Objekt‑Frame in eine Folie einbetten, dann können Sie dies folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie sich eine Referenz auf die Folie über deren Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array ein.
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) zur Folie hinzu, das das Byte‑Array und weitere Informationen über das OLE‑Objekt enthält.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei mithilfe von Aspose.Slides for C++ als [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) zu einer Folie hinzugefügt.

**Hinweis**: Der Konstruktor von [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) akzeptiert als zweiten Parameter die Erweiterung eines einbettbaren Objekts. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die passende Anwendung zum Öffnen des OLE‑Objekts auszuwählen.
``` cpp
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


### **Verknüpfte OLE-Objekt-Frames hinzufügen**

Aspose.Slides for C++ ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ohne Daten einzubetten, sondern nur mit einem Link zur Datei.

Der folgende C++‑Code zeigt, wie ein [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzugefügt wird:
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add an OLE object frame with a linked Excel file.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Zugriff auf OLE-Objekt-Frames**

Falls ein OLE‑Objekt bereits in einer Folie eingebettet ist, können Sie es auf folgende Weise leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie über deren Index.
3. Greifen Sie auf das [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑Shape zu.
   In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das nur ein Shape auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden soll.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) und dessen Dateidaten abgerufen.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Abrufen der eingebetteten Dateidaten.
    // Abrufen der Dateierweiterung der eingebetteten Datei.
    // ...

}
```


### **Eigenschaften verknüpfter OLE-Objekt-Frames abrufen**

Aspose.Slides ermöglicht den Zugriff auf die Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Der folgende C++‑Code zeigt, wie geprüft wird, ob ein OLE‑Objekt verknüpft ist, und wie anschließend der Pfad zur verknüpften Datei ermittelt wird:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Prüfen, ob das OLE-Objekt verknüpft ist.
    if (oleFrame->get_IsObjectLink())
    {
        // Vollständigen Pfad zur verknüpften Datei ausgeben.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
        // Nur PPT-Präsentationen können den relativen Pfad enthalten.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```


## **OLE-Objektdaten ändern**
{{% alert color="primary" %}}
In diesem Abschnitt verwendet das untenstehende Codebeispiel [Aspose.Cells for C++](/cells/cpp/).
{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie dieses Objekt auf folgende Weise leicht zugreifen und dessen Daten ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse erstellen.
2. Holen Sie die Referenz der Folie über deren Index.
3. Greifen Sie auf das [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑Shape zu.
   In unserem Beispiel haben wir das zuvor erstellte PPTX verwendet, das ein Shape auf der ersten Folie enthält. Wir haben dieses Objekt dann als [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) *gecastet*. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden soll.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein `Workbook`‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte `Worksheet` zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte `Workbook` in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im nachfolgenden Beispiel wird ein OLE‑Objekt‑Frame (ein in einer Folie eingebettetes Excel‑Diagramm‑Objekt) abgerufen und dessen Dateidaten werden geändert, um die Diagrammdaten zu aktualisieren.
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Erhalte das erste Shape als OLE-Objekt-Frame.
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
```


## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for C++ das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen auszuwählen.

Der folgende C++‑Code zeigt, wie HTML und ZIP in eine Folie eingebettet werden:
``` cpp
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

Beim Arbeiten mit Präsentationen kann es erforderlich sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for C++ ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, wodurch Sie die OLE‑Frame‑Daten oder dessen Erweiterung aktualisieren können.

Der folgende C++‑Code zeigt, wie der Dateityp für ein eingebettetes OLE‑Objekt auf `zip` gesetzt wird:
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Symbol-Bilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau in Form eines Symbol-Bildes hinzugefügt. Diese Vorschau sehen die Benutzer, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbol-Bild und den Titel mit Aspose.Slides for C++ festlegen.

Der folgende C++‑Code zeigt, wie das Symbol-Bild und der Titel für ein eingebettetes Objekt festgelegt werden:
``` cpp
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


## **Verhindern, dass ein OLE‑Objekt‑Frame skaliert und neu positioniert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Anklicken der Schaltfläche „Update Links“ kann Größe und Position des OLE‑Objekt‑Frames ändern, da PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Vorschau des Objekts neu erstellt. Um zu verhindern, dass PowerPoint zur Aktualisierung der Objektdaten auffordert, setzen Sie die Methode `set_UpdateAutomatic` der [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)‑Schnittstelle auf `false`:
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **Eingettete Dateien extrahieren**

Aspose.Slides for C++ ermöglicht das Extrahieren der in Folien eingebetteten Dateien als OLE‑Objekte auf folgende Weise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse, die die zu extrahierenden OLE‑Objekte enthält.
2. Durchlaufen Sie alle Shapes in der Präsentation und greifen Sie auf die [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)‑Shapes zu.
3. Greifen Sie auf die Daten eingebetteter Dateien aus OLE‑Object‑Frames zu und schreiben Sie sie auf die Festplatte.

Der folgende C++‑Code zeigt, wie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahiert werden:
``` cpp
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

Was auf der Folie sichtbar ist, wird gerendert – das Symbol/Ersetzung‑Bild (Vorschau). Der „Live“-OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie ein eigenes Vorschaubild festlegen, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, damit Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Schalten Sie das Shape: Aspose.Slides bietet [shape-level locks](/slides/de/cpp/applying-protection-to-presentation/). Dies ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Verschiebungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die Praktiken aus der [Working Solution for Worksheet Resizing](/slides/de/cpp/working-solution-for-worksheet-resizing/) befolgen – entweder den Frame an den Bereich anpassen oder den Bereich auf einen festen Frame skalieren und ein geeignetes Ersetzung‑Bild festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format beibehalten?**

Im PPTX‑Format ist die Information zu relativen Pfaden nicht verfügbar – es wird nur der volle Pfad gespeichert. Relative Pfade existieren im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.