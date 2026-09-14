---
title: Gestire i font del tema specifici per script in Python via Java
linktitle: Font del tema specifici per script
type: docs
weight: 15
url: /it/python-java/script-specific-font-mappings/
keywords:
- font specifico per script
- mappatura del font del tema
- presentazione multilingue
- sistema di scrittura
- font cirillico
- font arabo
- font giapponese
- font georgiano
- font thaana
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di font specifici per script nei temi PowerPoint con Aspose.Slides per Python via Java."
---
## **Panoramica**

Un tema di presentazione può selezionare diverse famiglie di caratteri per differenti sistemi di scrittura. Questo consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato, utilizzando caratteri adatti per cirillico, arabo, giapponese, georgiano, thaana e altri script.

Il [FontScheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontscheme/) del tema contiene una collezione di caratteri principale, tipicamente usata per i titoli, e una collezione secondaria, tipicamente usata per il corpo del testo. Oltre alle impostazioni dei caratteri latini ed est‑asiatici, entrambe le collezioni espongono le mappature da tag del sistema di scrittura a nomi di famiglie di caratteri tramite la classe [Fonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/).

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e ricarica.

## **Comprendere i tag di script**

I metodi dei caratteri di script usano sottotag di script BCP 47 a quattro lettere per identificare i sistemi di scrittura. I valori comuni includono:

| Tag di script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema di caratteri del tema, non a singole porzioni di testo. Una presentazione può definire mappature diverse per le collezioni principale e secondaria, e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri di script**

Usa [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasterTheme) per accedere al tema a livello di presentazione. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontscheme/#getMajor) e [FontScheme.getMinor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontscheme/#getMinor) restituiscono le due collezioni [Fonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/).

Chiama [Fonts.getScriptFontMap](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#getScriptFontMap) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [Fonts.getScriptFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#getScriptFont) con il suo tag di script. `getScriptFont` restituisce `None` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificare la persistenza**

Usa [Fonts.setScriptFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#setScriptFont) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [Fonts.removeScriptFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#removeScriptFont) per rimuovere una mappatura.

L'esempio end-to-end seguente legge tutte le mappature principali e secondarie esistenti, ricerca il carattere principale giapponese, cambia il carattere principale cirillico, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passaggio di rimozione indipendente dal tema iniziale, l'esempio crea prima una mappatura Thaana solo se non è già definita.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

La verifica utilizza lo stesso comportamento `None` di una ricerca ordinaria: dopo che la rimozione viene salvata, `getScriptFont("Thaa")` restituisce `None` per la collezione secondaria.

## **Distinguere le mappature del tema da altre impostazioni dei caratteri**

Le mappature di tema specifiche per script partecipano alla selezione del carattere, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura di carattere di tema specifica per script | Seleziona un carattere di tema principale o secondario per un sistema di scrittura. | Il testo che utilizza ancora il carattere del tema corrispondente può risolvere nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione dei caratteri | Sostituisce un carattere richiesto quando non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che è stato richiesto un carattere; non ridefinisce la mappatura di script del tema. |
| Fallback dei caratteri | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Copre la mancanza di glifi; non cambia la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedere [Font Substitution](/slides/it/python-java/font-substitution/) e [Fallback Fonts](/slides/it/python-java/fallback-font/).

Modificare una mappatura in [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasterTheme) influisce solo sul contenuto la cui formattazione efficace dipende ancora da quel tema. Il testo può invece ereditare un override del tema da un master, layout o diapositiva, o utilizzare un carattere assegnato esplicitamente. Ispeziona quei livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura di script memorizza un nome di famiglia di caratteri; non installa né carica il file del carattere corrispondente. Per una resa coerente e l'esportazione, ogni carattere mappato deve essere installato nell'ambiente o fornito ad Aspose.Slides tramite una fonte personalizzata come [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/#loadExternalFonts) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Vedi [Custom Fonts](/slides/it/python-java/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un'immagine o PDF e ispeziona l'output. Questo individua caratteri mancanti, copertura di glifi incompleta, comportamento di fallback e modifiche di layout prima della distribuzione della presentazione. Vedi [Convert PowerPoint Presentations](/slides/it/python-java/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `getScriptFont` quando uno script non è mappato?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#getScriptFont) restituisce `None` quando la mappatura di script richiesta non è definita in quella collezione principale o secondaria.

**`setScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [Fonts.setScriptFont](https://reference.aspose.com/slides/it/python-java/aspose.slides/fonts/#setScriptFont) crea la mappatura quando manca e sostituisce la famiglia di caratteri mappata quando lo stesso tag di script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite un override, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura di script a livello di presentazione controlla solo il testo la cui formattazione efficace fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l'output multilingue?**

No. La riapertura verifica la persistenza dei dati del tema. È inoltre necessario renderizzare testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.