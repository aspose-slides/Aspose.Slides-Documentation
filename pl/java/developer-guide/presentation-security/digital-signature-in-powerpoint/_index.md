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
description: "Dowiedz się, jak podpisać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz wykorzystać Aspose.Slides dla Javy do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Cyfrowy podpis pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane koncepcje bezpieczeństwa są tutaj istotne:

- **Certyfikat cyfrowy** to elektroniczne poświadczenie, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wystawić certyfikat, lub organizacja może użyć certyfikatu samopodpisanego w wewnętrznych procesach.
- **Podpis cyfrowy** jest tworzony z treści prezentacji i prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może następnie posłużyć do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub zmodyfikować prezentację. Jest ona oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje zabezpieczone hasłem](/java/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w ramach **File > Info > Protect Presentation**.

![Menu Ochrona prezentacji w PowerPoint z podświetnionym poleceniem Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy za pośrednictwem [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), które zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/) zawierającą elementy implementujące [IDigitalSignature](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i najczęściej mający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępnego prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. Nie jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło ze sklepu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej jedynie po to, by nie osadzać hasła w kodzie.

## **Dodaj podpis cyfrowy do prezentacji**

Aby podpisać rzeczywisty przepływ pracy prezentacji, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/java/com.aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz jako plik PPTX.

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

Zapisanie wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość ustawiona przez [IDigitalSignature.setComments](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) opisuje cel podpisu; nie jest to mechanizm bezpieczeństwa.

## **Walidacja podpisów cyfrowych**

Po wczytaniu podpisanego pliku PPTX przeanalizuj każdy element zwrócony przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#isValid--) wskazuje, czy osadzony podpis jest ważny dla bieżącej zawartości prezentacji.

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

Wynik nieprawidłowy zwykle oznacza, że zawartość prezentacji lub dane podpisu uległy zmianie po podpisaniu, albo plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje, że prezentacja jest niepodpisana, więc sprawdzanie wyłącznie ważności elementów nie wystarczy: wrażliwy na bezpieczeństwo przepływ pracy musi dodatkowo zweryfikować oczekiwaną liczbę podpisów oraz tożsamości oczekiwanych sygnatariuszy.

Ten wynik nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa Twoja aplikacja może także potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności i status odwołania, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Sama wartość zwracana przez [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignature/#getSignTime--) nie jest dowodem pochodzącym od zaufanego dostawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan zabezpieczeń prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/#clear--), i zapisuje niepodpisaną kopię.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) z jego zerowym indeksem. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźnym elementem Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Dokończ wszystkie zamierzone edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz poprawioną wersję i podpisz ją ponownie.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi pierwotnego podpisu PPTX jako ważnego podpisu w przekonwertowanym pliku.
- Traktuj prywatny klucz certyfikatu jako poufny. Każdy, kto zdobędzie prywatny klucz i jego hasło, może tworzyć podpisy, które wydają się pochodzić od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu pochodzenia i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [zabezpieczenia hasłem](/java/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest tym samym co hasło prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie tak, pod warunkiem że zawiera dostępny prywatny klucz. Odbiorcy nie będą automatycznie mu ufać, chyba że certyfikat zostanie jawnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj korzystają z certyfikatu wystawionego przez zaufany urząd certyfikacji.

**Co powoduje, że podpis jest nieważny?**

Zmiana treści podpisanej prezentacji lub danych podpisu po jego utworzeniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieważnego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać sygnatariuszowi?**

Nie samodzielnie. Integralność podpisu i zaufanie do sygnatariusza to odrębne decyzje. Polityka walidacji produkcyjnej powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się stanie, gdy certyfikat wygaśnie?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja nadal może być edytowana?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, dlatego najpierw skończ prezentację i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani sygnatariusze są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje związane z podpisem cyfrowym wyłącznie dla formatu PPTX. Format PPT i OpenDocument nie są obsługiwane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie będzie już zawierał dowodu usuniętego podpisu.