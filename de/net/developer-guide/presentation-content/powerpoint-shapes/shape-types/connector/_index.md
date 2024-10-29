---
title: Connector
type: docs
weight: 10
url: /de/net/connector/
keywords: "Formen verbinden, Verbinder, PowerPoint-Formen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Verbinden Sie PowerPoint-Formen in C# oder .NET"
---

Ein PowerPoint-Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verlinkt und auch dann an Formen angeheftet bleibt, wenn diese auf einer bestimmten Folie bewegt oder neu positioniert werden.

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn sich der Mauszeiger ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur auf bestimmten Verbindern vorhanden sind, werden verwendet, um die Position und Form von Verbindern zu ändern.

## **Arten von Verbindern**

In PowerPoint können Sie gerade, winkelige (geknickte) und gebogene Verbinder verwenden.

Aspose.Slides bietet diese Verbinder an:

| Connector                      | Image                                                        | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zu einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) zur Folie mit der `AddAutoShape` Methode des `Shapes` Objekts hinzu.
1. Fügen Sie einen Verbinder mit der `AddConnector` Methode des `Shapes` Objekts hinzu, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mit dem Verbinder. 
1. Rufen Sie die `Reroute` Methode auf, um den kürzesten Verbindungspfad anzuwenden.
1. Speichern Sie die Präsentation. 

Dieser C#-Code zeigt, wie man einen Verbinder (einen geknickten Verbinder) zwischen zwei Formen (einem Ellipsen und einem Rechteck) hinzufügt:

```c#
// Erstellt eine Präsentation, die eine PPTX-Datei darstellt
using (Presentation input = new Presentation())
{                
    // Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Fügt eine Ellipsen-Autohaltung hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-Autohaltung hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt eine Verbindungsform zur Shapes-Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Formen mit dem Verbinder
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Ruft reroute auf, das den automatischen kürzesten Pfad zwischen den Formen festlegt
    connector.Reroute();

    // Speichert die Präsentation
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die `Connector.Reroute` Methode leitet einen Verbinder neu und zwingt ihn dazu, den kürzesten möglichen Weg zwischen den Formen zu nehmen. Um ihr Ziel zu erreichen, kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**
Wenn Sie möchten, dass ein Verbinder zwei Formen mithilfe von bestimmten Punkten auf den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte folgendermaßen angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zu einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) zur Folie mit der `AddAutoShape` Methode des `Shapes` Objekts hinzu.
1. Fügen Sie einen Verbinder mit der `AddConnector` Methode des `Shapes` Objekts hinzu, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mit dem Verbinder. 
1. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen. 
1. Speichern Sie die Präsentation.

Dieser C#-Code demonstriert eine Operation, bei der ein bevorzugter Verbindungspunkt angegeben wird:

```c#
// Erstellt eine Präsentation, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Fügt eine Verbindungsform zur Shapes-Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Fügt eine Ellipsen-Autohaltung hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-Autohaltung hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Verbindet die Formen mit dem Verbinder
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Setzt den gewünschten Verbindungspunktindex auf der Ellipsenform
    uint wantedIndex = 6;

    // Überprüft, ob der bevorzugte Index kleiner als die maximale Anzahl von Verbindungsstationen ist
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Setzt den bevorzugten Verbindungspunkt auf der Ellipsen-Autohaltung
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Speichert die Präsentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Anpassung des Verbindungspunkts**

Sie können einen bestehenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Arten von Verbindern.](/slides/de/net/connector/#types-of-connectors)** 

#### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

![connector-obstruction](connector-obstruction.png)

Code:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie auf diese Weise nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie diese Aspekte berücksichtigen:

* Ein einstellbarer Punkt eines Verbinders ist stark mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Änderungen am Standort des Punktes können die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte sind von einem Verbindungsstartpunkt zum Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe des Connector-Shape wider. 
  * Die Form wird durch die Start- und Endpunkte des Verbinders multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren jeweils den Prozentsatz von der Breite, den Prozentsatz von der Höhe und den Prozentsatz von der Breite (wiederum).
* Bei Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung des Verbinders und seine Reflexion berücksichtigen. **Hinweis**: Der Drehwinkel für alle hier gezeigten Verbinder unter **[Arten von Verbindern](/slides/de/net/connector/#types-of-connectors)** beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textrahmenobjekte über einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c#
// Erstellt eine Präsentation, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
// Holt sich die erste Folie in der Präsentation
ISlide sld = pres.Slides[0];
// Fügt Formen hinzu, die durch einen Verbinder verbunden werden
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "Von";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "Zu";
// Fügt einen Verbinder hinzu
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Gibt die Richtung des Verbinders an
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Gibt die Farbe des Verbinders an
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Gibt die Dicke der Linie des Verbinders an
connector.LineFormat.Width = 3;

// Verbindet die Formen miteinander mit dem Verbinder
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Holt sich die Anpassungspunkte für den Verbinder
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir den entsprechenden Breiten- und Höhenprozentsatz um 20% und 200% erhöhen:

```c#
// Ändert die Werte der Anpassungspunkte
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das es uns ermöglicht, die Koordinaten und die Form einzelner Teile des Verbinders zu bestimmen, erstellen wir eine Form, die dem horizontalen Aspekt des Verbinders am Punkt connector.Adjustments[0] entspricht:

```c#
// Zeichnet das vertikale Element des Verbinders

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** haben wir eine einfache Anpassungsoperation des Verbinders anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Darstellung (die durch connector.Rotation, connector.Frame.FlipH und connector.Frame.FlipV festgelegt werden) berücksichtigen. Wir werden jetzt den Prozess demonstrieren.

Zuerst fügen wir ein neues Textrahmenobjekt (**Zu 1**) zur Folie hinzu (zu Verbindungszwecken) und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.

```c#
// Erstellt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "Zu 1";
// Erstellt einen neuen Verbinder
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Verbindet die Objekte über den neu erstellten Verbinder
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Holt sich die Anpassungspunkte des Verbinders
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ändert die Werte der Anpassungspunkte 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die dem horizontalen Element des Verbinders entspricht, das durch den neuen Verbinders Anpassungspunkt connector.Adjustments[0] verläuft. Wir verwenden die Werte aus den Verbinderdaten für connector.Rotation, connector.Frame.FlipH und connector.Frame.FlipV und wenden die beliebte Koordinatenumrechnungsformel für die Rotation rund um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, also ist das der entsprechende Code:

```c#
// Speichert die Koordinaten des Verbinders
x = connector.X;
y = connector.Y;
// Korrigiert die Koordinaten des Verbinders, falls diese erscheinen
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Nimmt den Anpassungspunktwert als die Koordinate
x += connector.Width * adjValue_0.RawValue / 100000;
//  Wandelt die Koordinaten um, da Sin(90) = 1 und Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Bestimmt die Breite des horizontalen Elements mithilfe des Wertes des zweiten Anpassungspunktes
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen mit einfachen Anpassungen und komplizierten Anpassungspunkten (Anpassungspunkte mit Drehwinkeln) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell (oder Code) entwickeln, um ein `GraphicsPath`-Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf bestimmten Folienkoordinaten festzulegen.

## **Winkel der Verbindungsleitungen finden**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zu einer Folie über ihren Index.
1. Greifen Sie auf die Verbindungslinienform zu. 
1. Verwenden Sie die Linienbreite, Höhe, Rahmenhöhe der Form und Rahmenbreite der Form, um den Winkel zu berechnen.

Dieser C#-Code demonstriert eine Operation, in der wir den Winkel für eine Verbindungslinienform berechnet haben:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```