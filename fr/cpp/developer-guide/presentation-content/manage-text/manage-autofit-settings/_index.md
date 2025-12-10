---
title: Améliorez vos présentations avec AutoFit en C++
linktitle: Paramètres Autofit
type: docs
weight: 30
url: /fr/cpp/manage-autofit-settings/
keywords:
- zone de texte
- autofit
- ne pas autofit
- adapter le texte
- réduire le texte
- retour à la ligne
- redimensionner la forme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour C++ afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Resize shape to fix text** pour la zone de texte — il redimensionne automatiquement la zone de texte pour garantir que son texte y rentre toujours. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur — pour lui permettre de contenir plus de texte. 
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur — pour éliminer l'espace superflu. 

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’auto‑ajustement pour une zone de texte : 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ propose des options similaires — certaines méthodes de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) — qui vous permettent de contrôler le comportement d’auto‑ajustement des zones de texte dans les présentations. 

## **Redimensionner une forme pour ajuster le texte**

Si vous souhaitez que le texte d’une zone s’ajuste toujours à cette zone après des modifications du texte, vous devez utiliser l’option **Resize shape to fix text**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `Shape`. 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code C++ vous montre comment spécifier qu’un texte doit toujours tenir dans sa zone dans une présentation PowerPoint :
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour garantir que tout le texte y tienne. Si le texte devient plus court, l’effet inverse se produit. 

## **Ne pas autofit**

Si vous voulez qu’une zone de texte ou une forme conserve ses dimensions quel que soit le texte qu’elle contient, vous devez utiliser l’option **Do not Autofit**. Pour appliquer ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code C++ vous montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


Lorsque le texte devient trop long pour sa zone, il déborde. 

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa zone, grâce à l’option **Shrink text on overflow**, vous pouvez spécifier que la taille et l’espacement du texte doivent être réduits pour qu’il tienne dans la zone. Pour appliquer ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `Normal`. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code C++ vous montre comment spécifier qu’un texte doit être réduit en cas de dépassement dans une présentation PowerPoint :
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Info" color="info" %}}
Lorsque l’option **Shrink text on overflow** est utilisée, le réglage n’est appliqué que lorsque le texte devient trop long pour sa zone. 
{{% /alert %}}

## **Wrap Text**

Si vous souhaitez que le texte d’une forme soit enveloppé à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Wrap text in shape**. Pour appliquer ce réglage, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `true`. 

Ce code C++ vous montre comment utiliser le réglage Wrap Text dans une présentation PowerPoint :
```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne. 
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit intervient plus tôt — en réduisant la police ou en redimensionnant la forme plus rapidement. Vérifiez et ajustez les marges avant d’affiner l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts imposés restent en place, et l’AutoFit ajuste la taille de la police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité avec laquelle l’AutoFit doit réduire le texte.

**Le fait de changer la police du thème ou de déclencher une substitution de police affecte‑t‑il les résultats de l’AutoFit ?**

Oui. Substituer une police avec des métriques de glyphe différentes modifie la largeur/hauteur du texte, ce qui peut modifier la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.