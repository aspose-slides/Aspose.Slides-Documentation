---
title: Licenza
type: docs
weight: 50
url: /it/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides per JasperReports è disponibile come valutazione gratuita senza limiti di tempo dalla [pagina di download](https://downloads.aspose.com/slides/it/jasperreport). La versione di valutazione e quella con licenza del prodotto sono lo stesso download.

Quando sei soddisfatto della valutazione, [acquista una licenza](https://purchase.aspose.com/buy). Assicurati di comprendere e accettare i termini dell'abbonamento.

La licenza è disponibile per il download dalla pagina dell'ordine dopo che l'ordine è stato pagato. La licenza è un file XML di testo chiaro, firmato digitalmente, che contiene informazioni come il nome del cliente, il prodotto acquistato e il tipo di licenza. Non modificare in alcun modo il contenuto del file di licenza: farlo invalida la licenza.

Scarica la licenza sul tuo computer e copiala nella cartella appropriata (ad esempio la cartella della tua applicazione o **JasperReports\lib**).

## **Limitazioni della versione di valutazione**
La versione di valutazione di Aspose.Slides (senza licenza specificata) fornisce tutte le funzionalità del prodotto, ma (quando salvi le tue presentazioni) inserisce una filigrana di valutazione al centro di ogni diapositiva come mostrato nella figura seguente:

![todo:image_alt_text](evaluation_watermark.png) 

## **Applicare una licenza**
Esistono diversi metodi per applicare una licenza, a seconda che tu stia lavorando su JasperReports o su JasperServer.

### **Applicare una licenza per JasperReports**
Usa una chiamata diretta al metodo setLicense simile a Aspose.Slides per Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Crea un oggetto stream contenente il file di licenza
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Istanzia la classe License
    License license = new License();
	
    //Imposta la licenza tramite l'oggetto stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Oppure, imposta il parametro dell'esportatore nel codice.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applicare una licenza su JasperServer**
Imposta il parametro dell'esportatore in applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```