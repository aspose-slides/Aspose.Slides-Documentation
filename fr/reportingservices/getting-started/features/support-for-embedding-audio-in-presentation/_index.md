---
title: Support pour l'intégration de l'audio dans la présentation
type: docs
weight: 90
url: /reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services n'a pas de capacités intégrées pour exporter des rapports avec de l'audio intégré vers des présentations PowerPoint. Aspose.Slides pour Reporting Services 4.10 et les versions ultérieures prennent en charge l'intégration de l'audio dans la présentation exportée. 

{{% /alert %}} 

Pour intégrer de l'audio dans les diapositives, veuillez ajouter au rapport une zone de texte avec le texte : 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Cela fonctionne pour SQL Server version 2008 et ultérieure. La fonctionnalité est prise en charge uniquement pour l'exportation PPTX. 