---
title: Licencjonowanie
type: docs
weight: 80
url: /pl/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- plik licencji
- licencja tymczasowa
- licencjonowanie metered
- ograniczenia wersji ewaluacyjnej
description: "Zastosuj licencję plikową, opartą na bajtach lub metered w Aspose.Slides for Python via Java i usuń ograniczenia wersji ewaluacyjnej z swoich aplikacji."
---
## **Przegląd**

Aspose.Slides for Python via Java może działać w trybie ewaluacyjnym lub z licencją. W trybie ewaluacyjnym dodaje pole tekstowe z znakowaniem wodnym „evaluation” do każdego slajdu każdej prezentacji, którą zapisuje, oraz przycina tekst, który Twój kod odczytuje z prezentacji. Ten artykuł wyjaśnia, jak zastosować licencję z pliku lub z bajtów oraz jak skonfigurować licencjonowanie metered.

Aby zobaczyć opcje zakupu, zobacz [Informacje o cenach](https://purchase.aspose.com/pricing/slides/family). Aby uzyskać informacje o licencjonowaniu i pytania dotyczące zakupu, zobacz [Polityki zakupowe i FAQ](https://purchase.aspose.com/policies).

Aby poznać ograniczenia wersji ewaluacyjnej i dowiedzieć się, jak uzyskać tymczasową licencję, zobacz [Ewaluacja Aspose.Slides](/slides/pl/python-java/evaluate-aspose-slides/). Tymczasową licencję stosuje się w ten sam sposób, co plik zakupionej licencji.

## **O licencji**

Plik licencji zawiera informacje takie jak nazwa produktu, liczba licencjonowanych programistów oraz data wygaśnięcia subskrypcji. Plik jest cyfrowo podpisanym XML.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie edytuj pliku licencji. Nawet dodatkowy znak nowej linii może unieważnić jego cyfrowy podpis.
{{% /alert %}}

Zastosuj licencję raz na aplikację lub proces, przed tworzeniem prezentacji lub wykonywaniem innych operacji Aspose.Slides. Do pliku licencji użyj klasy [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/). Licencjonowanie metered wykorzystuje parę kluczy publiczny i prywatny zamiast pliku licencji.

## **Zastosowanie licencji**

Poniższe przykłady zakładają, że Aspose.Slides for Python via Java oraz jego wymagania są zainstalowane. Każdy przykład jest samodzielnym skryptem, który uruchamia JVM, importuje API i stosuje licencję. W swojej aplikacji wykonuj operacje na prezentacjach po zastosowaniu licencji i wyłącz JVM dopiero po zakończeniu wszystkich działań Aspose.Slides.

### **Zastosowanie licencji z pliku**

Podaj ścieżkę do pliku licencji metodzie [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense). Zastąp `Aspose.Slides.lic` ścieżką do swojego pliku licencji.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Wykonaj operacje na prezentacji tutaj, przed zamknięciem JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Użyj dokładnej nazwy pliku, łącznie z rozszerzeniem. Na przykład, jeśli plik ma nazwę `Aspose.Slides.lic.xml`, uwzględnij `.xml` w ścieżce. Ścieżka bezwzględna eliminuje niejasności dotyczące katalogu roboczego aplikacji.

Przykład używa [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed), aby sprawdzić, czy licencja została zastosowana.

### **Zastosowanie licencji z bajtów**

Użyj [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes), gdy licencja jest dostępna jako bajty Pythona. Poniższy przykład odczytuje plik w trybie binarnym i zamyka go przed zastosowaniem licencji.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Wykonaj operacje na prezentacji tutaj, przed zamknięciem JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Pozostaw oryginalne bajty niezmienione. Nie dekoduj, nie formatuj ponownie ani w żaden inny sposób nie modyfikuj zawartości licencji przed jej zastosowaniem.

## **Zastosowanie licencji metered**

Licencjonowanie metered rozlicza Cię zgodnie z użyciem API. Po uzyskaniu licencji metered zastosuj jej klucze publiczny i prywatny metodą [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey). Zainicjuj obiekt [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) i zastosuj klucze raz przy uruchamianiu aplikacji.

Poniższy przykład odczytuje klucze ze zmiennych środowiskowych `ASPOSE_METERED_PUBLIC_KEY` i `ASPOSE_METERED_PRIVATE_KEY`. Ustaw obie zmienne przed uruchomieniem skryptu.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Wykonaj operacje na prezentacji tutaj, przed zamknięciem JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Uwaga" %}}
Licencjonowanie metered wymaga połączenia internetowego w celu weryfikacji kluczy i raportowania zużycia. Trzymaj klucz prywatny poza kodem źródłowym i logami. Zobacz [FAQ licencjonowania metered](https://purchase.aspose.com/faqs/licensing/metered) po informacje o łączności i rozliczeniach.
{{% /alert %}}

## **FAQ**

**Czy muszę zainstalować inny pakiet po zakupie licencji?**

Nie. Zastosuj licencję do tego samego pakietu, którego używałeś w trybie ewaluacyjnym.

**Czy powinienem stosować licencję dla każdej prezentacji?**

Nie. Zastosuj ją raz podczas uruchamiania aplikacji, przed tworzeniem lub wczytywaniem prezentacji.

**Czy mogę zmienić nazwę pliku licencji?**

Tak. Użyj dokładnej nowej nazwy pliku w kodzie i zachowaj niezmienioną zawartość pliku.

**Czy mogę użyć tymczasowej licencji w przykładzie opartym na bajtach?**

Tak. Odczytaj tymczasowy plik licencji jako bajty i zastosuj go w ten sam sposób, co zakupioną licencję.