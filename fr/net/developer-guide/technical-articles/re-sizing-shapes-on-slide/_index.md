---
title: Redimensionnement des formes sur la diapositive
type: docs
weight: 130
url: /fr/net/redimensionnement-des-formes-sur-la-diapositive/
---

## **Redimensionnement des Formes sur la Diapositive**
L'une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour .NET est comment redimensionner les formes de sorte que lorsque la taille de la diapositive est modifiée, les données ne soient pas coupées. Ce conseil technique bref montre comment y parvenir.

Pour éviter la désorientation des formes, chaque forme sur la diapositive doit être mise à jour en fonction de la nouvelle taille de la diapositive.

```c#
 //Charger une présentation
Presentation presentation = new Presentation(@"D:\TestResize.ppt");

//Ancienne taille de la diapositive
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Changer la taille de la diapositive
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

//Nouvelle taille de la diapositive
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (ISlide slide in presentation.Slides)
{
	foreach (IShape shape in slide.Shapes)
	{
		//Redimensionner la position
		shape.Height = shape.Height * ratioHeight;
		shape.Width = shape.Width * ratioWidth;

		//Redimensionner la taille de la forme si nécessaire 
		shape.Y = shape.Y * ratioHeight;
		shape.X = shape.X * ratioWidth;

	}
}

presentation.Save("Resize.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

S'il y a un tableau dans la diapositive, alors le code ci-dessus ne fonctionnera pas parfaitement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.

{{% /alert %}} 

Vous devez utiliser le code suivant de votre côté si vous devez redimensionner les diapositives avec des tableaux. La définition de la largeur ou de la hauteur d'un tableau est un cas particulier dans les formes où vous devez modifier la hauteur individuelle des lignes et la largeur des colonnes pour modifier la hauteur et la largeur du tableau.

```c#
Presentation presentation = new Presentation("D:\\Test.pptx");

//Ancienne taille de la diapositive
float currentHeight = presentation.SlideSize.Size.Height;
float currentWidth = presentation.SlideSize.Size.Width;

//Changer la taille de la diapositive
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

//Nouvelle taille de la diapositive
float newHeight = presentation.SlideSize.Size.Height;
float newWidth = presentation.SlideSize.Size.Width;

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

foreach (IMasterSlide master in presentation.Masters)
{
    foreach (IShape shape in master.Shapes)
    {
        //Redimensionner la position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Redimensionner la taille de la forme si nécessaire 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;

    }

    foreach (ILayoutSlide layoutslide in master.LayoutSlides)
    {
        foreach (IShape shape in layoutslide.Shapes)
        {
            //Redimensionner la position
            shape.Height = shape.Height * ratioHeight;
            shape.Width = shape.Width * ratioWidth;

            //Redimensionner la taille de la forme si nécessaire 
            shape.Y = shape.Y * ratioHeight;
            shape.X = shape.X * ratioWidth;

        }

    }
}

foreach (ISlide slide in presentation.Slides)
{
    foreach (IShape shape in slide.Shapes)
    {
        //Redimensionner la position
        shape.Height = shape.Height * ratioHeight;
        shape.Width = shape.Width * ratioWidth;

        //Redimensionner la taille de la forme si nécessaire 
        shape.Y = shape.Y * ratioHeight;
        shape.X = shape.X * ratioWidth;
        if (shape is ITable)
        {
            ITable table = (ITable)shape;
            foreach (IRow row in table.Rows)
            {
                row.MinimalHeight = row.MinimalHeight * ratioHeight;
                //   row.Height = row.Height * ratioHeight;
            }
            foreach (IColumn col in table.Columns)
            {
                col.Width = col.Width * ratioWidth;

            }
        }

    }
}

presentation.Save("D:\\Resize.pptx", SaveFormat.Pptx);
```