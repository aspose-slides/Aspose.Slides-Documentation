---
title: Pourquoi pas l'automatisation
type: docs
weight: 170
url: /fr/net/why-not-automation/
keywords:
- automatisation
- Microsoft Office
- comparaison
- sécurité
- stabilité
- évolutivité
- fonctionnalités
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez pourquoi l'automatisation Office est risquée pour les serveurs et les services, et voyez comment Aspose.Slides offre un traitement de présentation plus sûr et plus rapide pour PowerPoint et OpenDocument."
---
## **Introduction**

Il existe plusieurs raisons pour lesquelles les composants Aspose constituent une meilleure alternative à l'automatisation. Parmi les raisons clés figurent :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Vous trouverez ci‑dessous une explication plus détaillée de chaque point clé.

## **Questions importantes**

Nous entendons souvent deux questions chez Aspose :

- Vos produits nécessitent‑ils l'installation de Microsoft Office pour fonctionner ?

La réponse courte et simple est **NON**.

Les composants Aspose sont complètement indépendants et n'ont aucun lien, aucune autorisation, aucun parrainage ou aucune approbation de la part de Microsoft Corporation.

- Pourquoi devrions‑nous utiliser les produits Aspose au lieu de l'automatisation Microsoft Office ?

Tout d'abord, il existe de nombreux [les avantages dont vous bénéficiez lorsque vous utilisez Aspose.Slides](/slides/fr/net/product-overview/).

Ensuite, Microsoft lui‑même déconseille fortement **d'utiliser** l'automatisation Office dans les solutions logicielles.

## **Sécurité**
Voici une citation directe d'un article Microsoft :

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non‑granted access permissions by impersonating other users."

Les produits Aspose sont très **sécurisés**. Les composants Aspose s’exécutent dans le même contexte utilisateur que toutes les applications ASP.NET (sous l'utilisateur ASPNET). Par conséquent, les composants Aspose ne constituent **pas** un risque de sécurité. Ils ne consomment pas non plus de ressources système critiques. De plus, lorsqu’un composant Aspose ouvre un document, les macros ne s’exécutent pas automatiquement. Les composants Aspose ont été créés pour permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office.

{{% alert color="info" title="Note" %}}
Aucun des risques associés au paquet Microsoft Office ne s’appliquent aux composants Aspose.
{{% /alert %}}

## **Stabilité**
Ce texte est une citation directe de l’article Microsoft mentionné précédemment :

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Comme les composants Aspose sont fournis dans un seul DLL, leurs utilisateurs n’ont jamais besoin d’installer des parties supplémentaires pour les faire fonctionner. Les composants Aspose ne sont utilisés que par des applications .NET et aucune portion du code du composant n’est conçue pour attendre une réponse humaine.

{{% alert color="info" title="Note" %}}
Les composants Aspose ont été minutieusement testés et sont très stables. Ils sont utilisés par [entreprises](https://about.aspose.com/customers/) telles que **Bank of America** et de nombreuses autres organisations de premier plan dans plusieurs secteurs.
{{% /alert %}}

## **Scalabilité/Vitesse**
Voici une citation directe d'un article Microsoft :

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Les composants Aspose sont extrêmement scalables et ultra‑rapides. Les applications Office n’ont pas été conçues pour être utilisées simultanément par des centaines ou des milliers d’utilisateurs, alors que les composants Aspose le sont précisément. Nos composants sont une vraie solution .NET.

{{% alert color="info" title="Note" %}}
Les performances des composants Aspose sont irréprochables sur un serveur unique (alimentant une seule application) ou sur un formulaire web en équilibrage de charge (alimentant une application d’entreprise).
{{% /alert %}}

## **Prix**
Lorsque qu’une application utilise l’automatisation Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine exécutant l’application. De nombreuses instances d’une application peuvent créer ou manipuler un fichier Office, mais le processus ne nécessite pas Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose propose une licence de redistribution très [rentable](https://purchase.aspose.com/) et sans redevance qui permet le déploiement à un nombre illimité d’utilisateurs sans souci de licence.
{{% /alert %}}

Lors du développement d’applications web, il faut se rappeler que les composants d’automatisation Microsoft Office ne sont ni tarifés ni licenciés pour les solutions côté serveur. Ainsi, il n’existe aucune solution de licence adaptée au déploiement d’applications web utilisant les composants Microsoft Office. Aspose, en revanche, propose une solution très [rentable](https://purchase.aspose.com/) pour les applications serveur également.

## **Fonctionnalités**
Les composants Aspose offrent tout ce qui est nécessaire pour gérer les fichiers Office, et bien plus encore. Nous les avons conçus selon notre philosophie d’aider les développeurs à obtenir les meilleurs résultats possibles avec le moindre effort.

{{% alert color="info" title="Note" %}}
Contrairement à l’automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et qui font gagner du temps.
{{% /alert %}}

Par exemple, [Aspose.Cells](https://products.aspose.com/cells/net/) permet aux développeurs d’importer des données depuis une **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) propose une fonctionnalité similaire qui permet de remplir un document Word (c’est‑à‑dire une fusion de courrier) directement à partir de tout objet de données .NET. [Chaque composant](https://products.aspose.com/total/net/) de la famille Aspose propose son propre ensemble de fonctionnalités uniques et puissantes.

Le meilleur avantage d’acheter un composant Aspose est l’accès à nos équipes de développement. Par exemple, si vous utilisez des objets d’automatisation Office et avez besoin de certaines fonctionnalités, les chances que ces fonctionnalités soient ajoutées sont très, très faibles. Cependant, la situation est différente avec les composants Aspose.

{{% alert color="info" title="Note" %}}
Nos équipes de développement comprennent que si une fonctionnalité est nécessaire à votre entreprise, il y a de fortes chances que d’autres sociétés en aient également besoin. Bien que nous sachions que nous ne pouvons pas implémenter chaque fonctionnalité demandée, nous nous efforçons d’ajouter le plus grand nombre possible de fonctionnalités en fonction des retours de nos clients.
{{% /alert %}}

Nos équipes sont toujours ouvertes d’esprit et flexibles lorsqu’il s’agit d’apporter de l’aide — et c’est la raison pour laquelle les composants Aspose sont devenus aussi puissants qu’ils le sont aujourd’hui.

## **Conclusion**
{{% alert color="info" title="Note" %}}
Bien que cet article ait présenté certains des points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l’automatisation Office, vous devez comprendre qu’il existe de nombreux autres avantages. Nous n’avons présenté que quelques-uns des principaux avantages.

De plus, tous les produits et composants Aspose offrent une [Version d’Évaluation](https://releases.aspose.com/slides/net/) sans risque et sans engagement. Nous vous encourageons à profiter de l’évaluation pour découvrir ce qu’Aspose peut faire pour vos applications ou votre entreprise.
{{% /alert %}}