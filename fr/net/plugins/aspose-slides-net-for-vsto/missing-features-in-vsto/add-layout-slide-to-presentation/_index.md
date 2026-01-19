---
title: Ajouter une diapositive de mise en page à la présentation
type: docs
weight: 10
url: /fr/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NET permet aux développeurs d’ajouter de nouvelles diapositives de mise en page dans une présentation. Pour ajouter une diapositive de mise en page, suivez les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Accéder à la collection des diapositives maître
- Essayer de trouver des diapositives de mise en page existantes pour voir si celle requise est déjà disponible dans la collection de diapositives de mise en page ou non
- Ajouter une nouvelle diapositive de mise en page si la mise en page souhaitée n’est pas disponible
- Ajouter une diapositive vide avec la nouvelle diapositive de mise en page ajoutée
- Enfin, écrire le fichier de présentation à l’aide de l’objet Presentation.
## **Exemple**
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
## **Télécharger l'exemple en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pour plus de détails, consultez [Appliquer ou modifier les mises en page des diapositives dans .NET](/slides/fr/net/slide-layout/).

{{% /alert %}}