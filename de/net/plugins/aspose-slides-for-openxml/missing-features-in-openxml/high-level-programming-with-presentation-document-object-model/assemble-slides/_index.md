---
title: Folien zusammenstellen
type: docs
weight: 10
url: /de/net/assemble-slides/
---

## **Eine Folie zu einer Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien diskutieren. Jede PowerPoint-Präsentationsdatei enthält eine Master-/Layout‑Folie und weitere Normalfolien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normalfolien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index festgelegt wird.

Aspose.Slides für .NET ermöglicht Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Eine Instanz der **Presentation**‑Klasse erstellen
- Die **SlideCollection**‑Klasse instanziieren, indem Sie einen Verweis auf die Slides‑Eigenschaft (Sammlung von Inhalts‑Slide‑Objekten) setzen, die vom Presentation‑Objekt bereitgestellt wird.
- Eine leere Folie am Ende der Inhaltsfoliensammlung zur Präsentation hinzufügen, indem Sie die von **SlideCollection** bereitgestellten **AddEmptySlide**‑Methoden aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schließlich die Präsentationsdatei mit dem **Presentation**‑Objekt schreiben.

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
Aspose.Slides für .NET stellt die Presentation‑Klasse bereit, mit der Sie jede gewünschte Folie in der Präsentation finden und darauf zugreifen können.

**Verwendung der Slides‑Sammlung**

`Presentation`‑Klasse repräsentiert eine Präsentationsdatei und stellt alle Folien darin als `SlideCollection`‑Sammlung (eine Sammlung von `Slide`‑Objekten) bereit. Auf alle diese Folien kann über die `Slides`‑Sammlung mittels eines Folien‑Index zugegriffen werden.

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **Folien entfernen**
Wir wissen, dass die Presentation‑Klasse in **Aspose.Slides für .NET** eine Präsentationsdatei repräsentiert. Die Presentation‑Klasse kapselt eine **SlideCollection**, die als Repository aller Folien dient, die Teil der Präsentation sind. Entwickler können eine Folie aus dieser Slides‑Sammlung auf zwei Arten entfernen:

- Verwenden einer Folienreferenz
- Verwenden eines Folien‑Index

**Verwenden einer Folienreferenz**

Um eine Folie über ihre Referenz zu entfernen, folgen Sie bitte den untenstehenden Schritten:

- Eine Instanz der Presentation‑Klasse erstellen
- Den Verweis einer Folie über ihre Id oder ihren Index erhalten
- Die referenzierte Folie aus der Präsentation entfernen
- Die geänderte Präsentationsdatei schreiben

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
Es ist sehr einfach, die Position einer Folie in der Präsentation zu ändern. Folgen Sie einfach den untenstehenden Schritten:

- Eine Instanz der Presentation‑Klasse erstellen
- Den Verweis einer Folie über ihren Index erhalten
- Die SlideNumber der referenzierten Folie ändern
- Die geänderte Präsentationsdatei schreiben

Im untenstehenden Beispiel haben wir die Position einer Folie (die an der nullbasierten Indexposition 1 lag) der Präsentation auf Index 1 (Position 2) geändert.

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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)