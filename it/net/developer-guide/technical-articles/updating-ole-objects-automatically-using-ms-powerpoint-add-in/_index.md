---
title: Aggiorna automaticamente gli oggetti OLE utilizzando un componente aggiuntivo PowerPoint
type: docs
weight: 10
url: /it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- oggetto OLE
- aggiornare OLE
- automaticamente
- componente aggiuntivo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiornare automaticamente grafici e oggetti OLE in PowerPoint con un componente aggiuntivo e Aspose.Slides per .NET, includendo codice pratico e consigli di ottimizzazione."
---
## **Introduzione**

Una delle domande più frequenti poste dai clienti di Aspose.Slides per .NET è come creare o modificare grafici modificabili (o altri oggetti OLE) in modo che vengano aggiornati automaticamente quando la presentazione viene aperta. Sfortunatamente, PowerPoint non supporta le macro automatiche allo stesso modo di Excel e Word. Le sole macro disponibili sono `Auto_Open` e `Auto_Close`, e queste vengono eseguite automaticamente solo da un componente aggiuntivo. Questo breve suggerimento tecnico mostra come ottenere questo risultato.

## **Aggiornare gli oggetti OLE automaticamente**

Innanzitutto, sono disponibili diversi componenti aggiuntivi gratuiti che aggiungono la funzionalità della macro Auto_Open a PowerPoint, ad esempio [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) e [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Dopo aver installato uno di questi componenti aggiuntivi, aggiungi semplicemente la macro `Auto_Open()` (o `OnPresentationOpen()` se stai usando Event Generator) alla tua presentazione modello come mostrato di seguito:

```cs
public void Auto_Open()
{
    // Scorri ogni diapositiva nella presentazione.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Scorri tutte le forme nella diapositiva corrente.
        foreach (var oShape in oSlide.Shapes)
        {
            // Verifica se la forma è un oggetto OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Oggetto OLE trovato. Ottieni il riferimento all'oggetto e poi aggiornalo.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Ora chiudi il programma server OLE.
                // Questo libera memoria e previene eventuali problemi.
                // Inoltre, imposta oObject a Nothing per rilasciare l'oggetto.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Qualsiasi modifica apportata agli oggetti OLE con Aspose.Slides per .NET verrà aggiornata automaticamente quando PowerPoint apre la presentazione. Se hai molti oggetti OLE e non vuoi aggiornarli tutti, aggiungi semplicemente un tag personalizzato alle forme che devi elaborare e verificalo nella macro.