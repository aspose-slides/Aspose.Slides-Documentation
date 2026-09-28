---
title: Licenties
type: docs
weight: 50
url: /nl/jasperreports/licensing/
description: "Leer wat de evaluatieversie van Aspose.Slides voor JasperReports toevoegt aan geëxporteerde bestanden, en hoe u een licentie toepast in JasperReports en JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides voor JasperReports is beschikbaar als een gratis, tijdonbeperkte evaluatie vanaf de [download page](https://releases.aspose.com/slides/jasperreport/). De evaluatie‑ en gelicentieerde versies van het product zijn dezelfde download.

Wanneer u tevreden bent met de evaluatie, [buy a license](https://purchase.aspose.com/pricing/slides/jasperreports/). Zorg ervoor dat u de abonnementsvoorwaarden begrijpt en ermee akkoord gaat.

De licentie is beschikbaar voor download vanaf de bestelpagina nadat de bestelling betaald is. De licentie is een platte tekst, digitaal ondertekend XML‑bestand dat informatie bevat zoals de klantnaam, het gekochte product en het licentietype. Wijzig de inhoud van het licentiebestand op geen enkele manier: dit maakt de licentie ongeldig.

Download de licentie naar uw computer en kopieer deze naar de juiste map (bijvoorbeeld uw toepassingsmap of **JasperReports\lib**).
{{% /alert %}}

## **Beperking evaluatieversie**
De evaluatieversie van Aspose.Slides voor JasperReports (zonder opgegeven licentie) exporteert elke pagina van het rapport, maar plaatst een evaluatiewatermerk in het midden van elke dia of pagina, in alle vier de uitvoerformaten (PPT, PPTX, PDF en HTML), zoals hieronder weergegeven. Zie [Evalueer Aspose.Slides](/slides/nl/jasperreports/evaluate-aspose-slides/) voor details.

![Het evaluatiewatermerk in het midden van een geëxporteerde dia](evaluation_watermark.png)

## **Een licentie toepassen**
Er zijn verschillende manieren om een licentie toe te passen, afhankelijk van of u werkt met JasperReports of JasperServer.

### **Een licentie toepassen voor JasperReports**
Roep de `setLicense`‑methode van de `License`‑klasse aan met een stream die het licentiebestand leest, zoals in Aspose.Slides voor Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Maak een stream-object dat het licentiebestand bevat.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instantieer de License-klasse.
            License license = new License();

            // Stel de licentie in via het stream-object.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Of geef het pad van het licentiebestand door aan de exporter in de `ASExporterParameters.PPT_LICENSE`‑parameter. In dit fragment is `jasperPrint` een gevulde rapport, zoals in [Uw eerste export](/slides/nl/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Een licentie toepassen op JasperServer**
Stel de `licenseFile`‑eigenschap van de `pptExportParameters`‑bean in *applicationContext.xml* in op het pad van het licentiebestand, zoals getoond in [Integratie met JasperServer](/slides/nl/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).