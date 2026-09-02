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
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX certyfikatami PFX oraz używać Aspose.Slides dla .NET do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana zawartość uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** jest elektronicznym poświadczeniem, które łączy tożsamość z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wystawić certyfikat, lub organizacja może używać certyfikatu samopodpisanego w wewnętrznych procesach.
- **podpis cyfrowy** jest tworzony z zawartości prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest ona oddzielna od podpisywania cyfrowego i jest opisana w [Prezentacje chronione hasłem](/net/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation z podświetnionym Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/), [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/), którego elementy implementują [IDigitalSignature](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle posiadający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. **Nie** jest to hasło do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło ze sklepu tajemnic lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby uniknąć osadzania hasła w kodzie.

## **Dodaj podpis cyfrowy do prezentacji**

Aby podpisać rzeczywistą prezentację, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

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

Zapis wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość [DigitalSignature.Comments](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignature/comments/) opisuje cel podpisu; nie jest to mechanizm kontroli bezpieczeństwa.

## **Walidacja podpisów cyfrowych**

Gdy wczytasz podpisany plik PPTX, sprawdź każdy element w [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/). Właściwość [IDigitalSignature.IsValid](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/isvalid/) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej zawartości prezentacji.

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

Nieprawidłowy wynik zazwyczaj oznacza, że zawartość podpisanej prezentacji lub dane podpisu uległy zmianie po podpisaniu, lub plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzanie jedynie poprawności elementów nie jest wystarczające: wrażliwy na bezpieczeństwo proces musi także zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik nie powinien być traktowany jako ostateczna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa aplikacja może również musieć zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności i status odwołania certyfikatu, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować przeznaczenie klucza oraz ocenić zaufany znacznik czasu. Wartość [IDigitalSignature.SignTime](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature/signtime/) sama w sobie nie jest dowodem od zaufanego wystawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usunięcie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignaturecollection/removeat/) z odpowiednim indeksem zerowym. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźnym elementem twojego procesu.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja staje się tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej zawartości zazwyczaj unieważniają istniejący podpis.
- Dokonaj wszystkich zamierzonych edycji przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu w pliku przekonwertowanym.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto zdobędzie prywatny klucz i jego hasło, może tworzyć podpisy, które wydają się pochodzić od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**  
Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale zawartość prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/net/password-protected-presentation/) gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie same jak hasło do prezentacji?**  
Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**  
Technicznie tak, pod warunkiem że zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Przepływy publiczne lub międzyorganizacyjne zazwyczaj korzystają z certyfikatu wystawionego przez zaufany urząd certyfikacji.

**Co powoduje, że podpis jest nieprawidłowy?**  
Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie zawiera nieprawidłowego podpisu.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**  
Nie samodzielnie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka walidacji w produkcji powinna także sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, przeznaczenie klucza oraz ewentualne wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**  
Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od twojej polityki oraz od tego, czy ważny zaufany znacznik czasu dowodzi, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanej godzinie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisaną prezentację można dalej edytować?**  
Tak. Podpis nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc zakończ edycję przed ostatecznym podpisaniem.

**Czy prezentacja może zawierać więcej niż jeden podpis?**  
Tak. Dodaj każdy podpis do [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/digitalsignatures/) przed zapisaniem. Podczas walidacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**  
Aspose.Slides obsługuje opisane tutaj operacje związane z podpisem cyfrowym wyłącznie dla formatu PPTX. Format PPT oraz OpenDocument nie są wspierane przez ten interfejs API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**  
Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje nienaruszona, ale zapisany plik nie będzie już zawierał dowodu podpisu.