---
title: Converti le presentazioni PowerPoint in XPS in .NET
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma in .NET usando Aspose.Slides. Ottieni una guida passo-passo e un esempio di codice C#."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando le impostazioni predefinite o le impostazioni personalizzate di [XpsOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/) .

## **Informazioni su XPS**
Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare contenuti generando un file molto simile a un PDF. Il formato XPS si basa su XML. Il layout o la struttura di un file XPS rimangono gli stessi su tutti i sistemi operativi e stampanti. 

## **Quando utilizzare il formato XPS di Microsoft**

{{% alert color="info" %}} 

Per vedere come Aspose.Slides converte una presentazione PPT o PPTX nel formato XPS, è possibile provare [questa app di conversione online gratuita](https://products.aspose.app/slides/it/conversion). 

{{% /alert %}} 

Se vuoi ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i tuoi documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se lavori con Windows 8.1, Windows 8, Windows 7 e Windows Vista, XPS potrebbe essere la tua migliore opzione per alcune operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 fornisce un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** Visualizzatore/lettore XPS integrato e funzionalità di stampa su XPS disponibili. 
  - **PDF:** Lettore PDF disponibile ma nessuna funzionalità di stampa su PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Questi sistemi operativi forniscono anch'essi un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS:** Visualizzatore XPS integrato e funzionalità di stampa su XPS disponibili. 
  - **PDF:** Nessun lettore PDF. Nessuna funzionalità di stampa su PDF. 

|<p>**Input PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ha successivamente implementato il supporto per le operazioni di stampa in PDF tramite la funzionalità Stampa su PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti tramite il formato XPS. 

## **Conversione XPS con Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/it/net/) per .NET, è possibile utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/save/index) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) per convertire l'intera presentazione in un documento XPS. 

Quando si converte una presentazione in XPS, è necessario salvare la presentazione utilizzando una di queste impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions))

### **Converti le presentazioni in XPS utilizzando le impostazioni predefinite**

Questo esempio di codice in C# mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Salva la presentazione in un documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Converti le presentazioni in XPS utilizzando le impostazioni personalizzate**
Questo esempio di codice mostra come convertire una presentazione in un documento XPS utilizzando impostazioni personalizzate in C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Istanzia la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Salva i MetaFile come PNG
    options.SaveMetafilesAsPng = true;

    // Salva la presentazione in un documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

### Posso salvare in XPS su uno stream invece che su un file?

Sì—Aspose.Slides consente di esportare direttamente su uno stream, ideale per API web, pipeline lato server o qualsiasi scenario in cui si desideri inviare l'XPS senza intervenire sul file system.

### Le diapositive nascoste vengono trasferite su XPS e posso escluderle?

Per impostazione predefinita, vengono renderizzate solo le diapositive normali (visibili). È possibile [includere o escludere le diapositive nascoste](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/showhiddenslides/) tramite le [impostazioni di esportazione](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/) prima di salvare su XPS, garantendo che l'output contenga esattamente le pagine desiderate.