---
title: Gérer les en-têtes et pieds de page de la présentation en Java
linktitle: En-tête et pied de page
type: docs
weight: 140
url: /fr/java/presentation-header-and-footer/
keywords:
- en-tête
- texte d’en-tête
- pied de page
- texte de pied de page
- définir l’en-tête
- définir le pied de page
- version imprimable
- notes
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Java pour ajouter et personnaliser les en-têtes et pieds de page dans les présentations PowerPoint et OpenDocument afin d’obtenir un rendu professionnel."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/java/) offre une prise en charge du texte des en‑têtes et pieds de page des diapositives, qui sont en fait gérés au niveau du maître des diapositives.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/fr/java/) offre la fonctionnalité de gestion des en‑têtes et pieds de page dans les diapositives d’une présentation. Ceux‑ci sont en fait gérés au niveau du maître de la présentation.

## **Gérer les en‑têtes et pieds de page dans une présentation**
Les notes d’une diapositive spécifique peuvent être supprimées comme le montre l’exemple ci‑dessus :
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


## **Gérer les en‑têtes et pieds de page sur les diapositives de version imprimable et de notes**
Aspose.Slides for Java prend en charge les en‑têtes et pieds de page dans les diapositives de version imprimable et de notes. Veuillez suivre les étapes ci‑dessous :

- Charger une [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenant une vidéo.
- Modifier les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendre visible le maître des diapositives de notes ainsi que tous les espaces réservés de pied de page enfants.
- Rendre visible le maître des diapositives de notes ainsi que tous les espaces réservés de date et d’heure enfants.
- Modifier les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre visible l’espace réservé d’en‑tête de la diapositive de notes.
- Définir le texte de l’espace réservé d’en‑tête de la diapositive de notes.
- Définir le texte de l’espace réservé de date‑heure de la diapositive de notes.
- Enregistrer le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Modifier les paramètres d'en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rendre le maître des diapositives de notes et tous les espaces réservés de pied de page enfants visibles
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rendre le maître des diapositives de notes et tous les espaces réservés d'en-tête enfants visibles
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rendre le maître des diapositives de notes et tous les espaces réservés de numéro de diapositive enfants visibles
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rendre le maître des diapositives de notes et tous les espaces réservés de date et d'heure enfants visibles

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // définir le texte du maître des diapositives de notes et de tous les espaces réservés d'en-tête enfants
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // définir le texte du maître des diapositives de notes et de tous les espaces réservés de pied de page enfants
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // définir le texte du maître des diapositives de notes et de tous les espaces réservés de date et d'heure enfants
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
            headerFooterManager.setSlideNumberVisibility(true); // rendre cet espace réservé de numéro de diapositive de la diapositive de notes visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rendre cet espace réservé de date-heure de la diapositive de notes visible

        headerFooterManager.setHeaderText("New header text"); // définir le texte de l'espace réservé d'en-tête de la diapositive de notes
        headerFooterManager.setFooterText("New footer text"); // définir le texte de l'espace réservé de pied de page de la diapositive de notes
        headerFooterManager.setDateTimeText("New date and time text"); // définir le texte de l'espace réservé de date-heure de la diapositive de notes
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis‑je ajouter un « en‑tête » aux diapositives normales ?**

Dans PowerPoint, l’« en‑tête » n’existe que pour les notes et les versions imprimables ; sur les diapositives ordinaires, les éléments pris en charge sont le pied de page, la date/heure et le numéro de diapositive. Dans Aspose.Slides, cela correspond aux mêmes limites : en‑tête uniquement pour les Notes/Handout, et sur les diapositives—Footer/DateTime/SlideNumber.

**Que se passe‑t‑il si la mise en page ne contient pas de zone de pied de page—puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes d’API sont conçus pour les cas où l’espace réservé est absent ou masqué.

**Comment faire commencer le numéro de diapositive à une valeur autre que 1 ?**

Définissez le [numéro de première diapositive](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la présentation ; après cela, tous les numéros sont recalculés. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il avec les en‑têtes/pieds de page lors de l’exportation en PDF/images/HTML ?**

Ils sont rendus comme des éléments texte ordinaires de la présentation. Ainsi, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.