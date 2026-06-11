---
title: Dodawanie podpisów cyfrowych do prezentacji w Pythonie
linktitle: Podpis cyfrowy
type: docs
weight: 10
url: /pl/python-net/digital-signature-in-powerpoint/
keywords:
- podpis cyfrowy
- certyfikat cyfrowy
- organ certyfikacji
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisać pliki PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona w środowisku .NET. Zabezpiecz swoje slajdy w kilka sekund, korzystając z przejrzystych przykładów kodu."
---
## **Wstęp**

**Certyfikat cyfrowy** jest używany do tworzenia prezentacji PowerPoint zabezpieczonej hasłem, oznaczonej jako utworzonej przez określoną organizację lub osobę. Certyfikat cyfrowy można uzyskać, kontaktując się z upoważnioną organizacją – urzędem certyfikacji. Po zainstalowaniu certyfikatu cyfrowego w systemie można go używać do dodania podpisu cyfrowego do prezentacji przez Plik -> Informacje -> Ochrona prezentacji:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden podpis cyfrowy. Po dodaniu podpisu cyfrowego do prezentacji w programie PowerPoint pojawi się specjalna wiadomość:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów prezentacji, **Aspose.Slides API** udostępnia [**DigitalSignature**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/) klasę, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/DigitalSignatureCollection/) klasę i [**Presentation.digital_signatures**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/digital_signatures/) właściwość. Obecnie podpisy cyfrowe są obsługiwane wyłącznie dla formatu PPTX.

## **Dodaj podpis cyfrowy z certyfikatu PFX**

Poniższy przykład kodu pokazuje, jak dodać podpis cyfrowy z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do obiektu [**DigitalSignature**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignature/).
1. Dodaj utworzony podpis do obiektu prezentacji.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Utwórz obiekt DigitalSignature przy użyciu pliku PFX i hasła PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Skomentuj nowy podpis cyfrowy
    signature.comments = "Aspose.Slides digital signing test."

    # Dodaj podpis cyfrowy do prezentacji
    pres.digital_signatures.add(signature)

    # zapisz prezentację
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Teraz można sprawdzić, czy prezentacja została podpisana cyfrowo i nie została zmodyfikowana:

```py
# Otwórz prezentację
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Sprawdź, czy wszystkie podpisy cyfrowe są ważne
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja podpisów cyfrowych umożliwia [usuwanie pojedynczych elementów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/remove_at/) oraz [całkowite czyszczenie](https://reference.aspose.com/slides/pl/python-net/aspose.slides/digitalsignaturecollection/clear/); po zapisaniu pliku prezentacja nie będzie zawierała żadnych podpisów.

**Czy plik staje się „tylko do odczytu” po podpisaniu?**

Nie. Podpis zachowuje integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć edycję, połącz go z opcją ["Read-only" or a password](/slides/pl/python-net/password-protected-presentation/).

**Czy podpis będzie wyświetlany prawidłowo w różnych wersjach PowerPointa?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Nowoczesne wersje PowerPointa, które obsługują podpisy OOXML, wyświetlają status takich podpisów prawidłowo.