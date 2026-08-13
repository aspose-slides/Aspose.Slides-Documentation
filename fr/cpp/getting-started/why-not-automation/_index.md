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
- évolutivité
- fonctionnalités
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez pourquoi l’automatisation d’Office est risquée pour les serveurs et les services, et voyez comment Aspose.Slides offre un traitement des présentations plus sûr et plus rapide pour PowerPoint et OpenDocument."
---
## **Introduction**

Il existe plusieurs raisons pour lesquelles les composants Aspose sont une meilleure alternative à l’automatisation. Parmi les raisons principales :

- Sécurité
- Stabilité
- Évolutivité/Vitesse
- Prix
- Fonctionnalités

Vous trouverez ci‑dessous une explication plus détaillée de chaque point clé.

## **Questions importantes**
- Pourquoi les composants Aspose sont‑ils une bien meilleure option que Microsoft Office Automation ?

Il y a deux questions que nous entendons le plus souvent chez Aspose :

- Vos produits exigent‑ils que Microsoft Office soit installé pour pouvoir fonctionner ?

La réponse courte et simple est **NON**. Aspose et les composants Aspose sont totalement indépendants et ne sont ni affiliés, ni autorisés, ni sponsorisés, ni approuvés par Microsoft Corporation.

- Pourquoi devrions‑nous utiliser les produits Aspose plutôt que d’utiliser Microsoft Office Automation ?

La réponse la plus courte que nous puissions donner est qu’il existe de nombreuses raisons, la première étant que *Microsoft lui‑même recommande fortement de ne pas recourir à l’automatisation d’Office depuis des solutions logicielles : [Microsoft Article*

## **Sécurité**
Ce qui suit est une citation directe de l’« Microsoft Article » cité plus haut :
*"Les applications Office n’ont jamais été conçues pour être utilisées côté serveur, et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n’authentifie pas les requêtes entrantes et ne vous protège pas contre l’exécution involontaire de macros, ni contre le lancement d’un autre serveur pouvant exécuter des macros, depuis votre code côté serveur. N’ouvrez pas les fichiers téléchargés sur le serveur depuis le Web anonyme ! En fonction des paramètres de sécurité définis en dernier, le serveur peut exécuter des macros sous le contexte d’un administrateur ou du système avec tous les privilèges, compromettant ainsi votre réseau ! De plus, Office utilise de nombreux composants côté client (tels que Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache des informations d’authentification client afin d’accélérer le traitement. Si Office est automatisé côté serveur, une instance peut servir plusieurs clients, et comme les informations d’authentification ont été mises en cache pour cette session, il est possible qu’un client utilise les informations d’identification d’un autre client, obtenant ainsi des autorisations d’accès non accordées en se faisant passer pour d’autres utilisateurs."*

Les produits Aspose sont très sécurisés. Ainsi, les composants Aspose ne représentent aucun risque potentiel pour les ressources système vitales. De plus, lorsqu’un document est ouvert par un composant Aspose, les macros ne sont pas exécutées automatiquement. Les composants Aspose ont été conçus pour permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office. Aucun des risques associés au package Microsoft Office n’est inhérent aux composants Aspose.

## **Stabilité**
Ce qui suit est une citation directe de l’« Microsoft Article » cité plus haut :
*"Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) afin de simplifier l’installation et l’auto‑réparation pour l’utilisateur final. MSI introduit le concept d’« installation à la première utilisation », qui permet d’installer ou de configurer dynamiquement des fonctionnalités à l’exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit les performances et augmente la probabilité qu’une boîte de dialogue apparaisse pour demander à l’utilisateur d’approuver l’installation ou de fournir le disque d’installation approprié. Bien que cela soit destiné à augmenter la résilience d’Office en tant que produit destiné à l’utilisateur final, l’implémentation des capacités MSI d’Office est contre‑productive dans un environnement serveur. De plus, la stabilité générale d’Office ne peut être garantie lorsqu’il est exécuté côté serveur, car il n’a pas été conçu ni testé pour ce type d’utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cet ordinateur et, par conséquent, de votre réseau dans son ensemble. Si vous prévoyez d’automatiser Office côté serveur, essayez d’isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques et qui peut être redémarré si nécessaire."*

Comme les composants Aspose sont emballés dans une seule DLL, il ne sera jamais nécessaire d’installer des parties supplémentaires pour qu’ils fonctionnent. Les composants Aspose sont uniquement utilisés par des applications C++ et aucune partie du code du composant n’est conçue pour attendre une réponse humaine. Les composants Aspose ont été rigoureusement testés et sont extrêmement stables. Les composants Aspose sont utilisés par [Entreprises](https://about.aspose.com/customers) telles que : **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** et bien d’autres.

## **Évolutivité/Vitesse**
Ce qui suit est une citation directe de l’« Microsoft Article » cité plus haut :

*"Les composants côté serveur doivent être hautement réentrants, multi‑threads, des composants COM avec un minimum de surcharge et un débit élevé pour de multiples clients. Les applications Office sont, à bien des égards, exactement le contraire. Ce sont des serveurs d’automatisation non réentrants, basés sur STA, conçus pour fournir une fonctionnalité diversifiée mais gourmande en ressources pour un seul client. Elles offrent peu d’évolutivité en tant que solution côté serveur, et imposent des limites fixes à des éléments importants, comme la mémoire, qui ne peuvent pas être modifiés par configuration. Plus important encore, elles utilisent des ressources globales (comme les fichiers mappés en mémoire, les add‑ins ou modèles globaux, et les serveurs d’automatisation partagés), ce qui peut limiter le nombre d’instances pouvant s’exécuter simultanément et provoquer des conditions de concurrence si elles sont configurées dans un environnement multi‑client. Les développeurs qui prévoient d’exécuter plus d’une instance d’une application Office en même temps doivent envisager le pool ou la sérialisation de l’accès à l’application Office afin d’éviter des blocages potentiels ou une corruption de données."*

Les composants Aspose sont hautement évolutifs et ultra rapides. Les applications Office n’ont pas été conçues pour être utilisées simultanément par des centaines voire des milliers d’utilisateurs. En revanche, les composants Aspose ont été créés précisément pour cela. Nos composants sont une véritable solution C++ et fonctionnent parfaitement, que ce soit sur un serveur unique alimentant une seule application ou sur un formulaire Web équilibré en charge pour une application d’entreprise à l’échelle globale.

## **Prix**
Lorsqu’une application utilise Microsoft Office Automation, une copie de Microsoft Office doit être achetée pour chaque machine exécutant l’application. Il arrive souvent qu’une application doive créer ou manipuler un fichier Office sans que l’utilisateur possède Microsoft Office. Aspose propose une licence de redistribution très **rentable** et exempte de redevances qui permet un déploiement sur un nombre illimité d’utilisateurs sans souci de licence. Lors de la création d’applications Web, il faut savoir que les composants Microsoft Office Automation ne sont ni tarifés ni licenciés pour les solutions côté serveur ; il n’existe donc aucune solution de licence adéquate pour déployer des applications Web utilisant ces composants. Aspose propose une solution très **rentable** pour les applications serveur également.

## **Fonctionnalités**
Les composants Aspose offrent tout ce qui est nécessaire pour gérer les fichiers Office, et bien plus encore. Ils sont conçus avec la philosophie de permettre aux développeurs d’obtenir les meilleurs résultats avec le moindre effort. Contrairement à l’automatisation Office, les composants Aspose fournissent de nombreuses fonctions puissantes et gain de temps. Par exemple, [Aspose.Cells](https://products.aspose.com/cells/cpp/) permet aux développeurs d’importer des données depuis un **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) propose une fonctionnalité similaire qui permet de remplir un document Word (Mail Merge) directement à partir de tout objet de données C++. [Chaque composant](https://products.aspose.com/total/cpp/) de la famille Aspose offre son propre ensemble de fonctionnalités uniques et puissantes. Le meilleur avantage de l’achat d’un composant Aspose est l’accès à nos équipes de développement. Nos équipes comprennent que si une fonctionnalité est nécessaire à votre entreprise, il est très probable que d’autres entreprises en aient également besoin. Bien que toutes les demandes de fonctionnalité ne puissent être intégrées, nos équipes restent très ouvertes et flexibles lorsqu’il s’agit d’apporter de l’aide. Cette mentalité a permis aux composants Aspose de devenir aussi puissants qu’ils le sont. Si vous avez besoin de fonctionnalités supplémentaires provenant des objets d’automatisation Office, vos chances de les voir ajoutées sont très, très faibles.

## **Conclusion**
{{% alert color="info" %}} 

Bien que cet article ait couvert de nombreux points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l’automatisation Office, il en existe encore bien d’autres. Cet article ne traite ici que des points les plus essentiels. Tous les différents composants Aspose offrent une version d’évaluation sans risque et sans obligation [Version d’évaluation](https://downloads.aspose.com/slides/fr/cpp). Nous vous encourageons à profiter de cette [Évaluation](https://downloads.aspose.com/slides/fr/cpp) afin de mieux voir ce qu’Aspose peut faire pour vos applications. 
{{% /alert %}}