---
title: Dodawanie podpisów cyfrowych do prezentacji w Javie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/java/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- jednostka certyfikująca
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisać pliki PowerPoint i OpenDocument za pomocą Aspose.Slides for Java. Zabezpiecz swoje slajdy w kilka sekund, korzystając z przejrzystych przykładów kodu."
---
## **Wprowadzenie**

**Certyfikat cyfrowy** służy do tworzenia chronionej hasłem prezentacji PowerPoint, oznaczonej jako utworzonej przez określoną organizację lub osobę. Certyfikat cyfrowy można uzyskać, kontaktując się z autoryzowaną organizacją – jednostką certyfikującą. Po zainstalowaniu certyfikatu cyfrowego w systemie, można go użyć do dodania cyfrowego podpisu do prezentacji, wybierając Plik → Informacje → Chronienie prezentacji:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden cyfrowy podpis. Po dodaniu cyfrowego podpisu do prezentacji, w programie PowerPoint pojawi się specjalna wiadomość:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów w prezentacji, **Aspose.Slides API** udostępnia [**IDigitalSignature**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IDigitalSignature) **interfejs**, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IDigitalSignatureCollection) **interfejs** oraz [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentation#getDigitalSignatures--) **metodę**. Obecnie cyfrowe podpisy są obsługiwane wyłącznie dla formatu PPTX.
## **Dodaj cyfrowy podpis z certyfikatu PFX**
Poniższy przykład kodu pokazuje, jak dodać cyfrowy podpis z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do [**DigitalSignature**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/DigitalSignature) obiektu.
1. Dodaj utworzony podpis do obiektu prezentacji.

```java
// Otwieranie pliku prezentacji
Presentation pres = new Presentation();
try {
    // Utwórz obiekt DigitalSignature z plikiem PFX i hasłem PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Dodaj komentarz do nowego podpisu cyfrowego
    signature.setComments("Aspose.Slides digital signing test.");

    // Dodaj podpis cyfrowy do prezentacji
    pres.getDigitalSignatures().add(signature);

    // Zapisz prezentację
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Teraz można sprawdzić, czy prezentacja została cyfrowo podpisana i nie została zmodyfikowana:

```java
// Otwórz prezentację
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Sprawdź, czy wszystkie podpisy cyfrowe są ważne
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja cyfrowych podpisów obsługuje [usuwanie pojedynczych elementów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) oraz [czyszczenie jej w całości](https://reference.aspose.com/slides/pl/java/com.aspose.slides/digitalsignaturecollection/#clear--); po zapisaniu pliku prezentacja nie będzie zawierała żadnych podpisów.

**Czy plik staje się „tylko do odczytu” po podpisaniu?**

Nie. Podpis zachowuje integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć edycję, połącz go z ["Tylko do odczytu" lub hasło](/slides/pl/java/password-protected-presentation/).

**Czy podpis będzie wyświetlany poprawnie w różnych wersjach PowerPointa?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Współczesne wersje PowerPointa, które obsługują podpisy OOXML, wyświetlają status takich podpisów poprawnie.