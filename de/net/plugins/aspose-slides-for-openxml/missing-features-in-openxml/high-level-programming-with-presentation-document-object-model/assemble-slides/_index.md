---
title: Folien zusammenstellen
type: docs
weight: 10
url: /de/net/assemble-slides/
---

## **Folie zu einer Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien besprechen. Jede PowerPoint‑Präsentationsdatei enthält Master‑/Layout‑Folien und weitere normale Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird.

Aspose.Slides für .NET ermöglicht Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie zur Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der **Presentation**‑Klasse
- Instanziieren Sie die **SlideCollection**‑Klasse, indem Sie einen Verweis auf die Slides‑Eigenschaft (Sammlung von Inhalts‑Slide‑Objekten), die vom Presentation‑Objekt bereitgestellt wird, setzen.
- Fügen Sie der Präsentation am Ende der Sammlung von Inhalts‑Folien eine leere Folie hinzu, indem Sie die von **SlideCollection** bereitgestellte **AddEmptySlide**‑Methode aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des **Presentation**‑Objekts

``` csharp

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

``` 
## **Zugriff auf Folien einer Präsentation**
Aspose.Slides für .NET stellt die **Presentation**‑Klasse bereit, die verwendet werden kann, um jede gewünschte Folie in der Präsentation zu finden und darauf zuzugreifen.

**Verwenden der Folien‑Sammlung**

Die **Presentation**‑Klasse repräsentiert eine Präsentationsdatei und stellt alle Folien darin als **SlideCollection**‑Sammlung (eine Sammlung von **Slide**‑Objekten) bereit. Alle diese Folien können über diese **Slides**‑Sammlung mittels eines Folien‑Indexes aufgerufen werden.

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **Folien entfernen**
Wir wissen, dass die **Presentation**‑Klasse in **Aspose.Slides für .NET** eine Präsentationsdatei repräsentiert. Die Presentation‑Klasse kapselt eine **SlideCollection**, die als Repository aller Folien dient, die Teil der Präsentation sind. Entwickler können eine Folie aus dieser Slides‑Sammlung auf zwei Arten entfernen:

- Verwenden einer Folien‑Referenz
- Verwenden eines Folien‑Index

**Verwenden einer Folien‑Referenz**

Um eine Folie über ihre Referenz zu entfernen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der **Presentation**‑Klasse
- Holen Sie die Referenz einer Folie über deren Id oder Index
- Entfernen Sie die referenzierte Folie aus der Präsentation
- Schreiben Sie die modifizierte Präsentationsdatei

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

``` 
## **Position einer Folie ändern**
Es ist sehr einfach, die Position einer Folie in der Präsentation zu ändern. Befolgen Sie einfach die nachstehenden Schritte:

- Erstellen Sie eine Instanz der **Presentation**‑Klasse
- Holen Sie die Referenz einer Folie über deren Index
- Ändern Sie die **SlideNumber** der referenzierten Folie
- Schreiben Sie die modifizierte Präsentationsdatei

Im nachstehenden Beispiel haben wir die Position einer Folie (die sich an der Null‑Index‑Position 1 befand) der Präsentation auf Index 1 (Position 2) geändert.

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)