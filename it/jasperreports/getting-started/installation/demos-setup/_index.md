---
title: Configurazione Demo
type: docs
weight: 70
url: /it/jasperreports/demos-setup/
---
Tutti i demo forniti con Aspose.Slides per JasperReports sono demo standard modificate. È consigliabile copiare tutti i demo nella cartella demo di JasperReports:
...\jasperreports-x.x.x\demo\samples\

Usa la sequenza di comandi standard per compilare ed esportare i report:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
Si prega di non dimenticare di avviare HSQLDB con il database di test per riempire i report con i dati e copiare aspose.slides.jasperreports.library-xx.x.jar dalla cartella \lib\JasperReports X.X.X - X.X.X del file aspose-slides-xx.x-jasperreports.zip nella directory &#60;InstallDir&#62;\lib. 
{{% /alert %}} 

La maggior parte dei demo (tranne Charts) ha già presentazioni generate, quindi puoi saltare tutti i passaggi “ant” e controllare i risultati immediatamente.