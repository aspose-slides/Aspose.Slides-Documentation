---
title: Arbeitslösung für Diagrammskalierung in PPTX
type: docs
weight: 40
url: /de/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammskalierung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Unerwartete Diagrammskalierung in PPTX beheben, wenn eingebettete Excel OLE-Objekte mit Aspose.Slides for Python via Java verwendet werden. Lernen Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---
## **Hintergrund**

Es wurde beobachtet, dass in PowerPoint‑Präsentationen eingebettete Excel‑Diagramme als OLE‑Objekte über Aspose‑Komponenten nach ihrer ersten Aktivierung auf einen nicht spezifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem auffälligen visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose‑Team hat das Problem ausführlich untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Behebung.

Im [vorherigen Artikel](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells for Python via Java ein Excel‑Diagramm erstellt und es mit Aspose.Slides for Python via Java in eine PowerPoint‑Präsentation einbettet. Um das [Objekt‑Vorschau‑Problem](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. In der Ergebnis‑Präsentation wird das OLE‑Objekt‑Rahmen, das das Diagrammbild anzeigt, durch Doppelklick aktiviert. Endbenutzer können gewünschte Änderungen in der zugrunde liegenden Excel‑Arbeitsmappe vornehmen und dann zur entsprechenden Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert abhängig von den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe über eine eigene Fenstergröße verfügt, versucht sie bei der ersten Aktivierung, ihre ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hat jedoch seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei Aktivierung der Arbeitsmappe die Größe und erhalten die korrekten Proportionen im Rahmen des Einbettungsprozesses. Abhängig von den Unterschieden zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objektrahmens kommt es zur Größenanpassung.

## **Lösungsansatz**

Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint‑Präsentationen mit Aspose.Slides for Python via Java.

**Szenario 1:** Erstellung einer Präsentation basierend auf einer vorhandenen Vorlage.

**Szenario 2:** Erstellung einer Präsentation von Grund auf.

Die hier bereitgestellte Lösung gilt für beide Szenarien. Die Grundlage aller Lösungsansätze ist identisch: **die Fenstergröße des eingebetteten OLE‑Objekts muss der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien entsprechen**. Im Folgenden werden die beiden Ansätze zu dieser Lösung erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie die Fenstergröße der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien entspricht.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, in der Vorlage befindet sich an Index 2 eine Form, in der wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Objektrahmens vorgegeben – sie entspricht der Größe der Form an Index 2 in der Vorlage. Alles, was wir tun müssen, ist die Fenstergröße der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Abschnitt dient diesem Zweck:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laden Sie die Excel-Arbeitsmappe, die das Diagramm enthält.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Setzen Sie die Fenstergröße der Arbeitsmappe in Zoll (PowerPoint verwendet 72 Punkte pro Zoll).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Speichern Sie die Arbeitsmappe in einen Speicherstream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Erstellen Sie einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Szenario 2**

Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Abschnitt erstellen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Fenster der Excel‑Arbeitsmappe auf dieselbe Größe – 4 Zoll hoch und 9,5 Zoll breit.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpide.JClass("java.io.ByteArrayOutputStream")

# Laden Sie die Excel-Arbeitsmappe, die das Diagramm enthält.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 Zoll (4 * 72).
    desired_width = 684  # 9,5 Zoll (9.5 * 72).

    # Diagrammgröße mit Fenster festlegen.
    chart.setSizeWithWindow(True)

    # Setzen Sie die Fenstergröße der Arbeitsmappe in Zoll (PowerPoint verwendet 72 Punkte pro Zoll).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Arbeitsmappe in einen Speicherstream speichern.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # OLE-Objektrahmen mit den eingebetteten Excel-Daten erstellen.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie die Größe des Diagramms in der eingebetteten Excel‑Arbeitsmappe so eingestellt wird, dass sie der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien entspricht. Dieser Ansatz ist nützlich, wenn die Diagrammgröße im Voraus bekannt ist und sich nie ändern wird.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten darauf basierend Präsentationen erstellen. Nehmen wir an, in der Vorlage befindet sich an Index 2 eine Form, in der wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe platzieren möchten. In diesem Szenario ist die Größe des OLE‑Rahmens vorgegeben – sie entspricht der Größe der Form an Index 2 in der Vorlage. Alles, was wir tun müssen, ist die Diagrammgröße in der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Abschnitt dient diesem Zweck:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laden Sie die Excel-Arbeitsmappe, die das Diagramm enthält.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definieren Sie die Diagrammgröße ohne Fenster.
    chart.setSizeWithWindow(False)

    # Setzen Sie die Diagrammgröße in Pixeln (Excel verwendet 96 Pixel pro Zoll).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definieren Sie die Diagrammdruckgröße.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Speichern Sie die Arbeitsmappe in einen Speicherstream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Erstellen Sie einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Szenario 2**:

Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Abschnitt erstellen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll auf der Folie bei x = 0,5 Zoll und y = 1 Zoll. Wir setzen außerdem die zugehörige Diagrammgröße auf dieselben Abmessungen: eine Höhe von 4 Zoll und eine Breite von 9,5 Zoll.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laden Sie die Excel-Arbeitsmappe, die das Diagramm enthält.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 Zoll (4 * 72).
    desired_width = 684  # 9.5 Zoll (9.5 * 72).

    # Definieren Sie die Diagrammgröße ohne Fenster.
    chart.setSizeWithWindow(False)

    # Setzen Sie die Diagrammgröße in Pixeln (Excel verwendet 96 Pixel pro Zoll).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Speichern Sie die Arbeitsmappe in einen Speicherstream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Erstellen Sie einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Fazit**

Es gibt zwei Ansätze zur Behebung des Diagramm‑Skalierungsproblems. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Außerdem gibt es in dieser Lösung keine Begrenzung der Größe des OLE‑Objektrahmens.

## **FAQ**

**Warum ändert meine eingebettete Excel‑Diagramm nach der Aktivierung in PowerPoint die Größe?**

Das passiert, weil Excel bei der ersten Aktivierung versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Skalierung führen kann.

**Kann dieses Skalierungsproblem vollständig verhindert werden?**

Ja. Durch das Angleichen der Fenstergröße der Excel‑Arbeitsmappe oder der Diagrammgröße an die Größe des OLE‑Objektrahmens vor dem Einbetten können die Diagrammgrößen konsistent gehalten werden.

**Welchen Ansatz sollte ich wählen, die Fenstergröße der Arbeitsmappe festzulegen oder die Diagrammgröße?**

Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und ggf. später eine Größenänderung zulassen wollen.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammabmessungen fest sind und sich nach dem Einbetten nicht mehr ändern.

**Werden diese Methoden sowohl bei vorlagenbasierten als auch bei neuen Präsentationen funktionieren?**

Ja. Beide Ansätze funktionieren gleichermaßen für aus Vorlagen erstellte und von Grund auf neu erstellte Präsentationen.

**Gibt es eine Begrenzung der Größe des OLE‑Objektrahmens?**

Nein. Der OLE‑Rahmen kann auf jede Größe eingestellt werden, solange er angemessen zum Arbeitsmappen‑ oder Diagrammgröße skaliert.

**Kann ich diese Methoden mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Die Beispiele sind für Excel‑Diagramme konzipiert, die mit Aspose.Cells erstellt wurden, aber die Prinzipien gelten auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern sie ähnliche Größenoptionen unterstützen.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)