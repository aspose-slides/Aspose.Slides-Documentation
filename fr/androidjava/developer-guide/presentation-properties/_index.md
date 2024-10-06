---
title: Propriétés de présentation
type: docs
weight: 70
url: /androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint fournit une fonctionnalité pour ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés définies par le système (intégrées)
- Propriétés définies par l'utilisateur (personnalisées)

Les propriétés **intégrées** contiennent des informations générales sur le document, telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l'utilisateur. En utilisant Aspose.Slides pour Android via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

{{% /alert %}} 

## **Propriétés de document dans PowerPoint**
Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office et sur l'élément de menu **Préparer | Propriétés | Propriétés avancées** de Microsoft PowerPoint 2007 comme indiqué ci-dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour Android via Java x.x.x seront affichés dans ces champs.

{{% /alert %}} 

|**Sélection de l'élément de menu Propriétés avancées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l'élément de menu **Propriétés avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint comme indiqué ci-dessous dans la figure :

|**Boîte de dialogue Propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **boîte de dialogue Propriétés** ci-dessus, vous pouvez voir qu'il existe de nombreuses pages d'onglets comme **Général**, **Résumé**, **Statistiques**, **Contenu** et **Personnalisé**. Toutes ces pages d'onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

Travailler avec les propriétés de document en utilisant Aspose.Slides pour Android via Java

Comme nous l'avons décrit précédemment, Aspose.Slides pour Android via Java prend en charge deux types de propriétés de document, qui sont les propriétés **intégrées** et **personnalisées**. Ainsi, les développeurs peuvent accéder à ces deux types de propriétés par le biais de l'API Aspose.Slides pour Android via Java. Aspose.Slides pour Android via Java fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l'objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci-dessous :

## **Accéder aux propriétés intégrées**
Ces propriétés exposées par l'objet [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) incluent : **Creator** (Auteur), **Description**, **Keywords** **Created** (Date de création), **Modified** Date de modification, **Printed** Dernière date d'impression, **LastModifiedBy**, **Keywords**, **SharedDoc** (Partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**

```java
// Instancier la classe Presentation qui représente la présentation
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Afficher les propriétés intégrées
    System.out.println("Catégorie : " + dp.getCategory());
    System.out.println("Statut actuel : " + dp.getContentStatus());
    System.out.println("Date de création : " + dp.getCreatedTime());
    System.out.println("Auteur : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("Mots-clés : " + dp.getKeywords());
    System.out.println("Dernier modifié par : " + dp.getLastSavedBy());
    System.out.println("Superviseur : " + dp.getManager());
    System.out.println("Date de modification : " + dp.getLastSavedTime());
    System.out.println("Format de présentation : " + dp.getPresentationFormat());
    System.out.println("Dernière date d'impression : " + dp.getLastPrinted());
    System.out.println("Est partagé entre producteurs : " + dp.getSharedDoc());
    System.out.println("Sujet : " + dp.getSubject());
    System.out.println("Titre : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les propriétés intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d’y accéder. Vous pouvez simplement assigner une valeur string à toute propriété souhaitée et la valeur de la propriété serait modifiée. Dans l'exemple ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation en utilisant Aspose.Slides pour Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Définir les propriétés intégrées
    dp.setAuthor("Aspose.Slides pour Android via Java");
    dp.setTitle("Modification des propriétés de présentation");
    dp.setSubject("Sujet Aspose");
    dp.setComments("Description Aspose");
    dp.setManager("Gestionnaire Aspose");
    
    // Enregistrer votre présentation dans un fichier
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés intégrées de la présentation qui peuvent être visualisées comme indiqué ci-dessous :

|**Propriétés de document intégrées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**
Aspose.Slides pour Android via Java permet également aux développeurs d’ajouter les valeurs personnalisées pour les propriétés de document de la présentation. Un exemple est donné ci-dessous qui montre comment définir les propriétés personnalisées pour une présentation.

```java
Presentation pres = new Presentation();
try {
    // Obtenir les propriétés de document
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Ajouter des propriétés personnalisées
    dProps.set_Item("Nouvelle Personnalisée", 12);
    dProps.set_Item("Mon Nom", "Mudassir");
    dProps.set_Item("Personnalisé", 124);
    
    // Obtenir le nom de la propriété à un index particulier
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Supprimer la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    
    // Sauvegarder la présentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriétés de document personnalisées ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**
Aspose.Slides pour Android via Java permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous qui montre comment vous pouvez accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accéder et modifier les propriétés personnalisées
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et les valeurs des propriétés personnalisées
        System.out.println("Nom de la propriété personnalisée : " + dp.getCustomPropertyName(i));
        System.out.println("Valeur de la propriété personnalisée : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifier les valeurs des propriétés personnalisées
        dp.set_Item(dp.getCustomPropertyName(i), "Nouvelle Valeur " + (i + 1));
    }
    
    // Enregistrer votre présentation dans un fichier
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés personnalisées de la présentation [PPTX ](https://docs.fileformat.com/presentation/pptx/). Les figures suivantes montrent les propriétés personnalisées de la présentation avant et après modification :

|**Propriétés personnalisées avant modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de document avancées**
{{% alert color="primary" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) et [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo), et la logique de la méthode [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l’interface [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés de document et permettent de modifier et de mettre à jour des propriétés sans charger toute une présentation.

Le scénario typique consiste à charger les propriétés, à modifier certaines valeurs et à mettre à jour le document de la manière suivante :

```java
// lire les informations de la présentation
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
template.setCompany("Notre Entreprise");
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

Un nouveau modèle peut être créé de toutes pièces, puis utilisé pour mettre à jour plusieurs présentations :

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Auteur du Modèle");
template.setTitle("Titre du Modèle");
template.setCategory("Catégorie du Modèle");
template.setKeywords("MotClé1, MotClé2, MotClé3");
template.setCompany("Notre Entreprise");
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

## **Vérifier si la présentation a été modifiée ou créée**
Aspose.Slides pour Android via Java fournit la possibilité de vérifier si une présentation a été modifiée ou créée. Un exemple est donné ci-dessous qui montre comment vérifier si la présentation est créée ou modifiée.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Nom de l'application : " + app);
System.out.println("Version de l'application : " + ver);
```

## **Définir la langue de vérification**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue pour laquelle l'orthographe et la grammaire dans le PowerPoint sont vérifiées.

Ce code Java vous montre comment définir la langue de vérification pour un PowerPoint : xxx Pourquoi LanguageId est-il manquant dans la classe Java PortionFormat ?

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

## **Définir la langue par défaut**

Ce code Java vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Ajoute une nouvelle forme rectangle avec du texte
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Nouveau Texte");

    // Vérifie la langue de la première portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```