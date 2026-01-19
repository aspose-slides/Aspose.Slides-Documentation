---
title: Layout-Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/net/add-layout-slide-to-presentation/
---

Aspose.Slides für .NET ermöglicht Entwicklern, neue Layout‑Folien in einer Präsentation hinzuzufügen. Um eine Layout‑Folie hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse Presentation
- Greifen Sie auf die Master‑Folien‑Sammlung zu
- Versuchen Sie, vorhandene Layout‑Folien zu finden, um zu prüfen, ob die gewünschte bereits in der Layout‑Folien‑Sammlung vorhanden ist oder nicht
- Fügen Sie eine neue Layout‑Folie hinzu, wenn das gewünschte Layout nicht verfügbar ist
- Fügen Sie eine leere Folie mit der neu hinzugefügten Layout‑Folie ein
- Speichern Sie schließlich die Präsentationsdatei mithilfe des Presentation‑Objekts.
## **Beispiel**
``` csharp

 //Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation("Test.pptx"))

{

   // Try to search by layout slide type

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // The situation when a presentation doesn't contain some type of layouts.

     // Technographics.pptx presentation only contains Blank and Custom layout types.

     // But layout slides with Custom types has different slide names,

     // like "Title", "Title and Content", etc. And it is possible to use these

     // names for layout slide selection.

     // Also it is possible to use the set of placeholder shape types. For example,

     // Title slide should have only Title pleceholder type, etc.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Title and Object")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Title")

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

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

             }

          }

      }

  }

  //Adding empty slide with added layout slide

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Save presentation

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Weitere Details finden Sie unter [Anwenden oder Ändern von Folienlayouts in .NET](/slides/de/net/slide-layout/).

{{% /alert %}}