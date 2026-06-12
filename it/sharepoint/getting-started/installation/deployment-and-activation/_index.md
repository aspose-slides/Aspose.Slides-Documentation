---
title: Distribuzione e Attivazione
type: docs
weight: 20
url: /it/sharepoint/deployment-and-activation/
---
## **Distribuzione**
Durante la distribuzione, Aspose.Slides per SharePoint:

- Installa il **Aspose.Slides.SharePoint.dll** nella Global Assembly Cache e aggiunge una voce SafeControl al file **web.config**.
- Installa il manifesto della funzionalità e gli altri file necessari nelle directory appropriate.
- Registra la funzionalità nel database di SharePoint e la rende disponibile per l'attivazione a livello di funzionalità.
## **Attivazione**
Aspose.Slides per SharePoint è confezionato come funzionalità a livello di sito (collezione di siti) e può essere attivato o disattivato sulle collezioni di siti. Durante l'attivazione, la funzionalità apporta alcune modifiche alla directory virtuale dell'applicazione web genitore della collezione di siti. Essa:

- Aggiunge la pagina delle impostazioni di conversione al file sitemap.
- Copia i file di risorsa necessari nella cartella App_GlobalResources nella directory virtuale.