---
title: Gestion des nœuds de forme SmartArt dans les présentations en .NET
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
- supprimer un nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendre le nœud
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gestion des nœuds de forme SmartArt dans PPT et PPTX avec Aspose.Slides pour .NET. Obtenez des exemples de code clairs et des conseils pour optimiser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides for .NET fournit l’API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d’exemple suivant vous aidera à ajouter un nœud et un nœud enfant dans une forme SmartArt.

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez toutes les formes de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArt si c’est le cas.
- Ajoutez un nouveau nœud dans la collection NodeCollection de la forme SmartArt et définissez le texte dans le TextFrame.
- Ensuite, ajoutez un nœud enfant au nœud SmartArt nouvellement ajouté et définissez le texte dans le TextFrame.
- Enregistrez la présentation.
```c#
 // Charger la présentation souhaitée
 Presentation pres = new Presentation("AddNodes.pptx");

 // Parcourir chaque forme de la première diapositive
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
Dans le code d’exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux différents nœuds d’une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList dans la diapositive sélectionnée.
- Accédez au premier nœud de la forme SmartArt ajoutée.
- Ensuite, ajoutez le nœud enfant pour le nœud sélectionné à la position 2 et définissez son texte.
- Enregistrez la présentation.
```c#
 // Créer une instance de présentation
 Presentation pres = new Presentation();

 // Accéder à la diapositive de la présentation
 ISlide slide = pres.Slides[0];

 // Ajouter un IShape Smart Art
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
Le code d’exemple suivant vous aidera à accéder aux nœuds d’une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n’est défini que lors de l’ajout de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.

- Obtenez la référence de la première diapositive en utilisant son index.

- Parcourez toutes les formes de la première diapositive.

- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArt si c’est le cas.

- Parcourez tous les nœuds à l’intérieur de la forme SmartArt.

- Accédez et affichez des informations telles que la position du nœud SmartArt, son niveau et son texte.
```c#
  // Charger la présentation souhaitée
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Parcourir chaque forme de la première diapositive
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Vérifier si la forme est de type SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Effectuer un transtypage de la forme vers SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Parcourir tous les nœuds à l'intérieur du SmartArt
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
Le code d’exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux différents nœuds d’une forme SmartArt.

- Créez une instance de la classe PresentationEx et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez toutes les formes de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArtEx si c’est le cas.
- Parcourez tous les nœuds à l’intérieur de la forme SmartArt.
- Pour chaque nœud de forme SmartArt sélectionné, parcourez tous les nœuds enfants à l’intérieur du nœud particulier.
- Accédez et affichez des informations telles que la position du nœud enfant, son niveau et son texte.
```c#
 // Charger la présentation souhaitée
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Parcourir chaque forme de la première diapositive
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Vérifier si la forme est de type SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forme en SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Parcourir tous les nœuds à l'intérieur du SmartArt
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
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux différents nœuds d’une forme SmartArt.

- Créez une instance de la classe `Presentation`.
- Obtenez la référence de la première diapositive en utilisant son index.
- Ajoutez une forme SmartArt de type StackedList.
- Accédez à la forme SmartArt ajoutée.
- Accédez au nœud d’indice 0 de la forme SmartArt récupérée.
- Ensuite, accédez au nœud enfant à la position 1 du nœud SmartArt récupéré en utilisant la méthode GetNodeByPosition().
- Accédez et affichez des informations telles que la position du nœud enfant, son niveau et son texte.
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
Dans cet exemple, nous apprendrons à supprimer les nœuds d’une forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez toutes les formes de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArt si c’est le cas.
- Vérifiez que le SmartArt possède plus de 0 nœud.
- Sélectionnez le nœud SmartArt à supprimer.
- Ensuite, supprimez le nœud sélectionné à l’aide de la méthode RemoveNode().
- Enregistrez la présentation.
```c#
// Charger la présentation souhaitée
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Parcourir chaque forme de la première diapositive
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
Dans cet exemple, nous apprendrons à supprimer les nœuds d’une forme SmartArt à une position particulière.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez toutes les formes de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArt si c’est le cas.
- Sélectionnez le nœud de forme SmartArt d’indice 0.
- Vérifiez que le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
- Supprimez le nœud à la position 1 à l’aide de la méthode RemoveNodeByPosition().
- Enregistrez la présentation.
```c#
 // Charger la présentation souhaitée             
 Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Parcourir chaque forme de la première diapositive
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




## **Définir une position personnalisée pour le nœud enfant dans SmartArt**
Aspose.Slides for .NET prend désormais en charge la définition des propriétés X et Y de SmartArtShape. Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées d’une SmartArtShape ; notez que l’ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds.
```c#
// Charger la présentation désirée
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Déplacer la forme SmartArt vers une nouvelle position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Modifier la largeur de la forme SmartArt
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




## **Vérifier le nœud Assistant**
Dans le code d’exemple suivant, nous examinerons comment identifier les nœuds Assistant dans la collection de nœuds SmartArt et les modifier.

- Créez une instance de la classe PresentationEx et chargez la présentation contenant une forme SmartArt.
- Obtenez la référence de la deuxième diapositive en utilisant son index.
- Parcourez toutes les formes de la première diapositive.
- Vérifiez si la forme est de type SmartArt et effectuez un transtypage de la forme sélectionnée vers SmartArtEx si c’est le cas.
- Parcourez tous les nœuds de la forme SmartArt et vérifiez s’ils sont des nœuds Assistant.
- Changez le statut du nœud Assistant en nœud normal.
- Enregistrez la présentation.
```c#
// Créer une instance de présentation
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Parcourir chaque forme de la première diapositive
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
                    // Définir le nœud Assistant sur false et le transformer en nœud normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Enregistrer la présentation
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Définir le format de remplissage du nœud**
Aspose.Slides for .NET permet d’ajouter des formes SmartArt personnalisées et de définir leurs formats de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for .NET.

Veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d’une diapositive à l’aide de son indice.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Définissez le FillFormat pour les nœuds de la forme SmartArt.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Accéder à la diapositive
    ISlide slide = presentation.Slides[0];

    // Ajouter la forme SmartArt et les nœuds
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Définir la couleur de remplissage du nœud
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Enregistrer la présentation
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```




## **Générer une miniature du nœud enfant SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d’un SmartArt en suivant les étapes ci‑dessous :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
2. Ajoutez un SmartArt.
3. Obtenez la référence d’un nœud en utilisant son index.
4. Récupérez l’image miniature.
5. Enregistrez l’image miniature dans le format d’image souhaité.

L’exemple ci‑dessous génère une miniature du nœud enfant SmartArt
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

**L’animation SmartArt est‑elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/net/shape-animation/) (entrée, sortie, mise en valeur, trajectoires) et ajuster le minutage. Vous pouvez également animer les formes à l’intérieur des nœuds SmartArt si nécessaire.

**Comment localiser de façon fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [texte de remplacement](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). En définissant un AltText distinctif sur le SmartArt, vous pouvez le trouver programmatiquement sans dépendre des identifiants internes.

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l’[exportation PDF](/slides/fr/net/convert-powerpoint-to-pdf/), préservant la mise en page, les couleurs et les effets.

**Puis‑je extraire une image de l’ensemble du SmartArt (pour des aperçus ou des rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt vers des [formats raster](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou vers [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) pour une sortie vectorielle évolutive, ce qui convient aux miniatures, aux rapports ou à une utilisation web.