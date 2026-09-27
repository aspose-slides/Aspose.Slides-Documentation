---
title: Instalacja
type: docs
weight: 70
url: /pl/python-java/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Zainstaluj Aspose.Slides for Python via Java na Windows, Linux lub macOS, skonfiguruj Javę i JPype oraz zweryfikuj konfigurację przy pomocy działającego przykładu."
---
Aspose.Slides for Python via Java działa na systemach Windows, Linux i macOS. Używa JPype do uzyskania dostępu do biblioteki Java z Pythona. Microsoft PowerPoint nie jest wymagany.

## **Wymagania wstępne**

Przed zainstalowaniem pakietów Python, zainstaluj Pythona i JDK spełniające [System Requirements](/slides/pl/python-java/system-requirements/). Ta strona wymienia kompatybilne wersje, wymagania architektoniczne oraz wszelkie zależności potrzebne do budowy JPype ze źródeł.

Ustaw `JAVA_HOME` na katalog instalacji JDK, a nie na jego podkatalog `bin`, i dodaj katalog `bin` JDK do `PATH`. Otwórz nowy terminal po zmianie zmiennych środowiskowych.

## **Instalacja z PyPI**

Uruchom poniższe polecenia w terminalu, a nie w interaktywnym promptcie Pythona. Utwórz katalog projektu oraz wirtualne środowisko, aby odizolować pakiety od innych projektów.

### **Windows**

Mając wybrany interpreter Pythona dostępny jako `python` w `PATH`, uruchom poniższe polecenia w wierszu poleceń:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux i macOS**

Mając wybraną wersję Pythona dostępną jako `python3`, uruchom poniższe polecenia w Bash lub zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

W systemach Debian lub Ubuntu, jeśli tworzenie środowiska nie powiedzie się z powodu braku `ensurepip`, zainstaluj pakiet `python3-venv` poleceniem `sudo apt-get install python3-venv`, a następnie powtórz polecenie tworzenia środowiska. Oddzielnie zainstalowana wersja Pythona może wymagać odpowiadającego jej wersji‑specyficznego pakietu `venv`.

### **Instalacja pakietów**

Mając aktywne wirtualne środowisko, zainstaluj JPype i Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Użycie `python -m pip` zapewnia, że pakiety są instalowane dla interpretera używanego do uruchomienia Twojej aplikacji.

Aby zaktualizować istniejącą instalację Aspose.Slides, uruchom `python -m pip install --upgrade aspose-slides-java` w tym samym środowisku.

## **Instalacja z archiwum ZIP**

Możesz również używać biblioteki ze [strony pobierania Aspose.Slides](https://releases.aspose.com/slides/python-java/):

1. Zainstaluj Pythona i Javę zgodnie z opisem w [Wymagania wstępne](#prerequisites).
2. Utwórz i aktywuj wirtualne środowisko, korzystając z powyższych instrukcji.
3. Zainstaluj JPype poleceniem `python -m pip install JPype1`.
4. Pobierz i rozpakuj archiwum ZIP Aspose.Slides for Python via Java.
5. Zlokalizuj rozpakowany katalog pakietu `asposeslides`. Zachowaj jego zawartość, w tym katalog `lib` i plik JAR, razem.
6. Umieść `example.py` z następnej sekcji obok katalogu `asposeslides`, aby Python mógł zaimportować pakiet. Archiwum już zawiera własny plik `example.py` obok `asposeslides`; zamień go na poniższy.

## **Weryfikacja instalacji**

Zapisz poniższy kod jako `example.py`. Tworzy on prezentację z polem tekstowym i zapisuje ją jako `out.pptx` w bieżącym katalogu roboczym.

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

Mając aktywne wirtualne środowisko, uruchom przykład z katalogu zawierającego `example.py`:

```sh
python example.py
```

Import `asposeslides` rejestruje dołączoną bibliotekę Java przed uruchomieniem JVM. Zaimportuj `asposeslides.api` po uruchomieniu JVM i zwolnij zasoby prezentacji przed jej zamknięciem.

{{% alert color="info" title="Note" %}}
Bez licencji wynik zawiera znak wodny ewaluacyjny. Zobacz [Evaluate Aspose.Slides](/slides/pl/python-java/evaluate-aspose-slides/) aby zapoznać się z ograniczeniami wersji testowej i informacjami o tymczasowej licencji.
{{% /alert %}}

## **FAQ**

**Dlaczego Python zgłasza, że JVM nie może zostać znaleziony lub załadowany?**

Sprawdź, czy `JAVA_HOME` wskazuje na JDK zgodny z Twoją instalacją Pythona i JPype, jak opisano w [System Requirements](/slides/pl/python-java/system-requirements/). Zobacz [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) po dodatkowe wskazówki.

**Dlaczego Python zgłasza, że `asposeslides` jest brakujący po instalacji?**

Pakiet mógł zostać zainstalowany dla innego interpretera Pythona. Aktywuj wirtualne środowisko użyte podczas instalacji i uruchom `python -m pip show aspose-slides-java`. W przypadku instalacji z ZIP, upewnij się, że katalog `asposeslides` znajduje się obok Twojego skryptu lub jest inaczej dostępny w ścieżce wyszukiwania modułów Pythona.

**Czy mogę uruchamiać przykład wielokrotnie w notebooku?**

Przykład jest przeznaczony do uruchomienia w samodzielnym procesie Pythona. Przed dostosowaniem go do wielokrotnego wykonywania w notebooku, zobacz [Limitations and API Differences](/slides/pl/python-java/limitations-and-api-differences/#import-the-library) w celu uzyskania informacji o cyklu życia JVM i wskazówek dotyczących notebooków.

**Dlaczego pip kończy się niepowodzeniem z `CERTIFICATE_VERIFY_FAILED`?**

Jeśli Twoja sieć używa proxy do inspekcji HTTPS, pip musi zaufać jego wystawcy certyfikatów. Skonfiguruj zaufany pakiet CA przy użyciu opcji `--cert` pip lub zmiennej środowiskowej `PIP_CERT`, postępując zgodnie z [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). Wymagana konfiguracja zależy od Twojej sieci i wersji pip.