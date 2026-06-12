---
title: Supporto per l'inserimento di video nella presentazione
type: docs
weight: 80
url: /it/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services non dispone di funzionalità integrate per esportare report con video incorporato in presentazioni PowerPoint. Aspose.Slides per Reporting Services dalla versione 4.10 in poi supporta l'incorporamento di video all'interno della presentazione. 
{{% /alert %}} 
Per incorporare video nelle diapositive, aggiungi al report una casella di testo con il seguente contenuto: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

Funziona con la versione 2008 di SQL Server e successive. La funzionalità è supportata solo per l'esportazione PPTX.