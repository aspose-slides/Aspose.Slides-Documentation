---
title: Configuration des Services de Report
type: docs
weight: 30
url: /reportingservices/setting-up-reporting-services/
---

{{% alert color="primary" %}}

Notre premier arrêt sur le serveur RS est le Gestionnaire de Configuration des Services de Report.

{{% /alert %}}
## **Compte de Service**
Assurez-vous de comprendre quel compte de service vous utilisez pour les Services de Report. Si nous rencontrons des problèmes, cela peut être lié au compte de service que vous utilisez. Par défaut, c'est le Service Réseau. Chaque fois que je déploie de nouvelles versions, j'utilise toujours des Comptes de Domaine, car c'est là que je suis susceptible de rencontrer des problèmes. Pour cette configuration sur mon serveur, j'ai utilisé un Compte de Domaine appelé **RSService**.
## **URL du Service Web**
Nous devons configurer l'URL du Service Web. Il s'agit du répertoire virtuel **ReportServer** (vdir) qui héberge les Services Web utilisés par les Services de Report, et avec lequel SharePoint va communiquer. À moins que vous ne souhaitiez personnaliser les propriétés du vdir (c'est-à-dire SSL, ports, en-têtes d'hôte, etc…), vous devriez juste pouvoir cliquer sur Appliquer ici et être bon à aller.

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)

**Figure 3**: Configuration de l'URL du Service Web

Lorsque c'est fait, vous devriez voir la figure suivante.

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figure 4**: Configuration réussie de l'URL du Service Web
## **Base de Données**
Nous devons créer la Base de Données du Catalogue des Services de Report. Cela peut être placé sur n'importe quel moteur de base de données SQL 2008 ou SQL 2008 R2. SQL11 fonctionnerait également, mais il est encore en BETA. Cette action créera par défaut deux bases de données, **ReportServer** et **ReportServerTempDB**. 
L'autre étape importante à ce sujet est de s'assurer que vous choisissez SharePoint Intégré pour le type de base de données. Une fois ce choix fait, il ne peut pas être modifié. Veuillez consulter les Figures 5, 6 et 7 pour référence.

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figure 5**: Création de la Base de Données du Serveur de Report

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figure 6**: Configuration du Serveur de Base de Données et du Type d'Authentification

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figure 7**: Configuration du Nom de la Base de Données et du Mode

Pour les informations d'identification, c'est ainsi que le Serveur de Report communiquera avec le SQL Server. Quel que soit le compte que vous sélectionnez, il se verra attribuer certains droits au sein de la base de données Catalogue ainsi que quelques-unes des bases de données système via le RSExecRole. MSDB est l'une de ces bases de données pour l'utilisation des Abonnements, car nous utilisons SQL Agent.

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figure 8**: Configuration des Informations d'Identification de la Base de Données du Serveur de Report

Une fois cela fait, cela devrait ressembler à la figure suivante.

![todo:image_alt_text](setting-up-reporting-services_8.png)

**Figure 9**: Progression vers la Fin de la configuration de la Base de Données du Serveur de Report
## **URL du Gestionnaire de Rapports**
Nous pouvons ignorer l'URL du Gestionnaire de Rapports, car elle n'est pas utilisée lorsque nous sommes en mode SharePoint Intégré. SharePoint est notre frontend. Le Gestionnaire de Rapports ne fonctionne pas.
## **Clés de Chiffrement**
Sauvegardez vos Clés de Chiffrement et assurez-vous de savoir où vous les conservez. Si vous vous trouvez dans une situation où vous devez migrer la Base de Données ou la restaurer, vous aurez besoin de celles-ci.

![todo:image_alt_text](setting-up-reporting-services_9.png)

C'est tout pour le Gestionnaire de Configuration des Services de Report. Si vous consultez l'URL dans l'onglet URL du Service Web, cela devrait afficher quelque chose de similaire à la figure suivante.

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figure 12**: Accès au Serveur de Report après installation

Que s'est-il passé ? SharePoint est installé sur mon WFE et j'ai terminé la configuration des Services de Report. Dans cet exemple, les Services de Report et SharePoint sont sur des machines différentes. S'ils avaient été sur la même machine, vous n'auriez pas vu cette erreur. Nous devons techniquement installer SharePoint sur la boîte RS. Cela signifie que IIS sera également activé.