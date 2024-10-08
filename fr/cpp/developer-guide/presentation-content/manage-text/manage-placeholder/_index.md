---
title: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/cpp/manage-placeholder/
keywords: "Espace réservé, Texte d'espace réservé, Texte d'invite, Présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Modifier le texte des espaces réservés et le texte d'invite dans les présentations PowerPoint en C++"
---

## **Modifier le texte dans un espace réservé**
En utilisant [Aspose.Slides pour C++](/slides/fr/cpp/), vous pouvez trouver et modifier des espaces réservés sur des diapositives dans des présentations. Aspose.Slides vous permet d'apporter des modifications au texte dans un espace réservé.

**Prérequis** : Vous avez besoin d'une présentation contenant un espace réservé. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) et passez la présentation comme argument.
2. Obtenez une référence à une diapositive via son index.
3. Parcourez les formes pour trouver l'espace réservé.
4. Typecast la forme d'espace réservé en [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) et changez le texte en utilisant le [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) associé à l[`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Enregistrez la présentation modifiée.

Ce code C++ montre comment modifier le texte dans un espace réservé :

```c++
// Le chemin vers le répertoire des documents.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accède aux premier et deuxième espaces réservés de la diapositive et les typecast en AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"Ceci est un espace réservé");
	
// Enregistre la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir le texte d'invite dans un espace réservé**
Les mises en page standard et préconstruites contiennent des textes d'invite d'espace réservé tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page d'espace réservé.

Ce code C++ vous montre comment définir le texte d'invite dans un espace réservé :

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Lorsqu'il n'y a pas de texte, PowerPoint affiche "Cliquez pour ajouter un titre". 
        {
            text = u"Cliquez pour ajouter un titre";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Fait la même chose pour le sous-titre.
        {
            text = u"Cliquez pour ajouter un sous-titre";
        }
        System::Console::WriteLine(u"Espace réservé : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Définir la transparence de l'image de l'espace réservé**

Aspose.Slides vous permet de définir la transparence de l'image d'arrière-plan dans un espace réservé de texte. En ajustant la transparence de l'image dans une telle forme, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code C++ vous montre comment définir la transparence pour une image d'arrière-plan (à l'intérieur d'une forme) :

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```