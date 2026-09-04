---
title: Instala­ce
type: docs
weight: 70
url: /cs/python-java/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Nainstalujte Aspose.Slides pro Python přes Java na Windows, Linux nebo macOS, nakonfigurujte Java a JPype a ověřte nastavení pomocí funkčního příkladu."
---
Aspose.Slides pro Python přes Java běží na Windows, Linuxu a macOS. Používá JPype k přístupu k Java knihovně z Pythonu. Microsoft PowerPoint není vyžadován.

## **Požadavky**

Před instalací balíků Python nainstalujte Python a JDK, který splňuje [System Requirements](/slides/cs/python-java/system-requirements/). Tato stránka uvádí kompatibilní verze, požadavky na architekturu a veškeré závislosti potřebné ke kompilaci JPype ze zdrojového kódu.

Nastavte `JAVA_HOME` na adresář instalace JDK, nikoli na jeho podadresář `bin`, a přidejte adresář `bin` JDK do `PATH`. Po změně proměnných prostředí otevřete nový terminál.

## **Instalace z PyPI**

Spusťte následující příkazy v terminálu, ne v interaktivním příkazovém řádku Pythonu. Vytvořte adresář projektu a virtuální prostředí, aby byly balíky odděleny od ostatních projektů.

### **Windows**

Pokud je vámi zvolený interpret Pythonu dostupný jako `python` v `PATH`, spusťte následující příkazy v příkazovém řádku:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux a macOS**

Pokud je vámi zvolená verze Pythonu dostupná jako `python3`, spusťte následující příkazy v Bash nebo zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Na Debianu nebo Ubuntu, pokud vytvoření prostředí selže kvůli nedostupnosti `ensurepip`, nainstalujte balíček `python3-venv` pomocí `sudo apt-get install python3-venv` a poté opakujte příkaz pro vytvoření prostředí. Samostatně nainstalovaná verze Pythonu může vyžadovat odpovídající verzi‑specifický balíček `venv`.

### **Instalace balíků**

Se zapnutým virtuálním prostředím nainstalujte JPype a Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Použití `python -m pip` zajišťuje, že jsou balíky nainstalovány pro interpret, který spouští vaši aplikaci.

Pro aktualizaci existující instalace Aspose.Slides spusťte `python -m pip install --upgrade aspose-slides-java` ve stejném prostředí.

## **Instalace ze ZIP archivu**

Knihovnu můžete také použít ze [stránky ke stažení Aspose.Slides](https://releases.aspose.com/slides/cs/python-java/):

1. Nainstalujte Python a Java podle [Požadavky](#prerequisites).
2. Vytvořte a aktivujte virtuální prostředí pomocí výše uvedených instrukcí.
3. Nainstalujte JPype pomocí `python -m pip install JPype1`.
4. Stáhněte a rozbalte ZIP archiv Aspose.Slides pro Python přes Java.
5. Najděte rozbalený adresář balíčku `asposeslides`. Uchovejte jeho obsah, včetně adresáře `lib` a souboru JAR, společně.
6. Umístěte `example.py` z následující sekce vedle adresáře `asposeslides`, aby ho Python mohl importovat.

## **Ověření instalace**

Uložte následující kód do souboru `example.py`. Vytvoří prezentaci s textovým polem a uloží ji jako `out.pptx` do aktuálního pracovního adresáře.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Se zapnutým virtuálním prostředím spusťte příklad v adresáři obsahujícím `example.py`:

```sh
python example.py
```

Import `asposeslides` zaregistruje zabalenou Java knihovnu před spuštěním JVM. Importujte `asposeslides.api` po spuštění JVM a uvolněte zdroje prezentace před jeho vypnutím.

{{% alert color="info" title="Poznámka" %}}
Bez licence výstup obsahuje vodoznak pro hodnocení. Viz [Evaluate Aspose.Slides](/slides/cs/python-java/evaluate-aspose-slides/) pro omezení hodnocení a informace o dočasné licenci.
{{% /alert %}}

## **Často kladené otázky**

**Proč Python hlásí, že JVM nelze najít nebo načíst?**

Zkontrolujte, že `JAVA_HOME` ukazuje na JDK kompatibilní s vaším Python a instalací JPype, jak je popsáno v [System Requirements](/slides/cs/python-java/system-requirements/). Další kontrola je v [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html).

**Proč Python hlásí, že `asposeslides` chybí po instalaci?**

Balíček mohl být nainstalován pro jiný interpret Pythonu. Aktivujte virtuální prostředí použité při instalaci a spusťte `python -m pip show aspose-slides-java`. U ZIP instalace se ujistěte, že adresář `asposeslides` je vedle vašeho skriptu nebo je jinak dostupný v Pythonovém vyhledávacím cestě modulů.

**Mohu spouštět příklad opakovaně v notebooku?**

Příklad je určen pro samostatný proces Pythonu. Před jeho úpravou pro opakované spouštění v notebooku si přečtěte [Limitations and API Differences](/slides/cs/python-java/limitations-and-api-differences/#import-the-library) ohledně životního cyklu JVM a pokynů pro notebook.

**Proč pip selže s `CERTIFICATE_VERIFY_FAILED`?**

Pokud vaše síť používá proxy pro kontrolu HTTPS, pip musí důvěřovat jeho certifikační autoritě. Nakonfigurujte důvěryhodný balík CA pomocí pip volby `--cert` nebo proměnné prostředí `PIP_CERT`, podle [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Požadovaná konfigurace závisí na vaší síti a verzi pipu.