---
title: Converti le presentazioni PowerPoint in XPS con PHP
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/php-java/convert-powerpoint-to-xps/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in XPS
- presentazione in XPS
- diapositiva in XPS
- PPT in XPS
- PPTX in XPS
- salva PPT come XPS
- salva PPTX come XPS
- esporta PPT in XPS
- esporta PPTX in XPS
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Converti i file PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma utilizzando Aspose.Slides per PHP via Java. Ottieni una guida passo-passo e il codice di esempio."
---
## **Panoramica**

Aspose.Slides consente di convertire presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando le impostazioni predefinite o quelle personalizzate [XpsOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/xpsoptions/).

## **Informazioni su XPS**
Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare contenuti generando un file molto simile a un PDF. Il formato XPS è basato su XML. Il layout o la struttura di un file XPS rimane invariato su tutti i sistemi operativi e stampanti. 

## **Quando utilizzare il formato Microsoft XPS**

{{% alert color="primary" %}} 

Per vedere come Aspose.Slides converte una presentazione PPT o PPTX nel formato XPS, puoi provare [questa app di conversione online gratuita](https://products.aspose.app/slides/it/conversion). 

{{% /alert %}} 

Se desideri ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i tuoi documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se lavori con Windows 8.1, Windows 8, Windows 7 e Windows Vista, XPS potrebbe essere la tua migliore opzione per alcune operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 fornisce un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** Visualizzatore/lettore XPS integrato e funzionalità di stampa in XPS disponibili. 
  - **PDF:** Lettore PDF disponibile ma nessuna funzionalità di stampa in PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Questi sistemi operativi forniscono anche loro un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS:** Visualizzatore XPS integrato e funzionalità di stampa in XPS disponibili. 
  - **PDF:** Nessun lettore PDF. Nessuna funzionalità di stampa in PDF. 

|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ha infine implementato il supporto per le operazioni di stampa in PDF tramite la funzione Stampa in PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti tramite il formato XPS. 

## **Conversione XPS con Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/it/php-java/) per Java, è possibile utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) per convertire l'intera presentazione in un documento XPS.

Durante la conversione di una presentazione in XPS, devi salvare la presentazione utilizzando una di queste impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/php-java/aspose.slides/xpsoptions))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/php-java/aspose.slides/xpsoptions))

### **Converti le presentazioni in XPS utilizzando le impostazioni predefinite**

Questo esempio di codice mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Salva la presentazione in un documento XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Converti le presentazioni in XPS utilizzando le impostazioni personalizzate**
Questo esempio di codice mostra come convertire una presentazione in un documento XPS utilizzando impostazioni personalizzate :

```php
  # Istanzia un oggetto Presentation che rappresenta un file di presentazione
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Istanzia la classe TiffOptions
    $options = new XpsOptions();
    # Salva i MetaFile come PNG
    $options->setSaveMetafilesAsPng(true);
    # Salva la presentazione in un documento XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso salvare XPS in uno stream anziché in un file?**

Sì—Aspose.Slides consente di esportare direttamente in uno stream, ideale per API web, pipeline lato server o qualsiasi scenario in cui si desidera inviare l'XPS senza toccare il file system.

**Le diapositive nascoste vengono trasferite in XPS e posso escluderle?**

Per impostazione predefinita, vengono renderizzate solo le diapositive normali (visibili). È possibile [includere o escludere le diapositive nascoste](https://reference.aspose.com/slides/it/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) tramite le [impostazioni di esportazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/xpsoptions/) prima di salvare in XPS, garantendo che l'output contenga esattamente le pagine desiderate.