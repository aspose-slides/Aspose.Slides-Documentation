---
title: Gérer les paramètres d'ajustement automatique
type: docs
weight: 30
url: /cpp/manage-autofit-settings/
keywords: "Textbox, Ajustement automatique, Présentation PowerPoint, C++, Aspose.Slides pour C++"
description: "Définir les paramètres d'ajustement automatique pour les zones de texte dans PowerPoint en C++"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Ajuster la forme pour contenir le texte** pour la zone de texte : elle redimensionne automatiquement la zone de texte pour s'assurer que son texte s'y adapte toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur — pour permettre de contenir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur — pour libérer de l'espace superflu.

Dans PowerPoint, ces 4 paramètres ou options sont importants pour contrôler le comportement d'ajustement automatique d'une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de débordement**
* **Ajuster la forme pour contenir le texte**
* **Enrouler le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour C++ propose des options similaires — certaines méthodes de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format) — qui vous permettent de contrôler le comportement d'ajustement automatique pour les zones de texte dans les présentations.

## **Ajuster la forme pour contenir le texte**

Si vous souhaitez que le texte dans une zone s'adapte toujours à cette zone après des modifications, vous devez utiliser l'option **Ajuster la forme pour contenir le texte**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code C++ montre comment spécifier qu'un texte doit toujours s'adapter à sa zone dans une présentation PowerPoint :

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

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour s'assurer que tout le texte y rentre. Si le texte devient plus court, l'inverse se produit.

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions quelles que soient les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas ajuster automatiquement**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code C++ montre comment spécifier qu'une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

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

## **Réduire le texte en cas de débordement**

Si un texte devient trop long pour sa zone, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour le faire tenir dans sa zone. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code C++ montre comment spécifier qu'un texte doit être réduit en cas de débordement dans une présentation PowerPoint :

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

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le paramètre ne s'applique que lorsque le texte devient trop long pour sa zone.

{{% /alert %}}

## **Enrouler le texte**

Si vous souhaitez que le texte dans une forme soit enroulé à l'intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Enrouler le texte dans la forme**. Pour spécifier ce paramètre, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame_format)) sur `true`.

Ce code C++ montre comment utiliser le paramètre Enrouler le texte dans une présentation PowerPoint :

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

Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte s'étend au-delà des bordures de la forme sur une seule ligne.

{{% /alert %}}