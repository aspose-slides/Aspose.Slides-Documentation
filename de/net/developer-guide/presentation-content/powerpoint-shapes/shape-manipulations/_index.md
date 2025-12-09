---
title: Verwalten von Präsentationsformen in .NET
linktitle: Formmanipulation
type: docs
weight: 40
url: /de/net/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formenreihenfolge ändern
- Interop-Form-ID abrufen
- Form-Alternativtext
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in Aspose.Slides für .NET erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, um es Entwicklern zu erleichtern, ein bestimmtes Formobjekt auf einer Folie zu finden, ohne dessen interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit bieten, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Allen zu den Folien hinzugefügten Formen ist ein Alternativtext zugeordnet. Wir empfehlen Entwicklern, den Alternativtext zur Suche nach einer bestimmten Form zu verwenden. Sie können in MS PowerPoint den Alternativtext für Objekte definieren, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides for .NET öffnen und alle Formen einer Folie durchlaufen. Bei jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1), erstellt, die das Finden einer bestimmten Form in einer Folie übernimmt und dann einfach diese Form zurückgibt.
```c#
public static void Run()
{
    // Instanziieren Sie eine Presentation-Klasse, die die Präsentationsdatei darstellt
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternativtext der zu findenden Form
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Methodenimplementierung zum Finden einer Form in einer Folie mithilfe ihres Alternativtextes
public static IShape FindShape(ISlide slide, string alttext)
{
    // Durchlaufen aller Formen innerhalb der Folie
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Wenn der Alternativtext der Folie mit dem gewünschten übereinstimmt, dann
        // Rückgabe der Form
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **Form duplizieren**
Um eine Form auf einer Folie mit Aspose.Slides for .NET zu duplizieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie sich den Verweis auf eine Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Formsammlung der Quellfolie zu.
1. Fügen Sie eine neue Folie zur Präsentation hinzu.
1. Duplizieren Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierung von Formen hinzu.
```c#
 // Instanziieren Sie die Presentation-Klasse
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Schreiben Sie die PPTX-Datei auf die Festplatte
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **Form entfernen**
Aspose.Slides for .NET ermöglicht Entwicklern das Entfernen jeder Form. Um eine Form von einer Folie zu entfernen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem jeweiligen AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
 // Präsentationsobjekt erstellen
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Präsentation auf Festplatte speichern
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```




## **Form ausblenden**
Aspose.Slides for .NET ermöglicht Entwicklern das Ausblenden jeder Form. Um eine Form auf einer Folie auszublenden, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem jeweiligen AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
// Instanziieren Sie die Presentation‑Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Präsentation auf die Festplatte speichern
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```




## **Formenreihenfolge ändern**
Aspose.Slides for .NET ermöglicht Entwicklern das Neuanordnen von Formen. Das Neuanordnen bestimmt, welche Form im Vordergrund bzw. im Hintergrund liegt. Um die Reihenfolge von Formen auf einer Folie zu ändern, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie Text in den Textrahmen der Form ein.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu an.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **Interop-Form-ID abrufen**
Aspose.Slides for .NET ermöglicht Entwicklern das Abrufen einer eindeutigen Form‑Kennung im Folien‑Umfang im Gegensatz zur UniqueId‑Eigenschaft, die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Eigenschaft OfficeInteropShapeId wurde zu den IShape‑Interfaces und zur Shape‑Klasse hinzugefügt. Der von OfficeInteropShapeId zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten finden Sie ein Beispielcode.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Abrufen des eindeutigen Formidentifikators im Folienbereich
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **Alternativtext für Form festlegen**
Aspose.Slides for .NET ermöglicht Entwicklern das Festlegen von AlternateText für jede Form. 
Formen in einer Präsentation können über das AlternativeText‑ oder Shape‑Name‑Property unterschieden werden. 
Die AlternativeText‑Eigenschaft kann sowohl von Aspose.Slides als auch von Microsoft PowerPoint gelesen oder gesetzt werden. 
Durch die Verwendung dieser Eigenschaft können Sie eine Form kennzeichnen und verschiedene Vorgänge ausführen, z. B. das Entfernen, Ausblenden oder Neuanordnen von Formen auf einer Folie.
Um den AlternateText einer Form festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um die gewünschte Form zu finden.
1. Setzen Sie das AlternativeText‑Property.
1. Speichern Sie die Datei auf dem Datenträger.
```c#
// Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

// Autoform vom Typ Rechteck hinzufügen
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Präsentation auf die Festplatte speichern
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **Layout‑Formate für Form zugreifen**
Aspose.Slides for .NET bietet eine einfache API zum Zugriff auf Layout‑Formate einer Form. Dieser Artikel zeigt, wie Sie Layout‑Formate abrufen können.

Unten finden Sie Beispielcode.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **Form als SVG rendern**
Jetzt unterstützt Aspose.Slides for .NET das Rendern einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde zur Shape‑Klasse und zum IShape‑Interface hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Der untenstehende Code‑Auszug zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren.
```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```


## **Form ausrichten**

Über die überladene Methode [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) können Sie

* Formen relativ zu den Folienrändern ausrichten. Siehe Beispiel 1.
* Formen relativ zueinander ausrichten. Siehe Beispiel 2.

Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) definiert die verfügbaren Ausrichtungsoptionen.

**Beispiel 1**

Dieser C#‑Code zeigt, wie Sie die Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes einer Folie ausrichten:
Der Quellcode unten richtet die Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes der Folie aus.
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**Beispiel 2**

Dieser C#‑Code zeigt, wie Sie eine komplette Form‑Sammlung relativ zur untersten Form in der Sammlung ausrichten:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Flip‑Eigenschaften**

In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) Kontrolle über die horizontale und vertikale Spiegelung von Formen über die Eigenschaften `FlipH` und `FlipV`. Beide Eigenschaften sind vom Typ [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) und können die Werte `True` (Spiegelung), `False` (keine Spiegelung) oder `NotDefined` (Standardverhalten) annehmen. Diese Werte sind über das [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/)-Instanz mit der aktuellen Position und Größe der Form, den gewünschten Werten für `FlipH` und `FlipV` sowie dem Rotationswinkel erstellt. Durch Zuweisen dieser Instanz zum [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) der Form und dem anschließenden Speichern der Präsentation werden die Spiegelungen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit Standard‑Flip‑Einstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Der folgende Code‑Beispiel liest die aktuellen Flip‑Eigenschaften der Form aus und spiegelt sie horizontal und vertikal.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Abrufen der horizontalen Flip‑Eigenschaft der Form.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Abrufen der vertikalen Flip‑Eigenschaft der Form.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Horizontal spiegeln.
    NullableBool flipV = NullableBool.True; // Vertikal spiegeln.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnitt/Menge) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für Boolesche Operationen. Sie können dies approximieren, indem Sie die gewünschte Kontur selbst erzeugen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) berechnen und eine neue Form mit diesem Umriss erstellen, optional die Originale entfernen.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollte die Z‑Order nach allen anderen Folien‑Modifikationen finalisiert werden.

**Kann ich eine Form „sperren“, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie die [shape‑level‑Schutzflags](/slides/de/net/applying-protection-to-presentation/) (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung). Bei Bedarf können Sie Beschränkungen auf dem Master‑ oder Layout‑Level spiegeln. Beachten Sie, dass dies ein UI‑Schutz ist, kein Sicherheits‑Feature; für stärkeren Schutz kombinieren Sie ihn mit Dateischutz‑Optionen wie [schreibgeschützte Empfehlungen oder Passwörter](/slides/de/net/password-protected-presentation/).