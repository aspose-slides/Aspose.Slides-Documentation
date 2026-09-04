---
title: Gérer les propriétés de présentation en Java
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/java/presentation-properties/
keywords:
- propriétés PowerPoint
- propriétés de présentation
- propriétés de document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées de document
- modifier les métadonnées
- langue de correction
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement consultés et gérés à l'aide de l'API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document d'une présentation via l'interface [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque enregistrement, de sorte qu'une présentation enregistrée indique toujours « Aspose.Slides for Java » et la version de la bibliothèque qui l'a produite. Toute valeur passée à `setNameOfApplication` est ignorée lors de l'écriture de la présentation.
{{% /alert %}} 

## **Propriétés de document dans PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l'icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme indiqué ci‑dessous :

|**Sélection du menu Propriétés avancées**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Après avoir sélectionné le menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés de document du fichier PowerPoint comme le montre la figure suivante :

|**Boîte de dialogue Propriétés**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de dialogue Propriétés** ci‑dessus, vous constatez de nombreux onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d'informations relatives aux fichiers PowerPoint. L'onglet **Custom** sert à gérer les propriétés personnalisées des fichiers PowerPoint.

### Travailler avec les propriétés de document à l’aide d’Aspose.Slides for Java

Comme indiqué précédemment, Aspose.Slides for Java prend en charge deux sortes de propriétés de document, les propriétés **Built-in** et **Custom**. Les développeurs peuvent ainsi accéder aux deux types de propriétés via l’API Aspose.Slides for Java. Aspose.Slides for Java fournit la classe [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) pour accéder aux propriétés de document des présentations comme décrit ci‑dessous :

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège normalement le contenu de la présentation ainsi que ses propriétés de document. Lorsqu’une présentation est chiffrée en passant `false` à [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

L’option « document‑properties‑only » contrôle ce qu’Aspose.Slides charge ; elle ne décrypte rien. Si les propriétés étaient incluses dans le chiffrement, le chargement sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) puis lit les propriétés intégrées via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, mises en page, formes, médias et autres objets de présentation sont indisponibles. Les applications doivent toujours vérifier [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Warning" %}}
Les métadonnées publiques peuvent exposer les noms d’auteur, titres, sujets, mots‑clés, informations d’entreprise, commentaires et valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents nécessitent un accès sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée en mode « document‑properties‑only » est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées provenant de cet objet limité, car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) pour vérifier que le chiffrement est préservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit traiter les propriétés publiques d’un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet [IDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (Partagée entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

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

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les consulter. Il suffit d’affecter une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’une présentation à l’aide d’Aspose.Slides for Java.

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

Cet exemple modifie les propriétés intégrées de la présentation, comme le montre la capture ci‑dessous :

|**Propriétés de document intégrées après modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides for Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document d’une présentation. L’exemple suivant ajoute trois propriétés personnalisées, recherche ensuite le nom stocké à l’index 2 et supprime cette propriété, de sorte que la présentation enregistrée ne conserve que deux d’entre elles. Les propriétés personnalisées sont indexées par ordre alphabétique, pas dans l’ordre d’ajout.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtention des propriétés de document
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Ajout de propriétés personnalisées
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtention du nom de propriété à un index particulier
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Suppression de la propriété sélectionnée
    dProps.removeCustomProperty(getPropertyName);
    
    // Enregistrement de la présentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriétés de document personnalisées ajoutées**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessus montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Créer une référence à l'objet DocumentProperties associé à la présentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accéder et modifier les propriétés personnalisées
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Afficher les noms et les valeurs des propriétés personnalisées
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

Cet exemple modifie les propriétés personnalisées de la [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de document avancées**

{{% alert color="info" title="Note" %}}
De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). La logique du setter de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.
{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l’interface [IPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés de document et permettent de les changer et les mettre à jour sans charger une présentation complète.

Le scénario typique consiste à charger les propriétés, modifier une valeur et mettre à jour le document, comme illustré ci‑dessus :

```java
import com.aspose.slides.*;

// lire les informations de la présentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtenir les propriétés actuelles
IDocumentProperties props = info.readDocumentProperties();

// définir les nouvelles valeurs des champs Auteur et Titre
props.setAuthor("New Author");
props.setTitle("New Title");

// mettre à jour la présentation avec de nouvelles valeurs
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

Un nouveau modèle peut être créé de zéro puis utilisé pour mettre à jour plusieurs présentations :

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

## **Définir la langue de correction**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de correction orthographique pour un document PowerPoint. La langue de correction est celle pour laquelle l’orthographe et la grammaire du PowerPoint sont vérifiées.

Ce code Java montre comment définir la langue de correction pour un PowerPoint :

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

    portionFormat.setLanguageId("zh-CN"); // définir l'Id d'une langue de correction

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
    // Ajoute une nouvelle forme rectangle avec du texte
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Vérifie la langue de la première portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemple en ligne**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les vider si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur existante sera remplacée par la nouvelle. Vous n’avez pas besoin de la supprimer ou de la vérifier au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger la présentation complète ?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) puis [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pour lire les métadonnées stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/java/examine-presentation/) pour un exemple complet de rapport et les limitations selon le format.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. Le chiffrement des propriétés de document doit avoir été désactivé avant le chiffrement de la présentation, et la présentation doit être chargée en mode « document‑properties‑only ».

**Puis‑je mettre à jour un fichier PPTX chiffré en mode « document‑properties‑only » ?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, de sorte que la mise à jour d’un fichier PPTX chiffré nécessite le chargement complet de la présentation avec le mot de passe d’ouverture correct.