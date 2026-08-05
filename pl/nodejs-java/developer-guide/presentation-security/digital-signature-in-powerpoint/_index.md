---
title: Dodaj podpisy cyfrowe do prezentacji w JavaScript
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
- zweryfikuj podpis
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz korzystać z Aspose.Slides dla Node.js w języku Java w celu weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Ważne są tutaj trzy powiązane pojęcia bezpieczeństwa:

- **certyfikat cyfrowy** to elektroniczne poświadczenie, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych procesach.
- **podpis cyfrowy** jest tworzony z treści prezentacji i klucza prywatnego posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodów pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub zmodyfikować prezentację. Jest ona odrębna od podpisywania cyfrowego i opisana w [Prezentacje chronione hasłem](/nodejs-java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w **Plik > Informacje > Chroń prezentację**.

![Menu PowerPoint Chroń prezentację z podświetloną opcją Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera ważne podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), które zwraca [DigitalSignatureCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/) zawierającą obiekty [DigitalSignature](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle mający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi utworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może służyć do podpisywania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej jedynie po to, aby nie osadzać hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

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

## **Walidacja podpisów cyfrowych**

Podczas wczytywania podpisanego pliku PPTX, sprawdź każdy element zwrócony przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Metoda [DigitalSignature.isValid](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) wskazuje, czy osadzony podpis jest ważny dla bieżącej treści prezentacji.

Poniższy przykład używa również klasy Node.js `X509Certificate` do odczytania nazwy podmiotu z każdego osadzonego certyfikatu.

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

Nieprawidłowy wynik zwykle oznacza, że treść podpisanej prezentacji lub dane podpisu zmieniły się po podpisaniu, albo że plik jest uszkodzony. Usunięcie każdego podpisu powoduje uzyskanie niepodpisanej prezentacji, więc sprawdzanie wyłącznie poprawności elementów nie wystarcza: wrażliwy na bezpieczeństwo przepływ pracy musi również zweryfikować, że obecna jest oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może także budować i weryfikować łańcuch certyfikatów X.509, sprawdzać daty ważności i status odwołania certyfikatu, potwierdzać oczekiwany podmiot lub odcisk palca, weryfikować użycie klucza oraz oceniać zaufany znacznik czasu. Wartość zwracana przez [DigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignature/) sama w sobie nie jest dowodem od zaufanego wystawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy metodą [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

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

Aby usunąć tylko jeden podpis, wywołaj [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) z jego indeksu zerowego. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest świadomą częścią Twojego procesu.

## **Uwagi dotyczące edycji i formatów**

- Podpis nie czyni prezentacji tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Wykonaj wszystkie planowane zmiany przed podpisaniem. Jeśli prezentacja musi być zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj klucz prywatny certyfikatu jako poufny. Każdy, kto zdobędzie klucz prywatny i jego hasło, może tworzyć podpisy, które będą wydawały się pochodzić od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodów pochodzenia i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano osobne szyfrowanie. Użyj [password protection](/nodejs-java/password-protected-presentation/) gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest tym samym co hasło do prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie, certyfikat samopodpisany może być użyty, pod warunkiem że zawiera dostępny klucz prywatny. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie explicite dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne procesy zwykle korzystają z certyfikatu wydanego przez zaufany CA.

**Co powoduje, że podpis jest nieważny?**

Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie walidacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plikiem zawierającym nieważny podpis.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie samo w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w produkcji powinna również sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanej godzinie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być dalej edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ pracę nad prezentacją i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje podpisu cyfrowego wyłącznie dla PPTX. Format PPT oraz OpenDocument nie są wspierane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.