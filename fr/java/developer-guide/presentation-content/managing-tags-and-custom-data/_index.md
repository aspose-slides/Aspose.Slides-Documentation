---
title: Gérer les balises et les données personnalisées dans les présentations avec Java
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- XML personnalisé
- partie XML personnalisée
- métadonnées XML
- ItemId
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour Java, y compris l’ajout, la lecture, la mise à jour, l’audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides gère les balises et les données personnalisées dans les présentations PowerPoint. Les données spécifiques à une présentation peuvent être stockées sous forme de balises ou de parties XML personnalisées. Les balises sont de simples paires chaîne clé‑valeur, tandis que les parties XML personnalisées peuvent contenir des métadonnées structurées et des charges XML spécifiques à l'application.

Aspose.Slides fournit des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées au niveau de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que des identifiants de gestion de documents, l’état d’un workflow, des métadonnées de conformité, des données de liaison de modèle ou d’autres données d’application structurées à l’intérieur d’une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — les fichiers avec l’extension `.pptx` — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées par des relations. Par exemple, une partie de diapositive contient le contenu d’une seule diapositive et peut avoir des relations explicites avec d’autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITagCollection)) ou de parties XML personnalisées ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection)). Les deux sont accessibles via l’interface [`ICustomData`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
Les balises stockent de simples paires chaîne clé‑valeur. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La méthode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomData#getCustomXmlParts--) renvoie la collection de parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- `presentation.getCustomData().getCustomXmlParts()` contient les parties XML personnalisées associées à la présentation elle‑même.
- `slide.getCustomData().getCustomXmlParts()` contient les parties XML personnalisées associées à une diapositive spécifique.
- `shape.getCustomData().getCustomXmlParts()` contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) lorsque vous devez inspecter toutes les parties XML personnalisées de la présentation, quel que soit leur niveau d’association.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L’exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add attribue un identifiant automatiquement. Définissez un UUID spécifique uniquement si nécessaire.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La méthode `add` peut également accepter le XML sous forme de tableau d’octets ou de flux d’entrée, ce qui est pratique lorsque le contenu XML est déjà disponible en format binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou à une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou à une forme spécifique au lieu de toute la présentation. Cela est utile lorsque les métadonnées décrivent un seul objet, par exemple une clé de modèle, un identifiant d’enregistrement externe ou des informations de liaison.

L’exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le niveau auquel une partie est ajoutée détermine quelle collection `getCustomData().getCustomXmlParts()` de quel objet contient la relation vers cette partie. Les données au niveau de la présentation conviennent aux métadonnées globales du document, les données au niveau de la diapositive aux informations propres à une diapositive donnée, et les données au niveau de la forme aux métadonnées rattachées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) pour récupérer toutes les parties XML personnalisées d’une présentation. Chaque [`ICustomXmlPart`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart/) expose son identifiant, son contenu XML et les schémas d’espaces de noms associés.

L’exemple suivant liste toutes les parties XML personnalisées et leurs schémas d’espaces de noms :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l’audit de présentations contenant du XML produit par des systèmes externes.

### **Lire et mettre à jour le contenu XML et l’ItemId**

Utilisez [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) et [`setXmlAsString()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) pour travailler avec le XML sous forme de chaîne UTF‑8, ou [`getXmlData()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#getXmlData--) et [`setXmlData()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) pour traiter les octets XML bruts.

La méthode [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#getItemId--) renvoie le UUID qui identifie la partie XML personnalisée dans le document Office Open XML. Utilisez [`setItemId()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) lorsqu’une intégration nécessite un nouvel identifiant.

L’exemple suivant met à jour le contenu XML et l’identifiant :

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lire le XML actuel en tant que texte.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Mettre à jour le XML sous forme de chaîne UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData fournit le même contenu XML sous forme d'octets bruts.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Remplacer l'identifiant lorsque l'intégration le nécessite.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lors de l’appel à `setXmlAsString` ou `setXmlData`, fournissez un XML valide et non vide. Utilisez l’une ou l’autre des représentations selon que l’application travaille principalement avec des chaînes ou avec des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides propose plusieurs manières de supprimer des données XML personnalisées :

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPart#remove--) supprime la partie XML personnalisée de la présentation.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) supprime une partie spécifique d’une collection de parties XML personnalisées.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) supprime la partie à l’index spécifié de la collection.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ICustomXmlPartCollection#clear--) supprime toutes les parties d’une collection donnée.

L’exemple suivant supprime une partie XML personnalisée au niveau de la présentation en se basant sur la référence :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous avez déjà un `ICustomXmlPart` et que vous voulez supprimer cette partie de la présentation plutôt que d’adresser une collection particulière, appelez `customXmlPart.remove()`.

Vous pouvez également supprimer un élément par son index :

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Effacer toutes les parties XML personnalisées d’une collection**

Utilisez `clear` lorsque toutes les parties XML personnalisées associées à un objet de présentation particulier doivent être supprimées.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` n’affecte que la collection sélectionnée. Par exemple, vider la collection d’une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée de la présentation, parcourez `getAllCustomXmlParts()` et supprimez chaque partie :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de présentation. Par exemple, un fichier existant peut contenir des relations depuis plusieurs diapositives ou formes vers la même partie XML personnalisée sous‑jacente.

Une partie partagée doit être traitée comme un seul objet de données avec plusieurs références :

- La mettre à jour avec `setXmlAsString`, `setXmlData` ou `setItemId` modifie la partie XML personnalisée sous‑jacente, de sorte que le changement s’applique partout où la partie est référencée.
- `getItemId()` peut être utilisé pour identifier la même partie XML personnalisée lors de l’audit des collections au niveau des objets.
- Supprimer une partie d’une collection `getCustomXmlParts()` particulière la retire de cette collection. Utilisez `ICustomXmlPart.remove()` lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, inspectez les collections au niveau des objets pour déterminer si d’autres diapositives ou formes la référencent encore.

Les surcharges de `add` créent une nouvelle partie XML personnalisée à partir du contenu XML ; elles n’acceptent pas un `ICustomXmlPart` existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L’exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `ItemId` et signale les parties référencées depuis plus d’un endroit :

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ce type d’audit est utile avant de modifier ou de supprimer des données XML personnalisées dans des présentations créées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond à la méthode `IDocumentProperties.getKeywords()`. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides for Java pour [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée, par exemple `MyTag`;
- la valeur de la propriété personnalisée, par exemple `My Tag Value`.

Si vous devez classer les présentations selon une règle ou une propriété spécifique, vous pouvez ajouter des balises à cet effet. Par exemple, pour catégoriser les présentations provenant des pays d’Amérique du Nord, créez une balise « North American » et affectez le pays concerné comme valeur.

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) en utilisant Aspose.Slides for Java :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISlide) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Ou pour une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAutoShape) individuelle :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitations**

Les balises ajoutées via la collection `getCustomData().getTags()` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises PDF lors de l’exportation de la présentation en PDF. Par conséquent, un identifiant personnalisé affecté en tant que balise ne peut pas être récupéré depuis le PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **texte alternatif** de l’objet (par exemple, `shape.setAlternativeText("MyId")`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#clear--) qui supprime toutes les paires clé‑valeur d’un seul coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez [remove(name)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) sur la [collection de balises](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/#getNamesOfTags--) sur la [collection de balises](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.

**Comment trouver toutes les parties XML personnalisées quel que soit leur emplacement ?**

Utilisez [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois‑je utiliser `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` pour mettre à jour une partie XML personnalisée ?**

Utilisez `getXmlAsString` et `setXmlAsString` lorsque l’application travaille avec du texte XML UTF‑8. Utilisez `getXmlData` et `setXmlData` lorsque le XML est déjà disponible sous forme de tableau d’octets ou quand le traitement binaire est plus pratique. Les deux représentations font référence au même contenu XML de la partie XML personnalisée.