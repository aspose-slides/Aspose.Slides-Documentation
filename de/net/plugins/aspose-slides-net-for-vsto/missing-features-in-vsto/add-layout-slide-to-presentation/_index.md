---
title: Layout-Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/net/add-layout-slide-to-presentation/
---

Aspose.Slides für .NET ermöglicht Entwicklern das Hinzufügen neuer Layout-Folien in Präsentationen. Um eine Layout-Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Greifen Sie auf die Master-Folien-Sammlung zu
- Versuchen Sie, vorhandene Layout-Folien zu finden, um festzustellen, ob die erforderliche bereits in der Layout-Folien-Sammlung verfügbar ist
- Fügen Sie eine neue Layout-Folie hinzu, wenn das gewünschte Layout nicht verfügbar ist
- Fügen Sie eine leere Folie mit der neu hinzugefügten Layout-Folie hinzu
- Schließlich speichern Sie die Präsentationsdatei mithilfe des Präsentationsobjekts.
## **Beispiel**
``` csharp

 //Instanziieren Sie die Präsentationsklasse, die die Präsentationsdatei repräsentiert

using (Presentation p = new Presentation("Test.pptx"))

{

   // Versuchen Sie, nach Layout-Folien vom Typ zu suchen

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Die Situation, in der eine Präsentation einige Layouttypen nicht enthält.

     // Die Präsentation Technographics.pptx enthält nur leere und benutzerdefinierte Layouttypen.

     // Aber Layout-Folien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,

     // wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese

     // Namen zur Auswahl von Layout-Folien zu verwenden.

     // Es ist auch möglich, die Menge von Platzhalter-Formtypen zu verwenden. Zum Beispiel,

     // Die Titelseite sollte nur den Platzhaltertyp Titel haben, usw.

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

  //Hinzufügen einer leeren Folie mit der hinzugefügten Layout-Folie

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Präsentation speichern

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Laden Sie das laufende Beispiel herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **Beispielcode herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Layout-Folie zur Präsentation hinzufügen](/slides/de/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}