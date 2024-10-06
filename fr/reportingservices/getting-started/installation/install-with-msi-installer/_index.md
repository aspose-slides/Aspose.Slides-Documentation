---
title: Installer avec le programme d'installation MSI
type: docs
weight: 20
url: /reportingservices/install-with-msi-installer/
---

## **Installation**
Vous pouvez installer Aspose.Slides pour Reporting Services via un programme d'installation MSI. 

{{% alert title="Remarque" color="warning" %}} 

**Aspose.Slides pour Reporting Services** nécessite l'installation de **.NET Framework 3.5** sur la machine hôte. 

{{% /alert %}}

Exécutez ***Aspose.Slides.ReportingServices.msi*** et suivez les étapes proposées par l'installateur. 

L'installateur copiera l'assemblage et d'autres fichiers dans le répertoire spécifié et installera le produit sur l'instance par défaut des Reporting Services. Vous n'avez pas besoin de copier ou de modifier manuellement des fichiers à moins que vous ne souhaitiez ajouter des paramètres de configuration spéciaux. 

L'installation utilisant le programme d'installation MSI est la meilleure option dans la plupart des cas. Cependant, vous pouvez vouloir installer le produit manuellement dans certaines situations : 

- L'installation automatique échoue en raison de problèmes de sécurité ou d'autres raisons. 
- Le produit doit être installé sur une instance nommée (et non par défaut) des Reporting Services ou sur plusieurs instances.
- Après la mise à niveau vers la dernière version, vous souhaitez simplement remplacer l'assemblage au lieu de désinstaller l'ancienne version et d'installer la nouvelle à l'aide du programme d'installation MSI. **Remarque** que vous pourriez vous retrouver avec d'autres fichiers dans ce cas.