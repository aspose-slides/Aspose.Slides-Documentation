---
title: Gérer les propriétés de présentation en Java
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/java/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
- Propriétés de document
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
- Java
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for Java et simplifiez la recherche, l'image de marque et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement accessibles et gérés à l'aide de l'API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document d'une présentation via l'interface [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par la méthode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getDocumentProperties--) . Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" %}} 

Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque enregistrement, de sorte qu'une présentation enregistrée indique toujours « Aspose.Slides for Java » et la version de la bibliothèque qui l'a créée. Toute valeur transmise à `setNameOfApplication` est ignorée lors de l'écriture de la présentation.

{{% /alert %}} 

## **Document Properties in PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il vous suffit de cliquer sur l'icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme illustré ci‑dessous :

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l'élément de menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du document PowerPoint comme le montre la figure suivante :

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Properties Dialog** ci‑above, vous pouvez voir de nombreux onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Custom** sert à gérer les propriétés personnalisées des fichiers PowerPoint.

Working with Document Properties Using Aspose.Slides for Java

Comme indiqué précédemment, Aspose.Slides for Java prend en charge deux types de propriétés de document, les propriétés **Built-in** et **Custom**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés à l'aide de l'API Aspose.Slides for Java. Aspose.Slides for Java fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci‑dessous :

## **Access Built-in Properties**

Ces propriétés exposées par l'objet [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

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

## **Modify Built-in Properties**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les accéder. Il suffit d’affecter une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l'exemple ci‑dessous, nous montrons comment modifier les propriétés intégrées du document de présentation à l'aide d'Aspose.Slides for Java.

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

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**

Aspose.Slides for Java permet également aux développeurs d'ajouter des valeurs personnalisées aux propriétés de document de la présentation. L'exemple ci‑dessus ajoute trois propriétés personnalisées, recherche ensuite le nom stocké à l'index 2 et supprime cette propriété, si bien que la présentation enregistrée en conserve deux. Les propriétés personnalisées sont indexées par ordre alphabétique, pas dans l'ordre d'ajout.

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
    
    // Obtention du nom de la propriété à un index particulier
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Suppression de la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    
    // Enregistrement de la présentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**

Aspose.Slides for Java permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. L'exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

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

Cet exemple modifie les propriétés personnalisées de la [PPTX](https://docs.fileformat.com/presentation/pptx/) présentation. Les figures suivantes montrent les propriétés personnalisées de la présentation avant et après modification :

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). La logique du setteur de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l'interface [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés de document et permettent de les modifier sans charger l'intégralité de la présentation.

Le scénario typique consiste à charger les propriétés, changer une valeur et mettre à jour le document, comme illustré ci‑dessous :

```java
import com.aspose.slides.*;

// lire les informations de la présentation
IPPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtenir les propriétés actuelles
IDocumentProperties props = info.readDocumentProperties();

// définir les nouvelles valeurs des champs Author et Title
props.setAuthor("New Author");
props.setTitle("New Title");

// mettre à jour la présentation avec de nouvelles valeurs
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Il existe une autre façon d'utiliser les propriétés d'une présentation particulière comme modèle pour mettre à jour les propriétés d'autres présentations :

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

## **Set Proofing Language**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour définir la langue de vérification orthographique d'un document PowerPoint. La langue de vérification orthographique est la langue utilisée pour la correction orthographique et grammaticale dans PowerPoint.

Ce code Java montre comment définir la langue de vérification pour un PowerPoint :

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

    portionFormat.setLanguageId("zh-CN"); // définir l'Id d'une langue de vérification

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Default Language**

Ce code Java montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Ajoute une nouvelle forme rectangulaire avec texte
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Vérifie la langue de la première portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live Example**

Essayez l'application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l'API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## ***FAQ**

### How can I remove a built-in property from a presentation?

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

### What happens if I add a custom property that already exists?

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

### Can I access presentation properties without fully loading the presentation?

Yes, you can access presentation properties without fully loading the presentation by using the `getPresentationInfo` method from the [PresentationFactory](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/) class. Then, utilize the `readDocumentProperties` method provided by the [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/) interface to read the properties efficiently, saving memory and improving performance.