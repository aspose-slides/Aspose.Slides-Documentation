---
title: Arbeitslösung für Diagrammskalierung in PPTX
type: docs
weight: 60
url: /de/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammskalierung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Behebt unerwartete Diagrammskalierung in PPTX bei Verwendung eingebetteter Excel-OLE-Objekte mit Aspose.Slides für C++. Erfahren Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---

## **Hintergrund**

Es wurde beobachtet, dass Excel‑Diagramme, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet werden, nach ihrer ersten Aktivierung auf einen nicht spezifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem sichtbaren Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose‑Team hat das Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Behebung.

Im [vorherigen Artikel](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells für C++ ein Excel‑Diagramm erstellt und es mit Aspose.Slides für C++ in einer PowerPoint‑Präsentation als OLE‑Objekt einbettet. Um das [Objekt‑Vorschau‑Problem](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/) zu adressieren, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. In der Ausgabedatei wird beim Doppelklick auf den OLE‑Objektrahmen, der das Diagrammbild anzeigt, das Excel‑Diagramm aktiviert. Endbenutzer können Änderungen in der zugrunde liegenden Excel‑Arbeitsmappe vornehmen und dann zur entsprechenden Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenstermmaß hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objektrahmen hat jedoch seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe über die Größe und erhalten das korrekte Größenverhältnis als Teil des Einbettungsprozesses. Abhängig von den Unterschieden zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objektrahmens kommt es zur Skalierung.

## **Funktionierende Lösung**

Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint‑Präsentationen mit Aspose.Slides für C++.

**Szenario 1:** Erstellen einer Präsentation basierend auf einer vorhandenen Vorlage.

**Szenario 2:** Erstellen einer Präsentation von Grund auf.

Die hier bereitgestellte Lösung gilt für beide Szenarien. Die Basis aller Lösungsansätze ist dieselbe: **Die Fenstergröße des eingebetteten OLE‑Objekts muss der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien entsprechen**. Im Folgenden werden die beiden Ansätze zu dieser Lösung erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie mit der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien übereinstimmt.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen darauf basierend erzeugen. Es gibt eine Form mit Index 2 in der Vorlage, in die wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe einfügen wollen. In diesem Szenario ist die Größe des OLE‑Objektrahmens vordefiniert – sie entspricht der Größe der Form mit Index 2 in der Vorlage. Alles, was wir tun müssen, ist, die Fenstergröße der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Auszug erfüllt diesen Zweck:
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definiere die Diagrammgröße mit einem Fenster. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 72 Pixel pro Zoll verwendet).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Speichere die Arbeitsmappe in einen Speicherstrom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**Szenario 2**

Nehmen wir an, wir wollen eine Präsentation von Grund auf erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einbinden. Im folgenden Code‑Auszug erzeugen wir einen OLE‑Objektrahmen, der 4 Zoll hoch und 9,5 Zoll breit ist, bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Excel‑Arbeitsmappen‑Fenster auf dieselbe Größe – 4 Zoll hoch und 9,5 Zoll breit.
```cpp
// Unsere gewünschte Höhe.
int32_t desiredHeight = 288; // 4 Zoll (4 * 72)

// Unsere gewünschte Breite.
int32_t desiredWidth = 684; // 9,5 Zoll (9.5 * 72)

// Definiere die Diagrammgröße mit einem Fenster. 
chart->SetSizeWithWindow(true);

// Setze die Fensterbreite der Arbeitsmappe in Zoll.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Speichere die Arbeitsmappe in einen Speicherstrom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie man die Größe des Diagramms in der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der Größe des OLE‑Objektrahmens in der PowerPoint‑Folien entspricht. Dieser Ansatz ist sinnvoll, wenn die Diagrammgröße im Voraus bekannt ist und sich nie ändern wird.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen darauf basierend erzeugen. Es gibt eine Form mit Index 2 in der Vorlage, in die wir einen OLE‑Rahmen mit einer eingebetteten Excel‑Arbeitsmappe einfügen wollen. In diesem Szenario ist die Größe des OLE‑Rahmens vordefiniert – sie entspricht der Größe der Form mit Index 2 in der Vorlage. Alles, was wir tun müssen, ist, die Diagrammgröße in der Arbeitsmappe auf die Größe dieser Form zu setzen. Der folgende Code‑Auszug erfüllt diesen Zweck:
```cpp
// Definiere die Diagrammgröße ohne Fenster. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Setze die Diagrammbreite in Pixel (multipliziere mit 96, da Excel 96 Pixel pro Zoll verwendet).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Setze die Diagrammhöhe in Pixel.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Definiere die Druckgröße des Diagramms.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Speichere die Arbeitsmappe in einen Speicherstrom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**Szenario 2**

Angenommen, wir wollen eine Präsentation von Grund auf erstellen und einen OLE‑Objektrahmen beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einbinden. Im folgenden Code‑Auszug erzeugen wir einen OLE‑Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll auf der Folie bei x = 0,5 Zoll und y = 1 Zoll. Wir setzen zudem die entsprechende Diagrammgröße auf dieselben Maße: eine Höhe von 4 Zoll und eine Breite von 9,5 Zoll.
```cpp
// Unsere gewünschte Höhe.
int32_t desiredHeight = 288; // 4 Zoll (4 * 576)

// Unsere gewünschte Breite.
int32_t desiredWidth = 684; // 9,5 Zoll(9.5 * 576)

// Definiere die Diagrammgröße ohne Fenster. 
chart->SetSizeWithWindow(false);

// Setze die Diagrammbreite in Pixel.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Setze die Diagrammhöhe in Pixel.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Speichere die Arbeitsmappe in einen Speicherstrom.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Erstelle einen OLE-Objektrahmen mit den eingebetteten Excel-Daten.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Fazit**

Es gibt zwei Ansätze zur Behebung des Problems mit der Diagramm‑Skalierung. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zudem gibt es keine Beschränkung der Größe des OLE‑Objektrahmens in dieser Lösung.

## **FAQ**

**Warum ändert meine eingebettete Excel‑Diagramm nach der Aktivierung in PowerPoint die Größe?**

Dies geschieht, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zur Skalierung führen kann.

**Lässt sich dieses Skalierungsproblem vollständig verhindern?**

Ja. Wenn Sie die Fenstergröße der Excel‑Arbeitsmappe oder die Diagrammgröße vor dem Einbetten an die Größe des OLE‑Objektrahmens anpassen, bleiben die Diagrammgrößen konsistent.

**Welchen Ansatz sollte ich wählen, Fenstergröße oder Diagrammgröße?**

Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und später eventuell eine Größenänderung zulassen möchten.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammdimensionen feststehen und sich nach dem Einbetten nicht ändern.

**Funktionieren diese Methoden sowohl bei vorlagenbasierten als auch bei neuen Präsentationen?**

Ja. Beide Ansätze funktionieren gleich für Präsentationen, die aus Vorlagen oder von Grund auf erstellt werden.

**Gibt es eine Begrenzung für die Größe des OLE‑Objektrahmens?**

Nein. Der OLE‑Rahmen kann beliebig groß gesetzt werden, solange er angemessen zur Arbeitsmappe bzw. zum Diagramm skaliert.

**Kann ich diese Methoden mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Die Beispiele sind für Excel‑Diagramme konzipiert, die mit Aspose.Cells erstellt wurden, aber die Prinzipien gelten auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern sie ähnliche Größenoptionen unterstützen.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)