---
title: Dodawanie cyfrowych podpisów do prezentacji w PHP
linktitle: Cyfrowy podpis
type: docs
weight: 10
url: /pl/php-java/digital-signature-in-powerpoint/
keywords:
- cyfrowy podpis
- certyfikat cyfrowy
- urząd certyfikacji
- certyfikat PFX
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak cyfrowo podpisać pliki PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP via Java. Zabezpiecz swoje slajdy w kilka sekund dzięki przejrzystym przykładom kodu."
---
## **Wprowadzenie**

**Cyfrowy certyfikat** służy do utworzenia prezentacji PowerPoint chronionej hasłem, oznaczonej jako utworzonej przez określoną organizację lub osobę. Cyfrowy certyfikat można uzyskać, kontaktując się z autoryzowaną organizacją – wystawcą certyfikatu. Po zainstalowaniu cyfrowego certyfikatu w systemie można go użyć do dodania cyfrowego podpisu do prezentacji za pomocą Plik -> Informacje -> Ochrona prezentacji:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentacja może zawierać więcej niż jeden cyfrowy podpis. Po dodaniu cyfrowego podpisu do prezentacji w PowerPoincie pojawi się specjalna wiadomość:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Aby podpisać prezentację lub sprawdzić autentyczność podpisów w prezentacji, **Aspose.Slides API** udostępnia klasę [**DigitalSignature**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/DigitalSignature), klasę [**DigitalSignatureCollection**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/DigitalSignatureCollection) oraz metodę [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getDigitalSignatures). Obecnie cyfrowe podpisy są obsługiwane tylko dla formatu PPTX.

## **Dodaj cyfrowy podpis z certyfikatu PFX**

Poniższy przykład kodu pokazuje, jak dodać cyfrowy podpis z certyfikatu PFX:

1. Otwórz plik PFX i przekaż hasło PFX do obiektu [**DigitalSignature**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/DigitalSignature).
1. Dodaj utworzony podpis do obiektu prezentacji.

```php
  # Otwieranie pliku prezentacji
  $pres = new Presentation();
  try {
    # Utwórz obiekt DigitalSignature z plikiem PFX i hasłem PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Skomentuj nowy cyfrowy podpis
    $signature->setComments("Aspose.Slides digital signing test.");
    # Dodaj cyfrowy podpis do prezentacji
    $pres->getDigitalSignatures()->add($signature);
    # Zapisz prezentację
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Teraz można sprawdzić, czy prezentacja została cyfrowo podpisana i nie została zmodyfikowana:

```php
  # Otwórz prezentację
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Sprawdź, czy wszystkie cyfrowe podpisy są prawidłowe
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę usunąć istniejące podpisy z pliku?**

Tak. Kolekcja podpisów cyfrowych obsługuje [usuwanie poszczególnych elementów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/removeat/) i [czyszczenie całej kolekcji](https://reference.aspose.com/slides/pl/php-java/aspose.slides/digitalsignaturecollection/clear/); po zapisaniu pliku prezentacja nie będzie zawierała żadnych podpisów.

**Czy plik staje się „read-only” po podpisaniu?**

Nie. Podpis zapewnia integralność i autorstwo, ale nie blokuje edycji. Aby ograniczyć edytowanie, połącz go z ["Read-only" or a password](/slides/pl/php-java/password-protected-presentation/).

**Czy podpis będzie wyświetlany prawidłowo w różnych wersjach programu PowerPoint?**

Podpis jest tworzony dla kontenera OOXML (PPTX). Nowoczesne wersje PowerPointa, które obsługują podpisy OOXML, wyświetlają ich status poprawnie.