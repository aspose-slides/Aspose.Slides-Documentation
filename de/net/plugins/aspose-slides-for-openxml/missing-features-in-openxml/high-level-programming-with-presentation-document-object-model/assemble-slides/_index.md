---
title: Folien Zusammenstellen
type: docs
weight: 10
url: /net/assemble-slides/
---

Es werden die folgenden Funktionen abgedeckt:
## **Folie zur Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien besprechen. Jede PowerPoint-Präsentationsdatei enthält Master-/Layoutfolien und andere Normalfolien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige ID und alle Normalfolien sind in der Reihenfolge angeordnet, die durch den nullbasierten Index angegeben ist.

Aspose.Slides für .NET ermöglicht es Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der **Presentation**-Klasse
- Instanziieren Sie die **SlideCollection**-Klasse, indem Sie eine Referenz auf die Slides (Sammlung von Inhalt-Folien) Eigenschaft, die vom Presentation-Objekt bereitgestellt wird, setzen.
- Fügen Sie eine leere Folie am Ende der Sammlung von Inhaltsfolien hinzu, indem Sie die **AddEmptySlide**-Methoden verwenden, die vom **SlideCollection**-Objekt bereitgestellt werden
- Arbeiten Sie mit der neu hinzugefügten leeren Folie
- Schreiben Sie schließlich die Präsentationsdatei mit dem **Presentation**-Objekt

``` csharp

 PresentationEx pres = new PresentationEx();

//Instanziieren Sie die SlideCollection-Klasse

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Fügen Sie der Slides-Sammlung eine leere Folie hinzu

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Speichern Sie die PPTX-Datei auf der Festplatte

pres.Write("EmptySlide.pptx");

``` 
## **Zugriff auf Folien der Präsentation**
Aspose.Slides für .NET bietet die Presentation-Klasse, die verwendet werden kann, um eine gewünschte Folie in der Präsentation zu finden und darauf zuzugreifen.

**Verwendung der Folienkollektion**

Die **Presentation**-Klasse stellt eine Präsentationsdatei dar und bietet alle Folien darin als eine **SlideCollection**-Sammlung (das ist eine Sammlung von **Slide**-Objekten) an. Alle diese Folien können von dieser **Slides**-Sammlung unter Verwendung eines Folienindex zugegriffen werden.

``` csharp

 //Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Zugriff auf eine Folie unter Verwendung ihres Folienindex

SlideEx slide = pres.Slides[0];

``` 
## **Folien entfernen**
Wir wissen, dass die Präsentationsklasse in **Aspose.Slides für .NET** eine Präsentationsdatei darstellt. Die Präsentationsklasse kapselt eine **SlideCollection**, die als Repository aller Folien fungiert, die Teil der Präsentation sind. Entwickler können eine Folie aus dieser Slides-Sammlung auf zwei Arten entfernen:

- Verwendung der Folienreferenz
- Verwendung des Folienindex

**Verwendung der Folienreferenz**

Um eine Folie anhand ihrer Referenz zu entfernen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihre ID oder ihren Index verwenden
- Entfernen Sie die referenzierte Folie aus der Präsentation
- Schreiben Sie die modifizierte Präsentationsdatei

``` csharp

 //Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Zugriff auf eine Folie unter Verwendung ihres Index in der Slides-Sammlung

SlideEx slide = pres.Slides[0];

//Entfernen einer Folie anhand ihrer Referenz

pres.Slides.Remove(slide);

//Schreiben der Präsentationsdatei

pres.Write("modified.pptx");

``` 
## **Position der Folie ändern:**
Es ist sehr einfach, die Position einer Folie in der Präsentation zu ändern. Folgen Sie einfach den folgenden Schritten:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Ändern Sie die Foliennummer der referenzierten Folie
- Schreiben Sie die modifizierte Präsentationsdatei

Im folgenden Beispiel haben wir die Position einer Folie (die sich an der Null-Index-Position 1 befindet) der Präsentation auf Index 1 (Position 2) geändert.

``` csharp

 private static string MyDir = @"..\..\..\Beispieldateien\";

static void Main(string[] args)

{

FolieZurPräsentationHinzufügen();

ZugriffAufFolienDerPräsentation();

FolienEntfernen();

PositionDerFolieÄndern();

}

public static void FolieZurPräsentationHinzufügen()

{

Presentation pres = new Presentation();

//Instanziieren Sie die SlideCollection-Klasse

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Fügen Sie der Slides-Sammlung eine leere Folie hinzu

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Speichern Sie die PPTX-Datei auf der Festplatte

pres.Save(MyDir + "Folien Zusammenstellen.pptx", SaveFormat.Pptx);

}

public static void ZugriffAufFolienDerPräsentation()

{

//Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation(MyDir + "Folien Zusammenstellen.pptx");

//Zugriff auf eine Folie unter Verwendung ihres Folienindex

ISlide slide = pres.Slides[0];

}

public static void FolienEntfernen()

{

//Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation(MyDir + "Folien Zusammenstellen.pptx");

//Zugriff auf eine Folie unter Verwendung ihres Index in der Slides-Sammlung

ISlide slide = pres.Slides[0];

//Entfernen einer Folie anhand ihrer Referenz

pres.Slides.Remove(slide);

//Schreiben der Präsentationsdatei

pres.Save(MyDir + "Folien Zusammenstellen.pptx", SaveFormat.Pptx);

}

public static void PositionDerFolieÄndern()

{

//Instanziieren Sie die Präsentationsklasse zum Laden der Quelldatei 

Presentation pres = new Presentation(MyDir + "Folien Zusammenstellen.pptx");

{

    //Holen Sie sich die Folie, deren Position geändert werden soll

    ISlide sld = pres.Slides[0];

    //Setzen Sie die neue Position für die Folie

    sld.SlideNumber = 2;

    //Schreiben Sie die Präsentation auf die Festplatte

    pres.Save(MyDir + "Folien Zusammenstellen.pptx", SaveFormat.Pptx);

}

}

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)