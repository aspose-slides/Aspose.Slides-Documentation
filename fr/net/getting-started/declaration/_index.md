---
title: Déclaration
type: docs
weight: 110
url: /fr/net/declaration/
---

{{% alert color="primary" %}} 

Tous les composants Aspose .NET nécessitent un ensemble de permissions Full Trust car ils doivent parfois accéder aux paramètres du registre, aux fichiers système et aux fichiers stockés dans d'autres emplacements (en dehors du répertoire virtuel) pour certaines opérations (par exemple, le parsing de polices). De plus, les composants Aspose .NET sont basés sur des classes système core .NET, qui nécessitent également un ensemble de permissions Full Trust dans de nombreux cas. 

{{% /alert %}} 

Les fournisseurs de services Internet, qui hébergent plusieurs applications de différentes entreprises, appliquent principalement le niveau de sécurité Medium Trust. Dans le cas de .NET 2.0, un tel niveau de sécurité impose les contraintes suivantes : 

- OleDbPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser le fournisseur de données OLE DB géré par ADO.NET pour accéder aux bases de données.
- EventLogPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au journal des événements Windows.
- ReflectionPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser la réflexion.
- RegistryPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre.
- WebPermission est restreint. Cela signifie que votre application ne peut communiquer qu'avec une adresse ou la plage d'adresses que vous avez définies dans l'élément <trust>.
- FileIOPermission est restreint. Cela signifie que vous ne pouvez accéder qu'aux fichiers dans la hiérarchie de répertoires virtuels de votre application.

{{% alert color="primary" %}} 

En raison des raisons énoncées ci-dessus, les composants Aspose .NET ne peuvent être utilisés que sur des serveurs qui accordent l'ensemble de permissions Full Trust. 

{{% /alert %}}