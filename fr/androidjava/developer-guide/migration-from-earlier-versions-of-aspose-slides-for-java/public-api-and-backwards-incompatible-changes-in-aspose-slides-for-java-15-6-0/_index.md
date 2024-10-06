---
title: API public et modifications incompatibles avec les versions précédentes dans Aspose.Slides pour Java 15.6.0
type: docs
weight: 140
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) de classes, méthodes, propriétés, etc., toutes les nouvelles restrictions et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introduits avec l'API Aspose.Slides pour Java 15.6.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La signature du constructeur com.aspose.slides.DataLabel a été modifiée**
La signature du constructeur a été modifiée de DataLabel(com.aspose.slides.IChartSeries) à DataLabel(com.aspose.slides.IChartDataPoint).
#### **Les membres com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) ont été marqués comme obsolètes ; des substitutions ont été introduites à la place**
Les méthodes IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) ont été marquées comme obsolètes. Les méthodes IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name) ont été introduites à la place.
#### **La méthode com.aspose.slides.INotesSlideManager.removeNotesSlide() a été ajoutée**
La méthode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() a été ajoutée pour supprimer la diapositive de notes d'une diapositive.
#### **La méthode com.aspose.slides.ISlide.getNotesSlideManager() a été ajoutée. Les méthodes ISlide.getNotesSlide() et ISlide.addNotesSlide() ont été marquées comme obsolètes**
Les méthodes ISlide.getNotesSlide() et ISlide.addNotesSlide() ont été marquées comme obsolètes. Utilisez la nouvelle méthode ISlide.getNotesSlideManager() à la place.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - obsolète

// notes = slide.getNotesSlide(); - obsolète

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **La méthode getAppVersion() a été ajoutée à com.aspose.slides.IDocumentProperties**
La méthode com.aspose.slides.IDocumentProperties.getAppVersion() a été ajoutée pour obtenir la propriété de document intégrée, qui représente les numéros de version internes utilisés par Microsoft PowerPoint.
#### **La méthode remove() a été ajoutée à com.aspose.slides.IComment**
La méthode com.aspose.slides.IComment.remove() a été ajoutée pour supprimer un commentaire de la collection.
#### **La méthode remove() a été ajoutée à com.aspose.slides.ICommentAuthor**
La méthode ICommentAuthor.Remove a été ajoutée pour supprimer l'auteur des commentaires de la collection.
#### **Les méthodes clearCustomProperties() et clearBuiltInProperties() ont été ajoutées à com.aspose.slides.IDocumentProperties**
La méthode com.aspose.slides.IDocumentProperties.clearCustomProperties() a été ajoutée pour supprimer toutes les propriétés de document personnalisées.
La méthode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() a été ajoutée pour supprimer et définir les valeurs par défaut pour toutes les propriétés de document intégrées (Société, Sujet, Auteur, etc.).
#### **Les méthodes getBlackWhiteMode(), setBlackWhiteMode(byte) ont été ajoutées à com.aspose.slides.IShape**
Les méthodes getBlackWhiteMode(), setBlackWhiteMode(byte) ont été ajoutées à com.aspose.slides.IShape.
Les méthodes spécifient comment une forme sera rendue en mode d'affichage noir et blanc. Les valeurs possibles sont spécifiées dans la classe com.aspose.slides.BlackWhiteMode.

|**Valeur** |**Signification** |
| :- | :- |
|Couleur |Retour avec coloration normale |
|Automatique |Retour avec coloration automatique |
|Gris |Retour avec coloration grise |
|Gris clair |Retour avec coloration gris clair |
|Gris inverse |Retour avec coloration grise inverse |
|Gris et blanc |Retour avec coloration grise et blanche |
|Noir et gris |Retour avec coloration noire et grise |
|Noir et blanc |Retour avec coloration noire et blanche |
|Noir |Retour uniquement avec coloration noire |
|Blanc |Retour avec coloration blanche |
|Caché |L'objet n'est pas rendu |
#### **Les méthodes removeAt(int), remove(ICommentAuthor) et clear() ont été ajoutées à com.aspose.slides.ICommentAuthorCollection**
La méthode ICommentAuthorCollection.removeAt(int) a été ajoutée pour supprimer l'auteur par l'index spécifié. La méthode ICommentAuthorCollection.remove(ICommentAuthor) a été ajoutée pour supprimer l'auteur spécifié de la collection. La méthode ICommentAuthorCollection.clear() a été ajoutée pour supprimer tous les éléments de la collection.