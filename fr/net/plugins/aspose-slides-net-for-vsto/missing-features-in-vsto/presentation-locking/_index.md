---
title: Verrouillage de Présentation
type: docs
weight: 110
url: /net/presentation-locking/
---

## **Verrouillage de Présentation**
Une utilisation courante pour **Aspose.Slides** est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations de sortie. Les protéger de la modification est une préoccupation courante. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Cela explique comment les présentations et les diapositives sont construites et comment Aspose.Slides pour .NET peut appliquer une protection à, puis la retirer d'une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de l'écriture, n'est pas disponible dans Microsoft PowerPoint. Elle fournit aux développeurs un moyen de contrôler la manière dont les présentations créées par leurs applications sont utilisées.
## **Composition d'une Diapositive**
Une diapositive PPTX est composée d'un certain nombre de composants comme des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et les divers autres éléments disponibles pour construire une présentation.

Dans Aspose.Slides pour .NET, chaque élément sur une diapositive est transformé en un objet Shape. En d'autres termes, chaque élément sur la diapositive est soit un objet Shape, soit un objet dérivé de l'objet Shape.

La structure du PPTX est complexe, donc contrairement au PPT, où un verrouillage générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour .NET pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes de connecteur.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes de groupe.
- PictureFrameLock verrouille les cadres d'image.

Toute action effectuée sur tous les objets Shape d'un objet Presentation est appliquée à l'ensemble de la présentation.
## **Application et Suppression de Protection**
Appliquer une protection garantit qu'une présentation ne peut pas être modifiée. C'est une technique utile pour protéger le contenu d'une présentation.

**Application de la Protection aux Formes PPTX**

Aspose.Slides pour .NET fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrou associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent une protection à tous les types de formes dans une présentation.

``` csharp

 //Instancier la classe Presentation qui représente un fichier PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instancier la classe Presentation qui représente un fichier PPTX


//Objet ISlide pour accéder aux diapositives de la présentation

SlideEx slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires

ShapeEx shape;

//Parcourir toutes les diapositives de la présentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Parcourir toutes les formes dans les diapositives

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forme est une forme automatique

		if (shape is AutoShapeEx)

		{

			//Conversion en AutoShape et obtention du verrou de forme automatique

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Application des verrous de formes

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//si la forme est une forme de groupe

		else if (shape is GroupShapeEx)

		{

			//Conversion en forme de groupe et obtention du verrou de forme de groupe

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

			//Conversion en forme de connecteur et obtention du verrou de forme de connecteur

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

			//Conversion en forme de cadre d'image et obtention du verrou de forme de cadre d'image

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Application des verrous de formes

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Sauvegarder le fichier de présentation

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Suppression de la Protection**

La protection appliquée avec Aspose.Slides pour .NET ne peut être supprimée qu'avec Aspose.Slides pour .NET. Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur false. L'exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.

``` csharp

 //Ouvrir la présentation désirée

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Objet ISlide pour accéder aux diapositives de la présentation

SlideEx slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires

ShapeEx shape;

//Parcourir toutes les diapositives de la présentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Parcourir toutes les formes dans les diapositives

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//si la forme est une forme automatique

		if (shape is AutoShapeEx)

		{

			//Conversion en forme automatique et obtention du verrou de forme automatique

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Application des verrous de formes

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//si la forme est une forme de groupe

		else if (shape is GroupShapeEx)

		{

			//Conversion en forme de groupe et obtention du verrou de forme de groupe

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

			//Conversion en forme de connecteur et obtention du verrou de forme de connecteur

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

			//Conversion en forme de cadre d'image et obtention du verrou de forme de cadre d'image

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Application des verrous de formes

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Sauvegarder le fichier de présentation

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Télécharger le Code d'Exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)