---
title: Pourquoi pas l'automatisation
type: docs
weight: 50
url: /cpp/pourquoi-pas-l-automatisation/
---

## **Questions Importantes**
- Pourquoi les composants Aspose sont-ils une bien meilleure option que Microsoft Office Automation ?

Il y a deux questions que nous entendons le plus souvent ici chez Aspose :

- Vos produits nécessitent-ils que Microsoft Office soit installé pour fonctionner ?

La réponse courte et simple est **NON**. Aspose et les composants Aspose sont totalement indépendants et ne sont pas affiliés à, ni autorisés, sponsorisés ou autrement approuvés par Microsoft Corporation.

- Pourquoi devrions-nous utiliser les produits Aspose plutôt que d'utiliser Microsoft Office Automation ?

La réponse la plus courte que nous puissions donner est qu'il y a de nombreuses raisons, la principale étant que *Microsoft lui-même recommande fortement de s'éloigner de l'automatisation Office pour les solutions logicielles : [Article de Microsoft](https://docs.microsoft.com/office/vba/access/concepts/why-you-should-not-automate-office).*

## **Aperçu**
Comme mentionné ci-dessus, il y a plusieurs raisons pour lesquelles les composants Aspose sont une meilleure alternative à l'automatisation. Certaines des raisons clés sont :

- Sécurité
- Stabilité
- Scalabilité/Vitesse
- Prix
- Fonctionnalités

Ci-dessous, un meilleur éclaircissement sur chacun des points clés. Assurez-vous également de visiter la section **Informations Complémentaires** qui fournit des liens vers des évaluations d'utilisateurs indépendants.

## **Sécurité**
Ce qui suit est une citation directe de l'article de Microsoft mentionné ci-dessus :

*"Les applications Office n'ont jamais été conçues pour une utilisation côté serveur, et ne tiennent donc pas compte des problèmes de sécurité auxquels sont confrontés les composants distribués. Office n'authentifie pas les demandes entrantes, et ne vous protège pas contre l'exécution non-intentionnelle de macros, ou le démarrage d'un autre serveur qui pourrait exécuter des macros, à partir de votre code côté serveur. Ne pas ouvrir des fichiers qui sont téléchargés sur le serveur depuis un Web anonyme ! En fonction des paramètres de sécurité qui ont été définis pour la dernière fois, le serveur peut exécuter des macros sous un contexte Administrateur ou Système avec des privilèges complets et compromettre votre réseau ! De plus, Office utilise de nombreux composants côté client (comme Simple MAPI, WinInet, MSDAIPP) qui peuvent mettre en cache les informations d'authentification du client afin d'accélérer le traitement. Si Office est automatisé côté serveur, une instance peut desservir plus d'un client, et comme les informations d'authentification ont été mises en cache pour cette session, il est possible qu'un client puisse utiliser les identifiants mis en cache d'un autre client, et ainsi obtenir des autorisations d'accès non accordées en usurpant d'autres utilisateurs."*

Les produits Aspose sont très sécurisés. Par conséquent, les composants Aspose ne présentent aucun risque potentiel pour les ressources vitales du système. De plus, lorsqu'un document est ouvert par un composant Aspose, les macros ne sont pas exécutées automatiquement. Les composants Aspose ont été conçus dans le but de permettre aux développeurs de créer, manipuler et enregistrer des fichiers Office. Aucun des risques associés au paquet Microsoft Office n'est inhérent aux composants Aspose.

## **Stabilité**
Ce qui suit est une citation directe de l'article de Microsoft mentionné ci-dessus :

*"Office 2000, Office XP et Office 2003 utilisent la technologie Microsoft Windows Installer (MSI) pour faciliter l'installation et l'auto-réparation pour un utilisateur final. MSI introduit le concept de "installer lors de la première utilisation", ce qui permet d'installer ou de configurer dynamiquement des fonctionnalités à l'exécution (pour le système, ou plus souvent pour un utilisateur particulier). Dans un environnement côté serveur, cela ralentit à la fois les performances et augmente la probabilité qu'une boîte de dialogue apparaisse pour demander à l'utilisateur d'approuver l'installation ou de fournir un disque d'installation approprié. Bien qu'il soit conçu pour augmenter la résilience d'Office en tant que produit destiné aux utilisateurs finaux, l'implémentation des capacités MSI d'Office est contre-productive dans un environnement côté serveur. De plus, la stabilité d'Office en général ne peut être assurée lorsqu'il s'exécute côté serveur car il n'a pas été conçu ou testé pour ce type d'utilisation. Utiliser Office comme composant de service sur un serveur réseau peut réduire la stabilité de cette machine et, par conséquent, de votre réseau dans son ensemble. Si vous prévoyez d'automatiser Office côté serveur, essayez d'isoler le programme sur un ordinateur dédié qui ne peut pas affecter des fonctions critiques, et qui peut être redémarré au besoin."*

Étant donné que les composants Aspose sont empaquetés dans une seule DLL, il n'y aura jamais besoin d'installer des parties supplémentaires pour qu'ils fonctionnent. Les composants Aspose ne sont utilisés que par des applications C++ et il n'y a aucune partie du code du composant conçue pour attendre une réponse humaine. Les composants Aspose ont été soigneusement testés et sont extrêmement stables. Les composants Aspose sont utilisés par [des entreprises](https://about.aspose.com/customers) telles que : **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** et bien d'autres encore.

## **Scalabilité/Vitesse**
Ce qui suit est une citation directe de l'article de Microsoft mentionné ci-dessus :

*"Les composants côté serveur doivent être des composants COM multi-threadés et hautement réentrants avec un minimum de surcharge et un haut débit pour plusieurs clients. Les applications Office sont, dans presque tous les respects, l'exact opposé. Ce sont des serveurs d'automatisation basés sur STA et non réentrants qui sont conçus pour fournir des fonctionnalités diverses mais gourmandes en ressources pour un seul client. Ils offrent peu de scalabilité en tant que solution côté serveur, et ont des limites fixes pour des éléments importants, tels que la mémoire, qui ne peuvent être changées par configuration. Plus important encore, ils utilisent des ressources globales (comme des fichiers mappés en mémoire, des compléments ou des modèles globaux, et des serveurs d'automatisation partagés), ce qui peut limiter le nombre d'instances pouvant s'exécuter simultanément et entraîner des conditions de concurrence si elles sont configurées dans un environnement multi-client. Les développeurs qui prévoient d'exécuter plus d'une instance de n'importe quelle application Office en même temps doivent envisager le Pooling ou la Sérialisation d'Accès à l'Application Office pour éviter les blocages potentiels ou la corruption de données."*

Les composants Aspose sont hautement scalables et extrêmement rapides. Les applications Office n'ont pas été conçues pour être simultanément utilisées par des centaines ou des milliers d'utilisateurs. Cependant, les composants Aspose sont conçus pour cela. Nos composants sont une véritable solution C++ et fonctionnent parfaitement que ce soit sur un serveur unique alimentant une application unique ou sur un Web Form équilibré en charge alimentant une application à l'échelle de l'entreprise.

## **Prix**
Lorsqu'une application utilise Microsoft Office Automation, une copie de Microsoft Office doit être achetée pour chaque machine qui exécute l'application. Il y a beaucoup de cas où une application peut avoir besoin de créer ou de manipuler un fichier Office, mais ne nécessite pas que l'utilisateur ait Microsoft Office. Aspose propose une licence de redistribution très [rentable](https://purchase.aspose.com/) et libre de redevance qui permettra le déploiement à un nombre illimité d'utilisateurs sans soucis de licence. Lors de la création d'applications basées sur le web, il est important de savoir que les composants Microsoft Office Automation ne sont pas tarifés ni licenciés pour des solutions côté serveur ; par conséquent, il n'y a pas de bonne solution de licence pour déployer des applications web qui utilisent les composants Microsoft Office. Aspose propose également une solution très [rentable](https://purchase.aspose.com/) pour les applications basées sur serveur.

## **Fonctionnalités**
Les composants Aspose fournissent tout ce qui est nécessaire pour gérer des fichiers Office, ainsi que bien plus. Ils sont conçus avec la philosophie de permettre aux développeurs d'obtenir les meilleurs résultats avec le minimum de travail. Contrairement à l'automatisation Office, les composants Aspose fournissent de nombreuses fonctions puissantes et économisant du temps. Par exemple, [Aspose.Cells](https://products.aspose.com/cells/cpp/) permet aux développeurs d'importer des données d'un **DataTable** ou **DataView** directement dans un fichier Excel. [Aspose.Words](https://products.aspose.com/words/net/) offre une fonctionnalité similaire permettant aux développeurs de remplir un document Word (qui est une fusion de courrier) directement à partir de n'importe quel objet de données C++. [Chaque Composant](https://products.aspose.com/total/cpp/) de la famille Aspose offre son propre ensemble de fonctionnalités uniques et puissantes. La meilleure partie de l'achat d'un composant Aspose est d'avoir accès à nos équipes de développement. Nos équipes de développement réalisent que si une fonctionnalité dont votre entreprise a besoin, il est probable que d'autres entreprises en auront également besoin. Bien que toutes les demandes de fonctionnalités ne puissent pas être ajoutées, nos équipes essaient d'être très ouvertes d'esprit et flexibles lorsqu'elles fournissent une assistance. Cet état d'esprit est ce qui a aidé les composants Aspose à devenir aussi puissants qu'ils le sont. S'il y a des fonctionnalités supplémentaires dont vous avez besoin à partir des objets d'automatisation Office, vos chances de les voir ajoutées sont très, très faibles.

## **Conclusion**
{{% alert color="primary" %}} 

Bien que cet article ait couvert de nombreux points clés expliquant pourquoi les composants Aspose sont un meilleur choix que l'automatisation Office, il y en a beaucoup, beaucoup d'autres. Cet article aborde principalement uniquement les points les plus clés. Tous les différents composants Aspose offrent une version d'[Évaluation](https://downloads.aspose.com/slides/cpp) sans risque et sans obligation. Nous vous encourageons à profiter de cette [Évaluation](https://downloads.aspose.com/slides/cpp) afin de mieux voir ce que Aspose peut faire pour vos applications.