---
title: Installation d'Aspose.Slides pour SharePoint
type: docs
weight: 10
url: /fr/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Installez Aspose.Slides for SharePoint sur une ferme SharePoint : choisissez le programme d'installation correspondant à votre version de SharePoint, exécutez la vérification du système, puis déployez et activez la solution."
---
## **Contenu du package**

Aspose.Slides for SharePoint est téléchargé depuis la [page de téléchargement](https://releases.aspose.com/slides/fr/sharepoint/) sous forme d’archive ZIP. L’archive contient un package de solution SharePoint (WSP) et un programme d’installation pour chaque version SharePoint prise en charge :

| Version SharePoint | Programme d'installation | Package de solution |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Chaque programme d’installation possède un fichier de configuration à côté (par exemple, *Setup2019.exe.config*) qui indique le package de solution qu’il installe. Le dossier *License* contient un lien vers le contrat de licence utilisateur final et les mentions de licences tierces.

Aspose.Slides for SharePoint est fourni sous forme de solution SharePoint, que SharePoint déploie sur l’ensemble de la ferme de serveurs. Sa fonctionnalité est ensuite activée ou désactivée par collection de sites.

## **Processus d'installation**

Avant l’installation, le programme d’installation exécute une vérification du système. Il vérifie que :

- SharePoint est installé sur le serveur.
- L’utilisateur actuel dispose des droits d’installation et de déploiement de solutions SharePoint.
- Le service d’administration SharePoint est démarré.
- Le service de minuterie SharePoint est démarré.
- Le package de solution indiqué dans le fichier de configuration est présent.

Les services d’administration et de minuterie sont nécessaires car certaines actions d’installation s’exécutent sous forme de travaux planifiés qui propagent la solution sur tous les serveurs de la ferme.

### **Exécution de l'installation**

Pour installer Aspose.Slides for SharePoint :

1. Décompressez l’archive ZIP sur un disque local d’un serveur de la ferme SharePoint.
2. Exécutez le programme d’installation correspondant à votre version de SharePoint (voir le tableau ci‑dessus) et suivez les instructions à l’écran. Le programme d’installation :
   1. Exécute la vérification du système. L’installation ne se poursuit pas si une vérification échoue.

      **Exécution d’une vérification du système**

      ![Écran de vérification du système du programme d'installation](installing-aspose-slides-for-sharepoint_1.png)

   2. Affiche le contrat de licence utilisateur final. Vous devez l’accepter pour continuer.

      **Le contrat de licence**

      ![Écran du contrat de licence du programme d'installation](installing-aspose-slides-for-sharepoint_2.png)

   3. Affiche les cibles de déploiement. Sélectionnez les applications web et les collections de sites où activer la fonctionnalité.

      **Sélection des cibles de déploiement**

      ![Écran des cibles de déploiement de la collection de sites du programme d'installation](installing-aspose-slides-for-sharepoint_3.png)

   4. Déploie la solution sur la ferme.

      **Progression de l'installation**

      ![Écran de progression de l'installation du programme d'installation](installing-aspose-slides-for-sharepoint_4.png)

   5. Active Aspose.Slides for SharePoint sur les collections de sites sélectionnées.
   6. Liste les applications web et les collections de sites où la solution a été déployée et activée.

      **Installation réussie**

      ![Écran d’installation terminée du programme d'installation](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Remarque" %}}
Les captures d’écran ont été prises sur SharePoint 2007. Les programmes d’installation des versions ultérieures passent par les mêmes écrans.
{{% /alert %}}

Si la même version d’Aspose.Slides for SharePoint est déjà installée, le programme d’installation propose de la réparer ou de la désinstaller. Si une autre version est installée, il propose de la mettre à jour ou de la désinstaller.

Après l’installation, un élément **Convertir via Aspose.Slides** apparaît dans le menu des fichiers des bibliothèques de documents des collections de sites sélectionnées (sur SharePoint 2007, **Convertir avec Aspose.Slides**). Pour convertir une première présentation, consultez [Converting Microsoft PowerPoint Documents into Other Formats](/slides/fr/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Ce que la solution ajoute à la ferme est décrit dans [Deployment and Activation](/slides/fr/sharepoint/deployment-and-activation/).

## **FAQ**

**Quel programme d'installation dois-je exécuter ?**

Celui dont le nom correspond à votre version de SharePoint. Par exemple, exécutez *Setup2016.exe* sur une ferme SharePoint Server 2016. Chaque programme d’installation installe uniquement son propre package de solution.

**Ai-je besoin d'un téléchargement séparé pour la version sous licence ?**

Non. Le même package fonctionne en mode d’évaluation jusqu’à ce que vous installiez la solution de licence ; voir [Installing Aspose.Slides for SharePoint License](/slides/fr/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Comment supprimer le produit ?**

Exécutez à nouveau le même programme d’installation et choisissez **Remove** ; voir [Uninstalling Aspose.Slides for SharePoint](/slides/fr/sharepoint/uninstalling-aspose-slides-for-sharepoint/).