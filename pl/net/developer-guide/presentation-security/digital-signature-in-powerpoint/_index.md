---
title: Dodaj podpisy cyfrowe do prezentacji w .NET
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/net/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisać pliki PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Zabezpiecz swoje slajdy w kilka sekund dzięki przejrzystym przykładom kodu."
---
## **Wprowadzenie**

**Certyfikat cyfrowy** jest używany do tworzenia prezentacji PowerPoint chronionej hasłem, oznaczonej jako utworzonej przez określoną organizację lub osobę. Certyfikat cyfrowy można uzyskać, kontaktując się z autoryzowaną organizacją – urzędem certyfikacji. Po zainstalowaniu certyfikatu cyfrowego w systemie można go używać do dodania cyfrowego podpisu do prezentacji poprzez Plik → Informacje → Zabezpiecz prezentację:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden podpis cyfrowy. Po dodaniu cyfrowego podpisu do prezentacji pojawi się specjalna wiadomość w PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów, **Aspose.Slides API** udostępnia [**IDigitalSignature**](https://reference.aspose.com/slides/pl/net/aspose.slides/idigitalsignature) interfejs, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/pl/net/aspose.slides/IDigitalSignatureCollection) interfejs i [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/properties/digitalsignatures) właściwość. Obecnie podpisy cyfrowe są obsługiwane tylko dla formatu PPTX.

## **Dodaj podpis cyfrowy z certyfikatu PFX**

Przykład kodu poniżej pokazuje, jak dodać podpis cyfrowy z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do [**DigitalSignature**](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignature) obiektu.  
1. Dodaj utworzony podpis do obiektu prezentacji.

```c#
using (Presentation pres = new Presentation())
{
    // Utwórz obiekt DigitalSignature z plikiem PFX i hasłem PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Skomentuj nowy podpis cyfrowy
    signature.Comments = "Aspose.Slides digital signing test.";

    // Dodaj podpis cyfrowy do prezentacji
    pres.DigitalSignatures.Add(signature);

    // Zapisz prezentację
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Teraz można sprawdzić, czy prezentacja została podpisana cyfrowo i nie została zmodyfikowana:

```c#
// Otwórz prezentację
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Sprawdź, czy wszystkie podpisy cyfrowe są ważne
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja podpisów cyfrowych obsługuje [usuwanie poszczególnych elementów](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignaturecollection/removeat/) oraz [całkowite czyszczenie](https://reference.aspose.com/slides/pl/net/aspose.slides/digitalsignaturecollection/clear/); po zapisaniu pliku prezentacja nie będzie posiadała żadnych podpisów.

**Czy plik staje się „tylko do odczytu” po podpisaniu?**

Nie. Podpis zapewnia integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć możliwość edycji, połącz go z ["tylko do odczytu" lub hasłem](/slides/pl/net/password-protected-presentation/).

**Czy podpis będzie wyświetlany poprawnie w różnych wersjach PowerPointa?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Nowoczesne wersje PowerPointa obsługujące podpisy OOXML wyświetlają status takich podpisów poprawnie.