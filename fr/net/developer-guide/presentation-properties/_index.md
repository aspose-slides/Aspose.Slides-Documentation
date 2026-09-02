---
title: Gérer les propriétés de présentation en .NET
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
- Gestion des propriétés
- Modification des propriétés
- Métadonnées du document
- Modifier les métadonnées
- Langue de révision
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour .NET et optimisez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides for .NET prend en charge deux types de propriétés de document : **intégrées** et **personnalisées**. Ces deux types de propriétés peuvent être facilement accédés et gérés à l’aide de l’API Aspose.Slides for .NET.

Aspose.Slides vous permet de travailler avec les propriétés des présentations via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par la propriété [Presentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **Producer** ne peuvent pas être modifiés, ces champs affichent toujours « Aspose Ltd. » et « Aspose.Slides for .NET x.x.x ».
{{% /alert %}} 

## **Gestion des propriétés de présentation**

Microsoft PowerPoint offre une fonctionnalité permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les fichiers. Il existe deux types de propriétés de document :

- Propriétés définies par le système (intégrées)
- Propriétés définies par l’utilisateur (personnalisées)

Les propriétés **intégrées** contiennent des informations générales sur le document, telles que le titre du document, le nom de l’auteur, les statistiques du document, etc.

Les propriétés **personnalisées** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont spécifiés par l’utilisateur.

Avec Aspose.Slides for .NET, les développeurs peuvent accéder et modifier à la fois les propriétés intégrées et personnalisées.

Microsoft PowerPoint permet aux utilisateurs de gérer les propriétés du document en cliquant sur l’icône Office, puis en sélectionnant **File → Info → Properties**. Après avoir choisi **Advanced Properties**, une boîte de dialogue apparaît où vous pouvez gérer toutes les propriétés du fichier de présentation.

Dans la boîte de dialogue **Properties**, plusieurs onglets sont disponibles, tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Chaque onglet offre des options de configuration pour des types d’informations spécifiques liées au fichier PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés définies par l’utilisateur.

## **Accès aux propriétés intégrées**

Ces propriétés, exposées par l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/), comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (indique si le document est partagé entre différents producteurs), **PresentationFormat**, **Subject**, **Title**, etc.

```cs
using Aspose.Slides;

// Instancie la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Obtient une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Affiche les propriétés intégrées.
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

## **Modification des propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les accéder. Il suffit d’attribuer une chaîne de caractères à la propriété souhaitée, et la valeur de la propriété sera mise à jour. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’un fichier de présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Obtient une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Définit les propriétés intégrées.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Enregistre la présentation dans un fichier.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Ajout de propriétés personnalisées à la présentation**

Les propriétés personnalisées de la présentation permettent aux développeurs de stocker des métadonnées supplémentaires ou des informations spécifiques dans un fichier de présentation. Aspose.Slides facilite la création et la gestion de ces propriétés personnalisées par programme. Les exemples suivants démontrent comment ajouter des propriétés personnalisées à vos présentations.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation.
using Presentation presentation = new Presentation();

// Obtient une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ajoute des propriétés personnalisées.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Enregistre la présentation dans un fichier.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accès et modification des propriétés personnalisées**

Aspose.Slides permet également aux développeurs d’accéder aux propriétés personnalisées existantes et de modifier leurs valeurs facilement. Cette fonctionnalité aide à maintenir des métadonnées précises et prend en charge les mises à jour dynamiques basées sur les entrées utilisateur ou la logique métier. Les exemples ci‑dessous illustrent comment récupérer et mettre à jour les valeurs des propriétés personnalisées au sein d’une présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Obtient une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Accède et modifie les propriétés personnalisées.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Affiche le nom et la valeur de la propriété personnalisée.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifie la valeur de la propriété personnalisée.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Enregistre la présentation dans un fichier.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Exemple en direct**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les définir à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur actuelle sera écrasée par la nouvelle. Il n’est pas nécessaire de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger entièrement la présentation ?**

Oui. Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) puis [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/net/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.