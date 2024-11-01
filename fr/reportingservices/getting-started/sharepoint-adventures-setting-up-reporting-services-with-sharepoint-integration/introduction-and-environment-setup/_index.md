---
title: Introduction et Configuration de l'Environnement
type: docs
weight: 10
url: /fr/reportingservices/introduction-and-environment-setup/
---

{{% alert color="primary" %}} 

Il y a eu des demandes dans le passé concernant l'intégration d'Aspose.Slides pour Reporting Services avec SharePoint. Dans cet article, nous allons nous concentrer sur SharePoint 2010. On suppose qu'un environnement de ferme SharePoint est déjà configuré. Les exemples que nous allons suivre dans cet article seront pour un SharePoint Cloud complet, mais les étapes seront similaires pour un serveur SharePoint Foundation. Avant de procéder, commençons par quelques documents clés que vous pouvez utiliser comme référence lorsque vous faites cela : 

- [Aperçu de l'Intégration des Technologies Reporting Services et SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Configuration de Reporting Services pour l'Intégration avec SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configuration de l'Environnement**
La configuration que nous aurons se compose de **4 serveurs**. Cela inclut un **Contrôleur de Domaine**, un **SQL Server**, un **Serveur SharePoint** et un serveur pour **Reporting Services**. Vous pouvez choisir d'avoir SharePoint et Reporting Services sur le même serveur.