---
title: Manipulations de Formes
type: docs
weight: 40
url: /fr/net/manipulations-de-formes/
keywords: "forme PowerPoint, forme sur une diapositive, trouver forme, cloner forme, supprimer forme, cacher forme, changer ordre de forme, obtenir ID forme interop, texte alternatif de forme, formats de mise en page de forme, forme en tant que SVG, aligner forme, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Manipuler les formes PowerPoint en C# ou .NET"
---

## **Trouver une Forme dans la Diapositive**
Ce sujet décrira une technique simple pour faciliter la tâche des développeurs qui souhaitent trouver une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint n'ont aucun moyen d'identifier des formes sur une diapositive, sauf par un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d'utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier à l'avenir.

Après avoir défini le texte alternatif de toute forme désirée, vous pouvez ensuite ouvrir cette présentation en utilisant Aspose.Slides pour .NET et itérer à travers toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme avec le texte alternatif correspondant serait celle requise par vous. Pour démontrer cette technique de manière plus efficace, nous avons créé une méthode, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) qui effectue le tour nécessaire pour trouver une forme spécifique dans une diapositive et retourne simplement cette forme.

```c#
public static void Run()
{
    // Instancier une classe Presentation représentant le fichier de présentation
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Texte alternatif de la forme à trouver
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Nom de la forme: " + shape.Name);
        }
    }
}
        
// Implémentation de la méthode pour trouver une forme dans une diapositive en utilisant son texte alternatif
public static IShape FindShape(ISlide slide, string alttext)
{
    // Itération à travers toutes les formes de la diapositive
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Si le texte alternatif de la diapositive correspond à celui requis alors
        // Retourner la forme
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Cloner une Forme**
Pour cloner une forme dans une diapositive en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive.

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

	// Écrire le fichier PPTX sur le disque
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Supprimer une Forme**
Aspose.Slides pour .NET permet aux développeurs de supprimer toute forme. Pour supprimer la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un texte alternatif spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.

```c#
// Créer un objet Presentation
Presentation pres = new Presentation();

// Obtenez la première diapositive
ISlide sld = pres.Slides[0];

// Ajoutez une forme automatique de type rectangle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Défini par l'utilisateur";
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



## **Cacher une Forme**
Aspose.Slides pour .NET permet aux développeurs de cacher toute forme. Pour cacher la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un texte alternatif spécifique.
1. Cachez la forme.
1. Enregistrez le fichier sur le disque.

```c#
// Instancier la classe Presentation représentant le PPTX
Presentation pres = new Presentation();

// Obtenez la première diapositive
ISlide sld = pres.Slides[0];

// Ajoutez une forme automatique de type rectangle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "Défini par l'utilisateur";
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



## **Changer l'Ordre des Formes**
Aspose.Slides pour .NET permet aux développeurs de réorganiser les formes. La réorganisation de la forme spécifie quelle forme est devant ou quelle forme est derrière. Pour réorganiser la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre de texte de la forme.
1. Ajoutez une autre forme avec les mêmes coordonnées.
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
portion.Text="Texte de Filigrane Texte de Filigrane Texte de Filigrane";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save("Reshape_out.pptx", SaveFormat.Pptx);
```


## **Obtenir l'ID de Forme Interop**
Aspose.Slides pour .NET permet aux développeurs d'obtenir un identifiant unique de forme dans le contexte d'une diapositive, contrairement à la propriété UniqueId, qui permet d'obtenir un identifiant unique dans le scope de la présentation. La propriété OfficeInteropShapeId a été ajoutée aux interfaces IShape et à la classe Shape respectivement. La valeur retournée par la propriété OfficeInteropShapeId correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Un exemple de code est donné ci-dessous.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Obtention de l'identifiant unique de la forme dans le cadre de la diapositive
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Définir le Texte Alternatif pour la Forme**
Aspose.Slides pour .NET permet aux développeurs de définir le TexteAlternatif de toute forme. Les formes dans une présentation peuvent être distinguées par la propriété TexteAlternatif ou Nom de la Forme. La propriété TexteAlternatif peut être lue ou définie en utilisant Aspose.Slides ainsi que Microsoft PowerPoint. En utilisant cette propriété, vous pouvez taguer une forme et effectuer différentes opérations telles que Supprimer une forme, Cacher une forme ou Réorganiser des formes sur une diapositive. Pour définir le TexteAlternatif d'une forme, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Faites quelques travaux avec la forme nouvellement ajoutée.
1. Parcourez les formes pour en trouver une.
1. Définissez le TexteAlternatif.
1. Enregistrez le fichier sur le disque.

```c#
// Instancier la classe Presentation représentant le PPTX
Presentation pres = new Presentation();

// Obtenez la première diapositive
ISlide sld = pres.Slides[0];

// Ajoutez une forme automatique de type rectangle
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
        ashp.AlternativeText = "Défini par l'utilisateur";
    }
}

// Enregistrer la présentation sur le disque
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Accéder aux Formats de Mise en Page pour la Forme**
Aspose.Slides pour .NET fournit une API simple pour accéder aux formats de mise en page pour une forme. Cet article démontre comment vous pouvez accéder aux formats de mise en page.

Le code d'exemple ci-dessous est donné.

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

## **Rendre une Forme en tant que SVG**
Maintenant, Aspose.Slides pour .NET prend en charge le rendu d'une forme en tant que SVG. La méthode WriteAsSvg (et ses surcharges) a été ajoutée à la classe Shape et à l'interface IShape. Cette méthode permet d'enregistrer le contenu de la forme en tant que fichier SVG. L'extrait de code ci-dessous montre comment exporter la forme d'une diapositive vers un fichier SVG.

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

## Aligner la Forme

Grâce à la méthode surchargée [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index), vous pouvez 

* aligner les formes par rapport aux marges d'une diapositive. Voir Exemple 1. 
* aligner les formes les unes par rapport aux autres. Voir Exemple 2. 

L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) définit les options d'alignement disponibles.

### Exemple 1

Ce code C# vous montre comment aligner les formes avec les indices 1, 2 et 4 le long de la bordure supérieure d'une diapositive :
Le code source ci-dessous aligne les formes avec les indices 1, 2 et 4 le long de la bordure supérieure de la diapositive. 

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

### Exemple 2

Ce code C# vous montre comment aligner un ensemble entier de formes par rapport à la forme la plus basse de la collection :

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```