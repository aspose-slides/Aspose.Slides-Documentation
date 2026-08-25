---
title: Dodaj podpisy cyfrowe do prezentacji w PHP
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
- weryfikacja podpisu
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- PHP
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz korzystać z Aspose.Slides dla PHP przez Java, aby weryfikować lub usuwać podpisy cyfrowe."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane koncepcje bezpieczeństwa są tutaj istotne:

- **Certyfikat cyfrowy** to elektroniczne poświadczenie, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **Podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może następnie zostać użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest ona odrębna od podpisywania cyfrowego i jest opisana w [Prezentacje chronione hasłem](/slides/pl/php-java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Dodaj podpis cyfrowy** w sekcji **Plik > Informacje > Ochrona prezentacji**.

![Menu Ochrona prezentacji w PowerPoint z podświetnioną opcją Dodaj podpis cyfrowy](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures), który zwraca [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/) którego elementy są reprezentowane przez obiekty [DigitalSignature](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zazwyczaj oznaczany rozszerzeniem `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. Nie jest ono **hasłem** do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej jedynie w celu uniknięcia osadzania hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz jako plik PPTX.

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

Po wczytaniu podpisanego pliku PPTX, sprawdź każdy element zwrócony przez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures). Metoda [DigitalSignature::isValid](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/isvalid/) wskazuje, czy wbudowany podpis jest prawidłowy dla bieżącej zawartości prezentacji.

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

Nieprawidłowy wynik zwykle oznacza, że zawartość podpisanej prezentacji lub dane podpisu zmieniły się po podpisaniu, lub plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzanie jedynie ważności elementów nie wystarczy: wrażliwy na bezpieczeństwo przepływ pracy musi również zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może również potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności i status odwołania certyfikatu, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Wartość [DigitalSignature::getSignTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignature/getsigntime/) sama w sobie nie jest dowodem od zaufanego organu znaczników czasu.

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

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/removeat/) z jego indeksem zerowym. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźną częścią twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja staje się tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej zawartości zazwyczaj unieważniają istniejący podpis.
- Wykonaj wszystkie planowane edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu dla pliku przekonwertowanego.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto uzyska prywatny klucz i jego hasło, może tworzyć podpisy wyglądające, jakby pochodziły od tego posiadacza certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale zawartość prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/slides/pl/php-java/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest tym samym co hasło prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie, certyfikat samopodpisany może być użyty, jeśli zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie explicite dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji (CA).

**Co sprawia, że podpis jest nieprawidłowy?**

Zmiana podpisanej zawartości prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku może również spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieprawidłowego podpisu.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**

Nie sam w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka weryfikacji w środowisku produkcyjnym powinna również sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz wymogi dotyczące zaufanych znaczników czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygasanie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od twojej polityki oraz od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlonym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być dalej edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej zawartości zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ prezentację i podpisz finalną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDigitalSignatures) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Które formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje podpisu cyfrowego wyłącznie dla formatu PPTX. Format PPT oraz formaty prezentacji OpenDocument nie są obsługiwane w tym przepływie pracy API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodów usuniętego podpisu.