---
title: Confronta diapositive di presentazioni su Android
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/androidjava/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Confronta programmaticamente presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android. Identifica rapidamente le differenze delle diapositive nel codice Java."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, layout diapositive e diapositive master usando il metodo `equals` fornito dall'interfaccia `IBaseSlide` e dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**
Il metodo Equals è stato aggiunto all'interfaccia [IBaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBaseSlide) e alla classe [BaseSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/BaseSlide). Restituisce true per le diapositive/layout e le diapositive/master che sono identiche per struttura e contenuto statico.  

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc., sono uguali. Il confronto non tiene conto dei valori identificativi unici, ad es. SlideId, né del contenuto dinamico, ad es. valore della data corrente nel segnaposto Data.

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

Lo [Stato nascosto](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getHidden--) è una proprietà a livello di presentazione/riproduzione, non un contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non la rende diversa.

**I collegamenti ipertestuali e i loro parametri sono considerati?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò viene solitamente trattato come una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà considerato?**

No. Il confronto viene eseguito basandosi sulle diapositive stesse. Le fonti di dati esterne generalmente non vengono lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.