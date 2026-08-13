---
title: Déclaration
type: docs
weight: 60
url: /fr/java/declaration/
keywords:
- déclaration
- composants
- autorisation Full Trust
- paramètres du registre
- fichiers systèmes
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez les exigences de confiance, les autorisations et les limitations d'hébergement d'Aspose.Slides pour Java afin de pouvoir déployer en toute sécurité des applications qui traitent les fichiers PPT, PPTX et ODP sur les serveurs."
---
{{% alert color="info" %}}

Tous les composants Aspose Java nécessitent le jeu d'autorisations Full Trust. La raison est que les composants Aspose Java doivent accéder aux paramètres du registre, aux fichiers système autres que le répertoire virtuel pour certaines opérations comme l'analyse des polices, etc. De plus, les composants Aspose Java sont basés sur les classes système Java de base qui, dans de nombreux cas, requièrent également le jeu d'autorisations Full Trust.

{{% /alert %}}

Les fournisseurs d'accès à Internet hébergeant plusieurs applications provenant de différentes entreprises appliquent généralement le niveau de sécurité Medium Trust :

- OleDbPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser le fournisseur de données OLE DB géré ADO.NET pour accéder aux bases de données.
- EventLogPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au journal des événements Windows.
- ReflectionPermission n'est pas disponible. Cela signifie que vous ne pouvez pas utiliser la réflexion.
- RegistryPermission n'est pas disponible. Cela signifie que vous ne pouvez pas accéder au registre.
- WebPermission est restreint. Cela signifie que votre application ne peut communiquer qu'avec une adresse ou une plage d'adresses que vous définissez dans l'élément <trust>.
- FileIOPermission est restreint. Cela signifie que vous ne pouvez accéder qu'aux fichiers de la hiérarchie du répertoire virtuel de votre application.

{{% alert color="info" %}}

En raison des raisons mentionnées ci-dessus, les composants Aspose Java ne peuvent pas être utilisés sur des serveurs accordant un jeu d'autorisations autre que Full Trust.

{{% /alert %}}