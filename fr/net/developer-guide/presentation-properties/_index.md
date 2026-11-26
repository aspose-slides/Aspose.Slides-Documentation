---
title: Gérer les propriétés de présentation dans .NET
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
- Langue de vérification
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

Aspose.Slides for .NET prend en charge les propriétés de document **intégrées** et **personnalisées**. Utilisez ces propriétés pour lire et mettre à jour les métadonnées d’une présentation, telles que l’auteur, le titre et les valeurs définies par l’utilisateur.

Aspose.Slides vous permet de travailler avec les propriétés de document d’une présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Aspose.Slides gère les métadonnées d’application et du producteur lors de l’enregistrement des présentations ; ces champs identifient le logiciel qui a créé le résultat.
{{% /alert %}}

## **Gérer les propriétés de la présentation**

Les propriétés de document stockent des informations descriptives à côté du contenu de la présentation. Elles se répartissent en deux catégories :

- **Propriétés intégrées** contiennent des métadonnées standard, telles que le titre, l’auteur et les statistiques du document.
- **Propriétés personnalisées** stockent des paires nom/valeur définies par l’utilisateur.

Aspose.Slides for .NET donne accès aux deux catégories. Dans PowerPoint, choisissez **Fichier → Info → Propriétés → Propriétés avancées** pour examiner les métadonnées du document. La boîte de dialogue regroupe les informations dans des onglets tels que **Résumé**, **Statistiques**, **Contenu** et **Personnalisé**. Utilisez l’onglet **Personnalisé** pour gérer les propriétés définies par l’utilisateur.

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsqu’une présentation est chiffrée avec [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) défini sur `false`, ses propriétés de document restent publiques. Une application peut alors définir [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) sur `true` et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) contrôle ce que Aspose.Slides charge ; il ne déchiffre rien. Si les propriétés ont été incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple nécessite une présentation chiffrée dont les propriétés de document ont été laissées publiques. Il vérifie le mode de chargement via [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) puis lit les propriétés intégrées via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) :

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, mises en page, formes, médias et autres objets de la présentation ne sont pas disponibles. Les applications doivent toujours vérifier [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Security" %}}
Les métadonnées publiques peuvent révéler les noms d’auteur, les titres, les sujets, les mots‑clé, les informations d’entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsqu’un système d’indexation, de classification, de recherche ou de gestion de documents a besoin d’y accéder sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée avec [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) est destinée à lire les métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet contenant uniquement les métadonnées, car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple nécessite une présentation PPTX chiffrée avec des propriétés de document publiques et un mot de passe d’ouverture connu. Il ouvre la présentation complète avec [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

L’interface [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) expose les métadonnées intégrées via des propriétés typées, notamment [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) et [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Cet exemple ouvre une présentation existante et affiche ses métadonnées stockées dans la console. Les valeurs dépendent de la présentation d’entrée ; certains champs peuvent être vides.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Signaler le numéro de révision et le temps d’édition**

Pour signaler une ligne pour chaque fichier PPTX du dossier `presentations`, appelez [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) afin de récupérer son [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) sans charger les diapositives pour l’édition. Le format standard `c` pour `TimeSpan` inclut le nombre de jours lorsque la durée atteint 24 heures.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Exemple de sortie pour une présentation avec 1 jour, 2 heures et 5 minutes de temps d’édition enregistré :

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) est une métadonnée modifiable. Sa valeur seule ne permet pas de déterminer combien de fois la présentation a été enregistrée ni de reconstruire son historique de versions.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) est la durée d’édition enregistrée dans le fichier. Une valeur de `00:00:00` signifie que la durée stockée est nulle. Cela ne prouve pas que personne n’a modifié la présentation.

## **Modifier les propriétés intégrées**

Pour mettre à jour les métadonnées intégrées, attribuez des valeurs aux propriétés modifiables exposées par [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Cet exemple ouvre une présentation existante, définit [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), et [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), puis enregistre la présentation mise à jour avec [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Le PPTX enregistré contient les nouvelles métadonnées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Gérer la base des hyperliens**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) stocke la base au niveau du document pour les hyperliens relatifs. Cela est utile lors du déplacement d’une présentation et de ses fichiers liés vers un autre emplacement. Elle est distincte de [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) d’un hyperlien individuel : modifier la base ne réécrit pas les adresses de liens stockées ni ne change les destinations absolues.

L’exemple nécessite une présentation contenant à la fois un lien relatif, comme `target.html`, et un lien absolu, comme `https://example.org/absolute.html`. Il lit la base existante, attribue une nouvelle adresse de base, puis enregistre et rouvre la présentation pour vérifier la valeur. Il efface ensuite la base avec `string.Empty` et vérifie la valeur vide dans un fichier enregistré séparé. Remplacez l’adresse de base d’exemple par l’emplacement de vos fichiers liés.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Les deux messages de vérification doivent afficher `True`. Effacer la base laisse intactes les adresses des hyperliens individuels.

Un lien relatif vers `target.pptx` ouvrait `old/target.pptx` lorsque la base pointait vers le dossier `old`. Après avoir changé la base vers le dossier `new`, enregistré et rouvert la présentation, le même lien a ouvert `new/target.pptx`. Un lien absolu a continué d’ouvrir le même fichier. Testez vos liens relatifs dans PowerPoint avant et après avoir déplacé la présentation ou modifié sa base.

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées stockent des métadonnées qui n’ont aucun champ intégré correspondant. L’[indexeur IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) vous permet d’attribuer une valeur par nom de propriété. Cet exemple crée une présentation, ajoute deux valeurs texte et une valeur entière de version, puis enregistre la présentation avec [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Attribuer une valeur à un nom existant remplace la valeur de cette propriété.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accéder et modifier les propriétés personnalisées**

Cet exemple ouvre une présentation contenant des propriétés personnalisées et utilise [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) pour les parcourir. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) accepte un indice basé sur zéro et renvoie le nom utilisé par l’[indexeur IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). L’exemple affiche chaque nom et valeur d’origine, remplace chaque valeur par une chaîne numérotée quel que soit son type d’origine, puis enregistre les modifications. S’il n’y a aucune propriété personnalisée, la boucle ne fait aucun changement.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Exemple en direct**

Essayez l’application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document à l’aide de l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être complètement supprimées. Cependant, vous pouvez soit modifier leurs valeurs, soit les laisser vides si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) puis [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/net/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée avec [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) défini sur `false`, et elle doit être chargée avec [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) défini sur `true`.

**Puis‑je mettre à jour un fichier PPTX chiffré en mode uniquement‑propriétés‑de‑document ?**

Non. Les données des propriétés publiques et chiffrées doivent rester cohérentes, ainsi la mise à jour d’un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.