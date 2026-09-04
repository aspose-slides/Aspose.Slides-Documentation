---
title: Zabezpieczanie prezentacji hasłem w Pythonie
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
- sprawdzanie hasła prezentacji
- otwieranie zaszyfrowanej prezentacji
- usuwanie szyfrowania
- PowerPoint
- PPT
- PPTX
- prezentacja
- Python
- Aspose.Slides
description: "Szyfruj, wykrywaj, waliduj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w języku Python przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, dlatego ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza możliwość modyfikacji, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami służącymi do modyfikacji prezentacji, zobacz [Write-Protect Presentations](/slides/pl/python-net/write-protected-presentation/).

Poniższe przepływy pracy mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy istotne jest ich zachowanie w trybie opartym na pliku i strumieniu.

## **Zaszyfruj prezentację przy użyciu hasła otwierającego**

Użyj [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/encrypt/), aby przypisać hasło otwierające. Następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Utrzymaj właściwości dokumentu jako publiczne**

Domyślnie Aspose.Slides włącza właściwości dokumentu do szyfrowania prezentacji. Właściwość [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) kontroluje to zachowanie niezależnie od szyfrowania zawartości slajdów. Ustaw ją na `False` przed wywołaniem [ProtectionManager.encrypt](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/encrypt/), gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytywać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając jej wbudowane właściwości dokumentu jako publiczne:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Ustawienie `encrypt_document_properties` na `False` nie powoduje, że slajdy, wzorce, układy, kształty, multimedia ani inna zawartość prezentacji stają się publiczne. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej zawartości, zobacz [Manage Presentation Properties](/slides/pl/python-net/presentation-properties/).

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/) na hasło otwierające i przekaż te opcje do [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powiedzie się, gdy wymagane jest hasło otwierające, ale podane hasło jest brakujące lub nieprawidłowe.
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Pracuj z odszyfrowaną prezentacją.
    pass
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację przy użyciu hasła otwierającego, wywołaj [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/remove_encryption/) i zapisz wynik. Zapisana prezentacja może być następnie ładowana bez hasła.
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zweryfikuj hasło otwierające przed ładowaniem**

Użyj [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/is_password_protected/) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [PresentationInfo.check_password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_password/).

### **Workflow przy ścieżce pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/), a następnie ładuje pełną prezentację:
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

### **Workflow strumieniowy**

Przeciążenie strumieniowe [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationfactory/get_presentation_info/) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentationinfo/check_password/) zwraca `True` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest prawidłowe. Zwraca `False` w każdym z następujących przypadków:
- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `None` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu poprawnego hasła, sprawdź [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/pl/python-net/aspose.slides/protectionmanager/is_encrypted/), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj `PresentationInfo.is_password_protected` jak pokazano powyżej.
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Zalecenia dotyczące bezpieczeństwa**

{{% alert color="warning" title="Security" %}}
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, oraz ponownie użyj wyniku pomyślnej weryfikacji przy natychmiastowym ładowaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, nawet jeśli zawartość prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane razem z prezentacją. Pozostawienie właściwości publicznych powinno być świadomą decyzją podjętą wyłącznie wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło chroniące widok.
4. Opcjonalnie wprowadź oddzielne hasło chroniące edycję.
5. Zastosuj ochronę i pobierz wynikowy plik.

{{% alert color="info" title="Zobacz też" %}}
- [Write-Protect Presentations](/slides/pl/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza możliwość modyfikacji bez szyfrowania zawartości.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z ustawieniem `encrypt_document_properties` równym `False`. Aplikacja musi wtedy użyć trybu ładowania wyłącznie właściwości dokumentu opisanego w [Manage Presentation Properties](/slides/pl/python-net/presentation-properties/).

**Czy przepływy weryfikacji haseł obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja haseł oparte na ścieżce pliku oraz na strumieniu zachowują się tak samo dla prezentacji PPT i PPTX.