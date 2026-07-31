---
title: API publique et changements incompatibles avec les versions antérieures dans Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides for Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., les nouvelles restrictions et les autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introduites avec l’API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La signature du constructeur com.aspose.slides.DataLabel a été modifiée**
La signature du constructeur a été modifiée de DataLabel(com.aspose.slides.IChartSeries) à DataLabel(com.aspose.slides.IChartDataPoint).
#### **Les membres com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) ont été marqués comme obsolètes ; des substitutions ont été introduites à la place**
Les méthodes IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) ont été marquées comme obsolètes. Les méthodes IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ont été introduites à la place.
#### **La méthode com.aspose.slides.INotesSlideManager.removeNotesSlide() a été ajoutée**
La méthode com.aspose.slides.INotesSlideManager.RemoveNotesSlide() a été ajoutée pour supprimer la diapositive de notes d’une diapositive.
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
La méthode com.aspose.slides.IDocumentProperties.getAppVersion() a été ajoutée afin d’obtenir la propriété de document intégrée, qui représente les numéros de version internes utilisés par Microsoft PowerPoint.
#### **La méthode remove() a été ajoutée à com.aspose.slides.IComment**
La méthode com.aspose.slides.IComment.remove() a été ajoutée pour supprimer un commentaire de la collection.
#### **La méthode remove() a été ajoutée à com.aspose.slides.ICommentAuthor**
La méthode ICommentAuthor.Remove a été ajoutée pour supprimer l’auteur des commentaires de la collection.
#### **Les méthodes clearCustomProperties() et clearBuiltInProperties() ont été ajoutées à com.aspose.slides.IDocumentProperties**
La méthode com.aspose.slides.IDocumentProperties.clearCustomProperties() a été ajoutée pour supprimer toutes les propriétés de document personnalisées.
La méthode com.aspose.slides.IDocumentProperties.clearBuiltInProperties() a été ajoutée pour supprimer et réinitialiser les valeurs par défaut de toutes les propriétés de document intégrées (Company, Subject, Author, etc.).
#### **Les méthodes getBlackWhiteMode() et setBlackWhiteMode(byte) ont été ajoutées à com.aspose.slides.IShape**
Les méthodes getBlackWhiteMode() et setBlackWhiteMode(byte) ont été ajoutées à com.aspose.slides.IShape.
Ces méthodes spécifient comment une forme sera rendue en mode d’affichage noir et blanc. Les valeurs possibles sont définies dans la classe com.aspose.slides.BlackWhiteMode.

|**Valeur** |**Signification** |
| :- | :- |
|Color |Retour avec coloration normale |
|Automatic |Retour avec coloration automatique |
|Gray |Retour avec coloration grise |
|LightGray |Retour avec coloration gris clair |
|InverseGray |Retour avec coloration gris inverse |
|GrayWhite |Retour avec coloration gris et blanc |
|BlackGray |Retour avec coloration noir et gris |
|BlackWhite |Retour avec coloration noir et blanc |
|Black |Retour uniquement avec coloration noire |
|White |Retour avec coloration blanche |
|Hidden |L’objet n’est pas rendu |
#### **Les méthodes removeAt(int), remove(ICommentAuthor) et clear() ont été ajoutées à com.aspose.slides.ICommentAuthorCollection**
La méthode ICommentAuthorCollection.removeAt(int) a été ajoutée pour supprimer l’auteur à l’index spécifié. La méthode ICommentAuthorCollection.remove(ICommentAuthor) a été ajoutée pour supprimer l’auteur spécifié de la collection. La méthode ICommentAuthorCollection.clear() a été ajoutée pour supprimer tous les éléments de la collection.