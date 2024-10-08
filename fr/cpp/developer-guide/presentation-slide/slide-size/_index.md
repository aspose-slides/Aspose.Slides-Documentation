---
title: Taille des diapositives
type: docs
weight: 70
url: /fr/cpp/slide-size/

---

## Tailles de diapositives dans les présentations PowerPoint

Aspose.Slides pour C++ vous permet de changer la taille ou le rapport d'aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez prêter attention à la taille ou au rapport d'aspect de ses diapositives.

Voici les tailles de diapositives et les rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou vue sur des appareils ou écrans relativement anciens, vous souhaiterez peut-être utiliser ce réglage.

- **Grand écran (rapport d'aspect 16:9)**

  Si votre présentation doit être vue sur des projecteurs ou des écrans modernes, vous souhaiterez peut-être utiliser ce réglage.

Vous ne pouvez pas utiliser plusieurs réglages de taille de diapositive dans une seule présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce réglage de taille de diapositive est appliqué à toutes les diapositives de la présentation.

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire dès le début. Idéalement, vous devriez spécifier votre taille de diapositive préférée au début, c'est-à-dire lorsque vous êtes en train de configurer la présentation — avant d'ajouter du contenu à la présentation. De cette façon, vous évitez les complications résultant de changements (futurs) apportés à la taille des diapositives.

{{% alert color="primary" %}} 

 Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou un rapport d'aspect de 4:3.

{{% /alert %}} 

## Changer la taille des diapositives dans les présentations 

 Ce code exemple vous montre comment changer la taille des diapositives dans une présentation en C++ en utilisant Aspose.Slides :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## Spécifier des tailles de diapositives personnalisées dans les présentations

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives pleine taille de votre présentation sur une mise en page de page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, vous êtes susceptible de bénéficier d'un réglage de taille personnalisée pour votre présentation.

Ce code exemple vous montre comment utiliser Aspose.Slides pour C++ pour spécifier une taille de diapositive personnalisée pour une présentation en C++ :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Taille du papier A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## Gérer les problèmes lors du changement de la taille des diapositives dans les présentations

Après avoir changé la taille des diapositives pour une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d'une présentation, vous pouvez spécifier un réglage qui détermine comment Aspose.Slides traite le contenu sur les diapositives.

Selon ce que vous comptez faire ou atteindre, vous pouvez utiliser l'un de ces réglages :

- `DoNotScale`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce réglage.

- `EnsureFit`

  Si vous voulez réduire à une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives pour s'assurer qu'ils s'adaptent tous aux diapositives (de cette façon, vous évitez de perdre du contenu), utilisez ce réglage.

- `Maximize`

  Si vous souhaitez agrandir à une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce réglage.

Ce code exemple vous montre comment utiliser le réglage `Maximize` lors du changement de la taille des diapositives d'une présentation :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```