---
title: Gestion des tags et des données personnalisées
type: docs
weight: 300
url: /fr/nodejs-java/managing-tags-and-custom-data
---

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — éléments avec l’extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—comme les balises définies par l’utilisateur—définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) et de CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé–valeur de chaîne. 

{{% /alert %}} 

## **Obtention des valeurs des balises**

Dans les diapositives, une balise correspond aux méthodes [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) et [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour Node.js via Java pour [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajout de balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations en fonction d’une règle ou d’une propriété spécifique, vous pouvez tirer parti de l’ajout de balises à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations provenant des pays d’Amérique du Nord, vous pouvez créer une balise America du Nord puis attribuer les pays concernés (États‑Unis, Mexique et Canada) comme valeurs. 

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) en utilisant Aspose.Slides pour Node.js via Java :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Ou tout [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé–valeur en une seule fois.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) sur la [collection de balises](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.