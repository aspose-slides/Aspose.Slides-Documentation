---
title: Gérer les hyperliens de présentation en C++
linktitle: Gérer le lien hypertexte
type: docs
weight: 20
url: /fr/cpp/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter un hyperlien
- créer un hyperlien
- formater hyperlien
- supprimer le hyperlien
- mettre à jour le hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez facilement les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++ — améliorez l'interactivité et le flux de travail en quelques minutes."
---

Un hyperlien est une référence à un objet, à des données ou à un emplacement dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites web dans les textes, les formes ou les médias
* Liens vers des diapositives

Aspose.Slides for C++ vous permet d’effectuer de nombreuses tâches liées aux hyperliens dans les présentations. 

{{% alert color="primary" %}} 

Vous voudrez peut‑être découvrir Aspose simple, [éditeur PowerPoint en ligne gratuit.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajouter des hyperliens URL**

### **Ajouter des hyperliens URL au texte**

Ce code C++ montre comment ajouter un hyperlien vers un site web à un texte :
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


### **Ajouter des hyperliens URL aux formes ou aux cadres**

Ce code d’exemple en C++ montre comment ajouter un hyperlien vers un site web à une forme :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


### **Ajouter des hyperliens URL aux médias**

Aspose.Slides vous permet d’ajouter des hyperliens aux images, aux fichiers audio et vidéo. 

Ce code d’exemple montre comment ajouter un hyperlien à une **image** :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Ajoute une image à la présentation
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Crée un cadre image sur la diapositive 1 à partir de l'image ajoutée précédemment
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


Ce code d’exemple montre comment ajouter un hyperlien à un **fichier audio** :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


Ce code d’exemple montre comment ajouter un hyperlien à une **vidéo** :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


{{%  alert  title="Tip"  color="primary"  %}} 

Vous voudrez peut‑être consulter *[Gérer OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*.

{{% /alert %}}



## **Utiliser les hyperliens pour créer une table des matières**

Puisque les hyperliens vous permettent d’ajouter des références à des objets ou des emplacements, vous pouvez les utiliser pour créer une table des matières. 

Ce code d’exemple montre comment créer une table des matières avec des hyperliens :
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```



## **Formater les hyperliens**

### **Couleur**

Avec les méthodes [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) et [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) de l’interface [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink), vous pouvez définir la couleur des hyperliens et également récupérer les informations de couleur des hyperliens. Cette fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, de sorte que les modifications concernant cette propriété ne s’appliquent pas aux versions antérieures de PowerPoint.

Ce code d’exemple démontre une opération où des hyperliens de couleurs différentes ont été ajoutés à la même diapositive :
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```



## **Supprimer les hyperliens des présentations**

### **Supprimer les hyperliens du texte**

Ce code C++ montre comment supprimer l’hyperlien d’un texte dans une diapositive de présentation :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


### **Supprimer les hyperliens des formes ou des cadres**

Ce code C++ montre comment supprimer l’hyperlien d’une forme dans une diapositive de présentation :
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```




## **Hyperlien mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) est mutable. Avec cette classe, vous pouvez modifier les valeurs de ces méthodes :

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

L’extrait de code montre comment ajouter un hyperlien à une diapositive et modifier son info-bulle ultérieurement :
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```





## **Méthodes prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à IHyperlinkQueries depuis une présentation, une diapositive ou un texte pour lequel l’hyperlien est défini. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

La classe IHyperlinkQueries prend en charge ces méthodes : 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Comment puis‑je créer une navigation interne non seulement vers une diapositive, mais aussi vers une « section » ou la première diapositive d’une section ?**

Les sections dans PowerPoint sont des regroupements de diapositives ; la navigation cible techniquement une diapositive spécifique. Pour « naviguer vers une section », vous liez généralement à sa première diapositive.

**Puis‑je attacher un hyperlien aux éléments de la diapositive maîtresse afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments de la diapositive maîtresse et des dispositions prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives enfants et sont cliquables pendant le diaporama.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Dans [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l’exportation vers [images](/slides/fr/cpp/convert-powerpoint-to-png/) et [vidéo](/slides/fr/cpp/convert-powerpoint-to-video/), la possibilité de cliquer ne sera pas conservée en raison de la nature de ces formats (les images raster/les vidéos ne supportent pas les hyperliens).