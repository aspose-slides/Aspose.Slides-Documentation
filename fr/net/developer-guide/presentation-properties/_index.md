---
title: Gestion des propriétés de présentation en .NET
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/net/presentation-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour .NET et simplifiez la recherche, la marque et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides for .NET prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Ces deux types de propriétés peuvent être facilement consultés et gérés à l’aide de l’API Aspose.Slides for .NET.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par la propriété [Presentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" %}} 
Veuillez noter que les champs **Application** et **Producer** ne peuvent pas être modifiés, car ces champs afficheront toujours "Aspose Ltd." et "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gérer les propriétés de la présentation**

Microsoft PowerPoint propose une fonctionnalité permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les fichiers. Il existe deux types de propriétés de document :

- Propriétés système (intégrées)
- Propriétés utilisateur (personnalisées)

Les propriétés **Built-in** contiennent des informations générales sur le document, telles que le titre du document, le nom de l’auteur, les statistiques du document, etc.

Les propriétés **Custom** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont spécifiés par l’utilisateur.

Avec Aspose.Slides for .NET, les développeurs peuvent accéder et modifier à la fois les propriétés intégrées et personnalisées.

Microsoft PowerPoint permet aux utilisateurs de gérer les propriétés de document en cliquant sur l’icône Office, puis en sélectionnant **File → Info → Properties**. Après avoir choisi **Advanced Properties**, une boîte de dialogue apparaît où vous pouvez gérer toutes les propriétés du fichier de présentation.

Dans la boîte de dialogue **Properties**, plusieurs onglets sont disponibles, tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Chaque onglet offre des options de configuration pour des types d’informations spécifiques liées au fichier PowerPoint. L’onglet **Custom** sert à gérer les propriétés définies par l’utilisateur.

## **Accéder aux propriétés intégrées**

Ces propriétés, exposées par l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/), comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (indique si le document est partagé entre différents producteurs), **PresentationFormat**, **Subject**, **Title**, et d’autres.

```cs
using Aspose.Slides;

// Instancier la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les consulter. Il suffit d’assigner une chaîne de caractères à la propriété souhaitée, et la valeur sera mise à jour. L’exemple ci‑dessous montre comment modifier les propriétés de document intégrées d’un fichier de présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Obtenir une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Définir les propriétés intégrées.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Enregistrer la présentation dans un fichier.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées de présentation permettent aux développeurs de stocker des métadonnées supplémentaires ou des informations spécifiques dans un fichier de présentation. Aspose.Slides facilite la création et la gestion de ces propriétés personnalisées par programme. Les exemples suivants montrent comment ajouter des propriétés personnalisées à vos présentations.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation.
using Presentation presentation = new Presentation();

// Obtenir une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ajouter des propriétés personnalisées.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Enregistrer la présentation dans un fichier.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides permet également aux développeurs d’accéder aux propriétés personnalisées existantes et de modifier leurs valeurs facilement. Cette fonctionnalité aide à maintenir des métadonnées précises et prend en charge les mises à jour dynamiques basées sur les saisies utilisateur ou la logique métier. Les exemples ci‑dessous illustrent la récupération et la mise à jour des valeurs de propriétés personnalisées dans une présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Obtenir une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Accéder et modifier les propriétés personnalisées.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Afficher le nom et la valeur de la propriété personnalisée.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifier la valeur de la propriété personnalisée.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Enregistrer la présentation dans un fichier.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Exemple en direct**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## ***FAQ**

### Comment puis‑je supprimer une propriété intégrée d’une présentation ?

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Cependant, vous pouvez soit modifier leurs valeurs, soit les laisser vides si la propriété le permet.

### Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

### Puis‑je accéder aux propriétés d’une présentation sans la charger complètement ?

Oui, vous pouvez accéder aux propriétés d’une présentation sans la charger complètement en utilisant la méthode `GetPresentationInfo` de la classe [PresentationFactory](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/). Ensuite, utilisez la méthode `ReadDocumentProperties` fournie par l’interface [IPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/) pour lire les propriétés de manière efficace, économisant ainsi de la mémoire et améliorant les performances.