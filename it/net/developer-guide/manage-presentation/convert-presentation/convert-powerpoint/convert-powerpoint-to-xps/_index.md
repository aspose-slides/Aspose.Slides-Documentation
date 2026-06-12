---
title: Convertire le presentazioni PowerPoint in XPS in .NET
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/net/convert-powerpoint-to-xps/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in XPS
- presentazione in XPS
- diapositiva in XPS
- PPT in XPS
- PPTX in XPS
- salvare PPT come XPS
- salvare PPTX come XPS
- esportare PPT in XPS
- esportare PPTX in XPS
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Converti i file PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma in .NET usando Aspose.Slides. Ottieni una guida passo-passo e un esempio di codice C#."
---
## **Panoramica**

Aspose.Slides consente di convertire presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando sia le impostazioni predefinite sia quelle personalizzate di [XpsOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions/) .

## **Informazioni su XPS**
Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare il contenuto generando un file molto simile a un PDF. Il formato XPS si basa su XML. Il layout o la struttura di un file XPS rimane invariata su tutti i sistemi operativi e stampanti. 

## **Quando utilizzare il formato Microsoft XPS**

{{% alert color="primary" %}} 

Per vedere come Aspose.Slides converte una presentazione PPT o PPTX nel formato XPS, puoi provare questa app di conversione online gratuita. 

{{% /alert %}} 

Se vuoi ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i tuoi documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se utilizzi Windows 8.1, Windows 8, Windows 7 o Windows Vista, XPS potrebbe essere la tua migliore opzione per alcune operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 offre un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** Visualizzatore/lettore XPS integrato e funzionalità di stampa in XPS disponibili. 
  - **PDF:** Lettore PDF disponibile ma nessuna funzionalità di stampa in PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Questi sistemi operativi offrono anche loro un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS:** Visualizzatore XPS integrato e funzionalità di stampa in XPS disponibili. 
  - **PDF:** Nessun lettore PDF. Nessuna funzionalità di stampa in PDF. 

|<p>**Input PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ha infine implementato il supporto per le operazioni di stampa in PDF tramite la funzionalità Stampa su PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti attraverso il formato XPS. 

## **Conversione XPS con Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/it/net/) per .NET, puoi utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/save/index) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) per convertire l'intera presentazione in un documento XPS. 

Quando converti una presentazione in XPS, devi salvare la presentazione utilizzando una di queste impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/net/aspose.slides.export/xpsoptions))

### **Convertire le presentazioni in XPS usando le impostazioni predefinite**

Questo esempio di codice in C# mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

```c#
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Salvataggio della presentazione in documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Convertire le presentazioni in XPS usando impostazioni personalizzate**
Questo esempio di codice mostra come convertire una presentazione in un documento XPS usando impostazioni personalizzate in C#:

```c#
// Istanziare un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Istanziare la classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Salvare i MetaFile come PNG
    options.SaveMetafilesAsPng = true;

    // Salvare la presentazione in documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

**Posso salvare in XPS in uno stream invece che in un file?**

Sì—Aspose.Slides consente di esportare direttamente in uno stream, ideale per le API web, le pipeline lato server o qualsiasi scenario in cui desideri inviare l'XPS senza accedere al file system.

**Le diapositive nascoste vengono incluse nell'XPS e posso escluderle?**

Per impostazione predefinita, vengono renderizzate solo le diapositive regolari (visibili). È possibile includere o escludere le diapositive nascoste tramite le impostazioni di esportazione prima di salvare in XPS, garantendo che l'output contenga esattamente le pagine desiderate.