---
title: Ajouter des diapositives de mise en page à la présentation
type: docs
weight: 20
url: /fr/net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NET permet aux développeurs d’ajouter de nouvelles diapositives de mise en page dans une présentation. Pour ajouter une diapositive de mise en page, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe Presentation
- Accéder à la collection Master Slide
- Essayer de trouver des diapositives de mise en page existantes pour vérifier si celle requise est déjà disponible dans la collection Layout Slide ou non
- Ajouter une nouvelle diapositive de mise en page si la mise en page souhaitée n’est pas disponible
- Ajouter une diapositive vide avec la nouvelle diapositive de mise en page
- Enfin, écrire le fichier de présentation en utilisant l’objet Presentation

## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instancier la classe Presentation qui représente le fichier de présentation

using (Presentation p = new Presentation(FileName))

{

    // Essayer de rechercher par type de diapositive de mise en page

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Situation où une présentation ne contient pas certains types de mises en page.

        // La présentation Technographics.pptx ne contient que les types de mise en page Blank et Custom.

        // Mais les diapositives de mise en page de type Custom ont des noms de diapositives différents,

        // comme "Title", "Title and Content", etc. Et il est possible d’utiliser ceux‑ci

        // comme noms pour la sélection de la diapositive de mise en page.

        // Il est également possible d’utiliser l’ensemble des types de formes d’espace réservé. Par exemple,

        // La diapositive Titre ne doit contenir que le type de placeholder Title, etc.

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

    //Ajouter une diapositive vide avec la diapositive de mise en page ajoutée 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Enregistrer la présentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Télécharger l'exemple en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Pour plus de détails, consultez [Appliquer ou modifier les mises en page des diapositives dans .NET](/slides/fr/net/slide-layout/).

{{% /alert %}}