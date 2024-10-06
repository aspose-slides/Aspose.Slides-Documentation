---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /net/manage-smartart-shape/
keywords: "forme SmartArt, style de forme SmartArt, style de couleur de forme SmartArt, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Gérer les SmartArt dans les présentations PowerPoint en C# ou .NET"
---

## **Créer une forme SmartArt**
Aspose.Slides pour .NET facilite désormais l'ajout de formes SmartArt personnalisées dans leurs diapositives depuis le début. Aspose.Slides pour .NET a fourni l'API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Enregistrez la présentation modifiée au format PPTX.

```c#
// Instancier la présentation
using (Presentation pres = new Presentation())
{

    // Accéder à la diapositive de la présentation
    ISlide slide = pres.Slides[0];

    // Ajouter la forme Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Enregistrer la présentation
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de présentation. Dans le code exemple, nous allons parcourir chaque forme à l'intérieur de la diapositive et vérifier si c'est une forme SmartArt. Si la forme est de type SmartArt, nous la convertissons en instance SmartArt.

```c#
// Charger la présentation souhaitée
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Nom de la forme :" + smart.Name);

        }
    }
}
```



## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d'exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Vérifiez la forme SmartArt avec un LayoutType particulier et effectuez ce qui est requis par la suite.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérification de la mise en page SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Faites quelque chose ici....");
            }
        }
    }
}
```



## **Changer le style de forme SmartArt**
Le code d'exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Trouvez la forme SmartArt avec un style particulier.
- Définissez le nouveau style pour la forme SmartArt.
- Enregistrez la présentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérification du style SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Changer le style SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Enregistrer la présentation
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Changer le style de couleur de la forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style de couleur pour toute forme SmartArt. Dans le code d'exemple suivant, nous accéderons à la forme SmartArt avec un style de couleur particulier et changerons son style.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Trouvez la forme SmartArt avec un style de couleur particulier.
- Définissez le nouveau style de couleur pour la forme SmartArt.
- Enregistrez la présentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérification du type de couleur SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Changer le type de couleur SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Enregistrer la présentation
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```