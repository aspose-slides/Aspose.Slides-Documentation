---
title: Dodawanie podpisów cyfrowych do prezentacji w Javie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak podpisać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz jak używać Aspose.Slides dla Javy do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Omówienie**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane koncepcje bezpieczeństwa są tutaj istotne:

- **cyfrowy certyfikat** jest elektronicznym poświadczeniem, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wystawić certyfikat, lub organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest ona oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje chronione hasłem](/slides/pl/java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation z podświetnionym przyciskiem Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), który zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/), którego elementy implementują [IDigitalSignature](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle posiadający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępnego prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby nie osadzać hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/java/com.aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```java
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

Zapisanie wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość ustawiona przez [IDigitalSignature.setComments](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) opisuje cel podpisu; nie jest to mechanizm bezpieczeństwa.

## **Weryfikacja podpisów cyfrowych**

Gdy wczytujesz podpisany plik PPTX, sprawdź każdy element zwrócony przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#isValid--) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej zawartości prezentacji.

```java
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

Wynik nieprawidłowy zazwyczaj oznacza, że zawartość podpisanej prezentacji lub dane podpisu zmieniły się po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje niepodpisaną prezentację, więc sprawdzenie jedynie ważności elementów nie wystarcza: wrażliwy na bezpieczeństwo przepływ pracy musi również zweryfikować, że występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, Twoja aplikacja może również potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności certyfikatu i status unieważnienia, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Wartość [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#getSignTime--) sama w sobie nie jest dowodem od zaufanego urzędu znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/#clear--), i zapisuje niepodpisaną kopię.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) z jego zerowym indeksem. Zapisz do nowego pliku, chyba że nadpisanie podpisanego oryginału jest wyraźną częścią Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich zamierzonych edycji przed podpisaniem. Jeśli prezentacja musi być zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto uzyska prywatny klucz i jego hasło, może tworzyć podpisy, które wyglądają, jakby pochodziły od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego Twoja polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale zawartość prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/slides/pl/java/password-protected-presentation/), gdy dostęp do zawartości musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło do prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie, certyfikat samopodpisany można użyć, gdy zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji.

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana podpisanej zawartości prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku może również spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plik zawierający nieprawidłowy podpis.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**

Nie samo w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka weryfikacji w produkcji powinna także sprawdzać łańcuch certyfikatów, okres ważności, status unieważnienia, oczekiwaną tożsamość, użycie klucza oraz wszelkie wymogi dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygasanie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być nadal edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ prezentację i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) przed zapisem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj wyłącznie dla formatu PPTX. Formaty PPT i OpenDocument nie są obsługiwane w tym przepływie API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.