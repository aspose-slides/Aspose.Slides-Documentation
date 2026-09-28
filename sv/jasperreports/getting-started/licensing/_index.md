---
title: Licensiering
type: docs
weight: 50
url: /sv/jasperreports/licensing/
description: "Lär dig vad utvärderingsversionen av Aspose.Slides for JasperReports lägger till i exporterade filer, och hur du applicerar en licens i JasperReports och JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports finns tillgänglig som en gratis, tidsobestämd utvärdering från [nedladdningssidan](https://releases.aspose.com/slides/jasperreport/). Utvärderings- och licensierade versioner av produkten är samma nedladdning.

När du är nöjd med utvärderingen, [köp en licens](https://purchase.aspose.com/pricing/slides/jasperreports/). Se till att du förstår och godkänner prenumerationsvillkoren.

Licensen kan hämtas från ordersidan efter att beställningen har betalats. Licensen är en klartext, digitalt signerad XML‑fil som innehåller information såsom kundnamn, den köpta produkten och licenstypen. Ändra inte innehållet i licensfilen på något sätt: det gör licensen ogiltig.

Ladda ner licensen till din dator och kopiera den till rätt mapp (till exempel din programkatalog eller **JasperReports\lib**).
{{% /alert %}}

## **Begränsning för utvärderingsversion**
Utvärderingsversionen av Aspose.Slides for JasperReports (utan specificerad licens) exporterar varje sida i rapporten, men den placerar ett utvärderingsvattenmärke i mitten av varje bild eller sida, i alla fyra exportformat (PPT, PPTX, PDF och HTML), som visas i figuren nedan. Se [Utvärdera Aspose.Slides](/slides/sv/jasperreports/evaluate-aspose-slides/) för detaljer.

![Utvärderingsvattenmärket i mitten av en exporterad bild](evaluation_watermark.png)

## **Applicera en licens**
Det finns flera sätt att applicera en licens, beroende på om du arbetar med JasperReports eller JasperServer.

### **Applicera en licens för JasperReports**
Anropa `setLicense`‑metoden i `License`‑klassen med ett flöde som läser licensfilen, på samma sätt som i Aspose.Slides för Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Skapa ett strömobjekt som innehåller licensfilen.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instansiera License-klassen.
            License license = new License();

            // Sätt licensen via strömmobjektet.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Eller skicka sökvägen till licensfilen till exportören i parametern `ASExporterParameters.PPT_LICENSE`. I detta fragment är `jasperPrint` en ifylld rapport, som i [Din första export](/slides/sv/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applicera en licens på JasperServer**
Ställ in egenskapen `licenseFile` för bean‑en `pptExportParameters` i *applicationContext.xml* till sökvägen till licensfilen, som visas i [Integration med JasperServer](/slides/sv/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).