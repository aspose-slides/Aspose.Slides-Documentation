---
title: Fusionner efficacement des présentations en C++
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/cpp/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- C++
- Aspose.Slides
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour C++, simplifiant votre flux de travail."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de fusionner des présentations en clonant des diapositives d’une présentation à une autre. Cet article explique comment fusionner des présentations entières ou des diapositives sélectionnées, utiliser un masque de diapositives ou une mise en page spécifique pendant la fusion, gérer des présentations avec des tailles de diapositive différentes et ajouter des diapositives fusionnées à une section de présentation. Il couvre également des notes pratiques liées au contenu fusionné, y compris les notes du présentateur, les commentaires, les fichiers sources protégés par mot de passe et l’utilisation des threads.

## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier unique. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/fr/cpp/), toutefois, vous permet de fusionner des présentations de différentes façons. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, formatages, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données. 

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/fr/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT vers PPT, PPTX vers PPTX, etc.) et dans des formats différents (PPT vers PPTX, PPTX vers ODP, etc.) les unes avec les autres. 

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d’autres fichiers :

* [Images](https://products.aspose.com/slides/fr/cpp/merger/image-to-image/), comme [JPG to JPG](https://products.aspose.com/slides/fr/cpp/merger/jpg-to-jpg/) ou [PNG to PNG](https://products.aspose.com/slides/fr/cpp/merger/png-to-png/)
* Documents, comme [PDF to PDF](https://products.aspose.com/slides/fr/cpp/merger/pdf-to-pdf/) ou [HTML to HTML](https://products.aspose.com/slides/fr/cpp/merger/html-to-html/)
* Et deux fichiers différents comme [image to PDF](https://products.aspose.com/slides/fr/cpp/merger/image-to-pdf/) ou [JPG to PDF](https://products.aspose.com/slides/fr/cpp/merger/jpg-to-pdf/) ou [TIFF to PDF](https://products.aspose.com/slides/fr/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (de l’interface [ISlideCollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_slide_collection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion de présentations. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner des diapositives. 

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives d’une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple, appliquer des styles, des options de formatage ou des mises en page) sans craindre d’affecter les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone (ISlide)**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut). 

Ce code C++ vous montre comment fusionner des présentations :

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionner des présentations avec un masque de diapositive**

Aspose.Slides fournit la méthode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) qui vous permet de combiner des diapositives en appliquant un modèle de masque de diapositive. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives de la présentation de sortie. 

Ce code C++ démontre l’opération décrite :

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

La mise en page de la diapositive du masque est déterminée automatiquement. Lorsqu’une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, une exception [PptxEditException](https://reference.aspose.com/slides/fr/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sera levée. 

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une mise en page différente, utilisez la méthode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) lors de la fusion. 

## **Fusionner des diapositives spécifiques à partir de présentations**

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des jeux de diapositives personnalisés. Aspose.Slides C++ vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la mise en page et le design des diapositives originales.

Le code C++ suivant crée une nouvelle présentation, ajoute des diapositives titre provenant de deux autres présentations et enregistre le résultat dans un fichier :

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Déclaré dans le code ci‑dessus.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Fusionner des présentations avec une mise en page de diapositive**

Ce code C++ vous montre comment combiner des diapositives de présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie unique :

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner 2 présentations de tailles de diapositive différentes, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation. 

Ce code d’exemple démontre l’opération décrite :

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionner des diapositives dans une section de présentation**

Ce code C++ vous montre comment fusionner une diapositive spécifique dans une section d’une présentation :

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

La diapositive est ajoutée à la fin de la section. 

{{% alert title="Tip" color="info" %}}

Aspose propose une application web GRATUITE de collage ([Collage](https://products.aspose.app/slides/fr/collage)). En utilisant ce service en ligne, vous pouvez fusionner des [JPG to JPG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG à PNG, créer des [grilles de photos](https://products.aspose.app/slides/fr/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

### Les notes du présentateur sont-elles conservées lors de la fusion ?

Oui. Lors du clonage des diapositives, Aspose.Slides transfère tous les éléments de la diapositive, y compris les notes, le formatage et les animations.

### Les commentaires et leurs auteurs sont-ils transférés ?

Les commentaires, en tant que partie du contenu de la diapositive, sont copiés avec la diapositive. Les libellés d’auteur des commentaires sont conservés en tant qu’objets de commentaire dans la présentation résultante.

### Que se passe‑t‑il si la présentation source est protégée par un mot de passe ?

Elle doit être [ouverte avec le mot de passe](/slides/fr/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/); après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

### Quelle est la sécurité des threads de l’opération de fusion ?

N’utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/cpp/multithreading/). La règle recommandée est « un document — un thread » ; des fichiers différents peuvent être traités en parallèle dans des threads distincts.