---
title: Redimensionner les formes sur les diapositives de présentation en C++
type: docs
weight: 130
url: /fr/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /fr/cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- changer taille forme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour C++—automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Aperçu**

Lorsque vous modifiez la taille des diapositives d'une présentation, vous devez également redimensionner et repositionner ses formes pour qu'elles s'ajustent aux nouvelles dimensions. Cet article montre comment mettre à l'échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les masques et les dispositions.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur originale. Appliquez le même rapport de hauteur aux coordonnées verticales et à la hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, modifie la taille de la diapositive en A4 et enregistre le résultat. Il utilise [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) avec [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) afin que la boucle suivante contrôle la mise à l'échelle. Les rapports sont sans unité ; les positions et dimensions des formes sont exprimées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d'une forme ne met pas à l'échelle les tailles de police.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Les tables nécessitent une prise en charge distincte : mettre à l'échelle leurs largeurs de colonnes et hauteurs de lignes au lieu d'attribuer la largeur et la hauteur globales du tableau. Les hauteurs de lignes peuvent rester supérieures à la valeur demandée si le contenu de la cellule nécessite plus d'espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tables et traite les formes sur les masques et les dispositions ainsi que sur les diapositives individuelles avant d'enregistrer la présentation redimensionnée. Son utilitaire gère chaque [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) en mettant à l'échelle [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) et [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Il met ensuite à l'échelle la position du tableau sans mettre séparément à l'échelle ses dimensions globales.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Les dimensions du tableau sont contrôlées par les largeurs des colonnes et les hauteurs des lignes.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Redimensionner les formes définies sur les masques et les dispositions ainsi que sur les diapositives individuelles.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Pourquoi les formes sont-elles déformées ou tronquées après le redimensionnement d'une diapositive ?**

Si vous modifiez la taille de la diapositive sans mettre à l'échelle les formes, elles conservent leurs positions et dimensions d'origine et peuvent dépasser la diapositive. Mettre à l'échelle la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne-t-il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tables. Le deuxième exemple gère les tables séparément. Vérifiez la mise en page résultante, en particulier le texte et les tables, car ces exemples ne mettent pas à l'échelle les tailles de police et le contenu des tables peut contraindre les hauteurs de lignes.

**Comment redimensionner les tables lors du redimensionnement d'une diapositive ?**

Mettez à l'échelle les largeurs des colonnes selon le rapport de largeur et les hauteurs minimales des lignes selon le rapport de hauteur, puis mettez à l'échelle la position du tableau, comme indiqué dans le deuxième exemple.

**Ce redimensionnement fonctionnera-t-il pour les masques de diapositives et les dispositions de diapositives ?**

Oui. Le deuxième exemple parcourt [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) et les [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) de chaque masque, et applique la même logique de redimensionnement à leurs formes.

**Puis-je changer l'orientation d'une diapositive (portrait/paysage) en même temps que le redimensionnement ?**

Oui. Définissez [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d'échelle reflètent l'orientation finale.

**Existe-t-il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Les dimensions prises en charge dépendent également du format de la présentation et de l'application utilisée pour ouvrir le fichier.

**Comment éviter que les formes avec un ratio d'aspect fixe ne se déforment ?**

Utilisez le même facteur d'échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des deux rapports de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d'un bord.