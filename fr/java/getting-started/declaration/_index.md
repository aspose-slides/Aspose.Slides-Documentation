---
title: Déclaration
type: docs
weight: 60
url: /java/declaration/
---

{{% alert color="primary" %}} 

Tous les composants Aspose Java nécessitent un ensemble d'autorisations de Confiance Totale. La raison en est que les composants Aspose Java doivent accéder aux paramètres du registre, aux fichiers système autres que le répertoire virtuel pour certaines opérations telles que l'analyse des polices, etc. De plus, les composants Aspose Java sont basés sur des classes système Java de base qui nécessitent également un ensemble d'autorisations de Confiance Totale dans de nombreux cas. 

{{% /alert %}} 

Les fournisseurs de services Internet hébergeant plusieurs applications de différentes entreprises imposent généralement un niveau de sécurité de Confiance Médiane : 

- OleDbPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser le fournisseur de données OLE DB géré par ADO.NET pour accéder aux bases de données.
- EventLogPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au journal des événements Windows.
- ReflectionPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser la réflexion.
- RegistryPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre.
- WebPermission est restreint. Cela signifie que votre application peut uniquement communiquer avec une adresse ou une plage d'adresses que vous définissez dans l'élément <trust>.
- FileIOPermission est restreint. Cela signifie que vous ne pouvez accéder qu'aux fichiers dans la hiérarchie de répertoire virtuel de votre application.

{{% alert color="primary" %}} 

En raison des raisons spécifiées ci-dessus, les composants Aspose Java ne peuvent pas être utilisés sur des serveurs accordant un ensemble d'autorisations autre que la Confiance Totale. 

{{% /alert %}}