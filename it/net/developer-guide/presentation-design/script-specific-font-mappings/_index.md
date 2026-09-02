---
title: Gestire i caratteri di tema specifici per script in .NET
linktitle: Caratteri di tema specifici per script
type: docs
weight: 15
url: /it/net/script-specific-font-mappings/
keywords:
- carattere specifico per script
- mappatura del carattere del tema
- presentazione multilingue
- sistema di scrittura
- carattere cirillico
- carattere arabo
- carattere giapponese
- carattere georgiano
- carattere thaana
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di caratteri specifici per script nei temi PowerPoint con Aspose.Slides per .NET."
---
## **Panoramica**

Un tema di presentazione può selezionare diverse famiglie di caratteri per diversi sistemi di scrittura. Questo consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato, utilizzando caratteri adeguati per il cirillico, l'arabo, il giapponese, il georgiano, il thaana e altri script.

Il tema [IFontScheme](https://reference.aspose.com/slides/it/net/aspose.slides.theme/ifontscheme/) contiene una raccolta di caratteri principale, tipicamente usata per le intestazioni, e una raccolta di caratteri secondaria, tipicamente usata per il corpo del testo. Oltre alle loro proprietà di caratteri latini e dell'Asia orientale, entrambe le raccolte espongono le mappature da tag di sistema di scrittura a nomi di famiglie di caratteri tramite l'interfaccia [IFonts](https://reference.aspose.com/slides/it/net/aspose.slides/ifonts/).

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e ricaricamento.

## **Comprendere i tag di script**

I metodi dei caratteri di script utilizzano sottotag di script BCP 47 a quattro lettere per identificare i sistemi di scrittura. I valori comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema dei caratteri del tema, non a singole porzioni di testo. Una presentazione può definire mappature diverse per le raccolte principali e secondarie, e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri di script**

Usa [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/) per accedere al tema a livello di presentazione. Le proprietà [FontScheme.Major](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/major/) e [FontScheme.Minor](https://reference.aspose.com/slides/it/net/aspose.slides.theme/fontscheme/minor/) restituiscono le due collezioni [IFonts](https://reference.aspose.com/slides/it/net/aspose.slides/ifonts/).

Chiama [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/getscriptfontmap/) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [IFonts.GetScriptFont](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/getscriptfont/) con il suo tag di script. `GetScriptFont` restituisce `null` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificare la persistenza**

Usa [IFonts.SetScriptFont](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/setscriptfont/) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/removescriptfont/) per rimuovere una mappatura.

Il seguente esempio end‑to‑end legge tutte le mappature principali e secondarie esistenti, individua il carattere giapponese principale, cambia il carattere cirillico principale, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passaggio di rimozione indipendente dal tema iniziale, l’esempio crea prima una mappatura Thaana solo se non è già definita.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

La verifica utilizza lo stesso comportamento `null` di una ricerca ordinaria: dopo aver salvato la rimozione, `GetScriptFont("Thaa")` restituisce `null` per la collezione secondaria.

## **Distinguere le mappature del tema da altre impostazioni dei caratteri**

Le mappature del tema specifiche per script partecipano alla selezione del carattere, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto del cambiare una mappatura del tema |
|---|---|---|
| Mappatura del carattere di tema specifica per script | Seleziona un carattere di tema principale o secondario per un sistema di scrittura. | Il testo che utilizza ancora il carattere del tema corrispondente può risolvere nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione del carattere | Sostituisce un carattere richiesto quando quel carattere non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che il carattere è stato richiesto; non ridefinisce la mappatura dello script del tema. |
| Fallback del carattere | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Colma la copertura dei glifi mancanti; non modifica la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedi [Sostituzione di caratteri](/slides/it/net/font-substitution/) e [Caratteri di fallback](/slides/it/net/fallback-font/).

Modificare una mappatura in [Presentation.MasterTheme](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/mastertheme/) influisce solo sul contenuto il cui formato efficace dipende ancora da quel tema. Il testo può invece ereditare una sovrascrittura di tema da un master, layout o diapositiva, o utilizzare un carattere assegnato esplicitamente. Ispeziona questi livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura di script memorizza un nome di famiglia di caratteri; non installa né carica il file di carattere corrispondente. Per un rendering ed esportazione coerenti, ogni carattere mappato deve essere installato nell’ambiente o fornito ad Aspose.Slides tramite una fonte personalizzata come [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/). Vedi [Caratteri personalizzati](/slides/it/net/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non prova che il carattere sia disponibile, che contenga tutti i glifi richiesti o che produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un’immagine o PDF e ispeziona l’output. Questo rileva caratteri mancanti, copertura incompleta dei glifi, comportamento di fallback e modifiche di layout prima che la presentazione venga distribuita. Vedi [Convertire le presentazioni PowerPoint](/slides/it/net/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `GetScriptFont` quando uno script non è mappato?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/getscriptfont/) restituisce `null` quando la mappatura dello script richiesto non è definita in quella collezione principale o secondaria.

**`SetScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [IFonts.SetScriptFont](https://reference.aspose.com/slides/it/net/aspose.slides/fonts/setscriptfont/) crea la mappatura quando manca e sostituisce la famiglia di caratteri mappata quando il tag di script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite una sovrascrittura, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura di script a livello di presentazione controlla solo il testo il cui formato efficace fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l’output multilingue?**

No. La riapertura verifica la persistenza dei dati del tema. È inoltre necessario renderizzare testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.