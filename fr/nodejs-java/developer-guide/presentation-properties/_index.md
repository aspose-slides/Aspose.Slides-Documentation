---
title: Propriétés de présentation
type: docs
weight: 70
url: /fr/nodejs-java/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
- Propriétés du document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Modifier les propriétés
- Métadonnées du document
- Modifier les métadonnées
- PowerPoint
- Présentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Gérer les propriétés de présentation PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint offre une fonctionnalité permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés système (intégrées)
- Propriétés définies par l’utilisateur (personnalisées)

**Intégrées** les propriétés contiennent des informations générales sur le document telles que le titre du document, le nom de l’auteur, les statistiques du document, etc. **Personnalisées** les propriétés sont celles définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. En utilisant Aspose.Slides for Node.js via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

{{% /alert %}} 

## **Propriétés de document dans PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme indiqué ci‑dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for Node.js via Java x.x.x seront affichés dans ces champs.

{{% /alert %}} 

|**Sélection de l’élément de menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Après avoir sélectionné l’élément de menu **Advanced Properties**, une boîte de dialogue apparaît vous permettant de gérer les propriétés de document du fichier PowerPoint comme le montre la figure ci‑dessous :

|**Boîte de dialogue Propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Dans la **Boîte de dialogue Propriétés** ci‑dessus, vous pouvez voir qu’il existe plusieurs onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d’informations relatives aux fichiers PowerPoint. L’onglet **Custom** sert à gérer les propriétés personnalisées des fichiers PowerPoint.

### Travail avec les propriétés de document en utilisant Aspose.Slides for Node.js via Java

Comme indiqué précédemment, Aspose.Slides for Node.js via Java prend en charge deux types de propriétés de document, les propriétés **Intégrées** et les propriétés **Personnalisées**. Les développeurs peuvent donc accéder aux deux types de propriétés via l’API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java fournit la classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **DocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci‑dessous :

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (Est partagée entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.
```javascript
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


## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées d’un fichier de présentation est aussi simple que de les lire. Vous pouvez simplement affecter une chaîne de caractères à n’importe quelle propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’un fichier de présentation à l’aide d’Aspose.Slides for Node.js via Java.
```javascript
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


Cet exemple modifie les propriétés intégrées de la présentation, comme le montre la capture suivante :

|**Propriétés de document intégrées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides for Node.js via Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document d’une présentation. L’exemple ci‑dess dessous montre comment définir les propriétés personnalisées d’une présentation.
```javascript
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


|**Propriétés de document personnalisées ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for Node.js via Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées d’une présentation.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la présentation
    var dp = pres.getDocumentProperties();
    // Accéder et modifier les propriétés personnalisées
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et les valeurs des propriétés personnalisées
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


Cet exemple modifie les propriétés personnalisées de la [PPTX ](https://docs.fileformat.com/presentation/pptx/)présentation. Les figures suivantes montrent les propriétés personnalisées de la présentation avant et après modification :

|**Propriétés personnalisées avant modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de document avancées**

{{% alert color="primary" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo). La logique du mutateur de la propriété [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo). Elles offrent un accès rapide aux propriétés de document et permettent de les modifier sans charger toute la présentation.

Le scénario typique — charger les propriétés, changer une valeur et mettre à jour le document — peut être implémenté de la manière suivante :
```javascript
// Lire les informations de la présentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// Obtenir les propriétés actuelles
var props = info.readDocumentProperties();
// Définir les nouvelles valeurs des champs Auteur et Titre
props.setAuthor("New Author");
props.setTitle("New Title");
// Mettre à jour la présentation avec de nouvelles valeurs
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Il existe une autre façon d’utiliser les propriétés d’une présentation particulière comme modèle pour mettre à jour les propriétés d’autres présentations :
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Un nouveau modèle peut être créé à partir de zéro, puis utilisé pour mettre à jour plusieurs présentations :
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Définir la langue de relecture**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) afin de vous permettre de définir la langue de relecture pour un document PowerPoint. La langue de relecture est la langue pour laquelle l’orthographe et la grammaire du PowerPoint sont vérifiées.

Ce code JavaScript montre comment définir la langue de relecture pour un PowerPoint : xxx Pourquoi LanguageId est‑il absent de la classe JavaScript PortionFormat ?
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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


## **Définir la langue par défaut**

Ce code JavaScript montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :
```javascript
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


## **Exemple en direct**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées entièrement. Vous pouvez toutefois modifier leurs valeurs ou les vider si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de la supprimer ou de la vérifier au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui, vous pouvez accéder aux propriétés de la présentation sans la charger complètement en utilisant la méthode `getPresentationInfo` de la classe [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/). Ensuite, utilisez la méthode `readDocumentProperties` fournie par la classe [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) pour lire les propriétés de manière efficace, ce qui économise de la mémoire et améliore les performances.