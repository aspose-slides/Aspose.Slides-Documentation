---
title: Redimensionner les formes sur les diapositives de présentation
type: docs
weight: 100
url: /fr/cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour C++ — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

L'une des questions les plus fréquentes des clients d'Aspose.Slides pour C++ est de savoir comment redimensionner les formes de manière à ce que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique court montre comment procéder.

## **Redimensionner les formes**

Pour empêcher les formes de se désaligner lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu'elles correspondent à la nouvelle mise en page de la diapositive.

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

// Charger le fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Obtenir la taille originale de la diapositive.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Obtenir la nouvelle taille de la diapositive.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Redimensionner et repositionner les formes sur chaque diapositive.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Mettre à l'échelle la taille de la forme.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Mettre à l'échelle la position de la forme.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Si une diapositive contient un tableau, le code ci-dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.
{{% /alert %}} 

Utilisez le code suivant de votre côté pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, définir la largeur ou la hauteur est un cas particulier: vous devez ajuster les hauteurs des lignes individuelles et les largeurs des colonnes pour modifier la taille globale du tableau.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtenir la taille originale de la diapositive.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Obtenir la nouvelle taille de la diapositive.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Mettre à l'échelle la taille de la forme.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Mettre à l'échelle la position de la forme.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Mettre à l'échelle la taille de la forme.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Mettre à l'échelle la position de la forme.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Mettre à l'échelle la taille de la forme.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Mettre à l'échelle la position de la forme.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Pourquoi les formes sont-elles déformées ou tronquées après le redimensionnement d'une diapositive?

Lorsque vous redimensionnez une diapositive, les formes conservent leur position et taille d'origine à moins que l'échelle ne soit explicitement modifiée. Cela peut entraîner le rognage du contenu ou le désalignement des formes.

### Le code fourni fonctionne-t-il pour tous les types de formes?

L'exemple de base fonctionne pour la plupart des types de formes (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer séparément les lignes et les colonnes, car la hauteur et la largeur d'un tableau sont déterminées par les dimensions des cellules individuelles.

### Comment redimensionner les tableaux lors du redimensionnement d'une diapositive?

Vous devez parcourir toutes les lignes et colonnes du tableau et redimensionner leur hauteur et largeur proportionnellement, comme illustré dans le deuxième exemple de code.

### Ce redimensionnement fonctionnera-t-il pour les diapositives maîtres et les diapositives de disposition?

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_masters/) et les [Diapositives de mise en page](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_layoutslides/) et appliquer la même logique de mise à l'échelle à leurs formes afin d'assurer la cohérence de la présentation.

### Puis-je changer l'orientation d'une diapositive (portrait/landscape) lors du redimensionnement?

Oui. Vous pouvez utiliser [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidesize/set_orientation/) pour changer l'orientation. Assurez-vous de régler la logique de mise à l'échelle en conséquence afin de préserver la mise en page.

### Existe-t-il une limite à la taille de diapositive que je peux définir?

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très grandes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

### Comment éviter que les formes à ratio d'aspect fixe ne se déforment?

Vous pouvez vérifier la méthode `get_AspectRatioLocked` de la forme avant le redimensionnement. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l'échelle individuellement.