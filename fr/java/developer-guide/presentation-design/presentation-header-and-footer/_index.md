---
title: Gérer les en-têtes et pieds de page de la présentation en Java
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/java/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte du pied de page
- définir l'en-tête
- définir le pied de page
- livret
- notes
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, date-heure, numéro de diapositive et en-tête sur les diapositives, les pages de notes et les livrets avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page en fonction du type de page. Aspose.Slides for Java vous permet de contrôler le texte et la visibilité de ces espaces réservés via les interfaces du gestionnaire d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive ordinaire | Non | Oui | Oui | Oui |
| Maître des notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Maître du livret | Oui | Oui | Oui | Oui |

Une diapositive ordinaire de présentation ne possède pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les livrets. Pour les diapositives ordinaires, utilisez les espaces réservés de pied de page, date/heure et numéro de diapositive.

La portée d’une modification dépend du gestionnaire que vous utilisez. L’interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islideheaderfootermanager/) contrôle une diapositive ordinaire. L’interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de maître et de disposition peuvent également propager les paramètres aux diapositives dépendantes, tandis que l’interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) contrôle le maître du livret.

## **Définir le pied de page, la date/heure et les numéros de diapositive sur les diapositives ordinaires**

Pour les diapositives ordinaires, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis et enregistrer la présentation. Les numéros de diapositive sont générés par la présentation, vous n’avez donc qu’à contrôler leur visibilité.

Utilisez [`setFooterText`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) et [`setDateTimeText`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) pour définir le texte, et utilisez [`setFooterVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), et [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) pour afficher les espaces réservés correspondants.

L’exemple complet suivant applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives ordinaires :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez mettre à jour une seule diapositive, accédez‑directement à cette diapositive via la méthode [`getSlides`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlides--) au lieu d’itérer sur l’ensemble de la collection.

## **Définir les en‑têtes et pieds de page sur le maître des notes**

Le maître des notes définit le format commun et le comportement des espaces réservés pour les pages de notes. Utilisez l’interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) lorsque vous souhaitez modifier uniquement le maître des notes lui‑-même.

L’exemple suivant définit le texte de l’en‑tête, du pied de page et de la date/heure sur le maître des notes et rend visibles tous les espaces réservés pris en charge sur ce maître :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La méthode [`getMasterNotesSlide`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) renvoie `null` lorsque la présentation ne contient pas de maître des notes.

## **Appliquer les paramètres du maître des notes aux diapositives de notes enfants**

Un maître des notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués à toute la hiérarchie des notes.

Par exemple, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) et [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) mettent à jour l’en‑tête du maître des notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les méthodes de propagation utilisées ci‑dessus sont [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), et [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive ordinaire spécifique. Utilisez son interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [`addNotesSlide`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) renvoie la diapositive de notes pour la diapositive actuelle et en crée une si elle n’existe pas déjà. L’exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous propaguez d’abord les paramètres depuis le maître des notes, puis modifiez une diapositive de notes individuelle, les paramètres spécifiques à chaque diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le maître du livret**

Les pages de livret utilisent le maître du livret pour leurs espaces réservés d’en‑tête, pied de page, date/heure et numéro de page. Contrairement aux pages de notes, les paramètres du livret sont gérés via le maître du livret plutôt que via des diapositives de livret individuelles.

Utilisez la méthode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) pour accéder au maître du livret. S’il n’est pas présent, appelez [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) pour créer le maître du livret par défaut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islideheaderfootermanager/) modifie les paramètres de pied de page, date/heure et numéro de diapositive pour une diapositive ordinaire.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilayoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslideheaderfootermanager/) contrôle un maître de diapositive ordinaire et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasternotesslideheaderfootermanager/) contrôle le maître des notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/inotesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) modifie le maître du livret et prend en charge les quatre types d’espaces réservés.

Utilisez la propagation à partir d’un maître ou d’une mise en page lorsque le même paramètre doit s’appliquer à toute la hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une seule page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive ordinaire ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives ordinaires. Sur les diapositives ordinaires, utilisez les espaces réservés de pied de page, date/heure et numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les livrets.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`isFooterVisible`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) indique si un espace réservé de pied de page est présent, et [`setFooterVisibility`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à une valeur autre que 1 ?**

Appelez la méthode [`setFirstSlideNumber`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la présentation. Les espaces réservés de numéro de diapositive utiliseront alors la séquence de numérotation mise à jour.

**Que se passe‑t‑il pour les en‑têtes et pieds de page lors de l’exportation en PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.