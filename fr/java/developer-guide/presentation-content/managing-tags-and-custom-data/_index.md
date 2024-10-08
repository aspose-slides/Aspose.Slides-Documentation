---
title: Gestion des tags et des données personnalisées
type: docs
weight: 300
url: /fr/java/managing-tags-and-custom-data

---

## Stockage des données dans les fichiers de présentation

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Avec une *diapositive* étant l'un des éléments des présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec plusieurs parties—comme les tags définis par l'utilisateur—définies par l'ISO/IEC 29500.

Des données personnalisées (spécifiques à une présentation) ou utilisateurs peuvent exister sous forme de tags ([ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Les tags sont essentiellement des paires clé-valeur de type chaîne.

{{% /alert %}} 

## Obtention des valeurs pour les tags

Dans les diapositives, un tag correspond aux méthodes [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) et [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Ce code d'exemple vous montre comment obtenir la valeur d'un tag avec Aspose.Slides pour Java pour [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Ajout de tags aux présentations

Aspose.Slides vous permet d'ajouter des tags aux présentations. Un tag consiste généralement en deux éléments :

- le nom d'une propriété personnalisée - `MyTag`
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous avez besoin de classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pouvez bénéficier de l'ajout de tags à ces présentations. Par exemple, si vous souhaitez catégoriser ou regrouper toutes les présentations des pays nord-américains, vous pouvez créer un tag nord-américain et ensuite attribuer les pays pertinents (les États-Unis, le Mexique et le Canada) comme valeurs.

Ce code d'exemple vous montre comment ajouter un tag à une [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) en utilisant Aspose.Slides pour Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Les tags peuvent également être définis pour une [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ou pour tout [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) individuel :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("Mon texte");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```