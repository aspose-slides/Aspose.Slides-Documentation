---
title: Manipulations de formes
type: docs
weight: 40
url: /fr/net/shape-manipulations/
keywords: "forme PowerPoint, forme sur diapositive, trouver forme, cloner forme, supprimer forme, masquer forme, modifier l'ordre des formes, obtenir l'ID de forme interop, texte alternatif de forme, formats de mise en page de forme, forme en SVG, aligner forme, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Manipuler les formes PowerPoint en C# ou .NET"
---

## **Trouver une forme dans la diapositive**
Ce sujet décrit une technique simple pour faciliter les développeurs à trouver une forme précise sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint ne possèdent aucun moyen d’identifier les formes sur une diapositive autrement que par un Id interne unique. Il semble difficile pour les développeurs de trouver une forme en utilisant cet Id interne unique. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d’utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier ultérieurement.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ouvrir cette présentation avec Aspose.Slides for .NET et parcourir toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme dont le texte alternatif correspond sera celle recherchée. Pour illustrer cette technique de façon plus claire, nous avons créé une méthode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) qui permet de trouver une forme précise dans une diapositive et renvoie simplement cette forme.
```c#
public static void Run()
{
    // Instancier une classe Presentation qui représente le fichier de présentation
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Texte alternatif de la forme à rechercher
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implémentation de la méthode pour trouver une forme dans une diapositive à l'aide de son texte alternatif
public static IShape FindShape(ISlide slide, string alttext)
{
    // Itération à travers toutes les formes de la diapositive
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Si le texte alternatif de la forme correspond à celui requis alors
        // Retourner la forme
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **Cloner une forme**
Pour cloner une forme sur une diapositive avec Aspose.Slides for .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrez la présentation modifiée au format PPTX.

L’exemple ci‑dessous ajoute une forme groupée à une diapositive.
```c#
 // Instancier la classe Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Enregistrer le fichier PPTX sur le disque
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```




## **Supprimer une forme**
Aspose.Slides for .NET permet aux développeurs de supprimer n’importe quelle forme. Pour supprimer une forme d’une diapositive, suivez les étapes ci‑dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec le texte alternatif spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.
```c#
// Créer un objet Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Ajouter une forme auto de type rectangle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Enregistrer la présentation sur le disque
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```




## **Masquer une forme**
Aspose.Slides for .NET permet aux développeurs de masquer n’importe quelle forme. Pour masquer une forme d’une diapositive, suivez les étapes ci‑dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec le texte alternatif spécifique.
1. Masquez la forme.
1. Enregistrez le fichier sur le disque.
```c#
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();

// Obtenir la première diapositive
ISlide sld = pres.Slides[0];

// Ajouter une forme auto de type rectangle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Enregistrer la présentation sur le disque
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```




## **Modifier l’ordre des formes**
Aspose.Slides for .NET permet aux développeurs de réorganiser les formes. Réorganiser les formes spécifie quelle forme est au premier plan ou à l’arrière‑plan. Pour réorganiser les formes d’une diapositive, suivez les étapes ci‑dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre texte de la forme.
1. Ajoutez une autre forme aux mêmes coordonnées.
1. Réorganisez les formes.
1. Enregistrez le fichier sur le disque.
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **Obtenir l’ID Interop de la forme**
Aspose.Slides for .NET permet aux développeurs d’obtenir un identifiant de forme unique dans la portée de la diapositive, contrairement à la propriété UniqueId qui fournit un identifiant unique dans la portée de la présentation. La propriété OfficeInteropShapeId a été ajoutée aux interfaces IShape et à la classe Shape. La valeur renvoyée par la propriété OfficeInteropShapeId correspond à la valeur de l’Id de l’objet Microsoft.Office.Interop.PowerPoint.Shape. Le code d’exemple suivant est fourni.
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtention de l'identifiant de forme unique dans la portée de la diapositive
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **Définir le texte alternatif pour une forme**
Aspose.Slides for .NET permet aux développeurs de définir l’AlternateText d’une forme.  
Les formes d’une présentation peuvent être distinguées par la propriété AlternativeText ou par le nom de la forme.  
La propriété AlternativeText peut être lue ou définie à l’aide d’Aspose.Slides ainsi que de Microsoft PowerPoint.  
En utilisant cette propriété, vous pouvez baliser une forme et effectuer différentes opérations telles que la suppression d’une forme,  
le masquage d’une forme ou la réorganisation des formes sur une diapositive.  
Pour définir l’AlternateText d’une forme, suivez les étapes ci‑dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez n’importe quelle forme à la diapositive.
1. Effectuez des opérations avec la forme nouvellement ajoutée.
1. Parcourez les formes pour trouver une forme.
1. Définissez l’AlternativeText.
1. Enregistrez le fichier sur le disque.
```c#
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();

// Obtenir la première diapositive
ISlide sld = pres.Slides[0];

// Ajouter une forme auto de type rectangle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Enregistrer la présentation sur le disque
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **Accéder aux formats de mise en page d’une forme**
Aspose.Slides for .NET fournit une API simple pour accéder aux formats de mise en page d’une forme. Cet article montre comment accéder aux formats de mise en page.

Le code d’exemple ci‑dessus est fourni.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **Rendre une forme en SVG**
Aspose.Slides for .NET prend maintenant en charge le rendu d’une forme en SVG. La méthode WriteAsSvg (et ses surcharges) a été ajoutée à la classe Shape et à l’interface IShape. Cette méthode permet d’enregistrer le contenu de la forme sous forme de fichier SVG. L’extrait de code ci‑dessus montre comment exporter la forme d’une diapositive vers un fichier SVG.
```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```


## **Aligner une forme**

Grâce à la méthode surchargée [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index), vous pouvez 

* aligner des formes par rapport aux marges d’une diapositive. Voir l’Exemple 1. 
* aligner des formes les unes par rapport aux autres. Voir l’Exemple 2. 

L’énumération [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) définit les options d’alignement disponibles.

**Exemple 1**

Ce code C# montre comment aligner les formes aux indices 1, 2 et 4 le long de la bordure supérieure d’une diapositive :
Le code source ci‑dessous aligne les formes aux indices 1, 2 et 4 le long de la bordure supérieure de la diapositive. 
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**Exemple 2**

Ce code C# montre comment aligner une collection entière de formes par rapport à la forme inférieure de la collection :
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **Propriétés de retournement**

Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) offre le contrôle du retournement horizontal et vertical des formes via ses propriétés `FlipH` et `FlipV`. Les deux propriétés sont de type [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), permettant les valeurs `True` pour un retournement, `False` pour aucun retournement, ou `NotDefined` pour le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) d’une forme. 

Pour modifier les paramètres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) est construite avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `FlipH` et `FlipV`, ainsi que l’angle de rotation. L’attribution de cette instance au [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous ayons un fichier sample.pptx où la première diapositive contient une seule forme avec les paramètres de retournement par défaut, comme illustré ci‑dessus.

![The shape to be flipped](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne horizontalement et verticalement.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Récupérer la propriété de retournement horizontal de la forme.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Récupérer la propriété de retournement vertical de la forme.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Retourner horizontalement.
    NullableBool flipV = NullableBool.True; // Retourner verticalement.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The flipped shape](flipped_shape.png)

## **FAQ**

**Puis‑je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n’existe pas d’API de opérations booléennes intégrée. Vous pouvez vous en approcher en construisant vous‑même le contour souhaité — par exemple, en calculant la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)) et en créant une nouvelle forme avec ce contour, éventuellement en supprimant les originales.

**Comment contrôler l’ordre d’empilement (z‑order) afin qu’une forme reste toujours « au‑dessus » ?**

Modifiez l’ordre d’insertion/déplacement dans la collection [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis‑je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les drapeaux de protection au niveau de la forme [/slides/net/applying-protection-to-presentation/] (par exemple, verrouiller la sélection, le déplacement, le redimensionnement, l’édition du texte). Si nécessaire, appliquez les mêmes restrictions sur le maître ou la mise en page. Notez qu’il s’agit d’une protection au niveau UI, pas d’une fonctionnalité de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier comme les recommandations en lecture seule ou les mots de passe [/slides/net/password-protected-presentation/].