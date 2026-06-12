---
title: Confronta le diapositive della presentazione in .NET
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/net/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Confronta programmaticamente le presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, diapositive layout e diapositive master utilizzando il metodo `Equals` fornito dall'interfaccia `IBaseSlide` e dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**

Il metodo Equals è stato aggiunto all'interfaccia [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide) e alla classe [BaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/baseslide). Restituisce true per le diapositive/layout e le diapositive/master che sono identiche per struttura e contenuto statico.

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e altre impostazioni, ecc. La comparazione non tiene conto dei valori degli identificatori unici, ad esempio SlideId, né del contenuto dinamico, ad esempio il valore della data corrente nel segnaposto Data.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

[Stato nascosto](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri vengono considerati?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò è solitamente considerato una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di tale file verrà considerato?**

No. Il confronto viene eseguito basandosi sulle diapositive stesse. Le fonti di dati esterne generalmente non vengono lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.