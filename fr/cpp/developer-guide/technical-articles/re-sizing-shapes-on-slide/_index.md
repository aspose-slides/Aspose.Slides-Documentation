---
title: Redimensionnement des Formes sur la Diapositive
type: docs
weight: 100
url: /cpp/re-sizing-shapes-on-slide/
---

#### **Redimensionnement des Formes sur la Diapositive**
Une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour C++ est comment redimensionner les formes de manière à ce que lorsque la taille de la diapositive est modifiée, les données ne soient pas coupées. Ce court conseil technique montre comment y parvenir.

Pour éviter la désorientation des formes, chaque forme sur la diapositive doit être mise à jour selon la nouvelle taille de la diapositive.

``` cpp
// Charger une présentation
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// Ancienne taille de la diapositive
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Changer la taille de la diapositive
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Nouvelle taille de la diapositive
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Redimensionner la position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionner la taille de la forme si nécessaire 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

S'il y a un tableau dans la diapositive, alors le code ci-dessus ne fonctionnerait pas parfaitement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.

{{% /alert %}} 

Vous devez utiliser le code suivant de votre côté si vous avez besoin de redimensionner les diapositives avec des tableaux. La définition de la largeur ou de la hauteur du tableau constitue un cas particulier dans les formes où vous devez modifier la hauteur des lignes individuelles et la largeur des colonnes pour modifier la hauteur et la largeur du tableau.

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// Ancienne taille de la diapositive
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Changer la taille de la diapositive
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Nouvelle taille de la diapositive
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // Redimensionner la position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionner la taille de la forme si nécessaire 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            //Redimensionner la position
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            //Redimensionner la taille de la forme si nécessaire 
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Redimensionner la position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Redimensionner la taille de la forme si nécessaire 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = System::ExplicitCast<ITable>(shape);
            for (auto row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * ratioHeight);
                //   row.Height = row.Height * ratioHeight;
            }
            for (auto col : table->get_Columns())
            {
                col->set_Width(col->get_Width() * ratioWidth);
            }
        }
    }
}

presentation->Save(u"D:\\Resize.pptx", Export::SaveFormat::Pptx);
```