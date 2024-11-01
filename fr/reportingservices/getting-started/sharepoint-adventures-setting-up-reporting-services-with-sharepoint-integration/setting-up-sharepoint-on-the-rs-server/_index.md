---
title: Configuration de SharePoint sur le serveur RS
type: docs
weight: 40
url: /fr/reportingservices/setting-up-sharepoint-on-the-rs-server/
---

{{% alert color="primary" %}} 

Donc, nous devons faire ce que nous avons fait pour le WFE de SharePoint. La première chose à faire est de passer par l'installation des prérequis et après cela démarrer la configuration de SharePoint. 

Pour l'installation, nous choisissons Farm de serveur et une installation complète pour correspondre à ma boîte SharePoint, car nous ne voulons pas d'une installation autonome pour SharePoint. 

{{% /alert %}} 
### **Configuration de SharePoint**
Dans l'assistant de configuration de SharePoint, nous voulons nous connecter à une ferme existante. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figure 13**: Assistante de configuration de SharePoint 

Nous allons ensuite le pointer vers la base de données **SharePoint_Config** que notre ferme utilise. Si vous ne savez pas où cela se trouve, vous pouvez le découvrir via Central Admin à travers **Paramètres système -> Gérer les serveurs dans cette ferme.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figure 14**: Assistante de configuration de SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figure 15**: Assistante de configuration de SharePoint 

Une fois que l'assistant a terminé, c'est tout ce que nous devons faire sur la boîte du serveur de rapports pour l'instant. En revenant à l'URL du ReportServer, nous verrons une autre erreur, mais cela est dû au fait que nous ne l'avons pas configuré via l'administrateur central. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figure 16**: Erreur du serveur de rapports