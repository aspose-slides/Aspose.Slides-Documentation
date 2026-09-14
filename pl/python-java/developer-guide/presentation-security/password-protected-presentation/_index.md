---
title: Zabezpiecz prezentacje hasłem w języku Python
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/python-java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfrowanie PowerPoint
- odszyfrowywanie PowerPoint
- walidacja hasła prezentacji
- sprawdzanie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- Python
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem za pomocą Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do wczytania i wyświetlenia treści prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje treści ani nie uniemożliwia wczytania prezentacji. Aby zarządzać hasłami do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/python-java/write-protected-presentation/).

Poniższe przepływy pracy dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy ich zachowanie oparte na pliku i strumieniu jest istotne.

## **Zaszyfruj prezentację za pomocą hasła otwierającego**

Użyj [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#encrypt), aby przypisać hasło otwierające. Następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zachowaj publiczne właściwości dokumentu**

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Metoda [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) kontroluje to zachowanie niezależnie od szyfrowania treści slajdów. Przekaż `False` przed wywołaniem [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#encrypt), gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając jej wbudowane właściwości dokumentu publiczne:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przekazanie `False` do [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) nie sprawia, że slajdy, wzorce, układy, kształty, multimedia ani inne treści prezentacji stają się publiczne. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej treści, zobacz [Manage Presentation Properties](/slides/pl/python-java/presentation-properties/).

## **Wczytaj zaszyfrowaną prezentację**

Ustaw [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) podczas wczytywania pliku. Wczytanie nie powiedzie się, gdy wymagane jest hasło otwierające, a podane hasło jest brakujące lub nieprawidłowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Pracuj z odszyfrowaną prezentacją.
    pass
finally:
    presentation.dispose()
```

## **Usuń szyfrowanie z prezentacji**

Wczytaj prezentację z jej hasłem otwierającym, wywołaj [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#removeEncryption), a następnie zapisz wynik. Zapisana prezentacja może być później wczytana bez hasła.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sprawdź hasło otwierające przed wczytaniem**

Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#isPasswordProtected) przed żądaniem lub walidacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Przepływ pracy z ścieżką pliku**

Poniższy przykład sprawdza hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword) i następnie wczytuje pełną prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia o możliwościach przeszukiwania przed wczytaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Wartości zwracane przez checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#checkPassword) zwraca `True` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `False` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `None` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy wczytana prezentacja jest zaszyfrowana**

Po wczytaniu prezentacji z prawidłowym hasłem sprawdź [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/pl/python-java/aspose.slides/protectionmanager/#isEncrypted), aby potwierdzić, że źródłowa prezentacja była szyfrowana. Aby wykryć ochronę hasłem otwierającym przed wczytaniem, użyj [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationinfo/#isPasswordProtected) jak opisano powyżej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie zapisuj haseł otwierających w logach ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzanych prób walidacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, i ponownie użyj wyniku udanej walidacji przy natychmiastowym wczytywaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać imiona i nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, mimo że treść prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą wyłącznie wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło ochrony wyświetlania.
4. Opcjonalnie wprowadź odrębne hasło ochrony edycji.
5. Zastosuj ochronę i pobierz wynikowy plik.

{{% alert color="info" title="See also" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/python-java/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Najczęściej zadawane pytania**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do wczytania jej treści. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania treści.

**Czy mogę zweryfikować hasło otwierające bez wczytywania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z wyłączonym szyfrowaniem właściwości dokumentu. Aplikacja musi wtedy użyć trybu wczytywania tylko właściwości dokumentu opisanego w [Manage Presentation Properties](/slides/pl/python-java/presentation-properties/).

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu działają tak samo dla prezentacji PPT i PPTX.