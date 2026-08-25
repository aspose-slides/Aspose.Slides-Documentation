---
title: Dodaj podpisy cyfrowe do prezentacji na Androidzie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/androidjava/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- organ certyfikacji
- certyfikat PFX
- PKCS#12
- weryfikacja podpisu
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX i używać Aspose.Slides dla Androida w Javie do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** to elektroniczny dowód, który łączy tożsamość z kluczem publicznym. Zaufany organ certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **podpis cyfrowy** jest tworzony z treści prezentacji oraz klucza prywatnego posiadacza certyfikatu. Klucz publiczny certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest odrębna od podpisu cyfrowego i jest opisana w [Password-Protected Presentations](/slides/pl/androidjava/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w sekcji **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation z podświetnionym poleceniem Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), który zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/) zawierającą elementy implementujące [IDigitalSignature](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle z rozszerzeniem `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie w celu uniknięcia umieszczania hasła w kodzie.

## **Dodaj podpis cyfrowy do prezentacji**

Aby podpisać rzeczywisty przepływ pracy, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz jako plik PPTX.

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisanie wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość ustawiona przez [IDigitalSignature.setComments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) opisuje cel podpisu; nie jest to mechanizm zabezpieczający.

## **Weryfikacja podpisów cyfrowych**

Podczas wczytywania podpisanego pliku PPTX, przejrzyj każdy element zwrócony przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#isValid--) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej treści prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Nieprawidłowy wynik zazwyczaj oznacza, że treść prezentacji lub dane podpisu zostały zmienione po podpisaniu, albo że plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzanie jedynie poprawności elementów nie wystarcza: przepływ pracy wymagający bezpieczeństwa musi również weryfikować, czy oczekiwana liczba podpisów i tożsamości podpisujących jest obecna.

Ten wynik nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może także budować i weryfikować łańcuch certyfikatów X.509, sprawdzać daty ważności i status odwołania, potwierdzać oczekiwany podmiot lub odcisk palca, weryfikować użycie klucza oraz oceniać zaufany znacznik czasu. Wartość zwrócona przez [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) sama w sobie nie jest dowodem z zaufanego urzędu czasu.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy przy pomocy [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), i zapisuje niepodpisaną kopię.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) z jego indeksem bazującym na zerze. Zapisz do nowego pliku, chyba że nadpisanie podpisanego oryginału jest wyraźną częścią Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatów**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich planowanych edycji przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zrewidowaną wersję i ponownie ją podpisz.
- Zachowaj końcowy plik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj klucz prywatny certyfikatu jako wrażliwy. Każdy, kto zdobędzie klucz prywatny i jego hasło, może tworzyć podpisy, które wydają się pochodzić od posiadacza certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy polityka przechowywania dokumentów tego wymaga.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [password protection](/slides/pl/androidjava/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło do prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Technicznie tak, pod warunkiem że zawiera dostępny klucz prywatny. Odbiorcy nie będą automatycznie mu ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Przepływy pracy publiczne lub międzyorganizacyjne zazwyczaj korzystają z certyfikatu wydanego przez zaufany organ CA.

**Co sprawia, że podpis jest nieważny?**

Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieważnego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie samodzielnie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w produkcji powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygaśnie?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpisanie nastąpiło w czasie, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja nadal może być edytowana?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc zakończ edycję prezentacji przed jej podpisaniem.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane operacje podpisu cyfrowego wyłącznie dla PPTX. Format PPT oraz OpenDocument nie są obsługiwane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.