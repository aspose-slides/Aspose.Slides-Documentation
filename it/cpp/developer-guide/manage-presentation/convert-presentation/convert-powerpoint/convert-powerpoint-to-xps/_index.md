---
title: Converti le presentazioni PowerPoint in XPS con C++
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Converti i file PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma con C++ usando Aspose.Slides. Ottieni una guida passo passo e il codice di esempio."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando le impostazioni predefinite o le impostazioni personalizzate [XpsOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/xpsoptions/).

## **Informazioni su XPS**

Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare contenuti generando un file molto simile a un PDF. Il formato XPS si basa su XML. Il layout o la struttura di un file XPS rimane invariato su tutti i sistemi operativi e stampanti. 

## **Quando utilizzare il formato XPS di Microsoft**

{{% alert color="primary" %}} 

Per vedere come Aspose.Slides converte le presentazioni PPT o PPTX nel formato XPS, è possibile provare [questa app di conversione online gratuita](https://products.aspose.app/slides/it/conversion). 

{{% /alert %}} 

Se desideri ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i tuoi documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se lavori con Windows 8.1, Windows 8, Windows 7 e Windows Vista, XPS potrebbe effettivamente essere la tua migliore opzione per certe operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 offre un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** Visualizzatore/lettore XPS integrato e funzionalità di stampa su XPS disponibile. 
  - **PDF**: Lettore PDF disponibile ma nessuna funzione di stampa su PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Questi sistemi operativi offrono anche loro un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS**: Visualizzatore XPS integrato e funzionalità di stampa su XPS disponibile. 
  - **PDF**: Nessun lettore PDF. Nessuna funzione di stampa su PDF. 

|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ha infine implementato il supporto per le operazioni di stampa in PDF tramite la funzione Stampa su PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti tramite il formato XPS. 

## **Conversione XPS con Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/it/cpp/) per C++, è possibile utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) per convertire l'intera presentazione in un documento XPS. 

Quando si converte una presentazione in XPS, è necessario salvare la presentazione utilizzando una di queste impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.xps_options))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.xps_options))

### **Convertire le presentazioni in XPS usando le impostazioni predefinite**

Questo codice di esempio in C++ mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

``` cpp
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Salva la presentazione in un documento XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Convertire le presentazioni in XPS usando impostazioni personalizzate**

Questo codice di esempio mostra come convertire una presentazione in un documento XPS utilizzando impostazioni personalizzate in C++:

``` cpp
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanzia la classe XpsOptions
auto options = System::MakeObject<XpsOptions>();

// Salva i MetaFile come PNG
options->set_SaveMetafilesAsPng(true);

// Salva la presentazione in un documento XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

**Posso salvare XPS in uno stream invece che in un file?**

Sì—Aspose.Slides permette di esportare direttamente in uno stream, ideale per API web, pipeline lato server o qualsiasi scenario in cui si desidera inviare l'XPS senza intervenire sul file system.

**Le diapositive nascoste vengono incluse nell'XPS e posso escluderle?**

Per impostazione predefinita, vengono renderizzate solo le diapositive regolari (visibili). È possibile [includere o escludere le diapositive nascoste](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) attraverso le [impostazioni di esportazione](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/xpsoptions/) prima di salvare in XPS, garantendo che l'output contenga esattamente le pagine desiderate.