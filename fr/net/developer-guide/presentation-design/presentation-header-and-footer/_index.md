---
title: Gérer les en-têtes et pieds de page de la présentation en .NET
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les espaces réservés de pied de page, date-heure, numéro de diapositive et en-tête sur les diapositives, les pages de notes et les livrets avec Aspose.Slides pour .NET."
---
## **Aperçu**

PowerPoint utilise différents espaces réservés d’en‑tête et de pied de page selon le type de page. Aspose.Slides pour .NET vous permet de contrôler le texte et la visibilité de ces espaces réservés via les interfaces du gestionnaire d’en‑tête/pied de page.

Les espaces réservés disponibles dépendent de la portée :

| Portée | En‑tête | Pied de page | Date/heure | Numéro de diapositive/page |
|---|---|---|---|---|
| Diapositive normale | Non | Oui | Oui | Oui |
| Masque de notes | Oui | Oui | Oui | Oui |
| Diapositive de notes | Oui | Oui | Oui | Oui |
| Masque de livret | Oui | Oui | Oui | Oui |

Une diapositive de présentation normale ne possède pas d’espace réservé d’en‑tête. Les en‑têtes sont disponibles sur les pages de notes et les livrets. Pour les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive à la place.

La portée d’une modification dépend du gestionnaire que vous utilisez. L’interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/islideheaderfootermanager/) contrôle une diapositive normale. L’interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/inotesslideheaderfootermanager/) contrôle une diapositive de notes. Les gestionnaires de masque et de mise en page peuvent également propager les paramètres aux diapositives dépendantes, tandis que l’interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslideheaderfootermanager/) contrôle le masque de livret.

## **Définir le pied de page, la date/heure et les numéros de diapositive sur les diapositives normales**

Pour les diapositives normales, le flux de travail de base consiste à accéder au gestionnaire d’en‑tête/pied de page de chaque diapositive, définir le texte du pied de page et de la date/heure, activer les espaces réservés requis, puis enregistrer la présentation. Les numéros de diapositive sont générés par la présentation, vous n’avez donc besoin que de contrôler leur visibilité.

Utilisez [`SetFooterText`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) et [`SetDateTimeText`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) pour définir le texte, et utilisez [`SetFooterVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) et [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) pour afficher les espaces réservés correspondants.

L’exemple suivant, de bout en bout, applique le même pied de page, le même texte de date/heure et la même visibilité du numéro de diapositive à toutes les diapositives normales :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Si vous devez mettre à jour une seule diapositive, accédez directement à cette diapositive via la collection [`Slides`](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) au lieu de parcourir toute la collection.

## **Définir les en‑têtes et pieds de page sur le masque de notes**

Le masque de notes définit le format commun et le comportement des espaces réservés pour les pages de notes. Utilisez l’interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslideheaderfootermanager/) lorsque vous souhaitez modifier uniquement le masque de notes lui‑même.

L’exemple suivant définit l’en‑tête, le pied de page et le texte de date/heure sur le masque de notes et rend tous les espaces réservés pris en charge visibles sur ce masque :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

La propriété [`MasterNotesSlide`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslidemanager/masternotesslide/) renvoie `null` lorsque la présentation ne contient pas de masque de notes.

## **Appliquer les paramètres du masque de notes aux diapositives de notes filles**

Un masque de notes peut appliquer les paramètres d’en‑tête et de pied de page à lui‑même et à toutes les diapositives de notes dépendantes. Utilisez les méthodes de propagation dédiées sur [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslideheaderfootermanager/) lorsque les mêmes paramètres doivent être appliqués sur toute la hiérarchie des notes.

Par exemple, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) et [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) mettent à jour l’en‑tête du masque de notes et tous les en‑têtes enfants. Des méthodes équivalentes existent pour les pieds de page, la date/heure et les numéros de diapositive.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Les méthodes de propagation utilisées ci‑dessus sont [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) et [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Définir les en‑têtes et pieds de page sur une diapositive de notes individuelle**

Une diapositive de notes appartient à une diapositive normale spécifique. Utilisez son interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/inotesslideheaderfootermanager/) lorsque vous souhaitez personnaliser uniquement cette page de notes.

La méthode [`AddNotesSlide`](https://reference.aspose.com/slides/fr/net/aspose.slides/inotesslidemanager/addnotesslide/) renvoie la diapositive de notes pour la diapositive actuelle et en crée une si elle n’existe pas déjà. L’exemple suivant configure la page de notes associée à la première diapositive de la présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Si vous avez d’abord propagé les paramètres depuis le masque de notes, puis modifié une diapositive de notes individuelle, les paramètres ultérieurs par diapositive vous permettent de personnaliser cette page de notes de façon indépendante.

## **Définir les en‑têtes et pieds de page sur le masque de livret**

Les pages de livret utilisent le masque de livret pour leurs espaces réservés d’en‑tête, de pied de page, de date/heure et de numéro de page. Contrairement aux pages de notes, les paramètres du livret sont gérés via le masque de livret plutôt que via des diapositives de livret individuelles.

Utilisez la propriété [`MasterHandoutSlide`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) pour accéder au masque de livret. S’il n’est pas présent, appelez [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) pour créer le masque de livret par défaut.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Comprendre la portée et l’héritage**

Choisissez le gestionnaire d’en‑tête/pied de page qui correspond à la portée que vous souhaitez modifier :

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/islideheaderfootermanager/) modifie les paramètres de pied de page, de date/heure et de numéro de diapositive pour une diapositive normale.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslideheaderfootermanager/) contrôle une diapositive de mise en page et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslideheaderfootermanager/) contrôle un masque de diapositive normal et peut propager les paramètres pris en charge aux diapositives dépendantes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslideheaderfootermanager/) contrôle le masque de notes et peut propager les paramètres à toutes les diapositives de notes dépendantes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/inotesslideheaderfootermanager/) modifie une diapositive de notes et prend en charge un espace réservé d’en‑tête en plus du pied de page, de la date/heure et du numéro de diapositive.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslideheaderfootermanager/) modifie le masque de livret et prend en charge les quatre types d’espaces réservés.

Utilisez la propagation depuis un masque ou une mise en page lorsque le même paramètre doit s’appliquer à toute la hiérarchie. Utilisez un gestionnaire de diapositive individuelle ou de diapositive de notes lorsque vous avez besoin d’un paramètre local pour une page.

## **FAQ**

**Puis‑je ajouter un en‑tête à une diapositive normale ?**

Non. PowerPoint ne définit pas d’espace réservé d’en‑tête pour les diapositives normales. Sur les diapositives normales, utilisez les espaces réservés de pied de page, de date/heure et de numéro de diapositive. Les espaces réservés d’en‑tête sont disponibles sur les pages de notes et les livrets.

**Que faire si un espace réservé de pied de page, de date/heure ou de numéro de diapositive n’est pas visible ?**

Utilisez le gestionnaire d’en‑tête/pied de page correspondant pour vérifier sa visibilité et l’activer si nécessaire. Par exemple, [`IsFooterVisible`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indique si un espace réservé de pied de page est présent, et [`SetFooterVisibility`](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) modifie sa visibilité.

**Comment démarrer la numérotation des diapositives à partir d’une valeur autre que 1 ?**

Définissez la propriété [`FirstSlideNumber`](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/firstslidenumber/) de la présentation. Les espaces réservés de numéro de diapositive utilisent alors la séquence de numérotation mise à jour.

**Que se passe‑t‑il pour les en‑têtes et pieds de page lors de l’exportation vers PDF, images ou HTML ?**

Les éléments d’en‑tête et de pied de page visibles sont rendus avec le reste du contenu de la présentation dans le format de sortie. Leur apparence dépend du type de page exporté et des paramètres de visibilité des espaces réservés correspondants.