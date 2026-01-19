---
title: Assembler les diapositives
type: docs
weight: 10
url: /fr/net/assemble-slides/
---

## **Ajouter une diapositive à une présentation**
Avant de parler d’ajouter des diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Maître/Disposition et d’autres diapositives Normales. Cela signifie qu’un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for .NET. Chaque diapositive possède un Id unique et toutes les Diapositives Normales sont organisées dans un ordre spécifié par un index basé sur zéro.

Aspose.Slides for .NET permet aux développeurs d’ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, suivez les étapes ci‑dessous :

- Créez une instance de la classe **Presentation**
- Instanciez la classe **SlideCollection** en définissant une référence à la propriété Slides (collection d’objets Slide de contenu) exposée par l’objet Presentation.
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes **AddEmptySlide** exposées par l’objet **SlideCollection**
- Effectuez des opérations avec la diapositive vide nouvellement ajoutée
- Enfin, écrivez le fichier de présentation en utilisant l’objet **Presentation**

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
## **Accéder aux diapositives d’une présentation**
Aspose.Slides for .NET fournit la classe Presentation qui peut être utilisée pour trouver et accéder à n’importe quelle diapositive souhaitée présente dans la présentation.

**Utilisation de la collection Slides**

La classe **Presentation** représente un fichier de présentation et expose toutes les diapositives qu’il contient sous forme de collection **SlideCollection** (c’est‑à‑dire une collection d’objets **Slide**). Toutes ces diapositives peuvent être consultées depuis cette collection **Slides** à l’aide d’un index de diapositive.

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **Supprimer des diapositives**
Nous savons que la classe Presentation dans **Aspose.Slides for .NET** représente un fichier de présentation. La classe Presentation encapsule une **SlideCollection** qui sert de référentiel à toutes les diapositives faisant partie de la présentation. Les développeurs peuvent supprimer une diapositive de cette collection Slides de deux manières :

- Utilisation de la référence de diapositive
- Utilisation de l’index de diapositive

**Utilisation de la référence de diapositive**

Pour supprimer une diapositive en utilisant sa référence, suivez les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive en utilisant son Id ou son Index
- Supprimez la diapositive référencée de la présentation
- Écrivez le fichier de présentation modifié

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
## **Modifier la position d’une diapositive**
Il est très simple de changer la position d’une diapositive dans la présentation. Suivez simplement les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive en utilisant son Index
- Modifiez la propriété SlideNumber de la diapositive référencée
- Écrivez le fichier de présentation modifié

Dans l’exemple ci‑dessous, nous avons changé la position d’une diapositive (située à l’index zéro : position 1) de la présentation à l’index 1 (Position 2).

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
## **Télécharger le code d’exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)