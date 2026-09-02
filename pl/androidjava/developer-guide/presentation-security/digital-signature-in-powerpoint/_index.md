---
title: Dodawanie podpisów cyfrowych do prezentacji na Androidzie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz korzystać z Aspose.Slides dla Androida w Javie, aby weryfikować lub usuwać podpisy cyfrowe."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy ustalić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Ważne są trzy powiązane pojęcia bezpieczeństwa:

- **Certyfikat cyfrowy** to elektroniczne poświadczenie, które wiąże tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, albo organizacja może używać certyfikatu samopodpisanego w wewnętrznych procesach.
- **Podpis cyfrowy** jest tworzony z treści prezentacji i klucza prywatnego posiadacza certyfikatu. Następnie klucz publiczny certyfikatu może służyć do weryfikacji podpisu. Podpis dostarcza dowodów pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest ona oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje chronione hasłem](/androidjava/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu PowerPoint – Ochrona prezentacji z podświetnioną opcją Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera ważne podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), które zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/) zawierającą elementy implementujące [IDigitalSignature](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i często o rozszerzeniu `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest to hasło do otwierania lub edycji prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj hasło z magazynu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby nie osadzać hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywistą prezentację, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

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

Zapis wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość ustawiona za pomocą [IDigitalSignature.setComments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) opisuje cel podpisu; nie jest to mechanizm kontroli bezpieczeństwa.

## **Weryfikacja podpisów cyfrowych**

Kiedy wczytujesz podpisany plik PPTX, sprawdź każdy element zwrócony przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Metoda [IDigitalSignature.isValid](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#isValid--) wskazuje, czy wbudowany podpis jest ważny dla bieżącej treści prezentacji.

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

Nieprawidłowy wynik zazwyczaj oznacza, że treść podpisanej prezentacji lub dane podpisu uległy zmianie po podpisaniu, albo że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje utworzenie niepodpisanej prezentacji, więc sprawdzenie jedynie ważności elementów nie wystarczy: wrażliwy proces musi także zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa aplikacja może także budować i weryfikować łańcuch certyfikatów X.509, sprawdzać daty ważności i status odwołania certyfikatu, potwierdzać oczekiwany podmiot lub odcisk palca, weryfikować użycie klucza oraz oceniać zaufany znacznik czasu. Wartość zwracana przez [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) sama w sobie nie jest dowodem pochodzącym od zaufanego dostawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy przy użyciu [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), i zapisuje niepodpisaną kopię.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) z jego indeksu bazowanego na zero. Zapisz do nowego pliku, chyba że nadpisanie podpisanego oryginału jest wyraźną częścią Twojego procesu.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja staje się tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zwykle unieważniają istniejący podpis.
- Dokonaj wszystkich zamierzonych edycji przed podpisaniem. Jeśli prezentację trzeba zmienić, zapisz zaktualizowaną wersję i ponownie podpisz tę wersję.
- Zachowaj ostateczny plik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w pliku po konwersji.
- Traktuj klucz prywatny certyfikatu jako wrażliwy. Ktokolwiek uzyska klucz prywatny i jego hasło może tworzyć podpisy wyglądające na pochodzące od tego posiadacza certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy polityka przechowywania dokumentów tego wymaga.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodów dotyczących pochodzenia i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [password protection](/androidjava/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest tym samym, co hasło prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Technicznie tak, pod warunkiem że zawiera dostępny klucz prywatny. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. W typowych procesach między organizacjami używa się certyfikatów wydanych przez zaufany CA.

**Co powoduje, że podpis jest nieważny?**

Zmiana treści podpisanej prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja po prostu pozostaje niepodpisana, a nie zawiera nieważnego podpisu.

**Czy ważny podpis oznacza, że powinienem ufać podpisującemu?**

Nie sam w sobie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka weryfikacji produkcyjnej powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygaśnie?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony w okresie ważności certyfikatu. Nie polegaj wyłącznie na wyświetlonym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być dalej edytowana?**

Tak. Podpis nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ edycję, a dopiero potem podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje opisane tutaj operacje związane z podpisem cyfrowym wyłącznie dla formatu PPTX. Format PPT oraz OpenDocument nie są obsługiwane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć pojedynczy podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje nienaruszona, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.