---
title: Prérequis d'installation
type: docs
weight: 20
url: /fr/reportingservices/installation-prerequisites/
---

{{% alert color="primary" %}} 

Les prérequis suivants doivent être respectés avant de procéder à l'installation. 

{{% /alert %}} 
## **Module complémentaire Reporting Services pour SharePoint**
Le **module complémentaire Reporting Services pour SharePoint** est l'un des composants clés pour que l'intégration fonctionne correctement. Le module complémentaire doit être installé sur l'un des **Web Front Ends (WFE)** de votre ferme SharePoint, ainsi que sur le serveur Central Admin. L'un des nouveaux changements avec SQL 2008 R2 et SharePoint 2010 est que le module complémentaire 2008 R2 est désormais un prérequis pour l'installation de SharePoint. Cela signifie que le module complémentaire RS sera installé lorsque vous procéderez à l'installation de SharePoint. Cela a été montré et souligné dans la figure ci-dessous. Cela évite en fait de nombreux problèmes que nous avons rencontrés avec SP 2007 et RS 2008 lors de l'installation du module complémentaire. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figure 1**: Module complémentaire Reporting Services pour SharePoint 
## **Authentification SharePoint**
Avant de plonger dans les éléments d'intégration RS, il est important de s'occuper de la façon dont vous configurez votre **site** dans la ferme SharePoint. Plus précisément, comment vous configurez l'authentification pour le site ; si ce sera **Classique** ou **Claims**. Ce choix est important au début. Je ne crois pas que vous puissiez changer cette option une fois qu'elle est faite. Si vous pouvez le changer, ce ne sera pas un processus simple. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 n'est PAS conscient des Claims 

{{% /alert %}} 

Même si vous choisissez que votre site SharePoint utilise **Claims**, Reporting Services lui-même n'est pas conscient des Claims. Cela affecte le fonctionnement de l'authentification avec Reporting Services. Alors, quelle est la différence du point de vue de Reporting Services ? Cela dépend de si vous souhaitez transmettre les informations d'identification de l'utilisateur à la source de données. 

***Classique***   - Peut utiliser Kerberos et transférer les informations d'identification de l'utilisateur à votre source de données en arrière-plan (vous devrez utiliser Kerberos pour cela). 

***Claims*** ** - Un jeton Claims est utilisé et non un jeton Windows. RS utilisera toujours l'authentification de confiance dans ce scénario et n'aura accès qu'au jeton SPUser. Vous devrez stocker vos informations d'identification au sein de votre source de données. 

Pour l'instant, nous voulons juste nous concentrer sur la configuration de RS. À ce stade, SharePoint est installé sur la boîte SharePoint et configuré avec un **site d'authentification classique** sur le **port 80**. De plus, sur le serveur RS, j'ai **juste installé Reporting Services** et c'est tout. 