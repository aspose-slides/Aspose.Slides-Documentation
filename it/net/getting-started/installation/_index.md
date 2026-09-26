---
title: Installazione
type: docs
weight: 70
url: /it/net/installation/
keywords:
- installa Aspose.Slides
- scarica Aspose.Slides
- usa Aspose.Slides
- installazione di Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Installa Aspose.Slides per .NET da NuGet su Windows, Linux e macOS: scegli tra i due pacchetti, aggiungine uno con la .NET CLI o Visual Studio, e installa i prerequisiti per Linux."
---
## **Panoramica**

Questo articolo spiega come aggiungere Aspose.Slides per .NET a un progetto su Windows, Linux e macOS. Aspose.Slides è distribuito tramite NuGet. Puoi aggiungerlo con la .NET CLI su qualsiasi sistema operativo, o con il NuGet Package Manager o la Package Manager Console in Visual Studio su Windows. L'articolo spiega anche quale dei due pacchetti NuGet scegliere e cosa è necessario in più su Linux.

Prima dell'installazione, consulta i sistemi operativi supportati, le implementazioni .NET e le dipendenze aggiuntive in [Requisiti di Sistema](/slides/it/net/system-requirements/).

## **Scegli un Pacchetto**

Aspose.Slides per .NET è pubblicato come due pacchetti NuGet. Entrambi forniscono gli stessi namespace e classi Aspose.Slides, quindi il tuo codice non cambia quando passi da uno all'altro; cambiano solo il riferimento al pacchetto e i requisiti della piattaforma.

| Pacchetto | Usalo per | Requisiti aggiuntivi |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Applicazioni Windows e .NET Framework | Su Linux e macOS: la libreria `libgdiplus` e l'opzione `System.Drawing.EnableUnixSupport` attivata all'avvio dell'applicazione |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 o successivo su Windows, Linux e macOS | Su Linux: la libreria `fontconfig`, se non è già installata |

Se non sei sicuro, usa Aspose.Slides.NET su Windows e Aspose.Slides.NET6.CrossPlatform su Linux e macOS. Su Alpine Linux e su sistemi Linux la cui glibc è più vecchia di 2.23 (x64) o 2.39 (ARM64), usa Aspose.Slides.NET invece. [Requisiti di Sistema](/slides/it/net/system-requirements/) elenca le piattaforme supportate da ciascun pacchetto.

## **Installa con la .NET CLI**

Questi passaggi funzionano su Windows, Linux e macOS con .NET SDK 6 o successivo. Crea un'app console:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Quindi aggiungi il pacchetto per la tua piattaforma. Aggiungi solo uno dei due pacchetti a un progetto.

- Su Windows: `dotnet add package Aspose.Slides.NET`
- Su Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (su Linux, installa prima il suo prerequisito; vedi [Linux](#linux))

Per verificare che il pacchetto funzioni, sostituisci il contenuto di *Program.cs* con il primo esempio in [Creare Presentazioni](/slides/it/net/create-presentation/) ed esegui `dotnet run`. Verrà salvato *hello.pptx* nella cartella del progetto.

## **Windows**

### **Metodo 1: Installa o Aggiorna Aspose.Slides dal NuGet Package Manager**

1. Apri Microsoft Visual Studio.  
2. Crea un'app console o apri un progetto esistente.  
3. In **Solution Explorer**, fai clic con il tasto destro sul progetto e seleziona **Manage NuGet Packages** (o vai su **Project** > **Manage NuGet Packages**).  
4. Sotto **Browse**, cerca *Aspose.Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Fai clic su **Aspose.Slides.NET** e poi su **Install**.  
   * Se hai già installato Aspose.Slides e desideri aggiornarlo, fai clic su **Update** invece.

Il pacchetto viene scaricato e aggiunto al tuo progetto.

### **Metodo 2: Installa o Aggiorna Aspose.Slides tramite la Package Manager Console**

Questo è il modo per referenziare il pacchetto [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) tramite la Package Manager Console:

1. Apri Microsoft Visual Studio.  
2. Crea un'app console o apri un progetto esistente.  
3. Vai su **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Opening the Package Manager Console](installation_2.png)
4. Esegui questo comando: `Install-Package Aspose.Slides.NET`  
![Running the Install-Package command](installation_3.png)
L'ultima versione viene installata nel tuo progetto.

Il messaggio **Installing Aspose.Slides.NET** appare nella parte inferiore della finestra.  
![Installation progress in the Package Manager Console](installation_4.png)

Al termine del download compaiono i messaggi di conferma. Il pacchetto è distribuito sotto la [Aspose EULA](https://about.aspose.com/legal/eula).  
![Installation confirmation messages](installation_5.png)

Aspose.Slides è ora aggiunto al tuo progetto e referenziato.  
![Aspose.Slides referenced in the project](installation_6.png)

Per aggiornare il pacchetto, esegui `Update-Package Aspose.Slides.NET` nella Package Manager Console.

## **Linux**

Usa i passaggi della .NET CLI descritti sopra. Scegli il pacchetto e installa il suo prerequisito con il gestore pacchetti della tua distribuzione. Su Debian e Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: installa `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: installa `libgdiplus` e abilita il supporto Unix per System.Drawing prima che la tua applicazione utilizzi Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Aggiungi questa istruzione all'inizio della tua applicazione, prima di qualsiasi chiamata a Aspose.Slides. In un *Program.cs* con istruzioni di livello superiore, inseriscila dopo le direttive `using`:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Usa questo pacchetto su Alpine Linux e su sistemi la cui glibc è troppo vecchia per Aspose.Slides.NET6.CrossPlatform.

I font usati nelle tue presentazioni, o sostituti adeguati, devono essere installati sul sistema affinché il testo venga renderizzato correttamente. [Requisiti di Sistema](/slides/it/net/system-requirements/) descrive i pacchetti necessari a Aspose.Slides.NET su Alpine Linux, inclusi i font.

## **macOS**

Usa i passaggi della .NET CLI descritti sopra con il pacchetto **Aspose.Slides.NET6.CrossPlatform**, che supporta sia i Mac Intel (x86_64) sia i Mac Apple silicon (ARM64):

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Esiste una versione gratuita o limitazioni della prova?**

Sì. Senza licenza, Aspose.Slides funziona in modalità di valutazione: aggiunge una filigrana di valutazione a ogni diapositiva salvata e tronca il testo letto dalle presentazioni. Per rimuovere queste limitazioni, applica una [licenza](/slides/it/net/licensing/).