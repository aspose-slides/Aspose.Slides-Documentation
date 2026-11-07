---
title: Sequenza di selezione dei font in Aspose.Slides per .NET
linktitle: Selezione del font
type: docs
weight: 80
url: /it/net/font-selection-sequence/
keywords:
- selezione del font
- sostituzione del font
- rimpiazzo del font
- regola di sostituzione
- font disponibile
- font mancante
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET seleziona i font, garantendo una presentazione nitida e coerente di file PPT, PPTX e ODP — migliora le tue diapositive ora."
---
## **Panoramica**

Quando una presentazione viene caricata, renderizzata o convertita in un altro formato, Aspose.Slides considera i caratteri incorporati e i caratteri disponibili per l'applicazione. Se un carattere richiesto non è disponibile, Aspose.Slides seleziona un carattere sostitutivo il più vicino possibile a quello che userebbe PowerPoint.

I caratteri disponibili possono includere caratteri di sistema, caratteri caricati dall'applicazione e caratteri incorporati nella presentazione. Per un carattere incorporato e registrato corrispondente, la preferenza .NET 26.11 descritta di seguito controlla quale ha la priorità. Le regole di sostituzione dei caratteri definite tramite [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) sono un meccanismo separato.

Puoi anche aggiungere caratteri durante l'esecuzione dell'applicazione, usare caratteri incorporati da una presentazione o caricare caratteri esterni per documenti di output come file PDF.

## **Selezione del carattere**

Il testo può fare riferimento a un carattere del tema, come `+mn-lt`, invece di un nome di famiglia esplicito. Vedi [Risolvere i riferimenti ai caratteri del tema](/slides/it/net/presentation-theme/#resolve-theme-font-references) per ottenere la famiglia specificata dal tema applicabile. La risoluzione di quel riferimento è separata dal controllo della disponibilità dei caratteri e dall'applicazione della sostituzione in fase di rendering o del fallback dei glifi; non identifica il file del carattere effettivamente usato per renderizzare il testo.

Durante il rendering delle diapositive o la conversione di una presentazione, verifica che i caratteri richiesti siano incorporati o disponibili dalle fonti registrate. I caratteri mancanti possono richiedere una sostituzione o una sostituzione; vedi [**Sostituzione dei caratteri**](/slides/it/net/font-replacement/) e [**Sostituzione dei caratteri**](/slides/it/net/font-substitution/).

Quando si indaga la selezione del carattere:

1. Risolvi la famiglia e lo stile richiesti, includendo eventuale riferimento al tema.
2. Controlla i caratteri incorporati e le fonti registrate, includendo i caratteri di sistema e i caratteri caricati dall'applicazione. Usa la preferenza di seguito quando le versioni incorporate e registrate competono.
3. Rivedi le [regole di sostituzione dei caratteri](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) e il fallback dei glifi se il carattere o i caratteri richiesti non sono disponibili.

Aspose.Slides consente di aggiungere caratteri durante l'esecuzione dell'applicazione e quindi di usarli. Vedi [**Caratteri personalizzati**](/slides/it/net/custom-font/).

Quando vengono inseriti caratteri aggiuntivi all'interno di una presentazione, vengono chiamati [**Caratteri incorporati**](/slides/it/net/embedded-font/).

Aspose.Slides consente di aggiungere caratteri che vengono applicati *solo* ai documenti di output. Ad esempio, se una presentazione che desideri convertire in PDF contiene caratteri mancanti dal tuo sistema e dai caratteri incorporati, puoi aggiungere o caricare i caratteri necessari come **caratteri esterni**.

{{% alert title="Note" color="info" %}} 
Non distribuiamo alcun carattere, sia a pagamento che gratuito. La nostra API consente di caricare caratteri esterni e di incorporarli nei documenti, ma lo fai con i caratteri a tua discrezione e responsabilità.
{{% /alert %}}

## **Preferisci i caratteri registrati rispetto ai caratteri incorporati**

A partire da .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) consente a un carattere registrato corrispondente di avere priorità rispetto a un carattere incorporato durante l'esportazione. Il valore predefinito è `false`. La corrispondenza utilizza il nome e lo stile del carattere; un nome di famiglia diverso non è una corrispondenza di sostituzione. I caratteri registrati possono provenire dal sistema o da [font source caricati esplicitamente](/slides/it/net/custom-font/).

L'esempio seguente utilizza il **Aspose.Slides.NET6.CrossPlatform 26.11** package su .NET 8. Segui la [guida all'installazione](/slides/it/net/installation/) per il tuo ambiente. Fornisci `embedded-fonts.pptx` con un carattere incorporato e `preferred.ttf` con lo stesso nome di famiglia e stile. I due file di carattere dovrebbero differire visibilmente se desideri confrontare l'output.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Questa impostazione modifica la precedenza dei caratteri durante l'esportazione; non rinomina il carattere del testo, non rimuove i dati del carattere incorporato né reincorpora il file registrato. È un'impostazione di runtime: impostala nuovamente dopo aver riaperto una presentazione. Se non è disponibile un carattere registrato corrispondente, abilitare la preferenza non ne fornisce uno; verifica il carattere risultante e il layout nel tuo ambiente di destinazione.

L'output PNG e PDF con caratteri regolari caricati esplicitamente è stato verificato per la configurazione sopra. Controlla i tuoi file di carattere, gli stili, la build SDK e i formati di output prima di fare affidamento su risultati identici. Le metriche dei caratteri possono modificare le interruzioni di riga e il posizionamento. Usa [sostituzione dei caratteri](/slides/it/net/font-replacement/) o [sostituzione](/slides/it/net/font-substitution/) quando hai bisogno di una famiglia diversa, e [operazioni sui caratteri incorporati](/slides/it/net/embedded-font/) quando devi modificare i caratteri memorizzati nella presentazione.

## **Domande frequenti**

**Come posso determinare quali caratteri sono effettivamente usati in una presentazione prima della conversione?**

Aspose.Slides ti consente di ispezionare i caratteri usati tramite il [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), così puoi decidere se [incorporare](/slides/it/net/embedded-font/), [sostituire](/slides/it/net/font-replacement/) o aggiungere [fonti esterne](/slides/it/net/custom-font/). Questo ti aiuta a prevenire sostituzioni indesiderate durante il rendering e l'esportazione.

**Posso aggiungere directory di caratteri aggiuntive senza installarle sul sistema operativo?**

Sì. Puoi registrare [font source esterni](/slides/it/net/custom-font/) come cartelle o flussi in memoria per il rendering e l'esportazione. Questo elimina la dipendenza dai caratteri del sistema host e mantiene il layout prevedibile.

**Come evito un fallback silenzioso a un carattere non idoneo quando un glifo è mancante?**

Definisci esplicitamente [sostituzione dei caratteri](/slides/it/net/font-replacement/) e le [regole di fallback](/slides/it/net/fallback-font/) in anticipo. Analizzando i caratteri usati e impostando una priorità controllata per i sostituti, garantisci una tipografia coerente ed eviti risultati inattesi.