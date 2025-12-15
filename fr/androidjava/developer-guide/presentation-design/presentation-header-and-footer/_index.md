---
title: Gérer les en-têtes et pieds de page des présentations sur Android
linktitle: En-tête & Pied de page
type: docs
weight: 140
url: /fr/androidjava/presentation-header-and-footer/
keywords:
- en-tête
- texte d'en-tête
- pied de page
- texte de pied de page
- définir l'en-tête
- définir le pied de page
- support
- notes
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides pour Android via Java pour ajouter et personnaliser les en-têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d’obtenir un rendu professionnel."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/androidjava/) offre une prise en charge pour travailler avec le texte des en‑têtes et pieds de page des diapositives qui sont réellement maintenus au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/fr/androidjava/) offre la fonctionnalité de gestion des en‑têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux‑ci sont en fait gérés au niveau du maître de présentation.

## **Gérer les en‑têtes et pieds de page dans une présentation**
Les notes d'une diapositive spécifique peuvent être supprimées comme indiqué dans l'exemple ci-dessous :
```java
// Charger la présentation
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Définir le pied de page
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Accéder et mettre à jour l'en-tête
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Enregistrer la présentation
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Méthode pour définir le texte d'en-tête/pied de page
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Gérer les en‑têtes et pieds de page sur les diapositives de support et de notes**
Aspose.Slides for Android via Java prend en charge les en‑têtes et pieds de page dans les diapositives de support et de notes. Veuillez suivre les étapes ci‑dessous :

- Charger une Presentation contenant une vidéo.
- Modifier les paramètres d'en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Définir le maître des diapositives de notes et tous les espaces réservés du pied de page enfants comme visibles.
- Définir le maître des diapositives de notes et tous les espaces réservés de date et heure enfants comme visibles.
- Modifier les paramètres d'en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Définir l'espace réservé d'en‑tête de la diapositive de notes comme visible.
- Définir le texte pour l'espace réservé d'en‑tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de date‑heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci‑dessous.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Modifier les paramètres d'en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés du pied de page enfants visibles
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés de l'en-tête enfants visibles
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés du numéro de diapositive enfants visibles
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rendre la diapositive maître des notes et tous les espaces réservés de date et d'heure enfants visibles

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // définir le texte sur la diapositive maître des notes et tous les espaces réservés d'en-tête enfants
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // définir le texte sur la diapositive maître des notes et tous les espaces réservés de pied de page enfants
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // définir le texte sur la diapositive maître des notes et tous les espaces réservés de date et d'heure enfants
    }

    // Modifier les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // rendre cet espace réservé d'en-tête de diapositive de notes visible

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // rendre cet espace réservé de pied de page de diapositive de notes visible

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // rendre cet espace réservé du numéro de diapositive de diapositive de notes visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rendre cet espace réservé de date-heure de diapositive de notes visible

        headerFooterManager.setHeaderText("New header text"); // définir le texte sur l'espace réservé d'en-tête de diapositive de notes
        headerFooterManager.setFooterText("New footer text"); // définir le texte sur l'espace réservé de pied de page de diapositive de notes
        headerFooterManager.setDateTimeText("New date and time text"); // définir le texte sur l'espace réservé de date-heure de diapositive de notes
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l'« en‑tête » n'existe que pour les notes et les supports ; sur les diapositives normales, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, cela correspond aux mêmes limitations : en‑tête uniquement pour Notes/Handout, et sur les diapositives — Footer/DateTime/SlideNumber.

**Et si la mise en page ne contient pas de zone de pied de page—puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d'en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes API sont conçus pour les cas où l'espace réservé est manquant ou masqué.

**Comment faire en sorte que le numéro de diapositive commence à une valeur autre que 1 ?**

Définissez le numéro de première diapositive de la présentation ; après cela, tous les numéros sont recalculés. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il avec les en‑têtes/pieds de page lors de l'exportation vers PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte normaux de la présentation. Ainsi, si les éléments sont visibles sur les diapositives/pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.