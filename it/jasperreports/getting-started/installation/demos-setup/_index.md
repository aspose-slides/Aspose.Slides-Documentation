---
title: Configurazione Demo
type: docs
weight: 70
url: /it/jasperreports/demos-setup/
---
Tutte le demo fornite con Aspose.Slides per JasperReports sono demo standard modificate. È consigliabile copiare tutte le demo nella cartella demo di JasperReports:
...\jasperreports-x.x.x\demo\samples\

Utilizzare la sequenza di comandi standard per compilare ed esportare i report:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
Si prega di non dimenticare di eseguire HSQLDB con il database di test per popolare i report con i dati e copiare aspose.slides.jasperreports.library-xx.x.jar dalla cartella \lib\JasperReports X.X.X - X.X.X del file aspose-slides-xx.x-jasperreports.zip nella directory &#60;InstallDir&#62;\lib. 
{{% /alert %}} 

La maggior parte delle demo (ad eccezione di Charts) dispone già di presentazioni generate, quindi è possibile saltare tutti i passaggi “ant” e verificare i risultati immediatamente.