---
title: Configurazione delle demo
type: docs
weight: 70
url: /it/jasperreports/demos-setup/
description: "Configura i progetti demo dal download di Aspose.Slides per JasperReports, modifica la classe esportatore che utilizzano e compilali con Ant."
---
## **Cosa sono le demo**

La cartella *samples* del download di Aspose.Slides per JasperReports contiene otto progetti demo: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* e *xmldatasource*. Sono demo standard di JasperReports, modificate per aggiungere un target di build `ppt` che esporta il report compilato in PPT. Il download non contiene presentazioni esportate; le crei compilando una demo.

## **Modifica la classe esportatore prima di compilare**

Nella versione distribuita, il codice Java delle demo utilizza `com.aspose.slides.jasperreports.JRPptExporter`, una classe che i jar attuali non contengono, quindi le demo non compilano. Nella classe dell'applicazione della demo (ad esempio, *ShapesApp.java* nella demo *shapes*), sostituisci `JRPptExporter` con `ASPptExporter`, l'esportatore PPT nello stesso package. La demo *fonts* importa l'intero package, quindi cambia solo il nome della classe nel suo codice.

Le demo utilizzano anche classi di JasperReports che le versioni successive di JasperReports hanno rimosso, come `JExcelApiExporter` e `JRExporterParameter.FONT_MAP`. Con la modifica precedente, le demo compilano come segue:

| Versione JasperReports | Demo che compilano |
| :- | :- |
| 5.5.1 | all eight |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **Compila una demo**

Il *build.xml* di ogni demo si aspetta la struttura delle cartelle di un progetto JasperReports: compila contro *../../../build/classes* e i jar in *../../../lib*, relativi alla cartella della demo.

1. Copia la cartella della demo in *demo/samples* nella cartella del tuo progetto JasperReports.  
2. Copia *aspose.slides.jasperreports.library-xx.x.jar* dalla sottocartella *lib* del download che corrisponde alla tua versione di JasperReports nella cartella *lib* del progetto JasperReports. Vedi [Installing Aspose.Slides for JasperReports](/slides/it/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. Inserisci il jar della tua versione di JasperReports e i jar da cui dipende nella stessa cartella *lib*. Oltre ai file della demo, *build.xml* aggiunge solo *build/classes* e i jar sotto *lib* al classpath, e *build/classes* contiene le classi di JasperReports solo dopo aver compilato JasperReports dal sorgente.  
4. Le demo *charts*, *subreport* e *text* leggono il database di esempio HSQLDB di JasperReports (`jdbc:hsqldb:hsql://localhost`), quindi avvia prima il suo server, come descritto in *samples/Readme.txt* del download. Le altre demo non richiedono alcun database.  
5. Nella cartella della demo, compila l'applicazione, compila il layout del report, riempilo e esportalo in PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Il target `ppt` scrive la presentazione accanto al report compilato, con lo stesso nome del report (ad esempio, *LandscapeReport.ppt*).

Due demo richiedono più passaggi rispetto a quelli sopra:

- La demo *images* carica un'immagine da `http://jasperreports.sourceforge.net/jasperreports.png` durante l'esportazione. Questo indirizzo ora reindirizza a HTTPS, quindi il passaggio `ppt` non genera alcuna presentazione finché non cambi l'indirizzo in `https://` in *ImagesReport.jrxml*. Con JasperReports 6.4.0, l'esportazione di quell'immagine fallisce anche su HTTPS.  
- Il report *xmldatasource* utilizza il font Arial. Su un sistema senza Arial, `ant fill` segnala che il font "is not available to the JVM" e non genera alcun report compilato, quindi `ant ppt` non ha nulla da esportare. La build segnala comunque successo, perciò controlla l'output di ciascun passaggio.