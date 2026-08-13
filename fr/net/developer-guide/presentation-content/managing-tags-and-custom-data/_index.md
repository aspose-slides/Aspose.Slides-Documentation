---
title: Gérer les balises et les données personnalisées dans les présentations en .NET
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/net/managing-tags-and-custom-data/
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour .NET, y compris l’ajout, la lecture, la mise à jour, l’audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Les données spécifiques à une présentation peuvent être stockées sous forme de balises ou de parties XML personnalisées. Les balises sont de simples paires chaîne clé‑valeur, tandis que les parties XML personnalisées peuvent stocker des métadonnées structurées et des charges XML spécifiques à l'application.

Aspose.Slides fournit des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées au niveau de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que les identifiants de gestion de documents, l’état du workflow, les métadonnées de conformité, les données de liaison de modèle ou d’autres données d’application structurées à l’intérieur d’une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — les fichiers avec l’extension `.pptx` — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées par des relations. Par exemple, une partie de diapositive contient le contenu d’une seule diapositive et peut avoir des relations explicites avec d’autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/itagcollection)) ou de parties XML personnalisées ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection)). Les deux sont accessibles via l’interface [`ICustomData`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Les balises stockent de simples paires chaîne clé‑valeur. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La propriété [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomdata/customxmlparts/) renvoie la collection des parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- `presentation.CustomData.CustomXmlParts` contient les parties XML personnalisées associées à la présentation elle‑même.
- `slide.CustomData.CustomXmlParts` contient les parties XML personnalisées associées à une diapositive spécifique.
- `shape.CustomData.CustomXmlParts` contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/allcustomxmlparts/) lorsque vous devez examiner toutes les parties XML personnalisées de la présentation, quel que soit leur association.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection/add/) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L’exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add attribue automatiquement un identifiant. Définissez un GUID spécifique uniquement si nécessaire.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

La méthode `Add` peut également accepter le XML sous forme de tableau d’octets ou de flux, ce qui est utile lorsque le contenu XML est déjà disponible sous forme binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou à une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou à une forme spécifique plutôt qu’à l’ensemble de la présentation. Cela est utile lorsque les métadonnées décrivent un seul objet, comme une clé de modèle, un identifiant d’enregistrement externe ou des informations de liaison.

L’exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Le niveau auquel une partie est ajoutée détermine la collection `CustomData.CustomXmlParts` de quel objet contient la relation vers cette partie. Les données au niveau de la présentation sont appropriées pour les métadonnées couvrant tout le document, les données au niveau de la diapositive pour les informations relatives à une diapositive particulière, et les données au niveau de la forme pour les métadonnées liées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/allcustomxmlparts/) pour récupérer toutes les parties XML personnalisées d’une présentation. Chaque [`ICustomXmlPart`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpart/) expose son identifiant, son contenu XML et les schémas d’espaces de noms associés.

L’exemple suivant liste toutes les parties XML personnalisées et leurs schémas d’espaces de noms :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

`ICustomXmlPart.NamespaceSchemas` renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l’audit de présentations contenant du XML généré par des systèmes externes.

### **Lire et mettre à jour le contenu XML et l’ItemId**

Utilisez [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpart/xmlasstring/) pour travailler avec le XML sous forme de chaîne UTF‑8, ou [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpart/xmldata/) pour travailler avec les octets XML bruts. Les deux propriétés peuvent être lues et mises à jour.

La propriété [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpart/itemid/) contient le GUID qui identifie la partie XML personnalisée dans le document Office Open XML. Elle peut également être modifiée lorsqu’une intégration nécessite un nouvel identifiant.

L’exemple suivant met à jour le contenu XML et l’identifiant :

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Lire le XML actuel en tant que texte.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Mettre à jour le XML en tant que chaîne UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData fournit le même contenu XML sous forme d'octets bruts.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Remplacer l'identifiant lorsque l'intégration l'exige.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Lors de l’affectation de `XmlAsString` ou de `XmlData`, fournissez un XML valide et non vide. Utilisez l’une ou l’autre représentation selon que l’application travaille principalement avec des chaînes ou des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides propose plusieurs manières de supprimer des données XML personnalisées :

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpart/remove/) supprime la partie XML personnalisée de la présentation.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection/remove/) supprime une partie spécifique d’une collection de parties XML personnalisées.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection/removeat/) supprime la partie à l’index de collection spécifié.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection/clear/) supprime toutes les parties d’une collection spécifique.

L’exemple suivant supprime une partie XML personnalisée au niveau de la présentation par référence :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Si vous avez déjà un `ICustomXmlPart` et souhaitez supprimer cette partie de la présentation plutôt que d’adresser une collection particulière, appelez `customXmlPart.Remove()`.

Vous pouvez également supprimer un élément par index :

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Effacer toutes les parties XML personnalisées d’une collection**

Utilisez `Clear` lorsque toutes les parties XML personnalisées associées à un objet de présentation particulier doivent être supprimées.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` n’affecte que la collection sélectionnée. Par exemple, vider la collection d’une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée de la présentation, parcourez `AllCustomXmlParts` et supprimez chaque partie :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de présentation. Par exemple, un fichier existant peut contenir des relations provenant de plusieurs diapositives ou formes vers la même partie XML personnalisée sous‑jacent.

Une partie partagée doit être traitée comme un seul objet de données avec plusieurs références :

- Mettre à jour son `XmlAsString`, `XmlData` ou `ItemId` modifie la partie XML personnalisée sous‑jacent, si bien que la modification s’applique partout où cette partie est référencée.
- `ItemId` peut être utilisé pour identifier la même partie XML personnalisée lors de l’audit des collections au niveau des objets.
- Supprimer une partie d’une collection `CustomXmlParts` spécifique la retire de cette collection. Utilisez `ICustomXmlPart.Remove()` lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, inspectez les collections au niveau des objets pour déterminer si d’autres diapositives ou formes la référencent encore.

Les surcharges de `Add` créent une nouvelle partie XML personnalisée à partir du contenu XML ; elles n’acceptent pas un `ICustomXmlPart` existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L’exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `ItemId` et signale les parties référencées depuis plus d’un endroit :

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Ce type d’audit est utile avant de modifier ou de supprimer des données XML personnalisées dans des présentations créées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond à la propriété `IDocumentProperties.Keywords`. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour .NET pour [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée, par exemple, `MyTag` ;
- la valeur de la propriété personnalisée, par exemple, `My Tag Value`.

Si vous devez classer les présentations selon une règle ou une propriété spécifique, vous pouvez ajouter des balises à cet effet. Par exemple, si vous voulez catégoriser les présentations provenant des pays d’Amérique du Nord, vous pouvez créer une balise North American et attribuer le pays correspondant comme valeur.

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) en utilisant Aspose.Slides pour .NET :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/net/aspose.slides/slide) :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/shape) individuelle :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Limitations**

Les balises ajoutées via la collection `CustomData.Tags` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées dans la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé affecté sous forme de balise ne peut pas être récupéré à partir du PDF balisé.

**Solution** : Vous pouvez stocker un identifiant personnalisé dans le **texte alternatif** de l’objet (par exemple, `shape.AlternativeText = "MyId"`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) prend en charge une opération [Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur en une fois.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez [Remove(name)](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.

**Comment puis‑je trouver toutes les parties XML personnalisées, quel que soit leur emplacement ?**

Utilisez [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/allcustomxmlparts/) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois‑je utiliser `XmlAsString` ou `XmlData` pour mettre à jour une partie XML personnalisée ?**

Utilisez `XmlAsString` lorsque l’application travaille avec du texte XML UTF‑8. Utilisez `XmlData` lorsque le XML est déjà disponible sous forme de tableau d’octets ou lorsqu’un traitement orienté binaire est plus pratique. Les deux propriétés représentent le même contenu XML de la partie XML personnalisée.