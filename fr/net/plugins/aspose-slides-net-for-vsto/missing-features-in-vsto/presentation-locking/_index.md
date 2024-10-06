---
title: Verrouillage de Présentation
type: docs
weight: 110
url: /net/presentation-locking/
---

## **Verrouillage de Présentation**
Une utilisation courante de **Aspose.Slides** est de créer, mettre à jour et sauvegarder des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations générées. Les protéger contre l'édition est une préoccupation courante. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Ceci explique comment les présentations et les diapositives sont construites et comment Aspose.Slides pour .NET peut appliquer et ensuite retirer la protection d'une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de la rédaction, n'est pas disponible dans Microsoft PowerPoint. Elle offre aux développeurs un moyen de contrôler comment les présentations créées par leurs applications sont utilisées.
## **Composition d'une Diapositive**
Une diapositive PPTX est composée d'un certain nombre de composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'images, des cadres vidéo, des connecteurs et divers autres éléments disponibles pour construire une présentation.

Dans Aspose.Slides pour .NET, chaque élément sur une diapositive est transformé en un objet Shape. En d'autres termes, chaque élément sur la diapositive est soit un objet Shape, soit un objet dérivé de l'objet Shape.

La structure du PPTX est complexe, donc contrairement au PPT, où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour .NET pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d'images.

Toute action effectuée sur tous les objets Shape dans un objet Presentation est appliquée à l'ensemble de la présentation.
## **Application et Suppression de Protection**
L'application de protection garantit qu'une présentation ne peut pas être modifiée. C'est une technique utile pour protéger le contenu d'une présentation.

**Application de la Protection aux Formes PPTX**

Aspose.Slides pour .NET fournit la classe Shape pour manipuler une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrou associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection), et elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent la protection à tous les types de formes dans une présentation.

``` csharp

 //Instancier la classe Presentation qui représente un fichier PPTX

PresentationEx pTemplate = new PresentationEx("Application de Protection.pptx");//Instancier la classe Presentation qui représente un fichier PPTX


//Objet ISlide pour accéder aux diapositives de la présentation

SlideEx slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires

ShapeEx shape;

//Parcours de toutes les diapositives de la présentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Parcours de toutes les formes dans les diapositives

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forme est une forme automatique

		if (shape is AutoShapeEx)

		{

			//Casting en forme automatique et obtention du verrou de forme automatique

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Application des verrous de formes

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//si la forme est une forme groupée

		else if (shape is GroupShapeEx)

		{

			//Casting en forme groupée et obtention du verrou de forme groupée

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Application des verrous de formes

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//si la forme est un connecteur

		else if (shape is ConnectorEx)

		{

			//Casting en forme de connecteur et obtention du verrou de forme de connecteur

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Application des verrous de formes

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//si la forme est un cadre d'image

		else if (shape is PictureFrameEx)

		{

			//Casting en forme de cadre d'image et obtention du verrou de forme de cadre d'image

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Application des verrous de formes

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Sauvegarde du fichier de présentation

pTemplate.Save("ÉchantillonProtégé.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Suppression de la Protection**

La protection appliquée à l'aide d'Aspose.Slides pour .NET ne peut être supprimée qu'avec Aspose.Slides pour .NET. Pour débloquer une forme, définissez la valeur du verrou appliqué sur false. L'exemple de code qui suit montre comment débloquer des formes dans une présentation verrouillée.

``` csharp

 //Ouvrir la présentation souhaitée

PresentationEx pTemplate = new PresentationEx("ÉchantillonProtégé.pptx");

//Objet ISlide pour accéder aux diapositives de la présentation

SlideEx slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires

ShapeEx shape;

//Parcours de toutes les diapositives de la présentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Parcours de toutes les formes dans les diapositives

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forme est une forme automatique

		if (shape is AutoShapeEx)

		{

			//Casting en forme automatique et obtention du verrou de forme automatique

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Application des verrous de formes

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//si la forme est une forme groupée

		else if (shape is GroupShapeEx)

		{

			//Casting en forme groupée et obtention du verrou de forme groupée

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Application des verrous de formes

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//si la forme est une forme de connecteur

		else if (shape is ConnectorEx)

		{

			//Casting en forme de connecteur et obtention du verrou de forme de connecteur

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Application des verrous de formes

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//si la forme est un cadre d'image

		else if (shape is PictureFrameEx)

		{

			//Casting en forme de cadre d'image et obtention du verrou de forme de cadre d'image

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Application des verrous de formes

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Sauvegarde du fichier de présentation

pTemplate.Save("ÉchantillonSupprimerProtection.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)