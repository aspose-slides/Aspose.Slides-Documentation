---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 60
url: /fr/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- incorporer graphique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Corriger le redimensionnement inattendu des graphiques dans PPTX lors de l'utilisation d'objets OLE Excel incorporés avec Aspose.Slides pour .NET. Découvrez deux méthodes avec du code pour maintenir les tailles cohérentes."
---

## **Contexte**

Il a été observé que les graphiques Excel intégrés en tant qu'objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non spécifiée après leur première activation. Ce comportement entraîne une différence visuelle perceptible dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose a étudié le problème en détail et a trouvé une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans l'[article précédent](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells pour .NET et l'intégrer dans une présentation PowerPoint en utilisant Aspose.Slides pour .NET. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l'image du graphique au cadre d'objet OLE du graphique. Dans la présentation générée, lorsqu’on double-clique sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel sous-jacent, puis revenir à la diapositive correspondante en cliquant en dehors du classeur activé. La taille du cadre d'objet OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d'origine du cadre d'objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de sa première activation. Le cadre d'objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsqu'un classeur Excel est activé, Excel et PowerPoint négocient la taille et maintiennent les proportions correctes dans le cadre du processus d'intégration. En fonction des différences entre la taille de la fenêtre Excel et la taille ou la position du cadre d'objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scénarios possibles pour créer des présentations PowerPoint avec Aspose.Slides pour .NET.

**Scenario 1 :** Créer une présentation à partir d'un modèle existant.

**Scenario 2 :** Créer une présentation à partir de zéro.

La solution que nous présentons ici s'applique aux deux scénarios. Le principe de toutes les approches de solution est le même : **la taille de la fenêtre de l'objet OLE intégré doit correspondre au cadre d'objet OLE dans la diapositive PowerPoint**. Nous allons maintenant examiner les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint.

**Scenario 1** 

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLE est prédéfinie — elle correspond à la taille de la forme à l'index 2 du modèle. Tout ce que nous devons faire est de régler la taille de la fenêtre du classeur à la taille de cette forme. Le fragment de code suivant réalise cela :
```cs
// Définir la taille du graphique avec une fenêtre. 
chart.SizeWithWindow = true;

// Définir la largeur de la fenêtre du classeur en pouces (divisée par 72 car PowerPoint utilise 72 pixels par pouce).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Enregistrer le classeur dans un flux mémoire.
MemoryStream workbookStream = workbook.SaveToStream();

// Créer un cadre d'objet OLE avec les données Excel intégrées.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Scenario 2** 

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d'objet OLE de toute taille avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE de 4 pouces de hauteur et 9,5 pouces de largeur à x = 0,5 pouce et y = 1 pouce sur la diapositive. Nous réglons ensuite la fenêtre du classeur Excel à la même taille — 4 pouces de hauteur et 9,5 pouces de largeur.
```cs
// Hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 72)

// Largeur souhaitée.
int desiredWidth = 684;//9,5 pouces (9,5 * 72)

// Définir la taille du graphique avec une fenêtre.
chart.SizeWithWindow = true;

// Définir la largeur de la fenêtre du classeur en pouces.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Enregistrer le classeur dans un flux mémoire.
MemoryStream workbookStream = workbook.SaveToStream();

// Créer un cadre d'objet OLE avec les données Excel intégrées.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Deuxième approche**

Dans cette approche, nous apprendrons comment définir la taille du graphique dans le classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint. Cette méthode est utile lorsque la taille du graphique est connue à l'avance et ne changera jamais.

**Scenario 1** 

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'index 2 dans le modèle où nous avons l'intention de placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE est prédéfinie — elle correspond à la taille de la forme à l'index 2 du modèle. Tout ce que nous devons faire est de régler la taille du graphique dans le classeur à la taille de cette forme. Le fragment de code suivant réalise cela :
```cs
// Définir la taille du graphique sans fenêtre. 
chart.SizeWithWindow = false;

// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Définir la hauteur du graphique en pixels.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Définir la taille d'impression du graphique.
chart.PrintSize = PrintSizeType.Custom;

// Enregistrer le classeur dans un flux mémoire.
MemoryStream workbookStream = workbook.SaveToStream();

// Créer un cadre d'objet OLE avec les données Excel intégrées.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Scenario 2** 

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d'objet OLE de toute taille avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE d'une hauteur de 4 pouces et d'une largeur de 9,5 pouces sur la diapositive à x = 0,5 pouce et y = 1 pouce. Nous réglons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 pouces et une largeur de 9,5 pouces.
```cs
 // Hauteur souhaitée.
int desiredHeight = 288; // 4 pouce (4 * 576)

// Largeur souhaitée.
int desiredWidth = 684; // 9,5 pouce (9,5 * 576)

// Définir la taille du graphique sans fenêtre. 
chart.SizeWithWindow = false;

// Définir la largeur du graphique en pixels.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Définir la hauteur du graphique en pixels.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Enregistrer le classeur dans un flux mémoire.
MemoryStream workbookStream = workbook.SaveToStream();

// Créer un cadre d'objet OLE avec les données Excel intégrées.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **Conclusion**

Il existe deux approches pour résoudre le problème de redimensionnement du graphique. Le choix de l'approche dépend des exigences et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'y a aucune limite à la taille du cadre d'objet OLE dans cette solution.

## FAQ

**Q : Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce qu'Excel essaie de restaurer la taille originale de la fenêtre lors de sa première activation, alors que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le ratio d'aspect, ce qui peut entraîner le redimensionnement.

**Q : Est-il possible d'éviter complètement ce problème de redimensionnement ?**  
Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à la taille du cadre d'objet OLE avant l'intégration, vous pouvez conserver des tailles de graphique cohérentes.

**Q : Quelle approche devrais‑je adopter, régler la taille de la fenêtre du classeur ou régler la taille du graphique ?**  
Utilisez **Approach 1 (window size)** si vous souhaitez préserver le ratio d'aspect du classeur et éventuellement permettre un redimensionnement ultérieur.  
Utilisez **Approach 2 (chart size)** si les dimensions du graphique sont fixes et ne changeront pas après l'intégration.

**Q : Ces méthodes fonctionneront‑elles à la fois avec les présentations basées sur un modèle et les nouvelles présentations ?**  
Oui. Les deux approches fonctionnent de la même manière pour les présentations créées à partir de modèles et à partir de zéro.

**Q : Existe‑t‑il une limite à la taille du cadre d'objet OLE ?**  
Non. Vous pouvez définir le cadre OLE à n'importe quelle taille tant qu'il s'adapte correctement à la taille du classeur ou du graphique.

**Q : Puis‑je utiliser ces méthodes avec des graphiques créés dans d'autres programmes tableurs ?**  
Les exemples sont conçus pour des graphiques Excel créés avec Aspose.Cells, mais les principes s'appliquent à d'autres programmes tableurs compatibles OLE tant qu'ils offrent des options de dimensionnement similaires.

## **Sections liées**

- [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans des présentations](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Mettre à jour les objets OLE automatiquement à l'aide d'un add‑in PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)