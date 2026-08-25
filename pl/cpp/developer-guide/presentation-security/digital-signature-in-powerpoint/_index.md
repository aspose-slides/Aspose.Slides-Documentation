---
title: Dodaj podpisy cyfrowe do prezentacji w C++
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Dowiedz się, jak podpisywać istniejące prezentacje PPTX za pomocą certyfikatów PFX i używać Aspose.Slides dla C++, aby weryfikować lub usuwać podpisy cyfrowe."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** to elektroniczne poświadczenie, które kojarzy tożsamość z kluczem publicznym. Zaufany organ certyfikacji (CA) może wystawić certyfikat, albo organizacja może używać samopodpisanego certyfikatu do wewnętrznych procesów.
- **podpis cyfrowy** jest tworzony z treści prezentacji i prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może następnie zostać użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest oddzielna od podpisu cyfrowego i jest opisana w [Prezentacje chronione hasłem](/slides/pl/cpp/password-protected-presentation/).

PowerPoint udostępnia polecenie **Add a Digital Signature** w menu **File > Info > Protect Presentation**.

![Menu Protect Presentation w PowerPoint z podświetnionym Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy przez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/), które zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/), którego elementy implementują [IDigitalSignature](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle posiadający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego prywatny klucz oraz łańcuch certyfikatów. Prywatny klucz umożliwia posiadaczowi tworzenie podpisu. Certyfikat bez dostępu do prywatnego klucza nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i prywatny klucz. Nie jest **hasłem** do otwierania lub edytowania prezentacji. Nie zapisuj plików PFX ani ich haseł w kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj jego hasło z magazynu tajemnic lub innego zabezpieczonego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej wyłącznie po to, aby uniknąć umieszczania hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywistą prezentację, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/cpp/aspose.slides/digitalsignature/) z certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zapisanie wyniku pod nową nazwą zachowuje niepodpisane źródło. Wartość [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/set_comments/) opisuje cel podpisu; nie jest kontrolą bezpieczeństwa.

## **Walidacja podpisów cyfrowych**

Gdy wczytasz podpisany plik PPTX, sprawdź każdy element zwrócony przez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Metoda [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/get_isvalid/) wskazuje, czy osadzony podpis jest prawidłowy dla bieżącej treści prezentacji.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Nieprawidłowy wynik zazwyczaj oznacza, że treść podpisanej prezentacji lub dane podpisu zostały zmienione po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów powoduje niepodpisaną prezentację, więc sprawdzenie jedynie ważności elementów nie wystarcza: proces wrażliwy na bezpieczeństwo musi również zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może również musieć zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności certyfikatu i jego status odwołania, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Wartość [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/get_signtime/) sama w sobie nie jest dowodem od zaufanego dostawcy znacznika czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy przy pomocy [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/removeat/) z jego zerowym indeksem. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźną częścią twojego procesu.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje wciąż mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Zakończ wszystkie planowane edycje przed podpisaniem. Jeśli prezentacja musi zostać zmieniona, zapisz zaktualizowaną wersję i ponownie ją podpisz.
- Zachowaj ostateczny plik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi pierwotnego podpisu PPTX jako ważnego podpisu w pliku konwertowanym.
- Traktuj prywatny klucz certyfikatu jako wrażliwy. Każdy, kto zdobędzie prywatny klucz i jego hasło, może tworzyć podpisy, które wydają się pochodzić od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy wymaga tego polityka przechowywania dokumentów.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu o pochodzeniu i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/slides/pl/cpp/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło do prezentacji?**

Nie. Hasło PFX odblokowuje prywatny klucz przechowywany w pakiecie certyfikatu. Nie kontroluje ono, kto może otworzyć lub edytować plik PPTX.

**Czy mogę użyć certyfikatu samopodpisanego?**

Technicznie, certyfikat samopodpisany może być użyty, jeśli zawiera dostępny prywatny klucz. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie wyraźnie dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne procesy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji (CA).

**Co sprawia, że podpis jest nieprawidłowy?**

Zmiana treści podpisanej prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku również może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plik zawierający nieprawidłowy podpis.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**

Nie samodzielnie. Integralność podpisu i zaufanie do podpisującego są odrębnymi decyzjami. Polityka weryfikacji w środowisku produkcyjnym powinna również sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz wszelkie wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od twojej polityki i od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został złożony, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako na zaufanym znaczniku czasu.

**Czy podpisana prezentacja może być nadal edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ prezentację i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj tylko dla formatu PPTX. Formaty PPT i OpenDocument nie są obsługiwane przez ten przepływ API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.