---
title: Deïnstalleren van Aspose.Slides voor SharePoint-licentie
type: docs
weight: 20
url: /nl/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Om de licentie te deïnstalleren, volg de onderstaande stappen vanaf de serverconsole. 

1. Haal de licentie-oplossing terug uit de farm: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Voer administratieve timer-taken uit om de terugtrekking onmiddellijk te voltooien: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Wacht tot de terugtrekking is voltooid. Je kunt Central Administration gebruiken om te controleren of de terugtrekking is afgerond onder **Central Administration**, dan **Operations** en **Solution Management**.
4. Verwijder de oplossing uit de SharePoint-opslag voor oplossingen: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```