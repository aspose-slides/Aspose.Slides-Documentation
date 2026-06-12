---
title: Ondersteuning voor het insluiten van audio in presentaties
type: docs
weight: 90
url: /nl/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services heeft geen ingebouwde mogelijkheden om rapporten met ingesloten audio naar PowerPoint‑presentaties te exporteren. Aspose.Slides for Reporting Services versie 4.10 en hoger ondersteunt het insluiten van audio in de geëxporteerde presentatie. 

{{% /alert %}} 

Om audio in dia’s in te sluiten, moet u een tekstvak met de volgende tekst aan het rapport toevoegen: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Het werkt voor SQL Server versie 2008 en hoger. De functie wordt alleen ondersteund voor PPTX‑export.