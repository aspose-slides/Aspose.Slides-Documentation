---
title: En-tête et Pied de page de Présentation
type: docs
weight: 140
url: /fr/androidjava/presentation-header-and-footer/
keywords: "En-tête et pied de page PowerPoint en Java"
description: "En-tête et pied de page PowerPoint en Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/androidjava/) fournit un support pour travailler avec le texte des en-têtes et pieds de page des diapositives qui sont en fait maintenus au niveau du modèle de diapositive.

{{% /alert %}} 

[Aspose.Slides pour Android via Java](/slides/fr/androidjava/) fournit la fonctionnalité pour gérer les en-têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux-ci sont en fait gérés au niveau du modèle de présentation.

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

    // Enregistrer la présentation
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

## **Gérer l'en-tête et le pied de page dans les slides de distribution et de notes**
Aspose.Slides pour Android via Java prend en charge l'en-tête et le pied de page dans les diapositives de distribution et de notes. Veuillez suivre les étapes ci-dessous :

- Charger une [Présentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) contenant une vidéo.
- Modifier les paramètres d'en-tête et de pied de page pour le modèle de notes et toutes les diapositives de notes.
- Rendre le modèle de notes et tous les espaces réservés de pied de page visibles.
- Rendre le modèle de notes et tous les espaces réservés de date et d'heure visibles.
- Modifier les paramètres d'en-tête et de pied de page uniquement pour la première diapositive de notes.
- Rendre l'espace réservé d'en-tête de la diapositive de notes visible.
- Définir du texte pour l'espace réservé d'en-tête de la diapositive de notes.
- Définir du texte pour l'espace réservé de date-heure de la diapositive de notes.
- Écrire le fichier de présentation modifié.

Extrait de code fourni dans l'exemple ci-dessous.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Modifier les paramètres d'en-tête et de pied de page pour le modèle de notes et toutes les diapositives de notes
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // rendre le modèle de notes et tous les espaces réservés de pied de page visibles
        headerFooterManager.setFooterAndChildFootersVisibility(true); // rendre le modèle de notes et tous les espaces réservés d'en-tête visibles
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // rendre le modèle de notes et tous les espaces réservés de numéro de diapositive visibles
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // rendre le modèle de notes et tous les espaces réservés de date et d'heure visibles

        headerFooterManager.setHeaderAndChildHeadersText("Texte de l'en-tête"); // définir le texte du modèle de notes et tous les espaces réservés d'en-tête
        headerFooterManager.setFooterAndChildFootersText("Texte du pied de page"); // définir le texte du modèle de notes et tous les espaces réservés de pied de page
        headerFooterManager.setDateTimeAndChildDateTimesText("Texte de date et heure"); // définir le texte du modèle de notes et tous les espaces réservés de date et d'heure
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
            headerFooterManager.setSlideNumberVisibility(true); // rendre cet espace réservé de numéro de diapositive de notes visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // rendre cet espace réservé de date-heure de diapositive de notes visible

        headerFooterManager.setHeaderText("Nouveau texte d'en-tête"); // définir le texte pour l'espace réservé d'en-tête de la diapositive de notes
        headerFooterManager.setFooterText("Nouveau texte de pied de page"); // définir le texte pour l'espace réservé de pied de page de la diapositive de notes
        headerFooterManager.setDateTimeText("Nouveau texte de date et d'heure"); // définir le texte pour l'espace réservé de date-heure de la diapositive de notes
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```