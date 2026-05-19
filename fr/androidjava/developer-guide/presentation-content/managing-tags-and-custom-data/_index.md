---
title: Gérer les balises et les données personnalisées dans les présentations sur Android
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/androidjava/managing-tags-and-custom-data
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- valeurs de paires
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour Android, avec des exemples Java pour les présentations PowerPoint et OpenDocument."
---
## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — éléments avec l’extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec une *diapositive* étant l'un des éléments des présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — telles que les balises définies par l'utilisateur — définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ITagCollection)) et CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé‑valeur de type chaîne. 

{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapos, une balise correspond aux méthodes [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) et [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Ce code d'exemple montre comment obtenir la valeur d'une balise avec Aspose.Slides pour Android via Java pour [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) :

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d'une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez regrouper toutes les présentations des pays d'Amérique du Nord, vous pouvez créer une balise « North American » puis attribuer les pays concernés (États‑Unis, Mexique et Canada) comme valeurs. 

Ce code d'exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) en utilisant Aspose.Slides pour Android via Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlide) :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ou tout [Shape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IAutoShape) individuel :

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

### **Limitations**

Les balises ajoutées via la collection de balises de données personnalisées avec `getCustomData().getTags()` ne sont stockées que dans le fichier PowerPoint. Elles ne sont **pas** transférées à la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé assigné comme balise ne peut pas être récupéré depuis le PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l'objet (par ex., `shape.setAlternativeText("MyId")`). Après l'exportation en PDF, le Texte alternatif peut apparaître dans la structure de balises PDF.

## **FAQ**

**Puis-je supprimer toutes les balises d'une présentation, d'une diapositive ou d'une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/#clear--) qui supprime toutes les paires clé‑valeur en une fois.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l'opération [remove(name)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) sur la [collection de balises](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l'analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) sur la [collection de balises](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tagcollection/) ; elle renvoie un tableau de tous les noms de balises.