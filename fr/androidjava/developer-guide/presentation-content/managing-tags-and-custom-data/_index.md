---
title: Gestion des balises et des données personnalisées
type: docs
weight: 300
url: /fr/androidjava/managing-tags-and-custom-data

---

## Stockage des données dans les fichiers de présentation

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Avec une *diapositive* étant l'un des éléments dans les présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—comme des Balises définies par l'utilisateur—définies par l'ISO/IEC 29500.

Les données personnalisées (spécifiques à une présentation) ou à l'utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé-valeur de chaînes.

{{% /alert %}} 

## Obtention des valeurs pour les balises

Dans les diapositives, une balise correspond aux méthodes [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) et [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Ce code d'exemple vous montre comment obtenir la valeur d'une balise avec Aspose.Slides pour Android via Java pour [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) :

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## Ajout de balises aux présentations

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise consiste généralement en deux éléments :

- le nom d'une propriété personnalisée - `MyTag`
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous avez besoin de classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pouvez bénéficier de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez catégoriser ou regrouper toutes les présentations des pays d'Amérique du Nord, vous pouvez créer une balise nord-américaine et ensuite assigner les pays concernés (les États-Unis, le Mexique et le Canada) comme valeurs.

Ce code d'exemple vous montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) utilisant Aspose.Slides pour Android via Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ou pour une [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) individuelle :

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