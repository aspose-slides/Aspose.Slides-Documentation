---
title: Distribuire i font per Aspose.Slides su Linux e in Docker
linktitle: Distribuzione font
type: docs
weight: 145
url: /it/net/deploy-fonts/
keywords:
- distribuire font
- installare font
- font in Docker
- font su Linux
- font mancanti
- sostituzione dei font
- font core Microsoft
- ttf-mscorefonts-installer
- font personalizzati
- font predefinito
- server
- container
- conversione PDF
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Distribuire i font per Aspose.Slides per .NET su server Linux e in container Docker: verificare quali font sono sostituiti, installare i pacchetti dei font su Debian, Ubuntu e Alpine, aggiungere i propri file di font e impostare un font predefinito."
---
## **Panoramica**

Aspose.Slides disegna il testo con i caratteri disponibili al momento del rendering di una presentazione, ad esempio quando converte diapositive in PDF o in immagini. Un desktop Windows dispone solitamente dei caratteri utilizzati dalle presentazioni. I server e i container Linux hanno di solito pochi caratteri o nessuno, perciò Aspose.Slides utilizza un carattere sostitutivo. Un sostituto ha forme e larghezze di lettere diverse, quindi le righe possono andare a capo in modo differente e il testo può fuoriuscire dalla forma, e i caratteri non presenti nel sostituto non vengono disegnati correttamente. Se non è installato alcun carattere, la conversione si interrompe con un errore.

Questo articolo mostra come verificare quali caratteri Aspose.Slides sostituisce, come installare i caratteri su Debian, Ubuntu e Alpine Linux, come aggiungere file di caratteri propri e come impostare il carattere da utilizzare quando un carattere è mancante. Gli esempi vengono eseguiti in Docker sulle immagini ufficiali .NET, come in [Esegui Aspose.Slides per .NET in Docker](/slides/it/net/how-to-run-aspose-slides-in-docker/). I comandi del pacchetto sono istruzioni Dockerfile; su un server Linux, esegui gli stessi comandi come root.

Per l’API dei caratteri stessa, ad esempio l’incorporamento dei caratteri in una presentazione e le regole di fallback e sostituzione, vedi [Font di PowerPoint](/slides/it/net/powerpoint-fonts/).

## **Verifica Quali Caratteri Sono Sostituiti**

L’applicazione console seguente riporta i caratteri che Aspose.Slides sostituisce nell’ambiente corrente. Crea una cartella denominata *FontCheck* e aggiungi i file sotto indicati.

*FontCheck.csproj* fa riferimento a [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), il pacchetto per Debian e Ubuntu. Copia inoltre i file di una cartella *fonts* opzionale nell’output dell’applicazione; la sezione [Carica i caratteri dalla cartella dell’applicazione](#load-fonts-from-the-application-folder) la utilizza.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* aggiunge una casella di testo per ogni nome di carattere a una diapositiva e assegna il carattere tramite la proprietà [LatinFont](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/latinfont/). I nomi dei caratteri provengono dalla riga di comando; senza argomenti, l’applicazione verifica Calibri, Arial e Times New Roman. Stampa le cartelle in cui Aspose.Slides cerca i caratteri ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/)), renderizza la diapositiva in *output/fonts.pdf* e stampa le sostituzioni riportate da [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/). I due passaggi opzionali all’inizio, il caricamento di una cartella *fonts* e la lettura della variabile `DEFAULT_FONT`, sono spiegati più avanti in questo articolo.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// I caratteri da verificare: gli argomenti della riga di comando, o tre font comuni di Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Load the font files from the fonts folder next to the application, if there is one.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Use the font named in the DEFAULT_FONT environment variable, if it is set, for text whose font is missing.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* esclude i risultati di compilazione locali dal contesto di build:

```text
bin/
obj/
output/
```

*Dockerfile* compila l’applicazione con l’immagine SDK .NET e la esegue sull’immagine runtime .NET. Lo stage runtime installa `libfontconfig1`, richiesto da Aspose.Slides.NET6.CrossPlatform, e i caratteri DejaVu. [Esegui Aspose.Slides per .NET in Docker](/slides/it/net/how-to-run-aspose-slides-in-docker/) spiega ogni istruzione.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Compila l’immagine ed esegui il controllo:

```bash
docker build -t font-check .
docker run --rm font-check
```

L’immagine contiene solo i caratteri DejaVu, quindi tutti e tre i caratteri sono sostituiti con DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Per verificare i caratteri delle tue presentazioni, passane i nomi come argomenti, ad esempio `docker run --rm font-check "Segoe UI" Consolas`. Per copiare *output/fonts.pdf* fuori dal container, usa i comandi in [Copia l’output sul tuo computer](/slides/it/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installa i Caratteri su Debian e Ubuntu**

### **Microsoft Core Fonts**

Il pacchetto `ttf-mscorefonts-installer` scarica e installa i caratteri fondamentali di Microsoft per il Web, tra cui Arial, Times New Roman, Courier New, Verdana, Georgia e Trebuchet MS. I caratteri sono concessi in licenza secondo il contratto di licenza per l’utente finale di Microsoft (EULA), e il pacchetto li installa solo dopo che l’EULA è stata accettata. Una build Docker non può rispondere al prompt, perciò l’installatore rifiuta l’EULA e non installa alcun carattere, mentre `apt-get install` segnala comunque il successo. Accetta l’EULA con `debconf-set-selections` **prima** dell’installazione del pacchetto.

Nel *Dockerfile*, sostituisci l’istruzione `RUN` che installa i pacchetti nello stage runtime con:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Compila nuovamente l’immagine ed esegui il controllo con gli stessi due comandi. Arial e Times New Roman sono ora installati:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, il carattere predefinito di una presentazione creata da Aspose.Slides, non fa parte dei caratteri fondamentali, quindi viene comunque sostituito. Vedi [Imposta un carattere predefinito per i caratteri mancanti](#set-a-default-font-for-missing-fonts).

Su Debian, il pacchetto si trova nella componente `contrib` del repository, che le immagini Debian non abilitano; le immagini .NET 8 e .NET 9 predefinite si basano su Debian 12. Abilita `contrib` nella stessa istruzione:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Le immagini .NET 10 basate su Ubuntu abilitano già `multiverse`, la componente Ubuntu che contiene il pacchetto.

### **Altri Pacchetti di Caratteri**

Debian e Ubuntu forniscono anche caratteri con licenza libera, ad esempio:

| Pacchetto | Caratteri |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif e Mono, con metriche uguali a Arial, Times New Roman e Courier New |
| `fonts-crosextra-carlito` | Carlito, con metriche uguali a Calibri |
| `fonts-crosextra-caladea` | Caladea, con metriche uguali a Cambria |

Installa i pacchetti con `apt-get install` nella stessa istruzione `RUN`. Aspose.Slides.NET6.CrossPlatform non applica gli alias dei caratteri della configurazione dei caratteri Linux: con `fonts-liberation` installato, il testo in Arial viene ancora disegnato con il carattere sostitutivo generico, non con Liberation Sans. Per usare un carattere compatibile metricamente al posto di quello mancante, impostalo come [carattere predefinito](#set-a-default-font-for-missing-fonts) o aggiungi una [regola di sostituzione dei caratteri](/slides/it/net/font-substitution/).

## **Aggiungi i Tuoi File di Caratteri**

I caratteri non forniti dalle distribuzioni, come quelli della tua organizzazione o altri per i quali possiedi licenza per l’uso sul server, possono essere aggiunti come file di caratteri. Posiziona i file di caratteri, ad esempio file *.ttf*, in una cartella denominata *fonts* all’interno della cartella *FontCheck*. Gli esempi sotto usano i file di Carlito, un carattere con metriche uguali a Calibri, scaricabili da [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installa i Caratteri in una Cartella di Sistema**

Aspose.Slides legge i caratteri nelle cartelle elencate nella riga `Font folders`. Per installare i tuoi caratteri per ogni applicazione nell’immagine, copiali in */usr/local/share/fonts*, la cartella per i caratteri installati localmente. Aggiungi questa istruzione allo stage runtime del *Dockerfile*, dopo l’istruzione `RUN` che installa i pacchetti:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Carica i Caratteri dalla Cartella dell’Applicazione**

Invece di installare i caratteri nell’immagine, puoi includerli con l’applicazione e caricarli tramite [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/). I caratteri saranno quindi disponibili solo a Aspose.Slides e verranno distribuiti insieme all’applicazione. *FontCheck* lo fa: *FontCheck.csproj* copia la cartella *fonts* nell’output dell’applicazione, e *Program.cs* passa quella cartella a `LoadExternalFonts` prima di creare la presentazione. [Carattere Personalizzato](/slides/it/net/custom-font/) descrive gli altri modi per fornire i caratteri, ad esempio il caricamento dalla memoria.

Ricompila l’immagine, poi verifica Calibri e Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

La cartella dell’applicazione ora compare tra le cartelle dei caratteri, e Carlito non viene più sostituito:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Imposta un Carattere Predefinito per i Caratteri Mancanti**

Quando un carattere è mancante, Aspose.Slides utilizza un sostituto scelto autonomamente. Per sceglierlo tu, imposta la proprietà [DefaultRegularFont](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaultregularfont/) di [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/) e passa le opzioni al costruttore di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). *FontCheck* legge il nome del carattere dalla variabile d’ambiente `DEFAULT_FONT`. Con Carlito caricato, usalo per i caratteri mancanti:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri ora viene disegnato con Carlito, i cui caratteri hanno le stesse larghezze di Calibri, quindi il testo mantiene le interruzioni di riga:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Il carattere predefinito sostituisce tutti i caratteri mancanti. Per mappare singoli caratteri, ad esempio Arial → Liberation Sans e Calibri → Carlito, usa le [regole di sostituzione dei caratteri](/slides/it/net/font-substitution/). Le regole cambiano l’output renderizzato, ma `GetSubstitutions` non le riflette; verifica quindi i caratteri nel file di output. Per il testo asiatico, imposta anche [DefaultAsianFont](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/defaultasianfont/); vedi [Carattere Predefinito](/slides/it/net/default-font/).

## **Installa i Caratteri su Alpine Linux**

Su Alpine Linux, usa il pacchetto Aspose.Slides.NET; [Esecuzione su Alpine Linux](/slides/it/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) elenca le modifiche al progetto. Apporta le stesse modifiche a *FontCheck*: sostituisci il riferimento al pacchetto, aggiungi l’istruzione `SetSwitch` in *Program.cs* e usa questo stage runtime, che installa anche i caratteri Microsoft core:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` scarica e installa gli stessi caratteri Microsoft core dei pacchetti Debian e Ubuntu, e la loro EULA si applica allo stesso modo. `fc-cache` aggiorna la cache dei caratteri.

Con Aspose.Slides.NET su Linux, la libreria di configurazione dei caratteri (fontconfig) sceglie il sostituto per un carattere mancante, e `GetSubstitutions` non lo segnala, perciò *FontCheck* stampa `No font substitutions.` Per vedere quale carattere è usato per un nome specifico, chiedi a fontconfig nel container:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Con i caratteri Microsoft core installati, Arial è usato per Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Senza di essi, quando l’istruzione `RUN` installa solo `icu-libs libgdiplus font-dejavu`, lo stesso comando stampa:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Perché una presentazione appare diversa quando viene convertita su un server?**

Il server non dispone dei caratteri utilizzati dalla presentazione, quindi Aspose.Slides disegna il testo con un carattere sostitutivo le cui lettere hanno larghezze diverse. Esegui *FontCheck* con i nomi dei caratteri della presentazione per vedere quali sono sostituiti, quindi installa quei caratteri o caricali dalla cartella dell’applicazione.

**La build ha installato ttf-mscorefonts-installer, ma Arial è ancora sostituito. Perché?**

L’EULA non è stata accettata prima dell’installazione del pacchetto, quindi l’installatore ha saltato i caratteri. Aggiungi il comando `debconf-set-selections` prima di `apt-get install`, come mostrato in [Microsoft Core Fonts](#microsoft-core-fonts), e ricompila l’immagine.

**Il computer che apre il PDF ha bisogno dei caratteri?**

No. In questi esempi il PDF contiene i caratteri utilizzati per disegnare il testo, quindi appare identico su qualsiasi computer. I caratteri sono necessari solo dove Aspose.Slides rende la presentazione.