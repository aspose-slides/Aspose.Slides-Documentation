---
title: Installazione di Aspose.Slides per JasperReports
type: docs
weight: 40
url: /it/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Scegli i jar di Aspose.Slides per JasperReports che corrispondono alla tua versione di JasperReports e aggiungili a JasperReports, a un progetto Maven o a JasperReports Server."
---
## **Scegli i jar per la tua versione di JasperReports**

Aspose.Slides per JasperReports è distribuito come file ZIP nella [pagina di download](https://releases.aspose.com/slides/it/jasperreport/). La sua cartella *lib* contiene una sottocartella per ciascuna fascia di versioni di JasperReports. Prendi i jar dalla sottocartella che copre la versione di JasperReports che utilizzi:

| Versione JasperReports | Sottocartella di *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Non esiste una sottocartella per JasperReports 6.17.0 o versioni successive, inclusa JasperReports 7. La sottocartella *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* non contiene jar, ma solo una nota che il supporto per quelle versioni è terminato in Aspose.Slides per JasperReports 17.6.

Ogni sottocartella contiene due jar; *xx.x* nei loro nomi indica la versione del prodotto:

- *aspose.slides.jasperreports.library-xx.x.jar* contiene gli esportatori per JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` e `ASHtmlExporter`) e la classe `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* contiene le azioni di esportazione per JasperReports Server. Si basa sul jar della libreria, quindi il server ha sempre bisogno di entrambi i jar dalla stessa sottocartella.

## **Aggiungi il jar della libreria a JasperReports o alla tua applicazione**

Copia *aspose.slides.jasperreports.library-xx.x.jar* dalla sottocartella corrispondente nella cartella *lib* di JasperReports o nel classpath della tua applicazione. La tua applicazione potrà quindi creare gli esportatori nel codice.

{{% alert color="info" title="Note" %}}
Su Linux, JasperReports richiede fontconfig e almeno un font installato per compilare un report. Senza font, la compilazione fallisce con l'errore "Error initializing graphic environment".
{{% /alert %}}

## **Aggiungi il jar della libreria a un progetto Maven**

Il jar è fornito nel file ZIP anziché in un repository Maven. Per usarlo in una build Maven, installalo nel tuo repository Maven locale. Per la versione 26.6, esegui questo comando nella cartella che contiene il jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Quindi aggiungilo alle dipendenze in *pom.xml*, insieme a una versione di JasperReports coperta dalla sottocartella del jar:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Gli ID di gruppo e di artefatto sono quelli scelti nel comando di installazione; devono semplicemente corrispondere. Un progetto completo che utilizza JasperReports 6.16.0 è disponibile in [Il tuo primo export](/slides/it/jasperreports/#your-first-export).

## **Aggiungi i jar a JasperReports Server**

Copia entrambi i jar dalla sottocartella corrispondente nella cartella *WEB-INF/lib* dell'applicazione web JasperReports Server, quindi registra gli esportatori come descritto in [Integrazione con JasperServer](/slides/it/jasperreports/integration-with-jasperserver/).