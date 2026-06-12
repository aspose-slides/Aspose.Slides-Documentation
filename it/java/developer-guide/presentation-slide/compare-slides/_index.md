---
title: Confronta le diapositive della presentazione in Java
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/java/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Confronta presentazioni PowerPoint e OpenDocument programmaticamente con Aspose.Slides per Java. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, diapositive di layout e diapositive master utilizzando il metodo `equals` fornito dall'interfaccia `IBaseSlide` e dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**
Il metodo Equals è stato aggiunto all'interfaccia [IBaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/IBaseSlide) e alla classe [BaseSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/BaseSlide). Restituisce true per le diapositive/layout e le diapositive/master che sono identiche per struttura e contenuto statico.  

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc., sono uguali. Il confronto non tiene conto dei valori di identificatori unici, ad es. SlideId, né del contenuto dinamico, ad es. il valore della data corrente nel segnaposto Data.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

[Hidden status](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getHidden--) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri vengono presi in considerazione?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò è solitamente considerato una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà considerato?**

No. Il confronto viene effettuato basandosi sulle diapositive stesse. Le fonti di dati esterne non vengono generalmente lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.