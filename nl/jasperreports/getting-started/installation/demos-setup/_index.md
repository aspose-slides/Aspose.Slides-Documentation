---
title: Demo's installatie
type: docs
weight: 70
url: /nl/jasperreports/demos-setup/
---
Alle demo's die worden meegeleverd met Aspose.Slides for JasperReports zijn aangepaste standaarddemo's. Het is beter om alle demo's te kopiëren naar de JasperReports demo map:
...\jasperreports-x.x.x\demo\samples\

Gebruik de standaard commando volgorde om rapporten te bouwen en te exporteren:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Vergeet niet HSQLDB te starten met de testdatabase om de rapporten te vullen met gegevens en kopieer aspose.slides.jasperreports.library-xx.x.jar uit de \lib\JasperReports X.X.X - X.X.X map van aspose-slides-xx.x-jasperreports.zip naar &#60;InstallDir&#62;\lib map.

{{% /alert %}} 

De meeste demo's (behalve Charts) beschikken al over gegenereerde presentaties, zodat je alle ant-stappen kunt overslaan en de resultaten direct kunt bekijken.