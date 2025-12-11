---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 60
url: /fr/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l'utilisation d'objets OLE Excel integres avec Aspose.Slides pour C++. Découvrez deux methodes avec du code pour maintenir des tailles coherentes."
---

## **Contexte**

Il a ete observe que les graphiques Excel integrés en tant qu'objets OLE dans une presentation PowerPoint via les composants Aspose sont redimensionnes a une echelle non specifiee apres leur premiere activation. Ce comportement entraine une difference visuelle notable dans la presentation entre les etats avant et apres l'activation du graphique. L'equipe Aspose a examine le probleme en detail et a trouve une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans l'[article precedent](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons explique comment creer un graphique Excel avec Aspose.Cells for C++ et l'integrer dans une presentation PowerPoint a l'aide d'Aspose.Slides for C++. Pour resoudre le [probleme d'aperçu d'objet](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/), nous avons attribue l'image du graphique au cadre d'objet OLE du graphique. Dans la presentation generee, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est active. Les utilisateurs finaux peuvent apporter toutes les modifications souhaitees au classeur Excel sous-jacent, puis retourner a la diapositive correspondante en cliquant en dehors du classeur active. La taille du cadre d'objet OLE change lorsque l'utilisateur revient a la diapositive, et le facteur de redimensionnement varie en fonction des tailles originales tant du cadre d'objet OLE que du classeur Excel integre.

## **Cause du redimensionnement**

Parce que le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille originale lors de sa première activation. Le cadre d'objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsque le classeur Excel est active, Excel et PowerPoint negocient la taille et maintiennent les proportions correctes dans le cadre du processus d'integration. Selon les differences entre la taille de la fenetre Excel et la taille ou la position du cadre d'objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scenarios possibles pour creer des presentations PowerPoint a l'aide d'Aspose.Slides for C++.

**Scénario 1:** Creer une presentation a partir d'un modele existant.

**Scénario 2:** Creer une presentation à partir de zéro.

La solution que nous proposons ici s'applique aux deux scenarios. Le principe de toutes les approches de solution est le même : **la taille de la fenêtre de l'objet OLE intégré doit correspondre au cadre d'objet OLE dans la diapositive PowerPoint**. Nous allons maintenant examiner les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'indice 2 dans le modèle où nous voulons placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLE est prédéfinie — elle correspond à la taille de la forme à l'indice 2 du modèle. Tout ce que nous devons faire est de régler la taille de la fenêtre du classeur à la même taille que cette forme. Le fragment de code suivant remplit ce rôle :
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Définir la taille du graphique avec une fenêtre.
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Définir la largeur de la fenêtre du classeur en pouces (divisée par 72 car PowerPoint utilise 72 pixels par pouce).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Définir la hauteur de la fenêtre du classeur en pouces.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Enregistrer le classeur dans un flux mémoire.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Créer un cadre d'objet OLE avec les données Excel intégrées.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```



**Scénario 2**

Disons que nous voulons créer une présentation à partir de zéro et inclure un cadre d'objet OLE de taille quelconque avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE de 4 pouces de haut et 9,5 pouces de large, positionné à x = 0,5 pouce et y = 1 pouce sur la diapositive. Nous réglons ensuite la fenêtre du classeur Excel à la même taille — 4 pouces de haut et 9,5 pouces de large.
```cpp
// Hauteur souhaitée.
int32_t desiredHeight = 288; // 4 pouces (4 * 72)

// Largeur souhaitée.
int32_t desiredWidth = 684; // 9,5 pouces (9.5 * 72)

// Définir la taille du graphique avec une fenêtre. 
chart->SetSizeWithWindow(true);

// Définir la largeur de la fenêtre du classeur en pouces.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Définir la hauteur de la fenêtre du classeur en pouces.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Enregistrer le classeur dans un flux mémoire.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Créer un cadre d'objet OLE avec les données Excel intégrées.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Deuxième approche**

Dans cette approche, nous apprendrons comment définir la taille du graphique dans le classeur Excel intégré afin qu'elle corresponde à la taille du cadre d'objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l'avance et ne changera jamais.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui-ci. Supposons qu'il y ait une forme à l'indice 2 du modèle où nous prévoyons de placer un cadre OLE contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE est prédéfinie — elle correspond à la taille de la forme à l'indice 2 du modèle. Tout ce que nous devons faire est de régler la taille du graphique dans le classeur à la même taille que cette forme. Le fragment de code suivant remplit ce rôle :
```cpp
// Définir la taille du graphique sans fenêtre. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Définir la hauteur du graphique en pixels.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Définir la taille d'impression du graphique.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Enregistrer le classeur dans un flux mémoire.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Créer un cadre d'objet OLE avec les données Excel intégrées.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**Scénario 2**

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d'objet OLE de taille quelconque avec un classeur Excel intégré. Dans le fragment de code suivant, nous créons un cadre d'objet OLE d'une hauteur de 4 pouces et d'une largeur de 9,5 pouces sur la diapositive, positionné à x = 0,5 pouce et y = 1 pouce. Nous réglons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 pouces et une largeur de 9,5 pouces.
```cpp
// Hauteur souhaitée.
int32_t desiredHeight = 288; // 4 pouces (4 * 576)

// Largeur souhaitée.
int32_t desiredWidth = 684; // 9,5 pouces (9.5 * 576)

// Définir la taille du graphique sans fenêtre. 
chart->SetSizeWithWindow(false);

// Définir la largeur du graphique en pixels.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Définir la hauteur du graphique en pixels.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Enregistrer le classeur dans un flux mémoire.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Créer un cadre d'objet OLE avec les données Excel intégrées.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **Conclusion**

Il existe deux approches pour resoudre le problème de redimensionnement du graphique. Le choix de l'approche dépend des exigences et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'y a aucune limite à la taille du cadre d'objet OLE dans cette solution.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**

Cela se produit parce qu'Excel tente de restaurer la taille de fenêtre originale lors de la première activation, alors que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel negocient la taille afin de maintenir le ratio d'aspect, ce qui peut entraîner le redimensionnement.

**Est-il possible d'éviter totalement ce problème de redimensionnement ?**

Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à la taille du cadre d'objet OLE avant l'intégration, vous pouvez maintenir des tailles de graphiques cohérentes.

**Quelle approche dois-je choisir, definir la taille de la fenêtre du classeur ou definir la taille du graphique ?**

Utilisez **Approche 1 (taille de la fenêtre)** si vous souhaitez conserver le ratio d'aspect du classeur et éventuellement permettre un redimensionnement ultérieur.  
Utilisez **Approche 2 (taille du graphique)** si les dimensions du graphique sont fixes et ne changeront pas après l'intégration.

**Ces methodes fonctionneront-elles avec les présentations basees sur un modele et les nouvelles présentations ?**

Oui. Les deux approches fonctionnent de la même manière pour les présentations creees à partir de modèles et à partir de zéro.

**Existe-t-il une limite à la taille du cadre d'objet OLE ?**

Non. Vous pouvez definir le cadre OLE à n'importe quelle taille tant qu'il s'adapte correctement à la taille du classeur ou du graphique.

**Puis-je utiliser ces methodes avec des graphiques crees dans d'autres programmes de tableauur ?**

Les exemples sont conçus pour les graphiques Excel créés avec Aspose.Cells, mais les principes s'appliquent à d'autres programmes de tableauur compatibles OLE tant qu'ils offrent des options de dimensionnement similaires.

## **Sections connexes**

- [Creer des graphiques Excel et les integrer en tant qu'objets OLE dans les présentations](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)