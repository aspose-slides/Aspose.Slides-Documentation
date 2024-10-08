---
title: Assembler des diapositives
type: docs
weight: 10
url: /fr/net/assemble-slides/
---

Il couvre les fonctionnalités suivantes :
## **Ajouter une diapositive à la présentation**
Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive Master / Layout et d'autres diapositives normales. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour .NET. Chaque diapositive a un identifiant unique et toutes les diapositives normales sont disposées dans un ordre spécifié par l'index basé sur zéro.

Aspose.Slides pour .NET permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe **Presentation**
- Instancier la classe **SlideCollection** en définissant une référence à la propriété Slides (collection d'objets de diapositive de contenu) exposée par l'objet Presentation.
- Ajouter une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes **AddEmptySlide** exposées par l'objet **SlideCollection**
- Effectuer quelques travaux avec la nouvelle diapositive vide ajoutée
- Enfin, écrire le fichier de présentation en utilisant l'objet **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Instancier la classe SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Ajouter une diapositive vide à la collection de diapositives

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Enregistrer le fichier PPTX sur le disque

pres.Write("EmptySlide.pptx");

``` 
## **Accéder aux diapositives de la présentation**
Aspose.Slides pour .NET fournit une classe Presentation qui peut être utilisée pour trouver et accéder à n'importe quelle diapositive souhaitée présente dans la présentation.

**Utiliser la collection de diapositives**

La classe **Presentation** représente un fichier de présentation et expose toutes les diapositives qu'il contient sous forme de collection **SlideCollection** (qui est une collection d'objets **Slide**). Toutes ces diapositives peuvent être accédées à partir de cette collection **Slides** à l'aide d'un index de diapositive.

``` csharp

 //Instancier un objet Presentation qui représente un fichier de présentation

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accéder à une diapositive en utilisant son index de diapositive

SlideEx slide = pres.Slides[0];

``` 
## **Supprimer des diapositives**
Nous savons que la classe Presentation dans **Aspose.Slides pour .NET** représente un fichier de présentation. La classe Presentation encapsule une **SlideCollection** qui agit comme un référentiel de toutes les diapositives qui font partie de la présentation. Les développeurs peuvent supprimer une diapositive de cette collection de diapositives de deux manières :

- En utilisant une référence de diapositive
- En utilisant un index de diapositive

**Utiliser une référence de diapositive**

Pour supprimer une diapositive en utilisant sa référence, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son Id ou son index
- Supprimer la diapositive référencée de la présentation
- Écrire le fichier de présentation modifié

``` csharp

 //Instancier un objet Presentation qui représente un fichier de présentation

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accéder à une diapositive en utilisant son index dans la collection de diapositives

SlideEx slide = pres.Slides[0];

//Supprimer une diapositive en utilisant sa référence

pres.Slides.Remove(slide);

//Écrire le fichier de présentation

pres.Write("modified.pptx");

``` 
## **Changer la position de la diapositive :**
Il est très simple de changer la position d'une diapositive dans la présentation. Il suffit de suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son index
- Modifier le SlideNumber de la diapositive référencée
- Écrire le fichier de présentation modifié

Dans l'exemple donné ci-dessous, nous avons changé la position d'une diapositive (se trouvant à l'index zéro position 1) de la présentation à l'index 1 (Position 2).

``` csharp

 private static string MyDir = @"..\..\..\Fichiers d'échantillons\";

static void Main(string[] args)

{

AjouterDiapositiveÀLaPrésentation();

AccéderAuxDiapositivesDeLaPrésentation();

SupprimerDesDiapositives();

ChangerLaPositionDeLaDiapositive();

}

public static void AjouterDiapositiveÀLaPrésentation()

{

Presentation pres = new Presentation();

//Instancier la classe SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Ajouter une diapositive vide à la collection de diapositives

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Enregistrer le fichier PPTX sur le disque

pres.Save(MyDir + "Assembler des diapositives.pptx", SaveFormat.Pptx);

}

public static void AccéderAuxDiapositivesDeLaPrésentation()

{

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(MyDir + "Assembler des diapositives.pptx");

//Accéder à une diapositive en utilisant son index de diapositive

ISlide slide = pres.Slides[0];

}

public static void SupprimerDesDiapositives()

{

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(MyDir + "Assembler des diapositives.pptx");

//Accéder à une diapositive en utilisant son index dans la collection de diapositives

ISlide slide = pres.Slides[0];

//Supprimer une diapositive en utilisant sa référence

pres.Slides.Remove(slide);

//Écrire le fichier de présentation

pres.Save(MyDir + "Assembler des diapositives.pptx", SaveFormat.Pptx);

}

public static void ChangerLaPositionDeLaDiapositive()

{

//Instancier la classe Presentation pour charger le fichier de présentation source

Presentation pres = new Presentation(MyDir + "Assembler des diapositives.pptx");

{

    //Obtenir la diapositive dont la position doit être changée

    ISlide sld = pres.Slides[0];

    //Définir la nouvelle position pour la diapositive

    sld.SlideNumber = 2;

    //Écrire la présentation sur le disque

    pres.Save(MyDir + "Assembler des diapositives.pptx", SaveFormat.Pptx);

}

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)