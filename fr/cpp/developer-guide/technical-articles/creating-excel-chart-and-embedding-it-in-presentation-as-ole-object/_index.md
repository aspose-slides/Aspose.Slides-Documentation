---
title: Créer des diagrammes Excel et les intégrer dans des présentations en tant qu'objets OLE
type: docs
weight: 40
url: /fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagramme Excel
- intégrer le diagramme
- objet OLE
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer un diagramme Excel avec Aspose.Cells for C++ et intégrer le classeur dans une présentation PowerPoint avec Aspose.Slides, incluant un aperçu du diagramme."
---
## **Vue d'ensemble**

Cet article montre comment créer un diagramme à barres Excel avec Aspose.Cells for C++ et intégrer son classeur dans une présentation PowerPoint avec Aspose.Slides for C++. Le classeur intégré contient à la fois les données source et le diagramme. Un aperçu PNG séparé affiche le diagramme sur la diapositive avant l'activation de l'objet OLE.

Le résultat est un objet Excel intégré, et non un diagramme PowerPoint natif. La modification du classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation Excel compatible.

## **Prérequis**

Configurez votre projet C++ avec les en‑têtes et les bibliothèques d'Aspose.Cells for C++ et d'Aspose.Slides for C++. Placez le code d'exemple dans le point d'entrée de votre application, avec les déclarations d'inclusion au niveau du fichier. Microsoft Office n'est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d'entrée n'est requis : l'exemple crée les données et le diagramme en mémoire, puis écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences pour les deux produits lors de l'exécution hors mode d'évaluation.

## **Fonctionnement de l'intégration**

1. Créer un classeur avec une feuille de données et une feuille de diagramme.  
2. Rendre la feuille de diagramme active afin que le classeur s'ouvre sur le diagramme.  
3. Définir la plage d'affichage OLE du classeur et rendre le diagramme en PNG.  
4. Enregistrer le classeur au format XLSX en mémoire et intégrer ces octets dans une diapositive.  
5. Attribuer le PNG comme aperçu de l'objet OLE et enregistrer la présentation au format PPTX.

La plage d'affichage du classeur et le cadre sur la diapositive ont des rôles différents. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) prend des indices de ligne et de colonne de début/fin basés sur zéro. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) prend quant à lui la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L'exemple utilise l'indice de ligne 55 et l'indice de colonne 25 comme limites inférieure‑droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L'exemple l'adapte à la diapositive et le centre tout en conservant le ratio d'aspect du PNG, plutôt que d'étirer l'aperçu pour remplir la diapositive.

## **Créer et intégrer le diagramme**

L'exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série de diagramme. `ChartSheet` est sélectionnée comme feuille active avant l'enregistrement du classeur.

Le classeur est explicitement enregistré au format XLSX, correspondant à l'extension `xlsx` transmise à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). Le PNG est chargé à partir d'un flux en mémoire sans conversion bitmap intermédiaire. Aspose.Cells renvoie des vecteurs d'octets, que l'exemple copie dans le type de tableau accepté par Aspose.Slides. Initialisez Aspose.Cells avant d'utiliser ses objets, et libérez ses ressources après la destruction de ces objets. L'assignation via [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) remplace le substitut OLE par défaut.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Rendu de l'aperçu du diagramme et sérialisation du classeur modifiable séparément.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copier les tampons Cells dans le type de tableau utilisé par Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Adapter l'aperçu à la diapositive sans modifier son ratio d'aspect.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Libérer les ressources Cells après que tous les objets Cells ont été détruits.
Aspose::Cells::Cleanup();
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel intégré et un aperçu du diagramme. Le classeur contient les données originales et un diagramme à colonnes avec quatre séries. L'aperçu est centré sur la diapositive et conserve ses proportions.

![Diagramme à colonnes Excel affiché comme aperçu d'un classeur intégré](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double-cliquez sur l'objet pour activer et modifier le classeur intégré. L'activation et la modification dépendent de la prise en charge OLE de l'application hôte et de ses paramètres de sécurité.

## **FAQ**

**Pourquoi une image d'aperçu est‑elle nécessaire ?**

Le classeur intégré et son aperçu sur la diapositive sont des contenus séparés. Fournissez une image de diagramme afin que la diapositive montre le diagramme au lieu du substitut par défaut « EMBEDDED OLE OBJECT ». Voir [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/).

**L'aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**

Considérez l'aperçu comme une capture. Lors de la mise à jour des données du classeur par programme, régénérez l'image du diagramme et remplacez à la fois l'aperçu et les données du classeur intégré.

**Puis‑je utiliser XLS au lieu de XLSX ?**

Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension des données intégrées. L'extension doit correspondre au format réel du classeur ; modifier uniquement l'extension ne convertit pas les données.

**Pourquoi l'objet peut‑il changer de taille après activation ?**

L'application hôte peut mettre à jour la présentation de l'objet OLE lorsqu'elle active le classeur. La plage d'affichage OLE du classeur et les dimensions du cadre de la diapositive sont toutes deux importantes. Voir [Solution fonctionnelle pour le redimensionnement du diagramme dans PPTX](/slides/fr/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Sections associées**

- [Solution fonctionnelle pour le redimensionnement du diagramme dans PPTX](/slides/fr/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/cpp/object-preview-issue-when-adding-oleobjectframe/)