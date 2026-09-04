---
title: Gérer les propriétés de présentation en .NET
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/net/presentation-properties/
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
- Langue de révision
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour .NET et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides pour .NET prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Ces deux types de propriétés peuvent être facilement accessibles et gérées à l’aide de l’API Aspose.Slides pour .NET.

Aspose.Slides vous permet de travailler avec les propriétés de document d’une présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **Producer** ne peuvent pas être modifiés, car ils afficheront toujours « Aspose Ltd. » et « Aspose.Slides for .NET x.x.x ».
{{% /alert %}} 

## **Gérer les propriétés de la présentation**

Microsoft PowerPoint fournit une fonction permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les fichiers. Il existe deux types de propriétés de document :

- Propriétés définies par le système (built-in)
- Propriétés définies par l’utilisateur (custom)

Les propriétés **Built-in** contiennent des informations générales sur le document, telles que le titre du document, le nom de l’auteur, les statistiques du document, etc.

Les propriétés **Custom** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, le nom et la valeur étant spécifiés par l’utilisateur.

Avec Aspose.Slides pour .NET, les développeurs peuvent accéder et modifier à la fois les propriétés intégrées et personnalisées.

Microsoft PowerPoint permet aux utilisateurs de gérer les propriétés de document en cliquant sur l’icône Office, puis en sélectionnant **File → Info → Properties**. Après avoir choisi **Advanced Properties**, une boîte de dialogue apparaît où vous pouvez gérer toutes les propriétés du document du fichier de présentation.

Dans la boîte de dialogue **Properties**, plusieurs onglets sont disponibles, tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Chaque onglet offre des options de configuration pour des types d’informations spécifiques liées au fichier PowerPoint. L’onglet **Custom** sert à gérer les propriétés définies par l’utilisateur.

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège normalement le contenu de la présentation ainsi que les propriétés du document. Lorsqu’une présentation est chiffrée avec [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) réglé sur `false`, ses propriétés de document restent publiques. Une application peut alors définir [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) sur `true` et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

`OnlyLoadDocumentProperties` contrôle ce qu’Aspose.Slides charge ; il ne décrypte rien. Si les propriétés sont incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) puis lit les propriétés intégrées via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/documentproperties/) :

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, les maîtres, les mises en page, les formes, les médias et les autres objets de présentation ne sont pas disponibles. Les applications doivent toujours vérifier `IsOnlyDocumentPropertiesLoaded` avant d’effectuer une opération nécessitant le modèle complet d’objets de la présentation.

{{% alert color="warning" title="Security" %}}
Les métadonnées publiques peuvent révéler les noms d’auteur, les titres, les sujets, les mots‑clé, les informations d’entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont un besoin spécifique d’y accéder sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée avec `OnlyLoadDocumentProperties` sert à lire les métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet « metadata‑only » car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/isencrypted/) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX chiffré comme en lecture‑seule.

## **Accéder aux propriétés intégrées**

Ces propriétés, exposées par l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/), comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (indique si le document est partagé entre différents producteurs), **PresentationFormat**, **Subject**, **Title**, etc.

```cs
using Aspose.Slides;

// Instanciez la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Obtenez une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Affichez les propriétés intégrées.
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

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d’y accéder. Il suffit d’attribuer une chaîne de caractères à la propriété souhaitée, et la valeur sera mise à jour. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées d’un fichier de présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Obtenez une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Définissez les propriétés intégrées.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Enregistrez la présentation dans un fichier.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées de la présentation permettent aux développeurs de stocker des métadonnées supplémentaires ou des informations spécifiques dans un fichier de présentation. Aspose.Slides facilite la création et la gestion de ces propriétés personnalisées par programme. Les exemples suivants démontrent comment ajouter des propriétés personnalisées à vos présentations.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation.
using Presentation presentation = new Presentation();

// Obtenez une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ajoutez des propriétés personnalisées.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Enregistrez la présentation dans un fichier.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides permet également aux développeurs d’accéder aux propriétés personnalisées existantes et de modifier leurs valeurs facilement. Cette fonctionnalité aide à maintenir des métadonnées précises et prend en charge les mises à jour dynamiques en fonction des entrées utilisateur ou de la logique métier. Les exemples ci‑dessous illustrent comment récupérer et mettre à jour les valeurs des propriétés personnalisées au sein d’une présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Obtenez une référence à l'objet de type IDocumentProperties associé à la présentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Affichez le nom et la valeur de la propriété personnalisée.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifiez la valeur de la propriété personnalisée.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Enregistrez la présentation dans un fichier.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Exemple en direct**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les définir à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera remplacée par la nouvelle. Il n’est pas nécessaire de la supprimer ou de la vérifier au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) puis [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Voir [Build a Lightweight Presentation Inventory](/slides/fr/net/examine-presentation/) pour un exemple complet de génération de rapports et les limitations propres aux formats.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée avec `EncryptDocumentProperties` réglé sur `false`, et elle doit être chargée avec `OnlyLoadDocumentProperties` réglé sur `true`.

**Puis‑je mettre à jour un fichier PPTX chiffré en mode lecture‑seule des propriétés du document ?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, donc la mise à jour d’un fichier PPTX chiffré nécessite le chargement complet de la présentation avec le mot de passe d’ouverture correct.