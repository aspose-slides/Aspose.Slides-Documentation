---
title: Fusionner efficacement les présentations en C++
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/cpp/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner des présentations
- fusionner des diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- C++
- Aspose.Slides
description: "Fusionnez facilement les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour C++, en simplifiant votre flux de travail."
---

{{% alert title="Astuce" color="primary" %}} 

Vous pourriez vouloir consulter **Aspose gratuit en ligne** [Application de fusion](https://products.aspose.app/slides/merger). Elle permet de fusionner des présentations PowerPoint dans le même format (PPT en PPT, PPTX en PPTX, etc.) et de fusionner des présentations dans des formats différents (PPT en PPTX, PPTX en ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier unique. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) permet toutefois de fusionner des présentations de différentes façons. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mise en forme, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données. 

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations sont réunies dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées sont réunies dans une seule présentation
* des présentations dans un même format (PPT en PPT, PPTX en PPTX, etc.) et dans des formats différents (PPT en PPTX, PPTX en ODP, etc.) les unes avec les autres. 

{{% alert title="Remarque" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d’autres fichiers :

* [Images](https://products.aspose.com/slides/cpp/merger/image-to-image/), telles que [JPG en JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) ou [PNG en PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Documents, tels que [PDF en PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) ou [HTML en HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Et deux fichiers différents tels que [image vers PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) ou [JPG vers PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) ou [TIFF vers PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (depuis l’interface [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Plusieurs implémentations des méthodes `AddClone` définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c); vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner des diapositives. 

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple, appliquer des styles, des options de mise en forme ou des dispositions) sans vous soucier d’affecter les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) qui permet de combiner des diapositives tout en conservant leurs dispositions et styles (paramètres par défaut). 

Ce code C++ vous montre comment fusionner des présentations :
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Fusionner des présentations avec un maître de diapositive** 

Aspose.Slides fournit la méthode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) qui permet de combiner des diapositives tout en appliquant un modèle de maître de diapositive. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives de la présentation de sortie. 

Ce code C++ illustre l’opération décrite :
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Remarque" color="warning" %}} 

La disposition de la diapositive maître est déterminée automatiquement. Lorsqu’une disposition appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la disposition de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sera levée. 

{{% /alert %}}

Si vous voulez que les diapositives de la présentation de sortie aient une disposition différente, utilisez la méthode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) lors de la fusion. 

## **Fusionner des diapositives spécifiques à partir de présentations** 

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des ensembles de diapositives personnalisés. Aspose.Slides C++ vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve la mise en forme, la disposition et le design des diapositives originales. 

Le code C++ suivant crée une nouvelle présentation, ajoute des diapositives titre provenant de deux autres présentations, puis enregistre le résultat dans un fichier :
```cpp
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


## **Fusionner des présentations avec une disposition de diapositive** 

Ce code C++ vous montre comment combiner des diapositives provenant de présentations tout en appliquant votre disposition de diapositive préférée afin d’obtenir une présentation de sortie unique :
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Fusionner des présentations avec des tailles de diapositive différentes** 

{{% alert title="Remarque" color="warning" %}} 

Il est impossible de fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositive différentes, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation. 

Ce code d’exemple montre l’opération décrite :
```cpp
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

Ce code C++ montre comment fusionner une diapositive spécifique dans une section d’une présentation :
```cpp
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

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web GRATUITE de collage](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

**Les notes du présentateur sont‑elles conservées lors de la fusion ?**

Oui. Lors du clonage des diapositives, Aspose.Slides transfère tous les éléments de la diapositive, y compris les notes, la mise en forme et les animations.

**Les commentaires et leurs auteurs sont‑ils transférés ?**

Les commentaires, faisant partie du contenu de la diapositive, sont copiés avec la diapositive. Les étiquettes des auteurs de commentaires sont préservées en tant qu’objets commentaire dans la présentation résultante.

**Que se passe‑t‑il si la présentation source est protégée par mot de passe ?**

Elle doit être [ouvert avec le mot de passe](/slides/fr/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/); après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

**Quel est le niveau de thread‑safety de l’opération de fusion ?**

N’utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/cpp/multithreading/). La règle recommandée est « un document — un thread » ; différents fichiers peuvent être traités en parallèle dans des threads séparés.