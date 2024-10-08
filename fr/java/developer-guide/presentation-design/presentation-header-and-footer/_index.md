---
title: En-tête et pied de page de présentation
type: docs
weight: 140
url: /fr/java/presentation-header-and-footer/
keywords: "En-tête et pied de page PowerPoint en Java"
description: "En-tête et pied de page PowerPoint en Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/java/) fournit un support pour travailler avec le texte des en-têtes et des pieds de page des diapositives qui sont en fait maintenus au niveau du maître des diapositives.

{{% /alert %}} 

[Aspose.Slides pour Java](/slides/fr/java/) propose la fonctionnalité de gestion des en-têtes et des pieds de page dans les diapositives de présentation. Ceux-ci sont en fait gérés au niveau du maître de présentation.

## **Gérer l'en-tête et le pied de page dans la présentation**
Les notes de certaines diapositives spécifiques peuvent être supprimées comme montré dans l'exemple ci-dessous :

```java
// Charger la présentation
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Définir le pied de page
    pres.getHeaderFooterManager().setAllFootersText("Mon texte de pied de page");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Accéder et mettre à jour l'en-tête
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Sauvegarder la présentation
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Méthode pour définir le texte de l'en-tête/pied de page
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("Salut nouveau en-tête");
            }
        }
    }
}
```

## **Gérer l'en-tête et le pied de page dans les diapositives de remise et de notes**
Aspose.Slides pour Java prend en charge l'en-tête et le pied de page dans les diapositives de remise et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) contenant une vidéo.
- Changer les paramètres d'en-tête et de pied de page pour le maître de notes et toutes les diapositives de notes.
- Rendre la diapositive de notes maître et tous les espaces réservés de pied de page enfants visibles.
- Rendre la diapositive de notes maître et tous les espaces réservés de date et d'heure enfants visibles.
- Changer les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre l'espace réservé de l'en-tête de la diapositive de notes visible.
- Définir le texte pour l'espace réservé de l'en-tête de la diapositive de notes.
- Définir le texte pour l'espace réservé de date et d'heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Changer les paramètres d'en-tête et de pied de page pour le maître de notes et toutes les diapositives de notes
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rendre la diapositive de notes maître et tous les espaces réservés de pied de page enfants visibles
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rendre la diapositive de notes maître et tous les espaces réservés d'en-tête enfants visibles
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rendre la diapositive de notes maître et tous les espaces réservés de numéro de diapositive enfants visibles
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rendre la diapositive de notes maître et tous les espaces réservés de date et d'heure enfants visibles

        headerFooterManager.setHeaderAndChildHeadersText("Texte d'en-tête"); // définir le texte pour la diapositive de notes maître et tous les espaces réservés d'en-tête enfants
        headerFooterManager.setFooterAndChildFootersText("Texte de pied de page"); // définir le texte pour la diapositive de notes maître et tous les espaces réservés de pied de page enfants
        headerFooterManager.setDateTimeAndChildDateTimesText("Texte de date et d'heure"); // définir le texte pour la diapositive de notes maître et tous les espaces réservés de date et d'heure enfants
    }

    // Changer les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // rendre cet espace réservé d'en-tête de diapositive de notes visible

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // rendre cet espace réservé de pied de page de diapositive de notes visible

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // rendre cet espace réservé de numéro de diapositive de notes visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rendre cet espace réservé de date et d'heure de diapositive de notes visible

        headerFooterManager.setHeaderText("Nouveau texte d'en-tête"); // définir le texte pour l'espace réservé d'en-tête de diapositive de notes
        headerFooterManager.setFooterText("Nouveau texte de pied de page"); // définir le texte pour l'espace réservé de pied de page de diapositive de notes
        headerFooterManager.setDateTimeText("Nouveau texte de date et d'heure"); // définir le texte pour l'espace réservé de date et d'heure de diapositive de notes
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```