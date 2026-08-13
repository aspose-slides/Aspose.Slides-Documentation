---
title: Salva presentazioni in modalità sola lettura usando Java
linktitle: Presentazione sola lettura
type: docs
weight: 30
url: /it/java/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire la modifica
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per Java, offrendo anteprime precise delle diapositive senza alterare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le loro presentazioni. Potresti voler utilizzare questa impostazione Read-Only per proteggere una presentazione quando

- Vuoi evitare modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione vedono la raccomandazione **Read-Only** e potrebbero vedere un messaggio del tipo: *Per evitare modifiche accidentali, l'autore ha impostato questo file per l'apertura in modalità sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo educato, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione recentemente introdotta—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applicare la modalità Read-Only**

Aspose.Slides per Java ti consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in Java utilizzando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente destinata a scoraggiare la modifica o a impedire agli utenti di effettuare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa quello che sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai bisogno di impedire seriamente modifiche non autorizzate, è più opportuno utilizzare [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/it/java/password-protected-presentation/). 

{{% /alert %}} 

## **Domande frequenti**

### In che modo 'Read-Only recommended' è diverso dalla protezione con password completa?

'Read-Only recommended' mostra solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Password protection](/slides/it/java/password-protected-presentation/) restringe effettivamente l'apertura o la modifica ed è appropriato quando hai bisogno di controlli di sicurezza reali.

### 'Read-Only recommended' può essere combinato con filigrane per scoraggiare ulteriormente le modifiche?

Sì. La raccomandazione può essere accoppiata con [watermarks](/slides/it/java/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

### Una macro o uno strumento esterno può comunque modificare il file quando la raccomandazione è abilitata?

Sì. La raccomandazione non blocca le modifiche programmatiche. Per prevenire modifiche automatizzate, usa [passwords and encryption](/slides/it/java/password-protected-presentation/).

### Come si collega 'Read-Only recommended' ai metodi 'isEncrypted' e 'isWriteProtected'?

Sono segnali diversi. 'Read-Only recommended' è un suggerimento morbido e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/protectionmanager/#isEncrypted--) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.