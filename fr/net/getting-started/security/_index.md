---
title: Sécurité
type: docs
weight: 160
url: /fr/net/security/
keywords:
- sécurité
- dépendances
- composants tiers
- NuGet
- analyse des vulnérabilités
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez comment Aspose.Slides for .NET traite les présentations, quels packages NuGet il utilise pour chaque framework cible, et quels composants tiers il inclut."
---
## **Sécurité dans Aspose.Slides**

* Aspose.Slides for .NET est utilisé pour manipuler des présentations et les convertir vers d’autres formats. Il n’exécute pas de scripts dans les présentations. Aspose.Slides analyse la structure de la présentation et permet au code de l’utilisateur final de manipuler le modèle d’objets de façon pratique.
* Aspose.Slides fonctionne comme une bibliothèque qui analyse et interprète les documents sans exécuter de code distant. Tous les produits Aspose s’exécutent sur vos machines. Ils ne transmettent aucune donnée à Aspose. La seule exception est une [licence à la consommation](https://purchase.aspose.com/faqs/licensing/metered) : si vous en utilisez une, seules les informations d’utilisation de votre API sont traitées.
* Les composants Aspose s’exécutent dans le même contexte utilisateur que les applications classiques. Par conséquent, les composants Aspose ne présentent aucun risque pour les ressources système essentielles. De plus, lorsqu’un composant Aspose ouvre un document, les macros ne sont pas exécutées automatiquement.
* Les risques inhérents ou associés à la suite Microsoft Office ne s’appliquent pas aux composants Aspose, ainsi les produits Aspose sont très sécurisés.

## **Dépendances NuGet**

Aspose.Slides for .NET dépend de packages publiés par Microsoft sur NuGet. Les dépendances varient selon le package et le framework cible :

| Paquet | Framework cible | Dépendances |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

La section **Dependencies** de la page [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) et de la page [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) sur NuGet répertorie la version minimale de chaque dépendance pour chaque version.

Lorsque vous ajoutez Aspose.Slides à un projet, NuGet restaure également les dépendances de ces packages. Pour lister chaque package que votre projet restaure, y compris ces dépendances transitoires, exécutez cette commande dans le dossier du projet :

```bash
dotnet list package --include-transitive
```

Pour vérifier le même ensemble de packages contre les vulnérabilités connues, exécutez :

```bash
dotnet list package --vulnerable --include-transitive
```

Pour d’autres méthodes d’audit des packages NuGet, consultez [Audit des dépendances de packages pour les vulnérabilités de sécurité](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Composants tiers**

Aspose.Slides inclut du code provenant de composants open source tiers. Ils font partie du produit, et ne sont pas des packages NuGet séparés, de sorte que les outils qui ne lisent que les dépendances NuGet ne les répertorient pas. Les deux packages contiennent le fichier *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, qui répertorie les composants et leurs licences :

| Composant | Licence indiquée dans l'avis |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Quels systèmes sont utilisés pour surveiller les vulnérabilités dans le code Aspose ?**

Nous effectuons une analyse statique du code pour chaque version d’Aspose.Slides. Nous pouvons fournir des rapports de sécurité qui prouvent que le code d’Aspose.Slides respecte le Top 10 OWASP.

**Aspose.Slides utilise-t‑il des packages externes ?**

Oui. Il dépend des packages NuGet de Microsoft répertoriés dans [Dépendances NuGet](#nuget-dependencies), et il inclut les composants tiers répertoriés dans [Composants tiers](#third-party-components). Incluez les deux dans votre analyse de sécurité, et utilisez `dotnet list package --vulnerable --include-transitive` pour vérifier les packages NuGet que votre projet restaure.