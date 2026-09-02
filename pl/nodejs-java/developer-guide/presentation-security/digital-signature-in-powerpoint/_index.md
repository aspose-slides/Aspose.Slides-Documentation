---
title: Dodawanie podpisów cyfrowych do prezentacji w JavaScript
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX i korzystać z Aspose.Slides dla Node.js w Javie, aby weryfikować lub usuwać podpisy cyfrowe."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **Cyfrowy certyfikat** to elektroniczne poświadczenie, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **Podpis cyfrowy** jest tworzony na podstawie zawartości prezentacji i prywatnego klucza posiadacza certyfikatu. Klucz publiczny certyfikatu może następnie służyć do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub zmodyfikować prezentację. Jest ona oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje chronione hasłem](/slides/pl/nodejs-java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu ochrony prezentacji w PowerPoint z podświetnioną opcją Dodaj podpis cyfrowy](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o statusie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera ważne podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), które zwraca [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/) zawierającą obiekty [DigitalSignature](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle z rozszerzeniem `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz pozwala posiadaczowi utworzyć podpis. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisywania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło ze sklepu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby nie osadzać hasła w kodzie.

## **Dodawanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapis wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość ustawiona przez [DigitalSignature.setComments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) opisuje cel podpisu; nie jest to kontrola bezpieczeństwa.

## **Weryfikacja podpisów cyfrowych**

Po wczytaniu podpisanego pliku PPTX, sprawdź każdy element zwrócony przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) wskazuje, czy osadzony podpis jest ważny dla bieżącej zawartości prezentacji.

Poniższy przykład używa również klasy Node.js `X509Certificate`, aby odczytać nazwę podmiotu z każdego osadzonego certyfikatu.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Nieprawidłowy wynik zazwyczaj oznacza, że zawartość podpisanej prezentacji lub dane podpisu zostały zmienione po podpisaniu, albo że plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzanie jedynie ważności elementów nie wystarczy: wrażliwy przepływ pracy musi również zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa aplikacja może także potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności i status unieważnienia certyfikatu, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Sama wartość [DigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) nie jest dowodem pochodzącym od zaufanego urzędu znaczników czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy metodą [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) z jego indeksu zerowego. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźną częścią twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja staje się tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Wykonaj wszystkie zamierzone edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto zdobędzie prywatny klucz i jego hasło, może tworzyć podpisy, które wydają się pochodzić od tego posiadacza certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy polityka przechowywania dokumentów tego wymaga.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu pochodzenia i integralności, ale zawartość prezentacji pozostaje czytelna, chyba że zastosowano odrębne szyfrowanie. Użyj [Prezentacje chronione hasłem](/slides/pl/nodejs-java/password-protected-presentation/) gdy dostęp do treści ma być ograniczony.

**Czy hasło PFX jest tym samym co hasło prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Technicznie tak, pod warunkiem że zawiera dostępny prywatny klucz. Odbiorcy nie będą mu automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj korzystają z certyfikatu wydanego przez zaufany CA.

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana podpisanej zawartości prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest po prostu niepodpisana, a nie zawiera nieprawidłowego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie samodzielnie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w produkcji powinna również sprawdzać łańcuch certyfikatów, okres ważności, status unieważnienia, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpisanie odbyło się, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być nadal edytowana?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc zakończ edycję przed podpisaniem ostatecznej wersji.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje podpisu cyfrowego wyłącznie dla PPTX. Formaty PPT i OpenDocument nie są wspierane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.