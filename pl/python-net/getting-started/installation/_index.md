---
title: Instalacja
type: docs
weight: 70
url: /pl/python-net/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Zainstaluj Aspose.Slides dla Pythona via .NET z PyPI przy użyciu pip w systemach Windows, Linux i macOS oraz zainstaluj natywne biblioteki potrzebne w systemach Linux i macOS."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować Aspose.Slides dla Pythona via .NET w systemach Windows, Linux i macOS. Pakiet jest publikowany na [PyPI](https://pypi.org/project/aspose.slides/) i instalowany przy użyciu pip. Zawiera on środowisko uruchomieniowe .NET, więc nie trzeba instalować .NET osobno. W systemach Linux i macOS to środowisko wymaga natywnych bibliotek, które mogą nie być dołączone do systemu operacyjnego; sekcje poniżej podają ich nazwy.

Aspose.Slides dla Pythona via .NET obsługuje Pythona w wersjach od 3.5 do 3.14. PyPI udostępnia pakiety dla Windows (32‑bit i 64‑bit), Linux (x86_64 i ARM64) oraz macOS (Intel i Apple silicon).

## **Windows**

W systemie Windows zainstaluj pakiet przy pomocy pip. Nie są wymagane żadne dodatkowe biblioteki.

```bash
pip install aspose.slides
```

## **Linux**

W systemie Linux środowisko uruchomieniowe .NET zawarte w pakiecie wymaga dwóch bibliotek:

- **libgdiplus**, implementacji interfejsu graficznego Windows GDI+. Bez niej zapis prezentacji kończy się błędem `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Bez niej proces Pythona kończy się przy pierwszym wywołaniu Aspose.Slides komunikatem `Couldn't find a valid ICU package installed on the system`.

W systemach Debian i Ubuntu zainstaluj obie biblioteki poleceniem apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Nazwa pakietu ICU zawiera jego wersję: `libicu76` jest pakietem dla Debiana 13. W Debianie 12 zainstaluj `libicu72`, a w Ubuntu 24.04 – `libicu74`. Aby znaleźć nazwę na swoim systemie, uruchom:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Następnie zainstaluj pakiet w środowisku wirtualnym. W aktualnych wydaniach Debiana i Ubuntu systemowy Python nie zezwala na `pip install` poza środowiskiem wirtualnym i zatrzymuje się z błędem `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Uruchamiaj skrypty w aktywowanym środowisku wirtualnym. Jeśli używasz Pythona, którego twoja dystrybucja nie zarządza (np. w oficjalnych obrazach Docker `python`), możesz również wykonać `pip install aspose.slides` bez środowiska wirtualnego.

Czcionki używane w prezentacjach lub ich odpowiedniki muszą być zainstalowane w systemie, aby tekst renderował się prawidłowo przy konwersji slajdów do PDF lub obrazów.

## **macOS**

Instalację w macOS nie zweryfikowaliśmy. W macOS Aspose.Slides wymaga następujących zależności:

- **Python z bibliotekami współdzielonymi**, czyli Python skompilowany z opcją konfiguracyjną `--enable-shared`. Jeśli instalujesz Pythona przy pomocy [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), ustaw zmienną środowiskową `PYTHON_CONFIGURE_OPTS` na `--enable-shared` podczas instalacji wersji Pythona.
- **Biblioteka libpython w katalogu systemowych bibliotek**. Python zainstalowany przez pyenv zachowuje swoją bibliotekę libpython, np. *libpython3.9.dylib*, w *~/.pyenv/versions*; utwórz do niej dowiązanie symboliczne w */usr/local/lib*.
- **libgdiplus**, implementacja interfejsu graficznego Windows GDI+. Homebrew dostarcza ją w pakiecie `mono-libgdiplus`.

Następnie zainstaluj pakiet przy pomocy pip.

## **Sprawdź instalację**

Aby sprawdzić instalację, zapisz pierwszy przykład z [Create Presentations](/slides/pl/python-net/create-presentation/) jako *hello.py* i uruchom `python hello.py`. Skrypt zapisze *new_presentation.pptx* w bieżącym folderze.

## **Uaktualnienie**

Aby uaktualnić istniejącą instalację do najnowszej wersji, uruchom następujące polecenie w środowisku, w którym zainstalowano pakiet:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Czy mogę zainstalować Aspose.Slides w środowisku wirtualnym?**

Tak. Możesz zainstalować go w dowolnym wirtualnym środowisku Pythona przy użyciu pip. Natychmiastowe biblioteki potrzebne w Linux i macOS są instalowane w systemie, a nie w środowisku wirtualnym.

**Czy mogę używać Aspose.Slides w kontenerach Docker?**

Tak. Obraz musi zawierać te same natywne biblioteki co system Linux – libgdiplus i ICU – oraz czcionki wykorzystywane w twoich prezentacjach.

**Czy istnieje wersja darmowa lub ograniczenia wersji próbnej?**

Tak. Bez licencji Aspose.Slides działa w trybie ewaluacyjnym: dodaje znak wodny „evaluation” do każdego zapisanego slajdu i przycina tekst odczytany z prezentacji. Aby usunąć te ograniczenia, zastosuj ważną [license](/slides/pl/python-net/licensing/).