---
title: Gérer les propriétés de présentation en JavaScript
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/nodejs-java/presentation-properties/
keywords:
- propriétés PowerPoint
- propriétés de présentation
- propriétés de document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées du document
- modifier les métadonnées
- langue de vérification
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for Node.js via Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement accessibles et gérées à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/) . Une instance de cette classe est renvoyée par la méthode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque enregistrement, de sorte qu’une présentation enregistrée indique toujours « Aspose.Slides for Node.js via Java » et la version de la bibliothèque qui l’a produite. Toute valeur transmise à `setNameOfApplication` est ignorée lors de l’écriture de la présentation.
{{% /alert %}}

## **Manage Presentation Properties**

Microsoft PowerPoint propose une fonctionnalité permettant d’ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document :

- Propriétés système (intégrées)
- Propriétés définies par l’utilisateur (personnalisées)

Les propriétés **Built-in** contiennent des informations générales sur le document comme le titre, le nom de l’auteur, les statistiques du document, etc. Les propriétés **Custom** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. Avec Aspose.Slides for Node.js via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme indiqué ci‑dessous :

|**Sélection du menu Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Après avoir sélectionné le menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés de document du fichier PowerPoint comme illustré ci‑dessus :

|**Boîte de dialogue Propriétés**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la boîte de dialogue **Properties**, vous pouvez voir de nombreux onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Working with Document Properties Using Aspose.Slides for Node.js via Java**

Comme décrit précédemment, Aspose.Slides for Node.js via Java prend en charge deux types de propriétés de document, à savoir les propriétés **Built-in** et **Custom**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés grâce à l’API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java fournit la classe [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **DocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) pour accéder aux propriétés de document des présentations comme décrit ci‑dessous :

## **Read Public Properties from an Encrypted Presentation**

Un mot de passe d’ouverture protège normalement le contenu de la présentation ainsi que les propriétés de document. Lorsqu’une présentation est chiffrée en passant `false` à [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

L’option « document‑properties‑only » contrôle ce que charge Aspose.Slides ; elle ne décrypte rien. Si les propriétés ont été incluses dans le chiffrement, le chargement sans mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) puis lit les propriétés intégrées via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDocumentProperties) :

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, mises en page, formes, médias et autres objets de présentation ne sont pas disponibles. Les applications doivent toujours vérifier [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) avant d’effectuer une opération nécessitant le modèle complet de la présentation.

{{% alert color="warning" title="Warning" %}}
Les métadonnées publiques peuvent exposer les noms d’auteur, titres, sujets, mots‑clé, informations d’entreprise, commentaires et valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont besoin d’y accéder sans mot de passe.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

Pour un fichier PPTX chiffré, une présentation chargée en mode « document‑properties‑only » est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées provenant de cet objet « metadata‑only » car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/#setPassword), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) pour vérifier que le chiffrement est préservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Si une application n’est pas autorisée à décrypter ou charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX chiffré comme en lecture‑seule.

## **Access Built-in Properties**

Ces propriétés exposées par l’objet [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Dernière impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Est‑il partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation qui représente la présentation
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    var dp = pres.getDocumentProperties();
    // Afficher les propriétés intégrées
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modify Built-in Properties**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les lire. Il suffit d’assigner une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’une présentation à l’aide d’Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    var dp = pres.getDocumentProperties();
    // Définir les propriétés intégrées
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Enregistrer votre présentation dans un fichier
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Cet exemple modifie les propriétés intégrées de la présentation, comme le montre l’image suivante :

|**Propriétés de document intégrées après modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Node.js via Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document d’une présentation. L’exemple ci‑dessous montre comment définir des propriétés personnalisées pour une présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obtention des propriétés de document
    var dProps = pres.getDocumentProperties();
    // Ajout de propriétés personnalisées
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Obtention du nom de propriété à un indice particulier
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Suppression de la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    // Enregistrement de la présentation
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Propriétés de document personnalisées ajoutées**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Node.js via Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la présentation
    var dp = pres.getDocumentProperties();
    // Accéder et modifier les propriétés personnalisées
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et valeurs des propriétés personnalisées
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modifier les valeurs des propriétés personnalisées
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Enregistrer votre présentation dans un fichier
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Cet exemple modifie les propriétés personnalisées du [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation. Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}
De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) et [WriteBindedPresentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo) , la logique du setter de la propriété [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) a été modifiée.
{{% /alert %}}

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo) . Elles offrent un accès rapide aux propriétés de document et permettent de changer et mettre à jour les propriétés sans charger la présentation entière.

Le scénario typique consiste à charger les propriétés, modifier certaines valeurs et mettre à jour le document, comme illustré ci‑dessus :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// lire les informations de la présentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtenir les propriétés actuelles
var props = info.readDocumentProperties();
// définir les nouvelles valeurs des champs Auteur et Titre
props.setAuthor("New Author");
props.setTitle("New Title");
// mettre à jour la présentation avec de nouvelles valeurs
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Il existe une autre façon d’utiliser les propriétés d’une présentation particulière comme modèle pour mettre à jour les propriétés d’autres présentations :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Un nouveau modèle peut être créé à partir de zéro puis utilisé pour mettre à jour plusieurs présentations :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Set Proofing Language**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de vérification orthographique d’un document PowerPoint. La langue de vérification est celle pour laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code JavaScript montre comment définir la langue de vérification pour un PowerPoint : xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Default Language**

Ce code JavaScript montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Ajoute une nouvelle forme rectangle avec du texte
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Vérifie la langue de la première portion
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live Example**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les définir à vide si la propriété le permet.

**What happens if I add a custom property that already exists?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Can I access presentation properties without fully loading the presentation?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) puis [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) pour lire les métadonnées stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Voir [Build a Lightweight Presentation Inventory](/slides/fr/nodejs-java/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.

**Can I read public properties of an encrypted presentation without its opening password?**

Oui. Le chiffrement des propriétés de document doit avoir été désactivé avant que la présentation ne soit chiffrée, et la présentation doit être chargée en mode « document‑properties‑only ».

**Can I update an encrypted PPTX file in document-properties-only mode?**

Non. Les données publiques et chiffrées doivent rester cohérentes, donc la mise à jour d’un fichier PPTX chiffré nécessite le chargement complet de la présentation avec le mot de passe d’ouverture correct.