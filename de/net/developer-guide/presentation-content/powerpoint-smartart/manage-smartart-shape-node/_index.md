---
title: Verwalten von SmartArt-Formknoten in Präsentationen in .NET
linktitle: SmartArt-Formknoten
type: docs
weight: 30
url: /de/net/manage-smartart-shape-node/
keywords:
- SmartArt-Knoten
- untergeordneter Knoten
- Knoten hinzufügen
- Knotenposition
- Knoten zugreifen
- Knoten entfernen
- benutzerdefinierte Position
- Assistenten-Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie SmartArt-Formknoten in PPT und PPTX mit Aspose.Slides für .NET. Erhalten Sie klare Codebeispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides für .NET bietet die einfachste API zur Verwaltung von SmartArt‑Formen auf einfachste Weise. Der folgende Beispielcode zeigt, wie ein Knoten und ein untergeordneter Knoten innerhalb einer SmartArt‑Form hinzugefügt werden.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Fügen Sie einen neuen Knoten zur NodeCollection der SmartArt‑Form hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie nun einen untergeordneten Knoten zum neu hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.
```c#
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("AddNodes.pptx");

// Durchlaufen aller Formen in der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Prüfen, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Form zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Hinzufügen eines neuen SmartArt-Knotens
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Text hinzufügen
        TemNode.TextFrame.Text = "Test";

        // Hinzufügen eines neuen untergeordneten Knotens im übergeordneten Knoten.  Es wird am Ende der Sammlung hinzugefügt
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Text hinzufügen
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Präsentation speichern
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie untergeordnete Knoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position hinzugefügt werden.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Fügen Sie der ausgewählten Folie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
- Fügen Sie nun den untergeordneten Knoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.
```c#
// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation();

// Zugriff auf die Präsentationsfolie
ISlide slide = pres.Slides[0];

// SmartArt-IShape hinzufügen
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


## **Auf einen SmartArt‑Knoten zugreifen**
Der folgende Beispielcode zeigt, wie auf Knoten innerhalb einer SmartArt‑Form zugegriffen wird. Bitte beachten Sie, dass der LayoutType der SmartArt nur lesbar ist und ausschließlich beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Greifen Sie auf Informationen wie Position, Ebene und Text des SmartArt‑Knotens zu und geben Sie sie aus.
  ```c#
  // Laden der gewünschten Präsentation
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Durchlaufen aller Formen in der ersten Folie
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Prüfen, ob die Form vom Typ SmartArt ist
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Form zu SmartArt casten
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Durchlaufen aller Knoten innerhalb von SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Zugriff auf SmartArt-Knoten bei Index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Ausgabe der SmartArt-Knotenparameter
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **Auf einen SmartArt‑untergeordneten Knoten zugreifen**
Der folgende Beispielcode zeigt, wie auf die untergeordneten Knoten der jeweiligen Knoten einer SmartArt‑Form zugegriffen wird.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Für jeden ausgewählten SmartArt‑Knoten durchlaufen Sie alle untergeordneten Knoten des jeweiligen Knotens.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und geben Sie sie aus.
```c#
 // Laden der gewünschten Präsentation
 Presentation pres = new Presentation("AccessChildNodes.pptx");

// Durchlaufen aller Formen in der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Prüfen, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Form zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Durchlaufen aller Knoten innerhalb von SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Zugriff auf SmartArt-Knoten bei Index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten bei Index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Ausgabe der SmartArt‑untergeordneten Knotenparameter
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```


## **Auf einen SmartArt‑untergeordneten Knoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man untergeordnete Knoten an einer bestimmten Position der jeweiligen Knoten einer SmartArt‑Form abruft.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Fügen Sie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
- Greifen Sie auf den Knoten mit Index 0 der ausgewählten SmartArt‑Form zu.
- Rufen Sie nun den untergeordneten Knoten an Position 1 des ausgewählten SmartArt‑Knotens mittels `GetNodeByPosition()`‑Methode ab.
- Greifen Sie auf Informationen wie Position, Ebene und Text des untergeordneten Knotens zu und geben Sie sie aus.
```c#
 // Instanziieren der Präsentation
 Presentation pres = new Presentation();

 // Zugriff auf die erste Folie
 ISlide slide = pres.Slides[0];

 // Hinzufügen der SmartArt-Form in der ersten Folie
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // Zugriff auf den SmartArt-Knoten bei Index 0
 ISmartArtNode node = smart.AllNodes[0];

 // Zugriff auf den untergeordneten Knoten an Position 1 im übergeordneten Knoten
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // Ausgabe der SmartArt-untergeordneten Knotenparameter
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```


## **Einen SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form entfernt werden.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Prüfen Sie, ob die SmartArt mehr als 0 Knoten enthält.
- Wählen Sie den zu löschenden SmartArt‑Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mittels `RemoveNode()`‑Methode und speichern Sie die Präsentation.
```c#
// Laden der gewünschten Präsentation
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form zu SmartArtEx casten
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Zugriff auf den SmartArt-Knoten bei Index 0
                ISmartArtNode node = smart.AllNodes[0];

                // Entfernen des ausgewählten Knotens
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Präsentation speichern
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Einen SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt werden.

- Erstellen Sie eine Instanz der `Presentation`‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
- Wählen Sie den SmartArt‑Knoten mit Index 0 aus.
- Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten besitzt.
- Entfernen Sie nun den Knoten an Position 1 mittels `RemoveNodeByPosition()`‑Methode.
- Speichern Sie die Präsentation.
```c#
// Laden der gewünschten Präsentation             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Durchlaufen aller Formen in der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Prüfen, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Form zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Zugriff auf den SmartArt-Knoten bei Index 0
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


## **Eine benutzerdefinierte Position für einen untergeordneten Knoten in einem SmartArt‑Objekt festlegen**
Aspose.Slides für .NET unterstützt jetzt das Setzen der X‑ und Y‑Eigenschaften von SmartArtShape. Der nachfolgende Code‑Auszug zeigt, wie benutzerdefinierte Position, Größe und Drehung einer SmartArt‑Form festgelegt werden können. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst.
```c#
// Laden der gewünschten Präsentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt-Form an neue Position verschieben
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Breite der SmartArt-Form ändern
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Höhe der SmartArt-Form ändern
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Drehung der SmartArt-Form ändern
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```


## **Einen Assistent‑Knoten überprüfen**
Im folgenden Beispielcode untersuchen wir, wie Assistent‑Knoten in der SmartArt‑Knoten‑Sammlung identifiziert und geändert werden.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der zweiten Folie über deren Index.
- Durchlaufen Sie jede Form in der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, falls sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie Assistent‑Knoten sind.
- Ändern Sie den Status des Assistent‑Knotens zu einem normalen Knoten.
- Speichern Sie die Präsentation.
```c#
// Erstellen einer Präsentationsinstanz
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Durchlaufen aller Formen in der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Form zu SmartArtEx casten
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Durchlaufen aller Knoten der SmartArt-Form

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Prüfen, ob der Knoten ein Assistent-Knoten ist
                if (node.IsAssistant)
                {
                    // Setzen des Assistent-Knotens auf false und Umwandeln in einen normalen Knoten
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Präsentation speichern
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Füllformat für einen Knoten festlegen**
Aspose.Slides für .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt, darauf zugegriffen und ihr Füllformat über Aspose.Slides für .NET gesetzt wird.

Bitte führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der `Presentation`‑Klasse.
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie eine SmartArt‑Form hinzu, indem Sie deren LayoutType festlegen.
- Setzen Sie das FillFormat für die Knoten der SmartArt‑Form.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```c#
using (Presentation presentation = new Presentation())
{
    // Zugriff auf die Folie
    ISlide slide = presentation.Slides[0];

    // Hinzufügen von SmartArt-Form und Knoten
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Festlegen der Füllfarbe des Knotens
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Präsentation speichern
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```


## **Ein Thumbnail eines SmartArt‑untergeordneten Knotens erzeugen**
Entwickler können ein Thumbnail eines untergeordneten Knotens einer SmartArt‑Form erzeugen, indem sie die folgenden Schritte ausführen:

1. Instanziieren Sie die `Presentation`‑Klasse, die die PPTX‑Datei repräsentiert.
2. Fügen Sie eine SmartArt‑Form hinzu.
3. Holen Sie sich die Referenz eines Knotens über dessen Index.
4. Erzeugen Sie das Thumbnail‑Bild.
5. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachfolgende Beispiel erzeugt ein Thumbnail eines SmartArt‑untergeordneten Knotens.
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

**Wird SmartArt‑Animation unterstützt?**

Ja. SmartArt wird wie eine normale Form behandelt, sodass Sie [Standard‑Animationen](/slides/de/net/shape-animation/) (Eingang, Ausgang, Hervorhebung, Motion‑Paths) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie finde ich zuverlässig ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn die interne ID unbekannt ist?**

Verwenden Sie und suchen Sie nach dem [alternativen Text]((https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)). Durch das Festlegen eines eindeutigen AltText für das SmartArt‑Objekt können Sie es programmgesteuert finden, ohne interne Kennungen zu benötigen.

**Wird das Aussehen von SmartArt beim Export in PDF erhalten bleiben?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/net/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild des gesamten SmartArt‑Objekts extrahieren (für Vorschaubilder oder Berichte)?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate]((https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)) oder in [SVG]((https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)) rendern, um skalierbare Vektorausgaben zu erhalten – ideal für Thumbnails, Berichte oder Web‑Nutzung.