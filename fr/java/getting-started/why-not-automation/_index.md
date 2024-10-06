---
title: Pourquoi pas d'automatisation
type: docs
weight: 50
url: /java/why-not-automation/
---

{{% alert color="primary" %}} 

Il y a deux questions que nous entendons le plus souvent ici chez Aspose : 

La première est **Est-ce que vos produits nécessitent que Microsoft Office soit installé pour fonctionner ?** 

La réponse courte et simple est **NON**. Aspose et les composants Aspose sont totalement indépendants et ne sont pas affiliés à, ni autorisés, sponsorisés ou autrement approuvés par Microsoft Corporation. 

La deuxième question qui suit généralement est **Pourquoi devrions-nous utiliser les produits Aspose plutôt que d'utiliser l'automatisation de Microsoft Office ?** 

Cette question ne peut pas être répondu aussi facilement. La réponse la plus courte que nous puissions donner est qu'il y a de nombreuses raisons, la principale étant que **Microsoft lui-même recommande fortement d'éviter l'automatisation d'Office dans les solutions logicielles** 

{{% /alert %}} 
## **Aperçu**
Comme mentionné ci-dessus, il y a plusieurs raisons pour lesquelles les composants Aspose sont une meilleure alternative à l'automatisation. Certaines des raisons clés sont : 

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Voici une meilleure explication de chacun des points clés. Assurez-vous également de visiter la section **Informations supplémentaires** qui fournit des liens vers des évaluations d'utilisateurs indépendants. 
## **Sécurité**
Voici une citation directe d'un article de Microsoft : 

*"Les applications Office n'ont jamais été conçues pour être utilisées sur le serveur, et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n'authentifie pas les demandes entrantes, et ne vous protège pas du fait d'exécuter involontairement des macros, ou de démarrer un autre serveur qui pourrait exécuter des macros, à partir de votre code côté serveur. N'ouvrez pas les fichiers qui sont téléchargés sur le serveur depuis un Web anonyme ! En fonction des paramètres de sécurité qui ont été définis pour la dernière fois, le serveur peut exécuter des macros sous un contexte Administrateur ou Système avec des privilèges complets et compromettre votre réseau ! De plus, Office utilise de nombreux composants côté client (tels que Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d'authentification des clients afin d'accélérer le traitement. Si Office est automatisé côté serveur, une instance peut servir plus d'un client, et parce que les informations d'authentification ont été mises en cache pour cette session, il est possible qu'un client utilise les identifiants mis en cache d'un autre client, et ainsi obtenir des autorisations d'accès non accordées en usurpant d'autres utilisateurs."* 

Les produits Aspose sont très sécurisés. Les composants Aspose ne présentent pas de risque potentiel pour les ressources vitales du système. En outre, lorsqu'un document est ouvert par un composant Aspose, les macros ne s'exécutent pas automatiquement. Les composants Aspose ont été conçus dans le but de permettre aux développeurs de créer, manipuler et sauvegarder des fichiers Office. Aucun des risques associés au package Microsoft Office n'est inhérent aux composants Aspose. 
## **Stabilité**
Voici une citation directe d'un article de Microsoft : 

*"Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) pour faciliter l'installation et l'auto-réparation pour un utilisateur final. MSI introduit le concept de "installer au premier usage", qui permet d'installer ou de configurer dynamiquement des fonctionnalités à l'exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit à la fois les performances et augmente la probabilité qu'une boîte de dialogue apparaisse demandant à l'utilisateur d'approuver l'installation ou de fournir un disque d'installation approprié. Bien qu'il soit conçu pour accroître la résilience d'Office en tant que produit destiné à l'utilisateur final, l'implémentation des capacités MSI d'Office est contre-productive dans un environnement côté serveur. En outre, la stabilité d'Office en général ne peut pas être assurée lorsqu'il est exécuté côté serveur car il n'a pas été conçu ni testé pour ce type d'utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, par conséquent, de votre réseau dans son ensemble. Si vous prévoyez d'automatiser Office côté serveur, essayez d'isoler le programme sur un ordinateur dédié qui ne peut pas affecter les fonctions critiques, et qui peut être redémarré au besoin."* 

Les composants Aspose ont été rigoureusement testés et sont extrêmement stables. Les composants Aspose sont utilisés par des [entreprises](https://about.aspose.com/customers) telles que : **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** et beaucoup d'autres. 
## **Scalabilité/Vitesse**
Voici une citation directe d'un article de Microsoft : 

*"Les composants côté serveur doivent être des composants COM multi-threadés, hautement réentrants, avec un minimum de surcharge et un débit élevé pour plusieurs clients. Les applications Office sont presque à tous égards le contraire exact. Elles sont des serveurs d'automatisation basés sur STA non réentrants, conçus pour fournir une fonctionnalité diversifiée mais gourmande en ressources pour un seul client. Elles offrent peu de scalabilité en tant que solution côté serveur, et ont des limites fixes sur des éléments importants, tels que la mémoire, qui ne peuvent pas être modifiées par configuration. Plus important encore, elles utilisent des ressources globales (telles que des fichiers mappés en mémoire, des compléments ou modèles globaux, et des serveurs d'automatisation partagés), qui peuvent limiter le nombre d'instances pouvant s'exécuter simultanément et entraîner des conditions de concurrence si elles sont configurées dans un environnement multi-client. Les développeurs qui prévoient d'exécuter plus d'une instance de n'importe quelle application Office en même temps doivent envisager* ***le Pooling*** *ou* ***la Sérialisation de l'Accès*** *à l'application Office pour éviter d'éventuels* ***Deadlocks*** *ou* ***Corruptions de Données*** *.* 

Les composants Aspose sont très scalables et ultra-rapides. Les applications Office n'ont pas été conçues pour être utilisées simultanément par des centaines et des milliers d'utilisateurs. Cependant, les composants Aspose sont conçus pour cela. Nos composants fonctionnent parfaitement qu'ils soient sur un seul serveur, alimentant une seule application ou sur un Web Form équilibré, alimentant une application à l'échelle de l'entreprise. 
## **Prix**
Lorsqu'une application utilise l'automatisation de Microsoft Office, une copie de Microsoft Office doit être achetée pour chaque machine qui exécute l'application. Il y a de nombreuses fois où une application peut avoir besoin de créer ou de manipuler un fichier Office mais ne nécessite pas que l'utilisateur ait Microsoft Office. Aspose propose une licence de rediffusion très [économique](https://purchase.aspose.com/) et sans redevance, qui permettra le déploiement à un nombre illimité d'utilisateurs sans souci de licence. 

Lors de la création d'applications web, il est important de savoir que les composants d'automatisation de Microsoft Office ne sont pas tarifés ni licenciés pour des solutions côté serveur ; par conséquent, il n'existe aucune bonne solution de licence pour le déploiement d'applications web qui utilisent les composants Microsoft Office. Aspose propose également une solution très économique pour les applications basées sur serveur. 
## **Fonctionnalités**
Les composants Aspose fournissent tout ce qu'il faut pour gérer des fichiers Office et bien plus encore. Ils sont conçus avec la philosophie de permettre aux développeurs d'accomplir les meilleurs résultats avec le moins de travail possible. Contrairement à l'automatisation Office, les composants Aspose offrent de nombreuses fonctions puissantes et économes en temps. Par exemple, [Aspose.Cells](https://products.aspose.com/cells/java/) offre aux développeurs la possibilité d'importer des données d'un **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/java/) offre une fonctionnalité similaire qui permet aux développeurs de peupler un document Word (qui est un publipostage). [Chaque Composant](https://products.aspose.com/total/java/) de la famille Aspose propose son propre ensemble de fonctionnalités uniques et puissantes. 

Le meilleur avantage de l'achat d'un composant Aspose (ou de suites de composants comme [Aspose.Total](https://products.aspose.com/total/java/)) est d'avoir accès à nos équipes de développement. Nos équipes de développement réalisent que si une fonction est nécessaire à votre entreprise, il y a de fortes chances que d'autres entreprises en aient également besoin. Bien que toutes les demandes de fonctionnalités ne puissent pas être ajoutées, nos équipes essaient d'être très ouvertes d'esprit et flexibles lors de la fourniture d'assistance. Cet état d'esprit est ce qui a aidé les composants Aspose à devenir aussi puissants qu'ils le sont. S'il y a des fonctionnalités supplémentaires dont vous avez besoin d'objets d'automatisation Office, vos chances de les voir ajoutées sont très, très faibles. 
## **Conclusion**
{{% alert color="primary" %}} 

Bien que cet article ait couvert de nombreux points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l'automatisation Office, il y en a beaucoup, beaucoup d'autres. Cet article aborde principalement les points les plus clés. Tous les différents composants Aspose offrent une version d'[évaluation sans risque, sans engagement](https://downloads.aspose.com/slides/java). Nous vous encourageons à profiter de cette évaluation afin de mieux voir ce qu'Aspose peut faire pour vos applications. 

{{% /alert %}} 