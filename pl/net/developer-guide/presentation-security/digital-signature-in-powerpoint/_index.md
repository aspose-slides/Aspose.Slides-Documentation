---
title: Dodawanie podpisów cyfrowych do prezentacji w .NET
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX przy użyciu certyfikatów PFX oraz korzystać z Aspose.Slides dla .NET do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** to elektroniczne poświadczenie, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, lub organizacja może używać certyfikatu self‑signed w wewnętrznych procesach.
- **podpis cyfrowy** jest tworzony z treści prezentacji i prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowód pochodzenia i integralności; nie szyfruje prezentacji.
- **ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub zmodyfikować prezentację. Jest niezależna od podpisu cyfrowego i jest opisana w [Prezentacje zabezpieczone hasłem](/slides/pl/net/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation z podświetnionym Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy za pośrednictwem [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/), [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/), którego elementy implementują [IDigitalSignature](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i najczęściej posiadający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest **hasłem** do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i uzyskaj jego hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej tylko po to, aby nie osadzać hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy z prezentacją, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Zapisanie wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość [DigitalSignature.Comments](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignature/comments/) opisuje cel podpisu; nie jest mechanizmem zabezpieczającym.

## **Weryfikacja podpisów cyfrowych**

Podczas wczytywania podpisanego pliku PPTX sprawdź każdy element w [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/). Właściwość [IDigitalSignature.IsValid](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/isvalid/) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej treści prezentacji.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Nieprawidłowy wynik zwykle oznacza, że treść podpisanej prezentacji lub dane podpisu uległy zmianie po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzenie jedynie poprawności elementów nie wystarcza: wrażliwy na bezpieczeństwo przepływ pracy musi również zweryfikować, czy występuje oczekiwana liczba podpisów oraz oczekiwane tożsamości podpisujących.

Ten wynik weryfikacji nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może również wymagać budowy i weryfikacji łańcucha certyfikatów X.509, sprawdzenia dat ważności certyfikatu i statusu unieważnienia, potwierdzenia oczekiwanego podmiotu lub odcisku palca, weryfikacji użycia klucza oraz oceny zaufanego znacznika czasu. Wartość [IDigitalSignature.SignTime](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/signtime/) sama w sobie nie jest dowodem od zaufanego urzędu czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/removeat/) z jego indeksem zerowym. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźną częścią Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich zamierzonych edycji przed podpisaniem. Jeśli prezentacja musi być zmieniona, zapisz zrewidowaną wersję i ponownie podpisz tę wersję.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w przekształconym pliku.
- Traktuj klucz prywatny certyfikatu jako poufny. Każdy, kto zdobędzie klucz prywatny i jego hasło, może tworzyć podpisy, które wyglądają, jakby pochodziły od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowód pochodzenia i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano osobne szyfrowanie. Użyj [ochrony hasłem](/slides/pl/net/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest tym samym co hasło do prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu self‑signed?**

Technicznie, certyfikat self‑signed może być użyty, jeśli zawiera dostępny klucz prywatny. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne procesy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji (CA).

**Co sprawia, że podpis jest nieprawidłowy?**

Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku może również spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plikiem zawierającym nieprawidłowy podpis.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**

Nie samo w sobie. Integralność podpisu i zaufanie do podpisującego są odrębnymi decyzjami. Polityka weryfikacji w środowisku produkcyjnym powinna również sprawdzać łańcuch certyfikatów, okres ważności, status unieważnienia, oczekiwaną tożsamość, użycie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki oraz od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlonym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być nadal edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw ukończ prezentację i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj wyłącznie dla PPTX. Formaty PPT i OpenDocument nie są obsługiwane przez ten przepływ pracy API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.