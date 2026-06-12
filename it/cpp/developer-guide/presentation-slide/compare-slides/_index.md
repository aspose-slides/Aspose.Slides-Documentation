---
title: Confronta le diapositive della presentazione in C++
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/cpp/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Confronta programmaticamente le presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++. Identifica rapidamente le differenze tra diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, diapositive di layout e diapositive master utilizzando il metodo `Equals` fornito dall'interfaccia `IBaseSlide` e dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**
Il metodo Equals è stato aggiunto all'interfaccia IBaseSlide e alla classe BaseSlide. Restituisce true per le slide / slide di layout / slide master che sono identiche nella loro struttura e contenuto statico.

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc. sono gli stessi. Il confronto non tiene conto dei valori degli identificatori univoci, ad es. SlideId, né del contenuto dinamico, ad es. il valore della data corrente nel segnaposto Data.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

[Hidden status](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/get_hidden/) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri sono considerati?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò è solitamente trattato come una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà preso in considerazione?**

No. Il confronto viene eseguito basandosi sulle diapositive stesse. Le fonti di dati esterne generalmente non vengono lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.