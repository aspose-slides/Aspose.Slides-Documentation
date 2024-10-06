---
title: Questions Fréquemment Posées
type: docs
weight: 110
url: /reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

Cette page recueille un certain nombre de questions fréquemment posées sur :

- [Formats de fichiers pris en charge](#Supported-File-Formats).
- [Support pour les services de reporting Power BI](#Support-for-Power-BI-Reporting-services).
- [Installation](#Installation).
- [Configuration d'exportation](#Export-Configuration).

{{% /alert %}} 
### **Formats de Fichiers Pris en Charge**
#### **Q : Quels formats pouvez-vous utiliser pour exporter des rapports avec Aspose.Slides pour Reporting Services ?**
**R** : Aspose.Slides pour Reporting Services permet d'exporter n'importe quel rapport au format PPT, PPS, PPTX, PPSX, XPS ou RPL.
### **Support pour les Services de Reporting Power BI**
#### **Q : Aspose.Slides pour Reporting Services prend-il en charge Power BI ?**
**R** : Oui. Aspose.Slides pour Reporting Services prend en charge l'exportation de rapports paginés (RDL) vers Power BI.
### **Installation**
#### **Q : Le programme d'installation ne démarre pas. L'installation manuelle ne conduit pas au résultat souhaité.**
**R** : Assurez-vous que .NET Framework 3.5 est installé sur votre système.
#### **Q : Options d'exportation manquantes après l'installation d'Aspose.Slides pour Reporting Services.**
**R** : Si un CodeGroup dans rssrvpolicy.config ne fonctionne pas correctement, le parser du fichier de configuration peut ignorer les dernières sections du groupe. Déplacez donc tous les CodeGroups associés à Aspose.Slides pour Reporting Services en haut du bloc contenant les CodeGroups d'Aspose.Slides pour Reporting Services.
#### **Q : Impossible de charger le fichier ou l'assembly Aspose.Slides.ReportingServices (L'autorisation d'exécution ne peut pas être acquise \ Exception de HRESULT : 0x80131418).**
**R** : Le code d'erreur (0x80131418) indique que le module dll n'a pas suffisamment de droits. Cela peut être dû à une fonctionnalité de sécurité qui a bloqué l'accès complet au fichier .dll s'il a été obtenu d'un autre ordinateur. Cela peut être corrigé en ouvrant la fenêtre des propriétés du fichier dll et en cliquant sur le bouton "Débloquer" dans le panneau "Sécurité".
#### **Q : Impossible de trouver la licence 'Aspose.Slides.Reporting.Services.lic'.**
**R** : Le fichier de licence doit être situé à côté du fichier dll ou dans le répertoire Program Files(x86)\Aspose\Slides\.
### **Configuration d'Exportation**
#### **Q : Comment puis-je changer la couleur des liens hypertextes dans un rapport exporté ?**
**R** : Chaque extension de rendu d'Aspose.Slides pour Reporting Services dans rsreportserver.config a sa propre configuration. Pour changer la couleur des liens hypertextes, définissez la valeur requise dans la section <HyperlinkColor>.
#### **Q : Dans les présentations exportées, le texte dans les tableaux est étiré verticalement.**
**R** : Cela est fait pour faciliter la lecture du document. Pour afficher le texte dans le tableau tel qu'il apparaît dans le rapport, définissez l'extension requise d'Aspose.Slides pour Reporting Services sur "Normal" dans le fichier de configuration rsreportserver.config.