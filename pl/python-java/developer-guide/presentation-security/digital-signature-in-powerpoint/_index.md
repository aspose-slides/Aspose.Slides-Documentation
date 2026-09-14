---
title: Dodaj podpisy cyfrowe do prezentacji w Pythonie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/python-java/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PKCS#12
- walidacja podpisu
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Python
- Aspose.Slides
description: "Dowiedz się, jak podpisać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz korzystać z Aspose.Slides dla Pythona przez Javę, aby zweryfikować lub usunąć podpisy cyfrowe."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Ważne są tutaj trzy powiązane pojęcia bezpieczeństwa:

- **certyfikat cyfrowy** to elektroniczny dokument, który łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wystawić certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może następnie służyć do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest oddzielna od podpisu cyfrowego i opisana w [Password-Protected Presentations](/slides/pl/python-java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu Ochrona prezentacji w programie PowerPoint z podświetnioną opcją Dodaj podpis cyfrowy](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie w programie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDigitalSignatures), które zwraca [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignaturecollection/) zawierającą elementy typu [DigitalSignature](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i najczęściej z rozszerzeniem `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępnego prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby nie umieszczać hasła w kodzie.

## **Dodawanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, załaduj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Zapis wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość ustawiona przez [DigitalSignature.setComments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignature/#setComments) opisuje cel podpisu; nie jest to mechanizm zabezpieczający.

## **Weryfikacja podpisów cyfrowych**

Po załadowaniu podpisanego pliku PPTX przejrzyj każdy element zwrócony przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignature/#isValid) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej zawartości prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Wynik nieprawidłowy zazwyczaj oznacza, że zawartość prezentacji lub dane podpisu uległy zmianie po podpisaniu, albo że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje, że prezentacja jest niepodpisana, więc sprawdzenie jedynie poprawności elementów nie wystarczy: wrażliwy przepływ pracy musi także zweryfikować, czy obecna jest oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa aplikacja może również potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności i status unieważnienia, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Wartość zwracana przez [DigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignature/#getSignTime) sama w sobie nie jest dowodem pochodzącym od zaufanego urzędu czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład ładuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignaturecollection/#clear) i zapisuje niepodpisaną kopię.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/digitalsignaturecollection/#removeAt) z jego zerowym indeksem. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźnym elementem Twojego przepływu pracy.

## **Kwestie edycji i formatowania**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej zawartości zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich planowanych edycji przed podpisaniem. Jeśli prezentację trzeba zmienić, zapisz zmodyfikowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny plik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi pierwotnego podpisu PPTX jako prawidłowego podpisu w przetworzonym pliku.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto uzyska dostęp do prywatnego klucza i jego hasła, może tworzyć podpisy wyglądające na pochodzące od właściciela tego certyfikatu.
- Przechowuj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu pochodzenia i integralności, ale zawartość prezentacji pozostaje czytelna, o ile nie zostanie zastosowane oddzielne szyfrowanie. Użyj [password protection](/slides/pl/python-java/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Technicznie tak, pod warunkiem że zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie jawnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj korzystają z certyfikatu wydanego przez zaufany CA.

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana podpisanej zawartości prezentacji lub danych podpisu po podpisaniu unieważnia podpis. Uszkodzenie pliku również może spowodować niepowodzenie walidacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieprawidłowego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie sam w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w produkcji powinna także sprawdzać łańcuch certyfikatów, okres ważności, status unieważnienia, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymogi dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygaśnie?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od polityki i od tego, czy istnieje ważny zaufany znacznik czasu potwierdzający, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlonym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisaną prezentację można nadal edytować?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej zawartości zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ edycję, a następnie podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getDigitalSignatures) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje podpisu cyfrowego wyłącznie dla formatu PPTX. Format PPT oraz OpenDocument nie są obsługiwane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.