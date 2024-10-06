---
title: Solution Fonctionnelle pour le Redimensionnement de Graphiques dans PPTX
type: docs
weight: 60
url: /net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Il a été observé que les graphiques Excel intégrés en tant qu'OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non identifiée après leur première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose, avec l'aide de l'équipe Microsoft, a étudié ce problème en détail et a trouvé la solution à ce problème. Cet article couvre les raisons et la solution à ce problème.

{{% /alert %}} 
## **Contexte**
Dans [l'article précédent](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , nous avons expliqué comment créer un graphique Excel en utilisant Aspose.Cells pour .NET et ensuite intégrer ce graphique dans une présentation PowerPoint en utilisant Aspose.Slides pour .NET. Afin de prendre en compte le [problème d'objet changé](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) , nous avons assigné l'image du graphique au cadre d'objet OLE du graphique. Dans la présentation résultante, lorsque nous double-cliquons sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel réel puis retourner à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent pour différentes tailles de cadre d'objet OLE et de classeur Excel intégré.
## **Cause du Redimensionnement**
Puisque le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille d'origine lors de la première activation. D'autre part, le cadre d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences dans la taille de la fenêtre Excel et la taille / position du cadre d'objet OLE, le redimensionnement a lieu.
## **Solution Fonctionnelle**
Il existe deux scénarios possibles pour la création des présentations PowerPoint utilisant Aspose.Slides pour .NET.

**Scénario 1 :** Créer la présentation à partir d'un modèle existant

**Scénario 2 :** Créer la présentation à partir de zéro.

La solution que nous fournirons ici sera valide pour les deux scénarios. La base de toutes les approches de solution sera la même. C'est-à-dire : **La taille de la fenêtre de l'objet OLE intégré doit être la même que celle du cadre d'objet OLE** **dans la diapositive PowerPoint**. Maintenant, nous allons discuter des deux approches de la solution.
## **Première Approche**
Dans cette approche, nous allons apprendre à définir la taille de la fenêtre du classeur Excel intégré équivalente à la taille du cadre d'objet OLE dans la diapositive PowerPoint.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous souhaitions créer les présentations en fonction de ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLE sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille de la fenêtre du classeur égale à la taille de la forme. Le code suivant servira cet objectif :

```c#
//définir la taille du graphique avec la fenêtre
chart.SizeWithWindow = true;

//définir la largeur de la fenêtre du classeur en pouces (divisée par 72 car PowerPoint utilise 
//72 pixels / pouce)
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//définir la hauteur de la fenêtre du classeur en pouces
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//Instancier MemoryStream
MemoryStream ms = wb.SaveToStream();

//Créer un cadre d'objet OLE avec Excel intégré
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**Scénario 2**

Disons que nous voulons créer une présentation à partir de zéro et désirer un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x-axis=0,5 pouce et y-axis=1 pouce. De plus, nous avons défini la taille de fenêtre équivalente du classeur Excel, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces.

```c#
//Notre hauteur souhaitée
int desiredHeight = 288;//4 pouces (4 * 72)

//Notre largeur souhaitée
int desiredWidth = 684;//9,5 pouces (9,5 * 72)

//définir la taille du graphique avec la fenêtre
chart.SizeWithWindow = true;

//définir la largeur de la fenêtre du classeur en pouces
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//définir la hauteur de la fenêtre du classeur en pouces
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//Instancier MemoryStream
MemoryStream ms = wb.SaveToStream();

//Créer un cadre d'objet OLE avec Excel intégré
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```

## **Deuxième Approche**
Dans cette approche, nous allons apprendre à définir la taille du graphique présente dans le classeur Excel intégré équivalente à la taille du cadre d'objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l'avance et ne changera jamais.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous souhaitions créer les présentations en fonction de ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille du graphique dans le classeur égale à la taille de la forme. Le code suivant servira cet objectif :

```c#
//définir la taille du graphique sans fenêtre
chart.SizeWithWindow = false;

//définir la largeur du graphique en pixels (Multiplier par 96 car Excel utilise 96 pixels par pouce)    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//définir la hauteur du graphique en pixels
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//Définir la taille d'impression du graphique
chart.PrintSize = PrintSizeType.Custom;

//Instancier MemoryStream
MemoryStream ms = wb.SaveToStream();

//Créer un cadre d'objet OLE avec Excel intégré
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**Scénario 2**

Disons que nous voulons créer une présentation à partir de zéro et désirer un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x-axis=0,5 pouce et y-axis=1 pouce. De plus, nous avons défini la taille équivalente du graphique, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces.

```c#
//Notre hauteur souhaitée
int desiredHeight = 288;//4 pouces (4 * 576)

//Notre largeur souhaitée
int desiredWidth = 684;//9,5 pouces (9,5 * 576)

//définir la taille du graphique sans fenêtre 
chart.SizeWithWindow = false;

//définir la largeur du graphique en pixels    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//définir la hauteur du graphique en pixels    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//Instancier MemoryStream
MemoryStream ms = wb.SaveToStream();

//Créer un cadre d'objet OLE avec Excel intégré
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```

## **Conclusion**
{{% alert color="primary" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement des graphiques. Le choix de l'approche appropriée dépend des exigences et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou créées de zéro. De plus, il n'y a aucune limite à la taille du cadre d'objet OLE dans la solution.

{{% /alert %}} 
## **Sections Connexes**
[Créer et Intégrer un Graphique Excel en tant qu'Objet OLE dans la Présentation](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour les objets OLE automatiquement](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)