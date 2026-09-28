---
title: Requisiti di sistema
type: docs
weight: 60
url: /it/jasperreports/system-requirements/
description: "Verifica quali versioni di JasperReports e Java sono supportate da Aspose.Slides per JasperReports e cosa è necessario su Linux."
---
## **JasperReports**

Aspose.Slides for JasperReports funziona con JasperReports dalla versione 3.7.2 alla 6.16.0. Il download contiene un jar separato per ciascuna delle tre fasce di versione — vedere [Installazione di Aspose.Slides per JasperReports](/slides/it/jasperreports/installing-aspose-slides-for-jasperreports/) per sapere quale utilizzare. Non esiste alcun jar per JasperReports 6.17.0 o versioni successive, inclusa JasperReports 7.

Il supporto per JasperReports 2.0.3 fino a 3.7.1 è terminato in Aspose.Slides for JasperReports 17.6. La versione 17.5 e precedenti supportavano anche tali versioni.

## **Java**

I jar sono compilati per Java 6 o versioni successive, come indica *JDK 1.6* nei nomi delle cartelle, quindi la versione di Java necessaria è quella richiesta dalla versione di JasperReports in uso. Con JasperReports 6.16.0, le esportazioni vengono eseguite su Java 11, 17, 21 e 25.

## **Sistema operativo**

I jar contengono solo classi e risorse Java, senza librerie native, e non utilizzano Microsoft PowerPoint. Su Linux, JasperReports richiede fontconfig e almeno un font installato per generare un report.

## **JasperReports Server**

Per JasperReports Server, utilizzare entrambi i jar dalla cartella che corrisponde alla versione di JasperReports in esecuzione sul server — vedere [Integrazione con JasperServer](/slides/it/jasperreports/integration-with-jasperserver/).