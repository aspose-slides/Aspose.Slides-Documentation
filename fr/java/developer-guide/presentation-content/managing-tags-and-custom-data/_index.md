---
title: Gérer les tags et les données personnalisées dans les présentations avec Java
linktitle: Tags et données personnalisées
type: docs
weight: 300
url: /fr/java/managing-tags-and-custom-data/
keywords:
- propriétés de document
- tag
- données personnalisées
- ajouter un tag
- valeurs de paires
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter, lire, mettre à jour et supprimer les tags et les données personnalisées dans Aspose.Slides pour Java, avec des exemples pour les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les tags et les données personnalisées dans les présentations PowerPoint. Il résume brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données spécifiques à une présentation peuvent exister sous forme de tags et de parties XML personnalisées, et décrit les tags comme des paires clé‑valeur de chaîne.

Il montre également comment lire les valeurs des tags et comment ajouter des tags à une présentation, une diapositive individuelle ou une forme. De plus, l’article couvre les tâches courantes de gestion des tags telles que la suppression de tous les tags, la suppression d’un tag par son nom et la récupération de la liste des noms de tags.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Avec une *diapositive* étant l'un des éléments d'une présentation, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—comme les User Defined Tags—définies par ISO/IEC 29500.

Les données personnalisées (spécifiques à une présentation) ou de l'utilisateur peuvent exister sous forme de tags ([ITagCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITagCollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Les tags sont essentiellement des paires clé‑valeur de chaîne. 
{{% /alert %}} 

## **Obtenir les valeurs des tags**

Dans les diapositives, un tag correspond aux méthodes [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IDocumentProperties#getKeywords--) et [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Ce code d'exemple montre comment obtenir la valeur d'un tag avec Aspose.Slides pour Java pour [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) :

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des tags aux présentations**

Aspose.Slides vous permet d’ajouter des tags aux présentations. Un tag se compose généralement de deux éléments :

- le nom d'une propriété personnalisée - `MyTag`
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l'ajout de tags à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations des pays d'Amérique du Nord, vous pouvez créer un tag « North American » puis attribuer les pays pertinents (les États-Unis, le Mexique et le Canada) comme valeurs.

Ce code d'exemple montre comment ajouter un tag à une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) en utilisant Aspose.Slides pour Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Les tags peuvent également être définis pour [Slide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide) :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ou toute [Shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) individuelle :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Limites**

Les tags ajoutés via la collection de tags de données personnalisées avec `getCustomData().getTags()` sont stockés uniquement dans le fichier PowerPoint. Ils ne sont **pas** transférés vers la structure de tags PDF lorsque la présentation est exportée au format PDF. Par conséquent, un identifiant personnalisé assigné en tant que tag ne peut pas être récupéré à partir du PDF balisé.

**Solution de contournement** : Vous pouvez stocker un identifiant personnalisé dans le **Alt Text** de l'objet (par exemple, `shape.setAlternativeText("MyId")`). Après l'exportation au PDF, le Alt Text peut apparaître dans la structure de tags du PDF.

## **FAQ**

**Puis-je supprimer tous les tags d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#clear--) qui supprime toutes les paires clé‑valeur d'un seul coup.

**Comment supprimer un seul tag par son nom sans parcourir toute la collection ?**

Utilisez l’opération [Remove(name)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) sur la [tag collection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) pour supprimer le tag par sa clé.

**Comment récupérer la liste complète des noms de tags à des fins d’analyse ou de filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#getNamesOfTags--) sur la [tag collection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de tags.