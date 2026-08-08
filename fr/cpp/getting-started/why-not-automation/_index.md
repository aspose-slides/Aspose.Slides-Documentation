---
title: Pourquoi pas l'automatisation
type: docs
weight: 50
url: /fr/cpp/why-not-automation/
keywords:
- automatisation
- Microsoft Office
- comparaison
- sécurité
- stabilité
- scalabilité
- fonctionnalités
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez pourquoi l'automatisation Office est risquée pour les serveurs et services, et comment Aspose.Slides offre un traitement de présentations plus sûr et plus rapide pour PowerPoint et OpenDocument."
---
## **Introduction**

Il existe plusieurs raisons pour lesquelles les composants Aspose constituent une meilleure alternative à l'automatisation. Parmi les raisons principales :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Voici une explication plus détaillée de chaque point clé.

## **Questions importantes**
- Pourquoi les composants Aspose sont-ils une bien meilleure option que l'automatisation Microsoft Office ?

Il y a deux questions que nous entendons le plus souvent chez Aspose :

- Vos produits nécessitent-ils que Microsoft Office soit installé pour pouvoir fonctionner ?

La réponse courte et simple est **NON**. Aspose et les composants Aspose sont totalement indépendants et ne sont pas affiliés à, ni autorisés, sponsorisés ou autrement approuvés par Microsoft Corporation.

- Pourquoi devrions‑nous utiliser les produits Aspose plutôt que d’utiliser l’automatisation Microsoft Office ?

La réponse la plus courte que nous puissions donner est qu’il existe de nombreuses raisons, la principale étant que *Microsoft elle‑même recommande fortement de ne pas recourir à l’automatisation Office à partir de solutions logicielles : [Article Microsoft

## **Sécurité**
Ce qui suit est une citation directe de l’Article Microsoft mentionné ci‑dessus :

*"Les applications Office n’ont jamais été conçues pour une utilisation côté serveur et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n’authentifie pas les requêtes entrantes et ne vous protège pas contre l’exécution involontaire de macros, ou le démarrage d’un autre serveur pouvant exécuter des macros, depuis votre code côté serveur. N’ouvrez pas les fichiers téléchargés sur le serveur depuis le Web anonyme ! En fonction des paramètres de sécurité définis en dernier, le serveur peut exécuter des macros sous le contexte d’un administrateur ou du système avec des privilèges complets, compromettant ainsi votre réseau ! De plus, Office utilise de nombreux composants côté client (tels que Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d’authentification du client afin d’accélérer le traitement. Si Office est automatisé côté serveur, une instance peut servir plusieurs clients et, comme les informations d’authentification ont été mises en cache pour cette session, il est possible qu’un client utilise les informations d’identification mises en cache d’un autre client, obtenant ainsi des autorisations d’accès non accordées en se faisant passer pour d’autres utilisateurs."*

Les produits Aspose sont très sécurisés. Par conséquent, les composants Aspose ne représentent aucun risque potentiel pour les ressources système essentielles. De plus, lorsqu’un document est ouvert par un composant Aspose, les macros ne sont pas exécutées automatiquement. Les composants Aspose ont été conçus dans le but de permettre aux développeurs de créer, manipuler et sauvegarder des fichiers Office. Aucun des risques associés au pack Microsoft Office n’est inhérent aux composants Aspose.

## **Stabilité**
Ce qui suit est une citation directe de l’Article Microsoft mentionné ci‑dessus :

*"Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) afin de simplifier l’installation et l’autoguérison pour l’utilisateur final. MSI introduit le concept d’« installation à la première utilisation », qui permet aux fonctionnalités d’être installées ou configurées dynamiquement à l’exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit les performances et augmente la probabilité qu’une boîte de dialogue apparaisse pour demander à l’utilisateur d’approuver l’installation ou de fournir un disque d’installation approprié. Bien qu’il soit conçu pour augmenter la résilience d’Office en tant que produit destiné aux utilisateurs finaux, l’implémentation des capacités MSI d’Office est contre‑productive dans un environnement côté serveur. De plus, la stabilité d’Office en général ne peut être garantie lorsqu’il est exécuté côté serveur, car il n’a pas été conçu ou testé pour ce type d’utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, par conséquent, celle de l’ensemble de votre réseau. Si vous prévoyez d’automatiser Office côté serveur, essayez d’isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques, et qui peut être redémarré si nécessaire."*

Comme les composants Aspose sont empaquetés dans une seule DLL, il ne sera jamais nécessaire d’installer des parties ou pièces supplémentaires pour qu’ils fonctionnent. Les composants Aspose ne sont utilisés que par des applications C++ et aucune partie du code du composant n’est conçue pour attendre une réponse humaine. Les composants Aspose ont été rigoureusement testés et sont extrêmement stables. Les composants Aspose sont utilisés par [Companies](https://about.aspose.com/customers) tels que : **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** et bien d’autres.

## **Scalabilité/Vitesse**
Ce qui suit est une citation directe de l’Article Microsoft mentionné ci‑dessus :

*"Les composants côté serveur doivent être des composants COM hautement réentrants, multithread, avec un minimum de surcharge et un débit élevé pour plusieurs clients. Les applications Office sont, à bien des égards, exactement le contraire. Elles sont des serveurs d’automatisation non réentrants basés sur STA, conçus pour fournir une fonctionnalité diversifiée mais gourmande en ressources pour un seul client. Elles offrent peu de scalabilité en tant que solution côté serveur et ont des limites fixes sur des éléments importants, tels que la mémoire, qui ne peuvent pas être modifiées via la configuration. Plus important encore, elles utilisent des ressources globales (telles que des fichiers mémoire-mappés, des plug‑ins ou modèles globaux, et des serveurs d’automatisation partagés), ce qui peut limiter le nombre d’instances pouvant s’exécuter simultanément et entraîner des conditions de concurrence si elles sont configurées dans un environnement multi‑client. Les développeurs qui prévoient d’exécuter plus d’une instance d’une application Office en même temps doivent envisager le pooling ou la sérialisation de l’accès à l’application Office afin d’éviter d’éventuels interblocages ou corruptions de données".*

Les composants Aspose sont hautement évolutifs et extrêmement rapides. Les applications Office n’ont pas été conçues pour être utilisées simultanément par des centaines voire des milliers d’utilisateurs. Cependant, les composants Aspose sont conçus précisément pour cela. Nos composants sont une véritable solution C++ et fonctionnent impeccablement, que ce soit sur un serveur unique, alimentant une application unique ou sur un formulaire Web équilibré en charge supportant une application d’entreprise à grande échelle.

## **Prix**
Lorsqu’une application utilise l’automatisation Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine exécutant l’application. Il arrive souvent qu’une application doive créer ou manipuler un fichier Office sans que l’utilisateur possède Microsoft Office. Aspose propose une licence de redistribution très [Cost Effective](https://purchase.aspose.com/) et libre de redevances qui permet le déploiement à un nombre illimité d’utilisateurs sans souci de licence. Lors de la création d’applications web, il est important de savoir que les composants d’automatisation Microsoft Office ne sont ni tarifés ni sous licence pour des solutions côté serveur ; il n’existe donc aucune solution de licence adéquate pour déployer des applications web utilisant les composants Microsoft Office. Aspose propose également une solution très [Cost Effective](https://purchase.aspose.com/) pour les applications serveur.

## **Fonctionnalités**
Les composants Aspose offrent tout le nécessaire pour gérer les fichiers Office et bien plus encore. Ils sont conçus selon la philosophie de permettre aux développeurs d’obtenir les meilleurs résultats avec le moindre effort. Contrairement à l’automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et économisant du temps. Par exemple, [Aspose.Cells](https://products.aspose.com/cells/cpp/) permet aux développeurs d’importer des données depuis un **DataTable** ou un **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) propose une fonctionnalité similaire qui permet aux développeurs de remplir un document Word (c’est‑à‑dire une fusion de courrier) directement à partir de n’importe quel objet de données C++. [Every Component](https://products.aspose.com/total/cpp/) de la famille Aspose offre son propre ensemble de fonctionnalités uniques et puissantes. Le meilleur avantage d’acheter un composant Aspose est d’avoir accès à nos équipes de développement. Nos équipes comprennent que si une fonctionnalité est nécessaire à votre entreprise, il est très probable que d’autres entreprises en aient également besoin. Bien que toutes les demandes de fonctionnalités ne puissent être ajoutées, nos équipes essaient d’être très ouvertes et flexibles lorsqu’elles fournissent de l’assistance. Cette mentalité a permis aux composants Aspose de devenir aussi puissants. Si vous avez besoin de fonctionnalités supplémentaires provenant des objets d’automatisation Office, vos chances de les voir ajoutées sont très, très faibles.

## **Conclusion**
{{% alert color="primary" %}} 

Bien que cet article ait couvert de nombreux points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l’automatisation Office, il en existe bien d’autres. Cet article ne traite principalement que les points les plus importants. Tous les différents composants Aspose offrent une version d’évaluation sans risque et sans obligation [Evaluation Version](https://downloads.aspose.com/slides/fr/cpp). Nous vous encourageons à profiter de cette [Evaluation](https://downloads.aspose.com/slides/fr/cpp) afin de mieux voir ce que Aspose peut faire pour vos applications.
{{% /alert %}}