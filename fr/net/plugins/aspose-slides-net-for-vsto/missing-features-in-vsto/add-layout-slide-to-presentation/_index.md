---
title: Ajouter une diapositive de mise en page à la présentation
type: docs
weight: 10
url: /fr/net/add-layout-slide-to-presentation/
---

Aspose.Slides pour .NET permet aux développeurs d'ajouter de nouvelles diapositives de mise en page dans une présentation. Pour ajouter une diapositive de mise en page, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation
- Accédez à la collection de Master Slides
- Essayez de trouver des diapositives de mise en page existantes pour voir si celle requise est déjà disponible dans la collection de diapositives de mise en page ou non
- Ajoutez une nouvelle diapositive de mise en page si la mise en page souhaitée n'est pas disponible
- Ajoutez une diapositive vide avec la diapositive de mise en page nouvellement ajoutée
- Enfin, écrivez le fichier de présentation en utilisant l'objet Presentation.
## **Exemple**
``` csharp

 //Instancier la classe Presentation qui représente le fichier de présentation

using (Presentation p = new Presentation("Test.pptx"))

{

   // Essayer de rechercher par type de diapositive de mise en page

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // La situation où une présentation ne contient pas certains types de mises en page.

     // La présentation Technographics.pptx ne contient que des types de mise en page Vides et Personnalisés.

     // Mais les diapositives de mise en page avec des types Personnalisés ont des noms de diapositive différents,

     // comme "Titre", "Titre et Contenu", etc. Et il est possible d'utiliser ces

     // noms pour la sélection de la diapositive de mise en page.

     // Il est également possible d'utiliser l'ensemble des types de formes de zones réservées. Par exemple,

     // La diapositive de titre ne doit avoir que le type de zone réservée Titre, etc.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Titre et Objet")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Titre")

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

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Titre et Objet");

             }

          }

      }

  }

  //Ajout d'une diapositive vide avec la diapositive de mise en page ajoutée

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Enregistrer la présentation

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Télécharger un exemple fonctionnel**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **Télécharger un code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Ajouter une diapositive de mise en page à la présentation](/slides/fr/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}