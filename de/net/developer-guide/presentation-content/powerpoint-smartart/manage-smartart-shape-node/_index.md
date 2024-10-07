---
title: SmartArt-Formknoten verwalten
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords:
- SmartArt
- SmartArt-Knoten
- SmartArt-Kindknoten
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Verwalten von SmartArt-Knoten und Kindknoten in PowerPoint-Präsentationen in C# oder .NET"
---


## **SmartArt-Knoten hinzufügen**
Aspose.Slides für .NET bietet die einfachste API, um SmartArt-Formen auf die einfachste Weise zu verwalten. Der folgende Beispielcode hilft, Knoten und Kindknoten innerhalb der SmartArt-Form hinzuzufügen.

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse und load die Präsentation mit SmartArt-Form.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
- Fügen Sie einen neuen Knoten in der SmartArt-KnotenSammlung hinzu und setzen Sie den Text im Textfeld.
- Fügen Sie nun einen Kindknoten im neu hinzugefügten SmartArt-Knoten hinzu und setzen Sie den Text im Textfeld.
- Speichern Sie die Präsentation.

```c#
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AddNodes.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Überprüfen Sie, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Casten Sie die Form zu SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Hinzufügen eines neuen SmartArt-Knotens
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Hinzufügen von Text
        TemNode.TextFrame.Text = "Test";

        // Hinzufügen eines neuen Kindknotens im übergeordneten Knoten. Er wird am Ende der Sammlung hinzugefügt
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Hinzufügen von Text
        newNode.TextFrame.Text = "Neuer Knoten hinzugefügt";

    }
}

// Präsentation speichern
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **SmartArt-Knoten an einer bestimmten Position hinzufügen**
Im folgenden Beispielcode haben wir erklärt, wie man die Kindknoten der jeweiligen Knoten der SmartArt-Form an einer bestimmten Position hinzufügt.

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie in der aufgerufenen Folie eine SmartArt-Form vom Typ StackedList hinzu.
- Greifen Sie auf den ersten Knoten in der hinzugefügten SmartArt-Form zu.
- Fügen Sie nun den Kindknoten für den ausgewählten Knoten an Position 2 hinzu und setzen Sie dessen Text.
- Speichern Sie die Präsentation.

```c#
// Erstellen einer Präsentationsinstanz
Presentation pres = new Presentation();

// Zugriff auf die Präsentationsfolie
ISlide slide = pres.Slides[0];

// Hinzufügen einer SmartArt-IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Zugriff auf den SmartArt-Knoten bei Index 0
ISmartArtNode node = smart.AllNodes[0];

// Hinzufügen eines neuen Kindknotens an Position 2 im übergeordneten Knoten
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Text hinzufügen
chNode.TextFrame.Text = "Beispieltext hinzugefügt";

// Präsentation speichern
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt-Knoten zugreifen**
Der folgende Beispielcode hilft, auf Knoten innerhalb der SmartArt-Form zuzugreifen. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur beim Hinzufügen der SmartArt-Form festgelegt wird.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit der SmartArt-Form.

- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.

- Durchlaufen Sie jede Form auf der ersten Folie.

- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.

- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.

- Greifen Sie auf Informationen zu, wie z. B. die Position des SmartArt-Knotens, Ebene und Text.

  ```c#
  // Laden Sie die gewünschte Präsentation
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Durchlaufen Sie jede Form auf der ersten Folie
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Überprüfen Sie, ob die Form vom Typ SmartArt ist
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Casten Sie die Form zu SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Durchlaufen Sie alle Knoten in der SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Zugriff auf den SmartArt-Knoten bei Index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Drucken der Parameter des SmartArt-Knotens
              string outString = string.Format("i = {0}, Text = {1},  Ebene = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

  


## **SmartArt-Kindknoten zugreifen**
Der folgende Beispielcode hilft, auf die Kindknoten zuzugreifen, die den jeweiligen Knoten der SmartArt-Form zugeordnet sind.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, wenn sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form.
- Für jeden ausgewählten SmartArt-Formknoten durchlaufen Sie alle Kindknoten innerhalb des jeweiligen Knotens.
- Greifen Sie auf Informationen zu, wie z. B. die Position des Kindknotens, Ebene und Text.

```c#
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Überprüfen Sie, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Casten Sie die Form zu SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Durchlaufen Sie alle Knoten in der SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Zugriff auf den SmartArt-Knoten bei Index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Durchlaufen der Kindknoten im SmartArt-Knoten bei Index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Zugriff auf den Kindknoten im SmartArt-Knoten
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Drucken der Parameter des SmartArt-Kindknotens
                string outString = string.Format("j = {0}, Text = {1},  Ebene = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **SmartArt-Kindknoten an einer bestimmten Position zugreifen**
In diesem Beispiel lernen wir, wie man auf die Kindknoten an einer bestimmten Position zugreift, die den jeweiligen Knoten der SmartArt-Form zugeordnet sind.

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine SmartArt-Form vom Typ StackedList hinzu.
- Greifen Sie auf die hinzugefügte SmartArt-Form zu.
- Greifen Sie auf den Knoten bei Index 0 für die aufgerufene SmartArt-Form zu.
- Greifen Sie nun auf den Kindknoten an Position 1 für den aufgerufenen SmartArt-Knoten mit der Methode GetNodeByPosition() zu.
- Greifen Sie auf Informationen zu, wie z. B. die Position des Kindknotens, Ebene und Text.

```c#
// Instanziieren Sie die Präsentation
Presentation pres = new Presentation();

// Zugriff auf die erste Folie
ISlide slide = pres.Slides[0];

// Hinzufügen der SmartArt-Form auf der ersten Folie
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Zugriff auf den SmartArt-Knoten bei Index 0
ISmartArtNode node = smart.AllNodes[0];

// Zugriff auf den Kindknoten an Position 1 im übergeordneten Knoten
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Drucken der Parameter des SmartArt-Kindknotens
string outString = string.Format("j = {0}, Text = {1},  Ebene = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **SmartArt-Knoten entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form entfernt.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
- Überprüfen Sie, ob die SmartArt mehr als 0 Knoten hat.
- Wählen Sie den zu löschenden SmartArt-Knoten aus.
- Entfernen Sie nun den ausgewählten Knoten mit der Methode RemoveNode(). Präsentation speichern.

```c#
// Laden Sie die gewünschte Präsentation
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Durchlaufen Sie jede Form auf der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape is ISmartArt)
        {
            // Casten Sie die Form zu SmartArtEx
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



## **SmartArt-Knoten an einer bestimmten Position entfernen**
In diesem Beispiel lernen wir, wie man die Knoten innerhalb der SmartArt-Form an einer bestimmten Position entfernt.

- Erstellen Sie eine Instanz der `Presentation`-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz zur ersten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
- Wählen Sie den SmartArt-Formknoten bei Index 0 aus.
- Überprüfen Sie nun, ob der ausgewählte SmartArt-Knoten mehr als 2 Kindknoten hat.
- Entfernen Sie nun den Knoten an Position 1 mit der Methode RemoveNodeByPosition().
- Speichern Sie die Präsentation.

```c#
// Laden Sie die gewünschte Präsentation             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Durchlaufen Sie jede Form auf der ersten Folie
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Überprüfen Sie, ob die Form vom Typ SmartArt ist
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Casten Sie die Form zu SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Zugriff auf den SmartArt-Knoten bei Index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Entfernen des Kindknotens an Position 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Präsentation speichern
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Benutzerdefinierte Position für Kindknoten in SmartArt festlegen**
Jetzt unterstützt Aspose.Slides für .NET das Festlegen der X- und Y-Eigenschaften von SmartArtShape. Der folgende Codeausschnitt zeigt, wie man die benutzerdefinierte SmartArtShape-Position, Größe und Drehung festlegt. Bitte beachten Sie, dass das Hinzufügen neuer Knoten eine Neuberechnung der Positionen und Größen aller Knoten verursacht.

```c#
// Laden Sie die gewünschte Präsentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Bewegen Sie die SmartArt-Form zur neuen Position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Ändern Sie die Breite der SmartArt-Form
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Ändern Sie die Höhe der SmartArt-Form
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Ändern Sie die Drehung der SmartArt-Form
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Assistent-Knoten überprüfen**
Im folgenden Beispielcode werden wir untersuchen, wie man Assistentenknoten in der SmartArt-KnotenSammlung identifiziert und sie ändert.

- Erstellen Sie eine Instanz der PresentationEx-Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Erhalten Sie die Referenz zur zweiten Folie, indem Sie ihren Index verwenden.
- Durchlaufen Sie jede Form auf der ersten Folie.
- Überprüfen Sie, ob die Form vom Typ SmartArt ist, und casten Sie die ausgewählte Form zu SmartArtEx, wenn sie SmartArt ist.
- Durchlaufen Sie alle Knoten innerhalb der SmartArt-Form und prüfen Sie, ob sie Assistentenknoten sind.
- Ändern Sie den Status des Assistentenknotens in normalen Knoten.
- Speichern Sie die Präsentation.

```c#
// Erstellen einer Präsentationsinstanz
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Durchlaufen Sie jede Form auf der ersten Folie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Überprüfen Sie, ob die Form vom Typ SmartArt ist
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Casten Sie die Form zu SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Durchlaufen Sie alle Knoten der SmartArt-Form

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Überprüfen Sie, ob der Knoten ein Assistenten-Knoten ist
                if (node.IsAssistant)
                {
                    // Setzen des Assistenten-Knotens auf falsch und Umwandeln in einen normalen Knoten
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
Aspose.Slides für .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt-Formen und das Festlegen ihrer Füllformate. Dieser Artikel erklärt, wie man SmartArt-Formen erstellt und auf sie zugreift und ihr Füllformat mit Aspose.Slides für .NET festlegt.

Bitte folgen Sie den folgenden Schritten:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Erhalten Sie die Referenz zu einer Folie unter Verwendung ihres Index.
- Fügen Sie eine SmartArt-Form hinzu, indem Sie ihren LayoutType festlegen.
- Setzen Sie das Füllformat für die Knoten der SmartArt-Form.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

```c#
using (Presentation presentation = new Presentation())
{
    // Zugriff auf die Folie
    ISlide slide = presentation.Slides[0];

    // Hinzufügen von SmartArt-Formen und -Knoten
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Einige Texte";

    // Setzen der Knotenfüllfarbe
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Präsentation speichern
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Thumbnail des SmartArt-Kindknotens generieren**
Entwickler können ein Thumbnail eines Kindknotens einer SmartArt generieren, indem sie die folgenden Schritte befolgen:

1. Instanziieren Sie die `Presentation`-Klasse, die die PPTX-Datei darstellt.
1. Fügen Sie SmartArt hinzu.
1. Greifen Sie mit einem Index auf den Knoten zu.
1. Holen Sie sich das Thumbnail-Bild.
1. Speichern Sie das Thumbnail-Bild in jedem gewünschten Bildformat.

Das folgende Beispiel generiert ein Thumbnail des SmartArt-Kindknotens.

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