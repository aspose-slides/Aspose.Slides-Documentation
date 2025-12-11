---
title: Redimensionner les formes sur les diapositives de présentation
type: docs
weight: 100
url: /fr/cpp/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier taille forme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour C++—automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---

## **Vue d'ensemble**

L'une des questions les plus courantes des clients d'Aspose.Slides pour C++ porte sur la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique bref montre comment procéder.

## **Redimensionner les formes**

Pour empêcher les formes de se désaligner lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu'elles correspondent à la nouvelle disposition de la diapositive.
```cpp
// Charge le fichier de présentation.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Redimensionne et repositionne les formes sur chaque diapositive.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Met a l'echelle la taille de la forme.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Met a l'echelle la position de la forme.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}} 
Si une diapositive contient un tableau, le code ci‑dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.
{{% /alert %}} 

Utilisez le code suivant de votre côté pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, définir la largeur ou la hauteur est un cas particulier : vous devez ajuster les hauteurs des lignes individuelles et les largeurs des colonnes pour modifier la taille globale du tableau.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Obtenir la taille originale de la diapositive.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Modifier la taille de la diapositive sans redimensionner les formes existantes.
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

**Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?**

Lors du redimensionnement d’une diapositive, les formes conservent leur position et leur taille d’origine à moins que l’échelle ne soit explicitement modifiée. Cela peut entraîner le rognage du contenu ou le désalignement des formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

L’exemple de base fonctionne pour la plupart des types de formes (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer séparément les lignes et les colonnes, car la hauteur et la largeur d’un tableau sont déterminées par les dimensions des cellules individuelles.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Vous devez parcourir toutes les lignes et colonnes du tableau et redimensionner leur hauteur et largeur proportionnellement, comme indiqué dans le deuxième exemple de code.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui, mais vous devez également parcourir les [Maîtres](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) et les [Diapositives de mise en page](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence de la présentation.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) en même temps que le redimensionnement ?**

Oui. Vous pouvez utiliser [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) pour changer l’orientation. Assurez‑vous de régler la logique de mise à l’échelle en conséquence afin de préserver la disposition.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

**Comment empêcher les formes à ratio d’aspect fixe de se déformer ?**

Vous pouvez vérifier la méthode `get_AspectRatioLocked` de la forme avant de la mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle individuellement.