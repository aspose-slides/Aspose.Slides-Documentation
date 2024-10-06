---
title: Fusionner une Présentation - API C++ PowerPoint
linktitle: Fusionner une Présentation
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, C++"
description: L'article explique comment vous pouvez fusionner ou combiner des présentations PowerPoint en utilisant l'API ou la Bibliothèque C++ PowerPoint.
---

{{% alert  title="Astuce" color="primary" %}} 

Vous voudrez peut-être jeter un œil à **l'application Merger en ligne gratuite d'Aspose** [Merger app](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT à PPT, PPTX à PPTX, etc.) et de fusionner des présentations dans différents formats (PPT à PPTX, PPTX à ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusionner des Présentations**

Lorsque vous fusionnez une présentation à une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) manquent de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

Cependant, [**Aspose.Slides pour C++**](https://products.aspose.com/slides/cpp/) vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mises en forme, commentaires, animations, etc. sans avoir à vous soucier de la perte de qualité ou de données. 

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Ce Qui Peut Être Fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT à PPT, PPTX à PPTX, etc.) et dans différents formats (PPT à PPTX, PPTX à ODP, etc.) entre elles. 

{{% alert title="Remarque" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/cpp/merger/image-to-image/), telles que [JPG à JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) ou [PNG à PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Documents, tels que [PDF à PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) ou [HTML à HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Et deux fichiers différents tels que [image à PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) ou [JPG à PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) ou [TIFF à PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de Fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit des méthodes [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (de l'interface [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion de présentations. Chaque objet Présentation a une collection [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), vous pouvez donc appeler une méthode `AddClone` depuis la présentation à laquelle vous souhaitez fusionner des diapositives. 

La méthode `AddClone` retourne un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives de la source. Par conséquent, vous pouvez apporter des modifications aux diapositives résultantes (par exemple, appliquer des styles ou des options de mise en forme ou de mise en page) sans vous soucier que les présentations source soient affectées. 

## **Fusionner des Présentations** 

Aspose.Slides fournit la méthode [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut). 

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

## **Fusionner des Présentations avec le Maître de Diapositives**

Aspose.Slides fournit la méthode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation maître de diapositives. De cette façon, si nécessaire, vous pouvez changer le style des diapositives dans la présentation de sortie. 

Ce code en C++ démontre l'opération décrite :

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

La mise en page de la diapositive pour le maître de diapositives est déterminée automatiquement. Lorsqu'une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur vrai, la mise en page de la diapositive source est utilisée. Sinon, [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sera levée. 

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une mise en page de diapositive différente, utilisez la méthode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) à la place lors de la fusion. 

## **Fusionner des Diapositives Spécifiques de Présentations**

Ce code C++ vous montre comment sélectionner et combiner des diapositives spécifiques de différentes présentations pour obtenir une seule présentation de sortie :

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionner des Présentations Avec la Mise en Page des Diapositives**

Ce code C++ vous montre comment combiner des diapositives de présentations tout en leur appliquant votre mise en page préférée pour obtenir une seule présentation de sortie :

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Fusionner des Présentations Avec Différentes Tailles de Diapositive**

{{% alert title="Remarque" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositive différentes, vous devez redimensionner l'une des présentations pour que sa taille corresponde à celle de l'autre présentation. 

Ce code d'exemple démontre l'opération décrite :

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

## **Fusionner des Diapositives dans une Section de Présentation**

Ce code C++ vous montre comment fusionner une diapositive spécifique dans une section d'une présentation :

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

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner [JPG à JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG à PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}