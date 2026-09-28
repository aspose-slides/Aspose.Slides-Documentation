---
title: Distribuzione e Attivazione
type: docs
weight: 20
url: /it/sharepoint/deployment-and-activation/
description: "Cosa la soluzione Aspose.Slides for SharePoint installa nella farm quando viene distribuita e cosa la sua feature di raccolta siti aggiunge quando viene attivata."
---
## **Distribuzione**

Durante la distribuzione, la soluzione Aspose.Slides for SharePoint:

- Installa il suo assembly nella Global Assembly Cache e aggiunge voci SafeControl al file **web.config**. Su SharePoint 2010 e versioni successive, questo è *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* o *Aspose.Slides.SharePoint2016.dll* (il pacchetto SharePoint 2019 installa anche *Aspose.Slides.SharePoint2016.dll*). Su SharePoint 2007, è *Aspose.Slides.SharePointUI.dll*, insieme a *Aspose.Slides.SharePoint.Deployment.dll*.
- Copia la pagina di conversione e le sue immagini e altri file di supporto nelle cartelle di installazione di SharePoint.
- Installa la feature e la rende disponibile per l'attivazione nelle raccolte siti.

## **Attivazione**

Aspose.Slides for SharePoint è confezionato come feature di raccolta siti e può essere attivato o disattivato nelle raccolte siti. Quando viene attivato su una raccolta siti, la feature aggiunge:

- Su SharePoint 2010 e versioni successive:
  - la voce **Convert via Aspose.Slides** al menu dei documenti nelle librerie documenti;
  - la scheda ribbon **Aspose Tools** con il pulsante **Convert Slides**, che converte i documenti selezionati;
  - la voce **View Slides** al menu dei file PPT, PPTX, PPS e PPSX.
- Su SharePoint 2007:
  - la voce **Convert with Aspose.Slides** al menu dei documenti nelle librerie documenti;
  - la voce **Convert All with Aspose.Slides** al menu **Actions** delle librerie documenti.

Su SharePoint 2007, l'attivazione apporta anche modifiche alla directory virtuale dell'applicazione web principale della raccolta siti. Essa:

- Aggiunge la pagina delle impostazioni di conversione al file sitemap.
- Copia i file di risorse necessari nella cartella App_GlobalResources nella directory virtuale.

Il programma di installazione attiva la feature sulle raccolte siti che selezioni durante [installazione](/slides/it/sharepoint/installing-aspose-slides-for-sharepoint/).