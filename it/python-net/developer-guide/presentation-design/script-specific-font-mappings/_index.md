---
title: Gestisci i caratteri tematici specifici per script in Python
linktitle: Caratteri tematici specifici per script
type: docs
weight: 15
url: /it/python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di caratteri specifici per script nei temi di PowerPoint con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Un tema di presentazione può selezionare diverse famiglie di caratteri per diversi sistemi di scrittura. Questo consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato, utilizzando caratteri adeguati per il cirillico, l'arabo, il giapponese, il georgiano, il thaana e altri script.

Il [FontScheme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/) del tema contiene una raccolta di caratteri principali, tipicamente usata per i titoli, e una raccolta di caratteri secondari, tipicamente usata per il corpo del testo. Oltre alle loro proprietà di caratteri Latin e East Asian, entrambe le raccolte espongono mappature da tag di sistemi di scrittura a nomi di famiglie di caratteri tramite la classe [Fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/).

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e ricarica.

## **Comprendere i tag di script**

I metodi dei caratteri script utilizzano sottotag di script BCP 47 a quattro lettere per identificare i sistemi di scrittura. I valori più comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

## **Accedere e ispezionare le mappature dei caratteri script**

Usa [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/) per accedere al tema a livello di presentazione. Le proprietà [FontScheme.major](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/fontscheme/minor/) restituiscono le due raccolte [Fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/).

Chiama [Fonts.get_script_font_map](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/get_script_font_map/) per recuperare tutte le mappature da una raccolta. Per cercare un singolo sistema di scrittura, chiama [Fonts.get_script_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/get_script_font/) con il suo tag script. `get_script_font` restituisce `None` quando quella raccolta non definisce la mappatura richiesta.

## **Modificare le mappature e verificare la persistenza**

Usa [Fonts.set_script_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/set_script_font/) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [Fonts.remove_script_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/remove_script_font/) per rimuovere una mappatura.

La seguente example end-to-end legge tutte le mappature principali e secondarie esistenti, cerca il carattere principale giapponese, modifica il carattere principale cirillico, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passo di rimozione indipendente dal tema iniziale, l'esempio crea prima una mappatura Thaana solo se non è già definita.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

La verifica utilizza lo stesso comportamento `None` di una ricerca ordinaria: dopo che la rimozione è stata salvata, `get_script_font("Thaa")` restituisce `None` per la raccolta secondaria.

## **Distinguere le mappature del tema da altre impostazioni dei caratteri**

Le mappature tematiche specifiche per script partecipano alla selezione dei caratteri, ma risolvono un problema diverso dalla formattazione diretta del testo, sostituzione e fallback:

| Meccanismo | Scopo | Effetto del cambiare una mappatura del tema |
|---|---|---|
| Mappatura del carattere tematico specifica per script | Seleziona un carattere tematico principale o secondario per un sistema di scrittura. | Il testo che utilizza ancora il carattere tematico corrispondente può risolvere alla nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di basarsi sul tema. | La porzione può rimanere invariata perché la sua formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione del carattere | Sostituisce un carattere richiesto quando quel carattere non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che un carattere è stato richiesto; non ridefinisce la mappatura script del tema. |
| Fallback del carattere | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Compensa la copertura dei glifi mancanti; non modifica la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedere [Sostituzione dei caratteri](/slides/it/python-net/font-substitution/) e [Caratteri di fallback](/slides/it/python-net/fallback-font/).

Cambiare una mappatura in [Presentation.master_theme](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/master_theme/) influisce solo sul contenuto il cui formattazione efficace dipende ancora da quel tema. Il testo può invece ereditare un override del tema da un master, layout o slide, o utilizzare un carattere assegnato esplicitamente. Ispeziona questi livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura script memorizza un nome di famiglia di caratteri; non installa né carica il file di carattere corrispondente. Per un rendering e un'esportazione coerenti, ogni carattere mappato deve essere installato nell'ambiente o fornito a Aspose.Slides tramite una sorgente personalizzata come [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/load_external_fonts/) o [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/document_level_font_sources/). Consulta [Caratteri personalizzati](/slides/it/python-net/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura necessario in un'immagine o PDF e ispeziona l'output. Questo individua caratteri mancanti, copertura di glifi incompleta, comportamento di fallback e modifiche al layout prima della distribuzione della presentazione. Vedi [Converti presentazioni PowerPoint](/slides/it/python-net/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `get_script_font` quando uno script non è mappato?**

[Fonts.get_script_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/get_script_font/) restituisce `None` quando la mappatura di script richiesta non è definita in quella raccolta di caratteri principale o secondaria.

**`set_script_font` aggiunge una seconda mappatura quando lo script esiste già?**

No. [Fonts.set_script_font](https://reference.aspose.com/slides/it/python-net/aspose.slides/fonts/set_script_font/) crea la mappatura quando è assente e sostituisce la famiglia di caratteri mappata quando lo stesso tag script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite un override, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura script a livello di presentazione controlla solo il testo la cui formattazione efficace fa ancora riferimento a quella raccolta di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l'output multilingue?**

No. La riapertura verifica la persistenza dei dati del tema. Inoltre, renderizza testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.