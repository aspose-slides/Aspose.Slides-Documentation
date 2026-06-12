---
title: Domande Frequenti
type: docs
weight: 110
url: /it/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Questa pagina raccoglie diverse domande frequenti su:

- [Formati file supportati](#Supported-File-Formats).
- [Supporto per i servizi di reporting Power BI](#Support-for-Power-BI-Reporting-services).
- [Installazione](#Installation).
- [Configurazione di esportazione](#Export-Configuration).

{{% /alert %}} 
### **Formati File Supportati**
#### **Q: Quali formati è possibile esportare i report usando Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services consente di esportare qualsiasi report in formato PPT, PPS, PPTX, PPSX, XPS o RPL.
### **Supporto per i servizi di reporting Power BI**
#### **Q: Aspose.Slides for Reporting Services supporta Power BI?**
**A**: Sì. Aspose.Slides for Reporting Services supporta l'esportazione di report paginati (RDL) in Power BI.
### **Installazione**
#### **Q: Il programma di installazione non si avvia. L'installazione manuale non porta al risultato desiderato.**
**A** : Assicurati che .NET Framework 3.5 sia installato sul tuo sistema.
#### **Q: Opzioni di esportazione mancanti dopo l'installazione di Aspose.Slides for Reporting Services.**
**A**: Se qualche CodeGroup in rssrvpolicy.config non funziona correttamente, l'interprete del file di configurazione potrebbe saltare le ultime sezioni del gruppo. Sposta quindi tutti i CodeGroup associati a Aspose.Slides for Reporting Services nella parte superiore del blocco che contiene i CodeGroup di Aspose.Slides for Reporting Services.
#### **Q: Impossibile caricare il file o l'assembly Aspose.Slides.ReportingServices (Impossibile acquisire il permesso di esecuzione \ Eccezione da HRESULT: 0x80131418).**
**A**: Il codice di errore (0x80131418) indica che il modulo dll non dispone di diritti sufficienti. Ciò può dipendere da una funzione di sicurezza che ha bloccato l'accesso completo al file .dll se è stato ottenuto da un altro computer. È possibile risolvere il problema aprendo la finestra delle proprietà del file dll e facendo clic sul pulsante "Unblock" nel pannello "Security".
#### **Q: Impossibile trovare la licenza 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Il file di licenza deve trovarsi accanto al dll o nella directory Program Files(x86)\Aspose\Slides\.
### **Configurazione di esportazione**
#### **Q: Come posso cambiare il colore dei collegamenti ipertestuali in un report esportato?**
**A**: Ogni estensione di rendering di Aspose.Slides for Reporting Services in rsreportserver.config ha una propria configurazione. Per cambiare il colore del collegamento ipertestuale, imposta il valore desiderato nella sezione <HyperlinkColor>.
#### **Q: Nelle presentazioni esportate, il testo nelle tabelle è allungato verticalmente.**
**A**: Questo viene effettuato per rendere il documento più leggibile. Per visualizzare il testo nella tabella così com'è nel report, imposta l'estensione di Aspose.Slides for Reporting Services su "Normal" nel file di configurazione rsreportserver.config.