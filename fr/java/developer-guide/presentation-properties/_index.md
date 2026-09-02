---
title: Gérer les propriétés de présentation en Java
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/java/presentation-properties/
keywords:
- Propriétés PowerPoint
- propriétés de présentation
- propriétés du document
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
- Java
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Java et rationalisez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement accédés et gérés à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document d’une présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par la méthode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getDocumentProperties--) . Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque sauvegarde, de sorte qu’une présentation enregistrée indique toujours « Aspose.Slides for Java » et la version de la bibliothèque qui l’a produite. Toute valeur passée à `setNameOfApplication` est ignorée lors de l’écriture de la présentation.
{{% /alert %}} 

## **Propriétés du document dans PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés du document des fichiers de présentation. Il vous suffit de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme indiqué ci‑dessous :

|**Sélection de l'élément du menu Propriétés avancées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l’élément de menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint comme illustré ci‑dessous :

|**Boîte de dialogue des propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de dialogue des propriétés** ci‑above, vous voyez plusieurs onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d’informations relatives aux fichiers PowerPoint. L’onglet **Custom** sert à gérer les propriétés personnalisées des fichiers PowerPoint.

## **Travailler avec les propriétés du document à l’aide d’Aspose.Slides for Java**

Comme indiqué précédemment, Aspose.Slides for Java prend en charge deux sortes de propriétés de document, les propriétés **Built-in** et **Custom**. Les développeurs peuvent donc accéder aux deux types de propriétés via l’API Aspose.Slides for Java. Aspose.Slides for Java fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) pour accéder aux propriétés du document des présentations comme décrit ci‑dessous :

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date de dernière impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Partagée entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente la présentation
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Afficher les propriétés intégrées
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les lire. Il suffit d’affecter une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’une présentation à l’aide d’Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet IDocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Définir les propriétés intégrées
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Enregistrer votre présentation dans un fichier
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés intégrées de la présentation, comme illustré ci‑dessous :

|**Propriétés de document intégrées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides for Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document de la présentation. L’exemple ci‑dess dessous ajoute trois propriétés personnalisées, recherche le nom stocké à l’index 2 puis supprime cette propriété, de sorte que la présentation enregistrée conserve les deux restantes. Les propriétés personnalisées sont indexées par ordre alphabétique, pas dans l’ordre d’ajout.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtention des propriétés du document
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Ajout de propriétés personnalisées
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtention du nom de la propriété à un indice particulier
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Suppression de la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    
    // Enregistrement de la présentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriétés de document personnalisées ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. Un exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées d’une présentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accéder et modifier les propriétés personnalisées
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et valeurs des propriétés personnalisées
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifier les valeurs des propriétés personnalisées
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Enregistrer votre présentation dans un fichier
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple modifie les propriétés personnalisées du [PPTX ](https://docs.fileformat.com/presentation/pptx/)présentation. Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propriétés personnalisées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés avancées du document**

{{% alert color="info" title="Note" %}}
De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). La logique du mutateur de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.
{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l’interface [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés du document et permettent de changer et mettre à jour les propriétés sans charger l’ensemble de la présentation.

Le scénario typique consistant à charger les propriétés, changer une valeur et mettre à jour le document peut être implémenté comme suit :

```java
import com.aspose.slides.*;

// lire les informations de la présentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Il existe une autre façon d’utiliser les propriétés d’une présentation particulière comme modèle pour mettre à jour les propriétés d’autres présentations :

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Un nouveau modèle peut être créé à partir de zéro puis utilisé pour mettre à jour plusieurs présentations :

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Définir la langue de vérification**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de vérification orthographique d’un document PowerPoint. La langue de vérification correspond à la langue selon laquelle l’orthographe et la grammaire du PowerPoint sont vérifiées.

Ce code Java montre comment définir la langue de vérification d’un PowerPoint :

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // définir l'identifiant d'une langue de vérification

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la langue par défaut**

Ce code Java montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Ajoute une nouvelle forme rectangulaire avec du texte
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Vérifie la langue de la première portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemple en direct**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés du document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les mettre à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera écrasée par la nouvelle. Il n’est pas nécessaire de la supprimer ou de la vérifier au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans la charger entièrement ?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) puis [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pour lire les métadonnées du document sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/java/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.