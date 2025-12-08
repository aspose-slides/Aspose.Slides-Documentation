---
title: SmartArt-Shape-Knoten verwalten
type: docs
weight: 30
url: /de/net/manage-smartart-shape-node/
keywords:
- SmartArt
- SmartArt-Knoten
- SmartArt-Unterknoten
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "SmartArt-Knoten und Unterknoten in PowerPoint-Präsentationen in C# oder .NET verwalten"
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides for .NET hat die einfachste API bereitgestellt, um SmartArt‑Objekte auf einfachste Weise zu verwalten. Der folgende Beispielcode hilft, einen Knoten und einen untergeordneten Knoten innerhalb eines SmartArt‑Objekts hinzuzufügen.

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation mit einem SmartArt‑Objekt.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jedes Shape auf der ersten Folie.
- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArt.
- Fügen Sie einen neuen Knoten zur NodeCollection des SmartArt‑Objekts hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie nun einen untergeordneten Knoten zum neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.
```c#
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddNodes.pptx");

// Durchlaufen Sie jedes Shape auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Prüfen Sie, ob das Shape vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Shape zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Einen neuen SmartArt‑Knoten hinzufügen
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Text hinzufügen
        TemNode.TextFrame.Text = "Test";

        // Neuen untergeordneten Knoten im übergeordneten Knoten hinzufügen. Er wird am Ende der Sammlung hinzugefügt
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Text hinzufügen
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Präsentation speichern
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt‑Knoten an bestimmter Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie untergeordnete Knoten, die zu jeweiligen Knoten des SmartArt‑Objekts gehören, an einer bestimmten Position hinzugefügt werden.

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Fügen Sie ein SmartArt‑Objekt des Typs StackedList zur ausgewählten Folie hinzu.
- Greifen Sie auf den ersten Knoten des hinzugefügten SmartArt‑Objekts zu.
- Fügen Sie nun für den ausgewählten Knoten an Position 2 einen untergeordneten Knoten hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.
```c#
// Instanz einer Präsentation erstellen
Presentation pres = new Presentation();

// Zugriff auf die Präsentationsfolie
ISlide slide = pres.Slides[0];

// SmartArt IShape hinzufügen
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Zugriff auf den SmartArt-Knoten bei Index 0
ISmartArtNode node = smart.AllNodes[0];

// Neuen untergeordneten Knoten an Position 2 im übergeordneten Knoten hinzufügen
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Text hinzufügen
chNode.TextFrame.Text = "Sample Text Added";

// Präsentation speichern
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **SmartArt‑Knoten zugreifen**
Der folgende Beispielcode hilft, Knoten innerhalb eines SmartArt‑Objekts zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType des SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen des SmartArt‑Objekts festgelegt wird.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einem SmartArt‑Objekt.

- Erhalten Sie die Referenz der ersten Folie über deren Index.

- Durchlaufen Sie jedes Shape auf der ersten Folie.

- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArt.

- Durchlaufen Sie alle Knoten im SmartArt‑Objekt.

- Greifen Sie auf Informationen wie SmartArt‑Knotenposition, Ebene und Text zu und zeigen Sie diese an.
  ```c#
  // Laden Sie die gewünschte Präsentation
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Durchlaufen Sie jedes Shape auf der ersten Folie
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Prüfen Sie, ob das Shape vom Typ SmartArt ist
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Shape zu SmartArt casten
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Durchlaufen Sie alle Knoten innerhalb von SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Zugriff auf SmartArt-Knoten mit Index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Ausgabe der SmartArt-Knotenparameter
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```





## **SmartArt‑untergeordneten Knoten zugreifen**
Der folgende Beispielcode hilft, die zu jeweiligen Knoten eines SmartArt‑Objekts gehörenden untergeordneten Knoten zuzugreifen.

- Erstellen Sie eine Instanz der Klasse PresentationEx und laden Sie die Präsentation mit einem SmartArt‑Objekt.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jedes Shape auf der ersten Folie.
- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArtEx.
- Durchlaufen Sie alle Knoten im SmartArt‑Objekt.
- Für jeden ausgewählten SmartArt‑Knoten durchlaufen Sie alle untergeordneten Knoten des jeweiligen Knotens.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und zeigen Sie diese an.
```c#
// Gewünschte Präsentation laden
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Durchlaufen Sie jedes Shape auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Prüfen, ob das Shape vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Shape zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Durchlaufen aller Knoten im SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Zugriff auf SmartArt-Knoten mit Index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten mit Index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Ausgabe der SmartArt-Unterknoten-Parameter
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```





## **SmartArt‑untergeordneten Knoten an bestimmter Position zugreifen**
In diesem Beispiel lernen wir, auf die untergeordneten Knoten an einer bestimmten Position zuzugreifen, die zu jeweiligen Knoten eines SmartArt‑Objekts gehören.

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Fügen Sie ein SmartArt‑Objekt des Typs StackedList hinzu.
- Greifen Sie auf das hinzugefügte SmartArt‑Objekt zu.
- Greifen Sie auf den Knoten mit Index 0 des ausgewählten SmartArt‑Objekts zu.
- Greifen Sie nun mit der Methode GetNodeByPosition() auf den untergeordneten Knoten an Position 1 des ausgewählten SmartArt‑Knotens zu.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und zeigen Sie diese an.
```c#
 // Präsentation instanziieren
 Presentation pres = new Presentation();

 // Erste Folie zugreifen
 ISlide slide = pres.Slides[0];

 // SmartArt-Shape in erster Folie hinzufügen
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // SmartArt-Knoten mit Index 0 zugreifen
 ISmartArtNode node = smart.AllNodes[0];

 // Untergeordneten Knoten an Position 1 im übergeordneten Knoten zugreifen
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // Ausgabe der SmartArt-Unterknoten-Parameter
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```





## **SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, Knoten innerhalb eines SmartArt‑Objekts zu entfernen.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einem SmartArt‑Objekt.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jedes Shape auf der ersten Folie.
- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArt.
- Prüfen Sie, ob das SmartArt mehr als 0 Knoten enthält.
- Wählen Sie den zu löschenden SmartArt‑Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode() und speichern Sie die Präsentation.
```c#
// Lade die gewünschte Präsentation
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Durchlaufe jedes Shape auf der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Prüfe, ob das Shape vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Shape zu SmartArtEx casten
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Greife auf den SmartArt-Knoten mit Index 0 zu
                ISmartArtNode node = smart.AllNodes[0];

                // Entferne den ausgewählten Knoten
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Speichere die Präsentation
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **SmartArt‑Knoten an bestimmter Position entfernen**
In diesem Beispiel lernen wir, Knoten innerhalb eines SmartArt‑Objekts an einer bestimmten Position zu entfernen.

- Erstellen Sie eine Instanz der Klasse `Presentation` und laden Sie die Präsentation mit einem SmartArt‑Objekt.
- Erhalten Sie die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jedes Shape auf der ersten Folie.
- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArt.
- Wählen Sie den SmartArt‑Knoten mit Index 0 aus.
- Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten hat.
- Entfernen Sie nun den Knoten an Position 1 mit der Methode RemoveNodeByPosition().
- Speichern Sie die Präsentation.
```c#
 // Gewünschte Präsentation laden             
 Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Durchlaufen Sie jedes Shape auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Prüfen, ob das Shape vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Shape zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Zugriff auf den SmartArt-Knoten mit Index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Entfernen des untergeordneten Knotens an Position 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Präsentation speichern
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Benutzerdefinierte Position für untergeordneten Knoten in SmartArt festlegen**
Aspose.Slides for .NET unterstützt jetzt das Festlegen der X- und Y-Eigenschaften von SmartArtShape. Der nachstehende Codeausschnitt zeigt, wie Sie eine benutzerdefinierte Position, Größe und Drehung von SmartArtShape festlegen. Beachten Sie bitte, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht.
```c#
// Lade die gewünschte Präsentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Verschiebe das SmartArt-Shape an neue Position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Ändere die Breiten des SmartArt-Shape
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Ändere die Höhe des SmartArt-Shape
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Ändere die Drehung des SmartArt-Shape
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```




## **Assistant‑Knoten prüfen**
Im folgenden Beispielcode untersuchen wir, wie Assistant‑Knoten in der SmartArt‑Knotensammlung identifiziert und geändert werden können.

- Erstellen Sie eine Instanz der Klasse PresentationEx und laden Sie die Präsentation mit einem SmartArt‑Objekt.
- Erhalten Sie die Referenz der zweiten Folie über deren Index.
- Durchlaufen Sie jedes Shape innerhalb der ersten Folie.
- Prüfen Sie, ob das Shape vom Typ SmartArt ist, und casten Sie das ausgewählte Shape bei SmartArt zu SmartArtEx.
- Durchlaufen Sie alle Knoten im SmartArt‑Objekt und prüfen Sie, ob es Assistant‑Knoten sind.
- Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
- Speichern Sie die Präsentation.
```c#
// Präsentationsinstanz erstellen
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Durchlaufen aller Shapes auf der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Prüfen, ob das Shape vom Typ SmartArt ist
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Shape zu SmartArtEx casten
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Durchlaufen aller Knoten des SmartArt-Shapes

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Prüfen, ob der Knoten ein Assistent-Knoten ist
                if (node.IsAssistant)
                {
                    // Assistent-Knoten auf false setzen und zu normalem Knoten machen
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Präsentation speichern
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Füllformat des Knotens festlegen**
Aspose.Slides for .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Objekte und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie SmartArt‑Objekte erstellt und zugegriffen und deren Füllformat mit Aspose.Slides for .NET festgelegt wird.

Bitte folgen Sie den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse `Presentation`.
- Erhalten Sie die Referenz einer Folie über deren Index.
- Fügen Sie ein SmartArt‑Objekt hinzu, indem Sie dessen LayoutType festlegen.
- Legen Sie das FillFormat für die SmartArt‑Knoten fest.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.
```c#
using (Presentation presentation = new Presentation())
{
    // Zugriff auf die Folie
    ISlide slide = presentation.Slides[0];

    // Hinzufügen von SmartArt-Shape und Knoten
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Festlegen der Füllfarbe des Knotens
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Speichern der Präsentation
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```




## **Miniaturbild des SmartArt‑untergeordneten Knotens erstellen**
Entwickler können ein Miniaturbild eines untergeordneten Knotens eines SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Instanziieren Sie die Klasse `Presentation`, die die PPTX-Datei darstellt.
2. Fügen Sie SmartArt hinzu.
3. Erhalten Sie die Referenz eines Knotens über dessen Index
4. Ermitteln Sie das Miniaturbild.
5. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Miniaturbild des SmartArt‑untergeordneten Knotens
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```


## **FAQ**

**Unterstützt Aspose.Slides SmartArt-Animationen?**

Ja. SmartArt wird wie ein normales Shape behandelt, sodass Sie [Standardanimationen](/slides/de/net/shape-animation/) (Eintritt, Austritt, Betonung, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Shapes innerhalb von SmartArt‑Knoten animieren.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie zuverlässig finden, wenn seine interne ID unbekannt ist?**

Weisen Sie ihm über [alternativen Text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) zu und suchen Sie danach. Das Setzen eines eindeutigen AltText auf dem SmartArt ermöglicht das programmgesteuerte Auffinden, ohne interne Kennungen zu verwenden.

**Wird das Aussehen von SmartArt beim Konvertieren der Präsentation in PDF beibehalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Genauigkeit beim [PDF-Export](/slides/de/net/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können ein SmartArt-Shape in [Rasterformate](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) oder in [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) rendern, wodurch ein skalierbarer Vektor‑Ausgabe entsteht, die sich für Miniaturbilder, Berichte oder Web‑Nutzung eignet.