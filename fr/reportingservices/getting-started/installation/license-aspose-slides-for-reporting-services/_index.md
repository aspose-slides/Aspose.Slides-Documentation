---
title: Licence Aspose.Slides for Reporting Services
type: docs
weight: 70
url: /fr/reportingservices/license-aspose-slides-for-reporting-services/
keywords:
- licence
- gestion des licences
- filigrane d'évaluation
- licence temporaire
- Aspose.Slides for Reporting Services
description: "Appliquer une licence à Aspose.Slides for Reporting Services en copiant le fichier de licence sur le serveur de rapports, et vérifier que les présentations exportées ne comportent plus de filigrane d'évaluation."
---
## **Support de licence**

La version d'évaluation d'Aspose.Slides for Reporting Services est le même paquet que celui acheté, depuis [sa page de téléchargement](https://releases.aspose.com/slides/reportingservices/), et offre les mêmes fonctionnalités. Sans licence, elle fonctionne en mode d'évaluation et insère un filigrane d'évaluation dans les présentations exportées.

La version d'évaluation devient sous licence lorsque vous copiez un fichier de licence sur le serveur de rapports. Aucun code n'est impliqué.

Lorsque vous êtes satisfait de votre évaluation, vous pouvez [acheter une licence](https://purchase.aspose.com/pricing/slides/reporting-services/). Nous vous recommandons de parcourir les différents types d'abonnement. Si vous avez des questions, contactez l'équipe commerciale d'Aspose.

## **Licences dans Aspose.Slides for Reporting Services**

* La licence est un fichier XML en texte brut qui contient des détails tels que le nom du produit, le nombre de développeurs auxquels elle est accordée, la date d'expiration de l'abonnement, etc.
* Le fichier de licence est signé numériquement, vous ne devez donc pas le modifier. Même l'ajout involontaire d'un saut de ligne supplémentaire au contenu du fichier le rendra invalide.

Pour appliquer la licence :

1. Copiez le fichier de licence dans le dossier *ReportServer\bin* de chaque instance du serveur de rapports, où *Aspose.Slides.ReportingServices.dll* est installé — par exemple, *C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer\bin*. [Installation manuelle](/slides/fr/reportingservices/install-manually/#find-the-report-server-folder) répertorie les dossiers par défaut.
2. Assurez-vous que le fichier porte l'un des noms recherchés par l'extension : *Aspose.Slides.ReportingServices.lic*, *Aspose.Slides.Reporting.Services.lic*, *Aspose.Slides.Product.Family.lic*, *Aspose.Total.ReportingServices.lic*, *Aspose.Total.Reporting.Services.lic*, *Aspose.Total.Product.Family.lic* ou *Aspose.Total.lic*.
3. Exportez n'importe quel rapport en tant que présentation. S'il ne contient pas de filigrane, la licence est active.

L'extension recherche également le fichier de licence dans *%ProgramData%\Aspose\Slides* (généralement *C:\ProgramData\Aspose\Slides*), ainsi une copie à cet emplacement suffit pour toutes les instances sur la machine.

**Mode sous licence**

Lorsqu'un fichier de licence valide est trouvé, les présentations exportées ne comportent aucun filigrane d'évaluation.

![Un rapport exporté avec une licence : aucun filigrane d'évaluation](license-aspose-slides-for-reporting-services_2.png)

**Mode d'évaluation**

Sans licence, Aspose.Slides for Reporting Services insère un filigrane d'évaluation dans les présentations exportées.

![Un rapport exporté en mode d'évaluation, avec le filigrane d'évaluation](license-aspose-slides-for-reporting-services_1.png)

{{% alert color="info" title="Note" %}}
Pour tester Aspose.Slides for Reporting Services sans limitations, vous pouvez demander une **Licence temporaire de 30 jours**. Consultez la page [Comment obtenir une licence temporaire](https://purchase.aspose.com/temporary-license) pour plus d'informations.
{{% /alert %}}