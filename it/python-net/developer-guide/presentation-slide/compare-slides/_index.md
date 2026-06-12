---
title: Confronta diapositive di presentazione in Python
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/python-net/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Confronta programmaticamente le presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, layout di diapositive e master diapositive utilizzando il metodo `equals` fornito dalla classe `BaseSlide`. Questo metodo restituisce `True` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**
Il metodo `equals` è stato aggiunto alla classe [BaseSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/) . Restituisce true per i layout di diapositive e le master diapositive che sono identiche per struttura e contenuto statico.

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc. Il confronto non prende in considerazione i valori di identificatori unici, ad es. SlideId, né il contenuto dinamico, ad es. il valore della data corrente in un segnaposto data.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

Lo stato [Hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/hidden/) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L’uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri vengono considerati?**

Sì. I link fanno parte del contenuto statico di una diapositiva. Se l’URL o l’azione del collegamento ipertestuale differiscono, ciò viene solitamente considerato una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà preso in considerazione?**

No. Il confronto viene eseguito basandosi sulle diapositive stesse. Le fonti dati esterne non vengono generalmente lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.