---
title: Exigences de niveau de confiance
type: docs
weight: 190
url: /fr/net/declaration/
keywords:
- niveau de confiance
- permission Confiance totale
- confiance partielle
- Confiance moyenne
- sécurité d'accès au code
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Quel niveau de confiance de la sécurité d'accès au code Aspose.Slides for .NET nécessite : confiance totale sur .NET Framework, et aucun paramètre de confiance sur .NET 6 et versions ultérieures."
---
## **Vue d'ensemble**

Code access security (CAS) trust levels existent uniquement dans .NET Framework. Cet article explique ce que cela signifie pour Aspose.Slides for .NET : la bibliothèque nécessite une confiance totale sur .NET Framework, et sur .NET 6 et versions ultérieures il n’y a aucun niveau de confiance à configurer.

## **.NET Framework**

Aspose.Slides nécessite une confiance totale sur .NET Framework. Il ne fonctionne pas en confiance partielle, comme une application ASP.NET configurée pour la Confiance Moyenne (`<trust level="Medium" />`) : la création d’un objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) échoue avec une `SecurityException`.

Microsoft ne considère plus la confiance partielle ASP.NET comme un moyen d’isoler les applications les unes des autres, et recommande d’exécuter les applications dans des pools d’applications distincts. Voir [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 et versions ultérieures**

La sécurité d’accès au code n’est pas disponible sur .NET 6 et les versions ultérieures, il n’existe donc aucun niveau de confiance à attribuer. Aspose.Slides s’exécute avec les permissions du compte qui exécute votre application. Pour restreindre ce qu’une application peut accéder, Microsoft recommande des frontières du système d’exploitation, telles que les comptes utilisateur, les conteneurs ou les machines virtuelles. Voir [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Puis-je utiliser Aspose.Slides avec un hébergeur qui exécute des applications ASP.NET en Confiance Moyenne ?**

Non en Confiance Moyenne. Sur .NET Framework, l’application qui utilise Aspose.Slides doit s’exécuter avec une confiance totale.