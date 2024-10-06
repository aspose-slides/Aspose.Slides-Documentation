---
title: Solution Fonctionnelle pour le Redimensionnement de Graphiques dans PPTX
type: docs
weight: 60
url: /cpp/solution-fonctionnelle-pour-le-redimensionnement-de-graphique-dans-pptx/
---

{{% alert color="primary" %}} 

Il a été observé que les graphiques Excel intégrés en tant qu'OLÉ dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose, avec l'aide de l'équipe Microsoft, a examiné ce problème en détail et a trouvé une solution. Cet article couvre les raisons et la solution à ce problème.

{{% /alert %}} 
## **Contexte**
Dans [l'article précédent](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , nous avons expliqué comment créer un graphique Excel en utilisant Aspose.Cells pour C++ et ensuite intégrer ce graphique dans une présentation PowerPoint en utilisant Aspose.Slides pour C++. Afin de prendre en compte le problème de changement d'objet, nous avons attribué l'image du graphique au cadre d'objet OLÉ du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le cadre d'objet OLÉ affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter des modifications souhaitées dans le classeur Excel réel et ensuite revenir à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLÉ changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent pour différentes tailles de cadre d'objet OLÉ et de classeur Excel intégré.

## **Cause du Redimensionnement**
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille originale lors de la première activation. D'autre part, le cadre d'objet OLÉ aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences de taille de fenêtres Excel et de taille / position du cadre d'objet OLÉ, le redimensionnement a lieu.

## **Solution Fonctionnelle**
Il existe deux scénarios possibles pour la création de présentations PowerPoint en utilisant Aspose.Slides pour C++. 

**Scénario 1:** Créer la présentation basée sur un modèle existant.

**Scénario 2:** Créer la présentation à partir de zéro.

La solution que nous fournirons ici sera valable pour les deux scénarios. La base de toutes les approches de solution sera la même. C'est-à-dire : **La taille de la fenêtre de l'objet OLÉ intégré doit être la même que celle du cadre d'objet OLÉ** **dans la diapositive PowerPoint**. Maintenant, nous allons discuter des deux approches de la solution.

## **Première Approche**
Dans cette approche, nous allons apprendre comment définir la taille de la fenêtre du classeur Excel intégré équivalente à la taille du cadre d'objet OLÉ dans la diapositive PowerPoint.

**Scénario 1** 

Supposons que nous ayons défini un modèle et que nous souhaitions créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLÉ contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLÉ sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille de la fenêtre du classeur égale à la taille de la forme. Le code suivant servira cet objectif : 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// définir la taille du graphique avec la fenêtre 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// définir la largeur de la fenêtre du classeur en pouces (divisé par 72 car PowerPoint utilise 
// 72 pixels / pouce)
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// définir la hauteur de la fenêtre du classeur en pouces
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Instancier MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Créer un cadre d'objet OLÉ avec Excel intégré
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**Scénario 2** 

Disons que nous voulons créer une présentation à partir de zéro et désirer un cadre d'objet OLÉ de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLÉ avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x=0,5 pouce et y=1 pouce. De plus, nous avons défini la taille de la fenêtre correspondante du classeur Excel, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces. 

``` cpp
// Notre hauteur désirée
int32_t desiredHeight = 288; // 4 pouces (4 * 72)

// Notre largeur désirée
int32_t desiredWidth = 684; // 9,5 pouces (9,5 * 72)

// définir la taille du graphique avec la fenêtre 
chart->SetSizeWithWindow(true);

// définir la largeur de la fenêtre du classeur en pouces
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// définir la hauteur de la fenêtre du classeur en pouces
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Instancier MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Créer un cadre d'objet OLÉ avec Excel intégré
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **Deuxième Approche**
Dans cette approche, nous allons apprendre comment définir la taille du graphique présente dans le classeur Excel intégré équivalente à la taille du cadre d'objet OLÉ dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique à l'avance est connue et ne changera jamais. 

**Scénario 1** 

Supposons que nous ayons défini un modèle et que nous souhaitions créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLÉ contenant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLÉ sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille du graphique dans le classeur égale à la taille de la forme. Le code suivant servira cet objectif : 

``` cpp
// définir la taille du graphique sans fenêtre 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// définir la largeur du graphique en pixels (Multiplier par 96 car Excel utilise 96 pixels par pouce)    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// définir la hauteur du graphique en pixels
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Définir la taille d'impression du graphique
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Instancier MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Créer un cadre d'objet OLÉ avec Excel intégré
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**Scénario 2** 

Disons que nous voulons créer une présentation à partir de zéro et désirer un cadre d'objet OLÉ de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLÉ avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x=0,5 pouce et y=1 pouce. De plus, nous avons défini la taille équivalente du graphique, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces. 

``` cpp
// Notre hauteur désirée
int32_t desiredHeight = 288; // 4 pouces (4 * 576)

// Notre largeur désirée
int32_t desiredWidth = 684; // 9,5 pouces(9,5 * 576)

// définir la taille du graphique sans fenêtre 
chart->SetSizeWithWindow(false);

// définir la largeur du graphique en pixels    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// définir la hauteur du graphique en pixels    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Instancier MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// Créer un cadre d'objet OLÉ avec Excel intégré
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **Conclusion**
{{% alert color="primary" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement des graphiques. Le choix de l'approche appropriée dépend des besoins et du cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'y a pas de limite à la taille du cadre d'objet OLÉ dans la solution. 

{{% /alert %}} 
## **Sections Connexes**
[Créer et intégrer un graphique Excel en tant qu'objet OLÉ dans la présentation](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)