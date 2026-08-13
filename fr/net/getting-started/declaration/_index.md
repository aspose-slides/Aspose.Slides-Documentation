---
title: Déclaration
type: docs
weight: 110
url: /fr/net/declaration/
keywords:
- déclaration
- composants
- autorisation Full Trust
- paramètres du registre
- fichiers système
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez les exigences de confiance, les autorisations et les limitations d'hébergement d'Aspose.Slides pour .NET afin de pouvoir déployer en toute sécurité des applications qui traitent les fichiers PPT, PPTX et ODP sur les serveurs."
---
{{% alert color="info" %}}
Tous les composants Aspose .NET exigent le jeu d’autorisations Full Trust car ils doivent parfois accéder aux paramètres du registre, aux fichiers système et aux fichiers stockés dans d’autres emplacements (en dehors du répertoire virtuel) pour certaines opérations (par exemple l’analyse des polices). De plus, les composants Aspose .NET sont basés sur les classes système de base .NET, qui nécessitent le jeu d’autorisations Full Trust dans de nombreux cas.
{{% /alert %}}
Les fournisseurs d’accès à Internet, qui hébergent plusieurs applications provenant de différentes entreprises, appliquent généralement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, ce niveau de sécurité impose les contraintes suivantes :
- OleDbPermission n’est pas disponible. Cela signifie que vous ne pouvez pas utiliser le fournisseur de données OLE DB géré d’ADO.NET pour accéder aux bases de données.
- EventLogPermission n’est pas disponible. Cela signifie que vous ne pouvez pas accéder au journal des événements Windows.
- ReflectionPermission n’est pas disponible. Cela signifie que vous ne pouvez pas utiliser la réflexion.
- RegistryPermission n’est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre.
- WebPermission est restreint. Cela signifie que votre application ne peut communiquer qu’avec une adresse ou une plage d’adresses que vous avez définies dans l’élément <trust>.
- FileIOPermission est restreint. Cela signifie que vous ne pouvez accéder qu’aux fichiers de la hiérarchie du répertoire virtuel de votre application.
{{% alert color="info" %}}
En raison des raisons ci-dessus, les composants Aspose .NET ne peuvent être utilisés que sur des serveurs qui accordent le jeu d’autorisations Full Trust.
{{% /alert %}}