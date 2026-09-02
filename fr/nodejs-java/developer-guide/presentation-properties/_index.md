---
title: Gérer les propriétés de présentation en JavaScript
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/nodejs-java/presentation-properties/
keywords:
- Propriétés PowerPoint
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
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Node.js via Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Ces deux types de propriétés peuvent être facilement accessibles et gérés à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés des documents de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/) . Une instance de cette classe est renvoyée par la méthode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque enregistrement, de sorte qu’une présentation enregistrée indique toujours « Aspose.Slides for Node.js via Java » ainsi que la version de la bibliothèque qui l’a produite. Toute valeur transmise à `setNameOfApplication` est ignorée lors de l’écriture de la présentation.
{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint fournit une fonctionnalité permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux catégories de propriétés de document :

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

Les propriétés **Built-in** contiennent des informations générales sur le document telles que le titre, le nom de l’auteur, les statistiques du document, etc. Les propriétés **Custom** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. Avec Aspose.Slides for Node.js via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme illustré ci‑dessous :

|**Sélection du menu Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné le menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint comme le montre la figure suivante :

|**Boîte de dialogue Propriétés**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de dialogue Propriétés** ci‑dessus, vous pouvez voir de nombreux onglets comme **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

### Utilisation des propriétés de document avec Aspose.Slides for Node.js via Java

Comme indiqué précédemment, Aspose.Slides for Node.js via Java prend en charge deux types de propriétés de document, à savoir les propriétés **Built-in** et **Custom**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés via l’API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java fournit une classe [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **DocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci‑après :

## **Access Built-in Properties**

Ces propriétés, exposées par l’objet [DocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties), comprennent : **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers ?), **PresentationFormat**, **Subject** et **Title**.

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

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les lire. Il suffit d’attribuer une valeur de chaîne à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés intégrées d’un fichier de présentation à l’aide d’Aspose.Slides for Node.js via Java.

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

Cet exemple modifie les propriétés intégrées de la présentation, affichées comme suit :

|**Propriétés de document intégrées après modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Node.js via Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document d’une présentation. L’exemple ci‑dessus montre comment définir les propriétés personnalisées d’une présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obtention des propriétés du document
    var dProps = pres.getDocumentProperties();
    // Ajout de propriétés personnalisées
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Obtention du nom de la propriété à un indice particulier
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

|**Propriétés de document personnalisées ajoutées**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Node.js via Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessus montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

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

Cet exemple modifie les propriétés personnalisées du [PPTX ](https://docs.fileformat.com/presentation/pptx/)présentation. Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}
De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo). La logique du mutateur de la propriété [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) a été modifiée.
{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PresentationInfo). Elles offrent un accès rapide aux propriétés de document et permettent de changer et mettre à jour les propriétés sans charger toute la présentation.

Le scénario typique consiste à charger les propriétés, modifier une valeur et mettre à jour le document :

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
// mettre à jour la présentation avec les nouvelles valeurs
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

Un nouveau modèle peut être créé à partir de zéro, puis utilisé pour mettre à jour plusieurs présentations :

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

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour permettre de définir la langue de vérification orthographique d’un document PowerPoint. La langue de vérification orthographique est celle pour laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code JavaScript montre comment définir la langue de vérification pour un PowerPoint : xxx Pourquoi LanguageId est‑il absent de la classe JavaScript PortionFormat ?

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
    portionFormat.setLanguageId("zh-CN");// définir l'Id d'une langue de vérification
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
    // Ajoute une nouvelle forme rectangulaire avec texte
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

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Cependant, vous pouvez modifier leurs valeurs ou les définir à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) puis [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) pour lire les métadonnées de document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/nodejs-java/examine-presentation/) pour un exemple complet de génération de rapports et les limitations spécifiques aux formats.