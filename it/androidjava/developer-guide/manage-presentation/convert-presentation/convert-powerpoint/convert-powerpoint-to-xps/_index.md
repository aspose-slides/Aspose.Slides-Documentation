---
title: Convertire presentazioni PowerPoint in XPS su Android
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /it/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in XPS di alta qualità e indipendente dalla piattaforma in Java usando Aspose.Slides per Android. Ottieni una guida passo-passo e un esempio di codice."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando il formato XPS può essere utile e mostra come eseguire la conversione con Aspose.Slides utilizzando le impostazioni predefinite o quelle personalizzate [XpsOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xpsoptions/) .

## **Informazioni su XPS**
Microsoft ha sviluppato [XPS](https://docs.fileformat.com/page-description-language/xps/) come alternativa a [PDF](https://docs.fileformat.com/pdf/). Consente di stampare contenuti generando un file molto simile a un PDF. Il formato XPS è basato su XML. Il layout o la struttura di un file XPS rimane lo stesso su tutti i sistemi operativi e le stampanti. 

## **Quando utilizzare il formato Microsoft XPS**

{{% alert color="info" %}} 

Per vedere come Aspose.Slides converte una presentazione PPT o PPTX nel formato XPS, è possibile provare [questa app gratuita di conversione online](https://products.aspose.app/slides/it/conversion). 

{{% /alert %}} 

Se desideri ridurre i costi di archiviazione, puoi convertire la tua presentazione Microsoft PowerPoint nel formato XPS. In questo modo sarà più semplice salvare, condividere e stampare i tuoi documenti. 

Microsoft continua a implementare un forte supporto per XPS in Windows (anche in Windows 10), quindi potresti considerare di salvare i file in questo formato. Se lavori con Windows 8.1, Windows 8, Windows 7 e Windows Vista, XPS potrebbe essere la tua migliore opzione per alcune operazioni. 

- **Windows 8** utilizza il formato OXPS (Open XPS) per i file XPS. OXPS è una versione standardizzata del formato XPS originale. Windows 8 offre un supporto migliore per i file XPS rispetto ai file PDF. 
  - **XPS:** visualizzatore/lettore XPS integrato e funzionalità di stampa su XPS disponibili. 
  - **PDF:** lettore PDF disponibile ma nessuna funzionalità di stampa su PDF. 

- **Windows 7 e Windows Vista** utilizzano il formato XPS originale. Questi sistemi operativi offrono anche un supporto migliore per i file XPS rispetto ai PDF. 
  - **XPS:** visualizzatore XPS integrato e funzione di stampa su XPS disponibili. 
  - **PDF:** nessun lettore PDF. Nessuna funzione di stampa su PDF. 

|<p>**Input PPT (X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ha infine implementato il supporto per le operazioni di stampa in PDF tramite la funzione Stampa su PDF in Windows 10. In precedenza, gli utenti dovevano stampare i documenti tramite il formato XPS. 

## **Conversione XPS con Aspose.Slides**

Nella versione per Java di **Aspose.Slides**, è possibile utilizzare il metodo [**Save**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) per convertire l'intera presentazione in un documento XPS.

Durante la conversione di una presentazione in XPS, è necessario salvare la presentazione usando una di queste impostazioni:

- Impostazioni predefinite (senza [**XPSOptions**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xpsoptions))
- Impostazioni personalizzate (con [**XPSOptions**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xpsoptions))

### **Convertire le presentazioni in XPS usando le impostazioni predefinite**

Questo codice di esempio in Java mostra come convertire una presentazione in un documento XPS utilizzando le impostazioni standard:

```java
import com.aspose.slides.*;

// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Salvataggio della presentazione in un documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertire le presentazioni in XPS usando impostazioni personalizzate**
Questo codice di esempio mostra come convertire una presentazione in un documento XPS utilizzando impostazioni personalizzate in Java:

```java
import com.aspose.slides.*;

// Istanziare un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Istanziare la classe XpsOptions
    XpsOptions options = new XpsOptions();

    // Salvare i MetaFile come PNG
    options.setSaveMetafilesAsPng(true);

    // Salvare la presentazione in un documento XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Posso salvare in XPS su uno stream anziché su un file?

Sì—Aspose.Slides consente di esportare direttamente su uno stream, ideale per API web, pipeline lato server o qualsiasi scenario in cui si desidera inviare l'XPS senza intervenire sul file system.

### Le diapositive nascoste vengono trasferite in XPS e posso escluderle?

Per impostazione predefinita, vengono renderizzate solo le diapositive normali (visibili). È possibile [includere o escludere le diapositive nascoste](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) tramite le [impostazioni di esportazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/xpsoptions/) prima di salvare in XPS, garantendo che l'output contenga esattamente le pagine desiderate.