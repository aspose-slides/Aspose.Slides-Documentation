---
title: Υποστήριξη ενσωμάτωσης βίντεο στην παρουσίαση
type: docs
weight: 80
url: /el/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Το Microsoft SQL Server Reporting Services δεν διαθέτει ενσωματωμένες δυνατότητες εξαγωγής αναφορών με ενσωματωμένο βίντεο σε παρουσιάσεις PowerPoint. Το Aspose.Slides for Reporting Services 4.10 και εκδόσεις μετά από αυτήν υποστηρίζουν την ενσωμάτωση βίντεο μέσα στην παρουσίαση. 

{{% /alert %}} 

Για να ενσωματώσετε βίντεο στις διαφάνειες, παρακαλώ προσθέστε στην αναφορά ένα πλαίσιο κειμένου με το κείμενο: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Λειτουργεί για την έκδοση SQL Server 2008 και μεταγενέστερες. Η δυνατότητα υποστηρίζεται μόνο για εξαγωγή PPTX.