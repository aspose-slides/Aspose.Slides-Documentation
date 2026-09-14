---
title: Confronta diapositive di presentazione in Python
linktitle: Confronta diapositive
type: docs
weight: 50
url: /it/python-java/compare-slides/
keywords:
- confronta diapositive
- confronto diapositive
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Confronta programmaticamente presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via Java. Identifica rapidamente le differenze delle diapositive nel codice."
---
## **Panoramica**

Aspose.Slides consente di confrontare diapositive, diapositive di layout e diapositive master utilizzando il metodo [equals](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#equals) fornito dalla classe [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/). Questo metodo restituisce `True` quando le diapositive confrontate sono identiche nella loro struttura e nel contenuto statico.

## **Confronta Due Diapositive**

Il metodo [equals](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#equals) nella classe [BaseSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/) restituisce `True` per diapositive, diapositive di layout e diapositive master che sono identiche nella struttura e nel contenuto statico.

Due diapositive sono uguali se tutte le loro forme, stili, testi, animazioni e altre impostazioni sono uguali. Il confronto non tiene conto dei valori di identificatori univoci, come gli ID delle diapositive, né del contenuto dinamico, come la data corrente in un segnaposto data.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Il fatto che una diapositiva sia nascosta influisce sul confronto delle diapositive stesse?**

Lo [stato nascosto](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getHidden) è una proprietà a livello di presentazione/riproduzione, non un contenuto visivo. L'uguaglianza di due diapositive specifiche è determinata dalla loro struttura e dal contenuto statico; il semplice fatto che una diapositiva sia nascosta non rende le diapositive diverse.

**I collegamenti ipertestuali e i loro parametri sono considerati?**

Sì. I collegamenti fanno parte del contenuto statico di una diapositiva. Se l'URL o l'azione del collegamento ipertestuale differiscono, ciò è solitamente interpretato come una differenza nel contenuto statico.

**Se un grafico fa riferimento a un file Excel esterno, il contenuto di quel file verrà preso in considerazione?**

No. Il confronto avviene sulla base delle diapositive stesse. Le fonti di dati esterne generalmente non vengono lette al momento del confronto; viene considerato solo ciò che è presente nella struttura e nello stato statico della diapositiva.