---
title: Ajouter des diapositives de mise en page à la présentation
type: docs
weight: 20
url: /fr/net/add-layout-slides-to-presentation/
---

Aspose.Slides pour .NET permet aux développeurs d'ajouter de nouvelles diapositives de mise en page dans une présentation. Pour ajouter une diapositive de mise en page, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Accéder à la collection de diapositives maîtresses
- Essayer de trouver des diapositives de mise en page existantes pour voir si celle requise est déjà disponible dans la collection de diapositives de mise en page ou non
- Ajouter une nouvelle diapositive de mise en page si la mise en page souhaitée n'est pas disponible
- Ajouter une diapositive vide avec la nouvelle diapositive de mise en page ajoutée
- Enfin, écrire le fichier de présentation en utilisant l'objet Presentation
## **Exemple**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Ajouter des diapositives de mise en page.pptx";

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

        // La situation lorsqu'une présentation ne contient pas certains types de diapositives de mise en page.

        // La présentation Technographics.pptx ne contient que des types de mises en page Vides et Personnalisées.

        // Mais les diapositives de mise en page de type Personnalisé ont des noms de diapositives différents,

        // comme "Titre", "Titre et Contenu", etc. Et il est possible d'utiliser ces

        // noms pour la sélection de diapositives de mise en page.

        // Il est également possible d'utiliser l'ensemble des types de formes de remplacement. Par exemple,

        // La diapositive de titre ne devrait avoir que le type de forme de remplacement Titre, etc.

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

    //Ajouter une diapositive vide avec la diapositive de mise en page ajoutée 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Enregistrer la présentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Télécharger l'exemple en cours d'exécution**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Ajouter des diapositives de mise en page à la présentation](/slides/fr/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}