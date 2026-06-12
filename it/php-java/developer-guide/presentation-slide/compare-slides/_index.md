---
title: Confronta le diapositive di presentazione in PHP
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/php-java/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Confronta presentazioni PowerPoint e OpenDocument programmaticamente con Aspose.Slides per PHP via Java. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Introduzione**

Aspose.Slides consente di confrontare diapositive, diapositive di layout e diapositive master utilizzando il metodo `equals` fornito dalla classe `BaseSlide`. Questo metodo restituisce `true` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta due diapositive**

Il metodo Equals è stato aggiunto alla classe [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/BaseSlide). Restituisce true per le diapositive/layout e le diapositive/master che sono identiche nella loro struttura e nel contenuto statico.  

Due diapositive sono uguali se tutte le forme, gli stili, i testi, le animazioni e le altre impostazioni, ecc., sono uguali. Il confronto non tiene conto dei valori degli identificatori unici, ad es. SlideId, né del contenuto dinamico, ad es. il valore della data corrente nel segnaposto Data.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

[Hidden status](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/gethidden/) è una proprietà a livello di presentazione/riproduzione, non di contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri sono presi in considerazione?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò è solitamente considerato una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di tale file sarà preso in considerazione?**

No. Il confronto viene eseguito sulla base delle diapositive stesse. Le fonti dati esterne non vengono generalmente lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.