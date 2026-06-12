---
title: Confronta diapositive della presentazione in JavaScript
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/nodejs-java/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Confronta programmaticamente presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, diapositive layout e diapositive master utilizzando il metodo `equals` fornito dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**

Il metodo Equals è stato aggiunto alla classe [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BaseSlide) e alla classe [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BaseSlide). Restituisce true per le diapositive/layout e le diapositive/master che sono identiche per struttura e contenuto statico.

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc., sono uguali. Il confronto non tiene conto dei valori degli identificatori unici, ad esempio SlideId, né del contenuto dinamico, ad esempio il valore della data corrente nel segnaposto Data.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

**Il fatto che una diapositiva sia nascosta incide sul confronto delle diapositive stesse?**

[Hidden status](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/gethidden/) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri vengono considerati?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò viene solitamente considerato una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà preso in considerazione?**

No. Il confronto è eseguito sulla base delle sole diapositive. Le fonti di dati esterne generalmente non vengono lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.