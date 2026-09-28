---
title: Installation de la licence Aspose.Slides pour SharePoint
type: docs
weight: 10
url: /fr/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Installez la licence Aspose.Slides pour SharePoint sur un farm SharePoint : ajoutez la solution de licence au magasin de solutions, déployez-la et vérifiez que les fichiers convertis ne portent plus le filigrane d'évaluation."
---
{{% alert color="info" title="Remarque" %}}

Une fois que vous êtes satisfait de votre évaluation, vous pouvez [acheter une licence](https://purchase.aspose.com/pricing/slides/fr/sharepoint/). Avant d'acheter, assurez‑vous de comprendre et d’accepter les conditions d’abonnement à la licence. La licence vous est envoyée par courriel lorsque la commande a été payée.

La licence est une archive ZIP contenant un package de solution SharePoint standard. L’archive contient :

- Aspose.Slides.SharePoint.License.wsp – le fichier du package de solution SharePoint. La licence est empaquetée en tant que solution SharePoint afin de faciliter le déploiement et le retrait sur un serveur farm.
- readme.txt – Instructions d’installation de la licence.

{{% /alert %}}

## **Déploiement de la licence**

L’installation de la licence s’effectue depuis la console du serveur via **stsadm.exe**.

{{% alert color="info" title="Remarque" %}}

Les chemins sont omis dans la section suivante pour plus de clarté.

{{% /alert %}}

Effectuez les étapes suivantes pour déployer la licence Aspose.Slides pour SharePoint :

1. Exécutez stsadm pour ajouter la solution au magasin de solutions SharePoint :

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Déployez la solution sur tous les serveurs du farm :

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Lancez les travaux d’administration temporisés afin de terminer immédiatement le déploiement :

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

L’opération `addsolution` prend le chemin du fichier de solution dans `-filename` ; l’opération `deploysolution` prend le nom de la solution déjà présente dans le magasin de solutions dans `-name`.

{{% alert color="info" title="Remarque" %}}

Vous obtenez un avertissement lors de l’exécution de l’étape de déploiement si le service d’administration SharePoint n’est pas en cours d’exécution. **stsadm.exe** dépend de ce service ainsi que du service SharePoint Timer pour répliquer les données de solution sur le farm. Si ces services ne sont pas actifs sur votre farm, il peut être nécessaire de déployer la licence sur chaque serveur.

{{% /alert %}}

{{% alert color="info" title="Remarque" %}}

Sur SharePoint 2010 et versions ultérieures, les cmdlets SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` et `Start-SPAdminJob` correspondent aux opérations `addsolution`, `deploysolution` et `execadmsvcjobs`. Consultez [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Test de la licence**

Pour vérifier que la licence a été installée correctement, convertissez n’importe quelle présentation dans un nouveau format. Si aucun filigrane d’évaluation n’apparaît dans le fichier converti, la licence est active.