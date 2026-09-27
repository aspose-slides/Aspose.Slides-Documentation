---
title: Installazione
type: docs
weight: 70
url: /it/python-net/installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- usa Aspose.Slides
- installazione Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Installa Aspose.Slides per Python via .NET da PyPI con pip su Windows, Linux e macOS, e installa le librerie native necessarie a Linux e macOS."
---
## **Panoramica**

Questo articolo spiega come installare Aspose.Slides per Python via .NET su Windows, Linux e macOS. Il pacchetto è pubblicato su [PyPI](https://pypi.org/project/aspose.slides/) e installato con pip. Include il runtime .NET che utilizza, quindi non è necessario installare .NET. Su Linux e macOS, quel runtime richiede librerie native che il sistema operativo potrebbe non includere; le sezioni seguenti le elencano.

Aspose.Slides per Python via .NET supporta Python 3.5‑3.14. PyPI fornisce pacchetti per Windows (32‑bit e 64‑bit), Linux (x86_64 e ARM64) e macOS (Intel e Apple silicon).

## **Windows**

Su Windows, installa il pacchetto con pip. Non sono necessarie altre librerie.

```bash
pip install aspose.slides
```

## **Linux**

Su Linux, il runtime .NET incluso nel pacchetto richiede due librerie:

- **libgdiplus**, un'implementazione dell'API grafica Windows GDI+. Senza di essa, il salvataggio di una presentazione fallisce con l'errore `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Senza di essa, il processo Python termina alla prima chiamata a Aspose.Slides con il messaggio `Couldn't find a valid ICU package installed on the system`.

Su Debian e Ubuntu, installa entrambi con apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

La denominazione del pacchetto ICU contiene la sua versione: `libicu76` è il pacchetto per Debian 13. Su Debian 12, installa `libicu72` invece, e su Ubuntu 24.04, `libicu74`. Per trovare il nome sul tuo sistema, esegui:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Quindi installa il pacchetto in un ambiente virtuale. Nelle versioni attuali di Debian e Ubuntu, il Python di sistema non consente `pip install` al di fuori di un ambiente virtuale e si interrompe con l'errore `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Esegui i tuoi script con lo stesso ambiente virtuale attivato. Se usi un Python che la tua distribuzione non gestisce, come quello nelle immagini Docker ufficiali `python`, puoi anche eseguire `pip install aspose.slides` senza un ambiente virtuale.

I caratteri usati nelle tue presentazioni, o sostituti adeguati, devono essere installati sul sistema affinché il testo venga visualizzato correttamente quando converti le diapositive in PDF o immagini.

## **macOS**

Non abbiamo verificato l'installazione su macOS. Su macOS, Aspose.Slides richiede i seguenti prerequisiti:

- **Python with shared libraries**, ovvero Python compilato con l'opzione di configurazione `--enable-shared`. Se installi Python con [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), imposta la variabile d'ambiente `PYTHON_CONFIGURE_OPTS` su `--enable-shared` quando installi una versione di Python.
- **The libpython library in a system library directory.** Un Python installato con pyenv conserva la sua libreria libpython, ad esempio *libpython3.9.dylib*, sotto *~/.pyenv/versions*; crea un collegamento simbolico a essa in */usr/local/lib*.
- **libgdiplus**, un'implementazione dell'API grafica Windows GDI+. Homebrew lo fornisce come pacchetto `mono-libgdiplus`.

Quindi installa il pacchetto con pip.

## **Verifica l'installazione**

Per verificare l'installazione, salva il primo esempio in [Crea Presentazioni](/slides/it/python-net/create-presentation/) come *hello.py* ed esegui `python hello.py`. Salva *new_presentation.pptx* nella cartella corrente.

## **Aggiornamento**

Per aggiornare un'installazione esistente all'ultima versione, esegui questo comando nell'ambiente in cui hai installato il pacchetto:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Posso installare Aspose.Slides in un ambiente virtuale?**

Sì. Puoi installarlo in qualsiasi ambiente virtuale Python con pip. Le librerie native necessarie a Linux e macOS sono installate sul sistema, non nell'ambiente virtuale.

**Posso usare Aspose.Slides in container Docker?**

Sì. L'immagine deve includere le stesse librerie native di un sistema Linux — libgdiplus e ICU — e i caratteri usati nelle tue presentazioni.

**Esiste una versione gratuita o limitazioni di prova?**

Sì. Senza licenza, Aspose.Slides funziona in modalità di valutazione: aggiunge una filigrana di valutazione a ogni diapositiva salvata e tronca il testo letto dalle presentazioni. Per rimuovere queste limitazioni, applica una [licenza](/slides/it/python-net/licensing/) valida.