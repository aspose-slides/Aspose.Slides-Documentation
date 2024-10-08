---
title: Arrière-plan de Présentation
type: docs
weight: 20
url: /fr/cpp/presentation-background/
keywords: "arrière-plan PowerPoint, définir arrière-plan"
description: "Définir l'arrière-plan dans une présentation PowerPoint en CPP"
---

Les couleurs unies, les dégradés et les images sont souvent utilisés comme images d'arrière-plan pour les diapositives. Vous pouvez définir l'arrière-plan soit pour une **diapositive normale** (diapositive unique) soit pour une **diapositive maître** (plusieurs diapositives à la fois).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour une diapositive spécifique d'une présentation (même si cette présentation contient une diapositive maître). Le changement de fond n'affecte que la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) pour la diapositive à `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) pour l'arrière-plan de la diapositive à `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) exposée par [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment définir une couleur unie (bleu) comme arrière-plan pour une diapositive normale :

```c++
// Le chemin vers le répertoire des documents.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Définit la couleur d'arrière-plan pour la première ISlide à Bleu
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Écrit la présentation sur le disque
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour la diapositive maître d'une présentation. La diapositive maître agit comme un modèle qui contient et contrôle les paramètres de formatage pour toutes les diapositives. Par conséquent, lorsque vous sélectionnez une couleur unie comme arrière-plan pour la diapositive maître, ce nouvel arrière-plan sera utilisé pour toutes les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) pour la diapositive maître (`Masters`) à `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) pour l'arrière-plan de la diapositive maître à `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) exposée par [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment définir une couleur unie (vert forêt) comme arrière-plan pour une diapositive maître dans une présentation :

```c++
	// Le chemin vers le répertoire des documents.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Définit la couleur d'arrière-plan pour la Master ISlide à Vert Forêt
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	// Écrit la présentation sur le disque
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Définir une Couleur Dégradée comme Arrière-plan pour une Diapositive**

Un dégradé est un effet graphique basé sur un changement progressif de couleur. Les couleurs dégradées, lorsqu'elles sont utilisées comme arrière-plans pour les diapositives, rendent les présentations artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur dégradée comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) pour la diapositive à `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) pour l'arrière-plan de la diapositive à `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) exposée par [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) pour spécifier votre paramètre de dégradé préféré.
5. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment définir une couleur dégradée comme arrière-plan pour une diapositive :

```c++
// Crée une instance de la classe Presentation
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Applique l'effet dégradé à l'arrière-plan
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Écrit la présentation sur le disque
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Définir une Image comme Arrière-plan pour une Diapositive**

En plus des couleurs unies et dégradées, Aspose.Slides vous permet également de définir des images comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) pour la diapositive à `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) pour l'arrière-plan de la diapositive maître à `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) exposée par [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) pour définir l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment définir une image comme arrière-plan pour une diapositive :

```c++
// Le chemin vers le répertoire des documents.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Crée une instance de la classe Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Définit les conditions pour l'image d'arrière-plan
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Charge l'image
auto image = Images::FromFile(imagePath);

// Ajoute l'image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Écrit la présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Changer la Transparence de l'Image d'Arrière-plan**

Vous pouvez ajuster la transparence de l'image d'arrière-plan d'une diapositive pour faire ressortir le contenu de la diapositive. Ce code C++ vous montre comment changer la transparence d'une image d'arrière-plan de diapositive :

```c++
int32_t transparencyValue = 30;
// par exemple
// Obtient une collection d'opérations de transformation d'image
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// Trouve un effet de transparence avec un pourcentage fixe.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// Définit la nouvelle valeur de transparence.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Obtenir la Valeur de l'Arrière-plan de la Diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) pour vous permettre d'obtenir les valeurs effectives des arrière-plans de diapositives. Cette interface contient des informations sur le [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) effectif et sur le [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8) effectif.

En utilisant la propriété [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) de la classe [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/), vous pouvez obtenir la valeur effective pour un arrière-plan de diapositive.

Ce code C++ vous montre comment obtenir la valeur effective de l'arrière-plan d'une diapositive :

```c++
// Crée une instance de la classe Presentation
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"Couleur de remplissage : ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"Type de remplissage : ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```