---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 60
url: /fr/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer un graphique
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Corriger le redimensionnement inattendu des graphiques dans PPTX lors de l'utilisation d'objets OLE Excel intégrés avec Aspose.Slides pour C++. Définir des dimensions fixes pour le graphique afin de maintenir la cohérence des tailles du graphique et du cadre OLE."
---
## **Contexte**

Les graphiques Excel intégrés en tant qu'objets OLE dans les présentations PowerPoint à l'aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence notable de l'apparence du graphique avant et après l'activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l'éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans des présentations](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for C++ et l'intégrer dans une présentation PowerPoint à l'aide d'Aspose.Slides for C++. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l'image du graphique au cadre d'objet OLE du graphique. Dans la présentation générée, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel intégré, puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre d'objet OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie selon les tailles d'origine du cadre OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Le classeur Excel intégré possède ses propres dimensions de fenêtre, que Excel essaie de conserver lorsque l'objet est activé pour la première fois. Le cadre OLE sur la diapositive a des dimensions définies de façon indépendante. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l'objet afin de maintenir ses proportions dans le cadre du processus d'intégration. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc entraîner le redimensionnement de l'objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE sur la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L'exemple nécessite Aspose.Cells for C++ et Aspose.Slides for C++. Il crée un simple graphique à colonnes sur une feuille de graphique active et intègre le classeur au format XLS. Aucune image de prévisualisation du graphique n'est attribuée ; le graphique devient visible lorsque l'objet OLE est activé dans PowerPoint.

Placez le code d'exemple dans le point d'entrée de votre application, avec les déclarations d'inclusion au niveau du fichier. Initialise Aspose.Cells avant de créer ses objets et libère ses ressources après la destruction de ces objets. L'exemple copie le vecteur d'octets du classeur renvoyé par Aspose.Cells dans le type de tableau accepté par Aspose.Slides.

L'exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce). Pour une présentation existante, consultez [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) à false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) via [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) et [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), en convertissant les points en pixels avec 96 pixels par pouce : un cadre de 684 × 288 points correspond à un graphique de 912 × 384 pixels. Définissez [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) sur la valeur Custom de [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). L'exemple intègre le classeur avec [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce).
    auto width = 684.f; // 9,5 pouces.
    auto height = 288.f; // 4 pouces.

    chart.SetSizeWithWindow(false);
    // Convertir les points en pixels de graphique en utilisant 96 pixels par pouce.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Copier le vecteur d'octets Cells dans le type de tableau accepté par Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l'exemple :

1. Chargez la présentation modèle au lieu de créer une présentation vide.  
1. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l'index 2 comme espace réservé.  
1. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d'utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimensionnement inchangés.  
1. Ajoutez le cadre OLE à la position de l'espace réservé au lieu des coordonnées fixes 36 et 72.  
1. Supprimez l'espace réservé avant d'enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel intégré change-t-il de taille après son activation dans PowerPoint ?**  
Cela se produit parce que Excel tente de restaurer la taille originale de la fenêtre lors de la première activation, alors que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de préserver le ratio d'aspect, ce qui peut entraîner le redimensionnement.

**Comment garder les tailles du graphique et du cadre OLE cohérentes ?**  
Définissez des dimensions fixes pour le graphique qui correspondent au cadre OLE et utilisez une taille d’impression de graphique personnalisée avant d’intégrer le classeur. L'exemple ci‑dessus montre les paramètres requis et les conversions d'unités.

**Le fait d'aligner la taille de la fenêtre du classeur est‑il suffisant ?**  
Aligner uniquement la taille de la fenêtre du classeur ne garantit pas que le cadre OLE ne changera pas de taille après l'activation. Utilisez des dimensions fixes pour le graphique comme indiqué dans l'exemple.

**Cette solution fonctionne‑t‑elle avec les présentations basées sur un modèle et les nouvelles présentations ?**  
Oui. Pour un modèle, utilisez les dimensions et la position de l'espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**  
L'exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d'activation pour d'autres programmes de tableur.

## **Sections associées**

- [Créer des graphiques Excel et les intégrer en tant qu'objets OLE dans des présentations](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)