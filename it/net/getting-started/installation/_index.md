---
title: Installazione
type: docs
weight: 70
url: /it/net/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- utilizzare Aspose.Slides
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
description: "Scopri come installare rapidamente Aspose.Slides per .NET. Guida passo-passo, requisiti di sistema e esempi di codice — inizia a lavorare con le presentazioni PowerPoint oggi!"
---
## **Panoramica**

Questo articolo spiega come installare Aspose.Slides per .NET su Windows e macOS. Si concentra sull'installazione basata su NuGet e mostra come aggiungere la libreria a un progetto Visual Studio sia tramite il NuGet Package Manager sia tramite la Package Manager Console su Windows. Descrive inoltre come aggiornare il pacchetto e installare build prerelease quando necessario.

## **Windows**
NuGet fornisce il percorso più semplice per scaricare e installare le API Aspose per .NET sui PC. 

### **Metodo 1: Installa o Aggiorna Aspose.Slides dal NuGet Package Manager**

1. Apri Microsoft Visual Studio. 
2. Crea una semplice applicazione console o apri un progetto esistente. 
3. Passa su **Tools** > **NuGet package manager**.
4. Nella sezione **Browse**, cerca *Aspose Slides* nel campo di testo. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Fai clic su **Aspose.Slides.NET** e poi su **Install**. 
   * Se desideri aggiornare Aspose.Slides—supponendo di averlo già installato—fai clic su **Update** invece. 

L'API selezionata viene scaricata e referenziata nel tuo progetto.

### **Metodo 2: Installa o Aggiorna Aspose.Slides tramite la Package Manager Console**

Questo è il modo per referenziare [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) tramite la console del package manager:

1. Apri Microsoft Visual Studio. 
2. Crea una semplice applicazione console o apri un progetto esistente. 
3. Passa su **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Esegui questo comando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
L'ultima versione completa viene installata nella tua applicazione. 

* In alternativa, puoi aggiungere il suffisso `-prerelease` al comando per indicare che deve essere installata anche l'ultima release (inclusi gli hotfix). 

 Il suggerimento **Installing Aspose.Slides.NET** appare nella parte inferiore della finestra. 
![todo:image_alt_text](installation_4.png)

Una volta completato il download, dovresti vedere alcuni messaggi di conferma. 

Se non sei familiare con [Aspose EULA](https://about.aspose.com/legal/eula), potresti voler leggere la licenza indicata nell'URL. 
![todo:image_alt_text](installation_5.png)

Nella tua applicazione, dovresti vedere che Aspose.Slides è stato aggiunto e referenziato correttamente. 
![todo:image_alt_text](installation_6.png)

Nella Package Manager Console, puoi eseguire il comando `Update-Package Aspose.Slides.NET` per verificare la disponibilità di aggiornamenti al pacchetto Aspose.Slides. Gli aggiornamenti (se trovati) vengono installati automaticamente. Puoi anche usare il suffisso `-prerelease` per aggiornare l'ultima release.

#### **Considerazioni Quando Si Esegue in un Ambiente Server Condiviso**
Raccomandiamo vivamente di eseguire tutti i componenti Aspose .NET con il set di permessi **Full Trust** perché i componenti Aspose a volte necessitano di accedere a impostazioni di registro e file situati in luoghi diversi dalla directory virtuale—ad esempio, quando i componenti Aspose devono leggere i font. 

Inoltre, i componenti Aspose.NET si basano sulle classi di sistema core di .NET—e alcune di queste classi richiedono anch'esse il permesso Full Trust per determinate operazioni.

I provider di servizi Internet, che ospitano più applicazioni di diverse aziende, solitamente applicano il livello di sicurezza Medium Trust. Nel caso di .NET 2.0, tale livello di sicurezza può comportare restrizioni che influenzano le operazioni di Aspose.Slides:

- **RegistryPermission** non è disponibile. Questo significa che non puoi accedere al registro, necessario per elencare i font installati durante il rendering dei documenti.
- **FileIOPermission** è limitato. Questo significa che puoi accedere solo ai file nella gerarchia della directory virtuale della tua applicazione. Ciò può anche impedire la lettura dei font durante le operazioni di esportazione. 

Per i motivi sopra indicati, raccomandiamo fortemente di eseguire Aspose.Slides con permessi **Full Trust**. Se utilizzi **Medium trust**, potresti riscontrare incoerenze—alcune funzionalità della libreria (ad esempio il rendering) potrebbero non funzionare quando esegui determinati compiti. 

## **macOS**

NuGet fornisce il percorso più semplice per scaricare e installare Aspose.Slides per .NET sui Mac. 

**Installa Prerequisito**

Il namespace `System.Drawing` opera diversamente in macOS, quindi devi installare mono-libgdiplus. 

> In .NET 5 e versioni precedenti, il pacchetto NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) funziona su Windows, Linux e macOS. Tuttavia, esistono alcune differenze di piattaforma. Su Linux e macOS, la funzionalità GDI+ è implementata dalla libreria [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Questa libreria non è installata di default nella maggior parte delle distribuzioni Linux e non supporta tutta la funzionalità di GDI+ su Windows e macOS. Esistono anche piattaforme in cui libgdiplus non è disponibile affatto. Per utilizzare i tipi del pacchetto System.Drawing.Common su Linux e macOS, è necessario installare libgdiplus separatamente. Per ulteriori informazioni, consulta [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) o [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

Per installare mono-libgdiplus separatamente sul tuo Mac, consulta [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) dalla documentazione .NET. 

### **Installa Aspose.Slides**

1. Apri Visual Studio. 
2. Crea una semplice applicazione console o apri un progetto esistente.
3. Passa su **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Digita *Aspose.Slides* nel campo di testo. 
5. Fai clic su **Aspose.Slides for .NET** e poi su **Add Package.** 
6. Aggiungi un semplice frammento di codice.
   * Puoi copiare il codice su [questa pagina](/slides/it/net/create-presentation/).
7. Esegui l'app.
8. Apri la *folder/bin/Debug/presentation_file_name* del tuo progetto.

## **FAQ**

**Esiste una versione gratuita o limitazione di prova?**

Sì, per impostazione predefinita Aspose.Slides viene eseguito in modalità valutazione, che applica filigrane e può avere altre limitazioni. Per rimuovere le restrizioni, è necessario applicare una [licenza](/slides/it/net/licensing/).