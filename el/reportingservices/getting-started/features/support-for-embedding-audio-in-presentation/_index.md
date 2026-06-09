---
title: Υποστήριξη ενσωμάτωσης ήχου στην παρουσίαση
type: docs
weight: 90
url: /el/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 

Το Microsoft SQL Server Reporting Services δεν διαθέτει ενσωματωμένες δυνατότητες για εξαγωγή αναφορών με ενσωματωμένο ήχο σε παρουσιάσεις PowerPoint. Το Aspose.Slides για Reporting Services έκδοση 4.10 και μεταγενέστερες υποστηρίζουν την ενσωμάτωση ήχου μέσα στην εξαχθείσα παρουσίαση. 

{{% /alert %}} 

Για να ενσωματώσετε ήχο στις διαφάνειες, παρακαλούμε προσθέστε στην αναφορά ένα πλαίσιο κειμένου με το κείμενο: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


Λειτουργεί για την έκδοση SQL Server 2008 και μεταγενέστερες. Η δυνατότητα υποστηρίζεται μόνο για εξαγωγή PPTX.