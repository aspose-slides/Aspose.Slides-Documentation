---
title: Esportazione PPT, PPTX, PDF e HTML
type: docs
weight: 20
url: /it/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Scegli l'esportatore Aspose.Slides for JasperReports per output PPT, PPTX, PDF o HTML, esporta un report compilato con esso e mappa i font del report ai font della presentazione."
---
## **Esportatori**

Aspose.Slides for JasperReports aggiunge quattro esportatori a JasperReports. Ognuno di essi prende un report compilato (`JasperPrint`) ed esporta ogni pagina del report: come diapositiva in PPT e PPTX, come pagina in PDF e come immagine SVG in un unico file HTML.

| Formato output | Classe esportatore |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Le classi si trovano nel pacchetto `com.aspose.slides.jasperreports` del jar della libreria e non utilizzano Microsoft PowerPoint. Passa il report e il file di output a un esportatore con `setParameter` e `JRExporterParameter`, che JasperReports contrassegna come deprecato: gli esportatori non accettano la più recente configurazione `setExporterInput` e `setExporterOutput`.

## **Esporta un report in tutti e quattro i formati**

Il programma qui sotto si basa sul progetto di [Il tuo primo export](/slides/it/jasperreports/#your-first-export). Compila e riempie *hello.jrxml* una volta, quindi passa il report compilato a ciascun esportatore a turno. Salvalo come *src/main/java/ExportAllFormats.java* in quel progetto:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Compila e riempi il report una volta.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Esporta lo stesso report compilato con ciascun esportatore.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Eseguilo dalla cartella del progetto:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Il programma salva *hello.ppt*, *hello.pptx*, *hello.pdf* e *hello.html* nella cartella del progetto. Il metodo di supporto accetta `ASAbstractExporter`, la classe base di tutti e quattro gli esportatori. Senza licenza, ogni file di output contiene il watermark di valutazione — vedi [Valuta Aspose.Slides](/slides/it/jasperreports/evaluate-aspose-slides/).

![Un report esportato in una presentazione senza licenza](ppt-pptx-pdf-and-html-export_1.png)

## **Mappa i font**

Gli esportatori PPT e PPTX scrivono i nomi dei font del design del report nella presentazione senza modifiche. Quando un elemento di testo non specifica alcun font, JasperReports utilizza il suo font predefinito, `SansSerif`, che è un nome di font logico di Java piuttosto che un font installato. Per sostituire tali nomi, passa una mappa dai nomi dei font del report ai nomi dei font che desideri nella presentazione nel parametro `ASExporterParameters.PPT_FONT_MAP`. Le chiavi devono corrispondere esattamente ai nomi dei font nel report, includendo maiuscole/minuscole. Ogni valore deve essere un font che Java trova sulla macchina che esegue l'esportazione; gli esportatori ignorano una voce il cui font Java non riesce a trovare.

Salva questo programma come *src/main/java/MapFonts.java* nello stesso progetto. Esporta *hello.jrxml* in PPTX con `SansSerif` sostituito da Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Mappa il nome del font del report al nome del font da scrivere nella presentazione.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Eseguilo dalla cartella del progetto:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Nel file *hello-arial.pptx* salvato, il testo del report utilizza Arial al posto di `SansSerif`. Su una macchina in cui Java non trova Arial, ad esempio un sistema Linux senza di esso, il testo rimane `SansSerif`. Su JasperReports Server, imposta la stessa mappa tramite la proprietà `fontMap` del bean dei parametri di esportazione — vedi [Integrazione con JasperServer](/slides/it/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).