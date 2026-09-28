---
title: Requisiti di sistema
type: docs
weight: 60
url: /it/net/system-requirements/
keywords:
- requisiti di sistema
- piattaforme supportate
- framework di destinazione
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Verifica cosa richiede Aspose.Slides per .NET prima di installarlo: i framework a cui puntano i vari pacchetti NuGet, i sistemi operativi e i processori supportati, e le librerie e i font richiesti da Linux."
---
## **Introduzione**

Aspose.Slides for .NET è una libreria autonoma: non necessita di Microsoft PowerPoint o Microsoft Office. È pubblicata come due pacchetti NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) e [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Entrambi forniscono gli stessi namespace e classi Aspose.Slides; differiscono per i framework di destinazione e per il modo in cui disegnano le diapositive, il che determina dove vengono eseguiti e cosa necessitano.

Questo articolo elenca le versioni .NET e le piattaforme supportate da ciascun pacchetto, le librerie di sistema e i caratteri che Linux richiede, e termina con un breve programma che verifica la tua configurazione. Per aggiungere un pacchetto a un progetto, vedi [Installazione](/slides/it/net/installation/).

## **Versioni .NET supportate**

Ogni pacchetto contiene una build di Aspose.Slides per framework di destinazione, e NuGet seleziona la build che corrisponde al framework di destinazione del tuo progetto.

| Pacchetto | Framework di destinazione nel pacchetto | Il tuo progetto può puntare a |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 o successivo; .NET 6 o successivo, inclusi .NET 8, .NET 9 e .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 o successivo, inclusi .NET 8, .NET 9 e .NET 10 |

La build `netstandard2.0` consente a una libreria class .NET Standard 2.0 di fare riferimento ad Aspose.Slides.NET. Un'applicazione che utilizza tale libreria esegue la build che corrisponde al framework di destinazione dell'applicazione stessa: ad esempio, un'applicazione .NET 8 esegue la build `net6.0`.

## **Sistemi operativi e processori supportati**

**Aspose.Slides.NET** contiene solo codice gestito indipendente dal processore (AnyCPU), quindi viene eseguito sull'architettura del runtime .NET che lo carica. Disegna le diapositive tramite la libreria System.Drawing.Common di Microsoft, che Microsoft supporta [solo su Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Su Linux, Aspose.Slides.NET quindi necessita della libreria `libgdiplus` e di un interruttore di avvio, descritti in [Linux](#linux). Funziona su distribuzioni Linux che forniscono `libgdiplus`, come Debian, Ubuntu e Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** disegna le diapositive con il proprio motore grafico. Il motore è una libreria nativa che il pacchetto contiene in una build per piattaforma, quindi il pacchetto funziona solo su queste piattaforme:

| Sistema operativo | Processori | Note |
|---|---|---|
| Windows | x86, x64 | Windows su ARM64 non è supportato. |
| Linux | x64, ARM64 | Richiede glibc 2.23 o successiva su x64 e glibc 2.39 o successiva su ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform non funziona su Alpine Linux o altre distribuzioni basate su musl anziche` glibc, ne su distribuzioni con una glibc più vecchia, come CentOS 7. Usa Aspose.Slides.NET su tali sistemi.

Su Windows, la libreria nativa di Aspose.Slides.NET6.CrossPlatform utilizza il runtime Microsoft Visual C++ (*MSVCP140.dll* e *VCRUNTIME140.dll*, piu` *VCRUNTIME140_1.dll* su x64). Se questi file mancano sulla macchina di destinazione, installa il [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Entrambi i pacchetti necessitano di librerie di sistema aggiuntive su Linux. Senza di esse, il primo esempio in [Creare presentazioni](/slides/it/net/create-presentation/) fallisce con un'eccezione invece di salvare il file. I comandi seguenti sono per Debian e Ubuntu; su queste distribuzioni, ogni libreria porta anche i caratteri DejaVu (`fonts-dejavu-core`), quindi il testo viene visualizzato senza ulteriori pacchetti di caratteri.

### **Aspose.Slides.NET6.CrossPlatform**

La libreria Linux del pacchetto richiede la libreria `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Senza di essa, la creazione di una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) fallisce con una `TypeInitializationException` il cui `DllNotFoundException` interno segnala che `libfontconfig.so.1` non puo` essere aperto.

Le immagini base minime potrebbero non includere neanche `fontconfig`. L'immagine base AWS Lambda per .NET 8, ad esempio, non contiene ne` `fontconfig` ne` alcun carattere. In un'immagine container costruita su di essa, esegui `dnf install -y fontconfig`, che installa anche i caratteri Noto Sans.

### **Aspose.Slides.NET**

Il pacchetto richiede due cose su Linux:

1. La libreria `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

1. L'interruttore `System.Drawing.EnableUnixSupport`, abilitato all'inizio della tua applicazione prima di qualsiasi chiamata Aspose.Slides. In un *Program.cs* con dichiarazioni top-level, inseriscilo dopo le direttive `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Senza `libgdiplus`, il salvataggio di una presentazione fallisce con una `TypeInitializationException` il cui `DllNotFoundException` interno segnala che `libgdiplus` non puo` essere caricato. Senza l'interruttore, l'exception interna e` `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
L'interruttore funziona solo con System.Drawing.Common 6, la versione da cui dipende Aspose.Slides.NET. Microsoft l'ha rimosso in System.Drawing.Common 7. Se il tuo progetto fa riferimento a System.Drawing.Common 7 o successiva, direttamente o tramite un altro pacchetto, Aspose.Slides.NET fallisce su Linux con `PlatformNotSupportedException` anche se `libgdiplus` e` installato e l'interruttore e` abilitato. In tal caso, usa Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Su Alpine Linux, usa Aspose.Slides.NET con l'interruttore descritto sopra. Le immagini Alpine di solito non contengono caratteri, e `libgdiplus` da solo non ne installa alcuno, quindi installa `libgdiplus` insieme ad almeno un pacchetto di caratteri. Senza caratteri, il salvataggio di una presentazione fallisce con questo errore:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Opzione 1: caratteri DejaVu**

L'opzione consigliata e` il pacchetto `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Nelle versioni attuali di Alpine, `ttf-dejavu` installa il pacchetto `font-dejavu`, che installa anche `fontconfig` e gli strumenti di carattere da cui dipende.

**Opzione 2: caratteri di base Microsoft**

Se le tue presentazioni usano caratteri Microsoft come Arial, Times New Roman, Courier New o Verdana, installa invece i caratteri di base Microsoft. Lo step `update-ms-fonts` scarica i caratteri mentre l'immagine viene costruita, quindi la build ha bisogno di accesso a Internet:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Supporto alla globalizzazione**

Entrambi i pacchetti necessitano del supporto alla globalizzazione di .NET, che .NET su Linux fornisce tramite le librerie ICU. In [modalita` globalizzazione invariant](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), la creazione di una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) fallisce con `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Alcune immagini container attivano questa modalita`. Le immagini runtime .NET per Alpine Linux (`runtime-deps`, `runtime` e `aspnet`), ad esempio, impostano `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` e non includono ICU. In un'immagine costruita su di esse, installa ICU e disattiva la modalita`:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Assicurati inoltre che il file di progetto non imposti la proprieta` `InvariantGlobalization` su `true`.

## **Verifica la tua configurazione**

Per verificare che un pacchetto e i suoi requisiti siano presenti, esegui un programma che salva una presentazione e rende una diapositiva in un'immagine. Salvataggio e rendering utilizzano la libreria grafica e i caratteri, che sono forniti dai requisiti Linux sopra indicati.

Crea un'applicazione console e aggiungi il pacchetto come descritto in [Installazione](/slides/it/net/installation/), sostituisci il contenuto di *Program.cs* con il codice sotto e esegui `dotnet run`. Se usi Aspose.Slides.NET su Linux, aggiungi l'interruttore `System.Drawing.EnableUnixSupport` mostrato in [Linux](#linux) dopo le direttive `using`. Il programma usa dichiarazioni top-level e dichiarazioni `using`, che richiedono C# 9 o versioni successive. I progetti che puntano a .NET 6 o versioni successive usano una versione piu` recente di C# per impostazione predefinita; in un progetto che punta a .NET Framework, aggiungi `<LangVersion>latest</LangVersion>` a un `PropertyGroup` nel file di progetto.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Il programma aggiunge un rettangolo con testo alla prima diapositiva e salva la presentazione come *hello.pptx* con il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). Quindi rende la diapositiva con [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/) e salva il risultato come *hello.png* con [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/save/) nel formato [ImageFormat.Png](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/). I fattori di scala di 1 rendono un pixel per punto, quindi la diapositiva predefinita di 720 x 540 punti diventa un'immagine di 720 x 540 pixel, con il testo visibile all'interno del rettangolo. Senza licenza, entrambi i file contengono anche una filigrana di valutazione; vedi [Licensing](/slides/it/net/licensing/). Se manca un requisito, il programma si interrompe con una delle eccezioni descritte in [Linux](#linux).

## **Strumenti di sviluppo**

Puoi creare applicazioni che usano Aspose.Slides con qualsiasi strumento che supporta il framework di destinazione del tuo progetto: il .NET SDK e la sua interfaccia a riga di comando `dotnet` su Windows, Linux e macOS, o Visual Studio su Windows. [Installazione](/slides/it/net/installation/) descrive entrambi.

## **FAQ**

**Devo avere Microsoft PowerPoint installato per conversioni e rendering?**

No, PowerPoint non e` richiesto. Aspose.Slides e` un motore autonomo per [creare](/slides/it/net/create-presentation/), modificare, [convertire](/slides/it/net/convert-presentation/) e [rendere](/slides/it/net/convert-powerpoint-to-png/) presentazioni.

**Quale pacchetto dovrei usare?**

Usa Aspose.Slides.NET su Windows e Aspose.Slides.NET6.CrossPlatform su Linux e macOS. Su Alpine Linux, su sistemi Linux la cui glibc e` piu` vecchia delle versioni elencate sopra, e in progetti che puntano a .NET Framework, usa Aspose.Slides.NET. Aggiungi solo uno dei due pacchetti a un progetto.

**Quali caratteri sono necessari per un rendering corretto?**

I caratteri usati nella presentazione, o sostituti adeguati, devono essere disponibili nel sistema operativo. Su Linux e macOS, installa i pacchetti di caratteri di cui le tue presentazioni hanno bisogno per ottenere un rendering coerente. Su Alpine Linux, installa almeno un pacchetto di caratteri oltre a `libgdiplus`, come descritto in [Alpine Linux](#alpine-linux).

**Perche` un carattere personalizzato viene visualizzato come fallback o testo mancante su Linux?**

Se il file del carattere ha voci di tabella dei nomi incoerenti o corrotte, lo stack di abbinnamento dei caratteri di Linux (FreeType/fontconfig) può selezionare un record non valido, facendo si che il carattere non venga risolto. L'uso di una versione del carattere con voci di tabella dei nomi corrette o l'installazione di una sostituzione coerente risolve il problema.