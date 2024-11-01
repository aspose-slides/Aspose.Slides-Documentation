---
title: Introduction &amp; Configuration de l'environnement
type: docs
weight: 10
url: /fr/reportingservices/introduction-&amp;-configuration-de-l-environnement/
---

{{% alert color="primary" %}} 

Il y a eu des demandes dans le passé concernant l'intégration d'Aspose.Slides pour Reporting Services avec SharePoint. Dans cet article, nous nous concentrerons sur SharePoint 2010. On suppose que vous avez déjà configuré un environnement de ferme SharePoint. Les exemples que nous suivrons dans cet article seront pour un SharePoint Cloud complet, mais les étapes seront similaires pour un serveur SharePoint Foundation. Avant de procéder, commençons par quelques documentations clés que vous pouvez utiliser comme référence lorsque vous faites cela : 

- [Aperçu de l'intégration de Reporting Services et de la technologie SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Configuration de Reporting Services pour l'intégration de SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configuration de l'environnement**
La configuration que nous allons utiliser se compose de **4 serveurs**. Cela inclut un **contrôleur de domaine**, un **serveur SQL**, un **serveur SharePoint** et un serveur pour **Reporting Services**. Vous pouvez choisir d'avoir SharePoint et Reporting Services sur la même machine. 