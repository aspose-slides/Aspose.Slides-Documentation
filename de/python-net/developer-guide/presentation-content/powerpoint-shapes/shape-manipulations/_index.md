---
title: Formenmanipulationen
type: docs
weight: 40
url: /de/python-net/shape-manipulations/
keywords: "PowerPoint-Form, Form auf Folie, Form finden, Form klonen, Form entfernen, Form ausblenden, Formreihenfolge ändern, Interop-Form-ID abrufen, alternative Formtexte, Formularlayoutformate, Form als SVG, Form ausrichten, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Manipulieren Sie PowerPoint-Formen in Python"
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Technik, um Entwicklern das Finden einer bestimmten Form auf einer Folie zu erleichtern, ohne ihre interne ID zu verwenden. Es ist wichtig zu wissen, dass PowerPoint-Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie außer einer internen einzigartigen ID zu identifizieren. Es scheint schwierig für Entwickler zu sein, eine Form anhand ihrer internen einzigartigen ID zu finden. Alle Formen, die den Folien hinzugefügt werden, haben einen Alt-Text. Wir empfehlen Entwicklern, alternativen Text zu nutzen, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den alternativen Text für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den alternativen Text einer gewünschten Form festgelegt haben, können Sie diese Präsentation mit Aspose.Slides für Python über .NET öffnen und durch alle auf einer Folie hinzugefügten Formen iterieren. Bei jeder Iteration können Sie den alternativen Text der Form überprüfen, und die Form mit dem übereinstimmenden alternativen Text wäre die Form, die Sie benötigen. Um diese Technik anschaulicher zu demonstrieren, haben wir eine Methode, [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), erstellt, die den Trick ausführt, eine bestimmte Form in einer Folie zu finden und dann einfach diese Form zurückzugeben.

```py
import aspose.slides as slides

# Methodenimplementierung zum Finden einer Form in einer Folie anhand ihres alternativen Texts
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# Instanziieren einer Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # Alternativtext der zu findenden Form
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("Formname: " + shape.name)
```



## **Form klonen**
Um eine Form mit Aspose.Slides für Python über .NET in eine Folie zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie den Verweis auf eine Folie, indem Sie ihren Index verwenden.
1. Greifen Sie auf die Sammlung der Quellfolienformen zu.
1. Fügen Sie eine neue Folie zur Präsentation hinzu.
1. Klonen Sie Formen aus der Sammlung der Quellfolienformen in die neue Folie.
1. Speichern Sie die bearbeitete Präsentation als PPTX-Datei.

Im folgenden Beispiel wird eine Gruppenform zu einer Folie hinzugefügt.

```py
import aspose.slides as slides

# Instanziieren der Präsentationsklasse
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# Schreiben Sie die PPTX-Datei auf die Festplatte
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Form entfernen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern das Entfernen beliebiger Formen. Um die Form von einer Folie zu entfernen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit speziellem Alternativtext.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides

# Erstellen des Präsentationsobjekts
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine Autoshape vom Rechtecktyp hinzu
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Benutzerdefiniert"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # Speichern Sie die Präsentation auf der Festplatte
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Form ausblenden**
Aspose.Slides für Python über .NET ermöglicht Entwicklern das Ausblenden beliebiger Formen. Um die Form von einer Folie auszublenden, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Finden Sie die Form mit speziellem Alternativtext.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die das PPTX darstellt
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine Autoshape vom Rechtecktyp hinzu
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Benutzerdefiniert"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # Speichern Sie die Präsentation auf der Festplatte
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Formenreihenfolge ändern**
Aspose.Slides für Python über .NET ermöglicht Entwicklern das Neuanordnen der Formen. Das Neuanordnen der Form gibt an, welche Form vorne oder welche Form hinten ist. Um die Form von einer Folie neu anzuordnen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie etwas Text in den Textrahmen der Form ein.
1. Fügen Sie eine andere Form mit denselben Koordinaten hinzu.
1. Neuanordnen der Formen.
1. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="Wasserzeichen-Text Wasserzeichen-Text Wasserzeichen-Text"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Interop-Form-ID abrufen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, einen eindeutigen Form-Identifikator im Folienkontext abzurufen, im Gegensatz zur UniqueId-Eigenschaft, die es ermöglicht, einen eindeutigen Identifikator im Präsentationskontext zu erhalten. Die Eigenschaft OfficeInteropShapeId wurde den IShape-Schnittstellen und der Shape-Klasse hinzugefügt. Der Wert, der von der Eigenschaft OfficeInteropShapeId zurückgegeben wird, entspricht dem Wert der ID des Microsoft.Office.Interop.PowerPoint.Shape-Objekts. Im Folgenden ist ein Beispielcode gegeben.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # Abrufen des eindeutigen Form-Identifikators im Folienkontext
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **Alternativtext für eine Form festlegen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, den Alternativtext jeder Form festzulegen. 
Formen in einer Präsentation können durch die Eigenschaften Alternativtext oder Formname unterschieden werden. 
Die Eigenschaft Alternativtext kann sowohl über Aspose.Slides als auch über Microsoft PowerPoint gelesen oder festgelegt werden. 
Mit dieser Eigenschaft können Sie eine Form kennzeichnen und verschiedene Operationen wie das Entfernen einer Form, 
das Ausblenden einer Form oder das Neuanordnen von Formen auf einer Folie durchführen.
Um den Alternativtext einer Form festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie der Folie eine beliebige Form hinzu.
1. Führen Sie einige Arbeiten mit der neu hinzugefügten Form aus.
1. Durchsuchen Sie die Formen, um eine Form zu finden.
1. Legen Sie den Alternativtext fest.
1. Speichern Sie die Datei auf der Festplatte.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Präsentationsklasse, die das PPTX darstellt
with slides.Presentation() as pres:
    # Holen Sie sich die erste Folie
    sld = pres.slides[0]

    # Fügen Sie eine Autoshape vom Rechtecktyp hinzu
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "Benutzerdefiniert"

    # Speichern Sie die Präsentation auf der Festplatte
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Zugriff auf Layoutformate für Formen**
Aspose.Slides für Python über .NET bietet eine einfache API, um auf Layoutformate für eine Form zuzugreifen. Dieser Artikel demonstriert, wie Sie auf Layoutformate zugreifen können.

Im Folgenden ist ein Beispielcode aufgeführt.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **Form als SVG rendern**
Nun unterstützt Aspose.Slides für Python über .NET die Darstellung einer Form als SVG. Die Methode WriteAsSvg (und ihre Überladung) wurde der Shape-Klasse und der IShape-Schnittstelle hinzugefügt. Diese Methode ermöglicht es, den Inhalt der Form als SVG-Datei zu speichern. Der folgende Codeausschnitt zeigt, wie Sie die Form der Folie als SVG-Datei exportieren.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## Form ausrichten

Durch die überladene Methode [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) können Sie

* Formen relativ zu den Rändern einer Folie ausrichten. Siehe Beispiel 1.
* Formen relativ zueinander ausrichten. Siehe Beispiel 2.

Die Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) definiert die verfügbaren Ausrichtungsoptionen.

### Beispiel 1

Dieser Python-Code zeigt Ihnen, wie Sie die Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes einer Folie ausrichten:
Der folgende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes der Folie aus.

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### Beispiel 2

Dieser Python-Code zeigt Ihnen, wie Sie eine gesamte Sammlung von Formen relativ zur unteren Form in der Sammlung ausrichten:

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```