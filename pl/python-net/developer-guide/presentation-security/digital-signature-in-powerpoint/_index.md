---
title: Dodawanie podpisów cyfrowych do prezentacji w Pythonie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/python-net/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PKCS#12
- weryfikacja podpisu
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Python
- Aspose.Slides
description: "Dowiedz się, jak podpisać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz wykorzystać Aspose.Slides dla Pythona przez .NET do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** jest elektronicznym poświadczeniem, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego do wewnętrznych przepływów pracy.
- **podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub zmodyfikować prezentację. Jest to oddzielne od podpisywania cyfrowego i opisano w [Prezentacje chronione hasłem](/python-net/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation z podświetnionym poleceniem Add a Digital Signature](add-digital-signature-in-powerpoint.png)

![Powiadomienie PowerPoint informujące, że prezentacja zawiera ważne podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/), [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/) zawierający elementy typu [DigitalSignature](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zazwyczaj mający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest to **hasło** do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie w celu uniknięcia umieszczania hasła w kodzie.

## **Dodawanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy z prezentacją, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Zapisanie wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość [DigitalSignature.comments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/comments/) opisuje cel podpisu; nie jest to mechanizm zabezpieczający.

## **Walidacja podpisów cyfrowych**

Kiedy wczytujesz podpisany plik PPTX, sprawdź każdy element w [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/). Właściwość [DigitalSignature.is_valid](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/is_valid/) wskazuje, czy osadzony podpis jest ważny dla bieżącej zawartości prezentacji.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Nieprawidłowy wynik zazwyczaj oznacza, że treść podpisanej prezentacji lub dane podpisu zmieniły się po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje niepodpisaną prezentację, więc sprawdzenie jedynie ważności elementów nie wystarcza: przepływ pracy wrażliwy na bezpieczeństwo musi także zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Właściwość [DigitalSignature.certificate](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/certificate/) dostarcza dane certyfikatu jako tablicę bajtów. Przykład oblicza jej odcisk SHA‑256, aby aplikacja mogła porównać go z odciskiem oczekiwanego certyfikatu podpisującego.

Ten wynik ważności nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może również wymagać budowy i weryfikacji łańcucha certyfikatów X.509, sprawdzenia dat ważności i statusu unieważnienia certyfikatu, potwierdzenia oczekiwanego podmiotu lub odcisku, weryfikacji użycia klucza oraz oceny zaufanego znacznika czasu. Wartość [DigitalSignature.sign_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/sign_time/) sama w sobie nie jest dowodem od zaufanego urzędu znakowania czasem.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy przy pomocy [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/remove_at/) z jego indeksem zerowym. Zapisz do nowego pliku, chyba że nadpisanie podpisanego oryginału jest wyraźną częścią Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatów**

- Podpis nie sprawia, że prezentacja staje się tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Wykonaj wszystkie zamierzone edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zrewidowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w pliku po konwersji.
- Traktuj prywatny klucz certyfikatu jako poufny. Każdy, kto zdobędzie prywatny klucz i jego hasło, może tworzyć podpisy wyglądające, jakby pochodziły od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/python-net/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie certyfikat samopodpisany może być użyty, gdy zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat został wyraźnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji (CA).

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku może również spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plik zawierający nieprawidłowy podpis.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie samo w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w środowisku produkcyjnym powinna także sprawdzać łańcuch certyfikatów, okres ważności, status unieważnienia, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. To, czy podpis pozostaje akceptowalny, zależy od Twojej polityki oraz od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być dalej edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ prezentację i podpisz finalną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj wyłącznie dla formatu PPTX. Formaty PPT i OpenDocument nie są obsługiwane w tym przepływie API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.