---
title: Installation d'Aspose.Slides pour SharePoint
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint/
---

{{% alert color="primary" %}} 

Aspose.Slides pour SharePoint est téléchargé sous forme d'archive Aspose.Slides.SharePoint.zip. L'archive contient : 

- **Aspose.Slides.SharePoint.wsp** : Fichier de solution SharePoint. Aspose.Slides pour SharePoint est empaqueté en tant que solution SharePoint pour faciliter l'activation et la désactivation à travers la ferme de serveurs.
- **Aspose_LicenseAgreement.rtf** : Le contrat de licence utilisateur final.
- **Setup.exe** : Le programme d'installation.
- **Setup.exe.config** : Le fichier de configuration de l'installation.

{{% /alert %}} 
## **Processus d'installation**
Avant d'exécuter l'installation, le programme d'installation vérifie que :

- WSS 3.0 ou MOSS 2007 est installé.
- L'utilisateur a la permission d'installer des solutions SharePoint.
- La base de données SharePoint est en ligne.
- Le service d'administration WSS est démarré.
- Le service Timer WSS est démarré.

Les services d'administration et Timer WSS sont nécessaires car certaines actions d'installation dépendent d'un travail de minuterie pour se propager à tous les serveurs de la ferme de serveurs. 
### **Exécution de l'installation**
Pour installer Aspose.Slides pour SharePoint : 

1. Décompressez le zip Aspose.Slides.SharePoint sur le disque local du serveur MOSS 7.0 ou WSS 3.0.
2. Exécutez setup.exe et suivez les instructions à l'écran.
   Le programme d'installation effectue les actions suivantes : 
   1. Vérifie les prérequis d'installation. L'installation ne continuera pas si une vérification échoue. 

      **Exécution d'un contrôle des systèmes** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Affiche le contrat de licence utilisateur final. Vous devez accepter le contrat pour continuer. 

   **Le CLUF** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Affiche la sélection de la cible de déploiement. Sélectionnez les applications web et les collections de sites pour lesquelles la fonctionnalité doit être activée. 

   **Sélection de cibles de déploiement** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Déploie la fonctionnalité sur la ferme de serveurs. 

   **La barre de progression de l'installation** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Active Aspose.Slides pour les collections de sites sélectionnées et configure leurs applications web parentes.
7. Affiche une liste des applications web et des collections de sites pour lesquelles la fonctionnalité a été déployée et activée. 

   **Installation réussie** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)