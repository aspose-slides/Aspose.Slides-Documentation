---
title: Gestion des balises et des données personnalisées dans les présentations avec JavaScript
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/nodejs-java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- XML personnalisé
- partie XML personnalisée
- métadonnées XML
- ItemId
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour Node.js via Java, y compris l'ajout, la lecture, la mise à jour, l'audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les donnees personnalisees dans les presentations PowerPoint. Les donnees specifique a une presentation peuvent etre stockees sous forme de balises ou de parties XML personnalisees. Les balises sont de simples paires cle-valeur de chaines, tandis que les parties XML personnalisees peuvent stocker des metadonnees structurees et des charges XML specifique a l'application.

Aspose.Slides fournit des API permettant d'ajouter, lire, mettre a jour, auditor et supprimer des parties XML personnalisees au niveau de la presentation, de la diapositive et de la forme. Les parties XML personnalisees sont utiles pour les integrations qui stockent des informations telles que des identifiants de gestion de documents, l'etat du workflow, des metadonnees de conformite, des donnees de liaison de modele ou d'autres donnees d'application structurees a l'interieur d'une presentation.

## **Stockage des donnees dans les fichiers de presentation**

Les fichiers PPTX- les fichiers portant l'extension `.pptx`-sont stockes au format PresentationML, qui fait partie de la specification Office Open XML. Office Open XML definit la structure du package et les relations utilisees pour stocker le contenu de la presentation et les donnees associees.

Une presentation contient plusieurs parties reliees entre elles par des relations. Par exemple, une partie de diapositive contient le contenu d'une seule diapositive et peut avoir des relations explicites avec d'autres parties definies par la norme ISO/IEC 29500.

Les donnees personnalisees peuvent etre stockees sous forme de balises ([TagCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/)) ou de parties XML personnalisees ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpartcollection/)). Les deux sont accessibles via la classe [`CustomData`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Les balises stockent de simples paires cle-valeur sous forme de chaine. Les parties XML personnalisees stockent des donnees XML structurees et peuvent etre associees a une presentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisees**

La methode `getCustomXmlParts()` de [`CustomData`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customdata/) renvoie la collection des parties XML personnalisees associees a un objet de presentation particulier. Par exemple :

- `presentation.getCustomData().getCustomXmlParts()` contient les parties XML personnalisees associees a la presentation elle-meme.
- `slide.getCustomData().getCustomXmlParts()` contient les parties XML personnalisees associees a une diapositive specifique.
- `shape.getCustomData().getCustomXmlParts()` contient les parties XML personnalisees associees a une forme specifique.

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) lorsque vous devez examiner toutes les parties XML personnalisees de la presentation, quel que soit leur lieu dassociation.

### **Ajouter une partie XML personnalisee a une presentation**

Utilisez la methode `add` de [`CustomXmlPartCollection`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpartcollection/) pour ajouter des donnees XML a une collection de parties XML personnalisees. Le XML doit etre valide et non vide.

L'exemple suivant ajoute des metadonnees structurees a la collection de donnees personnalisees au niveau de la presentation :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add attribue automatiquement un identifiant. Définissez un UUID spécifique uniquement si nécessaire.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La methode `add` peut egalement accepter le XML sous forme de tableau d'octets, ce qui est utile lorsque le contenu XML est deja disponible sous forme binaire.

### **Ajouter une partie XML personnalisee a une diapositive ou a une forme**

Les donnees XML personnalisees peuvent etre associees a une diapositive ou a une forme specifique au lieu de l'ensemble de la presentation. Ceci est utile lorsque les metadonnees describent un seul objet, tel qu'une cle de modele, un identifiant d'enregistrement externe ou des informations de liaison.

L'exemple suivant ajoute une partie XML personnalisee a une diapositive et une autre a une forme :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le niveau auquel une partie est ajoute determine la collection `getCustomData().getCustomXmlParts()` de l'objet qui contient la relation vers cette partie. Les donnees au niveau de la presentation sont appropriees pour les metadonnees couvrant tout le document, les donnees au niveau de la diapositive pour les informations appartenant a une diapositive particuliere, et les donnees au niveau de la forme pour les metadonnees liees a une forme individuelle.

### **Lister et auditor toutes les parties XML personnalisees**

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) pour recuperer toutes les parties XML personnalisees d'une presentation. Chaque [`CustomXmlPart`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpart/) expose son identifiant, son contenu XML et les schemas d'espace de noms associes.

L'exemple suivant repertorie toutes les parties XML personnalisees et leurs schemas d'espace de noms :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`CustomXmlPart.getNamespaceSchemas()` renvoie les schemas XML associes a la partie XML personnalisee. Cette information peut etre utile lors de l'audit de presentations contenant du XML produit par des systemes externes.

### **Lire et mettre a jour le contenu XML et l'ItemId**

Utilisez `getXmlAsString()` et `setXmlAsString()` de [`CustomXmlPart`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpart/) pour travailler avec le XML sous forme de chaine UTF-8, ou `getXmlData()` et `setXmlData()` pour travailler avec les octets XML bruts.

La methode `getItemId()` renvoie l'UUID qui identifie la partie XML personnalisee dans le document Office Open XML. Utilisez `setItemId()` lorsqu'une integration nécessite un nouvel identifiant.

L'exemple suivant met a jour le contenu XML et l'identifiant :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lire le XML actuel en tant que texte.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Mettre à jour le XML sous forme de chaîne UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData fournit le même contenu XML sous forme d'octets bruts.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Remplacer l'identifiant lorsque requis par l'intégration.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lors de l'appel a `setXmlAsString` ou `setXmlData`, fournissez un XML valide et non vide. Utilisez l'une ou l'autre representation selon que l'application travaille principalement avec des chaines ou des donnees binaires.

### **Supprimer une partie XML personnalisee**

Aspose.Slides offre plusieurs manières de supprimer des donnees XML personnalisees :

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpart/) supprime la partie XML personnalisee de la presentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpartcollection/) supprime une partie specifique d'une collection de parties XML personnalisees.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpartcollection/) supprime la partie a l'indice specifie de la collection.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/customxmlpartcollection/) supprime toutes les parties d'une collection specifique.

L'exemple suivant supprime une partie XML personnalisee au niveau de la presentation par reference :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous avez deja un `CustomXmlPart` et souhaitez supprimer cette partie de la presentation plutot que d'adresser une collection particuliere, appelez `customXmlPart.remove()`.

Vous pouvez egalement supprimer un element par index :

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Effacer toutes les parties XML personnalisees d'une collection**

Utilisez `clear` lorsque toutes les parties XML personnalisees associees a un objet de presentation particulier doivent etre supprimees.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` n'affecte que la collection selectionnee. Par exemple, effacer la collection d'une diapositive ne vide pas les collections au niveau de la presentation ou de la forme.

Pour supprimer chaque partie XML personnalisee de la presentation, parcourez `getAllCustomXmlParts()` et supprimez chaque partie :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gerer les parties XML personnalisees liees ou partagees**

Dans une presentation Office Open XML, la meme partie XML personnalisee peut etre referencee a partir de plusieurs objets de presentation. Par exemple, un fichier existant peut contenir des relations de plusieurs diapositives ou formes vers la meme partie XML personnalisee sous-jacente.

Une partie partagee doit etre traitee comme un seul objet de donnees avec plusieurs references :

- La mettre a jour avec `setXmlAsString`, `setXmlData` ou `setItemId` modifie la partie XML personnalisee sous-jacente, de sorte que la modification s'applique partout ou cette partie est referencee.
- `getItemId()` peut etre utilise pour identifier la meme partie XML personnalisee lors de l'audit des collections au niveau des objets.
- Supprimer une partie d'une collection `getCustomXmlParts()` specifique la retire de cette collection. Utilisez `CustomXmlPart.remove()` lorsque la partie elle-meme doit etre supprimee de la presentation.
- Avant de supprimer ou de replacer une partie partagee, inspectez les collections au niveau des objets pour determiner si d'autres diapositives ou formes y font encore reference.

Les surcharges de `add` creent une nouvelle partie XML personnalisee a partir du contenu XML; elles n'acceptent pas un `CustomXmlPart` existant. Ainsi, les relations partagees sont le plus souvent rencontrees lors du chargement de presentations qui les contiennent deja.

L'exemple suivant auditor les collections au niveau de la presentation, de la diapositive et de la forme par `ItemId` et indique les parties referencees depuis plusieurs emplacements :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ce type d'audit est utile avant de modifier ou de supprimer des donnees XML personnalisees dans des presentations creees par des systemes externes, car la meme partie de metadonnees peut participer a plusieurs relations.

## **Obtenir les valeurs des balises**

Dans les slides, une balise correspond a la methode `DocumentProperties.getKeywords()`. Ce code d'exemple montre comment obtenir la valeur d'une balise avec Aspose.Slides pour Node.js via Java pour [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Ajouter des balises aux presentations**

Aspose.Slides vous permet d'ajouter des balises aux presentations. Une balise se compose généralement de deux elements :

- le nom d'une propriete personnalisee, par exemple, `MyTag`;
- la valeur de la propriete personnalisee, par exemple, `My Tag Value`.

Si vous devez classifier les presentaciones en fonction d'une regle ou d'une propriete specifique, vous pouvez ajouter des balises a cet effet. Par exemple, si vous souhaitez categoriser les presentations provenant de pays d'Amerique du Nord, vous pouvez creer une balise "North American" et assigner le pays correspondant comme valeur.

Ce code d'exemple montre comment ajouter une balise a une [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) en utilisant Aspose.Slides pour Node.js via Java :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Les balises peuvent egalement etre definites pour une [Slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/) :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) individuelle :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limites**

Les balises ajoutees via la collection `getCustomData().getTags()` ne sont stockees que dans le fichier PowerPoint. Elles ne sont **pas** transferees vers la structure de balises du PDF lors de l'exportation de la presentation au format PDF. En consequence, un identifiant personalise assigne en tant que balise ne peut pas etre recupere a partir du PDF balise.

**Solution de contournement**: Vous pouvez stocker un identifiant personalise dans le **Texte alternatif** de l'objet (par exemple, `shape.setAlternativeText("MyId")`). Apres l'exportation vers PDF, le texte alternatif peut apparaitre dans la structure de balises du PDF.

## **FAQ**

**Puis-je supprimer toutes les balises d'une presentation, d'une diapositive ou d'une forme en une seule operation ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) prend en charge une operation [clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) qui supprime toutes les paires cle-valeur d'un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez `remove(name)` sur la [collection de balises](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/) pour supprimer la balise par sa cle.

**Comment recuperer la liste complete des noms de balises pour l'analyse ou le filtrage ?**

Utilisez `getNamesOfTags()` sur la [collection de balises](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/tagcollection/); elle renvoie un tableau contenant tous les noms de balises.

**Comment trouver toutes les parties XML personnalisees, quel que soit leur emplacement ?**

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) pour recuperer toutes les parties XML personnalisees de la presentation.

**Dois-je utiliser `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` pour mettre a jour une partie XML personnalisee ?**

Utilisez `getXmlAsString` et `setXmlAsString` lorsque l'application travaille avec du texte XML UTF-8. Utilisez `getXmlData` et `setXmlData` lorsque le XML est deja disponible sous forme de tableau d'octets ou lorsque le traitement en mode binaire est plus pratique. Les deux representations font reference au meme contenu XML de la partie XML personnalisee.