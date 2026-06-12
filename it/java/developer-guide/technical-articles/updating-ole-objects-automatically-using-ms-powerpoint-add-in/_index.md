---
title: Aggiorna gli oggetti OLE automaticamente utilizzando un add-in per PowerPoint
type: docs
weight: 10
url: /it/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- oggetto OLE
- aggiorna OLE
- automaticamente
- add-in
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiornare automaticamente i grafici e gli oggetti OLE in PowerPoint con un add-in e Aspose.Slides per Java, con esempi pratici di codice e consigli di ottimizzazione."
---
## **Introduzione**

Una delle domande più frequenti poste dai clienti di Aspose.Slides per Java è come creare o modificare grafici modificabili (o altri oggetti OLE) in modo che vengano aggiornati automaticamente quando la presentazione viene aperta. Sfortunatamente, PowerPoint non supporta le macro automatiche nello stesso modo in cui lo fanno Excel e Word. Le uniche macro disponibili sono `Auto_Open` e `Auto_Close`, e queste vengono eseguite automaticamente solo da un componente aggiuntivo. Questo breve suggerimento tecnico mostra come ottenerlo.

## **Aggiornare automaticamente gli oggetti OLE**

Innanzitutto, sono disponibili diversi componenti aggiuntivi gratuiti che aggiungono la funzionalità di macro Auto_Open a PowerPoint, ad esempio [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) e [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Dopo aver installato uno di questi componenti aggiuntivi, aggiungi semplicemente la macro `Auto_Open()` (o `OnPresentationOpen()` se stai usando Event Generator) alla tua presentazione modello come mostrato di seguito:

```java
// Scorri ogni diapositiva nella presentazione.
for (var oSlide : ActivePresentation.Slides) {
    // Scorri tutte le forme nella diapositiva corrente.
    for (var oShape : oSlide.Shapes) {
        // Verifica se la forma è un oggetto OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Trovato un oggetto OLE. Ottieni il suo riferimento e quindi aggiornalo.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Ora, chiudi il programma server OLE.
            // Questo libera la memoria e previene eventuali problemi.
            // Inoltre, imposta oObject a null per rilasciare l'oggetto.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Qualsiasi modifica apportata agli oggetti OLE con Aspose.Slides per Java verrà aggiornata automaticamente quando PowerPoint apre la presentazione. Se hai molti oggetti OLE e non vuoi aggiornarli tutti, aggiungi semplicemente un tag personalizzato alle forme che devi elaborare e verifica la sua presenza nella macro.