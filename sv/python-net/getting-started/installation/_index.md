---
title: Installation
type: docs
weight: 70
url: /sv/python-net/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Installera Aspose.Slides för Python via .NET från PyPI med pip på Windows, Linux och macOS, och installera de inhemska biblioteken som Linux och macOS behöver."
---
## **Översikt**

Denna artikel förklarar hur man installerar Aspose.Slides för Python via .NET på Windows, Linux och macOS. Paketet publiceras på [PyPI](https://pypi.org/project/aspose.slides/) och installeras med pip. Det inkluderar .NET‑runtime som det använder, så du behöver inte installera .NET. På Linux och macOS kräver den runtime inhemska bibliotek som operativsystemet kanske inte innehåller; avsnitten nedan namnger dem.

Aspose.Slides för Python via .NET stöder Python 3.5 till 3.14. PyPI tillhandahåller paket för Windows (32‑bit och 64‑bit), Linux (x86_64 och ARM64) och macOS (Intel och Apple silicon).

## **Windows**

På Windows installerar du paketet med pip. Inga andra bibliotek krävs.

```bash
pip install aspose.slides
```

## **Linux**

På Linux kräver .NET‑runtime som ingår i paketet två bibliotek:

- **libgdiplus**, en implementering av Windows GDI+‑grafik‑API:et. Utan det misslyckas sparandet av en presentation med felmeddelandet `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Utan det avslutas Python‑processen vid första Aspose.Slides‑anropet med meddelandet `Couldn't find a valid ICU package installed on the system`.

På Debian och Ubuntu installerar du båda med apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Namnet på ICU‑paketet innehåller dess version: `libicu76` är paketet för Debian 13. På Debian 12 installerar du `libicu72` istället, och på Ubuntu 24.04 `libicu74`. För att hitta namnet på ditt system, kör:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Installera sedan paketet i en virtuell miljö. På aktuella Debian‑ och Ubuntu‑utgåvor tillåter system‑Python inte `pip install` utanför en virtuell miljö och stoppar med felet `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Kör dina skript med samma virtuella miljö aktiverad. Om du använder en Python som din distribution inte hanterar, exempelvis den i de officiella `python`‑Docker‑bilderna, kan du också köra `pip install aspose.slides` utan en virtuell miljö.

Teckensnitten som används i dina presentationer, eller lämpliga ersättningar, måste vara installerade på systemet för att text ska renderas korrekt när du konverterar bilder till PDF eller bilder.

## **macOS**

Vi har inte verifierat installationen på macOS. På macOS kräver Aspose.Slides följande förutsättningar:

- **Python med delade bibliotek**, dvs. Python byggd med konfigurationsalternativet `--enable-shared`. Om du installerar Python med [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) sätter du miljövariabeln `PYTHON_CONFIGURE_OPTS` till `--enable-shared` när du installerar en Python‑version.
- **libpython‑biblioteket i en systembibliotekskatalog.** En Python installerad med pyenv behåller sitt libpython‑bibliotek, t.ex. *libpython3.9.dylib*, under *~/.pyenv/versions*; skapa en symbolisk länk till det i */usr/local/lib*.
- **libgdiplus**, en implementering av Windows GDI+‑grafik‑API:et. Homebrew tillhandahåller det som paketet `mono-libgdiplus`.

Installera sedan paketet med pip.

## **Kontrollera installationen**

För att kontrollera installationen, spara det första exemplet i [Create Presentations](/slides/sv/python-net/create-presentation/) som *hello.py* och kör `python hello.py`. Det sparar *new_presentation.pptx* i den aktuella mappen.

## **Uppgradera**

För att uppgradera en befintlig installation till den senaste versionen, kör följande kommando i den miljö där du installerade paketet:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Kan jag installera Aspose.Slides i en virtuell miljö?**

Ja. Du kan installera det i vilken Python‑virtuell miljö som helst med pip. De inhemska biblioteken som Linux och macOS behöver är installerade på systemet, inte i den virtuella miljön.

**Kan jag använda Aspose.Slides i Docker‑behållare?**

Ja. Bilden måste innehålla samma inhemska bibliotek som ett Linux‑system — libgdiplus och ICU — samt de teckensnitt som dina presentationer använder.

**Finns det en gratis version eller begränsning i utvärderingsläget?**

Ja. Utan licens kör Aspose.Slides i utvärderingsläge: det lägger till ett utvärderingsvattenmärke på varje bild den sparar och trunkerar text som läses från presentationer. För att ta bort dessa begränsningar, tillämpa en giltig [license](/slides/sv/python-net/licensing/).