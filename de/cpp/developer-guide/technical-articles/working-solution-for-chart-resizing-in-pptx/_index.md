---
title: Funktionierende Lösung für das Ändern der Größe von Diagrammen in PPTX
type: docs
weight: 60
url: /cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde festgestellt, dass in eine PowerPoint-Präsentation eingebettete Excel-Diagramme als OLE über Aspose-Komponenten nach der ersten Aktivierung auf einem unbekannten Maßstab skaliert werden. Dieses Verhalten führt zu einem erheblichen visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose-Team hat mit Unterstützung des Microsoft-Teams dieses Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel behandelt die Gründe und die Lösung für dieses Problem.

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für C++ erstellt und dieses Diagramm dann mit Aspose.Slides für C++ in eine PowerPoint-Präsentation einbettet. Um das Problem der Objektänderung zu berücksichtigen, haben wir das Diagrammbild auf den OLE-Objektrahmen des Diagramms zugewiesen. In der Ausgabpräsentation wird das Excel-Diagramm aktiviert, wenn wir den OLE-Objektrahmen, der das Diagrammbild anzeigt, doppelklicken. Die Endbenutzer können die gewünschten Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur betreffenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Größenänderungsfaktor wird für verschiedene Größen des OLE-Objektrahmens und der eingebetteten Excel-Arbeitsmappe unterschiedlich sein.

## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Andererseits hat der OLE-Objektrahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe die Größe und stellen sicher, dass sie im richtigen Verhältnis als Teil des Einbettungsprozesses vorliegt. Basierend auf den Unterschieden in der Fenstergröße von Excel und der Größe / Position des OLE-Objektrahmens findet die Größenänderung statt.

## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint-Präsentationen mit Aspose.Slides für C++. 

**Szenario 1:** Erstellen der Präsentation auf Basis einer vorhandenen Vorlage.

**Szenario 2:** Erstellen der Präsentation von Grund auf. 

Die Lösung, die wir hier bereitstellen werden, ist für beide Szenarien gültig. Die Grundlage aller Lösungsansätze wird gleich sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte der des OLE-Objektrahmens** **in der PowerPoint-Folie entsprechen**. Jetzt werden wir die beiden Ansätze der Lösung diskutieren. 

## **Erster Ansatz**
In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel-Arbeitsmappe entsprechend der Größe des OLE-Objektrahmens in der PowerPoint-Folie einstellt. 

**Szenario 1** 

Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen auf dieser Vorlage basieren. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Objektrahmens als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Setzen Sie die Fenstergröße der Arbeitsmappe gleich der Größe der Form. Der folgende Code-Ausschnitt dient diesem Zweck: 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// Diagrammgröße mit Fenster definieren 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// Fensterbreite der Arbeitsmappe in Zoll setzen (geteilt durch 72, da PowerPoint 
// 72 Pixel / Zoll verwendet)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Fensterhöhe der Arbeitsmappe in Zoll setzen
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Instanz von MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Erstellen eines OLE-Objektrahmens mit eingebettetem Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**Szenario 2** 

Angenommen, wir möchten eine Präsentation von Grund auf neu erstellen und wünschen uns einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Code-Ausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie an der x-Achse=0,5 Zoll und an der y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Fenstergröße der Excel-Arbeitsmappe eingestellt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll. 

``` cpp
// Unsere gewünschte Höhe
int32_t desiredHeight = 288; // 4 Zoll (4 * 72)

// Unsere gewünschte Breite
int32_t desiredWidth = 684; // 9,5 Zoll (9,5 * 72)

// Diagrammgröße mit Fenster definieren 
chart->SetSizeWithWindow(true);

// Fensterbreite der Arbeitsmappe in Zoll setzen
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Fensterhöhe der Arbeitsmappe in Zoll setzen
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Instanz von MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Erstellen eines OLE-Objektrahmens mit eingebettetem Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **Zweiter Ansatz**
In diesem Ansatz lernen wir, wie man die Diagrammgröße in der eingebetteten Excel-Arbeitsmappe entsprechend der Größe des OLE-Objektrahmens in der PowerPoint-Folie einstellt. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Voraus bekannt ist und sich niemals ändern wird. 

**Szenario 1** 

Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen auf dieser Vorlage basieren. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Rahmens als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Stellen Sie die Größe des Diagramms in der Arbeitsmappe gleich der Größe der Form ein. Der folgende Code-Ausschnitt dient diesem Zweck: 

``` cpp
// Diagrammgröße ohne Fenster definieren 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// Diagrammbreite in Pixeln setzen (mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Diagrammhöhe in Pixeln setzen
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Diagramm-Druckgröße definieren
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Instanz von MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Erstellen eines OLE-Objektrahmens mit eingebettetem Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**Szenario 2** 

Angenommen, wir möchten eine Präsentation von Grund auf neu erstellen und wünschen uns einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Code-Ausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie an der x-Achse=0,5 Zoll und an der y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Diagrammgröße eingestellt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll. 

``` cpp
// Unsere gewünschte Höhe
int32_t desiredHeight = 288; // 4 Zoll (4 * 576)

// Unsere gewünschte Breite
int32_t desiredWidth = 684; // 9,5 Zoll(9,5 * 576)

// Diagrammgröße ohne Fenster definieren 
chart->SetSizeWithWindow(false);

// Diagrammbreite in Pixeln setzen    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Diagrammhöhe in Pixeln setzen    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Instanz von MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Erstellen eines OLE-Objektrahmens mit eingebettetem Excel
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze zur Behebung des Problems der Größenänderung von Diagrammen. Die Auswahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf dieselbe Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt oder von Grund auf neu erstellt werden. Darüber hinaus gibt es keine Begrenzung der Größe des OLE-Objektrahmens in der Lösung. 

{{% /alert %}} 
## **Verwandte Abschnitte**
[Erstellen und Einbetten eines Excel-Diagramms als OLE-Objekt in einer Präsentation](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)