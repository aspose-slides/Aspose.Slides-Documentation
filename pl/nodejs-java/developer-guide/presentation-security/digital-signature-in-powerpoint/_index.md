---
title: Dodawanie podpisów cyfrowych do prezentacji w JavaScript
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/nodejs-java/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisywać pliki PowerPoint i OpenDocument za pomocą Aspose.Slides dla Node.js w Javie. Zabezpiecz swoje slajdy w kilka sekund, korzystając z przejrzystych przykładów kodu."
---
## **Wstęp**

**Certyfikat cyfrowy** jest używany do tworzenia prezentacji PowerPoint zabezpieczonej hasłem, oznaczonej jako utworzonej przez konkretną organizację lub osobę. Certyfikat cyfrowy można uzyskać, kontaktując się z uprawnioną organizacją – wystawcą certyfikatów. Po zainstalowaniu certyfikatu cyfrowego w systemie można go używać do dodawania podpisu cyfrowego do prezentacji poprzez Plik -> Informacje -> Chroń prezentację:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden podpis cyfrowy. Po dodaniu podpisu cyfrowego do prezentacji w PowerPoint pojawi się specjalna wiadomość:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów w prezentacji, **Aspose.Slides API** udostępnia klasę [**DigitalSignature**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/DigitalSignature), klasę [**DigitalSignatureCollection**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/DigitalSignatureCollection) oraz metodę [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Obecnie podpisy cyfrowe są obsługiwane tylko dla formatu PPTX.
## **Dodawanie podpisu cyfrowego z certyfikatu PFX**
Poniższy przykład kodu pokazuje, jak dodać podpis cyfrowy z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do obiektu [**DigitalSignature**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/DigitalSignature).
1. Dodaj utworzony podpis do obiektu prezentacji.

```javascript
// Otwieranie pliku prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Utwórz obiekt DigitalSignature z plikiem PFX i hasłem PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Komentarz nowego podpisu cyfrowego
    signature.setComments("Aspose.Slides digital signing test.");
    // Dodaj podpis cyfrowy do prezentacji
    pres.getDigitalSignatures().add(signature);
    // Zapisz prezentację
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Teraz możesz sprawdzić, czy prezentacja została podpisana cyfrowo i nie została zmodyfikowana:

```javascript
// Otwórz prezentację
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Sprawdź, czy wszystkie podpisy cyfrowe są ważne
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja podpisów cyfrowych umożliwia [usuwanie pojedynczych elementów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) oraz [całkowite czyszczenie](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); po zapisaniu pliku prezentacja nie będzie zawierała żadnych podpisów.

**Czy plik staje się „tylko do odczytu” po podpisaniu?**

Nie. Podpis zachowuje integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć edycję, połącz go z ["Tylko do odczytu" lub hasłem](/slides/pl/nodejs-java/password-protected-presentation/).

**Czy podpis będzie wyświetlany poprawnie w różnych wersjach PowerPoint?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Nowoczesne wersje PowerPoint obsługujące podpisy OOXML wyświetlają status takich podpisów prawidłowo.