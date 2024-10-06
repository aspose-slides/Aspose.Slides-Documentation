---
title: Pourquoi pas d'automatisation
type: docs
weight: 50
url: /cpp/why-not-automation/
---

## **Questions importantes**
- Pourquoi les composants Aspose sont-ils une bien meilleure option que l'automatisation Microsoft Office ?

Il y a deux questions que nous entendons le plus souvent ici chez Aspose :

- Vos produits nécessitent-ils que Microsoft Office soit installé pour fonctionner ?

La réponse courte et simple est **NON**. Aspose et ses composants sont totalement indépendants et ne sont pas affiliés à, ni autorisés, sponsorisés ou autrement approuvés par la société Microsoft.

- Pourquoi devrions-nous utiliser les produits Aspose plutôt que d'utiliser l'automatisation Microsoft Office ?

La réponse la plus courte que nous puissions donner est qu'il existe de nombreuses raisons, la principale étant que *Microsoft lui-même recommande fortement d'éviter l'automatisation Office dans les solutions logicielles : [Article Microsoft](https://support.microsoft.com/en-us/help/832949/overview-of-issues-with-office-automation-on-the-server)

## **Aperçu**
Comme indiqué ci-dessus, il existe plusieurs raisons pour lesquelles les composants Aspose sont une meilleure alternative à l'automatisation. Certaines des principales raisons sont :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Ci-dessous se trouve une meilleure explication de chacun des points clés. Assurez-vous également de visiter la section **Informations supplémentaires** qui fournit un lien vers des évaluations d'utilisateurs indépendants.

## **Sécurité**
Ce qui suit est une citation directe de l'article Microsoft mentionné ci-dessus :
*"Les applications Office n'ont jamais été conçues pour être utilisées côté serveur, et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n'authentifie pas les demandes entrantes, et ne vous protège pas contre l'exécution involontaire de macros, ou le démarrage d'un autre serveur qui pourrait exécuter des macros depuis votre code côté serveur. N'ouvrez pas de fichiers téléchargés sur le serveur depuis un web anonyme ! En fonction des paramètres de sécurité qui ont été définis pour la dernière fois, le serveur peut exécuter des macros sous un contexte Administrateur ou Système avec des privilèges complets et compromettre votre réseau ! De plus, Office utilise de nombreux composants côté client (tels que Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d'authentification du client afin d'accélérer le traitement. Si Office est automatisé côté serveur, une instance peut servir plus d'un client, et comme les informations d'authentification ont été mises en cache pour cette session, un client peut utiliser les informations d'identification en cache d'un autre client, et ainsi obtenir des autorisations d'accès non accordées en usurpant d'autres utilisateurs."*

Les produits Aspose sont très sécurisés. Par conséquent, les composants Aspose ne présentent pas de risque potentiel pour les ressources vitales du système. En outre, lorsqu'un document est ouvert par un composant Aspose, les macros ne sont pas exécutées automatiquement. Les composants Aspose ont été conçus dans le but de permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office. Aucun des risques associés au package Microsoft Office n'est inhérent aux composants Aspose.

## **Stabilité**
Ce qui suit est une citation directe de l'article Microsoft mentionné ci-dessus :
*"Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) pour faciliter l'installation et la réparation automatique pour l'utilisateur final. MSI introduit le concept de "installation à la première utilisation ", qui permet d'installer ou de configurer des fonctionnalités dynamiquement à l'exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, ceci ralentit à la fois les performances et augmente la probabilité qu'une boîte de dialogue apparaisse demandant à l'utilisateur d'approuver l'installation ou de fournir un disque d'installation approprié. Bien qu'il soit conçu pour augmenter la résilience d'Office en tant que produit destiné à l'utilisateur final, l'implémentation des capacités MSI d'Office est contre-productive dans un environnement côté serveur. De plus, la stabilité d'Office en général ne peut être garantie lorsqu'il est exécuté côté serveur, car il n'a pas été conçu ni testé pour ce type d'utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, en conséquence, celle de votre réseau dans son ensemble. Si vous prévoyez d'automatiser Office côté serveur, essayez d'isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques, et qui peut être redémarré si besoin."*

Puisque les composants Aspose sont regroupés dans une seule DLL, il ne sera jamais nécessaire d'installer d'autres parties ou éléments pour qu'ils fonctionnent. Les composants Aspose ne sont utilisés que par des applications C++ et aucune partie du code du composant n'est conçue pour attendre une réponse humaine. Les composants Aspose ont été minutieusement testés et sont extrêmement stables. Les composants Aspose sont utilisés par des [entreprises](https://about.aspose.com/customers) telles que : **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** et beaucoup d'autres.

## **Scalabilité/Vitesse**
Ce qui suit est une citation directe de l'article Microsoft mentionné ci-dessus :

*"Les composants côté serveur doivent être des composants COM fortement réentrants et multithreadés avec un minimum de surcharge et un débit élevé pour plusieurs clients. Les applications Office sont, à presque tous égards, le contraire exact. Ce sont des serveurs d'automatisation basés sur STA non réentrants qui sont conçus pour fournir des fonctionnalités variées mais gourmandes en ressources pour un seul client. Elles offrent peu de scalabilité en tant que solution côté serveur, et ont des limites fixes pour des éléments importants, tels que la mémoire, qui ne peuvent pas être modifiés par configuration. Plus important encore, elles utilisent des ressources globales (telles que des fichiers mappés en mémoire, des compléments ou modèles globaux, et des serveurs d'automatisation partagés), ce qui peut limiter le nombre d'instances pouvant s'exécuter simultanément et entraîner des conditions de course si elles sont configurées dans un environnement multi-client. Les développeurs qui prévoient d'exécuter plus d'une instance de n'importe quelle application Office en même temps doivent envisager le Pooling ou la Sérialisation d'Accès à l'Application Office pour éviter les blocages potentiels ou la corruption de données."*

Les composants Aspose sont très évolutifs et extrêmement rapides. Les applications Office n'ont pas été conçues pour être utilisées simultanément par des centaines et des milliers d'utilisateurs. Cependant, les composants Aspose sont conçus pour cela. Nos composants sont une véritable solution C++ et fonctionnent parfaitement, que ce soit sur un seul serveur, alimentant une seule application ou sur un formulaire web équilibré par charge, alimentant une application d'entreprise à grande échelle.

## **Prix**
Lorsqu'une application utilise l'automatisation Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine qui exécute l'application. Il existe de nombreuses occasions où une application peut avoir besoin de créer ou de manipuler un fichier Office sans nécessiter que l'utilisateur ait Microsoft Office. Aspose propose une licence de redistribution très [abordable](https://purchase.aspose.com/) et sans redevance qui permettra un déploiement à un nombre illimité d'utilisateurs sans soucis de licences. Lors de la création d'applications web, il est important de savoir que les composants d'automatisation Microsoft Office ne sont pas tarifés ni licenciés pour des solutions côté serveur ; par conséquent, il n'existe pas de bonne solution de licence pour déployer des applications web qui utilisent les composants Microsoft Office. Aspose propose également une solution [très abordable](https://purchase.aspose.com/) pour les applications basées sur un serveur.

## **Fonctionnalités**
Les composants Aspose fournissent tout ce qui est nécessaire pour gérer des fichiers Office, plus bien plus encore. Ils sont conçus avec la philosophie de permettre aux développeurs d'obtenir les meilleurs résultats avec le moins de travail possible. Contrairement à l'automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et économes en temps. Par exemple, [Aspose.Cells](https://products.aspose.com/cells/cpp/) offre aux développeurs la possibilité d'importer des données à partir d'un **DataTable**ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) offre une fonctionnalité similaire qui permet aux développeurs de remplir un document Word (qui est une fusion de courrier) directement à partir de n'importe quel objet de données C++. [Chaque composant](https://products.aspose.com/total/cpp/) de la famille Aspose propose son propre ensemble de fonctionnalités uniques et puissantes. Le meilleur aspect de l'achat d'un composant Aspose est d'avoir accès à nos équipes de développement. Nos équipes de développement réalisent que si une fonctionnalité est nécessaire pour votre entreprise, il y a de fortes chances que d'autres entreprises en aient également besoin. Bien que toutes les demandes de fonctionnalités ne puissent pas être ajoutées, nos équipes essaient d'être très ouvertes d'esprit et flexibles lors de la fourniture d'assistance. Cet état d'esprit a aidé les composants Aspose à devenir aussi puissants qu'ils le sont. Si vous avez besoin de fonctionnalités supplémentaires des objets d'automatisation Office, vos chances de les voir ajoutées sont très, très faibles.

## **Conclusion**
{{% alert color="primary" %}} 

Bien que cet article ait couvert de nombreux points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l'automatisation Office, il en existe encore beaucoup, beaucoup d'autres. Cet article traite principalement des points les plus importants. Tous les différents composants Aspose offrent une version d'évaluation sans risque et sans obligation [Version d'Évaluation](https://downloads.aspose.com/slides/cpp). Nous vous encourageons à profiter de cette [Évaluation](https://downloads.aspose.com/slides/cpp) afin de mieux voir ce qu'Aspose peut faire pour vos applications.