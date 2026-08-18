---
title: Gérer les en-têtes et pieds de page de la présentation en JavaScript
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/nodejs-java/presentation-header-and-footer/
keywords:
- en-tête
- "texte d'en-tête"
- pied de page
- texte de pied de page
- "définir l'en-tête"
- définir le pied de page
- fascicule
- notes
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, de date-heure, de numéro de diapositive et d'en-tête sur les diapositives, les pages de notes et les fascicules avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page selon le type de page. Aspose.Slides pour Node.js via Java vous permet de contrôler le texte et la visibilité de ces espaces réservés grâce aux classes de gestionnaire d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive normale | Non | Oui | Oui | Oui |
| Maître des notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Maître du fascicule | Oui | Oui | Oui | Oui |

Une diapositive de présentation normale ne possède pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les fascicules. Pour les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive à la place.

La portée d’une modification dépend du gestionnaire que vous utilisez. La classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideheaderfootermanager/) contrôle une diapositive normale. La classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de maître et de mise en page peuvent également propager les paramètres aux diapositives dépendantes, tandis que la classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) contrôle le maître du fascicule.

## **Définir le pied de page, la date/heure et le numéro de diapositives sur les diapositives normales**

Pour les diapositives normales, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositives sont générés par la présentation, vous n’avez donc besoin que de contrôler leur visibilité.

Utilisez [`setFooterText`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) et [`setDateTimeText`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) pour définir le texte, et utilisez [`setFooterVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) et [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) pour afficher les espaces réservés correspondants.

L’exemple complet suivant applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives normales :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via la méthode [`getSlides`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslides/) au lieu de parcourir l’ensemble de la collection.

## **Définir les en‑têtes et pieds de page sur le maître des notes**

Le maître des notes définit la mise en forme commune et le comportement des espaces réservés pour les pages de notes. Utilisez la classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque vous souhaitez modifier uniquement le maître des notes lui‑même.

L’exemple suivant définit l’en‑tête, le pied de page et le texte de date/heure sur le maître des notes et rend tous les espaces réservés pris en charge visibles sur ce maître :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La méthode [`getMasterNotesSlide`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) renvoie `null` lorsque la présentation ne contient pas de maître des notes.

## **Appliquer les paramètres du maître des notes aux diapositives de notes enfants**

Un maître des notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués à l’ensemble de la hiérarchie des notes.

Par exemple, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) et [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) mettent à jour l’en‑tête du maître des notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositive.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les méthodes de propagation utilisées ci‑dessus sont [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) et [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive normale spécifique. Utilisez sa classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [`addNotesSlide`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) renvoie la diapositive de notes pour la diapositive actuelle et en crée une si elle n’existe pas déjà. L’exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous propaguez d’abord les paramètres du maître des notes, puis modifiez une diapositive de notes individuelle, les paramètres spécifiques à la diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le maître du fascicule**

Les pages de fascicule utilisent le maître du fascicule pour leurs espaces réservés d’en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres du fascicule sont gérés via le maître du fascicule plutôt que via les fascicules individuels.

Utilisez [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) pour accéder au maître du fascicule. S’il n’est pas présent, appelez [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) pour créer le maître du fascicule par défaut.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideheaderfootermanager/) modifie les paramètres de pied de page, de date/heure et de numéro de diapositive pour une diapositive normale.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) contrôle un maître de diapositive normale et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) contrôle le maître des notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) modifie le maître du fascicule et prend en charge les quatre types d’espaces réservés.

Utilisez la propagation à partir d’un maître ou d’une mise en page lorsque le même paramètre doit s’appliquer à toute sa hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une seule page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive normale ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives normales. Sur les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les fascicules.

**Et si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`isFooterVisible`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indique si un espace réservé de pied de page est présent, et [`setFooterVisibility`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à une valeur autre que 1 ?**

Appelez la méthode [`setFirstSlideNumber`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation. Les espaces réservés de numéro de diapositive utilisent alors la nouvelle séquence de numérotation.

**Que se passe‑t‑il avec les en‑têtes et pieds de page lors de l’exportation vers PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exportée et des paramètres de visibilité des espaces réservés correspondants.