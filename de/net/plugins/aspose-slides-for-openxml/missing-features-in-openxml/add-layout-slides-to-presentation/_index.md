---
title: Layout-Folien zur Präsentation hinzufügen
type: docs
weight: 20
url: /de/net/add-layout-slides-to-presentation/
---

Aspose.Slides für .NET ermöglicht Entwicklern, neue Layout-Folien in einer Präsentation hinzuzufügen. Befolgen Sie die folgenden Schritte, um eine Layout-Folie hinzuzufügen:

- Erstellen Sie eine Instanz der Klasse Präsentation
- Greifen Sie auf die Master-Folien-Kollektion zu
- Versuchen Sie, vorhandene Layout-Folien zu finden, um festzustellen, ob die benötigte bereits in der Layout-Folien-Kollektion verfügbar ist oder nicht
- Fügen Sie eine neue Layout-Folie hinzu, wenn das gewünschte Layout nicht vorhanden ist
- Fügen Sie eine leere Folie mit der neu hinzugefügten Layout-Folie hinzu
- Schließlich speichern Sie die Präsentationsdatei mit dem Präsentationsobjekt
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Hinzufügen von Layout-Folien.pptx";

//Erstellen Sie eine Instanz der Klasse Präsentation, die die Präsentationsdatei darstellt

using (Presentation p = new Presentation(FileName))

{

    // Versuchen Sie, nach Layoutfolientyp zu suchen

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Die Situation, in der eine Präsentation nicht über einige Layouttypen verfügt.

        // Die Präsentation Technographics.pptx enthält nur leere und benutzerdefinierte Layouttypen.

        // Aber Layout-Folien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,

        // wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese

        // Namen zur Auswahl von Layout-Folien zu verwenden.

        // Es ist auch möglich, die Sammlung von Platzhalterformtypen zu verwenden. Zum Beispiel,

        // sollte die Titelfolie nur den Platzhaltertyp "Titel" haben, usw.

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Titel und Objekt")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "Titel")

                {

                    layoutSlide = titleLayoutSlide;

                    break;

                }

            }

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

                if (layoutSlide == null)

                {

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Titel und Objekt");

                }

            }

        }

    }

    //Leere Folie mit hinzugefügter Layoutfolie hinzufügen

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Präsentation speichern 

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Laufendes Beispiel herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Layout-Folien zur Präsentation hinzufügen](/slides/de/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}