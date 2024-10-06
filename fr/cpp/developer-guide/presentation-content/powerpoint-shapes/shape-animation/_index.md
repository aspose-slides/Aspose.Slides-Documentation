---
title: Animation de Forme
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "animation PowerPoint, effet d'animation, appliquer animation, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Appliquer l'animation PowerPoint en C++"
---

Les animations sont des effets visuels qui peuvent être appliqués à des textes, images, formes ou [graphes](/slides/cpp/animated-charts/). Elles donnent vie aux présentations ou à ses constituants.

### **Pourquoi Utiliser des Animations dans les Présentations ?**

En utilisant des animations, vous pouvez 

* contrôler le flux d'informations
* souligner les points importants
* accroître l'intérêt ou la participation de votre public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur des parties importantes d'une présentation

PowerPoint offre de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **accentuation** et **chemins de mouvement**.

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec des animations sous le namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation),
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une Animation à un TextBox**

Aspose.Slides pour C++ vous permet d'appliquer une animation au texte d'une forme. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) à la valeur de l'[énumération BuildType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Écrivez la présentation sur le disque sous forme de fichier PPTX.

Ce code C++ vous montre comment appliquer l'effet `Fade` à un AutoShape et définir l'animation du texte sur la valeur *By 1st Level Paragraphs* :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoute un nouvel AutoShape avec du texte
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Premier paragraphe \nDeuxième paragraphe \n Troisième paragraphe");

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Ajoute un effet d'animation Fade à la forme
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anime le texte de la forme par les paragraphes de 1er niveau
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Sauvegarde le fichier PPTX sur le disque
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). Voir [**Texte Animé**](/slides/cpp/animated-text/).

{{% /alert %}} 

## **Appliquer une Animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) sur la diapositive. 
4. Obtenez la séquence principale d'effets.
5. Ajoutez un effet d'animation au [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. Écrivez la présentation sur le disque sous forme de fichier PPTX.

Ce code C++ vous montre comment appliquer l'effet `Fly` à un cadre d'image :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Charge une image à ajouter dans la collection d'images de la présentation
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Ajoute un cadre d'image à la diapositive
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ajoute un effet d'animation Fly de la gauche au cadre d'image
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Sauvegarde le fichier PPTX sur le disque
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Appliquer une Animation à une Forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (lorsque cet objet est cliqué, l'animation est jouée).
5. Créez une séquence d'effets sur la forme biseautée.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour vous déplacer vers le `UserPath`.
8. Écrivez la présentation sur le disque sous forme de fichier PPTX.

Ce code C++ vous montre comment appliquer l'effet `PathFootball` (chemin de football) à une forme :

```c++
	// Chemin du répertoire du document.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Charge la présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accède à la collection de formes pour la diapositive sélectionnée
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Crée un effet PathFootball pour une forme existante à partir de zéro.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Boîte de Texte Animée");

	// Ajoute l'effet d'animation PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Crée une sorte de "bouton".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Crée une séquence d'effets pour ce bouton.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après le clic sur le bouton.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Ajoute des commandes pour se déplacer puisque le chemin créé est vide.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	 //SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Écrit le fichier PPTX sur disque
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Obtenir les Effets d'Animation Appliqués à une Forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme. 

Ce code C++ vous montre comment obtenir tous les effets appliqués à une forme spécifique :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtient la première forme sur la diapositive.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Obtient tous les effets d'animation appliqués à la forme.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"La forme ") + shape->get_Name() + u" a " + shapeEffects->get_Length() + u" effets d'animation.");
}
```

## **Modifier les Propriétés de Temporisation de l'Effet d'Animation**

Aspose.Slides pour C++ vous permet de changer les propriétés de Temporisation d'un effet d'animation.

Voici le panneau de temporisation d'animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre la Temporisation PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) :

- La liste déroulante PowerPoint Timing **Début** correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- La **Durée** de la temporisation PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La durée d'une animation (en secondes) est le temps total qu'il faut pour que l'animation complète un cycle. 
- Le **Délai** de la temporisation PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Voici comment vous pouvez modifier les propriétés de Timing de l'Effet :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) dont vous avez besoin. 
3. Sauvegardez le fichier PPTX modifié.

Ce code C++ démontre l'opération :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Obtient le premier effet de la séquence principale.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Change le TriggerType de l'effet pour commencer au clic
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Change la Durée de l'effet
effect->get_Timing()->set_Duration(3.f);

// Change le TriggerDelayTime de l'effet
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Sauvegarde le fichier PPTX sur le disque
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Son de l'Effet d'Animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans les effets d'animation : 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Ajouter un Son à l'Effet d'Animation**

Ce code C++ vous montre comment ajouter un son d'effet d'animation et l'arrêter lorsque le prochain effet commence :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ajoute de l'audio à la collection audio de la présentation
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Vérifie si l'effet n'a pas "Pas de Son"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Ajoute du son pour le premier effet
    firstEffect->set_Sound(effectSound);
}

// Obtient la première séquence interactive de la diapositive.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Définit le drapeau "Arrêter le son précédent" de l'effet
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Écrit le fichier PPTX sur le disque
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extraire le Son de l'Effet d'Animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenez la référence d'une diapositive par son index. 
3. Obtenez la séquence principale d'effets. 
4. Extrayez le [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) intégré à chaque effet d'animation. 

Ce code C++ vous montre comment extraire le son intégré dans un effet d'animation :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Après l'Animation**

Aspose.Slides pour C++ vous permet de changer la propriété Après l'animation d'un effet d'animation.

Voici le panneau des effets d'animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante PowerPoint Effect **Après animation** correspond à ces propriétés : 

- La propriété [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) qui décrit le type d'animation après :
  * La fonction PowerPoint **Plus de Couleurs** correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * L'élément de liste **Ne pas Atténuer** correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (type d'animation après par défaut) ;
  * L'élément **Cacher Après Animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * L'élément **Cacher au Prochain Clic de Souris** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
- La propriété [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) qui définit un format de couleur après l'animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/). Si vous changez le type en un autre, la couleur après l'animation sera effacée.

Ce code C++ vous montre comment changer un effet après l'animation :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Change le type d'animation après en couleur
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Définit la couleur d'atténuation après l'animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Écrit le fichier PPTX sur le disque
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animer le Texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animer le texte* d'un effet d'animation :

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) qui décrit un type d'animation de texte de l'effet. Le texte de la forme peut être animé :
  - Tout en une fois ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) type)
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) type)
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) type)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive spécifie le pourcentage de la durée de l'effet. Une valeur négative spécifie le délai en secondes.

Voici comment vous pouvez changer les propriétés d'animation de l'effet de texte :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez la propriété [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) à la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *Par Paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) et [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) .
4. Sauvegardez le fichier PPTX modifié.

Ce code C++ démontre l'opération :

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Change le type d'animation du texte de l'effet à "En Un Seul Objet"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Change le type d'animation du texte de l'effet à "Par mot"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Définit le délai entre les mots à 20% de la durée de l'effet
firstEffect->set_DelayBetweenTextParts(20.0f);

// Écrit le fichier PPTX sur le disque
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```