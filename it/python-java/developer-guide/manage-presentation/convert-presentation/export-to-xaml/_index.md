---
title: Esporta presentazioni in XAML in Python via Java
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/python-java/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- Python
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in XAML con Aspose.Slides per Python via Java. Usa le opzioni predefinite o includi le diapositive nascoste."
---
## **Panoramica**

Questo articolo spiega come esportare presentazioni PowerPoint e OpenDocument in XAML utilizzando Aspose.Slides per Python via Java. Introduce XAML, mostra come esportare con le impostazioni predefinite e dimostra come includere diapositive nascoste con [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/).

Gli esempi richiedono Aspose.Slides per Python via Java e un runtime Java compatibile. Posizionare `pres.pptx` nella directory di lavoro corrente. Ogni esempio avvia la JVM solo se non è già in esecuzione.

## **Informazioni su XAML**

XAML (Extensible Application Markup Language) è un linguaggio basato su XML per descrivere le interfacce utente. Viene utilizzato da framework come Windows Presentation Foundation (WPF). È possibile creare e modificare XAML con un designer visuale o un editor di testo.

## **Esporta presentazioni in XAML con opzioni predefinite**

Crea una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) dal file di input, quindi passa [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per esportare con le impostazioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizza [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) per configurare l'esportazione. Per includere le diapositive nascoste, chiama [setExportHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True` prima di salvare:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Come posso scegliere un font di fallback quando il font originale non è disponibile?**

Utilizza [setDefaultRegularFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) sul tuo oggetto [XamlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/) per specificare un font di fallback. Assicurati che il font selezionato sia disponibile nell'ambiente di esportazione.

**Posso usare il markup esportato in qualsiasi framework XAML?**

I framework XAML differiscono per gli elementi e le funzionalità supportati. Testa il markup esportato nel framework di destinazione prima di integrarlo in un'applicazione.

**Le diapositive nascoste vengono esportate per impostazione predefinita?**

No. Per includerle, chiama [setExportHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True`. Lascia impostato a `False` per escluderle.