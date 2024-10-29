---
title: Déploiement et Activation
type: docs
weight: 20
url: /fr/sharepoint/deployment-and-activation/
---

## **Déploiement**
Lors du déploiement, Aspose.Slides pour SharePoint : 

- Installe le **Aspose.Slides.SharePoint.dll** dans le Global Assembly Cache et ajoute une entrée SafeControl au fichier **web.config**.
- Installe le manifeste de fonctionnalité et d'autres fichiers nécessaires dans les répertoires appropriés.
- Enregistre la fonctionnalité dans la base de données SharePoint et la rend disponible pour activation au niveau de la fonctionnalité.
## **Activation**
Aspose.Slides pour SharePoint est emballé en tant que fonctionnalité au niveau du site (collection de sites) et peut être activé ou désactivé sur les collections de sites. Lors de l'activation, la fonctionnalité apporte certaines modifications au répertoire virtuel de l'application web parente de la collection de sites. Elle : 

- Ajoute la page des paramètres de conversion au fichier sitemap.
- Copie les fichiers de ressources nécessaires dans le dossier App_GlobalResources du répertoire virtuel.