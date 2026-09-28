---
title: Installeer Aspose.Slides voor JasperReports
type: docs
weight: 40
url: /nl/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Kies de Aspose.Slides for JasperReports-jars die overeenkomen met jouw JasperReports-versie, en voeg ze toe aan JasperReports, een Maven-project of JasperReports Server."
---
## **Kies de jars voor je JasperReports‑versie**

Aspose.Slides for JasperReports wordt gedistribueerd als een ZIP‑bestand op de [downloadpagina](https://releases.aspose.com/slides/jasperreport/). De *lib*‑map bevat één submap per reeks JasperReports‑versies. Neem de jars uit de submap die overeenkomt met de JasperReports‑versie die je gebruikt:

| JasperReports‑versie | Submap van *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Er is geen submap voor JasperReports 6.17.0 of later, inclusief JasperReports 7. De submap *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* bevat geen jars, alleen een opmerking dat de ondersteuning voor die versies beëindigd is in Aspose.Slides for JasperReports 17.6.

Elke submap bevat twee jars; *xx.x* in hun namen is de productversie:

- *aspose.slides.jasperreports.library-xx.x.jar* bevat de exporters voor JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` en `ASHtmlExporter`) en de `License`‑klasse.
- *aspose.slides.jasperreports.server-xx.x.jar* bevat de export‑acties voor JasperReports Server. Het bouwt voort op de bibliotheek‑jar, dus de server heeft altijd beide jars uit dezelfde submap nodig.

## **Voeg de bibliotheek‑jar toe aan JasperReports of je toepassing**

Kopieer *aspose.slides.jasperreports.library-xx.x.jar* uit de overeenkomstige submap naar de *lib*‑map van JasperReports of naar het classpath van je toepassing. Je toepassing kan vervolgens de exporters in code aanmaken.

{{% alert color="info" title="Note" %}}
Op Linux heeft JasperReports fontconfig en minstens één geïnstalleerd lettertype nodig om een rapport te vullen. Zonder lettertypen mislukt het vullen met de fout “Error initializing graphic environment”.
{{% /alert %}}

## **Voeg de bibliotheek‑jar toe aan een Maven‑project**

De jar zit in de ZIP in plaats van in een Maven‑repository. Om deze in een Maven‑build te gebruiken, moet je hem installeren in je lokale Maven‑repository. Voor versie 26.6 voer je dit commando uit in de map die de jar bevat:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Voeg hem vervolgens toe aan de afhankelijkheden in *pom.xml*, samen met een JasperReports‑versie die door de submap van de jar wordt gedekt:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

De group‑ en artifact‑ID’s zijn die je kiest in het install‑commando; ze hoeven alleen maar overeen te komen. Een volledig project dat JasperReports 6.16.0 gebruikt, vind je in [Your first export](/slides/nl/jasperreports/#your-first-export).

## **Voeg de jars toe aan JasperReports Server**

Kopieer beide jars uit de overeenkomstige submap naar de *WEB-INF/lib*‑map van de JasperReports Server‑webapplicatie en registreer vervolgens de exporters zoals beschreven in [Integration with JasperServer](/slides/nl/jasperreports/integration-with-jasperserver/).