---
title: Configuration de Reporting Services pour SharePoint
type: docs
weight: 50
url: /reportingservices/reporting-services-sharepoint-configuration/
---

{{% alert color="primary" %}} 

Maintenant que SharePoint est installé et configuré sur le serveur RS et que RS est configuré via le Gestionnaire de configuration de Reporting Services, nous allons passer à la configuration dans l'administration centrale. RS 2008 R2 a vraiment simplifié ce processus. Avant, nous avions un processus en 3 étapes à réaliser pour que cela fonctionne. Maintenant, nous n'avons qu'une seule étape. 

Nous souhaitons aller sur le site Web de l'administrateur central, puis dans les paramètres d'application généraux. Vers le bas, nous verrons Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)

**Figure 17** : Configuration de SharePoint 

{{% alert color="primary" %}} 

Cliquez sur " **Intégration des services de rapport**". 

{{% /alert %}} 
## **URL du service Web**
Nous fournirons l'URL du serveur de rapports que nous avons trouvée dans le Gestionnaire de configuration de Reporting Services. 
## **Mode d'authentification**
Nous sélectionnerons également un mode d'authentification. Le lien MSDN suivant explique en détail ce que sont ces modes. 
[Vue d'ensemble de la sécurité pour Reporting Services en mode intégré de SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

En résumé, si votre site utilise **l'authentification basée sur des revendications**, vous utiliserez toujours l'authentification de confiance, quel que soit votre choix ici. Si vous souhaitez transmettre des informations d'identification Windows, vous devrez choisir l'authentification Windows. Pour l'authentification de confiance, nous passerons le jeton SPUser et ne nous fierons pas aux informations d'identification Windows. 

Vous voudrez également utiliser l'authentification de confiance si vous avez configuré vos sites en mode classique pour NTLM et si RS est configuré pour NTLM. Kerberos serait nécessaire pour utiliser l'authentification Windows et pour le transmettre à votre source de données. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)

**Figure 18** : Paramétrage des informations d'identification d'intégration des services de rapport
## **Activer la fonctionnalité**
Cela vous donne l'option d'activer les services de rapport sur toutes les collections de sites, ou vous pouvez choisir celles sur lesquelles vous souhaitez l'activer. Cela signifie simplement quels sites pourront utiliser les services de rapport. 
Une fois cela fait, vous devriez voir la figure suivante. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)

**Figure 19** : Intégration réussie des services de rapport avec l'environnement SharePoint 

En revenant à l'URL du serveur de rapports comme indiqué dans la figure 14, nous devrions voir quelque chose de similaire à la figure suivante. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)

**Figure 20** : Vérification réussie des services de rapport avec l'environnement SharePoint 

{{% alert color="primary" %}} 

Si votre site SharePoint est configuré pour SSL, il n'apparaîtra pas dans cette liste. C'est un problème connu et cela ne signifie pas qu'il y a un problème. Vos rapports devraient toujours fonctionner. 

{{% /alert %}} 

Maintenant, nous sommes prêts à utiliser les services de rapport dans SharePoint 2010. Comme dans la version précédente, nous avons une fonctionnalité (activée lorsque nous configurons l'intégration des services de rapport) dans la "Fonctionnalité de collection de sites". De plus, l'installation a ajouté 3 types de contenu à ajouter à notre site. Dans la figure 21, nous pouvons voir 2 de ces types de contenu ajoutés dans une bibliothèque de documents pour créer un rapport personnalisé, comme nous pouvons le voir dans la figure 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)

**Figure 21** : Constructeur de rapports 

Le “ **Constructeur de rapports”** est un ActiveX que nous devons télécharger sur le serveur, comme nous pouvons le voir dans la figure 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)

**Figure 22** : Télécharger et installer le constructeur de rapports 

Lorsque le téléchargement sera terminé, lancez le **“Constructeur de rapports”**. Maintenant, nous sommes prêts à concevoir notre premier rapport, comme nous pouvons le voir dans la figure 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23** : Assistant de génération de nouveau rapport du constructeur de rapports 

Après avoir créé notre rapport, nous pourrions l'enregistrer dans la bibliothèque de documents créée pour y mettre les rapports dans notre SharePoint 2010. 

L'autre type de contenu doit être utilisé pour créer une connexion partagée comme source de données et les enregistrer dans une bibliothèque de documents dans SharePoint. Nous pouvons créer une bibliothèque de documents, ajouter ce type de contenu et ensuite avoir nos connexions disponibles pour changer la source de données des rapports. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)

**Figure 24** : Exportation réussie du rapport vers le serveur de rapports