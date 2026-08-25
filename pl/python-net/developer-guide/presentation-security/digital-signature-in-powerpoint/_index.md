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
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX i korzystać z Aspose.Slides dla Pythona via .NET w celu weryfikacji lub usunięcia podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy ustalić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Ważne są tutaj trzy powiązane pojęcia bezpieczeństwa:

- **certyfikat cyfrowy** to elektroniczne poświadczenie łączące tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wystawić certyfikat, a organizacja może używać certyfikatu samopodpisanego w wewnętrznych procesach.
- **podpis cyfrowy** powstaje z zawartości prezentacji i prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może zostać użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest odrębna od podpisywania cyfrowego i opisana w [Prezentacje chronione hasłem](/slides/pl/python-net/password-protected-presentation/).

PowerPoint udostępnia polecenie **Dodaj podpis cyfrowy** w sekcji **Plik > Informacje > Zabezpiecz prezentację**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy przez [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/), czyli [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/) zawierającą obiekty [DigitalSignature](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle z rozszerzeniem `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. **Nie** jest to hasło do otwierania lub edytowania prezentacji. Nie umieszczaj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z bezpiecznego magazynu lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, by nie umieszczać hasła w kodzie.

## **Dodaj podpis cyfrowy do prezentacji**

Aby podpisać rzeczywistą prezentację, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz jako plik PPTX.

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

Zapis wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość [DigitalSignature.comments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/comments/) opisuje cel podpisu; nie jest ona mechanizmem bezpieczeństwa.

## **Sprawdź podpisy cyfrowe**

Podczas wczytywania podpisanego pliku PPTX, przejrzyj każdy element w [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/). Właściwość [DigitalSignature.is_valid](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/is_valid/) wskazuje, czy osadzony podpis jest ważny dla bieżącej zawartości prezentacji.

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

Nieprawidłowy wynik zazwyczaj oznacza, że zawartość prezentacji lub dane podpisu zostały zmienione po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje powstanie niepodpisanej prezentacji, więc samo sprawdzenie ważności elementów nie wystarczy: w procesach wymagających bezpieczeństwa należy także zweryfikować oczekiwaną liczbę podpisów oraz tożsamości podpisujących.

Właściwość [DigitalSignature.certificate](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/certificate/) zwraca dane certyfikatu jako tablicę bajtów. Przykład oblicza odcisk SHA‑256, aby aplikacja mogła porównać go z odciskiem oczekiwanego certyfikatu podpisującego.

Ten wynik nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może także budować i weryfikować łańcuch certyfikatów X.509, sprawdzać daty ważności i status odwołania, potwierdzać oczekiwany temat lub odcisk, weryfikować użycie klucza oraz oceniać zaufany znacznik czasu. Wartość [DigitalSignature.sign_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/sign_time/) sama w sobie nie jest dowodem pochodzącym od zaufanego dostawcy znacznika czasu.

## **Usuń podpisy cyfrowe**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy metodą [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/remove_at/) z jego indeksu zerowego. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest świadomą częścią Twojego procesu.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej zawartości zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich zamierzonych edycji przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj klucz prywatny certyfikatu jako poufny. Każdy, kto uzyska dostęp do klucza prywatnego i jego hasła, może tworzyć podpisy, które będą wyglądały, jakby pochodziły od posiadacza certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **Najczęściej zadawane pytania**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu pochodzenia i integralności, ale zawartość prezentacji pozostaje czytelna, o ile nie zostanie zastosowane oddzielne szyfrowanie. Użyj [ochrony hasłem](/slides/pl/python-net/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło do prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Tak, pod warunkiem że zawiera dostępny klucz prywatny. Odbiorcy nie będą automatycznie mu ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. W procesach publicznych lub między organizacjami zazwyczaj używa się certyfikatu wystawionego przez zaufany CA.

**Co powoduje, że podpis jest nieważny?**

Zmiana podpisanej zawartości prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku także może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieważnego podpisu.

**Czy ważny podpis oznacza, że mogę zaufać podpisującemu?**

Nie samo w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka weryfikacji produkcyjnej powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymogi dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygaśnie?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony w czasie ważności certyfikatu. Nie polegaj wyłącznie na wyświetlanej dacie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja nadal może być edytowana?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej zawartości zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ edycję, a dopiero potem podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do [Presentation.digital_signatures](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**W których formatach prezentacji dostępne są te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje podpisu cyfrowego wyłącznie dla PPTX. Format PPT oraz OpenDocument nie są wspierane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć pojedynczy podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie będzie już zawierał dowodu usuniętego podpisu.