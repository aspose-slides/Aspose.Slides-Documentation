---
title: Gérer les nœuds de forme SmartArt dans les présentations en .NET
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/net/manage-smartart-shape-node/
keywords:
- Nœud SmartArt
- nœud enfant
- ajouter un nœud
- position du nœud
- accéder au nœud
- supprimer le nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendu du nœud
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans PPT et PPTX avec Aspose.Slides pour .NET. Obtenez des exemples de code clairs et des astuces pour optimiser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides for .NET a fourni l'API la plus simple pour gérer les formes SmartArt de la façon la plus facile. Le code d'exemple suivant vous aidera à ajouter un nœud et un nœud enfant dans une forme SmartArt.

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et charger la présentation avec une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Ajouter un nouveau nœud dans la collection NodeCollection de la forme SmartArt et définir le texte dans le TextFrame.
- Ensuite, ajouter un nœud enfant au nœud SmartArt nouvellement ajouté et définir le texte dans le TextFrame.
- Enregistrer la présentation.
```c#
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddNodes.pptx");

// Parcourir chaque forme à l'intérieur de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Vérifier si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Ajouter un nouveau nœud SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Ajouter du texte
        TemNode.TextFrame.Text = "Test";

        // Ajouter un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Ajouter du texte
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Enregistrer la présentation
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt à une position particulière.

- Créer une instance de la classe `Presentation`.
- Obtenir la référence de la première diapositive en utilisant son index.
- Ajouter une forme SmartArt de type StackedList dans la diapositive ciblée.
- Accéder au premier nœud de la forme SmartArt ajoutée.
- Ensuite, ajouter le nœud enfant pour le nœud sélectionné à la position 2 et définir son texte.
- Enregistrer la présentation.
```c#
// Création d'une instance de présentation
Presentation pres = new Presentation();

// Accéder à la diapositive de la présentation
ISlide slide = pres.Slides[0];

// Ajouter une IShape SmartArt
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accéder au nœud SmartArt à l'index 0
ISmartArtNode node = smart.AllNodes[0];

// Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Ajouter du texte
chNode.TextFrame.Text = "Sample Text Added";

// Enregistrer la présentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **Accéder à un nœud SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds à l'intérieur d'une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne peut être défini que lors de l'ajout de la forme SmartArt.

- Créer une instance de la classe `Presentation` et charger la présentation avec une forme SmartArt.

- Obtenir la référence de la première diapositive en utilisant son index.

- Parcourir chaque forme à l'intérieur de la première diapositive.

- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.

- Parcourir tous les nœuds à l'intérieur de la forme SmartArt.

- Accéder et afficher des informations telles que la position du nœud SmartArt, son niveau et le texte.
  ```c#
  // Charger la présentation souhaitée
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Parcourir chaque forme dans la première diapositive
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Vérifier si la forme est de type SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Convertir la forme en SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Parcourir tous les nœuds du SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accéder au nœud SmartArt à l'index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Afficher les paramètres du nœud SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


  


## **Accéder à un nœud enfant SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt.

- Créer une instance de la classe PresentationEx et charger la présentation avec une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArtEx si c'est le cas.
- Parcourir tous les nœuds à l'intérieur de la forme SmartArt.
- Pour chaque nœud de forme SmartArt sélectionné, parcourir tous les nœuds enfants à l'intérieur du nœud particulier.
- Accéder et afficher des informations telles que la position du nœud enfant, son niveau et le texte.
```c#
// Charger la présentation désirée
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Parcourir chaque forme dans la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Vérifier si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Parcourir tous les nœuds du SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accéder au nœud SmartArt à l'index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Parcourir les nœuds enfants du nœud SmartArt à l'index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accéder au nœud enfant du nœud SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Afficher les paramètres du nœud enfant SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```




## **Accéder à un nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d'une forme SmartArt.

- Créer une instance de la classe `Presentation`.
- Obtenir la référence de la première diapositive en utilisant son index.
- Ajouter une forme SmartArt de type StackedList.
- Accéder à la forme SmartArt ajoutée.
- Accéder au nœud à l'index 0 de la forme SmartArt accédée.
- Ensuite, accéder au nœud enfant à la position 1 du nœud SmartArt accédé en utilisant la méthode GetNodeByPosition().
- Accéder et afficher des informations telles que la position du nœud enfant, son niveau et le texte.
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

// Afficher les paramètres du nœud enfant SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```




## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt.

- Créer une instance de la classe `Presentation` et charger la présentation avec une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Vérifier si le SmartArt possède plus de 0 nœud.
- Sélectionner le nœud SmartArt à supprimer.
- Ensuite, supprimer le nœud sélectionné à l'aide de la méthode RemoveNode() et enregistrer la présentation.
```c#
 // Charger la présentation souhaitée
 using (Presentation pres = new Presentation("RemoveNode.pptx"))
 {
 
     // Parcourir chaque forme à l'intérieur de la première diapositive
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
 
         // Vérifier si la forme est de type SmartArt
         if (shape is ISmartArt)
         {
             // Convertir la forme en SmartArtEx
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
 
     // Enregistrer la présentation
     pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```




## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds d'une forme SmartArt à une position particulière.

- Créer une instance de la classe `Presentation` et charger la présentation avec une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Sélectionner le nœud de forme SmartArt à l'index 0.
- Ensuite, vérifier si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
- Ensuite, supprimer le nœud à la position 1 à l'aide de la méthode RemoveNodeByPosition().
- Enregistrer la présentation.
```c#
// Charger la présentation souhaitée             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Parcourir chaque forme à l'intérieur de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Vérifier si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Convertir la forme en SmartArt
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

// Enregistrer la présentation
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Définir une position personnalisée pour un nœud enfant dans un objet SmartArt**
Aspose.Slides for .NET prend désormais en charge la définition des propriétés X et Y de SmartArtShape. Le fragment de code ci-dessous montre comment définir une position, une taille et une rotation personnalisées pour SmartArtShape ; veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.
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

	// Modifier les largeurs de la forme SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Modifier la hauteur de la forme SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Modifier la rotation de la forme SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```




## **Vérifier un nœud Assistant**
Dans le code d'exemple suivant, nous examinerons comment identifier les nœuds Assistant dans la collection de nœuds SmartArt et les modifier.

- Créer une instance de la classe PresentationEx et charger la présentation avec une forme SmartArt.
- Obtenir la référence de la deuxième diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArtEx si c'est le cas.
- Parcourir tous les nœuds à l'intérieur de la forme SmartArt et vérifier s'ils sont des nœuds Assistant.
- Modifier le statut du nœud Assistant en nœud normal.
- Enregistrer la présentation.
```c#
// Créer une instance de présentation
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Parcourir chaque forme dans la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Parcourir tous les nœuds de la forme SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Vérifier si le nœud est un nœud Assistant
                if (node.IsAssistant)
                {
                    // Définir le nœud Assistant à false et le convertir en nœud normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Enregistrer la présentation
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Définir le format de remplissage d'un nœud**
Aspose.Slides for .NET permet d'ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l'aide d'Aspose.Slides for .NET.

Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe `Presentation`.
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une forme SmartArt en définissant son LayoutType.
- Définir le FillFormat pour les nœuds de la forme SmartArt.
- Enregistrer la présentation modifiée au format PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Accès à la diapositive
    ISlide slide = presentation.Slides[0];

    // Ajout de la forme SmartArt et des nœuds
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Définir la couleur de remplissage du nœud
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Enregistrement de la présentation
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```




## **Générer une miniature d'un nœud enfant SmartArt**
Les développeurs peuvent générer une miniature d'un nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Instancier la classe `Presentation` qui représente le fichier PPTX.
2. Ajouter SmartArt.
3. Obtenir la référence d'un nœud en utilisant son index
4. Obtenir l'image miniature.
5. Enregistrer l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature d'un nœud enfant SmartArt
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


## **FAQ**

**L'animation SmartArt est-elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/net/shape-animation/) (entrée, sortie, mise en valeur, chemins de mouvement) et ajuster le timing. Vous pouvez également animer les formes à l'intérieur des nœuds SmartArt si nécessaire.

**Comment puis‑je localiser de manière fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Définir un AltText distinctif sur le SmartArt vous permet de le trouver programmatique sans dépendre des identifiants internes.

**L'apparence du SmartArt sera‑t‑elle préservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une grande fidélité visuelle lors de l'[export PDF](/slides/fr/net/convert-powerpoint-to-pdf/), en préservant la mise en page, les couleurs et les effets.

**Puis‑je extraire une image de l'ensemble du SmartArt (pour les aperçus ou les rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt aux [formats raster](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou au [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) pour une sortie vectorielle évolutive, ce qui la rend adaptée aux miniatures, aux rapports ou à l'utilisation web.