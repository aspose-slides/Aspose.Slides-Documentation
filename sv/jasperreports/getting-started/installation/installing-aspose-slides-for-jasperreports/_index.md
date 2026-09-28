---
title: Installera Aspose.Slides för JasperReports
type: docs
weight: 40
url: /sv/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Välj de Aspose.Slides for JasperReports‑jar-filerna som matchar din JasperReports‑version och lägg till dem i JasperReports, ett Maven‑projekt eller JasperReports Server."
---
## **Välj jar-filerna för din JasperReports-version**

Aspose.Slides for JasperReports distribueras som en ZIP-fil på [download page](https://releases.aspose.com/slides/jasperreport/). Dess *lib*-mapp har en underkatalog per intervall av JasperReports-versioner. Hämta jar-filerna från underkatalogen som täcker den JasperReports-version du använder:

| JasperReports-version | Underkatalog i *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Det finns ingen underkatalog för JasperReports 6.17.0 eller senare, inklusive JasperReports 7. Underkatalogen *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* innehåller inga jar-filer, bara en notering om att stöd för dessa versioner upphörde i Aspose.Slides for JasperReports 17.6.

Varje underkatalog innehåller två jar-filer; *xx.x* i deras namn är produktversionen:

- *aspose.slides.jasperreports.library-xx.x.jar* innehåller exportörerna för JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` och `ASHtmlExporter`) och `License`‑klassen.
- *aspose.slides.jasperreports.server-xx.x.jar* innehåller exportåtgärderna för JasperReports Server. Den bygger på biblioteks‑jar‑filen, så servern behöver alltid båda jar-filerna från samma underkatalog.

## **Lägg till biblioteks‑jar‑filen i JasperReports eller din applikation**

Kopiera *aspose.slides.jasperreports.library-xx.x.jar* från den matchande underkatalogen till *lib*-mappen i JasperReports eller till din applikations klassökväg. Din applikation kan då skapa exportörerna i kod.

{{% alert color="info" title="Note" %}}
På Linux kräver JasperReports fontconfig och minst ett installerat teckensnitt för att fylla en rapport. Utan teckensnitt misslyckas fyllningen med felet "Error initializing graphic environment".
{{% /alert %}}

## **Lägg till biblioteks‑jar‑filen i ett Maven‑projekt**

Jar‑filen finns i ZIP‑filen snarare än i ett Maven‑förråd. För att använda den i en Maven‑byggnad installerar du den i ditt lokala Maven‑förråd. För version 26.6 kör du följande kommando i den mapp som innehåller jar‑filen:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Lägg sedan till den i beroendena i *pom.xml*, tillsammans med en JasperReports‑version som jar‑filens underkatalog täcker:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Grupp‑ och artefakt‑ID:n är de du väljer i installationskommandot; de behöver bara matcha. Ett komplett projekt som använder JasperReports 6.16.0 finns i [Your first export](/slides/sv/jasperreports/#your-first-export).

## **Lägg till jar‑filerna i JasperReports Server**

Kopiera båda jar‑filerna från den matchande underkatalogen till *WEB-INF/lib*-mappen i JasperReports Server‑webbapplikationen, och registrera sedan exportörerna enligt beskrivningen i [Integration with JasperServer](/slides/sv/jasperreports/integration-with-jasperserver/).