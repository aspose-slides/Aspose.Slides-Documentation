---
title: Gérer les balises et les données personnalisées dans les présentations à l’aide de JavaScript
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/nodejs-java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- valeurs de paires
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides for Node.js, avec des exemples pour les présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Il décrit brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données spécifiques à la présentation peuvent exister sous forme de balises et de parties XML personnalisées, et définit les balises comme des paires clé‑valeur de chaînes.

Il montre également comment lire les valeurs des balises et comment ajouter des balises à une présentation, à une diapositive individuelle ou à une forme. De plus, l’article couvre les tâches courantes de gestion des balises telles que la suppression de toutes les balises, la suppression d’une balise par son nom et la récupération de la liste des noms de balises.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — éléments avec l’extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — telles que les Balises définies par l’utilisateur — définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l’utilisateur peuvent exister sous forme de balises ([TagCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TagCollection)) et de parties XML personnalisées ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Les balises sont essentiellement des paires clé‑valeur de chaînes. 
{{% /alert %}} 

## **Obtention des valeurs des balises**

Dans Slides, une balise correspond aux méthodes [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) et [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides for Node.js via Java pour [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) :

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

- le nom d’une propriété personnalisée — `MyTag` 
- la valeur de la propriété personnalisée — `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l’ajout de balises à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations provenant des pays d’Amérique du Nord, vous pouvez créer une balise « North American » puis attribuer les pays concernés (États‑Unis, Mexique et Canada) comme valeurs.

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) à l’aide d’Aspose.Slides for Node.js via Java :

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

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Slide) :

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

Ou pour toute [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AutoShape) individuelle :

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

### **Limites**

Les balises ajoutées via la collection de balises de données personnalisées avec `getCustomData().getTags()` sont stockées uniquement dans le fichier PowerPoint. Elles **ne** sont **pas** transférées vers la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé attribué comme balise ne peut pas être récupéré depuis le PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **texte alternatif** de l’objet (par exemple, `shape.setAlternativeText("MyId")`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) prend en charge l’opération [clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [remove(name)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises à des fins d’analyse ou de filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.