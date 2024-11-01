---
title: Désinstallation de la licence Aspose.Slides pour SharePoint
type: docs
weight: 20
url: /fr/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

Pour désinstaller la licence, veuillez suivre les étapes ci-dessous depuis la console du serveur.

1. Retirer la solution de licence de la ferme :

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Exécutez des travaux d'administration pour compléter immédiatement la rétraction :

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Attendez que la rétraction soit terminée. Vous pouvez utiliser l'administration centrale pour vérifier si la rétraction est terminée sous **Administration centrale**, puis **Opérations** et **Gestion des solutions**.
4. Supprimez la solution du magasin de solutions SharePoint :

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```