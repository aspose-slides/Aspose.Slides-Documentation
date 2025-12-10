---
title: Assembler les diapositives
type: docs
weight: 10
url: /fr/net/assemble-slides/
---

## **Ajouter une diapositive à une présentation**
Avant de parler d’ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Maître / Mise en page et d’autres diapositives Normales. Cela signifie qu’un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for .NET. Chaque diapositive possède un Id unique et toutes les Diapositives Normales sont disposées dans un ordre spécifié par l’indice basé sur zéro.

- Créez une instance de la classe **Presentation**
- Instanciez la classe **SlideCollection** en définissant une référence à la propriété Slides (collection d’objets Slide de contenu) exposée par l’objet Presentation.
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes **AddEmptySlide** exposées par l’objet **SlideCollection**.
- Effectuez des opérations avec la diapositive vide nouvellement ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l’objet **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Instanciez la classe SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Ajoutez une diapositive vide à la collection Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Enregistrez le fichier PPTX sur le disque

pres.Write("EmptySlide.pptx");

``` 
## **Accéder aux diapositives d’une présentation**
Aspose.Slides for .NET fournit la classe Presentation qui peut être utilisée pour trouver et accéder à toute diapositive souhaitée présente dans la présentation.

**Utilisation de la collection Slides**

**Presentation** classe représente un fichier de présentation et expose toutes les diapositives qu’il contient sous forme d’une collection **SlideCollection** (c’est‑à‑dire une collection d’objets **Slide**). Toutes ces diapositives peuvent être accessibles depuis cette collection **Slides** à l’aide d’un indice de diapositive.

``` csharp

 //Instanciez un objet Presentation qui représente un fichier de présentation

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accédez à une diapositive en utilisant son indice

SlideEx slide = pres.Slides[0];

``` 
## **Supprimer des diapositives**
Nous savons que la classe Presentation dans **Aspose.Slides for .NET** représente un fichier de présentation. La classe Presentation encapsule une **SlideCollection** qui agit comme un dépôt de toutes les diapositives faisant partie de la présentation. Les développeurs peuvent supprimer une diapositive de cette collection Slides de deux manières :

- En utilisant la référence de diapositive
- En utilisant l’indice de diapositive

**En utilisant la référence de diapositive**

Pour supprimer une diapositive en utilisant sa référence, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive en utilisant son Id ou son indice
- Supprimez la diapositive référencée de la présentation
- Enregistrez le fichier de présentation modifié

``` csharp

 //Instanciez un objet Presentation qui représente un fichier de présentation

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accédez à une diapositive en utilisant son indice dans la collection Slides

SlideEx slide = pres.Slides[0];

//Supprimez une diapositive en utilisant sa référence

pres.Slides.Remove(slide);

//Enregistrez le fichier de présentation

pres.Write("modified.pptx");

``` 
## **Modifier la position d’une diapositive**
Il est très simple de modifier la position d’une diapositive dans la présentation. Suivez simplement les étapes ci‑dessus :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive en utilisant son indice
- Modifiez la propriété SlideNumber de la diapositive référencée
- Enregistrez le fichier de présentation modifié

Dans l’exemple ci‑dessous, nous avons modifié la position d’une diapositive (située à l’indice zéro, position 1) de la présentation pour la placer à l’indice 1 (position 2).

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

//Instanciez la classe SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Ajoutez une diapositive vide à la collection Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Enregistrez le fichier PPTX sur le disque

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instanciez un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accédez à une diapositive en utilisant son indice

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instanciez un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accédez à une diapositive en utilisant son indice dans la collection Slides

ISlide slide = pres.Slides[0];

//Supprimez une diapositive en utilisant sa référence

pres.Slides.Remove(slide);

//Enregistrez le fichier PPTX sur le disque

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instanciez la classe Presentation pour charger le fichier de présentation source

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Obtenez la diapositive dont la position doit être modifiée

    ISlide sld = pres.Slides[0];

    //Définissez la nouvelle position pour la diapositive

    sld.SlideNumber = 2;

    //Enregistrez la présentation sur le disque

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Télécharger le code d’exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)