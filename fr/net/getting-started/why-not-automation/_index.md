---
title: Pourquoi Pas d'Automatisation
type: docs
weight: 40
url: /fr/net/why-not-automation/
---

## **Questions Importantes**
- Pourquoi les composants Aspose sont-ils une bien meilleure option que l'automatisation de Microsoft Office ?

Il y a deux questions que nous entendons souvent chez Aspose :

- Vos produits nécessitent-ils que Microsoft Office soit installé pour fonctionner ?

La réponse courte et simple—**NON**.

Aspose et les composants Aspose sont totalement indépendants et ne sont pas affiliés, ni autorisés, sponsorisés ou autrement approuvés par Microsoft Corporation.

- Pourquoi devrions-nous utiliser les produits Aspose au lieu d'utiliser l'automatisation de Microsoft Office ?

Premièrement, il y a de nombreux [avantages que vous bénéficiez en utilisant Aspose.Slides](https://docs.aspose.com/slides/net/product-overview/).

Deuxièmement, Microsoft lui-même **déconseille fortement** l'utilisation de l'automatisation Office à partir de solutions logicielles.

## **Aperçu**
Comme nous l'avons mentionné précédemment, il existe plusieurs raisons pour lesquelles les composants Aspose sont une meilleure alternative à l'automatisation. Certaines des raisons clés sont :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Nous avons développé les raisons clés dans les paragraphes ci-dessous.
## **Sécurité**
Ce qui suit est une citation directe d'un article Microsoft :

> "Les applications Office n'ont jamais été conçues pour une utilisation côté serveur, et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n'authentifie pas les demandes entrantes et ne vous protège pas de l'exécution involontaire de macros, ou du démarrage d'un autre serveur qui pourrait exécuter des macros, à partir de votre code côté serveur. N'ouvrez pas de fichiers qui sont téléchargés sur le serveur depuis un Web anonyme ! En fonction des paramètres de sécurité qui ont été définis pour la dernière fois, le serveur peut exécuter des macros dans le contexte d'un Administrateur ou d'un Système avec des privilèges complets et compromettre votre réseau ! De plus, Office utilise de nombreux composants côté client (comme Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d'authentification du client afin d'accélérer le traitement. Si Office est automatisé côté serveur, une instance peut desservir plus d'un client, et comme les informations d'authentification ont été mises en cache pour cette session, il est possible qu'un client puisse utiliser les identifiants mis en cache d'un autre client, et ainsi obtenir des autorisations d'accès non accordées en usurpant d'autres utilisateurs."

Les produits Aspose sont très **sécurisés**. Les composants Aspose s'exécutent dans le même contexte utilisateur que toutes les applications ASP.NET (sous l'utilisateur ASPNET). Par conséquent, les composants Aspose ne posent pas de risque de sécurité. Ils ne consomment également pas de ressources système critiques. De plus, lorsque un composant Aspose ouvre un document, les macros ne s'exécutent pas automatiquement. Les composants Aspose ont été conçus pour permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office.

{{% alert color="primary" %}} 

Aucun des risques associés au pack Microsoft Office ne s'applique aux composants Aspose.

{{% /alert %}} 

## **Stabilité**
Ce texte est une citation directe de l'article Microsoft précédemment référencé :

> "Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) pour faciliter l'installation et la réparation automatique pour un utilisateur final. MSI introduit le concept de "installer au premier usage", ce qui permet aux fonctionnalités d'être installées ou configurées dynamiquement à l'exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit les performances et augmente la probabilité qu'une boîte de dialogue apparaisse pour demander à l'utilisateur d'approuver l'installation ou de fournir un disque d'installation approprié. Bien qu'il soit conçu pour augmenter la résilience d'Office en tant que produit pour l'utilisateur final, la mise en œuvre des capacités MSI d'Office est contre-productive dans un environnement côté serveur. De plus, la stabilité d'Office en général ne peut pas être garantie lorsqu'il est exécuté côté serveur car il n'a pas été conçu ni testé pour ce type d'utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, par conséquent, celle de votre réseau dans son ensemble. Si vous envisagez d'automatiser Office côté serveur, essayez d'isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques, et qui peut être redémarré au besoin."

Étant donné que les composants Aspose sont emballés dans une seule DLL, ses utilisateurs n'ont jamais besoin d'installer des parties ou des éléments supplémentaires pour qu'ils fonctionnent. Les composants Aspose ne sont utilisés que par des applications .NET et aucune portion du code du composant n'est conçue pour attendre une réponse humaine.

{{% alert color="primary" %}} 

Les composants Aspose ont été soigneusement testés et confirmés comme étant très stables. Les composants Aspose sont utilisés par [des entreprises](http://www.aspose.com/Corporate/Aspose/Customerlist.html) telles que **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, et de nombreuses autres organisations de premier plan dans plusieurs secteurs et domaines.

{{% /alert %}} 

## **Scalabilité/Vitesse**
Ce qui suit est une citation directe d'un article Microsoft :

> "Les composants côté serveur doivent être des composants COM multi-threadés, réentrants et à surcharge minimale avec un débit élevé pour plusieurs clients. Les applications Office sont, dans presque tous les aspects, l'exact opposé. Elles sont des serveurs d'automatisation basés sur STA qui sont conçus pour fournir des fonctionnalités variées mais gourmandes en ressources pour un seul client. Elles offrent peu de scalabilité en tant que solution côté serveur et ont des limites fixes pour des éléments importants, tels que la mémoire, qui ne peuvent pas être modifiées par configuration. Plus important encore, elles utilisent des ressources globales (comme des fichiers mappés en mémoire, des compléments ou des modèles globaux, et des serveurs d'automatisation partagés), ce qui peut limiter le nombre d'instances pouvant s'exécuter en parallèle et entraîner des conditions de course si elles sont configurées dans un environnement multi-clients. Les développeurs qui prévoient d'exécuter plus d'une instance de toute application Office en même temps doivent envisager le Pooling ou la Sérialisation de l'Accès à l'Application Office afin d'éviter des blocages potentiels ou une corruption de données."

Les composants Aspose sont incroyablement évolutifs et ultrarapides. Les applications Office n'ont pas été conçues pour être utilisées simultanément par des centaines ou des milliers d'utilisateurs, mais les composants Aspose sont précisément conçus pour cela. Nos composants constituent une véritable solution .NET.

{{% alert color="primary" %}} 

La performance des composants Aspose est parfaite sur un serveur unique (alimentant une application unique) ou sur un formulaire web équilibré (alimentant une application à l'échelle de l'entreprise).

{{% /alert %}} 

## **Prix**
Lorsqu'une application utilise l'automatisation de Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine exécutant l'application. Il y a de nombreux cas où une application peut avoir besoin de créer ou de manipuler un fichier office, mais le processus ne nécessite pas Microsoft Office.

{{% alert color="primary" %}} 

Aspose fournit une licence de redistribution très [rentable](https://purchase.aspose.com/) et sans redevance qui permet le déploiement à un nombre illimité d'utilisateurs sans souci de licence.

{{% /alert %}} 

Lors de la création d'applications web, il est important de se rappeler que les composants d'automatisation de Microsoft Office ne sont ni tarifés ni licenciés pour les solutions côté serveur. Par conséquent, il n'existe pas de bonne solution de licence pour le déploiement d'applications web qui utilisent des composants Microsoft Office. Aspose, en revanche, propose une solution [très rentable](https://purchase.aspose.com/) pour les applications basées sur le serveur également.

## **Fonctionnalités**
Les composants Aspose offrent tout ce dont vous avez besoin pour gérer les fichiers Office et bien plus encore. Nous les avons conçus sur la base de notre philosophie d'aider les développeurs à obtenir les meilleurs résultats possibles avec le moins d'efforts possible.

{{% alert color="primary" %}} 

Contrairement à l'automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et économiques en termes de temps.

{{% /alert %}} 

Par exemple, [Aspose.Cells](https://products.aspose.com/cells/net/) donne aux développeurs la possibilité d'importer des données depuis un **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) fournit une fonctionnalité similaire qui permet aux développeurs de peupler un document Word (c'est-à-dire, Mail Merge) directement à partir de n'importe quel objet de données .NET. [Chaque composant](https://products.aspose.com/total/net/) de la famille Aspose offre son propre ensemble de fonctionnalités uniques et puissantes.

Le meilleur aspect de l'achat d'un composant Aspose est d'avoir accès à nos équipes de développement. Par exemple, si vous utilisez des objets d'automatisation Office et avez besoin de certaines fonctionnalités, les chances que ces fonctionnalités soient ajoutées sont très, très faibles. Cependant, les choses sont différentes avec les composants Aspose.

{{% alert color="primary" %}} 

Nos équipes de développement comprennent que si une fonctionnalité est nécessaire pour votre entreprise, il y a de bonnes chances que d'autres entreprises aient besoin de la même fonctionnalité. Bien que nous sachions que nous ne pouvons pas mettre en œuvre chaque fonctionnalité demandée, nous nous efforçons d'ajouter autant de fonctionnalités que possible en fonction des retours de nos clients.

{{% /alert %}} 

Nos équipes sont toujours ouvertes d'esprit et flexibles lorsqu'il s'agit de fournir de l'aide—et c'est la raison pour laquelle les composants Aspose sont devenus aussi puissants qu'ils le sont aujourd'hui.

## **Conclusion**
{{% alert color="primary" %}} 

Bien que cet article ait couvert certains des points clés pour lesquels les composants Aspose sont un meilleur choix que l'automatisation Office, vous devez comprendre qu'il y a de nombreux, nombreux autres avantages. Nous n'avons traité que quelques-uns des principaux avantages.

De plus, tous les produits et composants Aspose offrent une [version d'évaluation](https://downloads.aspose.com/slides/net) sans risque et sans obligation. Nous vous encourageons à profiter de l'évaluation pour voir ce qu'Aspose peut faire pour vos applications ou votre entreprise.

{{% /alert %}}