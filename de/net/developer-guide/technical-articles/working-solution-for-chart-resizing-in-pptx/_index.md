---
title: Funktionierende Lösung für das Skalieren von Diagrammen in PPTX
type: docs
weight: 60
url: /net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in einer PowerPoint-Präsentation eingebettete Excel-Diagramme als OLE über Aspose-Komponenten beim ersten Aktivieren auf einen nicht identifizierten Maßstab skaliert werden. Dieses Verhalten erzeugt einen erheblichen visuellen Unterschied zwischen dem Zustand der Präsentation vor und nach der Diagrammaktivierung. Das Aspose-Team hat gemeinsam mit dem Microsoft-Team dieses Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel behandelt die Ursachen und die Lösung für dieses Problem. 

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für .NET erstellt und dieses Diagramm weiter in eine PowerPoint-Präsentation mit Aspose.Slides für .NET einbettet. Um das [Problem mit den geänderten Objekten](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) zu berücksichtigen, haben wir das Diagrammbild dem OLE-Objekt-Frame des Diagramms zugewiesen. In der Ausgabpräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objekt-Frame mit dem Diagrammbild doppelklicken. Die Endbenutzer können alle gewünschten Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur betreffenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objekt-Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor wird für unterschiedliche Größen des OLE-Objekt-Frames und eingebetteten Excel-Arbeitsmappen unterschiedlich sein. 
## **Ursache der Skalierung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe beim ersten Aktivieren beizubehalten. Andererseits hat der OLE-Objekt-Frame seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe die Größe und stellen sicher, dass diese im richtigen Maßstab im Rahmen des Einbettungsprozesses erfolgt. Basierend auf den Unterschieden in der Excel-Fenstergröße und der OLE-Objekt-Frame-Größe / -Position erfolgt die Skalierung. 
## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien für die Erstellung der PowerPoint-Präsentationen mit Aspose.Slides für .NET. 

**Szenario 1:** Erstellen Sie die Präsentation basierend auf einer bestehenden Vorlage 

**Szenario 2:** Erstellen Sie die Präsentation von Grund auf. 

Die Lösung, die wir hier bereitstellen, ist für beide Szenarien gültig. Die Grundlage aller Lösungsansätze wird dieselbe sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte die gleiche sein wie die des OLE-Objekt-Frames** **in der PowerPoint-Folie**. Nun werden wir die beiden Ansätze der Lösung diskutieren. 
## **Erster Ansatz**
In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel-Arbeitsmappe der Größe des OLE-Objekt-Frames in der PowerPoint-Folie anpasst. 

**Szenario 1** 

Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Frame mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Objekt-Frames als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Setzen Sie die Fenstergröße der Arbeitsmappe gleich der Größe der Form. Der folgende Codeausschnitt dient diesem Zweck: 

```c#
//definieren Sie die Diagrammgröße mit Fenster 
chart.SizeWithWindow = true;

//setzen Sie die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 
//72 Pixel / Zoll verwendet)
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//setzen Sie die Fensterhöhe der Arbeitsmappe in Zoll
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//Instanziieren Sie MemoryStream
MemoryStream ms = wb.SaveToStream();

//Erstellen Sie einen OLE-Objekt-Frame mit eingebettetem Excel
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**Szenario 2** 

Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objekt-Frame einer beliebigen Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Codeausschnitt haben wir einen OLE-Objekt-Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie an der x-Achse = 0,5 Zoll und der y-Achse = 1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Fenstergröße der Excel-Arbeitsmappe festgelegt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll. 

```c#
 //Unsere gewünschte Höhe
int desiredHeight = 288;//4 Zoll (4 * 72)

//Unsere gewünschte Breite
int desiredWidth = 684;//9,5 Zoll (9,5 * 72)

//definieren Sie die Diagrammgröße mit Fenster
chart.SizeWithWindow = true;

//setzen Sie die Fensterbreite der Arbeitsmappe in Zoll
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//setzen Sie die Fensterhöhe der Arbeitsmappe in Zoll
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//Instanziieren Sie MemoryStream
MemoryStream ms = wb.SaveToStream();

//Erstellen Sie einen OLE-Objekt-Frame mit eingebettetem Excel
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```



## **Zweiter Ansatz**
In diesem Ansatz lernen wir, wie man die Diagrammgröße in der eingebetteten Excel-Arbeitsmappe der Größe des OLE-Objekt-Frames in der PowerPoint-Folie anpasst. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Voraus bekannt ist und sich nie ändern wird. 

**Szenario 1** 

Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Frame mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Frames als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Setzen Sie die Größe des Diagramms in der Arbeitsmappe gleich der Größe der Form. Der folgende Codeausschnitt dient diesem Zweck: 

```c#
//definieren Sie die Diagrammgröße ohne Fenster 
chart.SizeWithWindow = false;

//setzen Sie die Diagrammbreite in Pixel (Multiplizieren mit 96, da Excel 96 Pixel pro Zoll verwendet)    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//setzen Sie die Diagrammhöhe in Pixel
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//Definieren Sie die Druckgröße des Diagramms
chart.PrintSize = PrintSizeType.Custom;

//Instanziieren Sie MemoryStream
MemoryStream ms = wb.SaveToStream();

//Erstellen Sie einen OLE-Objekt-Frame mit eingebettetem Excel
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());

```




**Szenario 2** 

Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objekt-Frame einer beliebigen Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Codeausschnitt haben wir einen OLE-Objekt-Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie an der x-Achse = 0,5 Zoll und der y-Achse = 1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Diagrammgröße festgelegt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll. 

```c#
 //Unsere gewünschte Höhe
int desiredHeight = 288;//4 Zoll (4 * 576)

//Unsere gewünschte Breite
int desiredWidth = 684;//9,5 Zoll (9,5 * 576)

//definieren Sie die Diagrammgröße ohne Fenster 
chart.SizeWithWindow = false;

//setzen Sie die Diagrammbreite in Pixel    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//setzen Sie die Diagrammhöhe in Pixel    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//Instanziieren Sie MemoryStream
MemoryStream ms = wb.SaveToStream();

//Erstellen Sie einen OLE-Objekt-Frame mit eingebettetem Excel
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```


## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze zur Behebung des Problems der Diagrammskalierung. Die Auswahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt oder von Grund auf neu erstellt werden. Zudem gibt es keine Begrenzung der Größe des OLE-Objekt-Frames in der Lösung. 

{{% /alert %}} 
## **Verwandte Abschnitte**
[Erstellen und Einbetten eines Excel-Diagramms als OLE-Objekt in der Präsentation](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatisches Aktualisieren von OLE-Objekten](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)