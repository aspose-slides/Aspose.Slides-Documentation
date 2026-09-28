---
title: Licenza
type: docs
weight: 50
url: /it/jasperreports/licensing/
description: "Scopri cosa aggiunge la versione di valutazione di Aspose.Slides per JasperReports ai file esportati e come applicare una licenza in JasperReports e JasperReports Server."
---
{{% alert color="info" title="Note" %}}
Aspose.Slides per JasperReports è disponibile come valutazione gratuita e senza limiti di tempo dalla [pagina di download](https://releases.aspose.com/slides/jasperreport/). Le versioni di valutazione e con licenza del prodotto sono lo stesso download.

Quando sei soddisfatto della valutazione, [acquista una licenza](https://purchase.aspose.com/pricing/slides/jasperreports/). Assicurati di comprendere e accettare i termini di abbonamento.

La licenza è disponibile per il download dalla pagina dell'ordine dopo che l'ordine è stato pagato. La licenza è un file XML in chiaro, firmato digitalmente, che contiene informazioni come il nome del cliente, il prodotto acquistato e il tipo di licenza. Non modificare in alcun modo il contenuto del file di licenza: farlo invalida la licenza.

Scarica la licenza sul tuo computer e copiala nella cartella appropriata (ad esempio la cartella della tua applicazione o **JasperReports\lib**).
{{% /alert %}}

## **Limite della versione di valutazione**
La versione di valutazione di Aspose.Slides per JasperReports (senza una licenza specificata) esporta ogni pagina del report, ma inserisce una filigrana di valutazione al centro di ogni diapositiva o pagina, in tutti e quattro i formati di output (PPT, PPTX, PDF e HTML), come mostrato nella figura sottostante. Vedi [Valuta Aspose.Slides](/slides/it/jasperreports/evaluate-aspose-slides/) per i dettagli.

![La filigrana di valutazione al centro di una diapositiva esportata](evaluation_watermark.png)

## **Applicare una licenza**
Ci sono diversi modi per applicare una licenza, a seconda che tu stia lavorando su JasperReports o su JasperServer.

### **Applicare una licenza per JasperReports**
Chiama il metodo `setLicense` della classe `License` con uno stream che legge il file di licenza, come in Aspose.Slides per Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Crea un oggetto stream contenente il file di licenza.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Istanzia la classe License.
            License license = new License();

            // Imposta la licenza tramite l'oggetto stream.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Oppure, passa il percorso del file di licenza all'esportatore nel parametro `ASExporterParameters.PPT_LICENSE`. In questo frammento, `jasperPrint` è un report compilato, come in [La tua prima esportazione](/slides/it/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applicare una licenza su JasperServer**
Imposta la proprietà `licenseFile` del bean `pptExportParameters` in *applicationContext.xml* al percorso del file di licenza, come mostrato in [Integrazione con JasperServer](/slides/it/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).