---
title: Appliquer des animations de forme dans les présentations avec C++
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/cpp/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter une animation
- obtenir une animation
- extraire une animation
- ajouter un effet
- obtenir un effet
- extraire un effet
- son d'effet
- appliquer une animation
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint avec Aspose.Slides pour C++. Démarquez‑vous !"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [charts](/slides/fr/cpp/animated-charts/). Elles donnent vie aux présentations ou à leurs éléments. 

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant les animations, vous pouvez 

* contrôler le flux d'informations
* mettre en évidence les points importants
* accroître l'intérêt ou la participation de votre public
* faciliter la lecture, l'assimilation ou le traitement du contenu
* attirer l'attention de vos lecteurs ou spectateurs sur les parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrance**, **exit**, **emphasis** et **motion paths**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l’espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation).
* Aspose.Slides propose plus de **150 effets d'animation** dans l’énumération [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides pour C++ vous permet d'appliquer une animation au texte d'une forme. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Récupérez la séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) sur la valeur provenant de l'[énumération BuildType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C++ montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation du texte sur la valeur *Par paragraphes de niveau 1* :
```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). Voir [**Animated Text**](/slides/fr/cpp/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) sur la diapositive. 
4. Récupérez la séquence principale d'effets.
5. Ajoutez un effet d'animation au [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. Enregistrez la présentation sur le disque au format PPTX.

Ce code C++ montre comment appliquer l'effet `Fly` à un cadre d'image :
```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Charge l'image à ajouter à la collection d'images de la présentation
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Ajoute un cadre image à la diapositive
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Récupère la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ajoute l'effet d'animation Fly depuis la gauche au cadre image
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Enregistre le fichier PPTX sur le disque
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (lorsque cet objet est cliqué, l'animation se déclenche).
5. Créez une séquence d'effets sur la forme en biseau.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour le déplacement vers le `UserPath`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C++ montre comment appliquer l'effet `PathFootball` (path football) à une forme :
```c++
	// Le chemin du répertoire du document.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Charge la présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accède à la collection de formes de la diapositive sélectionnée
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Crée l'effet PathFootball pour la forme existante à partir de zéro.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Ajoute l'effet d'animation PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Crée une sorte de "bouton".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Crée une séquence d'effets pour ce bouton.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après que le bouton soit cliqué.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Ajoute des commandes de déplacement car le chemin créé est vide.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Écrit le fichier PPTX sur le disque
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Obtenir les effets d'animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `GetEffectsByShape` de l’interface [ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) pour obtenir tous les effets d'animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d'animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d'animation aux formes dans les présentations PowerPoint. Le code d'exemple suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.
```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Obtient la séquence d'animation principale de la diapositive.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtient la première forme de la première diapositive.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Obtient les effets d'animation appliqués à la forme.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```


**Exemple 2 : Obtenir tous les effets d'animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés qui se trouvent sur la diapositive de disposition et/ou la diapositive maître, et que des effets d'animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités des espaces réservés.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une diapositive avec uniquement une forme de pied de page affichant le texte "Made with Aspose.Slides" et que l'effet **Random Bars** soit appliqué à cette forme.

![Slide shape animation effect](slide-shape-animation.png)

Supposons également que l'effet **Split** soit appliqué à l'espace réservé du pied de page sur la diapositive **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Enfin, l'effet **Fly In** est appliqué à l'espace réservé du pied de page sur la diapositive **master**.

![Master shape animation effect](master-shape-animation.png)

Le code d'exemple suivant montre comment utiliser la méthode `GetBasePlaceholder` de l’interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pour accéder aux espaces réservés de la forme et obtenir les effets d'animation appliqués à la forme de pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de disposition et maîtres.
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```

```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Obtenir les effets d'animation de la forme sur la diapositive normale.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Obtenir les effets d'animation du espace réservateur sur la diapositive de mise en page.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Obtenir les effets d'animation du espace réservateur sur la diapositive maître.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vol, Bas
Type: 134, subtype: 45            // Diviser, Entrée verticale
Type: 126, subtype: 22            // Barres aléatoires, Horizontal
```


## **Modifier les propriétés de synchronisation d'un effet d'animation**

Aspose.Slides pour C++ vous permet de modifier les propriétés de synchronisation d'un effet d'animation.

Voici le volet Animation Timing dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

- La liste déroulante **Start** de PowerPoint Timing correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- La valeur **Duration** de PowerPoint Timing correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La durée d'une animation (en secondes) est le temps total nécessaire à l'animation pour accomplir un cycle. 
- La valeur **Delay** de PowerPoint Timing correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Voici comment modifier les propriétés de synchronisation de l'effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l'effet d'animation.
2. Définissez les nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) dont vous avez besoin. 
3. Enregistrez le fichier PPTX modifié.

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Obtient le premier effet de la séquence principale.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Modifie le TriggerType de l'effet pour démarrer au clic
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Modifie la durée de l'effet
effect->get_Timing()->set_Duration(3.f);

// Modifie le TriggerDelayTime de l'effet
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Enregistre le fichier PPTX sur le disque
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Son d'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec les sons dans les effets d'animation : 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Ajouter un son d'effet d'animation**

Ce code C++ montre comment ajouter un son à un effet d'animation et l'arrêter lorsque l'effet suivant démarre :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ajoute le son à la collection audio de la présentation
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient la séquence principale de la diapositive.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Vérifie si l'effet n'a pas de son
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Ajoute le son au premier effet
    firstEffect->set_Sound(effectSound);
}

// Obtient la première séquence interactive de la diapositive.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Définit le drapeau "Stop previous sound" de l'effet
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Enregistre le fichier PPTX sur le disque
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **Extraire le son d'un effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index. 
3. Récupérez la séquence principale d'effets. 
4. Extrayez le [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) intégré à chaque effet d'animation. 

Ce code C++ montre comment extraire le son intégré dans un effet d'animation :
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


## **Après animation**

Aspose.Slides pour C++ vous permet de modifier la propriété After animation d'un effet d'animation.

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** de PowerPoint correspond aux propriétés suivantes : 

- La propriété [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) qui décrit le type After animation :
  * **More Colors** de PowerPoint correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Don't Dim** de PowerPoint correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (type d'animation après défaut) ;
  * **Hide After Animation** de PowerPoint correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** de PowerPoint correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
- La propriété [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) qui définit un format de couleur après animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après animation sera effacée.

Ce code C++ montre comment modifier un effet après animation :
```c++
// Instancie une classe de présentation qui représente un fichier de présentation
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Modifie le type d'animation après en Couleur
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Définit la couleur d'atténuation après l'animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Enregistre le fichier PPTX sur le disque
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animate text* d'un effet d'animation :

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) qui décrit le type d'animation du texte de l'effet. Le texte de la forme peut être animé :
  - Tout d'un coup ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) )
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) )
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) )
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) définit un délai entre les parties du texte animées (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l'effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés Animate text de l'effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l'effet d'animation.
2. Définissez la propriété [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) et [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Enregistrez le fichier PPTX modifié.

```c++
// Instancie une classe de présentation qui représente un fichier de présentation.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtient le premier effet de la séquence principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Modifie le type d'animation du texte de l'effet en "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Modifie le type d'animation du texte de l'effet en "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Définit le délai entre les mots à 20% de la durée de l'effet
firstEffect->set_DelayBetweenTextParts(20.0f);

// Enregistre le fichier PPTX sur le disque
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le Web ?**

[Export to HTML5](/slides/fr/cpp/export-to-html5/) et activez les [options] responsables des animations de [shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) et de [transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/). Le HTML simple ne joue pas les animations de diapositive, alors que le HTML5 le fait.

**Comment le changement de l'ordre Z (ordre des calques) des formes affecte-t-il l'animation ?**

L'ordre d'animation et l'ordre de dessin sont indépendants : un effet contrôle la synchronisation et le type d'apparition/disparition, tandis que le [z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) détermine ce qui couvre quoi. Le résultat visible est défini par leur combinaison. (Ceci est le comportement général de PowerPoint ; le modèle d'effets et de formes d'Aspose.Slides suit la même logique.)

**Existe-t-il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/cpp/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.