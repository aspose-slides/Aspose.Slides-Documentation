---
title: Zabezpieczanie prezentacji hasłem w PHP
linktitle: Ochrona hasłem
type: docs
weight: 20
url: /pl/php-java/password-protected-presentation/
keywords:
- prezentacja zabezpieczona hasłem
- hasło otwierające
- szyfruj PowerPoint
- odszyfruj PowerPoint
- weryfikuj hasło prezentacji
- sprawdź hasło prezentacji
- otwórz zaszyfrowaną prezentację
- usuń szyfrowanie
- PowerPoint
- PPT
- PPTX
- prezentacja
- PHP
- Aspose.Slides
description: "Szyfruj, wykrywaj, weryfikuj, otwieraj i odszyfrowuj prezentacje PowerPoint PPT i PPTX zabezpieczone hasłem w PHP przy użyciu Aspose.Slides."
---
## **Przegląd**

Hasło otwierające szyfruje prezentację. Poprawne hasło jest wymagane, aby załadować i wyświetlić zawartość prezentacji, więc ta ochrona zapewnia poufność.

Hasło otwierające różni się od hasła zabezpieczającego przed zapisem. Zabezpieczenie przed zapisem ogranicza modyfikacje, ale nie szyfruje zawartości ani nie uniemożliwia załadowania prezentacji. Aby zarządzać hasłami umożliwiającymi modyfikację prezentacji, zobacz [Zabezpiecz prezentacje przed zapisem](/slides/pl/php-java/write-protected-presentation/).

Poniższe przepływy pracy dotyczą zarówno prezentacji PPT, jak i PPTX. Przykłady używają obu formatów, gdy ich zachowanie oparte na plikach i strumieniach ma znaczenie.

## **Szyfruj prezentację hasłem otwierającym**

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

## **Załaduj zaszyfrowaną prezentację**

Ustaw [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword) na hasło otwierające i przekaż opcje do [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) podczas ładowania pliku. Ładowanie kończy się niepowodzeniem, gdy wymagane jest hasło otwierające, ale podane hasło jest brakujące lub nieprawidłowe.

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

Załaduj prezentację z jej hasłem otwierającym, wywołaj [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#removeEncryption) i zapisz wynik. Zapisana prezentacja może następnie być ładowana bez hasła.

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

## **Sprawdź poprawność hasła otwierającego przed ładowaniem**

Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo), aby uzyskać [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/) bez tworzenia pełnej instancji prezentacji. Sprawdź [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) przed żądaniem lub weryfikacją hasła. Gdy ochrona jest obecna, zweryfikuj podaną wartość za pomocą [PresentationInfo::checkPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Przepływ pracy z ścieżką pliku**

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

### **Przepływ pracy ze strumieniem**

Przeciążenie strumieniowe [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/#getPresentationInfo) zapewnia ten sam przepływ pracy. Zresetuj pozycję strumienia umożliwiającego przeszukiwanie przed załadowaniem pełnej prezentacji z tego strumienia.

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#checkPassword) zwraca `true` tylko wtedy, gdy prezentacja ma hasło otwierające i podane hasło jest prawidłowe. Zwraca `false` w każdym z następujących przypadków:

- Hasło jest nieprawidłowe.
- Prezentacja nie posiada hasła otwierającego.
- Podane hasło jest `null` lub puste.

Zachowanie jest takie samo dla prezentacji PPT i PPTX.

## **Sprawdź, czy załadowana prezentacja jest zaszyfrowana**

Po załadowaniu prezentacji przy użyciu prawidłowego hasła, sprawdź [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isEncrypted), aby potwierdzić, że źródłowa prezentacja była zaszyfrowana. Aby wykryć ochronę hasłem otwierającym przed ładowaniem, użyj [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isPasswordProtected) jak pokazano powyżej.

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
Nie rejestruj haseł otwierających ani nie umieszczaj ich w komunikatach diagnostycznych. Unikaj niepotrzebnych, powtarzających się prób weryfikacji, przechowuj hasła w pamięci tylko tak długo, jak jest to potrzebne, i ponownie użyj udanego wyniku weryfikacji przy natychmiastowym ładowaniu prezentacji.
{{% /alert %}}

## **Zabezpiecz prezentację hasłem online**

1. Otwórz aplikację [Aspose.Slides Lock](https://products.aspose.app/slides/pl/lock).
2. Wybierz lub prześlij prezentację.
3. Wprowadź hasło do ochrony podglądu.
4. Opcjonalnie wprowadź osobne hasło do ochrony edycji.
5. Zastosuj ochronę i pobierz otrzymany plik.

{{% alert color="info" title="Zobacz także" %}}
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/php-java/write-protected-presentation/)
- [Podpis cyfrowy w PowerPoint](/slides/pl/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między hasłem otwierającym a hasłem zabezpieczającym przed zapisem?**

Hasło otwierające szyfruje prezentację i jest wymagane do załadowania jej zawartości. Hasło zabezpieczające przed zapisem ogranicza modyfikacje bez szyfrowania treści.

**Czy mogę zweryfikować hasło otwierające bez ładowania wszystkich slajdów?**

Tak. Uzyskaj informacje o prezentacji, sprawdź, czy istnieje ochrona hasłem otwierającym, i zweryfikuj hasło przed utworzeniem pełnej instancji prezentacji.

**Czy przepływy weryfikacji hasła obsługują zarówno PPT, jak i PPTX?**

Tak. Wykrywanie i weryfikacja hasła oparte na ścieżce pliku oraz strumieniu działają identycznie dla prezentacji PPT i PPTX.