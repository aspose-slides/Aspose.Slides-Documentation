---
title: Gérer les espaces réservés de présentation en C++
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/cpp/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- texte d'invite
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez facilement les espaces réservés dans Aspose.Slides pour C++ : remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Modifier le texte d'un espace réservé**
En utilisant [Aspose.Slides for C++](/slides/fr/cpp/), vous pouvez trouver et modifier les espaces réservés sur les diapositives des présentations. Aspose.Slides vous permet de modifier le texte d'un espace réservé.

**Prerequisite**: Vous avez besoin d’une présentation contenant un espace réservé. Vous pouvez créer une telle présentation avec l’application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte de l'espace réservé dans cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) et passez la présentation en argument.
2. Obtenez une référence à une diapositive via son index.
3. Parcourez les formes pour trouver l'espace réservé.
4. Convertissez le type de la forme de l'espace réservé en [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) et modifiez le texte à l’aide du [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) associé à l'[`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/).
5. Enregistrez la présentation modifiée.

Ce code C++ montre comment modifier le texte d'un espace réservé :
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Charge la présentation souhaitée
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accède à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accède aux premier et deuxième espaces réservés de la diapositive et les convertit en AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Enregistre la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Définir le texte d’invite dans un espace réservé**
Les mises en page standard et pré‑construites contiennent des textes d’invite d’espace réservé comme ***Click to add a title*** ou ***Click to add a subtitle***. Avec Aspose.Slides, vous pouvez insérer vos propres textes d’invite dans les mises en page d’espaces réservés.

Ce code C++ vous montre comment définir le texte d’invite dans un espace réservé :
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Lorsqu'il n'y a pas de texte, PowerPoint affiche "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Fait la même chose pour le sous-titre.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspense::Slides::Export::SaveFormat::Pptx);
```


## **Définir la transparence d’une image d’espace réservé**

Aspose.Slides vous permet de définir la transparence de l’image d’arrière‑plan dans un espace réservé de texte. En ajustant la transparence de l’image dans ce cadre, vous pouvez mettre en valeur le texte ou l’image (selon les couleurs du texte et de l’image).

Ce code C++ vous montre comment régler la transparence d’un arrière‑plan d’image (à l’intérieur d’une forme) :
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


## **FAQ**

**What is a base placeholder, and how is it different from a local shape on a slide?**

Un espace réservé de base est la forme originale sur une disposition ou un maître dont hérite la forme de la diapositive — le type, la position et certains formats proviennent de celle‑ci. Une forme locale est indépendante ; s’il n’existe pas d’espace réservé de base, l’héritage ne s’applique pas.

**How can I update all titles or captions across a presentation without iterating over every slide?**

Modifiez l’espace réservé correspondant sur la disposition ou le maître. Les diapositives basées sur ces dispositions/ce maître hériteront automatiquement de la modification.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, dispositions, maître, notes/handouts) pour activer ou désactiver ces espaces réservés et définir leur contenu.