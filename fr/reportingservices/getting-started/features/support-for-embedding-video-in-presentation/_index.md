---
title: Prise en charge de l'intégration de vidéos dans la présentation
type: docs
weight: 80
url: /fr/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services n'a pas de capacités intégrées pour exporter des rapports avec des vidéos intégrées vers des présentations PowerPoint. Aspose.Slides for Reporting Services 4.10 et les versions ultérieures prennent en charge l'intégration de vidéos dans la présentation. 

{{% /alert %}} 

Pour intégrer une vidéo dans les diapositives, veuillez ajouter au rapport une zone de texte avec le texte :

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Cela fonctionne pour la version SQL Server 2008 et plus. Cette fonctionnalité est prise en charge uniquement pour l'exportation PPTX.