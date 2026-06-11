---
title: Dodaj podpisy cyfrowe do prezentacji w C++
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/cpp/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- organ certyfikacji
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisać pliki PowerPoint i OpenDocument za pomocą Aspose.Slides dla C++. Zabezpiecz swoje slajdy w kilka sekund, korzystając z przejrzystych przykładów kodu."
---
## **Wprowadzenie**

**Certyfikat cyfrowy** jest używany do tworzenia prezentacji PowerPoint chronionych hasłem, oznaczonych jako utworzone przez określoną organizację lub osobę. Certyfikat cyfrowy można uzyskać, kontaktując się z autoryzowaną organizacją – urzędem certyfikacji. Po zainstalowaniu certyfikatu cyfrowego w systemie można go użyć do dodania podpisu cyfrowego do prezentacji poprzez Plik -> Informacje -> Ochrona prezentacji:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden podpis cyfrowy. Po dodaniu podpisu cyfrowego do prezentacji pojawi się specjalna wiadomość w PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów prezentacji, **Aspose.Slides API** udostępnia interfejs [**IDigitalSignature**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_digital_signature), interfejs [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_digital_signature_collection) oraz metodę [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Obecnie podpisy cyfrowe są obsługiwane tylko dla formatu PPTX.

## **Dodaj podpis cyfrowy z certyfikatu PFX**
Poniższy przykład kodu demonstruje, jak dodać podpis cyfrowy z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do obiektu [**DigitalSignature**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.digital_signature).
1. Dodaj utworzony podpis do obiektu prezentacji.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Utwórz obiekt DigitalSignature z plikiem PFX i hasłem PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Skomentuj nowy podpis cyfrowy
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Dodaj podpis cyfrowy do prezentacji
pres->get_DigitalSignatures()->Add(signature);

// Zapisz prezentację
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Teraz można sprawdzić, czy prezentacja została podpisana cyfrowo i nie została zmodyfikowana:

``` cpp
// Otwórz prezentację
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Sprawdź, czy wszystkie podpisy cyfrowe są ważne
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja podpisów cyfrowych obsługuje [usuwanie pojedynczych elementów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/digitalsignaturecollection/removeat/) oraz [całkowite czyszczenie](https://reference.aspose.com/slides/pl/cpp/aspose.slides/digitalsignaturecollection/clear/); po zapisaniu pliku prezentacja nie będzie zawierała żadnych podpisów.

**Czy plik staje się „tylko do odczytu” po podpisaniu?**

Nie. Podpis zachowuje integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć edycję, połącz go z [„Tylko do odczytu” lub hasłem](/slides/pl/cpp/password-protected-presentation/).

**Czy podpis będzie wyświetlany prawidłowo w różnych wersjach PowerPoint?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Nowoczesne wersje PowerPoint, które obsługują podpisy OOXML, wyświetlają status takich podpisów prawidłowo.