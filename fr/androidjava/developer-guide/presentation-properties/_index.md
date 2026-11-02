---
title: Gérer les propriétés de présentation sur Android
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/androidjava/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
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
- Android
- Java
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Android via Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides for Android via Java prend en charge les propriétés de document **intégrées** et **personnalisées**. Utilisez ces propriétés pour lire et mettre à jour les métadonnées d’une présentation, telles que l’auteur, le titre et les valeurs définies par l’utilisateur.

Aspose.Slides vous permet de travailler avec les propriétés de document de la présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Aspose.Slides gère les métadonnées d’application et de producteur lors de l’enregistrement des présentations ; ces champs identifient le logiciel qui a créé le fichier de sortie.
{{% /alert %}}

## **Manage Presentation Properties**

Les propriétés de document stockent des informations descriptives avec le contenu de la présentation. Elles se répartissent en deux catégories :

- **Built-in properties** contiennent des métadonnées standard, telles que le titre, l’auteur et les statistiques du document.
- **Custom properties** stockent des paires nom/valeur définies par l’utilisateur.

Aspose.Slides for Android via Java fournit l’accès aux deux catégories. Dans PowerPoint, sélectionnez **File → Info → Properties → Advanced Properties** pour examiner les métadonnées du document. La boîte de dialogue regroupe les informations dans des onglets tels que **Summary**, **Statistics**, **Contents** et **Custom**. Utilisez l’onglet **Custom** pour gérer les propriétés définies par l’utilisateur.

## **Read Public Properties from an Encrypted Presentation**

Un mot de passe d’ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsqu’une présentation est chiffrée après l’appel de [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) avec `false`, ses propriétés de document restent publiques. Une application peut alors appeler [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) avec `true` et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) contrôle ce qu’Aspose.Slides charge ; cela ne décrypte rien. Si les propriétés ont été incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple nécessite une présentation chiffrée dont les propriétés de document ont été laissées publiques. Il vérifie le mode de chargement via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) puis lit les propriétés intégrées via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de la présentation ne sont pas disponibles. Les applications doivent toujours vérifier [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Warning" %}}
Les métadonnées publiques peuvent divulguer les noms d’auteur, les titres, les sujets, les mots‑clé, les informations sur l’entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque les systèmes d’indexation, de classification, de recherche ou de gestion documentaire ont une exigence spécifique d’accès sans mot de passe.
{{% /alert %}}

## **Update Properties of an Encrypted Presentation**

Pour un fichier PPTX chiffré, une présentation chargée après l’appel de [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) avec `true` est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet « document‑properties‑only » car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple nécessite une présentation PPTX chiffrée avec des propriétés de document publiques et un mot de passe d’ouverture connu. Il ouvre la présentation complète avec [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs:

```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

## **Access Built-in Properties**

L’interface [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) expose les métadonnées intégrées via des méthodes d’accès, notamment [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) et [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Cet exemple ouvre une présentation existante et imprime ses métadonnées stockées dans la console. Les valeurs dépendent de la présentation d’entrée ; certains champs peuvent être vides.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modify Built-in Properties**

Pour mettre à jour les métadonnées intégrées, utilisez les méthodes d’affectation sur l’objet renvoyé par [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Cet exemple ouvre une présentation existante, appelle [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), et [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), puis enregistre la présentation mise à jour avec [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Le PPTX enregistré contient les nouvelles métadonnées.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Manage the Hyperlink Base**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) renvoie la base au niveau du document pour les hyperliens relatifs. Utilisez [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) pour la modifier ou la vider. Ceci est utile lors du déplacement d’une présentation et de ses fichiers liés vers un autre emplacement. Cela est distinct de [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) d’un hyperlien individuel : changer la base ne réécrit pas les adresses de lien stockées ni ne modifie les destinations absolues.

L’exemple nécessite une présentation contenant à la fois un lien relatif, tel que `target.html`, et un lien absolu, tel que `https://example.org/absolute.html`. Il lit la base existante, attribue une nouvelle adresse de base, puis enregistre et rouvre la présentation pour vérifier la valeur. Il vide ensuite la base avec une chaîne vide et vérifie la valeur vide dans un fichier enregistré séparément. Remplacez l’adresse de base d’exemple par l’emplacement de vos fichiers liés.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

Les deux messages de vérification doivent afficher `true`. Vider la base laisse les adresses des hyperliens individuels intactes.

Un lien relatif vers `target.pptx` ouvrait `old/target.pptx` lorsque la base pointait vers le dossier `old`. Après avoir changé la base vers le dossier `new`, enregistré et rouverts la présentation, le même lien a ouvert `new/target.pptx`. Un lien absolu a continué d’ouvrir le même fichier. Testez vos liens relatifs dans PowerPoint avant et après avoir déplacé la présentation ou modifié sa base.

## **Add Custom Presentation Properties**

Les propriétés personnalisées stockent des métadonnées qui n’ont aucun champ intégré correspondant. La méthode [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) vous permet d’attribuer une valeur par nom de propriété. Cet exemple crée une présentation, ajoute deux valeurs texte et une valeur entière de version, puis enregistre la présentation avec [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Attribuer une valeur à un nom existant remplace la valeur de cette propriété.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access and Modify Custom Properties**

Cet exemple ouvre une présentation contenant des propriétés personnalisées et utilise [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) pour les parcourir. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) accepte un indice basé sur zéro et renvoie le nom utilisé par [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). L’exemple imprime chaque nom et valeur d’origine, remplace chaque valeur par une chaîne numérotée quel que soit son type d’origine, et enregistre les modifications. S’il n’y a aucune propriété personnalisée, la boucle ne fait aucune modification.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live Example**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées entièrement. Vous pouvez toutefois modifier leurs valeurs ou les mettre à vide si la propriété le permet.

**What happens if I add a custom property that already exists?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Can I access presentation properties without fully loading the presentation?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) puis [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/androidjava/examine-presentation/) pour un exemple complet de rapport et les limites spécifiques aux formats.

**Can I read public properties of an encrypted presentation without its opening password?**

Oui. La présentation doit avoir été chiffrée après l’appel de [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) avec `false`, et elle doit être chargée après l’appel de [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) avec `true`.

**Can I update an encrypted PPTX file in document-properties-only mode?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, de sorte que la mise à jour d’un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.