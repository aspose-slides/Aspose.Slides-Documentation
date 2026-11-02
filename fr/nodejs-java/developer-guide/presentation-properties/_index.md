---
title: Gérer les propriétés de la présentation en JavaScript
linktitle: Propriétés de la présentation
type: docs
weight: 70
url: /fr/nodejs-java/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de la présentation
- Propriétés du document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Gérer les propriétés
- Modifier les propriétés
- Métadonnées du document
- Modifier les métadonnées
- Langue de vérification
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Node.js via Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides for Node.js via Java prend en charge les propriétés de document **intégrées** et **personnalisées**. Utilisez ces propriétés pour lire et mettre à jour les métadonnées de la présentation, telles que l’auteur, le titre et les valeurs définies par l’utilisateur.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Une instance de cette classe est renvoyée par [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Aspose.Slides gère les métadonnées d’application et du producteur lors de l’enregistrement des présentations ; ces champs identifient le logiciel qui a créé la sortie.
{{% /alert %}}

## **Gérer les propriétés de la présentation**

Les propriétés de document stockent des informations descriptives à côté du contenu de la présentation. Elles se répartissent en deux catégories :

- **Propriétés intégrées** contiennent des métadonnées standard, telles que le titre, l’auteur et les statistiques du document.
- **Propriétés personnalisées** stockent des paires nom/valeur définies par l’utilisateur.

Aspose.Slides for Node.js via Java donne accès aux deux catégories. Dans PowerPoint, sélectionnez **File → Info → Properties → Advanced Properties** pour examiner les métadonnées du document. La boîte de dialogue regroupe les informations en onglets tels que **Summary**, **Statistics**, **Contents** et **Custom**. Utilisez l’onglet **Custom** pour gérer les propriétés définies par l’utilisateur.

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège généralement à la fois le contenu de la présentation et les propriétés du document. Lorsqu’une présentation est chiffrée après avoir appelé [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) avec `false`, ses propriétés de document restent publiques. Une application peut alors appeler [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) avec `true` et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) contrôle ce qu’Aspose.Slides charge ; il ne déchiffre rien. Si les propriétés ont été incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple nécessite une présentation chiffrée dont les propriétés de document ont été laissées publiques. Il vérifie le mode de chargement via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) puis lit les propriétés intégrées via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) :

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, les maîtres, les dispositions, les formes, les médias et les autres objets de la présentation ne sont pas disponibles. Les applications doivent toujours vérifier [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) avant d’exécuter une opération qui nécessite le modèle complet des objets de la présentation.

{{% alert color="warning" title="Warning" %}}
Les métadonnées publiques peuvent révéler les noms d’auteur, les titres, les sujets, les mots‑clés, les informations d’entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont une exigence spécifique d’y accéder sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée après avoir appelé [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) avec `true` est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées à partir de cet objet contenant uniquement les métadonnées, car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple nécessite une présentation PPTX chiffrée avec des propriétés de document publiques et un mot de passe d’ouverture connu. Il ouvre la présentation complète avec [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), met à jour les propriétés intégrées publiques et enregistre le résultat. Il utilise ensuite [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) pour vérifier que le chiffrement est préservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

La classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) expose les métadonnées intégrées via des méthodes getter, notamment [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) et [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Cet exemple ouvre une présentation existante et affiche ses métadonnées stockées dans la console. Les valeurs dépendent de la présentation d’entrée ; certains champs peuvent être vides.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modifier les propriétés intégrées**

Pour mettre à jour les métadonnées intégrées, utilisez les méthodes setter sur l’objet renvoyé par [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Cet exemple ouvre une présentation existante, appelle [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) et [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), puis enregistre la présentation mise à jour avec [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Le PPTX enregistré contient les nouvelles métadonnées.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gérer la base des hyperliens**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) renvoie la base au niveau du document pour les hyperliens relatifs. Utilisez [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) pour la modifier ou la supprimer. Cela est utile lors du déplacement d’une présentation et de ses fichiers liés vers un autre emplacement. C’est distinct de l’URL externe d’un hyperlien individuel via [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) : changer la base ne réécrit pas les adresses des liens stockés ni ne modifie les destinations absolues.

L’exemple nécessite une présentation contenant à la fois un lien relatif, tel que `target.html`, et un lien absolu, tel que `https://example.org/absolute.html`. Il lit la base existante, attribue une nouvelle adresse de base, puis enregistre et rouvre la présentation pour vérifier la valeur. Il supprime ensuite la base avec une chaîne vide et vérifie la valeur vide dans un fichier enregistré séparé. Remplacez l’adresse de base de l’exemple par l’emplacement de vos fichiers liés.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Les deux messages de vérification doivent afficher `true`. La suppression de la base laisse les adresses des hyperliens individuels intactes.

Un lien relatif vers `target.pptx` ouvrait `old/target.pptx` lorsque la base pointait vers le dossier `old`. Après avoir modifié la base vers le dossier `new`, enregistré et rouvert la présentation, le même lien ouvrait `new/target.pptx`. Un lien absolu a continué d’ouvrir le même fichier. Testez vos liens relatifs dans PowerPoint avant et après avoir déplacé la présentation ou changé sa base.

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées stockent des métadonnées qui n’ont aucun champ intégré correspondant. La méthode [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) vous permet d’attribuer une valeur par nom de propriété. Cet exemple crée une présentation, ajoute deux valeurs texte et une valeur de version entière, et enregistre la présentation avec [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Attribuer une valeur à un nom existant remplace la valeur de cette propriété.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder et modifier les propriétés personnalisées**

Cet exemple ouvre une présentation contenant des propriétés personnalisées et utilise [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) pour les parcourir. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) accepte un indice commençant à zéro et renvoie le nom utilisé par [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). L’exemple affiche chaque nom et valeur d’origine, remplace chaque valeur par une chaîne numérotée quel que soit son type d’origine, et enregistre les modifications. S’il n’y a aucune propriété personnalisée, la boucle ne fait aucun changement.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Exemple en direct**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées entièrement. Cependant, vous pouvez soit modifier leurs valeurs, soit les définir à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera remplacée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) puis [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/nodejs-java/examine-presentation/) pour un exemple complet de rapport et les limitations propres aux formats.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée après avoir appelé [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) avec `false`, et elle doit être chargée après avoir appelé [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) avec `true`.

**Puis‑je mettre à jour un fichier PPTX chiffré en mode uniquement‑propriétés‑de‑document ?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, ainsi la mise à jour d’un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.