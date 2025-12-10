---
title: Verrouillage de la présentation
type: docs
weight: 110
url: /fr/net/presentation-locking/
---

## **Verrouillage de la présentation**
Une utilisation courante de **Aspose.Slides** consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d’un flux de travail automatisé. Les utilisateurs de l’application qui utilise Aspose.Slides de cette façon ont accès aux présentations générées. Les protéger contre toute modification est une préoccupation fréquente. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d’origine.

Cela explique comment les présentations et les diapositives sont construites et comment Aspose.Slides pour .NET peut appliquer une protection à une présentation, puis la supprimer. Cette fonctionnalité est propre à Aspose.Slides et, au moment de la rédaction, n’est pas disponible dans Microsoft PowerPoint. Elle offre aux développeurs un moyen de contrôler l’utilisation des présentations créées par leurs applications.
## **Composition d’une diapositive**
Une diapositive PPTX est composée d’un certain nombre de composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et divers autres éléments disponibles pour construire une présentation.

Dans Aspose.Slides pour .NET, chaque élément d’une diapositive est transformé en un objet Shape. En d’autres termes, chaque élément de la diapositive est soit un objet Shape, soit un objet dérivé de Shape.

La structure du PPTX est complexe, ainsi, contrairement à PPT où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour chaque type de forme. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour .NET pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes de connecteur.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d’image.

Toute action effectuée sur tous les objets Shape d’un objet Presentation est appliquée à l’ensemble de la présentation.
## **Appliquer et supprimer la protection**
L’application d’une protection garantit qu’une présentation ne peut pas être modifiée. C’est une technique utile pour protéger le contenu d’une présentation.

**Appliquer la protection aux formes PPTX**

Aspose.Slides pour .NET fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme possède une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection), et qu’elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent la protection à tous les types de formes d’une présentation.

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Suppression de la protection**

La protection appliquée à l’aide d’Aspose.Slides pour .NET ne peut être supprimée qu’avec Aspose.Slides pour .NET. Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur false. L’exemple de code qui suit montre comment déverrouiller les formes dans une présentation verrouillée.

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Télécharger le code d’exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)