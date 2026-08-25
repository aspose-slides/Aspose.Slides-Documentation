---
title: Gestire i caratteri del tema specifici per script in C++
linktitle: Caratteri del tema specifici per script
type: docs
weight: 15
url: /it/cpp/script-specific-font-mappings/
keywords:
- carattere specifico per script
- mappatura dei caratteri del tema
- presentazione multilingue
- sistema di scrittura
- carattere cirillico
- carattere arabo
- carattere giapponese
- carattere georgiano
- carattere thaana
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Esamina, aggiungi, sostituisci e rimuovi le mappature di caratteri specifici per script nei temi di PowerPoint con Aspose.Slides per C++."
---
## **Panoramica**

Un tema di presentazione può selezionare famiglie di caratteri diverse per sistemi di scrittura differenti. Questo consente a testi multilingue che utilizzano comunque i caratteri del tema di seguire uno schema di caratteri coordinato, usando caratteri adeguati per cirillico, arabo, giapponese, georgiano, thaana e altri script.

Il tema contiene l’interfaccia [IFontScheme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/ifontscheme/) con una collezione principale di caratteri, tipicamente usata per i titoli, e una collezione secondaria, tipicamente usata per il corpo del testo. Oltre alle proprietà dei caratteri latini e dell’Asia orientale, entrambe le collezioni espongono mappature da tag di sistema di scrittura a nomi di famiglie di caratteri tramite l’interfaccia [IFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifonts/).

Questo articolo mostra come esaminare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e riapertura.

## **Comprendere i tag script**

I metodi dei caratteri script usano sottotag script BCP 47 di quattro lettere per identificare i sistemi di scrittura. I valori più comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema di caratteri del tema, non a porzioni di testo individuali. Una presentazione può definire mappature diverse per le collezioni principale e secondaria e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri script**

Usa [Presentation::get_MasterTheme](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_mastertheme/) per accedere al tema a livello di presentazione. I metodi [FontScheme::get_Major](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/fontscheme/get_major/) e [FontScheme::get_Minor](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/fontscheme/get_minor/) restituiscono le due collezioni [IFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifonts/).

Chiama [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/getscriptfontmap/) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [Fonts::GetScriptFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/getscriptfont/) con il relativo tag script. `GetScriptFont` restituisce una stringa nulla quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificare la persistenza**

Usa [Fonts::SetScriptFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/setscriptfont/) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/removescriptfont/) per rimuovere una mappatura.

L’esempio end‑to‑end seguente legge tutte le mappature principali e secondarie esistenti, individua il carattere principale giapponese, cambia il carattere principale cirillico, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passo di rimozione indipendente dal tema iniziale, l’esempio crea una mappatura Thaana solo quando non è già definita.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

La verifica utilizza lo stesso comportamento della stringa nulla di una ricerca ordinaria: dopo che la rimozione è stata salvata, `GetScriptFont(u"Thaa")` restituisce una stringa nulla per la collezione secondaria.

## **Distinguere le mappature del tema da altre impostazioni dei caratteri**

Le mappature di caratteri del tema specifiche per script partecipano alla selezione del carattere, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura di carattere del tema specifica per script | Seleziona un carattere tema principale o secondario per un sistema di scrittura. | Il testo che continua a usare il carattere tema corrispondente può risolvere nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione dei caratteri | Sostituisce un carattere richiesto quando non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che un carattere è stato richiesto; non ridefinisce la mappatura script del tema. |
| Fallback dei caratteri | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Riempie le lacune di copertura dei glifi; non modifica la mappatura salvata del tema. |

Per ulteriori informazioni sugli ultimi due meccanismi, consulta [Font Substitution](/slides/it/cpp/font-substitution/) e [Fallback Fonts](/slides/it/cpp/fallback-font/).

Modificare una mappatura in [Presentation::get_MasterTheme](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_mastertheme/) influisce solo sul contenuto il cui formato efficace dipende ancora da quel tema. Il testo può invece ereditare un override di tema da un master, layout o slide, o usare un carattere assegnato esplicitamente. Ispeziona quei livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura script memorizza un nome di famiglia di caratteri; non installa né carica il file del carattere corrispondente. Per una resa coerente e per l’esportazione, ogni carattere mappato deve essere installato nell’ambiente o fornito ad Aspose.Slides tramite una sorgente personalizzata come [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Consulta [Custom Fonts](/slides/it/cpp/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Rendi rappresentativo del testo per ogni sistema di scrittura richiesto in un’immagine o PDF e ispeziona l’output. Questo individua caratteri mancanti, copertura di glifi incompleta, comportamento di fallback e variazioni di layout prima della distribuzione della presentazione. Vedi [Convert PowerPoint Presentations](/slides/it/cpp/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `GetScriptFont` quando uno script non è mappato?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/getscriptfont/) restituisce una stringa nulla quando la mappatura dello script richiesto non è definita in quella collezione principale o secondaria.

**`SetScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [Fonts::SetScriptFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fonts/setscriptfont/) crea la mappatura quando è assente e sostituisce la famiglia di caratteri mappata quando il medesimo tag script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato del testo?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite un override, oppure essere influenzato da sostituzione o fallback durante il rendering. Una mappatura script a livello di presentazione controlla solo il testo il cui formato efficace fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l’output multilingue?**

No. La riapertura verifica solo la persistenza dei dati del tema. È necessario anche rendere rappresentativo il testo di ogni sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.