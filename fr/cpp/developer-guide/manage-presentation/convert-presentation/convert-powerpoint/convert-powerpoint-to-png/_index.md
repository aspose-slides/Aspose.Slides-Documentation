---
title: Convertir les diapositives PowerPoint en PNG avec C++
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/cpp/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- C++
- Aspose.Slides
description: "Convertir rapidement des présentations PowerPoint en images PNG de haute qualité avec Aspose.Slides pour C++, en garantissant des résultats précis et automatisés."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG à l'aide d'Aspose.Slides pour C++. Vous pouvez charger des présentations dans des formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l'enregistrer comme une image PNG distincte.

Les exemples ci-dessous démontrent le rendu à l'échelle par défaut, l'augmentation de l'échelle, la spécification des dimensions de sortie en pixels et le choix d'un style de rendu de dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et accédez à ses diapositives via l'accesseur [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). L'exemple rend chaque diapositive avec [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) sans paramètres pour créer une miniature. Il appelle ensuite [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) avec [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) pour enregistrer chaque diapositive rendue au format PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
La surcharge sans paramètre de [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) rend à une échelle de 0.2. Par exemple, une diapositive mesurant 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d'échelle ou une taille d'image explicite comme indiqué ci-dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d'échelle horizontaux et verticaux à [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont à 2, ainsi une diapositive mesurant 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d'échelle égaux conservent le rapport d'aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) au lieu des facteurs d'échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat avec [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Choisissez des dimensions correspondant au rapport d'aspect de la diapositive afin d'éviter d'étirer l'image.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Choisir un style de rendu de dégradé**

Supposons qu'une diapositive contienne des remplissages dégradés, mais que les transitions dans le PNG exporté semblent plus claires ou autrement différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la méthode [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l'application. Sa première diapositive contient deux dégradés linéaires : du cyan à l'orange en haut et du bleu au jaune en bas. Chaque dégradé possède deux points d'arrêt, à 0 % et 100 %.

L'exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Les images ci-dessous montrent le rendu de la même diapositive, avec les deux dégradés dans chaque image :

| Default | PowerPointUI |
| --- | --- |
| ![Dégradés cyan‑orange et bleu‑jaune rendus avec Default](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus foncées. La différence dépend des couleurs et des points d'arrêt du dégradé.

Choisissez `Default` lorsque la sortie standard d'Aspose.Slides répond à vos besoins. Essayez `PowerPointUI` lorsque votre priorité est de reproduire l'apparence dans PowerPoint. Comparez les deux sorties avec le résultat souhaité ; aucun des deux modes n'est universellement préférable.

## **FAQ**

**Comment puis‑je exporter une forme spécifique, comme un graphique ou une image, au lieu de la diapositive entière ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/cpp/shape-thumbnails/), vous permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque fil d'exécution ou processus ; [ne partagez pas une même instance entre les threads](/slides/fr/cpp/multithreading/).

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**

Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/cpp/licensing/) jusqu'à ce qu'une licence soit appliquée.