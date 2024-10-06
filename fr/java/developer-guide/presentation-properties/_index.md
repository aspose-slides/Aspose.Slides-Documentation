---
title: Propriétés de Présentation
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint offre une fonctionnalité permettant d'ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés Définies par le Système (Intégrées)
- Propriétés Définies par l’Utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document comme le titre du document, le nom de l’auteur, des statistiques sur le document, etc. Les propriétés **Personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l'utilisateur. En utilisant Aspose.Slides pour Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

{{% /alert %}} 

## **Propriétés de Document dans PowerPoint**
Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office et de sélectionner l'élément du menu **Préparer | Propriétés | Propriétés Avancées** de Microsoft PowerPoint 2007 comme montré ci-dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour Java x.x.x seront affichés dans ces champs.

{{% /alert %}} 

|**Sélection de l'élément de menu Propriétés Avancées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l'élément de menu **Propriétés Avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint comme montré ci-dessous dans la figure :

|**Boîte de Dialogue des Propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de Dialogue des Propriétés** ci-dessus, vous pouvez voir qu'il existe de nombreux onglets comme **Général**, **Résumé**, **Statistiques**, **Contenus** et **Personnalisé**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Travailler avec les Propriétés de Document en Utilisant Aspose.Slides pour Java**

Comme nous l'avons décrit précédemment, Aspose.Slides pour Java prend en charge deux types de propriétés de document, à savoir les propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés en utilisant l'API de Aspose.Slides pour Java. Aspose.Slides pour Java fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation à travers la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci-dessous :

## **Accéder aux Propriétés Intégrées**
Ces propriétés exposées par l'objet [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) incluent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de Création), **Modified** (Date de Modification), **Printed** (Date du Dernier Impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Est-ce partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```java
// Instancier la classe Presentation qui représente la présentation
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la Présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Afficher les propriétés intégrées
    System.out.println("Catégorie : " + dp.getCategory());
    System.out.println("Statut Actuel : " + dp.getContentStatus());
    System.out.println("Date de Création : " + dp.getCreatedTime());
    System.out.println("Auteur : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("Mots-clés : " + dp.getKeywords());
    System.out.println("Dernier Modifié Par : " + dp.getLastSavedBy());
    System.out.println("Superviseur : " + dp.getManager());
    System.out.println("Date de Modification : " + dp.getLastSavedTime());
    System.out.println("Format de Présentation : " + dp.getPresentationFormat());
    System.out.println("Date du Dernier Impression : " + dp.getLastPrinted());
    System.out.println("Est Partagé entre les producteurs : " + dp.getSharedDoc());
    System.out.println("Sujet : " + dp.getSubject());
    System.out.println("Titre : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les Propriétés Intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d'y accéder. Vous pouvez simplement assigner une valeur de chaîne à n'importe quelle propriété désirée et la valeur de la propriété sera modifiée. Dans l'exemple donné ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation en utilisant Aspose.Slides pour Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la Présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Définir les propriétés intégrées
    dp.setAuthor("Aspose.Slides pour Java");
    dp.setTitle("Modification des Propriétés de Présentation");
    dp.setSubject("Sujet Aspose");
    dp.setComments("Description Aspose");
    dp.setManager("Gestionnaire Aspose");
    
    // Enregistrer votre présentation dans un fichier
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés intégrées de la présentation qui peuvent être consultées comme montré ci-dessous :

|**Propriétés de document intégrées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des Propriétés de Document Personnalisées**
Aspose.Slides pour Java permet également aux développeurs d'ajouter des valeurs personnalisées pour les propriétés de document de présentation. Un exemple est donné ci-dessous montrant comment définir les propriétés personnalisées pour une présentation.

```java
Presentation pres = new Presentation();
try {
    // Obtenir les Propriétés de Document
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Ajouter des propriétés personnalisées
    dProps.set_Item("Nouvelle Personnalisée", 12);
    dProps.set_Item("Mon Nom", "Mudassir");
    dProps.set_Item("Personnalisée", 124);
    
    // Obtenir le nom de propriété à un index particulier
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Supprimer la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    
    // Enregistrer la présentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriétés de Document Personnalisées Ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et Modifier les Propriétés Personnalisées**
Aspose.Slides pour Java permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous montrant comment vous pouvez accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la Présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accéder et modifier les propriétés personnalisées
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et les valeurs des propriétés personnalisées
        System.out.println("Nom de la Propriété Personnalisée : " + dp.getCustomPropertyName(i));
        System.out.println("Valeur de la Propriété Personnalisée : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifier les valeurs des propriétés personnalisées
        dp.set_Item(dp.getCustomPropertyName(i), "Nouvelle Valeur " + (i + 1));
    }
    
    // Enregistrer votre présentation dans un fichier
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés personnalisées de la présentation [PPTX](https://docs.fileformat.com/presentation/pptx/). Les figures suivantes montrent les propriétés personnalisées de la présentation avant et après modification :

|**Propriétés Personnalisées avant Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propriétés Personnalisées après Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de Document Avancées**
{{% alert color="primary" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) et [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à l'interface [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo), la logique du setter de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l'interface [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). Elles fournissent un accès rapide aux propriétés de document et permettent de changer et de mettre à jour les propriétés sans charger une présentation entière.

Le scénario typique consiste à charger les propriétés, modifier une valeur et mettre à jour le document peut être implémenté de la manière suivante :

```java
// lire les informations de présentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtenir les propriétés actuelles
IDocumentProperties props = info.readDocumentProperties();

// définir les nouvelles valeurs des champs Auteur et Titre
props.setAuthor("Nouvel Auteur");
props.setTitle("Nouveau Titre");

// mettre à jour la présentation avec de nouvelles valeurs
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Il existe une autre façon d'utiliser les propriétés d'une présentation particulière comme modèle pour mettre à jour les propriétés d'autres présentations :

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Auteur du Modèle");
template.setTitle("Titre du Modèle");
template.setCategory("Catégorie du Modèle");
template.setKeywords("MotClé1, MotClé2, MotClé3");
template.setCompany("Notre Société");
template.setComments("Créé à partir du modèle");
template.setContentType("Contenu du Modèle");
template.setSubject("Sujet du Modèle");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Un nouveau modèle peut être créé à partir de zéro et ensuite utilisé pour mettre à jour plusieurs présentations :

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Auteur du Modèle");
template.setTitle("Titre du Modèle");
template.setCategory("Catégorie du Modèle");
template.setKeywords("MotClé1, MotClé2, MotClé3");
template.setCompany("Notre Société");
template.setComments("Créé à partir du modèle");
template.setContentType("Contenu du Modèle");
template.setSubject("Sujet du Modèle");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Vérifier si la Présentation est Modifiée ou Créée**
Aspose.Slides pour Java fournit la possibilité de vérifier si une présentation est modifiée ou créée. Un exemple est donné ci-dessous montrant comment vérifier si la présentation est créée ou modifiée.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Nom de l'Application : " + app);
System.out.println("Version de l'Application : " + ver);
```

## **Définir la Langue de Vérification**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue pour laquelle l'orthographe et la grammaire dans le PowerPoint sont vérifiées.

Ce code Java vous montre comment définir la langue de vérification pour un PowerPoint : xxx Pourquoi LanguageId est-il manquant dans la classe PortionFormat Java ?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // définir l'Id d'une langue de vérification

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Langue par Défaut**

Ce code Java vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Ajoute une nouvelle forme rectangle avec du texte
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Nouveau Texte");

    // Vérifier la langue de la première portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```