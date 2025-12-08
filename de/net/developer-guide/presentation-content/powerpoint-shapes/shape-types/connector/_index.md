---
title: Verbinder
type: docs
weight: 10
url: /de/net/connector/
keywords: "Formen verbinden, Verbinder, PowerPoint-Formen, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Formen in C# oder .NET verbinden"
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen haften bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden.  

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn ein Zeiger in ihre Nähe kommt.  

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um Position und Form von Verbindern zu ändern.  

## **Arten von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑ (gekrümmte) und gekrümmte Verbinder verwenden.  

Aspose.Slides stellt diese Verbinder bereit:

| Verbinder                      | Bild                                                        | Anzahl der Anpassungspunkte |
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Folien‑Referenz über deren Index.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)-Objekte über die vom `Shapes`‑Objekt bereitgestellte `AddAutoShape`‑Methode hinzu.  
1. Fügen Sie einen Verbinder über die vom `Shapes`‑Objekt bereitgestellte `AddConnector`‑Methode hinzu, indem Sie den Verbinder­typ definieren.  
1. Verbinden Sie die Formen über den Verbinder.  
1. Rufen Sie die `Reroute`‑Methode auf, um den kürzesten Verbindungsweg anzuwenden.  
1. Speichern Sie die Präsentation.  

Dieser C#‑Code zeigt, wie Sie einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einem Ellipse und einem Rechteck) hinzufügen:
```c#
// Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation input = new Presentation())
{                
    // Greift auf die Shapes‑Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Fügt eine Ellipse‑Autoform hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck‑Autoform hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt ein Connector‑Shape zur Formsammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Formen mithilfe des Connectors
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Ruft Reroute auf, das den automatischen kürzesten Pfad zwischen den Formen setzt
    connector.Reroute();

    // Speichert die Präsentation
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Die Methode `Connector.Reroute` leitet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen Formen zu nehmen. Um dieses Ziel zu erreichen, kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie einen Verbinder dazu bringen wollen, zwei Formen über bestimmte Punkte auf den Formen zu verknüpfen, müssen Sie die gewünschten Verbindungspunkte wie folgt angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Folien‑Referenz über deren Index.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)-Objekte über die vom `Shapes`‑Objekt bereitgestellte `AddAutoShape`‑Methode hinzu.  
1. Fügen Sie einen Verbinder über die vom `Shapes`‑Objekt bereitgestellte `AddConnector`‑Methode hinzu, indem Sie den Verbinder­typ definieren.  
1. Verbinden Sie die Formen über den Verbinder.  
1. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen.  
1. Speichern Sie die Präsentation.  

Dieser C#‑Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt angegeben wird:
```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die Shapes‑Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Fügt ein Connector‑Shape zur Shape‑Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Fügt eine Ellipse‑Autoform hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck‑Autoform hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Verbindet die Formen mithilfe des Connectors
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Setzt den gewünschten Verbindungspunkt‑Index auf der Ellipse‑Form
    uint wantedIndex = 6;

    // Überprüft, ob der gewünschte Index kleiner ist als die maximale Site‑Index‑Anzahl
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Setzt den gewünschten Verbindungspunkt auf der Ellipse‑Autoform
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Speichert die Präsentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Verbinderpunkt anpassen**

Sie können einen existierenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Arten von Verbindern](/slides/de/net/connector/#types-of-connectors)**.  

#### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

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


Um die dritte Form zu umgehen, können wir den Verbinder anpassen, indem wir seine senkrechte Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **Komplexe Fälle** 

Für aufwendigere Anpassungen müssen Sie folgende Punkte berücksichtigen:

* Der anpassbare Punkt eines Verbinders ist stark an eine Formel gebunden, die seine Position berechnet. Änderungen der Punktposition können daher die Form des Verbinders verändern.  
* Die Anpassungspunkte eines Verbinders sind in einer festen Reihenfolge in einem Array definiert. Sie werden vom Start‑ zum Endpunkt des Verbinders nummeriert.  
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe der Verbinderform an.  
  * Die Form ist durch die mit 1000 multiplizierten Start‑ und Endpunkte des Verbinders begrenzt.  
  * Erster, zweiter und dritter Punkt stehen jeweils für den Prozentsatz der Breite, den Prozentsatz der Höhe und erneut den Prozentsatz der Breite.  
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung des Verbinders und seine Spiegelung berücksichtigen. **Hinweis:** Der Drehwinkel für alle im Abschnitt **[Arten von Verbindern](/slides/de/net/connector/#types-of-connectors)** gezeigten Verbinder beträgt 0.  

#### **Fall 1**

Betrachten Sie den Fall, dass zwei Textfeld‑Objekte über einen Verbinder verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:
```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
// Holt die erste Folie der Präsentation
ISlide sld = pres.Slides[0];
// Fügt Formen hinzu, die über einen Verbinder verbunden werden
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Fügt einen Verbinder hinzu
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Legt die Richtung des Verbinders fest
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Legt die Farbe des Verbinders fest
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Legt die Linienstärke des Verbinders fest
connector.LineFormat.Width = 3;

// Verknüpft die Formen mit dem Verbinder
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Erhält die Anpassungspunkte für den Verbinder
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir den entsprechenden Breiten‑ und Höhen‑Prozentsatz um 20 % bzw. 200 % erhöhen:
```c#
// Ändert die Werte der Anpassungspunkte
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns die Koordinaten und die Form einzelner Teile des Verbinders ermöglicht, erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders am Punkt `connector.Adjustments[0]` entspricht:
```c#
// Zeichnet die vertikale Komponente des Verbinders

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir einen einfachen Verbinder‑Anpassungsvorgang anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders sowie seine Anzeige (gesetzt über `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV`) berücksichtigen. Wir zeigen nun den Vorgang.

Zuerst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) zum Zweck der Verbindung hinzu und erstellen einen neuen (grünen) Verbinder, der es mit den bereits vorhandenen Objekten verbindet.
```c#
// Erstellt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Erstellt einen neuen Verbinder
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Verbindet Objekte mit dem neu erstellten Verbinder
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Ruft die Anpassungspunkte des Verbinders ab
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ändert die Werte der Anpassungspunkte 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Als Nächstes erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders entspricht, der durch den neuen Anpassungspunkt `connector.Adjustments[0]` verläuft. Wir verwenden die Werte aus den Verbinder‑Daten für `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` und wenden die gängige Koordinaten‑Umrechnungsformel für Drehungen um einen Punkt x₀ an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, sodass der zugehörige Code lautet:
```c#
// Speichert die Koordinaten des Verbinders
x = connector.X;
y = connector.Y;
// Korrigiert die Koordinaten des Verbinders, falls sie auftreten
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Verwendet den Wert des Anpassungspunkts als Koordinate
x += connector.Width * adjValue_0.RawValue / 100000;
//  Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Bestimmt die Breite der horizontalen Komponente anhand des Wertes des zweiten Anpassungspunkts
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen zu einfachen Anpassungen und zu komplexen Anpassungspunkten (mit Drehwinkeln) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder die Werte von Verbinder‑Anpassungspunkten basierend auf konkreten Folienkoordinaten zu setzen.  

## **Winkel von Verbinder‑Linien ermitteln**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Folien‑Referenz über deren Index.  
1. Greifen Sie auf die Verbinder‑Linien‑Form zu.  
1. Verwenden Sie die Linien‑Breite, -Höhe, die Höhe des Form‑Frames und die Breite des Form‑Frames, um den Winkel zu berechnen.  

Dieser C#‑Code demonstriert einen Vorgang, bei dem wir den Winkel einer Verbinder‑Linien‑Form berechnet haben:
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


## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**  

Prüfen Sie, ob die Form [connection sites](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) bereitstellt. Wenn keine vorhanden sind oder die Anzahl 0 beträgt, ist das Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie diese manuell. Es ist sinnvoll, die Site‑Anzahl vor dem Anhängen zu prüfen.  

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**  

Seine Enden werden getrennt; der Verbinder bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [reroute](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/) ausführen.  

**Werden Verbinder‑Bindungen erhalten, wenn ich eine Folie in eine andere Präsentation kopiere?**  

In der Regel ja, vorausgesetzt, die Ziel‑Formen werden ebenfalls kopiert. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut verbinden.  