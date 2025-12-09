---
title: "Verwalten von Verbindern in Präsentationen in .NET"
linktitle: "Verbinder"
type: docs
weight: 10
url: /de/net/connector/
keywords:
- "Verbinder"
- "Verbinder-Typ"
- "Verbinderpunkt"
- "Verbinderlinie"
- "Verbinderwinkel"
- "Formen verbinden"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ermöglichen Sie .NET‑Apps, Linien in PowerPoint‑Folien zu zeichnen, zu verbinden und automatisch zu routen — erhalten Sie die vollständige Kontrolle über gerade, Ellenbogen‑ und gebogene Verbinder."
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden. 

Verbinder werden typischerweise an *Verbindungspunkten* (grüne Punkte) angeschlossen, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn der Cursor ihnen nahe kommt.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um Positionen und Formen von Verbindern zu ändern.

## **Typen von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑ (gekrümmte) und gebogene Verbinder verwenden. 

Aspose.Slides provides these connectors:

| Verbinder | Bild | Anzahl der Anpassungspunkte |
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) mit der vom `Shapes`‑Objekt bereitgestellten Methode `AddAutoShape` hinzu.
1. Fügen Sie einen Verbinder mit der vom `Shapes`‑Objekt bereitgestellten Methode `AddConnector` hinzu, indem Sie den Verbinder‑Typ festlegen.
1. Verbinden Sie die Formen mit dem Verbinder.
1. Rufen Sie die Methode `Reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation. 

```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
using (Presentation input = new Presentation())
{                
    // Greift auf die Shapes-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Fügt eine Ellipse-AutoShape hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-AutoShape hinzu
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

Die Methode `Connector.Reroute` leitet einen Verbinder neu und zwingt ihn, den kürzest möglichen Pfad zwischen Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `StartShapeConnectionSiteIndex` und `EndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt festlegen**
Wenn Sie möchten, dass ein Verbinder zwei Formen über bestimmte Punkte auf den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte folgendermaßen festlegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) mit der vom `Shapes`‑Objekt bereitgestellten Methode `AddAutoShape` hinzu.
1. Fügen Sie einen Verbinder mit der vom `Shapes`‑Objekt bereitgestellten Methode `AddConnector` hinzu, indem Sie den Verbinder‑Typ festlegen.
1. Verbinden Sie die Formen mit dem Verbinder.
1. Legen Sie Ihre bevorzugten Verbindungspunkte auf den Formen fest.
1. Speichern Sie die Präsentation.

```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
using (Presentation presentation = new Presentation())
{
    // Greift auf die Shapes-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Fügt ein Connector-Shape zur Shape-Sammlung der Folie hinzu
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Fügt eine Ellipse-AutoShape hinzu
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-AutoShape hinzu
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Verbindet die Shapes mit dem Connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Legt den gewünschten Verbindungs-Punkt-Index für die Ellipse-Shape fest
    uint wantedIndex = 6;

    // Prüft, ob der gewünschte Index kleiner ist als die maximale Anzahl von Verbindungsstellen
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Legt den gewünschten Verbindungs-Punkt für die Ellipse-AutoShape fest
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Speichert die Präsentation
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```


## **Verbinderpunkt anpassen**
Sie können einen bestehenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Typen von Verbindern.](/slides/de/net/connector/#types-of-connectors)** 

#### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

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


Um die dritte Form zu vermeiden oder zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```


### **Komplexe Fälle** 

Um komplexere Anpassungen vorzunehmen, müssen Sie die folgenden Punkte berücksichtigen:

* Der anpassbare Punkt eines Verbinders ist stark mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Änderungen der Punktposition können daher die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders werden in einem Array in einer festen Reihenfolge definiert. Die Punkte sind vom Start‑ bis zum Endpunkt des Verbinders nummeriert.
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe der Verbinder‑Form an.
  * Die Form wird durch die Start‑ und Endpunkte des Verbinders multipliziert mit 1000 begrenzt.
  * Der erste, zweite und dritte Punkt definieren jeweils den Prozentsatz der Breite, den Prozentsatz der Höhe und erneut den Prozentsatz der Breite.
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung und Spiegelung des Verbinders berücksichtigen. **Hinweis:** Der Drehwinkel für alle unter **[Typen von Verbindern](/slides/de/net/connector/#types-of-connectors)** gezeigten Verbinder beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textfeld‑Objekte über einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:
```c#
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
// Ruft die erste Folie in der Präsentation ab
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
// Legt die Dicke der Verbinderlinie fest
connector.LineFormat.Width = 3;

// Verknüpft die Formen mit dem Verbinder
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Holt die Anpassungspunkte des Verbinders
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir die entsprechenden Breiten‑ und Höhen‑Prozentsätze um jeweils 20 % bzw. 200 % erhöhen:
```c#
// Ändert die Werte der Anpassungspunkte
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns die Koordinaten und die Form einzelner Teile des Verbinders ermöglicht, erstellen wir eine Form, die der horizontalen Komponente des Verbinders am Punkt connector.Adjustments[0] entspricht:
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

In **Fall 1** haben wir eine einfache Verbinder‑Anpassungs‑Operation mittels Grundprinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Anzeige (die durch connector.Rotation, connector.Frame.FlipH und connector.Frame.FlipV festgelegt werden) berücksichtigen. Wir werden nun den Vorgang demonstrieren.

Zuerst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) (zum Verbinden) hinzu und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.
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
// Holt die Anpassungspunkte des Verbinders
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Ändert die Werte der Anpassungspunkte 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die der horizontalen Komponente des Verbinders entspricht, die durch den Anpassungspunkt connector.Adjustments[0] des neuen Verbinders verläuft. Wir verwenden die Werte aus den Verbinder‑Daten für connector.Rotation, connector.Frame.FlipH und connector.Frame.FlipV und wenden die gängige Koordinaten‑Umrechnungsformel für die Drehung um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, daher lautet der entsprechende Code:
```c#
// Speichert die Koordinaten des Verbinders
x = connector.X;
y = connector.Y;
// Korrigiert die Koordinaten des Verbinders, falls es vorkommt
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

Wir haben Berechnungen mit einfachen Anpassungen und komplexen Anpassungspunkten (Anpassungspunkte mit Drehwinkeln) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf bestimmten Folien‑Koordinaten festzulegen.

## **Winkel von Verbinderlinien ermitteln**
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Greifen Sie auf die Form der Verbinderlinie zu.
1. Verwenden Sie die Linienbreite, Höhe, die Rahmenhöhe und -breite der Form, um den Winkel zu berechnen.

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

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/net/aspose.slides/shape/connectionsitecount/) bereitstellt. Gibt es keine oder ist die Anzahl null, ist das Kleben nicht möglich; in diesem Fall verwenden Sie freie Endpunkte und positionieren sie manuell. Es ist sinnvoll, die Anzahl der Punkte vor dem Anfügen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Verbinder bleibt auf der Folie als gewöhnliche Linie mit freien Start‑/Endpunkten bestehen. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [neu routen](https://reference.aspose.com/slides/net/aspose.slides/connector/reroute/).

**Werden Verbinder‑Zuordnungen beim Kopieren einer Folie in eine andere Präsentation beibehalten?**

Im Allgemeinen ja, sofern die Ziel‑Formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne dass die verbundenen Formen mitkopiert werden, werden die Enden frei und Sie müssen sie erneut anfügen.