---
title: Connectoren in Präsentationen mit .NET verwalten
linktitle: Connector
type: docs
weight: 10
url: /de/net/connector/
keywords:
- Connector
- Connector-Typ
- Connector-Punkt
- Connector-Linie
- Connector-Winkel
- Formen verbinden
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Ermöglichen Sie .NET-Anwendungen, Linien in PowerPoint-Folien zu zeichnen, zu verbinden und automatisch zu routen – erhalten Sie volle Kontrolle über gerade, Ellenbogen‑ und gebogene Connectoren."
---

Ein PowerPoint‑Connector ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, auch wenn sie verschoben oder neu positioniert werden.

Connectoren werden typischerweise an *Verbindungspunkten* (grüne Punkte) angeschlossen, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn ein Cursor ihnen nahekommt.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Connectoren existieren, dienen dazu, die Position und Form von Connectoren zu ändern.

## **Arten von Connectoren**

In PowerPoint können Sie gerade, abgewinkelte (Ellenbogen‑) und gebogene Connectoren verwenden.

Aspose.Slides stellt folgende Connectoren bereit:

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

## **Formen mit Connectoren verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
1. Rufen Sie über den Index die Referenz einer Folie ab.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)‑Objekte mit der Methode `AddAutoShape` hinzu, die vom `Shapes`‑Objekt bereitgestellt wird.  
1. Fügen Sie einen Connector mit der Methode `AddConnector` hinzu, indem Sie den Connector‑Typ angeben.  
1. Verbinden Sie die Formen mithilfe des Connectors.  
1. Rufen Sie die Methode `Reroute` auf, um den kürzesten Verbindungsweg anzuwenden.  
1. Speichern Sie die Präsentation.  

Dieser C#‑Code zeigt, wie Sie zwischen zwei Formen (einem Ellipsen‑ und einem Rechteck‑Shape) einen Connector (einen abgewinkelten Connector) hinzufügen:
```c#
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
using (Presentation input = new Presentation())
{                
    // Greift auf die Shape-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Fügt eine Ellipse-Autoform hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-Autoform hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt ein Connector-Shape zur Shape-Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Shapes mit dem Connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Ruft Reroute auf, das den automatischen kürzesten Pfad zwischen den Shapes festlegt
    connector.Reroute();

    // Speichert die Präsentation
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Die Methode `Connector.Reroute` leitet einen Connector um und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu nehmen. Dazu kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 
{{% /alert %}} 

## **Ein Verbindungspunkt festlegen**
Wenn Sie einen Connector so einrichten möchten, dass er zwei Formen über bestimmte Punkte auf den Formen verbindet, geben Sie die gewünschten Verbindungspunkte wie folgt an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
1. Rufen Sie über den Index die Referenz einer Folie ab.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)‑Objekte mit der Methode `AddAutoShape` hinzu.  
1. Fügen Sie einen Connector mit der Methode `AddConnector` hinzu, indem Sie den Connector‑Typ angeben.  
1. Verbinden Sie die Formen mit dem Connector.  
1. Legen Sie die gewünschten Verbindungspunkte auf den Formen fest.  
1. Speichern Sie die Präsentation.  

Dieser C#‑Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt angegeben wird:
```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die Shape‑Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Fügt ein Connector‑Shape zur Shape‑Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Fügt eine Ellipse‑Autoform hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck‑Autoform hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Verbindet die Shapes mit dem Connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Legt den Index des gewünschten Verbindungspunkts auf der Ellipse-Form fest
    uint wantedIndex = 6;

    // Prüft, ob der gewünschte Index kleiner ist als die maximale Site‑Index‑Anzahl
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Setzt den gewünschten Verbindungspunkt auf der Ellipse‑Autoform
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Speichert die Präsentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Einen Connector‑Punkt anpassen**

Sie können einen bestehenden Connector über seine Anpassungspunkte justieren. Nur Connectoren mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Arten von Connectoren.](/slides/de/net/connector/#types-of-connectors)** 

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Connector zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

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


Um die dritte Form zu umgehen, können wir den Connector anpassen, indem wir seine senkrechte Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **Komplexe Fälle** 

Für aufwändigere Anpassungen müssen Sie Folgendes berücksichtigen:

* Ein anpassbarer Punkt eines Connectors ist stark mit einer Formel verknüpft, die seine Position berechnet. Änderungen der Punktposition können die Form des Connectors verändern.  
* Die Anpassungspunkte eines Connectors sind in einem Array in fester Reihenfolge definiert. Sie werden vom Start‑ zum Endpunkt des Connectors nummeriert.  
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe des Connector‑Shapes an.  
  * Das Shape wird durch die Start‑ und Endpunkte des Connectors multipliziert mit 1000 begrenzt.  
  * Erster, zweiter und dritter Punkt definieren jeweils den Prozentsatz der Breite, der Höhe und erneut der Breite.  
* Für die Berechnung der Koordinaten der Anpassungspunkte eines Connectors müssen Sie die Drehung und die Spiegelung des Connectors berücksichtigen. **Hinweis:** Der Drehwinkel aller in **[Arten von Connectoren](/slides/de/net/connector/#types-of-connectors)** gezeigten Connectoren beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textfeld‑Objekte über einen Connector verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:
```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
// Holt die erste Folie der Präsentation
ISlide sld = pres.Slides[0];
// Fügt Formen hinzu, die über einen Connector verbunden werden
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Fügt einen Connector hinzu
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Gibt die Richtung des Connectors an
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Gibt die Farbe des Connectors an
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Gibt die Linienstärke des Connectors an
connector.LineFormat.Width = 3;

// Verbindet die Formen mit dem Connector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Holt die Anpassungspunkte des Connectors
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Connectors ändern, indem wir den jeweiligen Breiten‑ bzw. Höhen‑Prozentsatz um 20 % bzw. 200 % erhöhen:
```c#
// Ändert die Werte der Anpassungspunkte
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns die Koordinaten und die Form einzelner Connector‑Teile bestimmt, erstellen wir ein Shape, das der horizontalen Komponente des Connectors am Punkt `connector.Adjustments[0]` entspricht:
```c#
// Zeichnet die vertikale Komponente des Connectors
float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Connector‑Anpassung anhand grundlegender Prinzipien demonstriert. In normalen Situationen muss die Drehung des Connectors sowie seine Ansicht (gesetzt über `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV`) berücksichtigt werden. Nun zeigen wir den Vorgang.

Zuerst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) zum Zwecke der Verbindung hinzu und erstellen einen neuen (grünen) Connector, der es mit den bereits erstellten Objekten verbindet.
```c#
// Erstellt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Erstellt einen neuen Connector
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Verbindet Objekte mit dem neu erstellten Connector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Holt die Anpassungspunkte des Connectors
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ändert die Werte der Anpassungspunkte 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Als Nächstes erstellen wir ein Shape, das der horizontalen Komponente des Connectors entspricht, die durch den neuen Anpassungspunkt `connector.Adjustments[0]` verläuft. Wir verwenden die Werte aus `connector.Rotation`, `connector.Frame.FlipH` und `connector.Frame.FlipV` und wenden die gängige Koordinaten‑Umrechnungsformel für eine Drehung um einen Punkt x₀ an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Connector wird vertikal angezeigt, sodass der entsprechende Code folgendermaßen aussieht:
```c#
 // Speichert die Connector-Koordinaten
x = connector.X;
y = connector.Y;
 // Korrigiert die Connector-Koordinaten, falls sie auftreten
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
 //  Konvertiert die Koordinaten, da Sin(90)=1 und Cos(90)=0
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

Wir haben Berechnungen sowohl für einfache Anpassungen als auch für komplexe Anpassungspunkte (angepasst durch Drehwinkel) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder die Werte eines Connector‑Anpassungspunkts basierend auf konkreten Folien‑Koordinaten zu setzen.

## **Winkel von Connector‑Linien bestimmen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
1. Rufen Sie über den Index die Referenz einer Folie ab.  
1. Greifen Sie auf das Connector‑Linien‑Shape zu.  
1. Verwenden Sie Breite, Höhe, Frame‑Höhe und Frame‑Breite des Shapes, um den Winkel zu berechnen.

Dieser C#‑Code demonstriert einen Vorgang, bei dem wir den Winkel einer Connector‑Linie berechnet haben:
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

**Wie kann ich feststellen, ob ein Connector an einer bestimmten Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) bereitstellt. Gibt es keine oder ist die Anzahl 0, ist ein Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie diese manuell. Es ist sinnvoll, die Anzahl der Punkte vor dem Anhängen zu prüfen.

**Was passiert mit einem Connector, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden gelöst; der Connector bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie erhalten. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und, falls nötig, [rerouten](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**Werden Connector‑Verknüpfungen beibehalten, wenn eine Folie in eine andere Präsentation kopiert wird?**

In der Regel ja, sofern die Ziel‑Formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anhängen.