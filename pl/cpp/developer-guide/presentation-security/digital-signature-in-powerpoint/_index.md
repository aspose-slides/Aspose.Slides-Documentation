---
title: Dodawanie podpisów cyfrowych do prezentacji w C++
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
description: "Dowiedz się, jak podpisać istniejące prezentacje PPTX przy użyciu certyfikatów PFX i wykorzystać Aspose.Slides dla C++ do weryfikacji lub usuwania podpisów cyfrowych."
---
## **Przegląd**

Podpis cyfrowy pomaga odbiorcy określić, kto podpisał prezentację i czy podpisana treść uległa zmianie. Trzy powiązane pojęcia bezpieczeństwa są tutaj istotne:

- **certyfikat cyfrowy** to elektroniczny dokument potwierdzający tożsamość i powiązujący ją z kluczem publicznym. Zaufany urząd certyfikacji (CA) może wydać certyfikat, lub organizacja może używać certyfikatu samopodpisanego w wewnętrznych przepływach pracy.
- **podpis cyfrowy** jest tworzony z treści prezentacji oraz prywatnego klucza posiadacza certyfikatu. Publiczny klucz certyfikatu może być następnie użyty do weryfikacji podpisu. Podpis dostarcza dowodu pochodzenia i integralności; nie szyfruje prezentacji.
- **Ochrona hasłem** kontroluje, czy użytkownik może otworzyć lub modyfikować prezentację. Jest oddzielna od podpisywania cyfrowego i jest opisana w [Prezentacje chronione hasłem](/cpp/password-protected-presentation/).

PowerPoint udostępnia polecenie **Dodaj podpis cyfrowy** w menu **Plik > Informacje > Zabezpiecz prezentację**.

![Menu PowerPoint Zabezpiecz prezentację z podświetlonym poleceniem Dodaj podpis cyfrowy](add-digital-signature-in-powerpoint.png)

Po otwarciu podpisanej prezentacji PowerPoint może wyświetlić powiadomienie o stanie podpisu.

![Powiadomienie PowerPoint informujące, że prezentacja zawiera prawidłowe podpisy](digital-signature-status-in-powerpoint.png)

Aspose.Slides udostępnia podpisy poprzez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/), który zwraca [IDigitalSignatureCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/), którego elementy implementują [IDigitalSignature](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/). Prezentacja może zawierać wiele podpisów.

## **Zrozumienie certyfikatów PFX i haseł**

Plik PFX, znany również jako plik PKCS#12 i zwykle mający rozszerzenie `.pfx` lub `.p12`, może zawierać certyfikat X.509, jego klucz prywatny oraz łańcuch certyfikatów. Klucz prywatny umożliwia posiadaczowi stworzenie podpisu. Certyfikat bez dostępnego klucza prywatnego nie może być użyty do podpisania prezentacji.

Hasło PFX chroni pakiet certyfikatu i klucz prywatny. Nie jest **hasłem** do otwierania lub edycji prezentacji. Nie zapisuj plików PFX ani ich haseł w systemie kontroli wersji. W środowisku produkcyjnym ogranicz dostęp do pliku certyfikatu i pobieraj hasło z magazynu sekretów lub innego chronionego źródła konfiguracji. Poniższe przykłady używają zmiennej środowiskowej jedynie po to, aby nie osadzać hasła w kodzie.

## **Dodanie podpisu cyfrowego do prezentacji**

Aby podpisać rzeczywisty przepływ pracy z prezentacją, wczytaj istniejący plik PPTX, utwórz [DigitalSignature](https://reference.aspose.com/slides/pl/cpp/aspose.slides/digitalsignature/) używając certyfikatu PFX i jego hasła, dodaj podpis do kolekcji prezentacji i zapisz do pliku PPTX.

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

Zapisanie wyniku pod nową nazwą zachowuje niepodpisany plik źródłowy. Wartość [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/set_comments/) opisuje cel podpisu; nie jest to mechanizm bezpieczeństwa.

## **Weryfikacja podpisów cyfrowych**

Gdy wczytujesz podpisany plik PPTX, sprawdź każdy element zwrócony przez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Metoda [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/get_isvalid/) wskazuje, czy osadzony podpis jest ważny dla bieżącej treści prezentacji.

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

Nieprawidłowy wynik zwykle oznacza, że treść podpisanej prezentacji lub dane podpisu zostały zmienione po podpisaniu, lub że plik jest uszkodzony. Usunięcie wszystkich podpisów tworzy niepodpisaną prezentację, więc sprawdzanie tylko ważności elementów nie wystarcza: wrażliwy na bezpieczeństwo przepływ pracy musi również zweryfikować, czy występuje oczekiwana liczba podpisów i oczekiwane tożsamości podpisujących.

Ten wynik ważności nie powinien być traktowany jako pełna decyzja o zaufaniu do certyfikatu. W zależności od polityki bezpieczeństwa, aplikacja może również potrzebować zbudować i zweryfikować łańcuch certyfikatów X.509, sprawdzić daty ważności certyfikatu i status odwołania, potwierdzić oczekiwany podmiot lub odcisk palca, zweryfikować użycie klucza oraz ocenić zaufany znacznik czasu. Wartość [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignature/get_signtime/) sama w sobie nie jest dowodem od zaufanego organu znaczników czasu.

## **Usuwanie podpisów cyfrowych**

Usuwanie podpisów zmienia stan bezpieczeństwa prezentacji. Poniższy przykład wczytuje podpisany plik PPTX, usuwa wszystkie podpisy za pomocą [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/clear/), i zapisuje niepodpisaną kopię.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Aby usunąć tylko jeden podpis, wywołaj [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idigitalsignaturecollection/removeat/) z jego indeksie zerowym. Zapisz do nowego pliku, chyba że nadpisywanie podpisanego oryginału jest wyraźną częścią Twojego przepływu pracy.

## **Rozważania dotyczące edycji i formatu**

- Podpis nie sprawia, że prezentacja jest tylko do odczytu. Użytkownicy i aplikacje nadal mogą edytować plik, ale zmiany w podpisanej treści zazwyczaj unieważniają istniejący podpis.
- Wykonaj wszystkie zamierzone edycje przed podpisaniem. Jeśli prezentacja musi być zmieniona, zapisz zrewidowaną wersję i ponownie ją podpisz.
- Zachowaj końcowy wynik w formacie PPTX. Konwersja podpisanej prezentacji do innego formatu nie przenosi oryginalnego podpisu PPTX jako ważnego podpisu dla pliku po konwersji.
- Traktuj klucz prywatny certyfikatu jako wrażliwy. Każdy, kto uzyska klucz prywatny i jego hasło, może tworzyć podpisy wydające się pochodzić od posiadacza tego certyfikatu.
- Zachowaj niepodpisane źródło lub inną kontrolowaną kopię, gdy polityka przechowywania dokumentów tego wymaga.

## **FAQ**

**Czy podpis cyfrowy szyfruje prezentację?**

Nie. Podpis cyfrowy dostarcza dowodu na temat pochodzenia i integralności, ale treść prezentacji pozostaje czytelna, chyba że zastosowano oddzielne szyfrowanie. Użyj [ochrony hasłem](/cpp/password-protected-presentation/), gdy dostęp do treści musi być ograniczony.

**Czy hasło PFX jest takie samo jak hasło do prezentacji?**

Nie. Hasło PFX odblokowuje klucz prywatny przechowywany w pakiecie certyfikatu. Nie kontroluje, kto może otworzyć lub edytować plik PPTX.

**Czy mogę używać certyfikatu samopodpisanego?**

Technicznie, certyfikat samopodpisany może być użyty, jeśli zawiera dostępny klucz prywatny. Odbiorcy nie będą go automatycznie ufać, chyba że certyfikat zostanie explicite dodany do ich zaufanego środowiska. Publiczne lub międzyorganizacyjne przepływy pracy zazwyczaj używają certyfikatu wydanego przez zaufany urząd certyfikacji.

**Co powoduje, że podpis jest nieprawidłowy?**

Zmiana podpisanej treści prezentacji lub danych podpisu po podpisaniu może unieważnić podpis. Uszkodzenie pliku także może spowodować niepowodzenie weryfikacji. Jeśli wszystkie podpisy zostaną usunięte, prezentacja jest niepodpisana, a nie plik zawierający nieprawidłowy podpis.

**Czy prawidłowy podpis oznacza, że powinienem ufać podpisującemu?**

Nie samodzielnie. Integralność podpisu i zaufanie do podpisującego to odrębne decyzje. Polityka weryfikacji w produkcji powinna również sprawdzać łańcuch certyfikatów, okres ważności, status odwołania, oczekiwaną tożsamość, użycie klucza oraz wszelkie wymagania dotyczące zaufanego znacznika czasu.

**Co się dzieje, gdy certyfikat wygasa?**

Wygaśnięcie certyfikatu nie zmienia bajtów prezentacji, ale wpływa na ocenę zaufania do certyfikatu. Czy podpis pozostaje akceptowalny, zależy od Twojej polityki oraz od tego, czy ważny zaufany znacznik czasu potwierdza, że podpis został wykonany, gdy certyfikat był ważny. Nie polegaj wyłącznie na wyświetlanym czasie podpisu jako zaufanym znaczniku czasu.

**Czy podpisana prezentacja nadal może być edytowana?**

Tak. Podpisanie nie blokuje pliku. Edycja podpisanej treści zazwyczaj unieważnia istniejący podpis, więc najpierw zakończ prezentację i podpisz ostateczną wersję.

**Czy prezentacja może zawierać więcej niż jeden podpis?**

Tak. Dodaj każdy podpis do kolekcji zwróconej przez [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_digitalsignatures/) przed zapisaniem. Podczas weryfikacji sprawdź każdy podpis i potwierdź, że wszyscy wymagani podpisujący są obecni.

**Jakie formaty prezentacji obsługują te operacje?**

Aspose.Slides obsługuje operacje podpisu cyfrowego opisane tutaj wyłącznie dla PPTX. Formaty PPT i OpenDocument nie są obsługiwane przez ten workflow API.

**Czy mogę usunąć podpis bez wpływu na slajdy?**

Tak. Możesz usunąć jeden podpis lub wyczyścić całą kolekcję, a następnie zapisać prezentację. Zawartość slajdów pozostaje dostępna, ale zapisany plik nie zawiera już dowodu usuniętego podpisu.