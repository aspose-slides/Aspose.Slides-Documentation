---
title: Solution fonctionnelle pour le redimensionnement de graphiques dans PPTX
type: docs
weight: 60
url: /fr/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Corrigez le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l'utilisation d'objets Excel OLE intégrés avec Aspose.Slides pour .NET. Découvrez deux méthodes avec du code pour garder les tailles cohérentes."
---

## **Contexte**

Il a été constaté que les graphiques Excel intégrés en tant qu'objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non spécifiée après leur première activation. Ce comportement entraîne une différence visuelle notable dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose a étudié le problème en détail et a trouvé une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans l'[article précédent](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells pour .NET et l'intégrer dans une présentation PowerPoint à l'aide d'Aspose.Slides pour .NET. Pour résoudre le [problème d'aperçu de l'objet](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l'image du graphique au cadre d'objet OLE du graphique. Dans la présentation générée, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter toutes les modifications souhaitées au classeur Excel sous-jacent, puis retourner à la diapositive correspondante en cliquant en dehors du classeur activé. La taille du cadre d'objet OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d'origine du cadre d'objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Puisque le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d'origine lors de sa première activation. Le cadre d'objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille et maintiennent les proportions correctes dans le cadre du processus d'intégration. Selon les différences entre la taille de la fenêtre Excel et la taille ou la position du cadre d'objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scénarios possibles pour créer des présentations PowerPoint à l'aide d'Aspose.Slides pour .NET.

**Scenario 1 :** Créer une présentation à partir d'un modèle existant.

**Scenario 2 :** Créer une présentation à partir de zéro.

La solution que nous présentons ici s'applique aux deux scénarios. Le principe de toutes les approches de solution est le même : **la taille de la fenêtre de l'objet OLE intégré doit correspondre au cadre d'objet OLE dans la diapositive PowerPoint**. Nous allons maintenant examiner les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint.

**Scenario 1** 

Supposons que nous ayons défini un modèle et que nous souhaitions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLE est prédéfinie — elle correspond à la taille de la forme à l'index 2 du modèle. Tout ce que nous devons faire est de définir la taille de la fenêtre du classeur égale à celle de cette forme. Le fragment de code suivant remplit cet objectif :
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

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE de 4 pouces de hauteur et 9,5 pouces de largeur à x = 0,5 pouce et y = 1 pouce sur la diapositive. Nous définissons ensuite la fenêtre du classeur Excel à la même taille — 4 pouces de hauteur et 9,5 pouces de largeur.
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

Dans cette approche, nous apprendrons comment définir la taille du graphique dans le classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l'avance et ne changera jamais.

**Scenario 1** 

Supposons que nous ayons défini un modèle et que nous souhaitions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE est prédéfinie—correspondant à la taille de la forme à l'index 2 du modèle. Tout ce que nous devons faire est de définir la taille du graphique dans le classeur égale à celle de la forme. Le fragment de code suivant remplit cet objectif :
```cs
// Définir la taille du graphique sans fenêtre. 
// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).    
// Définir la hauteur du graphique en pixels.
// Définir la taille d'impression du graphique.
// Enregistrer le classeur dans un flux mémoire.
// Créer un cadre d'objet OLE avec les données Excel intégrées.
chart.SizeWithWindow = false;

chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);
chart.PrintSize = PrintSizeType.Custom;

MemoryStream workbookStream = workbook.SaveToStream();

Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Scenario 2** 

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE d'une hauteur de 4 pouces et d'une largeur de 9,5 pouces sur la diapositive à x = 0,5 pouce et y = 1 pouce. Nous définissons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 pouces et une largeur de 9,5 pouces.
```cs
 // Hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 576)

// Largeur souhaitée.
int desiredWidth = 684; // 9,5 pouces (9,5 * 576)

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

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**
Cela se produit parce qu'Excel tente de restaurer la taille de sa fenêtre d'origine lors de la première activation, alors que le cadre d'objet OLE dans PowerPoint a ses propres dimensions. PowerPoint et Excel négocient la taille pour conserver le ratio d'aspect, ce qui peut entraîner le redimensionnement.

**Est-il possible d'éviter complètement ce problème de redimensionnement ?**
Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à celle du cadre d'objet OLE avant l'intégration, vous pouvez maintenir des tailles de graphique cohérentes.

**Quelle approche devrais-je adopter, définir la taille de la fenêtre du classeur ou définir la taille du graphique ?**
Utilisez **Approach 1 (window size)** si vous souhaitez conserver le ratio d'aspect du classeur et éventuellement permettre un redimensionnement ultérieur.
Utilisez **Approach 2 (chart size)** si les dimensions du graphique sont fixes et ne changeront pas après l'intégration.

**Ces méthodes fonctionneront-elles à la fois pour les présentations basées sur un modèle et les nouvelles présentations ?**
Oui. Les deux approches fonctionnent de la même manière pour les présentations créées à partir de modèles et à partir de zéro.

**Existe-t-il une limite à la taille du cadre d'objet OLE ?**
Non. Vous pouvez définir le cadre OLE à n'importe quelle taille tant qu'il s'adapte correctement à la taille du classeur ou du graphique.

**Puis-je utiliser ces méthodes avec des graphiques créés dans d'autres programmes tableur ?**
Les exemples sont conçus pour les graphiques Excel créés avec Aspose.Cells, mais les principes s'appliquent à d'autres programmes tableur compatibles OLE tant qu'ils prennent en charge des options de dimensionnement similaires.

## **Sections connexes**

- [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans les présentations](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Mettre à jour les objets OLE automatiquement à l'aide d'un complément PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)