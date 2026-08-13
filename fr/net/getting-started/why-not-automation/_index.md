---
title: Pourquoi ne pas automatiser
type: docs
weight: 40
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
description: "Découvrez pourquoi l'automatisation Office est risquée pour les serveurs et les services, et voyez comment Aspose.Slides offre un traitement des présentations plus sûr et plus rapide pour PowerPoint et OpenDocument."
---
## **Introduction**

Il existe plusieurs raisons pour lesquelles les composants Aspose constituent une meilleure alternative à l'automatisation. Parmi les raisons principales :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Vous trouverez ci‑dessous une explication plus détaillée de chaque point clé.

## **Questions importantes**

Il y a deux questions que nous entendons souvent chez Aspose :

- Vos produits nécessitent-ils que Microsoft Office soit installé pour fonctionner ?

La réponse courte et simple est **NON**.

Les composants Aspose sont totalement indépendants et ne sont ni affiliés, ni autorisés, ni sponsorisés, ni approuvés de quelque manière que ce soit par Microsoft Corporation.

- Pourquoi devrions‑nous utiliser les produits Aspose plutôt que l’automatisation Microsoft Office ?

Tout d’abord, il existe de nombreux [avantages dont vous bénéficiez lorsque vous utilisez Aspose.Slides](/slides/fr/net/product-overview/).

Ensuite, Microsoft elle‑même déconseille fortement **d’utiliser** l’automatisation Office à partir de solutions logicielles.

## **Sécurité**
Voici une citation directe d’un article Microsoft :

> "Les applications Office n’ont jamais été conçues pour une utilisation côté serveur et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n’authentifie pas les requêtes entrantes et ne vous protège pas contre l’exécution involontaire de macros, ou le lancement d’un autre serveur qui pourrait exécuter des macros, depuis votre code côté serveur. N’ouvrez pas les fichiers qui sont téléchargés sur le serveur depuis le Web anonyme ! En fonction des paramètres de sécurité qui ont été définis en dernier, le serveur peut exécuter des macros sous le contexte Administrateur ou Système avec des privilèges complets et compromettre votre réseau ! De plus, Office utilise de nombreux composants côté client (comme Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d’authentification du client afin d’accélérer le traitement. Si Office est automatisé côté serveur, une instance peut servir plusieurs clients et, comme les informations d’authentification ont été mises en cache pour cette session, il est possible qu’un client utilise les informations d’identification mises en cache d’un autre client, obtenant ainsi des autorisations d’accès non accordées en se faisant passer pour d’autres utilisateurs."

Les produits Aspose sont très **sécurisés**. Les composants Aspose s’exécutent dans le même contexte utilisateur que toutes les applications ASP.NET (sous l’utilisateur ASPNET). Ainsi, les composants Aspose ne **représentent pas** un risque de sécurité. Ils ne consomment pas non plus de ressources système critiques. De plus, lorsqu’un composant Aspose ouvre un document, les macros ne sont pas exécutées automatiquement. Les composants Aspose ont été conçus pour permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office.

{{% alert color="info" %}} 

Aucun des risques associés au package Microsoft Office ne s’applique aux composants Aspose.

{{% /alert %}} 

## **Stabilité**
Ce texte est une citation directe de l’article Microsoft précédemment référencé :

> "Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) pour faciliter l’installation et l’auto‑réparation pour l’utilisateur final. MSI introduit le concept d’« installation lors de la première utilisation », qui permet d’installer ou de configurer dynamiquement des fonctionnalités au moment de l’exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit les performances et augmente la probabilité qu’une boîte de dialogue apparaisse pour demander à l’utilisateur d’approuver l’installation ou de fournir un disque d’installation approprié. Bien qu’il soit conçu pour augmenter la résilience d’Office en tant que produit destiné à l’utilisateur final, l’implémentation par Office des capacités MSI est contre‑productive dans un environnement côté serveur. De plus, la stabilité d’Office en général ne peut pas être assurée lorsqu’il est exécuté côté serveur car il n’a pas été conçu ni testé pour ce type d’utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, par conséquent, de l’ensemble de votre réseau. Si vous prévoyez d’automatiser Office côté serveur, essayez d’isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques et qui peut être redémarré si nécessaire."

Comme les composants Aspose sont empaquetés dans une seule DLL, leurs utilisateurs n’ont jamais besoin d’installer des parties ou des pièces supplémentaires pour qu’ils fonctionnent. Les composants Aspose sont uniquement utilisés par les applications .NET et aucune partie du code du composant n’est conçue pour attendre une réponse humaine.

{{% alert color="info" %}} 

Les composants Aspose ont été testés en profondeur et confirmés comme étant très stables. Les composants Aspose sont utilisés par [entreprises](http://www.aspose.com/Corporate/Aspose/Customerlist.html) telles que **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, et de nombreuses autres organisations leaders dans plusieurs secteurs et domaines.

{{% /alert %}} 

## **Scalabilité/Vitesse**
Voici une citation directe d’un article Microsoft :

> "Les composants côté serveur doivent être des composants COM hautement réentrants, multithreads, avec un minimum de surcharge et un débit élevé pour plusieurs clients. Les applications Office sont, à bien des égards, exactement le contraire. Elles sont des serveurs d’automatisation non réentrants, basés sur STA, conçus pour fournir des fonctionnalités diverses mais gourmandes en ressources pour un seul client. Elles offrent peu de scalabilité en tant que solution côté serveur et ont des limites fixes sur des éléments importants, tels que la mémoire, qui ne peuvent pas être modifiées par configuration. Plus important encore, elles utilisent des ressources globales (comme les fichiers mémoire-mappés, les modules complémentaires ou modèles globaux, et les serveurs d’automatisation partagés), ce qui peut limiter le nombre d’instances pouvant s’exécuter simultanément et entraîner des conditions de concurrence si elles sont configurées dans un environnement multi‑client. Les développeurs qui prévoient d’exécuter plusieurs instances d’une application Office en même temps doivent envisager le pool ou la sérialisation d’accès à l’application Office afin d’éviter d’éventuels interblocages ou corruptions de données."

Les composants Aspose sont incroyablement scalables et ultra rapides. Les applications Office n’ont pas été conçues pour être utilisées simultanément par des centaines ou des milliers d’utilisateurs, mais les composants Aspose sont précisément conçus pour cela. Nos composants sont une véritable solution .NET.

{{% alert color="info" %}} 

Les performances des composants Aspose sont impeccables sur un serveur unique (alimentant une application unique) ou sur un formulaire web réparti (alimentant une application d’entreprise à grande échelle).

{{% /alert %}} 

## **Prix**
Lorsqu’une application utilise l’automatisation Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine qui exécute l’application. Il existe de nombreuses instances où une application peut devoir créer ou manipuler un fichier Office, mais le processus ne nécessite pas Microsoft Office.

{{% alert color="info" %}} 

Aspose propose une licence de redistribution très [rentable](https://purchase.aspose.com/) et sans redevance qui permet un déploiement à un nombre illimité d’utilisateurs sans souci de licence.

{{% /alert %}} 

Lors de la création d’applications web, il est important de se rappeler que les composants d’automatisation Microsoft Office ne sont ni tarifés ni licenciés pour les solutions côté serveur. Par conséquent, il n’existe aucune solution de licence adaptée pour le déploiement d’applications web utilisant des composants Microsoft Office. Aspose, en revanche, propose une solution très [rentable](https://purchase.aspose.com/) pour les applications basées sur serveur également.

## **Fonctionnalités**
Les composants Aspose offrent tout ce qui est nécessaire pour gérer les fichiers Office et bien plus encore. Nous les avons conçus selon notre philosophie d’aider les développeurs à obtenir les meilleurs résultats possibles avec le moins d’effort.

{{% alert color="info" %}} 

Contrairement à l’automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et permettant de gagner du temps.

{{% /alert %}} 

Par exemple, [Aspose.Cells](https://products.aspose.com/cells/net/) permet aux développeurs d’importer des données depuis une **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) offre une fonction similaire qui permet aux développeurs de remplir un document Word (c’est‑à‑dire une fusion de courrier) directement à partir de n’importe quel objet de données .NET. [Chaque composant](https://products.aspose.com/total/net/) de la famille Aspose propose son propre ensemble de fonctionnalités uniques et puissantes.

La meilleure partie de l’achat d’un composant Aspose est d’obtenir l’accès à nos équipes de développement. Par exemple, si vous utilisez des objets d’automatisation Office et avez besoin de certaines fonctionnalités, les chances que ces fonctionnalités soient ajoutées sont très, très faibles. Cependant, les choses sont différentes avec les composants Aspose.

{{% alert color="info" %}} 

Nos équipes de développement comprennent que si votre entreprise a besoin d’une fonctionnalité, il y a de fortes chances que d’autres entreprises aient la même demande. Bien que nous sachions que nous ne pouvons pas implémenter chaque fonctionnalité demandée, nous nous efforçons d’ajouter le plus grand nombre possible de fonctionnalités en nous basant sur les retours de nos clients.

{{% /alert %}} 

Nos équipes sont toujours ouvertes d’esprit et flexibles lorsqu’elles offrent de l’assistance — et c’est la raison pour laquelle les composants Aspose sont devenus aussi puissants aujourd’hui.

## **Conclusion**
{{% alert color="info" %}} 

Bien que cet article ait couvert certains des points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l’automatisation Office, vous devez comprendre qu’il existe de nombreux, nombreux avantages supplémentaires. Nous n’avons abordé que quelques‑unes des principales atouts.

De plus, tous les produits et composants Aspose offrent une [Version d’évaluation](https://downloads.aspose.com/slides/fr/net) sans risque et sans obligation. Nous vous encourageons à profiter de l’évaluation pour voir ce qu’Aspose peut faire pour vos applications ou votre entreprise.

{{% /alert %}}