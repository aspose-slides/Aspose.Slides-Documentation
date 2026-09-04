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
- licencjonowanie rozliczane według zużycia
- ograniczenia wersji próbnej
description: "Zastosuj licencję z pliku, na bazie bajtów lub rozliczaną według zużycia w Aspose.Slides for Python via Java i usuń ograniczenia wersji próbnej w swoich aplikacjach."
---
## **Przegląd**

Aspose.Slides for Python via Java może działać w trybie oceny lub z licencją. Ten artykuł wyjaśnia, jak zastosować licencję z pliku lub z bajtów oraz jak skonfigurować licencjonowanie rozliczane według zużycia.

W celu zapoznania się z opcjami zakupu, zobacz [Informacje o cenach](https://purchase.aspose.com/pricing/slides/pl/family). W sprawach ogólnych dotyczących licencjonowania i zakupów, zobacz [Polityki zakupu i FAQ](https://purchase.aspose.com/policies).

W celu zapoznania się z ograniczeniami wersji ewaluacyjnej i sposobem ubiegania się o tymczasową licencję, zobacz [Evaluate Aspose.Slides](/slides/pl/python-java/evaluate-aspose-slides/). Zastosuj tymczasową licencję w taki sam sposób, jak plik licencji zakupionej.

## **O licencji**

Plik licencji zawiera informacje takie jak nazwa produktu, liczba licencjonowanych programistów oraz data wygaśnięcia subskrypcji. Plik jest cyfrowo podpisanym XML.

{{% alert color="warning" title="Warning" %}}
Nie edytuj pliku licencji. Nawet dodatkowy znak końca linii może unieważnić jego cyfrowy podpis.
{{% /alert %}}

Zastosuj licencję raz na aplikację lub proces, przed tworzeniem prezentacji lub wykonywaniem innych operacji Aspose.Slides. Do pliku licencji użyj klasy [License](https://reference.aspose.com/slides/pl/python-java/aspose.slides/license/). Licencjonowanie rozliczane według zużycia wykorzystuje parę kluczy publicznego i prywatnego zamiast pliku licencji.

## **Zastosowanie licencji**

Poniższe przykłady zakładają, że Aspose.Slides for Python via Java oraz jego zależności są zainstalowane. Każdy przykład jest samodzielnym skryptem, który uruchamia JVM, importuje API i stosuje licencję. W swojej aplikacji wykonuj operacje na prezentacjach po zastosowaniu licencji i zamykaj JVM dopiero po zakończeniu wszelkich działań Aspose.Slides.

### **Zastosowanie licencji z pliku**

Przekaż ścieżkę do pliku licencji metodzie [License.setLicense](https://reference.aspose.com/slides/pl/python-java/aspose.slides/license/#setLicense). Zastąp `Aspose.Slides.lic` ścieżką do swojego pliku licencji.

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

Użyj dokładnej nazwy pliku, łącznie z rozszerzeniem. Na przykład, jeśli plik ma nazwę `Aspose.Slides.lic.xml`, uwzględnij `.xml` w ścieżce. Ścieżka bezwzględna eliminuje niejasności dotyczące bieżącego katalogu aplikacji.

Przykład używa [License.isLicensed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/license/#isLicensed) do sprawdzenia, czy licencja została zastosowana.

### **Zastosowanie licencji z bajtów**

Użyj [License.setLicenseFromBytes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/license/#setLicenseFromBytes), gdy licencja jest dostępna jako bajty w Pythonie. Poniższy przykład odczytuje plik w trybie binarnym i zamyka go przed zastosowaniem licencji.

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
        # Wykonaj operacje na prezentacji tutaj, przed wyłączeniem JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Zachowaj oryginalne bajty niezmienione. Nie dekoduj, nie formatowuj ponownie ani nie modyfikuj treści licencji przed jej zastosowaniem.

## **Zastosowanie licencji rozliczanej według zużycia**

Licencjonowanie rozliczane według zużycia rozlicza Cię zgodnie z wykorzystaniem API. Po uzyskaniu licencji rozliczanej, zastosuj jej klucze publiczny i prywatny przy pomocy [Metered.setMeteredKey](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/#setMeteredKey). Zainicjalizuj obiekt [Metered](https://reference.aspose.com/slides/pl/python-java/aspose.slides/metered/) i zastosuj klucze raz przy uruchamianiu aplikacji.

Poniższy przykład odczytuje klucze z zmiennych środowiskowych `ASPOSE_METERED_PUBLIC_KEY` i `ASPOSE_METERED_PRIVATE_KEY`. Ustaw obie zmienne przed uruchomieniem skryptu.

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
        # Wykonaj operacje na prezentacji tutaj, przed wyłączeniem JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Licencjonowanie rozliczane wymaga połączenia internetowego w celu weryfikacji kluczy i raportowania zużycia. Przechowuj klucz prywatny poza kodem źródłowym i logami. Zobacz [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) po szczegóły dotyczące łączności i rozliczeń.
{{% /alert %}}

## **FAQ**

**Czy muszę zainstalować inny pakiet po zakupie licencji?**

Nie. Zastosuj licencję do tego samego pakietu, którego używałeś w trybie oceny.

**Czy powinienem stosować licencję dla każdej prezentacji?**

Nie. Zastosuj ją raz przy uruchamianiu aplikacji, przed tworzeniem lub ładowaniem prezentacji.

**Czy mogę zmienić nazwę pliku licencji?**

Tak. Użyj dokładnie nowej nazwy pliku w kodzie i nie zmieniaj zawartości pliku.

**Czy mogę użyć tymczasowej licencji w przykładzie opartym na bajtach?**

Tak. Odczytaj tymczasowy plik licencji jako bajty i zastosuj go w taki sam sposób, jak licencję zakupioną.