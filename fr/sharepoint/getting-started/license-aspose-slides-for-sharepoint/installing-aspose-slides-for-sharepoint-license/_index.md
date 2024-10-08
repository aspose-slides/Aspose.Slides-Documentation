---
title: Installation de la licence Aspose.Slides pour SharePoint
type: docs
weight: 10
url: /fr/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

Une fois que vous êtes satisfait de votre évaluation, vous pouvez [acheter une licence](https://purchase.aspose.com/buy). Avant d'acheter, assurez-vous de bien comprendre et d'accepter les conditions de souscription de la licence. La licence vous est envoyée par email lorsque la commande a été payée.

La licence est une archive ZIP contenant un paquet de solution SharePoint régulier. L'archive contient :

- Aspose.Slides.SharePoint.License.wsp – le fichier de paquet de solution SharePoint. La licence est emballée en tant que solution SharePoint pour faciliter le déploiement et le retrait à travers une ferme de serveurs.
- readme.txt – Instructions d'installation de la licence.

{{% /alert %}} 
## **Déployer la Licence**
L'installation de la licence s'effectue depuis la console du serveur via **stsadm.exe**.

{{% alert color="primary" %}} 

Les chemins sont omis dans la section suivante pour des raisons de clarté.

{{% /alert %}} 

Effectuez les étapes suivantes pour déployer la licence Aspose.Slides pour SharePoint :

1. Exécutez stsadm pour ajouter la solution au magasin de solutions SharePoint : 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Déployez la solution sur tous les serveurs de la ferme : 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Exécutez des travaux de minuterie administratifs pour compléter immédiatement le déploiement : 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Vous recevrez un avertissement lors de l'exécution de l'étape de déploiement si le service d'administration des services Windows SharePoint n'est pas en cours d'exécution. **stsadm.exe** s'appuie sur ce service et sur le service de minuterie Windows SharePoint pour répliquer les données de la solution à travers la ferme. Si ces services ne fonctionnent pas sur votre ferme de serveurs, vous devrez peut-être déployer la licence sur chaque serveur. 

{{% /alert %}} 
## **Tester la Licence**
Pour tester que la licence a été installée correctement, convertissez un document dans un nouveau format. S'il n'y a pas de filigrane d'évaluation dans le document, la licence a été activée avec succès. 