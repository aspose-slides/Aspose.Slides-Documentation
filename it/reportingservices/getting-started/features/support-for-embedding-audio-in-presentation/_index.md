---
title: "Supporto per l'incorporamento di audio nella presentazione"
type: docs
weight: 90
url: /it/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services non dispone di funzionalità integrate per esportare report con audio incorporato in presentazioni PowerPoint. Aspose.Slides for Reporting Services dalla versione 4.10 in poi supporta l'incorporamento di audio nelle presentazioni esportate. 

{{% /alert %}} 

Per incorporare audio nelle diapositive, inserisci nel report una casella di testo con il seguente testo: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Funziona con SQL Server versione 2008 e successive. La funzionalità è supportata solo per l'esportazione PPTX.