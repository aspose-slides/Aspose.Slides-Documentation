---
title: Instalace
type: docs
weight: 70
url: /cs/python-net/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Nainstalujte Aspose.Slides pro Python via .NET z PyPI pomocí pip na Windows, Linuxu a macOS a nainstalujte nativní knihovny, které Linux a macOS vyžadují."
---
## **Přehled**

Tento článek vysvětluje, jak nainstalovat Aspose.Slides for Python via .NET na Windows, Linuxu a macOS. Balíček je publikován na [PyPI](https://pypi.org/project/aspose.slides/) a instalován pomocí pip. Obsahuje .NET runtime, který používá, takže není nutné instalovat .NET. Na Linuxu a macOS tento runtime vyžaduje nativní knihovny, které operační systém nemusí obsahovat; sekce níže je uvádí.

Aspose.Slides for Python via .NET podporuje Python 3.5 až 3.14. PyPI poskytuje balíčky pro Windows (32-bitové a 64-bitové), Linux (x86_64 a ARM64) a macOS (Intel a Apple silicon).

## **Windows**

Na Windows nainstalujte balíček pomocí pip. Žádné další knihovny nejsou vyžadovány.

```bash
pip install aspose.slides
```

## **Linux**

Na Linuxu .NET runtime zahrnutý v balíčku vyžaduje dvě knihovny:

- **libgdiplus**, implementace Windows GDI+ grafického API. Bez ní selže uložení prezentace s chybou `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Bez ní proces Python skončí při prvním volání Aspose.Slides zprávou `Couldn't find a valid ICU package installed on the system`.

Na Debianu a Ubuntu nainstalujte obě pomocí apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Název balíčku ICU obsahuje jeho verzi: `libicu76` je balíček pro Debian 13. Na Debianu 12 nainstalujte místo toho `libicu72` a na Ubuntu 24.04 `libicu74`. Pro zjištění názvu na vašem systému spusťte:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Poté nainstalujte balíček do virtuálního prostředí. V aktuálních verzích Debianu a Ubuntu systémový Python neumožňuje `pip install` mimo virtuální prostředí a ukončí se s chybou `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Spouštějte své skripty s aktivovaným stejným virtuálním prostředím. Pokud používáte Python, který vaše distribuce neříídí, například ten v oficiálních `python` Docker obrazech, můžete také spustit `pip install aspose.slides` bez virtuálního prostředí.

Písma používaná ve vašich prezentacích, nebo vhodné náhrady, musí být nainstalována v systému, aby se text při převodu snímků do PDF nebo obrázků vykresloval správně.

## **macOS**

Instalaci na macOS jsme neověřili. Na macOS Aspose.Slides vyžaduje následující předpoklady:

- **Python s sdílenými knihovnami**, tj. Python sestavený s konfigurační volbou `--enable-shared`. Pokud instalujete Python pomocí [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), nastavte proměnnou prostředí `PYTHON_CONFIGURE_OPTS` na `--enable-shared` při instalaci verze Pythonu.
- **Knihovna libpython v adresáři systémových knihoven.** Python nainstalovaný pomocí pyenv uchovává svou knihovnu libpython, např. *libpython3.9.dylib*, v *~/.pyenv/versions*; vytvořte na ni symbolický odkaz v */usr/local/lib*.
- **libgdiplus**, implementace Windows GDI+ grafického API. Homebrew poskytuje tento balíček jako `mono-libgdiplus`.

Poté nainstalujte balíček pomocí pip.

## **Kontrola instalace**

Pro kontrolu instalace uložte první příklad z [Vytvořit prezentace](/slides/cs/python-net/create-presentation/) jako *hello.py* a spusťte `python hello.py`. Uloží *new_presentation.pptx* do aktuální složky.

## **Aktualizace**

Pro aktualizaci existující instalace na nejnovější verzi spusťte tento příkaz v prostředí, kde jste balíček nainstalovali:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Mohu nainstalovat Aspose.Slides ve virtuálním prostředí?**

Ano. Můžete jej nainstalovat v libovolném virtuálním prostředí Pythonu pomocí pip. Nativní knihovny, které potřebují Linux a macOS, jsou nainstalovány v systému, nikoli ve virtuálním prostředí.

**Mohu používat Aspose.Slides v Docker kontejnerech?**

Ano. Image musí obsahovat stejné nativní knihovny jako Linuxový systém — libgdiplus a ICU — a písma, která vaše prezentace používají.

**Existuje bezplatná verze nebo omezení zkušební verze?**

Ano. Bez licence Aspose.Slides běží v evaluačním režimu: přidává evaluační vodoznak ke každému snímku, který uloží, a zkracuje text načtený z prezentací. Pro odstranění těchto omezení použijte platnou [licenci](/slides/cs/python-net/licensing/).