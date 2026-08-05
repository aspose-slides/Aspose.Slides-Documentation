---
title: Dodawanie podpisów cyfrowych do prezentacji w PHP
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/php-java/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PKCS#12
- zweryfikować podpis
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- PHP
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX za pomocą certyfikatów PFX oraz używać Aspose.Slides dla PHP poprzez Javę do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane pojęcia związane z bezpieczeństwem są tutaj istotne:

- **Certyfikat cyfrowy** to elektroniczny dokument poświadczający tożsamość i powiązujący ją z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, lub organizacja może używać certyfikatu samopodpisanego w ramach wewnętrznych przepływów pracy.
- **Podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Klucz publiczny certyfikatu może być użyty do weryfikacji podpisu. Podpis zapewnia dowód pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje chronione hasłem](/php-java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w sekcji **File > Info > Protect Presentation**.

![Menu Ochrony prezentacji PowerPoint z wyróżnionym Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures), które zwraca [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/) zawierającą obiekty [DigitalSignature](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zazwyczaj mający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępu do klucza prywatnego nie może być użyty do podpisywania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest **hasłem** do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej jedynie w celu uniknięcia umieszczania hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zapisanie wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość ustawiona przez [DigitalSignature::setComments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/setcomments/) opisuje cel podpisu; nie jest mechanizmem bezpieczeństwa.

## **Walidacja podpisów cyfrowych**

Po wczytaniu podpisanego pliku PPTX, sprawdź każdy element zwrócony przez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature::isValid](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/isvalid/) wskazuje, czy osadzony podpis jest ważny dla bieżącej zawartości prezentacji.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Nieprawidłowy wynik zazwyczaj oznacza, że zawartość podpisanej prezentacji lub dane podpisu uległy zmianie po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, dlatego sprawdzanie jedynie ważności elementów nie wystarcza: przepływ pracy wrażliwy na bezpieczeństwo musi również weryfikować, że oczekiwana liczba podpisów i tożsamości podpisujących są obecne.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może także potrzebować budować i weryfikować łańcuch certyfikatów X.509, sprawdzać daty ważności certyfikatu i status odwołania, potwierdzać oczekiwany podmiot lub odcisk, weryfikować użycie klucza oraz oceniać zaufany znacznik czasu. Wartość zwracana przez [DigitalSignature::getSignTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/getsigntime/) nie jest dowodem od zaufanego wystawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy przy użyciu [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/removeat/) z jego zerowym indeksem. Zapisz do nowego pliku, chyba że nadpisanie podpisanego oryginału jest wyraźną częścią twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje mogą nadal edytować plik, ale zmiany w podpisanej zawartości zazwyczaj unieważniają istniejący podpis.
- Dokończ wszystkie planowane edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zrewidowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny plik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj klucz prywatny certyfikatu jako poufny. Każdy, kto uzyska klucz prywatny i jego hasło, może tworzyć podpisy wyglądające, jakby pochodziły od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, jeśli wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowód o pochodzeniu i integralności, ale zawartość prezentacji pozostaje czytelna, chyba że zostanie zastosowane oddzielne szyfrowanie. Użyj [ochrony hasłem](/php-java/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie certyfikat samopodpisany może być użyty, jeśli zawiera dostępny klucz prywatny. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Przepływy publiczne lub międzyorganizacyjne zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji (CA).

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana zawartości podpisanej prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieprawidłowego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie sam w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w środowisku produkcyjnym powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz wszelkie wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od twojej polityki i od tego, czy ważny zaufany znacznik czasu wykazuje, że podpis został złożony, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja nadal może być edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej zawartości zazwyczaj unieważnia istniejący podpis, dlatego najpierw zakończ tworzenie prezentacji i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj wyłącznie dla formatu PPTX. Formaty PPT i OpenDocument nie są obsługiwane przez ten przepływ pracy API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.