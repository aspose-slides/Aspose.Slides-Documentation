---
title: Configuration des démos
type: docs
weight: 70
url: /fr/jasperreports/demos-setup/
---
Tous les démos fournis avec Aspose.Slides pour JasperReports sont des démos standard modifiées. Il vaut mieux copier toutes les démos dans le dossier de démonstration de JasperReports :
...\jasperreports-x.x.x\demo\samples\

Utilisez la séquence de commandes standard pour compiler et exporter les rapports :

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Veuillez ne pas oublier d’exécuter HSQLDB avec la base de données de test pour remplir les rapports avec des données et copier aspose.slides.jasperreports.library-xx.x.jar depuis le dossier \lib\JasperReports X.X.X - X.X.X du fichier aspose-slides-xx.x-jasperreports.zip vers le répertoire &#60;InstallDir&#62;\lib.

{{% /alert %}} 

La plupart des démos (sauf Charts) ont déjà des présentations générées, vous pouvez donc sauter toutes les étapes “ant” et vérifier les résultats immédiatement.