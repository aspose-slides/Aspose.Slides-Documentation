---
title: Prezentacje zabezpieczone hasłem w Pythonie
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/python-net/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- walidacja hasła prezentacji
- sprawdzenie hasła prezentacji
- otwarcie zaszyfrowanej prezentacji
- usunięcie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- Python
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w Pythonie przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, dzięki czemu ochrona zapewnia poufność.

Hasło otwierające różni się od hasła zabezpieczającego przed zapisem. Zabezpieczenie przed zapisem ogranicza modyfikację, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/python-net/write-protected-presentation/).

Poniższe scenariusze dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie w trybie plikowym i strumieniowym.

## **Zaszyfruj prezentację hasłem otwierającym**

Użyj [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/encrypt/) aby przypisać hasło otwierające. Następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) aby zapisać zaszyfrowaną prezentację.

Przykład poniżej szyfruje prezentację PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) przy ładowaniu pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Pracuj z odszyfrowaną prezentacją.
    pass
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację przy użyciu jej hasła otwierającego, wywołaj [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/remove_encryption/), a następnie zapisz wynik. Zapisana prezentacja może być później ładowana bez hasła.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Waliduj hasło otwierające przed załadowaniem**

Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) , aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/is_password_protected/) przed żądaniem lub walidacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [PresentationInfo.check_password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_password/).

Poniższy przykład waliduje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/), a następnie ładuje pełną prezentację:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Workflow z ścieżką pliku**

Przeciążenie strumieniowe [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia, który można przewijać, przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Wartości zwracane przez CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_password/) zwraca `True` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest poprawne. Zwraca `False` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `None` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu poprawnego hasła sprawdź [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/is_encrypted/) , aby potwierdzić, że źródłowa prezentacja została zaszyfrowana. Aby wykryć zabezpieczenie hasłem otwierającym przed ładowaniem, użyj `PresentationInfo.is_password_protected`, jak pokazano powyżej.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie loguj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne, i ponownie użyj udanego wyniku walidacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło zabezpieczające podgląd.
1. Opcjonalnie wprowadź oddzielne hasło zabezpieczające edycję.
1. Zastosuj ochronę i pobierz wygenerowany plik.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/pl/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem zabezpieczającym przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło zabezpieczające przed zapisem ogranicza modyfikację bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Pobierz informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy scenariusze sprawdzania hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i walidacja hasła zarówno w trybie plikowym, jak i strumieniowym działa tak samo dla prezentacji PPT i PPTX.