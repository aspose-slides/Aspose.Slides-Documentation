---
title: Déploiement et activation
type: docs
weight: 20
url: /fr/sharepoint/deployment-and-activation/
description: "Ce que la solution Aspose.Slides pour SharePoint installe sur la ferme lorsqu’elle est déployée, et ce que sa fonctionnalité de collection de sites ajoute lorsqu’elle est activée."
---
## **Déploiement**

Lors du déploiement, la solution Aspose.Slides pour SharePoint :

- Installe son assembly dans le Global Assembly Cache et ajoute des entrées SafeControl pour celui‑ci dans le fichier **web.config**. Sur SharePoint 2010 et versions ultérieures, il s’agit de *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* ou *Aspose.Slides.SharePoint2016.dll* (le package SharePoint 2019 installe également *Aspose.Slides.SharePoint2016.dll*). Sur SharePoint 2007, il s’agit de *Aspose.Slides.SharePointUI.dll*, ainsi que de *Aspose.Slides.SharePoint.Deployment.dll*.
- Copie la page de conversion ainsi que ses images et autres fichiers de support vers les dossiers d’installation de SharePoint.
- Installe la fonctionnalité et la rend disponible pour activation sur les collections de sites.

## **Activation**

Aspose.Slides pour SharePoint est livré sous forme de fonctionnalité de collection de sites et peut être activé ou désactivé sur les collections de sites. Lorsqu’il est activé sur une collection de sites, la fonctionnalité ajoute :

- Sur SharePoint 2010 et versions ultérieures :
  - l’élément **Convert via Aspose.Slides** dans le menu des documents des bibliothèques de documents ;
  - l’onglet ruban **Aspose Tools** avec le bouton **Convert Slides**, qui convertit les documents sélectionnés ;
  - l’élément **View Slides** dans le menu des fichiers PPT, PPTX, PPS et PPSX.
- Sur SharePoint 2007 :
  - l’élément **Convert with Aspose.Slides** dans le menu des documents des bibliothèques de documents ;
  - l’élément **Convert All with Aspose.Slides** dans le menu **Actions** des bibliothèques de documents.

Sur SharePoint 2007, l’activation modifie également le répertoire virtuel de l’application Web parente de la collection de sites. Elle :
- Ajoute la page des paramètres de conversion au fichier sitemap.
- Copie les fichiers de ressources nécessaires dans le dossier App_GlobalResources du répertoire virtuel.

Le programme d’installation active la fonctionnalité sur les collections de sites que vous sélectionnez pendant l’[installation](/slides/fr/sharepoint/installing-aspose-slides-for-sharepoint/).