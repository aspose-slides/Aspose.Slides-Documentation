---
title: Zabezpieczanie prezentacji hasłem w PHP
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/php-java/password-protected-presentation/
keywords:
  - prezentacja zabezpieczona hasłem
  - hasło otwierające
  - szyfrowanie PowerPoint
  - deszyfrowanie PowerPoint
  - weryfikacja hasła prezentacji
  - sprawdzenie hasła prezentacji
  - otwieranie zaszyfrowanej prezentacji
  - usuwanie szyfrowania
  - PowerPoint
  - PPT
  - PPTX
  - prezentacja
  - PHP
  - Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX chronione hasłem w PHP przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane do załadowania i wyświetlenia zawartości prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła ochrony przed zapisem. Ochrona przed zapisem ogranicza modyfikację, ale nie szyfruje treści ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami do modyfikacji prezentacji, zobacz [Zabezpiecz prezentacje przed zapisem](/slides/pl/php-java/write-protected-presentation/).

Poniższe przepływy pracy mają zastosowanie zarówno do prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy ich zachowanie oparte na pliku i strumieniu jest istotne.

## **Zaszyfruj prezentację przy użyciu hasła otwierającego**

Użyj [ProtectionManager::encrypt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#encrypt), aby przypisać hasło otwierające. Następnie użyj [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save), aby zapisać zaszyfrowaną prezentację.

Poniższy przykład szyfruje prezentację PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utrzymaj właściwości dokumentu publiczne**

Domyślnie Aspose.Slides uwzględnia właściwości dokumentu w szyfrowaniu prezentacji. Metoda [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) kontroluje to zachowanie niezależnie od szyfrowania zawartości slajdów. Przekaż `false` przed wywołaniem [ProtectionManager::encrypt](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#encrypt), gdy system indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami musi odczytywać metadane bez hasła otwierającego.

Poniższy przykład tworzy zaszyfrowaną prezentację PPTX, pozostawiając jej wbudowane właściwości dokumentu publiczne:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przekazanie `false` do [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) nie powoduje, że slajdy, mastery, układy, kształty, multimedia ani inna zawartość prezentacji stają się publiczne. Dotyczy to wyłącznie właściwości dokumentu. Aby odczytać te właściwości bez ładowania zaszyfrowanej treści, zobacz [Zarządzaj właściwościami prezentacji](/slides/pl/php-java/presentation-properties/).

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie nie powodzi się, gdy wymagane jest hasło otwierające, ale podane hasło jest brakujące lub nieprawidłowe.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Pracuj z odszyfrowaną prezentacją.
} finally {
    $presentation->dispose();
}
```

## **Usuń szyfrowanie z prezentacji**

Załaduj prezentację przy użyciu jej hasła otwierającego, wywołaj [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeEncryption) i zapisz wynik. Zapisaną prezentację można następnie załadować bez hasła.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sprawdź poprawność hasła otwierającego przed załadowaniem**

Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość przy użyciu [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Przepływ pracy przy użyciu ścieżki pliku**

Poniższy przykład weryfikuje hasło otwierające dla pliku PPTX, przekazuje zweryfikowaną wartość do [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword), a następnie ładuje pełną prezentację:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Przepływ pracy przy użyciu strumienia**

Przeciążenie strumieniowe [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego wyszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

Poniższy przykład używa pliku PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Wartości zwracane przez checkPassword**

Metoda [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkPassword) zwraca `true` tylko wtedy, gdy prezentacja posiada hasło otwierające i podane hasło jest poprawne. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest niepoprawne.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu prawidłowego hasła, sprawdź [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isEncrypted), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) jak opisano powyżej.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Zalecenia bezpieczeństwa**

{{% alert color="warning" title="Bezpieczeństwo" %}}
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych powtarzalnych prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to konieczne, oraz ponownie użyj wyniku udanej weryfikacji przy natychmiastowym ładowaniu prezentacji.

Publiczne właściwości dokumentu mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe, mimo że zawartość prezentacji jest zaszyfrowana. Szyfruj wrażliwe metadane wraz z prezentacją. Pozostawienie właściwości publicznych powinno być wyraźną decyzją podjętą tylko wtedy, gdy systemy muszą indeksować, klasyfikować, wyszukiwać lub zarządzać plikiem bez hasła otwierającego.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
1. Wybierz lub prześlij prezentację.
1. Wprowadź hasło do ochrony wyświetlania.
1. Opcjonalnie wprowadź osobne hasło do ochrony edycji.
1. Zastosuj ochronę i pobierz powstały plik.

{{% alert color="info" title="Zobacz również" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/php-java/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem ochrony przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło ochrony przed zapisem ogranicza modyfikację bez szyfrowania treści.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy aplikacja może odczytać metadane bez hasła otwierającego?**

Tak, ale tylko wtedy, gdy prezentacja została zaszyfrowana z wyłączonym szyfrowaniem właściwości dokumentu. Aplikacja musi wtedy używać trybu ładowania wyłącznie właściwości dokumentu opisanego w [Zarządzaj właściwościami prezentacji](/slides/pl/php-java/presentation-properties/).

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku i strumieniu zachowują się identycznie dla prezentacji PPT i PPTX.