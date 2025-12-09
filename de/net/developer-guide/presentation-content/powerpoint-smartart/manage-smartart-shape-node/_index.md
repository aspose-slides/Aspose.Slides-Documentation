---
title: SmartArt‑Formknoten in Präsentationen mit .NET verwalten
linktitle: SmartArt‑Formknoten
type: docs
weight: 30
url: /de/net/manage-smartart-shape-node/
keywords:
- SmartArt‑Knoten
- Unterknoten
- Knoten hinzufügen
- Knotenposition
- Knotenzugriff
- Knoten entfernen
- benutzerdefinierte Position
- Assistant‑Knoten
- Füllformat
- Knoten rendern
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie SmartArt‑Formknoten in PPT und PPTX mit Aspose.Slides für .NET. Erhalten Sie klare Code‑Beispiele und Tipps, um Ihre Präsentationen zu optimieren."
---

## **SmartArt‑Knoten hinzufügen**
Aspose.Slides for .NET bietet die einfachste API, um SmartArt‑Formen auf einfachste Weise zu verwalten. Der folgende Beispielcode zeigt, wie ein Knoten und ein untergeordneter Knoten innerhalb einer SmartArt‑Form hinzugefügt werden.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn dies der Fall ist.
- Fügen Sie einen neuen Knoten zur NodeCollection der SmartArt‑Form hinzu und setzen Sie den Text im TextFrame.
- Fügen Sie nun einen untergeordneten Knoten zum gerade hinzugefügten SmartArt‑Knoten hinzu und setzen Sie den Text im TextFrame.
- Speichern Sie die Präsentation.
```c#
// Lade die gewünschte Präsentation
Presentation pres = new Presentation("AddNodes.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Prüfen Sie, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Casten Sie die Form zu SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Hinzufügen eines neuen SmartArt-Knotens
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Text hinzufügen
        TemNode.TextFrame.Text = "Test";

        // Hinzufügen eines neuen untergeordneten Knotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Text hinzufügen
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Präsentation speichern
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt‑Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode wird erklärt, wie die untergeordneten Knoten zu den jeweiligen Knoten einer SmartArt‑Form an einer bestimmten Position eingefügt werden.

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Fügen Sie der ausgewählten Folie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten der hinzugefügten SmartArt‑Form zu.
- Fügen Sie nun den untergeordneten Knoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.
```c#
// Eine Präsentationsinstanz erstellen
Presentation pres = new Presentation();

// Auf die Präsentationsfolie zugreifen
ISlide slide = pres.Slides[0];

// SmartArt IShape hinzufügen
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Zugriff auf den SmartArt-Knoten mit Index 0
ISmartArtNode node = smart.AllNodes[0];

// Neuen untergeordneten Knoten an Position 2 im übergeordneten Knoten hinzufügen
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Text hinzufügen
chNode.TextFrame.Text = "Sample Text Added";

// Präsentation speichern
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **SmartArt‑Knoten zugreifen**
Der folgende Beispielcode zeigt, wie auf Knoten innerhalb einer SmartArt‑Form zugegriffen werden kann. Bitte beachten Sie, dass der LayoutType der SmartArt nicht geändert werden kann, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt‑Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn dies der Fall ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Greifen Sie auf Informationen wie die Position des SmartArt‑Knotens, die Ebene und den Text zu und geben Sie sie aus.
```c#
  // Die gewünschte Präsentation laden
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Durchlaufen Sie jede Form auf der ersten Folie
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
              // Zugriff auf SmartArt-Knoten mit Index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Ausgabe der SmartArt-Knotenparameter
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```






## **SmartArt‑Unterknoten zugreifen**
Der folgende Beispielcode zeigt, wie auf die untergeordneten Knoten der jeweiligen Knoten einer SmartArt‑Form zugegriffen werden kann.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, wenn dies der Fall ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form.
- Für jeden ausgewählten SmartArt‑Knoten traversieren Sie alle untergeordneten Knoten des jeweiligen Knotens.
- Greifen Sie auf Informationen wie die Position des Unterknotens, die Ebene und den Text zu und geben Sie sie aus.
```c#
// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
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
            // Zugriff auf SmartArt-Knoten mit Index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Durchlaufen der untergeordneten Knoten im SmartArt-Knoten mit Index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Zugriff auf den untergeordneten Knoten im SmartArt-Knoten
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Ausgabe der SmartArt-Unterknotenparameter
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```




## **SmartArt‑Unterknoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man die untergeordneten Knoten an einer bestimmten Position zu den jeweiligen Knoten einer SmartArt‑Form zugreift.

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Fügen Sie eine SmartArt‑Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt‑Form zu.
- Greifen Sie auf den Knoten mit Index 0 der ausgewählten SmartArt‑Form zu.
- Greifen Sie nun mit der Methode GetNodeByPosition() auf den Unterknoten an Position 1 des ausgewählten SmartArt‑Knotens zu.
- Greifen Sie auf Informationen wie die Position des Unterknotens, die Ebene und den Text zu und geben Sie sie aus.
```c#
// Präsentation instanziieren
Presentation pres = new Presentation();

// Erste Folie zugreifen
ISlide slide = pres.Slides[0];

// SmartArt-Form in erster Folie hinzufügen
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// SmartArt‑Knoten an Index 0 zugreifen
ISmartArtNode node = smart.AllNodes[0];

// Untergeordneten Knoten an Position 1 im übergeordneten Knoten zugreifen
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Ausgabe der SmartArt‑Unterknotenparameter
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```




## **SmartArt‑Knoten entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form entfernt.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn dies der Fall ist.
- Prüfen Sie, ob die SmartArt mehr als 0 Knoten enthält.
- Wählen Sie den zu löschenden SmartArt‑Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode() und speichern Sie die Präsentation.
```c#
// Die gewünschte Präsentation laden
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Durchlaufen Sie jede Form auf der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Prüfen, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Form zu SmartArtEx casten
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Zugriff auf SmartArt-Knoten mit Index 0
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




## **SmartArt‑Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie man Knoten innerhalb einer SmartArt‑Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der ersten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn dies der Fall ist.
- Wählen Sie den SmartArt‑Knoten mit Index 0 aus.
- Prüfen Sie nun, ob der ausgewählte SmartArt‑Knoten mehr als 2 untergeordnete Knoten enthält.
- Entfernen Sie nun den Knoten an Position 1 mit der Methode RemoveNodeByPosition().
- Speichern Sie die Präsentation.
```c#
// Die gewünschte Präsentation laden
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Prüfen, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Form zu SmartArt casten
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Zugriff auf SmartArt-Knoten mit Index 0
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




## **Benutzerdefinierte Position für Unterknoten in SmartArt festlegen**
Jetzt unterstützt Aspose.Slides for .NET das Setzen der X‑ und Y‑Eigenschaften von SmartArtShape. Der nachstehende Codeausschnitt zeigt, wie benutzerdefinierte Position, Größe und Drehung einer SmartArtShape festgelegt werden können. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten auslöst.
```c#
// Die gewünschte Präsentation laden
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt-Form an neue Position verschieben
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Breiten der SmartArt-Form ändern
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




## **Assistant‑Knoten prüfen**
Im folgenden Beispielcode untersuchen wir, wie Assistant‑Knoten in der SmartArt‑Knoten‑Sammlung identifiziert und geändert werden können.

- Erstellen Sie eine Instanz der PresentationEx‑Klasse und laden Sie die Präsentation mit einer SmartArt‑Form.
- Holen Sie sich die Referenz der zweiten Folie über deren Index.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Prüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, wenn dies der Fall ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt‑Form und prüfen Sie, ob sie Assistant‑Knoten sind.
- Ändern Sie den Status des Assistant‑Knotens zu einem normalen Knoten.
- Speichern Sie die Präsentation.
```c#
 // Eine Präsentationsinstanz erstellen
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Durchlaufen jeder Form auf der ersten Folie
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
                    // Setzen des Assistent-Knotens auf false und ihn zu einem normalen Knoten machen
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
Aspose.Slides for .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie SmartArt‑Formen erstellt und zugegriffen sowie ihr Füllformat mit Aspose.Slides for .NET festgelegt wird.

Bitte folgen Sie den nachstehenden Schritten:

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




## **Miniaturansicht eines SmartArt‑Unterknotens erzeugen**
Entwickler können eine Miniaturansicht eines Unterknotens einer SmartArt erzeugen, indem sie die folgenden Schritte ausführen:

1. Instanziieren Sie die `Presentation`‑Klasse, die die PPTX‑Datei repräsentiert.
1. Fügen Sie SmartArt hinzu.
1. Holen Sie sich die Referenz eines Knotens über dessen Index.
1. Erzeugen Sie das Miniaturbild.
1. Speichern Sie das Miniaturbild in einem beliebigen Bildformat.

Das nachstehende Beispiel erzeugt eine Miniaturansicht eines SmartArt‑Unterknotens
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

Ja. SmartArt wird wie eine reguläre Form behandelt, sodass Sie [Standardanimationen](/slides/de/net/shape-animation/) (Eingang, Ausgang, Hervorhebung, Bewegungsbahnen) anwenden und das Timing anpassen können. Bei Bedarf können Sie auch Formen innerhalb von SmartArt‑Knoten animieren.

**Wie finde ich zuverlässig eine bestimmte SmartArt‑Form auf einer Folie, wenn deren interne ID unbekannt ist?**

Verwenden Sie und suchen Sie nach [alternativem Text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Wenn Sie der SmartArt einen eindeutigen AltText zuweisen, können Sie sie programmgesteuert finden, ohne sich auf interne Kennungen zu verlassen.

**Wird das Aussehen von SmartArt beim Exportieren der Präsentation nach PDF beibehalten?**

Ja. Aspose.Slides rendert SmartArt mit hoher visueller Treue während des [PDF‑Exports](/slides/de/net/convert-powerpoint-to-pdf/), wobei Layout, Farben und Effekte erhalten bleiben.

**Kann ich ein Bild der gesamten SmartArt (für Vorschauen oder Berichte) extrahieren?**

Ja. Sie können eine SmartArt‑Form in [Rasterformate](/slides/de/net/shape-getimage/) oder in [SVG](/slides/de/net/shape-writeassvg/) rendern, um skalierbare Vektordaten zu erhalten, die sich für Miniaturansichten, Berichte oder Web‑Verwendung eignen.