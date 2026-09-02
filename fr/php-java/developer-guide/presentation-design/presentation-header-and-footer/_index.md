---
title: Gérer les en-têtes et pieds de page de la présentation en PHP
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/php-java/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir l'en-tête
- définir le pied de page
- prospectus
- notes
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, de date-heure, de numéro de diapositive et d'en-tête sur les diapositives, les pages de notes et les prospectus avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page selon le type de page. Aspose.Slides for PHP via Java vous permet de contrôler le texte et la visibilité de ces espaces réservés via les classes de gestionnaire d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive normale | Non | Oui | Oui | Oui |
| Masque de notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Masque de prospectus | Oui | Oui | Oui | Oui |

Une diapositive de présentation normale ne possède pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les prospectus. Pour les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive à la place.

La portée d’une modification dépend du gestionnaire que vous utilisez. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideheaderfootermanager/) contrôle une diapositive normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de masque et de disposition peuvent également propager les paramètres aux diapositives dépendantes, tandis que la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) contrôle le masque de prospectus.

## **Définir le pied de page, la date/heure et les numéros de diapositives sur les diapositives normales**

Pour les diapositives normales, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositives sont générés par la présentation, vous n’avez donc besoin de contrôler que leur visibilité.

Utilisez [`setFooterText`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) et [`setDateTimeText`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) pour définir le texte, et utilisez [`setFooterVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) et [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) pour afficher les espaces réservés correspondants.

L’exemple complet suivant applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives normales :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via la méthode [`getSlides`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getslides/) au lieu d’itérer sur l’ensemble de la collection.

## **Définir les en‑têtes et pieds de page sur le masque de notes**

Le masque de notes définit le formatage commun et le comportement des espaces réservés pour les pages de notes. Utilisez la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque vous souhaitez modifier uniquement le masque de notes lui‑-même.

L’exemple suivant définit l’en‑tête, le pied de page et le texte de date/heure sur le masque de notes et rend visibles tous les espaces réservés pris en charge sur ce masque :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La méthode [`getMasterNotesSlide`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) renvoie `null` lorsque la présentation ne contient pas de masque de notes.

## **Appliquer les paramètres du masque de notes aux diapositives de notes enfants**

Un masque de notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués dans toute la hiérarchie des notes.

Par exemple, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) et [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) mettent à jour l’en‑tête du masque de notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositives.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les méthodes de propagation utilisées ci‑dessus sont [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) et [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive normale spécifique. Utilisez sa classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [`addNotesSlide`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notesslidemanager/addnotesslide/) renvoie la diapositive de notes pour la diapositive actuelle et en crée une si elle n’existe pas déjà. L’exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si vous propaguez d’abord les paramètres depuis le masque de notes puis modifiez une diapositive de notes individuelle, les paramètres appliqués ultérieurement à la diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le masque de prospectus**

Les pages de prospectus utilisent le masque de prospectus pour leurs espaces réservés d’en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres des prospectus sont gérés via le masque de prospectus plutôt que via les diapositives de prospectus individuelles.

Utilisez la méthode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) pour accéder au masque de prospectus. S’il n’est pas présent, appelez [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) pour créer le masque de prospectus par défaut.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideheaderfootermanager/) modifie les paramètres de pied de page, de date/heure et de numéro de diapositive pour une diapositive normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/layoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterslideheaderfootermanager/) contrôle un masque de diapositive normal et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masternotesslideheaderfootermanager/) contrôle le masque de notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifie le masque de prospectus et prend en charge les quatre types d’espaces réservés.

Utilisez la propagation depuis un masque ou une mise en page lorsque le même paramètre doit s’appliquer partout dans sa hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une seule page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive normale ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives normales. Sur les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les prospectus.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`isFooterVisible`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indique si un espace réservé de pied de page est présent, et [`setFooterVisibility`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à une valeur différente de 1 ?**

Appelez la méthode [`setFirstSlideNumber`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation. Les espaces réservés de numéro de diapositive utilisent alors la séquence de numérotation mise à jour.

**Que se passe‑t‑il pour les en‑têtes et pieds de page lors de l’exportation vers PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.