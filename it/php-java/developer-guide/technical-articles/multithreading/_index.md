---
title: Multithreading in Aspose.Slides per PHP tramite Java
linktitle: Multithreading
type: docs
weight: 310
url: /it/php-java/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per PHP tramite Java migliora l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazioni efficienti."
---
## **Introduzione**

Mentre il lavoro parallelo con le presentazioni è possibile (oltre al parsing/loading/cloning) e tutto funziona bene (nella maggior parte dei casi), c’è una piccola probabilità di ottenere risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo vivamente di **non** usare un’unica istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) in un ambiente multithreading, poiché potrebbe causare errori o guasti imprevedibili difficili da rilevare.

Non è **sicuro** caricare, salvare e/o clonare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) in più thread. Tali operazioni **non** sono supportate. Se è necessario eseguire queste attività, dovete parallelizzare le operazioni utilizzando diversi processi monothread e ciascuno di questi processi deve usare la propria istanza di presentazione.

Non garantiamo il multithreading in PHP quando si utilizzano le estensioni. Se le usi, fallo a tuo rischio.

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente eseguirla una volta per processo/dominio dell'applicazione prima dell’avvio dei thread. Se la [license setup](/slides/it/php-java/licensing/) potrebbe essere invocata contemporaneamente (ad esempio durante l’inizializzazione pigra), sincronizzate la chiamata poiché il metodo di configurazione della licenza stesso non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra i thread?**

Passare oggetti di presentazione "live" tra i thread non è consigliato: utilizzate istanze indipendenti per ogni thread o pre-create presentazioni/contenitori di slide separati per ciascun thread. Questo approccio segue la raccomandazione generale di non condividere un’unica istanza di presentazione tra i thread.

**È sicuro parallelizzare l’esportazione in formati diversi (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività si parallelizzano correttamente nella maggior parte dei casi; evitate qualsiasi oggetto di presentazione condiviso e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializzate tutte le [font settings](/slides/it/php-java/powerpoint-fonts/) globali prima di avviare i thread e non modificatele durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.