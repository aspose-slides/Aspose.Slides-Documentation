---
title: Gérer le nœud de forme SmartArt
type: docs
weight: 30
url: /fr/net/manage-smartart-shape-node/
keywords:
- SmartArt
- nœud SmartArt
- nœud enfant SmartArt
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Gérer les nœuds SmartArt et les nœuds enfants dans les présentations PowerPoint en C# ou .NET"
---


## **Ajouter un nœud SmartArt**
Aspose.Slides pour .NET a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Ajoutez un nouveau nœud dans la collection de nœuds de la forme SmartArt et définissez le texte dans TextFrame.
- Maintenant, ajoutez un nœud enfant dans le nouveau nœud SmartArt ajouté et définissez le texte dans TextFrame.
- Enregistrez la présentation.

```c#
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddNodes.pptx");

// Parcourez chaque forme à l'intérieur de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Vérifiez si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Conversion de la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Ajout d'un nouveau nœud SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Ajout de texte
        TemNode.TextFrame.Text = "Test";

        // Ajout d'un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Ajout de texte
        newNode.TextFrame.Text = "Nouveau nœud ajouté";

    }
}

// Sauvegarder la présentation
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous avons expliqué comment ajouter des nœuds enfants appartenant à des nœuds respectifs de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList dans la diapositive accédée.
- Accédez au premier nœud dans la forme SmartArt ajoutée.
- Maintenant, ajoutez le nœud enfant pour le nœud sélectionné à la position 2 et définissez son texte.
- Sauvegardez la présentation.

```c#
// Création d'une instance de présentation
Presentation pres = new Presentation();

// Accéder à la diapositive de la présentation
ISlide slide = pres.Slides[0];

// Ajouter un IShape Smart Art
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accéder au nœud SmartArt à l'index 0
ISmartArtNode node = smart.AllNodes[0];

// Ajout d'un nouveau nœud enfant à la position 2 dans le nœud parent
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Ajouter du texte
chNode.TextFrame.Text = "Texte d'exemple ajouté";

// Sauvegarder la présentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Accéder à un nœud SmartArt**
Le code d'exemple suivant aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.

- Obtenez la référence de la première diapositive en utilisant son index.

- Parcourez chaque forme à l'intérieur de la première diapositive.

- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.

- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.

- Accédez et affichez des informations telles que la position du nœud SmartArt, le niveau et le texte.

  ```c#
  // Charger la présentation souhaitée
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Parcourez chaque forme à l'intérieur de la première diapositive
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Vérifiez si la forme est de type SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Conversion de la forme en SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Parcourez tous les nœuds à l'intérieur de SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accéder au nœud SmartArt à l'index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Impression des paramètres du nœud SmartArt
              string outString = string.Format("i = {0}, Texte = {1},  Niveau = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

  


## **Accéder au nœud enfant SmartArt**
Le code d'exemple suivant aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArtEx si c'est un SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt.
- Pour chaque nœud SmartArt sélectionné, parcourez tous les nœuds enfants à l'intérieur du nœud particulier.
- Accédez et affichez des informations telles que la position du nœud enfant, le niveau et le texte.

```c#
// Charger la présentation souhaitée
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Parcourez chaque forme à l'intérieur de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Vérifiez si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Conversion de la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Parcourez tous les nœuds à l'intérieur de SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accéder au nœud SmartArt à l'index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Parcourir les nœuds enfants dans le nœud SmartArt à l'index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accéder au nœud enfant dans le nœud SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Impression des paramètres du nœud enfant SmartArt
                string outString = string.Format("j = {0}, Texte = {1},  Niveau = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Accéder au nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs de la forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud à l'index 0 pour la forme SmartArt accédée.
- Maintenant, accédez au nœud enfant à la position 1 pour le nœud SmartArt accédé à l'aide de la méthode GetNodeByPosition().
- Accédez et affichez des informations telles que la position du nœud enfant, le niveau et le texte.

```c#
// Instancier la présentation
Presentation pres = new Presentation();

// Accéder à la première diapositive
ISlide slide = pres.Slides[0];

// Ajouter la forme SmartArt dans la première diapositive
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accéder au nœud SmartArt à l'index 0
ISmartArtNode node = smart.AllNodes[0];

// Accéder au nœud enfant à la position 1 dans le nœud parent
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Impression des paramètres du nœud enfant SmartArt
string outString = string.Format("j = {0}, Texte = {1},  Niveau = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Supprimer un nœud SmartArt**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Vérifiez si le SmartArt a plus de 0 nœuds.
- Sélectionnez le nœud SmartArt à supprimer.
- Maintenant, supprimez le nœud sélectionné à l'aide de la méthode RemoveNode(). Enregistrez la présentation.

```c#
// Charger la présentation souhaitée
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Parcourez chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Vérifiez si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Conversion de la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Accéder au nœud SmartArt à l'index 0
                ISmartArtNode node = smart.AllNodes[0];

                // Supprimer le nœud sélectionné
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Sauvegarder la présentation
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c'est un SmartArt.
- Sélectionnez le nœud de forme SmartArt à l'index 0.
- Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
- Maintenant, supprimez le nœud à la position 1 à l'aide de la méthode RemoveNodeByPosition().
- Sauvegardez la présentation.

```c#
// Charger la présentation souhaitée             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Parcourez chaque forme à l'intérieur de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Vérifiez si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Conversion de la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Accéder au nœud SmartArt à l'index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Supprimer le nœud enfant à la position 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Sauvegarder la présentation
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Définir une position personnalisée pour un nœud enfant dans SmartArt**
Maintenant, Aspose.Slides pour .NET prend en charge la définition des propriétés X et Y de SmartArtShape. Le code ci-dessous montre comment définir la position, la taille et la rotation de SmartArtShape. Veuillez noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et tailles de tous les nœuds.

```c#
// Charger la présentation souhaitée
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Déplacer la forme SmartArt à une nouvelle position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Changer les largeurs des formes SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Changer la hauteur de la forme SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Changer la rotation de la forme SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Vérifier le nœud assistant**
Dans le code d'exemple suivant, nous allons explorer comment identifier les nœuds assistants dans la collection de nœuds SmartArt et les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la deuxième diapositive en utilisant son index.
- Parcourez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArtEx si c'est un SmartArt.
- Parcourez tous les nœuds à l'intérieur de la forme SmartArt et vérifiez s'ils sont des nœuds assistants.
- Changez le statut du nœud assistant en nœud normal.
- Sauvegardez la présentation.

```c#
// Création d'une instance de présentation
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Parcourez chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Conversion de la forme en SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Parcourir tous les nœuds de la forme SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Vérifiez si le nœud est un nœud assistant
                if (node.IsAssistant)
                {
                    // Définir le nœud assistant à faux et en faire un nœud normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Sauvegarder la présentation
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Définir le format de remplissage du nœud**
Aspose.Slides pour .NET permet d'ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l'aide d'Aspose.Slides pour .NET.

Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le format de remplissage pour les nœuds de la forme SmartArt.
- Écrivez la présentation modifiée en tant que fichier PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Accéder à la diapositive
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme SmartArt et des nœuds
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Du texte ici";

    // Définir la couleur de remplissage du nœud
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Sauvegarder la présentation
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Générer un vignettes du nœud enfant SmartArt**
Les développeurs peuvent générer une vignette du nœud enfant d'un SmartArt en suivant les étapes suivantes :

1. Instancier la classe `Presentation` qui représente le fichier PPTX.
2. Ajouter SmartArt.
3. Obtenir la référence d'un nœud en utilisant son index.
4. Obtenez l'image miniature.
5. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous génère une vignette du nœud enfant SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```