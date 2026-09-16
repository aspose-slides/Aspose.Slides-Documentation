---
title: Gérer les hyperliens de présentation en C++
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/cpp/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter hyperlien
- créer hyperlien
- formater hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien modifiable
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez, formatez, mettez à jour et supprimez les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++, à l'aide d'exemples C++."
---
## **Introduction**

Un hyperlien relie le contenu d’une présentation à un site Web ou à un emplacement au sein de la présentation. Dans PowerPoint, les hyperliens remplissent généralement deux fonctions :

* Ouvrir un site Web depuis du texte, une forme ou un cadre multimédia.  
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for C++ vous permet d’ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs paramètres et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Note" %}}

Vous pouvez également modifier les présentations avec le [éditeur en ligne gratuit Aspose PowerPoint](https://products.aspose.app/slides/fr/editor).

{{% /alert %}} 

## **Add URL Hyperlinks**

Vous pouvez affecter une URL de site Web à du texte, une forme ou un cadre multimédia. L’élément auquel vous affectez l’hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu’une forme ou un cadre lie l’objet de la diapositive.

### **Add URL Hyperlinks to Text**

Pour lier du texte à un site Web, créez un [Hyperlink](https://reference.aspose.com/slides/fr/cpp/aspose.slides/hyperlink/) et affectez‑le à la portion de texte via la méthode [set_HyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/portionformat/set_hyperlinkclick/), comme indiqué ci‑dessous. Seule cette portion de texte devient cliquable.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Add URL Hyperlinks to Shapes and Media Frames**

Pour rendre une forme ou un cadre cliquable, utilisez sa méthode [set_HyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/set_hyperlinkclick/). L’hyperlien appartient à l’objet lui‑-même plutôt qu’à une portion de texte à l’intérieur.

La même approche s’applique aux cadres d’image, d’audio et de vidéo : affectez l’hyperlien au cadre et utilisez [set_Tooltip](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_tooltip/) pour ajouter une astuce si nécessaire.

L’exemple suivant rend un rectangle cliquable :

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Use Hyperlinks to Create a Table of Contents**

Les hyperliens internes permettent aux lecteurs de passer d’une table des matières à une diapositive spécifique. L’exemple suivant utilise [SetInternalHyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Format Hyperlinks**

### **Color**

La méthode [set_ColorSource](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_colorsource/) de [IHyperlink](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/) détermine si un hyperlien utilise la couleur d’hyperlien de la présentation ou le formatage de la portion de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n’appliquent pas ce paramètre.

L’exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage rouge, le second conserve la couleur d’hyperlien par défaut.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Sound**

Un hyperlien peut jouer un son lorsqu’il est activé ou arrêter un son déjà en cours de lecture. Utilisez les méthodes suivantes pour configurer ces comportements :

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_sound/) spécifie le fichier audio associé à l’hyperlien.  
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) contrôle si l’activation de l’hyperlien arrête le son précédent.

#### **Add a Hyperlink Sound**

L’exemple suivant charge `sampleaudio.wav` et l’associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et passe à la diapositive suivante. Une seconde forme sur cette diapositive arrête le son précédent lorsqu’on clique dessus, sans effectuer d’action de navigation.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Extract a Hyperlink Sound**

L’exemple suivant ouvre la présentation créée ci‑dessus et lit le son d’hyperlien du premier cadre dans la mémoire via [get_Sound](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_sound/) et [get_BinaryData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Tooltip and Interaction Settings**

Vous pouvez mettre à jour les paramètres suivants de [IHyperlink](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/) grâce à ces méthodes après avoir affecté un hyperlien à du texte ou à une forme :

- [set_Tooltip](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_tooltip/) définit le texte affiché comme astuce pour le lien.  
- [set_TargetFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_targetframe/) indique le cadre cible au sein d’un frameset HTML parent, le cas échéant.  
- [set_History](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_history/) contrôle si l’activation du lien ajoute sa destination à la liste des hyperliens consultés.  
- [set_HighlightClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/set_highlightclick/) contrôle si l’hyperlien est mis en évidence lorsqu’on clique dessus.

## **Remove Hyperlinks from Presentations**

Utilisez [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) pour collecter les conteneurs d’hyperliens, y compris les liens de portions de texte, avant de les modifier. L’exemple suivant supprime les deux types d’activation de la première diapositive. Pour ne supprimer qu’un seul type, appelez uniquement [RemoveHyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ou [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) ; la suppression d’une action de clic ne supprime pas son pendant‑sur‑souris correspondant.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Pour une suppression inconditionnelle, [RemoveAllHyperlinks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) supprime les deux types d’activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif couvrant maîtres, mises en page et notes, voir [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Avant de diffuser une présentation, répertoriez ses actions interactives ainsi que ses liens Web. [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) renvoie des objets [IHyperlinkContainer](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkcontainer/), pas une simple liste de chaînes d’URL. Examinez à la fois [get_HyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) et [get_HyperlinkMouseOver](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, de sorte qu’un rapport complet nécessite jusqu’à deux lignes par conteneur.

Ne rechercher que les hyperliens au niveau des formes peut manquer les liens attachés aux portions de texte. Interrogez la portée appropriée, puis conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Query Presentation, Slide, and Text-Frame Scopes**

L’interface [IHyperlinkQueries](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/) est accessible via [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) et [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Chaque portée supporte les mêmes requêtes :

- [GetHyperlinkClicks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) renvoie les conteneurs avec une action de clic.  
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) renvoie les conteneurs avec une action de survol.  
- [GetAnyHyperlinks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) renvoie les conteneurs avec l’une ou les deux actions.

L’exemple suivant crée `hyperlink-audit-input.pptx` avec : un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de survol de texte et une action macro. Aucun de ces liens n’est exécuté. Les trois requêtes fonctionnent à chaque portée ; les comptes décrivent des conteneurs, pas le nombre total d’actions. La portée du cadre de texte exclut les liens propres à la forme englobante.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Dans cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs possédant l’une ou l’autre action. La requête du cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classify Actions and Destinations**

Utilisez [IHyperlink::get_ActionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_actiontype/) pour interpréter une action avant d’en interpréter la destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/hyperlinkactiontype/) couvrent plus que la navigation Web :

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; inspectez l’URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive précise. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation de diaporama intégrée, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Met fin au diaporama courant ou démarre un diaporama personnalisé. |
| `StartMacro` | Exécute une macro. |
| `StartProgram` | Lance un programme. |
| `OpenFile`, `OpenPresentation` | Ouvre un fichier ou une autre présentation ; à examiner séparément des URLs Web. |
| `StartStopMedia` | Démarre ou arrête la lecture d’un média. |
| `NoAction`, `Unknown` | Aucune action de navigation ou action non reconnue nécessitant une revue. |

Lisez les destinations externes via [get_ExternalUrl](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_externalurl/) et les destinations internes spécifiques via [get_TargetSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_targetslide/). Les actions internes et les commandes intégrées peuvent ne pas avoir d’URL externe ; une URL vide ne signifie pas que le conteneur est dépourvu d’action. Conservez [get_ExternalUrlOriginal](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) lorsqu’elle diffère de l’URL normalisée, et incluez l’astuce retournée par [get_Tooltip](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlink/get_tooltip/) si disponible.

### **Report, Sanitize, and Verify Hyperlinks**

L’exemple C++ suivant lit une présentation existante (utilisez le fichier créé plus haut), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et la rouvre pour vérifier à nouveau les deux types d’activation. Il récupère les conteneurs avant de les modifier et utilise l’identité des pointeurs pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire global du package, il interroge explicitement les maîtres, mises en page, notes et les maîtres de notes et de documents distribués lorsqu’ils sont présents.

Le rapport enregistre un indice de diapositive basé sur 1 et [get_SlideId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_slideid/) lorsqu’il est disponible. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecomponent/get_slide/) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les maîtres, mises en page et notes n’ont pas d’indice de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de formes et les conteneurs de formatage de portions de texte sont étiquetés séparément ; les autres types conservent leur nom de type d’exécution. Chaque conteneur reçoit un identifiant local au rapport afin que ses deux actions puissent être corrélées.

Cette politique d’application volontairement restrictive n’autorise que les URL HTTPS absolues et les cibles de diapositive internes valides. Elle rejette les macros, programmes, actions de fichiers, autres actions de diaporama, actions inconnues et autres schémas d’URL. Ces rejets sont des décisions politiques, pas un verdict de sécurité Aspose.Slides. Le HTTPS seul ne garantit pas la confiance : ajoutez des listes blanches d’hôtes et d’autres vérifications pour votre application. Les URL externes originales et normalisées sont toutes deux contrôlées. L’exemple audite les métadonnées sans suivre les liens ni exécuter d’actions.

Pour corriger, le [get_HyperlinkManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) du conteneur prend en charge [SetExternalHyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) et [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Ici, les liens externes de clic interdits sont remplacés par une page de destination HTTPS fixe ; les autres clics interdits et les actions de survol interdites sont supprimés de façon indépendante. Réglez `replaceExternalClicks` à `false` pour supprimer toutes les violations de politique. Choisissez une page de remplacement appartenant à votre application avant le déploiement.

Le drapeau d’exportation du rapport utilise une politique d’examen PDF prudente : les actions de survol et tout ce qui n’est pas un lien externe ou un saut de diapositive spécifique sont signalés comme potentiellement non pris en charge. Il s’agit d’une indication d’examen, pas d’un test de capacité ni d’une garantie que les liens non signalés survivront à l’exportation. Les exportations PDF et HTML prises en charge ([PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/cpp/convert-powerpoint-to-html/)) peuvent préserver les hyperliens selon l’action, les options d’exportation et le visualiseur. Les [images](/slides/fr/cpp/convert-powerpoint-to-png/) raster et les [vidéos](/slides/fr/cpp/convert-powerpoint-to-video/) ne peuvent pas conserver les hyperliens interactifs ; signalez chaque action lors d’un audit pour ces sorties.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Avec l’entrée créée ci‑dessus, le rapport contient cinq lignes d’action. Le lien de survol de fichier et la macro de clic sont supprimés, tandis que les liens HTTPS et la navigation interne demeurent. La vérification indique zéro action prohibée. Une entrée contenant une URL de clic externe prohibée montre également le branchement de remplacement. Un conteneur avec un clic autorisé et un survol prohibé conserve son action de clic.

Ce nettoyage sélectif diffère de [RemoveAllHyperlinks](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), qui supprime les deux types d’activation dans la portée sélectionnée quelles que soient les politiques. La vérification ici ne teste que les actions d’hyperliens ; elle ne supprime pas les projets VBA intégrés, les objets OLE ou autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**How can I link to a section or its first slide?**

Les sections dans PowerPoint regroupent des diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez‑vous à la première diapositive de cette section.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Oui. Les éléments du maître de diapositive et des mises en page prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le maître ou la mise en page correspondante.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Les exportations PDF et HTML prises en charge peuvent conserver les hyperliens ; les images raster et les vidéos, non. Consultez les considérations d’exportation dans [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).