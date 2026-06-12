---
title: Converti le presentazioni PowerPoint in XPS con Python
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/python-net/convert-powerpoint-to-xps/
keywords:
- conversione PowerPoint
- conversione presentazione
- PowerPoint in XPS
- presentazione in XPS
- PPT in XPS
- PPTX in XPS
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Converti i file PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma con Python usando Aspose.Slides. Ottieni una guida passo-passo e il codice di esempio."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando le impostazioni predefinite o quelle personalizzate [XpsOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/xpsoptions/).

## **Informazioni su XPS**
Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare contenuti generando un file molto simile a un PDF. Il formato XPS è basato su XML. Il layout o la struttura di un file XPS rimane invariato su tutti i sistemi operativi e stampanti. 

## Quando utilizzare il formato Microsoft XPS

{{% alert color="primary" %}} 

Per vedere come Aspose.Slides converte le presentazioni PPT o PPTX nel formato XPS, è possibile provare [questa app di conversione online gratuita](https://products.aspose.app/slides/it/conversion). 

{{% /alert %}} 

Se desideri ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se lavori con Windows 8.1, Windows 8, Windows 7 e Windows Vista, XPS potrebbe essere la tua opzione migliore per alcune operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 offre un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** visualizzatore/lettore XPS integrato e funzione di stampa in XPS disponibili. 
  - **PDF:** lettore PDF disponibile ma nessuna funzione di stampa in PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Anche questi sistemi operativi offrono un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS:** visualizzatore XPS integrato e funzione di stampa in XPS disponibili. 
  - **PDF:** nessun lettore PDF. Nessuna funzione di stampa in PDF. 

|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ha infine implementato il supporto per le operazioni di stampa in PDF tramite la funzionalità Stampa in PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti attraverso il formato XPS. 

## Conversione XPS con Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/it/python-net/) per .NET, è possibile utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per convertire l’intera presentazione in un documento XPS. 

Durante la conversione di una presentazione in XPS, è necessario salvare la presentazione utilizzando una delle seguenti impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/xpsoptions/))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/xpsoptions/))

### **Conversione di presentazioni in XPS con impostazioni predefinite**

Questo esempio di codice in Python mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

```py
import aspose.slides as slides

# Instanzia un oggetto Presentation che rappresenta un file di presentazione
pres = slides.Presentation("Convert_XPS.pptx")

# Salva la presentazione in un documento XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Conversione di presentazioni in XPS con impostazioni personalizzate**
Questo esempio di codice mostra come convertire una presentazione in un documento XPS utilizzando impostazioni personalizzate in Python:

```py
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Istanzia la classe TiffOptions
options = slides.export.XpsOptions()

# Salva i MetaFile come PNG
options.save_metafiles_as_png = True

# Salva la presentazione in un documento XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**Posso salvare in XPS su uno stream invece che su un file?**

Sì—Aspose.Slides consente di esportare direttamente su uno stream, ideale per API web, pipeline lato server o qualsiasi scenario in cui si desidera inviare il XPS senza intervenire sul file system.

**Le diapositive nascoste vengono trasferite in XPS e posso escluderle?**

Per impostazione predefinita vengono renderizzate solo le diapositive normali (visibili). È possibile [includere o escludere le diapositive nascoste](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) tramite le [impostazioni di esportazione](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/xpsoptions/) prima di salvare in XPS, garantendo che l’output contenga esattamente le pagine desiderate.