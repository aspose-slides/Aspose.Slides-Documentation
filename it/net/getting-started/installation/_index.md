---
title: Installazione
type: docs
weight: 70
url: /it/net/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come installare rapidamente Aspose.Slides per .NET. Guida passo-passo, requisiti di sistema e esempi di codice - inizia a lavorare con le presentazioni PowerPoint oggi!"
---
## **Panoramica**

Questo articolo spiega come installare Aspose.Slides per .NET su Windows, Linux e macOS. Si concentra sull'installazione basata su NuGet e mostra come aggiungere la libreria tramite il Gestore pacchetti NuGet o la Console del gestore pacchetti su Windows, a un progetto .NET su Linux e a un progetto Visual Studio su macOS. Descrive inoltre come aggiornare il pacchetto e installare build prerelease quando necessario.

Prima dell'installazione, esamina i sistemi operativi supportati, le implementazioni .NET e le dipendenze aggiuntive in [System Requirements](/slides/it/net/system-requirements/).

## **Windows**
NuGet fornisce il percorso più semplice per scaricare e installare le API Aspose per .NET sui PC.

### **Metodo 1: Installa o aggiorna Aspose.Slides dal NuGet Package Manager**

1. Apri Microsoft Visual Studio.  
2. Crea una semplice applicazione console o apri un progetto esistente.  
3. Vai su **Tools** > **NuGet package manager**.  
4. Nella sezione **Browse**, cerca *Aspose Slides* nel campo di testo.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Fai clic su **Aspose.Slides.NET** e poi su **Install**.  
   * Se vuoi aggiornare Aspose.Slides—presumendo che l'hai già installato—fai clic su **Update** invece.  

L'API selezionata viene scaricata e referenziata nel tuo progetto.

### **Metodo 2: Installa o aggiorna Aspose.Slides tramite la Package Manager Console**

Questo è il modo in cui si fa riferimento a [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) tramite la console del gestore pacchetti:

1. Apri Microsoft Visual Studio.  
2. Crea una semplice applicazione console o apri un progetto esistente.  
3. Vai su **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Esegui questo comando: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
L'ultima versione completa viene installata nella tua applicazione.  

* In alternativa, puoi aggiungere il suffisso `-prerelease` al comando per specificare che deve essere installata anche l'ultima release (inclusi gli hotfix).  

Il suggerimento **Installing Aspose.Slides.NET** appare nella parte inferiore della finestra.  
![todo:image_alt_text](installation_4.png)

Una volta completato il download, dovresti vedere alcuni messaggi di conferma.  

Se non conosci la [Aspose EULA](https://about.aspose.com/legal/eula), potresti voler leggere la licenza indicata nell'URL.  
![todo:image_alt_text](installation_5.png)

Nella tua applicazione, dovresti vedere che Aspose.Slides è stato aggiunto e referenziato correttamente.  
![todo:image_alt_text](installation_6.png)

Nella Package Manager Console, puoi eseguire il comando `Update-Package Aspose.Slides.NET` per verificare gli aggiornamenti del pacchetto Aspose.Slides. Gli aggiornamenti (se trovati) vengono installati automaticamente. Puoi anche usare il suffisso `-prerelease` per aggiornare l'ultima release.  

#### **Considerazioni quando si esegue in un ambiente server condiviso**
Raccomandiamo vivamente di eseguire tutti i componenti Aspose .NET con il set di autorizzazioni **Full Trust**, poiché i componenti Aspose a volte devono accedere a impostazioni di registro e file situati in percorsi diversi dalla directory virtuale—ad esempio, quando devono leggere i font.  

Inoltre, i componenti Aspose.NET si basano sulle classi di sistema core .NET e alcune di queste classi richiedono anch'esse l'autorizzazione Full Trust per determinate operazioni.  

I provider di servizi Internet, che ospitano più applicazioni da diverse aziende, applicano principalmente il livello di sicurezza Medium Trust. Nel caso di .NET 2.0, tale livello può comportare restrizioni che influenzano le operazioni di Aspose.Slides:

- **RegistryPermission** non è disponibile. Questo significa che non è possibile accedere al registro, necessario per enumerare i font installati durante il rendering dei documenti.  
- **FileIOPermission** è limitato. Questo significa che puoi accedere solo ai file nella gerarchia della directory virtuale della tua applicazione. Ciò può impedire la lettura dei font durante le operazioni di esportazione.  

Per le ragioni sopra indicate, raccomandiamo fortemente di eseguire Aspose.Slides con le autorizzazioni **Full Trust**. Se utilizzi **Medium trust**, potresti riscontrare incoerenze—alcune funzionalità della libreria (ad esempio il rendering) potrebbero non funzionare quando esegui determinate attività.  

## **Linux**

NuGet fornisce il percorso più semplice per scaricare e installare Aspose.Slides per .NET su Linux. Aggiungi il pacchetto [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) al tuo progetto .NET.

## **macOS**

NuGet fornisce il percorso più semplice per scaricare e installare Aspose.Slides per .NET su Mac.

### **Installa Aspose.Slides**

1. Apri Visual Studio.  
2. Crea una semplice applicazione console o apri un progetto esistente.  
3. Vai su **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Digita *Aspose.Slides* nel campo di testo.  
5. Fai clic su **Aspose.Slides for .NET** e poi su **Add Package.**  
6. Aggiungi un semplice frammento di codice.  
   * Puoi copiare il codice su [questa pagina](/slides/it/net/create-presentation/).  
7. Esegui l'app.  
8. Apri *folder/bin/Debug/presentation_file_name* del tuo progetto.  

## **FAQ**

**Esiste una versione gratuita o limitazioni di prova?**

Sì, per impostazione predefinita Aspose.Slides è in modalità di valutazione, che inserisce filigrane e può avere altre limitazioni. Per rimuovere le restrizioni, è necessario applicare una [license](/slides/it/net/licensing/) valida.