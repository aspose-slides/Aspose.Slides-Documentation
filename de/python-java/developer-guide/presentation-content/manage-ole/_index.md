---
title: OLE in Präsentationen mit Python verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/python-java/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung und Einbettung
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
- Python
- Java
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via Java. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---
## **Einleitung**

{{% alert color="info" title="Hinweis" %}}

OLE (Object Linking & Embedding) ist eine Microsoft‑Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, in einer anderen Anwendung über Verknüpfung oder Einbettung zu platzieren.

{{% /alert %}}

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird anschließend in eine PowerPoint‑Folie eingefügt. Dieses Excel‑Diagramm gilt als OLE‑Objekt.

- Ein OLE‑Objekt kann als Symbol angezeigt werden. In diesem Fall wird beim Doppelklick auf das Symbol das Diagramm in der zugehörigen Anwendung (Excel) geöffnet, oder Sie werden aufgefordert, eine Anwendung zum Öffnen bzw. Bearbeiten des Objekts auszuwählen.
- Ein OLE‑Objekt kann seinen tatsächlichen Inhalt anzeigen, z. B. den Inhalt eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Diagrammdaten innerhalb von PowerPoint ändern.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/de/python-java/) ermöglicht das Einfügen von OLE‑Objekten in Folien als OLE‑Objekt‑Frames ([OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/)).

## **OLE‑Objekt‑Frames zu Folien hinzufügen**

Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten es mithilfe von Aspose.Slides for Python via Java als OLE‑Objekt‑Frame in eine Folie einbetten, dann geht das folgendermaßen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Lesen Sie die Excel‑Datei als Byte‑Array.
4. Fügen Sie das [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) zur Folie hinzu und übergeben Sie das Byte‑Array sowie weitere Informationen zum OLE‑Objekt.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel‑Datei als OLE‑Objekt‑Frame in eine Folie eingefügt, wobei Aspose.Slides for Python via Java verwendet wurde.
**Hinweis** dass der [OleEmbeddedDataInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleembeddeddatainfo/)‑Konstruktor die Dateienserweiterung des einbettbaren Objekts als zweiten Parameter erhält. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE‑Objekts auszuwählen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Daten für das OLE-Objekt vorbereiten.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Den OLE-Objektrahmen zur Folie hinzufügen.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Verknüpfte OLE‑Objekt‑Frames hinzufügen**

Aspose.Slides for Python via Java ermöglicht das Hinzufügen eines [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) ohne Einbetten von Daten, sondern nur mit einem Link zur Datei.

Dieser Python‑Code zeigt, wie Sie ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) mit einer verknüpften Excel‑Datei zu einer Folie hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # OLE-Objektrahmen mit einer verknüpften Excel-Datei hinzufügen.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Auf OLE‑Objekt‑Frames zugreifen**

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie es wie folgt leicht finden oder darauf zugreifen:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse erstellen.
2. Holen Sie sich die Referenz der Folie über ihren Index.
3. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/)‑Form zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die nur eine Form auf der ersten Folie enthält. Anschließend haben wir geprüft, dass das Objekt ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) ist. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) und seine Dateidaten abgerufen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Eingebettete Dateidaten abrufen.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Erweiterung der eingebetteten Datei abrufen.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Eigenschaften von verknüpften OLE‑Objekt‑Frames abrufen**

Aspose.Slides ermöglicht den Zugriff auf Eigenschaften verknüpfter OLE‑Objekt‑Frames.

Dieser Python‑Code zeigt, wie Sie prüfen, ob ein OLE‑Objekt verknüpft ist, und anschließend den Pfad zur verknüpften Datei ermitteln:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Prüfen, ob das OLE-Objekt verknüpft ist.
        if ole_frame.isObjectLink():
            # Den vollständigen Pfad zur verknüpften Datei ausgeben.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Den relativen Pfad zur verknüpften Datei ausgeben, falls vorhanden.
            # Nur PPT-Präsentationen können den relativen Pfad enthalten.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE‑Objektdaten ändern**

{{% alert color="info" title="Hinweis" %}}

In diesem Abschnitt verwendet das nachfolgende Code‑Beispiel [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Ist ein OLE‑Objekt bereits in einer Folie eingebettet, können Sie dieses Objekt leicht zugreifen und dessen Daten wie folgt ändern:

1. Laden Sie eine Präsentation mit dem eingebetteten OLE‑Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse erstellen.
2. Holen Sie sich die Referenz der Folie über ihren Index.
3. Greifen Sie auf die OLE‑Objekt‑Frame‑Form zu.  
   In unserem Beispiel haben wir die zuvor erstellte PPTX‑Datei verwendet, die eine Form auf der ersten Folie enthält. Anschließend haben wir geprüft, dass das Objekt ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) ist. Dies war der gewünschte OLE‑Objekt‑Frame, auf den zugegriffen werden sollte.
4. Sobald der OLE‑Objekt‑Frame zugänglich ist, können Sie beliebige Operationen darauf ausführen.
5. Erstellen Sie ein [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑Objekt und greifen Sie auf die OLE‑Daten zu.
6. Greifen Sie auf das gewünschte [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) zu und ändern Sie die Daten.
7. Speichern Sie das aktualisierte [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) in einem Stream.
8. Ändern Sie die OLE‑Objektdaten aus dem Stream.

Im folgenden Beispiel wird ein OLE‑Objekt‑Frame (ein eingebettetes Excel‑Diagramm) abgerufen und dessen Dateidaten geändert, um die Diagrammdaten zu aktualisieren.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # OLE-Objektdaten als Workbook-Objekt einlesen.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Arbeitsmappendaten ändern.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE-Frame-Objektdaten ändern.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Andere Dateitypen in Folien einbetten**

Neben Excel‑Diagrammen ermöglicht Aspose.Slides for Python via Java das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML‑, PDF‑ und ZIP‑Dateien als Objekte einfügen. Wenn ein Benutzer das eingefügte Objekt doppelklickt, wird es automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zur Öffnung auszuwählen.

Dieser Python‑Code zeigt, wie Sie HTML und ZIP in eine Folie einbetten:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dateitypen für eingebettete Objekte festlegen**

Beim Arbeiten mit Präsentationen kann es nötig sein, alte OLE‑Objekte durch neue zu ersetzen oder ein nicht unterstütztes OLE‑Objekt durch ein unterstütztes zu ersetzen. Aspose.Slides for Python via Java ermöglicht das Festlegen des Dateityps für ein eingebettetes Objekt, sodass Sie die OLE‑Frame‑Daten oder seine Erweiterung aktualisieren können.

Dieser Python‑Code zeigt, wie Sie den Dateityp für ein eingebettetes OLE‑Objekt auf `zip` setzen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Dateityp auf ZIP ändern.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Symbolbilder und Titel für eingebettete Objekte festlegen**

Nach dem Einbetten eines OLE‑Objekts wird automatisch eine Vorschau bestehend aus einem Symbolbild hinzugefügt. Diese Vorschau sehen Benutzer, bevor sie das OLE‑Objekt öffnen oder darauf zugreifen. Wenn Sie ein bestimmtes Bild und einen Text als Elemente der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides for Python via Java festlegen.

Dieser Python‑Code zeigt, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Ein Bild zu den Präsentationsressourcen hinzufügen.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Titel und Bild für die OLE-Vorschau festlegen.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verhindern, dass ein OLE‑Objektrahmen in Größe und Position geändert wird**

Nachdem Sie ein verknüpftes OLE‑Objekt zu einer Präsentationsfolie hinzugefügt haben, kann beim Öffnen der Präsentation in PowerPoint eine Meldung erscheinen, die Sie auffordert, die Verknüpfungen zu aktualisieren. Das Anklicken der Schaltfläche „Update Links“ kann die Größe und Position des OLE‑Objektrahmens ändern, weil PowerPoint die Daten des verknüpften OLE‑Objekts aktualisiert und die Objektvorschau neu erstellt. Um zu verhindern, dass PowerPoint auffordert, die Daten des Objekts zu aktualisieren, setzen Sie die Methode [setUpdateAutomatic](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) der Klasse [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) auf `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eingebettete Dateien extrahieren**

Aspose.Slides for Python via Java ermöglicht das Extrahieren der in Folien als OLE‑Objekte eingebetteten Dateien wie folgt:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, die die OLE‑Objekte enthält, die Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/)‑Formen zu.
3. Greifen Sie auf die Daten der eingebetteten Dateien aus OLE‑Objekt‑Frames zu und schreiben Sie sie auf die Festplatte.

Dieser Python‑Code zeigt, wie Sie Dateien, die in einer Folie als OLE‑Objekte eingebettet sind, extrahieren:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Wird der OLE‑Inhalt beim Exportieren von Folien zu PDF/Bildern gerendert?**

Es wird das gerendert, was auf der Folie sichtbar ist – das Symbol/Ersetzungssymbol (Vorschau). Der „Live“‑OLE‑Inhalt wird beim Rendern nicht ausgeführt. Bei Bedarf können Sie Ihr eigenes Vorschaubild festlegen, um das erwartete Erscheinungsbild im exportierten PDF sicherzustellen.

**Wie kann ich ein OLE‑Objekt auf einer Folie sperren, sodass Benutzer es in PowerPoint nicht verschieben/bearbeiten können?**

Sperren Sie die Form: Aspose.Slides bietet [Form‑Sperren](/slides/de/python-java/applying-protection-to-presentation/). Das ist keine Verschlüsselung, verhindert jedoch effektiv versehentliche Änderungen und Bewegungen.

**Warum „springt“ ein verknüpftes Excel‑Objekt oder ändert seine Größe, wenn ich die Präsentation öffne?**

PowerPoint kann die Vorschau des verknüpften OLE‑Objekts aktualisieren. Für ein stabiles Erscheinungsbild sollten Sie die bewährten Verfahren aus der [Working Solution for Worksheet Resizing](/slides/de/python-java/working-solution-for-worksheet-resizing/) befolgen – entweder den Rahmen an den Bereich anpassen oder den Bereich an einen festen Rahmen skalieren und ein passendes Ersetzungssymbol festlegen.

**Werden relative Pfade für verknüpfte OLE‑Objekte im PPTX‑Format erhalten bleiben?**

Im PPTX‑Format gibt es keine Informationen zu „relativen Pfaden“ – nur den vollständigen Pfad. Relative Pfade finden sich im älteren PPT‑Format. Für Portabilität sollten Sie zuverlässige absolute Pfade/zugängliche URIs oder das Einbetten bevorzugen.